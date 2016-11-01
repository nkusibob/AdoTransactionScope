using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppliPrincipale
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btLoadDataSet_Click(object sender, EventArgs e)
        {
            DataSet oData =  new DataSet();

            BusinessLayer.Etudiants.LoadAllMatricule( ref oData);

            gridData.DataSource = oData.Tables[0].DefaultView;
        }

        private void btDataTable_Click(object sender, EventArgs e)
        {
            DataTable oData = new DataTable();

            BusinessLayer.Etudiants.LoadAllMatricule(ref oData);

            gridData.DataSource = oData.DefaultView;
        }

        private void btDataView_Click(object sender, EventArgs e)
        {
            DataView oData = new DataView();

            BusinessLayer.Etudiants.LoadAllMatricule(ref oData);

            gridData.DataSource = oData;
        }

        private void btList_Click(object sender, EventArgs e)
        {
            List<BusinessEntity.Etudiant> ListEtudiants = new List<BusinessEntity.Etudiant>();

            try
            {
                BusinessLayer.Etudiants.LoadAllMatricule(ref ListEtudiants);

                gridData.DataSource = ListEtudiants;
            }
            catch ( BusinessError.CustomError ex)
            {
                MessageBox.Show(ex.ID + "   " + ex.Message);
            }
        }

        private void btSearch_Click(object sender, EventArgs e)
        {
            try
            {

                if (txtMatricule.Text.Length < 3)
                    throw new BusinessError.CustomError(4);
                List<BusinessEntity.Etudiant> ListEtudiants = new List<BusinessEntity.Etudiant>();
                BusinessLayer.Etudiants.LoadAllMatricule(ref ListEtudiants);

                
                BusinessLayer.Etudiants.FindMatricule(ref ListEtudiants, txtMatricule.Text);
            }
            catch( Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btSaveAll_Click(object sender, EventArgs e)
        {
            DataView oView = (DataView) gridData.DataSource;
           
            BusinessLayer.Etudiants.SaveALL(oView);
        }

     
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.Show();
        }
    }
}
