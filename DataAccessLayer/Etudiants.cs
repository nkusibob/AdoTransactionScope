using System;
using System.Collections.Generic;
using System.Data;

using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using BusinessEntity;

namespace DataAccessLayer
{



    public static class Etudiants
    {
        public static void SaveAll(List<int> lstToDelete, List<BusinessEntity.Etudiant> ListToUpdate, List<BusinessEntity.Etudiant> ListToInsert)
        {
            SqlCommand oUpd
               = null;
            SqlCommand oDel
              = null;
            
            SqlCommand oIns
              = null;
            SqlTransaction oTrans=null;

            try
            {
                //delete
                 clsDatabase.oDataBase.Open();
                 oTrans = clsDatabase.oDataBase.BeginTransaction();

                foreach (var ID in lstToDelete)
                {
                   
                    oDel = new SqlCommand();
                    oDel.Connection = clsDatabase.oDataBase;
                    oDel.Transaction = oTrans;
                    oDel.CommandType = CommandType.StoredProcedure;
                    oDel.CommandText = "EtuDeleteById";
                    SqlParameter oParamID = new SqlParameter("@id", ID);



                    oDel.Parameters.Add(oParamID);

                    int RowsDeleted = oDel.ExecuteNonQuery();

                    if (RowsDeleted == 0)
                        throw new BusinessError.CustomError(5);

                   
                }
                //uodate

                foreach (var etu in ListToUpdate)
                {
                    oUpd = new SqlCommand();
                    oUpd.Connection = clsDatabase.oDataBase;
                    oUpd.Transaction = oTrans;
                    oUpd.CommandType = CommandType.StoredProcedure;
                    oUpd.CommandText = "UpdateByID";
                    SqlParameter oParamMatricule = new SqlParameter("@Matricule", etu.Matricule);
                    SqlParameter oParamID = new SqlParameter("@ID", etu.ID);


                    oUpd.Parameters.Add(oParamMatricule);
                    oUpd.Parameters.Add(oParamID);

                    int RowsModified = oUpd.ExecuteNonQuery();

                    if (RowsModified == 0)
                    {
                        //tout erreur logique il faut aussi faire le commit
                        oTrans.Commit();
                        throw new BusinessError.CustomError(5);
                    }
                    

                }

                //insert
                foreach (var etu in ListToInsert)
                {
                    oIns = new SqlCommand();
                    oIns.Connection = clsDatabase.oDataBase;
                    oIns.Transaction = oTrans;
                    oIns.CommandType = CommandType.StoredProcedure;
                    oIns.CommandText = "Etu_Create";
                    SqlParameter oParamMatricule = new SqlParameter("@matricule", etu.Matricule);
                    SqlParameter oParamNom = new SqlParameter("@nom", etu.DisplayName);
                    SqlParameter oParamPrenom = new SqlParameter("@prenom", etu.DisplayName);
                    SqlParameter oParamCours = new SqlParameter("@cours", etu.cours);



                    oIns.Parameters.Add(oParamMatricule);
                    oIns.Parameters.Add(oParamNom);
                    oIns.Parameters.Add(oParamPrenom);
                    oIns.Parameters.Add(oParamCours);

                    int RowsModified =  oIns.ExecuteNonQuery();

                    if (RowsModified == 0)
                    {
                        //tout erreur logique il faut aussi faire le commit
                        oTrans.Commit();
                        throw new BusinessError.CustomError(5);
                    }

                }
                oTrans.Commit();

            }

            catch (SqlException exSQL)
            {
                //roll back avant n'importe quel traitement 
                //après on renvoie l'erreur business,...
                oTrans.Rollback();
                int IdError = 999;
                switch (exSQL.Number)
                {
                    case 18456:
                        IdError = 1;
                        break;
                    case 8152:
                        IdError = 5;
                        break;
                }

                throw new BusinessError.CustomError(IdError);

            }

            finally
            {
                //clsDatabase.oDataBase.Close();

            }

        }

        public static void SelectByMatricule(DataSet poData)
        {
            SqlCommand oSelect
                = new SqlCommand();

            SqlDataAdapter oDataAdapter = new SqlDataAdapter();

            try
            {
                clsDatabase.oDataBase.Open();

                oSelect.Connection = clsDatabase.oDataBase;

                oSelect.CommandType = CommandType.StoredProcedure;
                oSelect.CommandText = "ETU_SelectByMatricule";

                oDataAdapter.SelectCommand = oSelect;

                oDataAdapter.Fill(poData, "MesMatricule");

            }
            catch (SqlException exSQL)
            {
                int IdError = 999;
                switch (exSQL.Number)
                {
                    case 18456:
                        IdError = 1;
                        break;
                }

                throw new BusinessError.CustomError(IdError);

            }
            catch (Exception ex)
            {
                int IdError = 999;

                throw new BusinessError.CustomError(IdError);


            }
            finally
            {
                clsDatabase.oDataBase.Close();
            }




        }
        public static void LoadAllMatricule( DataSet poData)
        {
            SqlCommand oSelect
                = new SqlCommand();

            SqlDataAdapter oDataAdapter = new SqlDataAdapter();

            try
            {
                clsDatabase.oDataBase.Open();

                oSelect.Connection = clsDatabase.oDataBase;

                oSelect.CommandType = CommandType.StoredProcedure;
                oSelect.CommandText = "Etu_SelectAllMatricule";

                oDataAdapter.SelectCommand = oSelect;

                oDataAdapter.Fill(poData, "MesMatricule");
                
            }
            catch (SqlException exSQL)
            {
                int IdError = 999;
                switch (exSQL.Number)
                {
                    case 18456:
                        IdError = 1;
                        break;
                }

                throw new BusinessError.CustomError(IdError);

            }
            catch (Exception ex)
            {
                int IdError = 999;

                throw new BusinessError.CustomError(IdError);


            }
            finally
            {
                clsDatabase.oDataBase.Close(); 
            }




        }

        public static void DeleteFromID(int id)
        {
            {
                SqlCommand oUpd
                    = new SqlCommand();


                try
                {
                    clsDatabase.oDataBase.Open();

                    oUpd.Connection = clsDatabase.oDataBase;

                    oUpd.CommandType = CommandType.StoredProcedure;
                    oUpd.CommandText = "EtuDeleteById";

                  
                    SqlParameter oParamID = new SqlParameter("@id",id);


                   
                    oUpd.Parameters.Add(oParamID);

                    int RowsDeleted = oUpd.ExecuteNonQuery();

                    if (RowsDeleted == 0)
                        throw new BusinessError.CustomError(5);

                }
                catch (SqlException exSQL)
                {
                    int IdError = 999;
                    switch (exSQL.Number)
                    {
                        case 18456:
                            IdError = 1;
                            break;
                        case 8152:
                            IdError = 5;
                            break;
                    }

                    throw new BusinessError.CustomError(IdError);

                }
                catch (Exception ex)
                {
                    int IdError = 999;

                    throw new BusinessError.CustomError(IdError);


                }
                finally
                {
                    clsDatabase.oDataBase.Close();

                }

            }
        }

        public static DataSet SelectByMatricule()
        {
            DataSet oData = new DataSet();
            string matr="";
            oData=SelectByMatricule(matr);
            return oData;
        }

        public static DataSet LoadAllMatricule()
        {
            DataSet oData = new DataSet();

            SqlCommand oSelect
                = new SqlCommand();

            SqlDataAdapter oDataAdapter = new SqlDataAdapter();

            try
            {
                clsDatabase.oDataBase.Open();

                oSelect.Connection = clsDatabase.oDataBase;

                oSelect.CommandType = CommandType.StoredProcedure;
                oSelect.CommandText = "ETU_SelectAll";

                oDataAdapter.SelectCommand = oSelect;

                oDataAdapter.Fill(oData, "MesMatricule");

                return oData;
            }
            catch (SqlException exSQL)
            {
                int IdError = 999;
                switch (exSQL.Number)
                {
                    case 18456:
                        IdError = 1;
                        break;
                }

                throw new BusinessError.CustomError(IdError);

            }
            catch (Exception ex)
            {
                int IdError = 999;

                throw new BusinessError.CustomError(IdError);


            }
            finally
            {
                clsDatabase.oDataBase.Close();


            }

        }

        public static void SaveAllMDI(List<Etudiant> listEtu, List<studentTest> ListToInsert)
        {

            {
                SqlCommand oUpd
                   = null;
                SqlCommand oDel
                  = null;

                SqlCommand oIns
                  = null;
                SqlTransaction oTrans = null;

                try
                {
                    //delete

                    //uodate
                    clsDatabase.oDataBase.Open();

                  
                    foreach (var etu in listEtu)
                    {
                        oUpd = new SqlCommand();
                        oUpd.Connection = clsDatabase.oDataBase;
                        oUpd.Transaction = oTrans;
                        oUpd.CommandType = CommandType.StoredProcedure;
                        oUpd.CommandText = "UpdateByID";
                        SqlParameter oParamMatricule = new SqlParameter("@Matricule", etu.Matricule);
                        SqlParameter oParamID = new SqlParameter("@ID", etu.ID);


                        oUpd.Parameters.Add(oParamMatricule);
                        oUpd.Parameters.Add(oParamID);

                        int RowsModified = oUpd.ExecuteNonQuery();

                        if (RowsModified == 0)
                        {
                            //tout erreur logique il faut aussi faire le commit
                            oTrans.Commit();
                            throw new BusinessError.CustomError(5);
                        }


                    }
                    oIns = new SqlCommand();
                    oIns.Connection = clsDatabase.oDataBase;
                    //insert
                    foreach (var etu in ListToInsert)
                    {
                        
                        oIns.Transaction = oTrans;
                        oIns.CommandType = CommandType.StoredProcedure;
                        oIns.CommandText = "Etu_Create";
                        SqlParameter oParamMatricule = new SqlParameter("@matricule", etu.Matricule);
                        SqlParameter oParamNom = new SqlParameter("@nom", etu.nom);
                        SqlParameter oParamPrenom = new SqlParameter("@prenom", etu.prenom);
                        SqlParameter oParamCours = new SqlParameter("@cours", etu.cours);



                        oIns.Parameters.Add(oParamMatricule);
                        oIns.Parameters.Add(oParamNom);
                        oIns.Parameters.Add(oParamPrenom);
                        oIns.Parameters.Add(oParamCours);

                        int RowsModified = oIns.ExecuteNonQuery();

                        if (RowsModified == 0)
                        {
                            //tout erreur logique il faut aussi faire le commit
                            oTrans.Commit();
                            throw new BusinessError.CustomError(5);
                        }

                    }
                   // oTrans.Commit();

                }

                catch (SqlException exSQL)
                {
                    //roll back avant n'importe quel traitement 
                    //après on renvoie l'erreur business,...
                    oTrans.Rollback();
                    int IdError = 999;
                    switch (exSQL.Number)
                    {
                        case 18456:
                            IdError = 1;
                            break;
                        case 8152:
                            IdError = 5;
                            break;
                    }

                    throw new BusinessError.CustomError(IdError);

                }

                finally
                {
                    clsDatabase.oDataBase.Close();

                }

            }
        }

        public static DataSet SelectByMatricule(string matr)
        {
            SqlCommand oUpd
                = new SqlCommand();
            SqlDataAdapter oDataAdapter = new SqlDataAdapter();
            DataSet oData = new DataSet();

            try
            {
                clsDatabase.oDataBase.Open();

                oUpd.Connection = clsDatabase.oDataBase;

                oUpd.CommandType = CommandType.StoredProcedure;
                oUpd.CommandText = "ETU_SelectByMatricule";

                SqlParameter oParamMatricule = new SqlParameter("@matr", matr);
                oUpd.Parameters.Add(oParamMatricule);
                oDataAdapter.SelectCommand = oUpd;

                oDataAdapter.Fill(oData, "MesMatricule");

               
             
              

        
                return oData;
            }
            catch (SqlException exSQL)
            {
                int IdError = 999;
                switch (exSQL.Number)
                {
                    case 18456:
                        IdError = 1;
                        break;
                    case 8152:
                        IdError = 5;
                        break;
                }

                throw new BusinessError.CustomError(IdError);

            }
            catch (Exception ex)
            {
                int IdError = 999;

                throw new BusinessError.CustomError(IdError);


            }
            finally
            {
                clsDatabase.oDataBase.Close();

            }
        }
        public static void UpdateMatricule(string pMAtricule, int pID)
        {
            SqlCommand oUpd
                = new SqlCommand();


             try
            {
                clsDatabase.oDataBase.Open();

                oUpd.Connection = clsDatabase.oDataBase;

                oUpd.CommandType = CommandType.StoredProcedure;
                oUpd.CommandText = "UpdateByID";

                SqlParameter oParamMatricule = new SqlParameter("@Matricule", pMAtricule);
                SqlParameter oParamID = new SqlParameter("@ID", pID);


                oUpd.Parameters.Add(oParamMatricule);
                oUpd.Parameters.Add(oParamID);

                int RowsModified = oUpd.ExecuteNonQuery();

                if (RowsModified == 0)
                    throw new BusinessError.CustomError(5);

            }
            catch (SqlException exSQL)
            {
                int IdError = 999;
                switch (exSQL.Number)
                {
                    case 18456:
                        IdError = 1;
                        break;
                    case 8152:
                        IdError = 5;
                        break;
                }

                throw new BusinessError.CustomError(IdError);

            }
            
            finally
            {
                clsDatabase.oDataBase.Close();

            }

        }
        public static void UpdateAllMatricule(List<BusinessEntity.Etudiant> listEtu)
        {
            SqlCommand oUpd
                = new SqlCommand();
            SqlTransaction oTrans=null;

            try
            {
                clsDatabase.oDataBase.Open();
                oTrans = clsDatabase.oDataBase.BeginTransaction();
                oUpd.Connection = clsDatabase.oDataBase;
                oUpd.Transaction = oTrans;
                oUpd.CommandType = CommandType.StoredProcedure;
                oUpd.CommandText = "UpdateByID";
                foreach (var etu in listEtu)
                {
                    SqlParameter oParamMatricule = new SqlParameter("@Matricule", etu.Matricule);
                    SqlParameter oParamID = new SqlParameter("@ID", etu.ID);


                    oUpd.Parameters.Add(oParamMatricule);
                    oUpd.Parameters.Add(oParamID);

                    int RowsModified = oUpd.ExecuteNonQuery();

                    if (RowsModified == 0)
                    {
                        //tout erreur logique il faut aussi faire le commit
                        oTrans.Commit();
                        throw new BusinessError.CustomError(5);
                    }
                        
                }
                oTrans.Commit();

            }
            catch (SqlException exSQL)
            {
                //roll back avant n'importe quel traitement 
                //après on renvoie l'erreur business,...
                oTrans.Rollback();
                int IdError = 999;
                switch (exSQL.Number)
                {
                    case 18456:
                        IdError = 1;
                        break;
                    case 8152:
                        IdError = 5;
                        break;
                }

                throw new BusinessError.CustomError(IdError);

            }

            finally
            {
                clsDatabase.oDataBase.Close();

            }

        }
        public static void InsertETU(string pMAtricule, string nom,string prenom,string cours)
        {
            SqlCommand oUpd
                = new SqlCommand();


            try
            {
                clsDatabase.oDataBase.Open();

                oUpd.Connection = clsDatabase.oDataBase;

                oUpd.CommandType = CommandType.StoredProcedure;
                oUpd.CommandText = "Etu_Create";

                SqlParameter oParamMatricule = new SqlParameter("@matricule", pMAtricule);
                SqlParameter oParamNom = new SqlParameter("@nom", nom);
                SqlParameter oParamPrenom = new SqlParameter("@prenom", prenom);
                SqlParameter oParamCours = new SqlParameter("@cours", cours);


                oUpd.Parameters.Add(oParamMatricule);
                oUpd.Parameters.Add(oParamNom);
                oUpd.Parameters.Add(oParamPrenom);
                oUpd.Parameters.Add(oParamCours);


                int RowsInserted = oUpd.ExecuteNonQuery();

                if (RowsInserted == 0)
                    throw new BusinessError.CustomError(6);

            }
            catch (SqlException exSQL)
            {
                int IdError = 999;
                switch (exSQL.Number)
                {
                    case 18456:
                        IdError = 1;
                        break;
                    case 8152:
                        IdError = 5;
                        break;
                }

                throw new BusinessError.CustomError(IdError);

            }
            catch (Exception ex)
            {
                int IdError = 999;

                throw new BusinessError.CustomError(IdError);


            }
            finally
            {
                clsDatabase.oDataBase.Close();

            }

        }

 }
}
