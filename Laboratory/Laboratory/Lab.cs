using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laboratory
{
    public partial class Lab : Form
    {

        public Lab()
        {
            InitializeComponent();
            button1.BringToFront();
            if (!(Directory.Exists("ff12-vbf") && File.Exists("ff12-vbf\\ff12-vbf.exe") &&
                File.Exists("ff12-vbf\\libgcc_s_seh-1.dll") && File.Exists("ff12-vbf\\libstdc++-6.dll") &&
                File.Exists("ff12-vbf\\libwinpthread-1.dll") && File.Exists("ff12-vbf\\zlib1.dll")))
            {
                MessageBox.Show("ffgriever's tools are missing. Exiting...");
                Environment.Exit(1);
            }
        }

        private void UpdateStatusLabel()
        {
            statusLabel.Text = $"Loaded. {Program.manager.modCount} mods available, {Program.manager.activeCount} mods active.";
        }

        private void loadVBFPicButton_Click(object sender, EventArgs e)
        {
            if (openVBFDialog.ShowDialog() == DialogResult.OK)
            {
                Cursor.Current = Cursors.WaitCursor;
                if(LoadVBF(openVBFDialog.FileName))
                {
                    UpdateStatusLabel();
                }
                else
                {
                    MessageBox.Show("Could not load the VBF.");
                }
                Cursor.Current = Cursors.Default;
            }
        }

        private bool LoadVBF(string filePath)
        {
            if (Program.LoadVBF(filePath))
            {
                LoadMods();
                addModButton.Enabled = true;
                settingsButton.Enabled = true;
                addModButton.Image = Properties.Resources.addmod;
                settingsButton.Image = Properties.Resources.options;

                return true;
            }
            Log("Failed to load the VBF.");
            return false;
        }

        private void LoadMods()
        {
            Program.manager = new ModManager();
            modList.Items.Clear();
            var e = Program.manager.GetEnumerator();
            int i = 0;
            while (e.MoveNext())
            {
                modList.Items.Add(e.Current.GetListItem());
                i++;
            }
            Program.manager.UpdateCurrentScaffold();
            Log($"Loaded {i} mods.");
        }

        private void addModButton_Click(object sender, EventArgs e)
        {
            if(addModDialog.ShowDialog() == DialogResult.OK)
            {
                Cursor.Current = Cursors.WaitCursor;
                var mod = Program.manager.AddMod(addModDialog.SelectedPath, this);
                if (mod != null)
                {
                    UpdateStatusLabel();
                    modList.Items.Add(mod.GetListItem());
                    Program.manager.Save();
                }
                Cursor.Current = Cursors.Default;
            }
        }

        private void modList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (modList.SelectedItems.Count == 0)
                return;

            var index = modList.SelectedItems[0].Index;
            var mod = Program.manager.GetMod(index);
            modDescriptionText.Text = mod.description;
            modAuthorText.Text = $"By {mod.author}";
            modNameText.Text = mod.modName;
            toolTip1.SetToolTip(modNameText, mod.modName);
            toolTip1.SetToolTip(modAuthorText, mod.author);
            toolTip1.SetToolTip(modVersionLabel, mod.version);
            modVersionLabel.Text = $"Version: {mod.version}";
            moveUpButton.Enabled = index > 0;
            moveDownButton.Enabled = index < modList.Items.Count - 1;
            switch(mod.state)
            {
                case ModState.ACTIVE:
                    toggleModButton.Image = Properties.Resources.disable;
                    toggleModButton.Enabled = true;
                    listFilesButton.Enabled = true;
                    break;
                case ModState.INACTIVE:
                    toggleModButton.Image = Properties.Resources.add;
                    toggleModButton.Enabled = true;
                    listFilesButton.Enabled = true;
                    break;
                case ModState.CORRUPTED:
                default:
                    toggleModButton.Image = null;
                    toggleModButton.Enabled = false;
                    listFilesButton.Enabled = false;
                    break;
            }
            removeModButton.Enabled = true;
            removeModButton.Image = Properties.Resources.delete1;
            listFilesButton.Image = Properties.Resources.files;
            
        }

        private void moveUpButton_Click(object sender, EventArgs e)
        {
            if (modList.SelectedItems.Count == 1)
            {
                var index = modList.SelectedItems[0].Index;
                if (index > 0)
                {
                    TradePlaces(index - 1, index);
                    RecalcRanks();
                }
            }
        }

        private void moveDownButton_Click(object sender, EventArgs e)
        {
            if (modList.SelectedItems.Count == 1)
            {
                var index = modList.SelectedItems[0].Index;
                if (index < modList.Items.Count - 1)
                {
                    TradePlaces(index + 1, index);
                    RecalcRanks();
                }
            }
        }

        private void TradePlaces(int i, int j)
        {
            Cursor.Current = Cursors.WaitCursor;

            Program.manager.TradePlaces(i, j);

            modList.Items.Clear();
            var e = Program.manager.GetEnumerator();
            while (e.MoveNext())
                modList.Items.Add(e.Current.GetListItem());

            modList.SelectedItems.Clear();
            modList.Items[i].Selected = modList.Items[i].Focused = true;
            modList.Focus();

            RecalcRanks();
            applyChangesButton.Enabled = Program.manager.hasChanges;

            Cursor.Current = Cursors.Default;
        }

        private void RecalcRanks()
        {
            for (int i = 0; i < modList.Items.Count; i++)
            {
                var item = modList.Items[i];
                item.SubItems[0] = new ListViewItem.ListViewSubItem(item, $"{i + 1}")
                {
                    BackColor = item.BackColor
                };
            }
            Program.manager.UpdateRanks();
        }

        private void removeModButton_Click(object sender, EventArgs e)
        {
            if(modList.SelectedItems.Count == 1 && MessageBox.Show("This will remove the mod from the list. This action is permanent. Proceed? This might take a while.", "Are you sure?", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Cursor.Current = Cursors.WaitCursor;
                Program.manager.RemoveMod(modList.SelectedItems[0].Index);
                modList.Items.Remove(modList.SelectedItems[0]);

                if (modList.Items.Count > 0)
                    modList.Items[0].Selected = true;
                else
                {
                    modNameText.Text = "";
                    toolTip1.SetToolTip(modNameText, "No mod selected.");
                    modDescriptionText.Text = "";
                    modAuthorText.Text = "";
                    toolTip1.SetToolTip(modAuthorText, "No mod selected.");
                    modVersionLabel.Text = "";
                    toolTip1.SetToolTip(modVersionLabel, "No mod selected.");
                }
                UpdateStatusLabel();
                RecalcRanks();
                Program.manager.ApplyChanges(this);
                Cursor.Current = Cursors.Default;
            }
        }

        private void exitPicButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toggleModButton_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            if (modList.SelectedItems.Count == 1)
            {
                var mod = Program.manager.GetMod(modList.SelectedItems[0].Index);
                if(mod.state == ModState.ACTIVE)
                {
                    toggleModButton.Image = Properties.Resources.add;
                    mod.state = ModState.INACTIVE;
                    modList.SelectedItems[0].BackColor = Color.White;
                    modList.SelectedItems[0].SubItems[2].Text = "";
                    applyChangesButton.Enabled = Program.manager.hasChanges = true;
                }
                else if(mod.state == ModState.INACTIVE)
                {
                    toggleModButton.Image = Properties.Resources.disable;
                    mod.state = ModState.ACTIVE;
                    modList.SelectedItems[0].BackColor = Color.LightGreen;
                    modList.SelectedItems[0].SubItems[2].Text = "✓";
                    applyChangesButton.Enabled = Program.manager.hasChanges = true;
                }
            }
            Cursor.Current = Cursors.Default;
        }

        private void applyChangesButton_Click(object sender, EventArgs e)
        {
            var mods = Program.manager.GetYellowMods();
            if (mods.Count > 0)
            {
                string s = "";
                foreach (var m in mods)
                    s += $"\n{m.modName}";
                if (MessageBox.Show("Some active mods will not install all their files due to being overwritten. Proceed?" + s, "Warning", MessageBoxButtons.YesNo) != DialogResult.Yes)
                    return;
            }

            if(MessageBox.Show("This will extract backups and inject your mods. It might take a while. Proceed?", "Are you sure?", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Program.manager.ApplyChanges(this);
                if (Program.settings.openLog)
                {
                    var form = new LogForm(Program.injectionLog);
                    form.Owner = this;
                    form.ShowDialog();
                }
                applyChangesButton.Enabled = Program.manager.hasChanges;
                UpdateStatusLabel();
            }
        }

        private void settingsButton_Click(object sender, EventArgs e)
        {
            var form = new SettingsForm();
            form.Owner = this;
            form.ShowDialog();
        }

        public void Log(string message)
        {
            logLabel.Text = message;
            Program.Log(message);
        }

        private void Lab_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(Program.manager != null && Program.manager.hasChanges)
            {
                if(MessageBox.Show("You have unsaved changes. Do you wish to apply the current active mods?", "Save", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    Program.manager.ApplyChanges(this);
                    Program.manager.AcknowledgeMods();
                }
                else
                {
                    Program.manager.AcknowledgeMods(true);
                }
            }
        }

        private void logLabel_Click(object sender, EventArgs e)
        {
            button1_Click(sender, e);
        }

        //open log
        private void button1_Click(object sender, EventArgs e)
        {
            var form = new LogForm(Program.consoleLog);
            form.Owner = this;
            form.ShowDialog();
        }

        private void listFilesButton_Click(object sender, EventArgs e)
        {
            if (modList.SelectedItems.Count == 1)
            {
                var selectedMod = modList.SelectedItems[0].Tag as Mod;
                if (selectedMod.state == ModState.ACTIVE)
                {
                    var scaffold = Program.manager.GetScaffold();
                    var form = new FileListForm(selectedMod, scaffold)
                    {
                        Owner = this
                    }.ShowDialog();
                }
                else if (selectedMod.state == ModState.INACTIVE)
                {
                    var form = new FileListForm(selectedMod)
                    {
                        Owner = this
                    }.ShowDialog();
                }
            }

        }

        private void aboutBtn_Click(object sender, EventArgs e)
        {
            var form = new AboutForm();
            form.Owner = this;
            form.ShowDialog();
        }
    }
}
