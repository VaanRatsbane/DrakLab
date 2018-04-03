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
            if (!(Directory.Exists("ff12-vbf") && File.Exists("ff12-vbf\\ff12-phyre.exe") && File.Exists("ff12-vbf\\ff12-vbf.exe") &&
                File.Exists("ff12-vbf\\libgcc_s_seh-1.dll") && File.Exists("ff12-vbf\\libstdc++-6.dll") &&
                File.Exists("ff12-vbf\\libwinpthread-1.dll") && File.Exists("ff12-vbf\\zlib1.dll")))
            {
                MessageBox.Show("ffgriever's tools are missing. Exiting...");
                Environment.Exit(1);
            }
        }

        private void loadVBFPicButton_Click(object sender, EventArgs e)
        {
            if (openVBFDialog.ShowDialog() == DialogResult.OK)
            {
                LoadVBF(openVBFDialog.FileName);
            }
        }

        private void LoadVBF(string filePath)
        {
            if (Program.LoadVBF(filePath))
            {

            }
            else
            {

            }
        }
    }
}
