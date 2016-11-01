using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows.Forms;

namespace BusinessLayer
{
    public static class Etudiants
    {

        public static void SaveALL(DataView poViewData)
        {
            using (TransactionScope ts = DataAccessLayer.clsDatabase.CreateSeriazable())
            {
               
                try
                {
                    //On récupère les rows deleted

                    poViewData.RowStateFilter = DataViewRowState.Deleted;

                    foreach (DataRowView oRow in poViewData)
                    {
                        Console.WriteLine(oRow["ETU_ID"].ToString());
                        int ID = Convert.ToInt32(oRow["ETU_ID"].ToString());
                        DataAccessLayer.Etudiants.DeleteFromID(ID);
                    }

                    poViewData.RowStateFilter = DataViewRowState.ModifiedCurrent;

                    //Data.Etudiant odataEtu = new Data.Etudiant();

                    foreach (DataRowView oRow in poViewData)

                    {
                        MessageBox.Show(oRow["ETU_ID"].ToString());
                        int ID = Convert.ToInt32(oRow["ETU_ID"].ToString());
                        string Matricule = oRow["ETU_MATRICULE"].ToString();

                        if (Matricule.Length < 5)
                            throw new BusinessError.CustomError(3);

                        DataAccessLayer.Etudiants.UpdateMatricule(Matricule, ID);
                    }

                    poViewData.RowStateFilter = DataViewRowState.Added;
                    foreach (DataRowView oRow in poViewData)
                    {
                        int ID = Convert.ToInt32(oRow["ETU_ID"].ToString());
                        string matricule = oRow["ETU_MATRICULE"].ToString();
                        string nom = oRow["ETU_nom"].ToString();
                        string prenom = oRow["ETU_prenom"].ToString();
                        if (matricule.Length < 5)
                            throw new BusinessError.CustomError(3);
                        DataAccessLayer.Etudiants.InsertETU(matricule, nom, prenom);

                    }
                    ts.Complete();

                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }


            }

        }




        public static void FindMatricule(ref List<BusinessEntity.Etudiant> pEtudiants, string pSearch)
        {
            if (pSearch.Length < 3)
                throw new BusinessError.CustomError(4);


        }


        public static void LoadAllMatricule(ref DataSet oDataSet)
        {
            DataSet oData;

            try
            {
                oData = DataAccessLayer.Etudiants.LoadAllMatricule();

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

        public static void LoadAllMatricule(ref List<BusinessEntity.Etudiant> pEtudiants)
        {
            DataView oDataView = new DataView();

            LoadAllMatricule(ref oDataView);

            foreach (DataRowView oRow in oDataView)
            {
                BusinessEntity.Etudiant oEtudiant = new BusinessEntity.Etudiant();

                oEtudiant.ID = Convert.ToInt32(oRow["ETU_ID"]);
                oEtudiant.Matricule = oRow["ETU_MATRICULE"].ToString();


                if (oEtudiant.Matricule.Length < 5)
                    throw new BusinessError.CustomError(3);

                oEtudiant.DisplayName = oEtudiant.ID + " - " + oEtudiant.Matricule.ToUpper();

                pEtudiants.Add(oEtudiant);

            }

        }
    }
}
