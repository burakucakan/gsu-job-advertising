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
        public class LanguageInfo : CVLanguageInfo
        {
            public int? Language { get; set; }
            public int? ReadGrade { get; set; }
            public int? WriteGrade { get; set; }
            public int? TalkGrade { get; set; }
            public string LearnPlace { get; set; }

            #region Get Functions
            public static DataTable Get(int cvId)
            {
                return Generated.GetByFK(cvId);
            }
            #endregion

            #region Update Functions
            public static void Update(SqlTransaction tran,int cvId, DataTable dtLanguageInfo)
            {
                Generated.DeleteByFK(tran, cvId);

                foreach (DataRow dr in dtLanguageInfo.Rows)
                {
                    dr[ColumnNames.CVId] = cvId;
                    BulkOperation.Add(tran, dr);
                }
            }
            public static void Update(int cvId, DataTable dtLanguageInfo)
            {
                SqlConnection conn = null;
                SqlTransaction tran = null;

                try
                {
                    conn = new SqlConnection(CVUniversityClubsProvider.GetConnectionString());
                    conn.Open();

                    tran = conn.BeginTransaction(IsolationLevel.Serializable);

                    Update(tran, cvId, dtLanguageInfo);

                    //transaction Commit
                    tran.Commit();
                }
                catch (Exception ex)
                {
                    //transaction Rollback
                    tran.Rollback();
                    throw new MyException(ex, "LanguageInfo", "Update");
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
