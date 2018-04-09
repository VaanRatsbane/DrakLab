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
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();
            showReport.Checked = Program.settings.openLog;
            useCustomTemp.Checked = alterTemp.Enabled = Program.settings.useCustomTemp;
            if (useCustomTemp.Checked)
                folderPath.Text = Program.settings.tempPath;
            enableLogging.Checked = Program.settings.saveLog;
        }

        private void showReport_CheckedChanged(object sender, EventArgs e)
        {
            Program.settings.openLog = showReport.Checked;
        }

        private void useCustomTemp_CheckedChanged(object sender, EventArgs e)
        {
            if (useCustomTemp.Checked)
            {
                if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                {
                    folderPath.Text = Program.settings.tempPath = folderBrowserDialog1.SelectedPath;
                }
                else
                {
                    useCustomTemp.Checked = false;
                    folderPath.Text = "";
                }
            }
            Program.settings.useCustomTemp = alterTemp.Enabled = useCustomTemp.Checked;
        }

        private void alterTemp_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                folderPath.Text = Program.settings.tempPath = folderBrowserDialog1.SelectedPath;
            }
        }

        private void enableLogging_CheckedChanged(object sender, EventArgs e)
        {
            Program.settings.saveLog = enableLogging.Checked;
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
