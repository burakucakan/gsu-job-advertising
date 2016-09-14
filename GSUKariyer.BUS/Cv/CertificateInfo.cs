using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using GSUKariyer.DAL;
using GSUKariyer.COMMON;
using GSUKariyer.COMMON.Exceptions;

namespace GSUKariyer.BUS
{
    public partial class CVs
    {
        public class CertificateInfo : CVCertificateInfo
        {
            public struct CustomColumnNames
            {
                public const string CustomId = "CustomId";
            }

            #region Get Functions
            public static DataTable Get(int cvId)
            {
                return Generated.GetByFK(cvId);
            }
            #endregion

            #region Update Functions
            public static void Update(SqlTransaction tran,int cvId, DataTable dtCertificateInfo)
            {
                Generated.DeleteByFK(tran, cvId);

                foreach (DataRow dr in dtCertificateInfo.Rows)
                {
                    dr[ColumnNames.CVId] = cvId;
                    BulkOperation.Add(tran, dr);
                }
            }
            public static void Update(int cvId, DataTable dtCertificateInfo)
            {
                SqlConnection conn = null;
                SqlTransaction tran = null;

                try
                {
                    conn = new SqlConnection(CVUniversityClubsProvider.GetConnectionString());
                    conn.Open();

                    tran = conn.BeginTransaction(IsolationLevel.Serializable);

                    Update(tran, cvId, dtCertificateInfo);

                    //transaction Commit
                    tran.Commit();
                }
                catch (Exception ex)
                {
                    //transaction Rollback
                    tran.Rollback();
                    throw new MyException(ex, "CertificateInfo", "Update");
                }
                finally
                {
                    //Connection Close
                    conn.Close();
                    conn.Dispose();
                }
            }
            #endregion
        }
    }
}
