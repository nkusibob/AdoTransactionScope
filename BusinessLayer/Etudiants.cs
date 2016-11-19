using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows.Forms;
using BusinessEntity;

namespace BusinessLayer
{
    public static class Etudiants
    {

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
                        string cours = oRow["cours"].ToString();
                        if (matricule.Length < 5)
                            throw new BusinessError.CustomError(3);
                        DataAccessLayer.Etudiants.InsertETU(matricule, nom, prenom,cours);

                    }
                    ts.Complete();

                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }


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
                    List<int> ToDel = new List<int>();
                    foreach (DataRowView oRow in poViewData)
                    {
                        Console.WriteLine(oRow["ETU_ID"].ToString());
                        int ID = Convert.ToInt32(oRow["ETU_ID"].ToString());
                        string MATRICULE = oRow["ETU_MATRICULE"].ToString();
                        ToDel.Add(ID);
                        //DataAccessLayer.Etudiants.DeleteFromID(ID);
                       
                    }

                    poViewData.RowStateFilter = DataViewRowState.ModifiedCurrent;

                    //Data.Etudiant odataEtu = new Data.Etudiant();
                    List<BusinessEntity.Etudiant> listEtu = new List<BusinessEntity.Etudiant>();
                    foreach (DataRowView oRow in poViewData)

                    {
                        MessageBox.Show(oRow["ETU_ID"].ToString());
                        int ID = Convert.ToInt32(oRow["ETU_ID"].ToString());
                        string Matricule = oRow["ETU_MATRICULE"].ToString();
                       

                        if (Matricule.Length < 5)
                            throw new BusinessError.CustomError(3);
                        BusinessEntity.Etudiant oEtu = new BusinessEntity.Etudiant();
                        oEtu.Matricule = Matricule;
                        oEtu.ID = ID;
                        listEtu.Add(oEtu);


                    }
               

                poViewData.RowStateFilter = DataViewRowState.Added;
                List<BusinessEntity.Etudiant> listToAdd= new List<BusinessEntity.Etudiant>();
                foreach (DataRowView oRow in poViewData)
                    {
                        int ID = Convert.ToInt32(oRow["ETU_ID"].ToString());
                        string matricule = oRow["ETU_MATRICULE"].ToString();
                        string nom = oRow["ETU_nom"].ToString();
                        string prenom = oRow["ETU_prenom"].ToString();
                        string cours = oRow["cours"].ToString();
                    if (matricule.Length < 5)
                            throw new BusinessError.CustomError(3);
                        BusinessEntity.Etudiant oEtu = new BusinessEntity.Etudiant();
                        oEtu.Matricule = matricule;
                        oEtu.ID = ID;
                        oEtu.DisplayName = nom + prenom;
                        listToAdd.Add(oEtu);
                       // DataAccessLayer.Etudiants.InsertETU(matricule, nom, prenom);

                    }

                DataAccessLayer.Etudiants.SaveAll(ToDel, listEtu, listToAdd);
            }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }


            }
        public static void SaveAllTransMDI(DataView poViewData)
        {
            //default isolation level for transaction scope is already seriazable
            //if yu delete a row and try to update it within another form
            //it throws a business error explaining the row has been already deleted it doesn't exist anymore
            //i gave the choice in DATALAYER in DataBase.CS to configure isolation level


            try
            {
                ////On récupère les rows deleted

                //poViewData.RowStateFilter = DataViewRowState.Deleted;
                //List<int> ToDel = new List<int>();
                //foreach (DataRowView oRow in poViewData)
                //{
                //    Console.WriteLine(oRow["ETU_ID"].ToString());
                //    int ID = Convert.ToInt32(oRow["ETU_ID"].ToString());
                //    string MATRICULE = oRow["ETU_MATRICULE"].ToString();
                //    ToDel.Add(ID);
                //    //DataAccessLayer.Etudiants.DeleteFromID(ID);

                //}

                poViewData.RowStateFilter = DataViewRowState.ModifiedCurrent;

                //Data.Etudiant odataEtu = new Data.Etudiant();
                List<BusinessEntity.Etudiant> listEtu = new List<BusinessEntity.Etudiant>();
                foreach (DataRowView oRow in poViewData)

                {
                    MessageBox.Show(oRow["ETU_ID"].ToString());
                    int ID = Convert.ToInt32(oRow["ETU_ID"].ToString());
                    string Matricule = oRow["ETU_MATRICULE"].ToString();


                    if (Matricule.Length < 5)
                        throw new BusinessError.CustomError(3);
                    BusinessEntity.Etudiant oEtu = new BusinessEntity.Etudiant();
                    oEtu.Matricule = Matricule;
                    oEtu.ID = ID;
                    listEtu.Add(oEtu);


                }


                poViewData.RowStateFilter = DataViewRowState.Added;
                List<BusinessEntity.studentTest> listToAdd = new List<BusinessEntity.studentTest>();
                foreach (DataRowView oRow in poViewData)
                {
                    int ID = Convert.ToInt32(oRow["ETU_ID"].ToString());
                    string matricule = oRow["ETU_MATRICULE"].ToString();
                    string nom = oRow["ETU_nom"].ToString();
                    string prenom = oRow["ETU_prenom"].ToString();
                    string cours = oRow["cours"].ToString();
                    if (matricule.Length < 5)
                        throw new BusinessError.CustomError(3);

                    BusinessEntity.studentTest oEtu = new BusinessEntity.studentTest();
                    oEtu.Matricule = matricule;
                    oEtu.ID = ID;
                    oEtu.nom = nom;
                    oEtu.prenom = prenom;
                    oEtu.cours = cours;
                    listToAdd.Add(oEtu);
                   //DataAccessLayer.Etudiants.InsertETU(matricule, nom, prenom,cours);

                }

                DataAccessLayer.Etudiants.SaveAllMDI( listEtu, listToAdd);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }


        }
        public static void DeleteToDB(int id)
        {


            try
            {
                //On récupère les rows deleted

              
                    DataAccessLayer.Etudiants.DeleteFromID(id);

                
            }


            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }


        }




        public static void  FindMatricule( string pSearch)
        {
            DataSet oData;
            if (pSearch.Length < 3)
                throw new BusinessError.CustomError(4);
           oData=DataAccessLayer.Etudiants.SelectByMatricule(pSearch);
           

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

        public static void LoadAllMatricule(ref List<BusinessEntity.Etudiant> pEtudiants)
        {
            DataView oDataView = new DataView();

            LoadAllMatricule(ref oDataView);

            foreach (DataRowView oRow in oDataView)
            {
                BusinessEntity.Etudiant oEtudiant = new BusinessEntity.Etudiant();

                oEtudiant.ID = Convert.ToInt32(oRow["ETU_ID"]);
                oEtudiant.Matricule = oRow["ETU_MATRICULE"].ToString();
                oEtudiant.cours = oRow["cours"].ToString();


                if (oEtudiant.Matricule.Length < 5)
                    throw new BusinessError.CustomError(3);

                oEtudiant.DisplayName = oEtudiant.ID + " - " + oEtudiant.Matricule.ToUpper();

                pEtudiants.Add(oEtudiant);

            }

        }

        public static void LoadAllMatriculeMDI(ref List<studentsMDI> listEtudiants)
        {
            DataView oDataView = new DataView();

            LoadAllMatricule(ref oDataView);

            foreach (DataRowView oRow in oDataView)
            {
                BusinessEntity.studentsMDI oEtudiant = new BusinessEntity.studentsMDI();

                oEtudiant.ID = Convert.ToInt32(oRow["ETU_ID"]);
                oEtudiant.Matricule = oRow["ETU_MATRICULE"].ToString();
                oEtudiant.cours = oRow["cours"].ToString();


                if (oEtudiant.Matricule.Length < 5)
                    throw new BusinessError.CustomError(3);

                oEtudiant.libellé = oEtudiant.ID + " - " + oEtudiant.Matricule.ToUpper();

                listEtudiants.Add(oEtudiant);

            }
        }



    }
}
