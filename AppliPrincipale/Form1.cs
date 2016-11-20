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


                DataSet
                    oData = new DataSet();

                BusinessLayer.Etudiants.LoadAllMatricule(ref oData);
                string search = "ETU_MATRICULE like '%" + txtMatricule.Text + "%'";
                var dt = oData.Tables[0].DefaultView;
                var dt2= oData.Tables[0].DefaultView;
                var dt3= oData.Tables[0].DefaultView;
                dt.RowFilter = search;
               

                if (dt.Count==0)
                {

                     dt2= oData.Tables[0].DefaultView;
                    search = "ETU_NOM like '%" + txtMatricule.Text + "%'";
                    dt2= oData.Tables[0].DefaultView;
                   dt2.RowFilter = search;

                }
              if(dt2.Count == 0)
                {

                    search = "ETU_PRENOM like '%" + txtMatricule.Text + "%'";
                    dt3 = oData.Tables[0].DefaultView;
                    dt3.RowFilter = search;

                }



                gridData.DataSource = dt;
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

        private void button1_Click(object sender, EventArgs e)
        {
            DataView oView = (DataView)gridData.DataSource;

            BusinessLayer.Etudiants.SaveAllTrans(oView);

        }

        private void btnSaveTimeStamp_Click(object sender, EventArgs e)
        {
            DataView oView = (DataView)gridData.DataSource;

            BusinessLayer.Etudiants.SaveAllTImeStamp(oView);
        }
    }
}
