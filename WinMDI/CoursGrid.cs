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
    public partial class CoursWinForm : Form
    {

        public CoursWinForm()
        {
            InitializeComponent();
            loadCours();

        }
        public void loadCours()
        {

            DataView oData = new DataView();

            BusinessLayer.Cours.LoadAllMatricule(ref oData);

            CoursGrid.DataSource = oData;
        }

        private void SaveCours_Click(object sender, EventArgs e)
        {
           

            DataView oView = (DataView)CoursGrid.DataSource;

            BusinessLayer.Cours.SaveAllTrans(oView);
        }
    }
}
