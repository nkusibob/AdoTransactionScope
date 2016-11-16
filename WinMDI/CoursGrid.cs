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

        private void btn_searchCours_Click(object sender, EventArgs e)
        {
            try
            {

                if (SearchCours.Text.Length < 3)
                    throw new BusinessError.CustomError(4);


                DataSet
                    oData = new DataSet();

                BusinessLayer.Cours.LoadAllMatricule(ref oData);
                string search = "code like '%" + SearchCours.Text + "%'";
                var dt = oData.Tables[0].DefaultView;
                var dt2 = oData.Tables[0].DefaultView;
                var dt3 = oData.Tables[0].DefaultView;
                dt.RowFilter = search;


                if (dt.Count == 0)
                {

                    dt2 = oData.Tables[0].DefaultView;
                    search = "libellé like '%" + SearchCours.Text + "%'";
                    dt2 = oData.Tables[0].DefaultView;
                    dt2.RowFilter = search;

                }
                if (dt2.Count == 0)
                {

                    search = "IdCours like '%" + SearchCours.Text + "%'";
                    dt3 = oData.Tables[0].DefaultView;
                    dt3.RowFilter = search;

                }



                CoursGrid.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
