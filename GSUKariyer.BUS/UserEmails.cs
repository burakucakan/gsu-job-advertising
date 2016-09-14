using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using GSUKariyer.DAL;
using GSUKariyer.COMMON.Exceptions;
using GSUKariyer.COMMON;

namespace GSUKariyer.BUS {

	public partial class UserEmails {

        public static DataTable GetUser(string StudentNumber)
        {
            return UserEmailsProvider.Generated.GetByParams(
                new SqlParameter(ColumnNames.StudentNumber, StudentNumber)
                ).Tables[0];
        }


        public static void Import(DataTable dtUserEmails,string uploadPath)
        {
            SqlConnection conn = null;
            SqlTransaction tran = null;

            try
            {
                conn = new SqlConnection(UserEmailsProvider.GetConnectionString());
                conn.Open();

                tran = conn.BeginTransaction(IsolationLevel.Serializable);


                //Truncate Table
                UserEmails.Truncate(tran);

                //Update DataBase
                UserEmails.BulkOperation.Add(tran, dtUserEmails);

                //Update LastUploadedExcelFile
                SiteParams.UpdateLastUploadedExcelFile(tran,uploadPath);

                tran.Commit();
            }catch(Exception ex)
            {
                tran.Rollback();
                Logger.LogErrors(ex.ToString());
                throw ex;
            }
            finally
            {
                conn.Close();
                conn.Dispose();

                conn=null;
            }
        }

        public static int Truncate()
        {
            return UserEmailsProvider.Truncate(null);
        }
        public static int Truncate(SqlTransaction tran)
        {
            return UserEmailsProvider.Truncate(tran);
        }
	}
}
