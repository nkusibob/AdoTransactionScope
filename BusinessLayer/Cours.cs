using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BusinessLayer
{
    public static class Cours
    {
        public static void LoadAllMatricule(ref DataSet oDataSet)
        {
            DataSet oData;

            try
            {
                oData = DataAccessLayer.Cours.LoadAllCours();

                oDataSet = oData;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static void SelectByMatricule(ref DataSet oDataSet)
        {
            DataSet oData;

            try
            {
                oData = DataAccessLayer.Etudiants.SelectByMatricule();

                oDataSet = oData;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public static void LoadAllMatricule(ref DataTable oDataTable)
        {
            DataSet oDataBis = new DataSet();

            LoadAllMatricule(ref oDataBis);

            oDataTable = oDataBis.Tables[0];
        }

        public static void LoadAllMatricule(ref DataView oDataView)
        {
            DataTable oDataBis = new DataTable();

            LoadAllMatricule(ref oDataBis);

            oDataView = oDataBis.DefaultView;
        }
        public static void LoadAllCours(ref List<BusinessEntity.Cours> Cours)
        {
            DataView oDataView = new DataView();

            LoadAllMatricule(ref oDataView);

            foreach (DataRowView oRow in oDataView)
            {
                BusinessEntity.Cours ocours = new BusinessEntity.Cours();

                ocours.IdCours = oRow["IdCours"].ToString();
                ocours.code = oRow["code"].ToString();
                ocours.libellé = oRow["libellé"].ToString();


                //if (ocours.IdCours.Length < 5)
                //    throw new BusinessError.CustomError(7);



                Cours.Add(ocours);

            }

        }
    }
}
