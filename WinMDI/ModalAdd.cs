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
    public partial class ModalAdd : Form
    {
        public ModalAdd()
        {
            InitializeComponent();
            loadStudents();
        }
        public void loadStudents()
        {
            DataSet oData = new DataSet();

            BusinessLayer.Etudiants.LoadAllMatricule(ref oData);

            dataGridViewModal.DataSource = oData.Tables[0].DefaultView;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataView oView = (DataView)dataGridViewModal.DataSource;

            BusinessLayer.Etudiants.SaveAllTransMDI(oView);
            loadStudents();
        }
    }
}
