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
                oData = DataAccessLayer.Cours.LoadAllCours();

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
                ocours.last_modified = Convert.ToDateTime( oRow["libellé"].ToString());

                //if (ocours.IdCours.Length < 5)
                //    throw new BusinessError.CustomError(7);



                Cours.Add(ocours);

            }

        }
        public static void SaveAllTrans(DataView poViewData)
        {
            //default isolation level for transaction scope is already seriazable
            //if yu delete a row and try to update it within another form
            //it throws a business error explaining the row has been already deleted it doesn't exist anymore
            //i gave the choice in DATALAYER in DataBase.CS to configure isolation level


            try
            {
                //On récupère les rows deleted

                poViewData.RowStateFilter = DataViewRowState.Deleted;
                List<string> ToDel = new List<string>();
                foreach (DataRowView oRow in poViewData)
                {
                    Console.WriteLine(oRow["code"].ToString());
                    string libellé = (oRow["libellé"].ToString());
                    string code = oRow["code"].ToString();
                    ToDel.Add(code);
                    //DataAccessLayer.Etudiants.DeleteFromID(ID);

                }

                poViewData.RowStateFilter = DataViewRowState.ModifiedCurrent;

                //Data.Etudiant odataEtu = new Data.Etudiant();
                List<BusinessEntity.Cours> listCours = new List<BusinessEntity.Cours>();
                foreach (DataRowView oRow in poViewData)

                {
                    string idCours = oRow["idCours"].ToString();
                    string libellé = (oRow["libellé"].ToString());
                    string code = oRow["code"].ToString();


                    //if (Matricule.Length < 5)
                    //    throw new BusinessError.CustomError(3);
                    BusinessEntity.Cours oCours = new BusinessEntity.Cours();
                    oCours.IdCours = idCours;
                    oCours.code = code;
                    oCours.libellé = libellé;
                    listCours.Add(oCours);


                }


                poViewData.RowStateFilter = DataViewRowState.Added;
                List<BusinessEntity.Cours> listToAdd = new List<BusinessEntity.Cours>();
                foreach (DataRowView oRow in poViewData)
                {
                    string idCours = oRow["idCours"].ToString();
                    string libellé = (oRow["libellé"].ToString());
                    string code = oRow["code"].ToString();

                    //if (matricule.Length < 5)
                    //    throw new BusinessError.CustomError(3);
                    BusinessEntity.Cours oCours = new BusinessEntity.Cours();
                    oCours.IdCours = idCours;
                    oCours.code = code;
                    oCours.libellé = libellé;
                    //oEtu.DisplayName = nom + prenom;
                    listToAdd.Add(oCours);
                    // DataAccessLayer.Etudiants.InsertETU(matricule, nom, prenom);

                }

                DataAccessLayer.Cours.SaveAll(ToDel, listCours, listToAdd);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }


        }

        public static void SaveAllTransTimeStamp(DataView poViewData)
        {
            try
            {
                //On récupère les rows deleted

                poViewData.RowStateFilter = DataViewRowState.Deleted;
                List<string> ToDel = new List<string>();
                foreach (DataRowView oRow in poViewData)
                {
                    Console.WriteLine(oRow["code"].ToString());
                    string libellé = (oRow["libellé"].ToString());
                    string code = oRow["code"].ToString();
                    DateTime dt = Convert.ToDateTime(oRow["last_modidfied"].ToString());
                    ToDel.Add(code);
                    //DataAccessLayer.Etudiants.DeleteFromID(ID);

                }

                poViewData.RowStateFilter = DataViewRowState.ModifiedCurrent;

                //Data.Etudiant odataEtu = new Data.Etudiant();
                List<BusinessEntity.Cours> listCours = new List<BusinessEntity.Cours>();
                foreach (DataRowView oRow in poViewData)

                {
                    string idCours = oRow["idCours"].ToString();
                    string libellé = (oRow["libellé"].ToString());
                    string code = oRow["code"].ToString();
                    DateTime dt = Convert.ToDateTime(oRow["last_modidfied"].ToString());

                    //if (Matricule.Length < 5)
                    //    throw new BusinessError.CustomError(3);
                    BusinessEntity.Cours oCours = new BusinessEntity.Cours();
                    oCours.IdCours = idCours;
                    oCours.code = code;
                    oCours.libellé = libellé;
                    oCours.last_modified = dt;
                    listCours.Add(oCours);


                }


                poViewData.RowStateFilter = DataViewRowState.Added;
                List<BusinessEntity.Cours> listToAdd = new List<BusinessEntity.Cours>();
                foreach (DataRowView oRow in poViewData)
                {
                    string idCours = oRow["idCours"].ToString();
                    string libellé = (oRow["libellé"].ToString());
                    string code = oRow["code"].ToString();
                    DateTime dt = Convert.ToDateTime(oRow["last_modified"].ToString());
                    //if (matricule.Length < 5)
                    //    throw new BusinessError.CustomError(3);
                    BusinessEntity.Cours oCours = new BusinessEntity.Cours();
                    oCours.IdCours = idCours;
                    oCours.code = code;
                    oCours.libellé = libellé;
                    oCours.last_modified = dt;
                    //oEtu.DisplayName = nom + prenom;
                    listToAdd.Add(oCours);
                    // DataAccessLayer.Etudiants.InsertETU(matricule, nom, prenom);

                }

                DataAccessLayer.Cours.SaveAllTimeStamp(ToDel, listCours, listToAdd);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

        }

        public static void SaveALL(DataView poViewData)
        {
            //default isolation level for transaction scope is already seraizable
            //if yu delete a row and try to update it within another form
            //it throws a business error explaining the row has been already deleted it doesn't exist anymore
            //i gave the choice in DATALAYER in DataBase.CS to configure isolation level
            using (TransactionScope ts = DataAccessLayer.clsDatabase.CreateReadUncommitted())
            {

                try
                {
                    //On récupère les rows deleted

                    poViewData.RowStateFilter = DataViewRowState.Deleted;

                    foreach (DataRowView oRow in poViewData)
                    {
                        string libellé = (oRow["libellé"].ToString());
                        string code = oRow["code"].ToString();
                        DataAccessLayer.Cours.DeleteCode(code);
                    }

                    poViewData.RowStateFilter = DataViewRowState.ModifiedCurrent;

                    //Data.Etudiant odataEtu = new Data.Etudiant();

                    foreach (DataRowView oRow in poViewData)

                    {
                        MessageBox.Show(oRow["ETU_ID"].ToString());
                        
                        string code = oRow["code"].ToString();

                        //if (Matricule.Length < 5)
                        //    throw new BusinessError.CustomError(3);

                        DataAccessLayer.Cours.UpdateCode(code);
                    }

                    poViewData.RowStateFilter = DataViewRowState.Added;
                    foreach (DataRowView oRow in poViewData)
                    {
                        string idCours = oRow["idCours"].ToString();
                        string libellé = (oRow["libellé"].ToString());
                        string code = oRow["code"].ToString();
                        //if (matricule.Length < 5)
                        //    throw new BusinessError.CustomError(3);
                        DataAccessLayer.Cours.InsertCours(idCours, code, libellé);

                    }
                    ts.Complete();

                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }


            }

        }
    }
}
