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

        
    }
}
