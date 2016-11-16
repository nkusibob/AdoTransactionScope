using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

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