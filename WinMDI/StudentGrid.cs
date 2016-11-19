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
    public partial class StudentGrid : Form
    {
        public StudentGrid()
        {
            InitializeComponent();
            loadStudents();
            this.KeyPreview = true;
            this.KeyDown += new KeyEventHandler(Window_KeyDown);

        }

        public void loadStudents()
        {
            
            List<BusinessEntity.studentsMDI> ListEtudiants = new List<BusinessEntity.studentsMDI>();
            
            try
            {
                BusinessLayer.Etudiants.LoadAllMatriculeMDI(ref ListEtudiants);

                GridStudentMDI.DataSource =new BindingList<BusinessEntity.studentsMDI>(ListEtudiants);
                GridStudentMDI.Columns[0].Visible = false;
            }
            catch (BusinessError.CustomError ex)
            {
                MessageBox.Show(ex.ID + "   " + ex.Message);
            }
        }
    

       
        public void Window_KeyDown(object sender, KeyEventArgs e)
        {
          
            
            if (e.KeyCode == Keys.Delete)
            {

                foreach (DataGridViewRow row in this.GridStudentMDI.SelectedRows)
                {

                    int id = Convert.ToInt32( row.Cells[0].Value.ToString()); ;
                    BusinessLayer.Etudiants.DeleteToDB(id);
                }
                MessageBox.Show("l'etudiant a été supprimé");
              
                
                e.Handled = true;
                loadStudents();
            }
        }
        private void  loidDatasetStudents()
        {
            ModalAdd oform = new ModalAdd();
            oform.ShowDialog();
        }
        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loidDatasetStudents();
        }

        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loidDatasetStudents();
        }

        private void btnNomSearch_Click(object sender, EventArgs e)
        {
            try
            {

                if (txtBoxNomSearch.Text.Length < 3)
                    throw new BusinessError.CustomError(4);


                DataSet
                    oData = new DataSet();

                BusinessLayer.Etudiants.LoadAllMatricule(ref oData);
                string search = "ETU_MATRICULE like '%" + txtBoxNomSearch.Text + "%'";
                var dt = oData.Tables[0].DefaultView;
                var dt2 = oData.Tables[0].DefaultView;
                var dt3 = oData.Tables[0].DefaultView;
                dt.RowFilter = search;


                if (dt.Count == 0)
                {

                    dt2 = oData.Tables[0].DefaultView;
                    search = "ETU_NOM like '%" + txtBoxNomSearch.Text + "%'";
                    dt2 = oData.Tables[0].DefaultView;
                    dt2.RowFilter = search;

                }
                if (dt2.Count == 0)
                {

                    search = "ETU_PRENOM like '%" + txtBoxNomSearch.Text + "%'";
                    dt3 = oData.Tables[0].DefaultView;
                    dt3.RowFilter = search;

                }



                GridStudentMDI.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
