using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using BusinessEntity;

namespace DataAccessLayer
{
    public static class Cours
    {
        
        public static DataSet LoadAllCours()
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
                oSelect.CommandText = "Cours_SelectAll";

                oDataAdapter.SelectCommand = oSelect;

                oDataAdapter.Fill(oData, "MesCours");

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
         
            finally
            {
                clsDatabase.oDataBase.Close();


            }

        }
        public static void InsertCours(string IdCours, string code, string libellé)
        {
            SqlCommand oUpd
                = new SqlCommand();


            try
            {
                clsDatabase.oDataBase.Open();

                oUpd.Connection = clsDatabase.oDataBase;

                oUpd.CommandType = CommandType.StoredProcedure;
                oUpd.CommandText = "Cours_Create";

                SqlParameter oParamMatricule = new SqlParameter("@code", code);
                SqlParameter oParamNom = new SqlParameter("@libellé", libellé);
                SqlParameter oParamPrenom = new SqlParameter("@IdCours", IdCours);



                oUpd.Parameters.Add(oParamMatricule);
                oUpd.Parameters.Add(oParamNom);
                oUpd.Parameters.Add(oParamPrenom);


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
        public static void UpdateCode(string code)
        {
            SqlCommand oUpd
                = new SqlCommand();


            try
            {
                clsDatabase.oDataBase.Open();

                oUpd.Connection = clsDatabase.oDataBase;

                oUpd.CommandType = CommandType.StoredProcedure;
                oUpd.CommandText = "UpdateByCode";

                SqlParameter oParamCode = new SqlParameter("@code", code);
               

                oUpd.Parameters.Add(oParamCode);
             

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
        public static void UpdateLibellé(string libellé)
        {
            SqlCommand oUpd
                = new SqlCommand();


            try
            {
                clsDatabase.oDataBase.Open();

                oUpd.Connection = clsDatabase.oDataBase;

                oUpd.CommandType = CommandType.StoredProcedure;
                oUpd.CommandText = "UpdateByLibellé";

                SqlParameter oParamLibellé = new SqlParameter("@libelle", libellé);


                oUpd.Parameters.Add(oParamLibellé);


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
        public static void UpdateId(string idCours)
        {
            SqlCommand oUpd
                = new SqlCommand();


            try
            {
                clsDatabase.oDataBase.Open();

                oUpd.Connection = clsDatabase.oDataBase;

                oUpd.CommandType = CommandType.StoredProcedure;
                oUpd.CommandText = "UpdateByID";

                SqlParameter oParamId = new SqlParameter("@idCours", idCours);


                oUpd.Parameters.Add(oParamId);


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
        public static void DeleteCode(string code)
        {
            SqlCommand oUpd
                = new SqlCommand();


            try
            {
                clsDatabase.oDataBase.Open();

                oUpd.Connection = clsDatabase.oDataBase;

                oUpd.CommandType = CommandType.StoredProcedure;
                oUpd.CommandText = "DeleteByCode";

                SqlParameter oParamCode = new SqlParameter("@code", code);


                oUpd.Parameters.Add(oParamCode);


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

            finally
            {
                clsDatabase.oDataBase.Close();

            }

        }

        public static void SaveAllTimeStamp( List<BusinessEntity.Cours> ListToUpdates)
        {
            //uodate
            SqlCommand oUpd
              = null;
        
            SqlTransaction oTrans = null;
            try
            {
                clsDatabase.oDataBase.Open();
                oTrans = clsDatabase.oDataBase.BeginTransaction();

                foreach (var cours in ListToUpdates)
                {
                    oUpd = new SqlCommand();
                    oUpd.Connection = clsDatabase.oDataBase;
                    oUpd.Transaction = oTrans;
                    oUpd.CommandType = CommandType.StoredProcedure;
                    oUpd.CommandText = "UpdateCoursByID";
                    SqlParameter oParamCode = new SqlParameter("@code", cours.code);
                    SqlParameter oParamLibellé = new SqlParameter("@libellé", cours.libellé);
                    SqlParameter oParamID = new SqlParameter("@IdCours", cours.IdCours);
                    SqlParameter oParamLastModified = new SqlParameter("@last_modified", cours.last_modified);


                    oUpd.Parameters.Add(oParamCode);
                    oUpd.Parameters.Add(oParamLibellé);
                    oUpd.Parameters.Add(oParamLastModified);
                    oUpd.Parameters.Add(oParamID);
                    int RowsModified = oUpd.ExecuteNonQuery();

                    if (RowsModified == 0)
                    {
                        oTrans.Commit();

                      

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
                    case 547:
                        IdError = 8;
                        break;
                    case 2627:
                        IdError = 10;
                        break;
                }

                throw new BusinessError.CustomError(IdError);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                clsDatabase.oDataBase.Close();

            }


        }

        public static void SaveAll(List<string> lstToDelete, List<BusinessEntity.Cours> ListToUpdate, List<BusinessEntity.Cours> ListToInsert)
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
                clsDatabase.oDataBase.Open();
                oTrans = clsDatabase.oDataBase.BeginTransaction();

                foreach (var code in lstToDelete)
                {

                    oDel = new SqlCommand();
                    oDel.Connection = clsDatabase.oDataBase;
                    oDel.Transaction = oTrans;
                    oDel.CommandType = CommandType.StoredProcedure;
                    oDel.CommandText = "deleteByCode";
                    SqlParameter oParamID = new SqlParameter("@code", code);



                    oDel.Parameters.Add(oParamID);

                    int RowsDeleted = oDel.ExecuteNonQuery();

                    if (RowsDeleted == 0)
                      throw new BusinessError.CustomError(5);


                }
                //uodate

                int RowsModified1 = 0;
                int RowsModified2 = 0;
                //foreach (var cours in ListToUpdate)
                //{
                //    oUpd = new SqlCommand();
                //    oUpd.Connection = clsDatabase.oDataBase;
                //    oUpd.Transaction = oTrans;
                //    oUpd.CommandType = CommandType.StoredProcedure;
                //    oUpd.CommandText = "UpdateByCode";
                //    SqlParameter oParamCode = new SqlParameter("@code", cours.code);
                //    SqlParameter oParamLibellé = new SqlParameter("@libellé", cours.libellé);



                //    oUpd.Parameters.Add(oParamCode);
                //    oUpd.Parameters.Add(oParamLibellé);

                //   RowsModified1 = oUpd.ExecuteNonQuery();

                   


                //}
                foreach (var cours in ListToUpdate)
                {
                    oUpd = new SqlCommand();
                    oUpd.Connection = clsDatabase.oDataBase;
                    oUpd.Transaction = oTrans;
                    oUpd.CommandType = CommandType.StoredProcedure;
                    oUpd.CommandText = "UpdateCoursByID";
                    SqlParameter oParamId = new SqlParameter("@IdCours", cours.IdCours);
                    SqlParameter oParamCode = new SqlParameter("@code", cours.code);
                    SqlParameter oParamLibellé = new SqlParameter("@libellé", cours.libellé);
                    SqlParameter oParamMaxEtu = new SqlParameter("@max_etudiant", cours.max_etu);
                    SqlParameter oParamDt = new SqlParameter("@last_modified", cours.last_modified);

                    oUpd.Parameters.Add(oParamMaxEtu);
                    oUpd.Parameters.Add(oParamCode);
                    oUpd.Parameters.Add(oParamLibellé);
                    oUpd.Parameters.Add(oParamId);
                    oUpd.Parameters.Add(oParamDt);
                    int RowsModified = oUpd.ExecuteNonQuery();
                    if(RowsModified == 0){
                        throw new BusinessError.CustomError(12);
                    }



                }
                //foreach (var cours in ListToUpdate)
                //{
                //    oUpd = new SqlCommand();
                //    oUpd.Connection = clsDatabase.oDataBase;
                //    oUpd.Transaction = oTrans;
                //    oUpd.CommandType = CommandType.StoredProcedure;
                //    oUpd.CommandText = "UpdateByLibellé";
                //    SqlParameter oParamLibellé = new SqlParameter("@Libellé", cours.libellé);
                //    SqlParameter oParamCode = new SqlParameter("@code", cours.code);
                //    SqlParameter oParamId = new SqlParameter("@idCours", cours.IdCours);



                //    oUpd.Parameters.Add(oParamCode);
                //    oUpd.Parameters.Add(oParamLibellé);
                //    oUpd.Parameters.Add(oParamId);

                //    RowsModified2 = oUpd.ExecuteNonQuery();

                   /// if (RowsModified2 == 0 )
                   // {
                        //tout erreur logique il faut aussi faire le commit
                        oTrans.Commit();
                       ////// throw new BusinessError.CustomError(9);
                 //   }
                  //  if (RowsModified1 == 0)
                  //  {
                   ////     oTrans.Commit();
                       //// throw new BusinessError.CustomError(9);

                 //   }


               // }

                //insert
                foreach (var cours in ListToInsert)
                {
                    oIns = new SqlCommand();
                    oIns.Connection = clsDatabase.oDataBase;
                    oIns.Transaction = oTrans;
                    oIns.CommandType = CommandType.StoredProcedure;
                    oIns.CommandText = "Cours_Create";
                    SqlParameter oParamCode = new SqlParameter("@code", cours.code);
                    SqlParameter oParamLibellé = new SqlParameter("@libellé", cours.libellé);
                    //SqlParameter oParamIdCours = new SqlParameter("@idCours", cours.IdCours);

                    SqlParameter oParamIdMaxEtu= new SqlParameter("@max_etu", cours.max_etu);

                    oIns.Parameters.Add(oParamCode);
                    oIns.Parameters.Add(oParamLibellé);
                    //oIns.Parameters.Add(oParamIdCours);
                    oIns.Parameters.Add(oParamIdMaxEtu);
                    int RowsModified = oIns.ExecuteNonQuery();

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
                    case 547:
                        IdError = 8;
                        break;
                    case 2627:
                        IdError = 10;
                        break;
                }

                throw new BusinessError.CustomError(IdError);

            }
            catch(Exception ex)
            {
                throw;
            }

            finally
            {
                clsDatabase.oDataBase.Close();

            }

        }

    }
}