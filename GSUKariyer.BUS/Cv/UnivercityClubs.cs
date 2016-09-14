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
        public class UnivercityClubs: CVUniversityClubs
        {
            #region OtherInfo
            public class OtherInfo
            {
                public struct ColumnNames
                {
                    public const string OtherClubs = "OtherClubs";
                    public const string OtherUniversityClubs = "OtherUniversityClubs";
                }

                public static DataTable Get(int cvId)
                {
                    return CVsProvider.GetCVUserClubsInfo(null, cvId).Tables[0];
                }
                public static int Update(SqlTransaction tran, int cvId, string otherClubs, string otherUniversityClubs,
                    DateTime modifyDate)
                {
                    return CVsProvider.UpdateCVUserClubsInfo(tran, cvId, otherClubs, otherUniversityClubs, modifyDate);
                }
            }
            #endregion

            #region Get Functions
            public static DataTable GetGsClubs(int cvId)
            {
                return CVUniversityClubsProvider.GetGsClubs(null, cvId).Tables[0];
            }
            #endregion

            #region Update Functions
            protected static void Update(SqlTransaction tran, int cvId, DataTable dtGsClubs)
            {
                Check.Require(tran != null, "tran null değer alamaz!");

                Generated.DeleteByParams(tran, cvId, null);

                foreach (DataRow dr in dtGsClubs.Rows)
                {
                    Generated.Add(tran, cvId, dr[ColumnNames.UniversityClub].ToInt());
                }
            }
            public static void Update(int cvId, DataTable dtGsClubs, string otherClubs, string otherUniversityClubs)
            {
                SqlConnection conn = null;
                SqlTransaction tran = null;

                try
                {
                    conn = new SqlConnection(CVUniversityClubsProvider.GetConnectionString());
                    conn.Open();

                    tran = conn.BeginTransaction(IsolationLevel.Serializable);

                    Update(tran, cvId, dtGsClubs);
                    OtherInfo.Update(tran, cvId, otherClubs, otherUniversityClubs, DateTime.Now);

                    //transaction Commit
                    tran.Commit();

                }
                catch (Exception ex)
                {
                    //transaction Rollback
                    tran.Rollback();
                    throw new MyException(ex, "UniversityClubs", "Update");
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
