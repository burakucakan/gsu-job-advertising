using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace GSUKariyer.COMMON.Helpers.DAL
{
    public abstract class BaseDataLayer
    {
        #region Connection String Functions
        public static string GetConnectionString()
        {
            string connectionString = String.Empty;
            string connectionStringConfigName = ConfigurationHelper.GetAppSetting(
                ConfigurationHelper.AppSettingKeys.ConnStrName);

            if (!String.IsNullOrEmpty(connectionStringConfigName))
            {
                connectionString = ConfigurationHelper.GetConnectionString(connectionStringConfigName).ConnectionString;
            }
            
            return connectionString;
        }
        #endregion

        #region ArrangeParameters
        protected static string[] ArrangeParamValues(SqlParameter[] sqlParams)
        {
            List<string> paramVals = new List<string>();
            for (int i = 0; i < sqlParams.Length; i++)
            {
                if (sqlParams[i].Value != null)
                {
                    paramVals.Add("[" + sqlParams[i].ParameterName + "] = " + sqlParams[i].Value.ToString());
                }
                else
                {
                    paramVals.Add("null");
                }

            }

            return paramVals.ToArray();
        }
        #endregion

        #region ExecuteDataset
        protected static DataSet ExecuteDataset(string storedProcedureName, params SqlParameter[] sqlParams)
        {
            return SqlHelper.ExecuteDataset(GetConnectionString(), CommandType.StoredProcedure, storedProcedureName, sqlParams);
        }
        protected static DataSet ExecuteDataset(SqlTransaction tran, string storedProcedureName, params SqlParameter[] sqlParams)
        {
            if (tran == null)
                return ExecuteDataset(storedProcedureName, sqlParams);

            return SqlHelper.ExecuteDataset(tran, CommandType.StoredProcedure, storedProcedureName, sqlParams);
        }
        #endregion

        #region ExecuteNonQuery
        protected static int ExecuteNonQuery(string storedProcedureName, params SqlParameter[] sqlParams)
        {
            return SqlHelper.ExecuteNonQuery(GetConnectionString(), CommandType.StoredProcedure, storedProcedureName, sqlParams);
        }
        protected static int ExecuteNonQuery(SqlTransaction tran, string storedProcedureName, params SqlParameter[] sqlParams)
        {
            if (tran == null)
                return ExecuteNonQuery(storedProcedureName, sqlParams);

            return SqlHelper.ExecuteNonQuery(tran, CommandType.StoredProcedure, storedProcedureName, sqlParams);
        }
        #endregion

        #region ExecuteScalar
        protected static int ExecuteScalar(string storedProcedureName, params SqlParameter[] sqlParams)
        {
            return (int)(decimal)SqlHelper.ExecuteScalar(GetConnectionString(), CommandType.StoredProcedure, storedProcedureName, sqlParams);
        }
        protected static int ExecuteScalar(SqlTransaction tran, string storedProcedureName, params SqlParameter[] sqlParams)
        {
            if (tran == null)
                return ExecuteScalar(storedProcedureName, sqlParams);

            return (int)(decimal)SqlHelper.ExecuteScalar(tran, CommandType.StoredProcedure, storedProcedureName, sqlParams);
        }
        protected static object ExecuteScalarObj(string storedProcedureName, params SqlParameter[] sqlParams)
        {
            return SqlHelper.ExecuteScalar(GetConnectionString(), CommandType.StoredProcedure, storedProcedureName, sqlParams);
        }
        protected static object ExecuteScalarObj(SqlTransaction tran, string storedProcedureName, params SqlParameter[] sqlParams)
        {
            if (tran == null)
                return ExecuteScalarObj(storedProcedureName, sqlParams);

            return SqlHelper.ExecuteScalar(tran, CommandType.StoredProcedure, storedProcedureName, sqlParams);
        }
        #endregion
    }
}
