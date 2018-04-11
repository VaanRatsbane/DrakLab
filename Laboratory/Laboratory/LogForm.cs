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
    public partial class LogForm : Form
    {
        public LogForm(IEnumerable<string> log)
        {
            InitializeComponent();
            if(log != null && log.Count() > 0)
                textBox1.Lines = log.ToArray();
        }
    }
}
