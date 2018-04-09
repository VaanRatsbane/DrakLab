using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laboratory
{
    public partial class FileListForm : Form
    {
        public FileListForm(Mod mod, ModFile[] scaffold)
        {
            InitializeComponent();
            var inScaffold = new List<ModFile>();
            var notInScaffold = new List<ModFile>();
            foreach (var file in mod.files)
            {
                if (scaffold.Contains(file))
                    inScaffold.Add(file);
                else
                    notInScaffold.Add(file);
            }
            foreach (var file in inScaffold)
                listView1.Items.Add(new ListViewItem(file.virtualPath)
                {
                    BackColor = Color.LightGreen
                });

            foreach (var file in notInScaffold)
                listView1.Items.Add(new ListViewItem(file.virtualPath)
                {
                    BackColor = Color.Orange
                });

            scaffoldLabel.Text = $"{inScaffold.Count} active file(s)";
            scaffoldLabel.BackColor = Color.LightGreen;

            notScaffoldLabel.Text = $"{notInScaffold.Count} overwritten file(s)";
            notScaffoldLabel.BackColor = Color.Orange;

        }

        public FileListForm(Mod mod)
        {
            InitializeComponent();
            foreach (var file in mod.files)
            {
                listView1.Items.Add(new ListViewItem(file.virtualPath));
            }

            scaffoldLabel.Text = $"{mod.files.Count} files";
            scaffoldLabel.BackColor = Color.White;

            notScaffoldLabel.Text = $"";
            notScaffoldLabel.BackColor = Color.White;

        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
