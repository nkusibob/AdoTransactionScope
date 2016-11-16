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
            List<BusinessEntity.Cours> ListCours = new List<BusinessEntity.Cours>();

            try
            {
                BusinessLayer.Cours.LoadAllCours(ref ListCours);

                CoursGrid.DataSource = ListCours;
              
            }
            catch (BusinessError.CustomError ex)
            {
                MessageBox.Show(ex.ID + "   " + ex.Message);
            }
        }
    }
}
