using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinMDI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void coursToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CoursWinForm oForm = new CoursWinForm();

            
            oForm.MdiParent = this;
            oForm.Show();
        }

        private void SaveALLMDI_Click(object sender, EventArgs e)
        {

        }
    }
}
