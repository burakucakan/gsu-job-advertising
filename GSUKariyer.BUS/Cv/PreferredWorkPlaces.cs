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
        public class PreferredWorkPlaces: CVWorkPlaces
        {
            public enum Type
            {
                City=0,
                Country=1
            }

            #region Get Functions
            public static DataTable Get(int cvId)
            {
                return Generated.GetByFK(cvId);
            }
            #endregion

            #region Update Functions
            public static void Update(int cvId,DataTable dtWorkPlaces)
            {
                SqlConnection conn = null;
                SqlTransaction tran = null;

                try
                {
                    conn = new SqlConnection(CVUniversityClubsProvider.GetConnectionString());
                    conn.Open();

                    tran = conn.BeginTransaction(IsolationLevel.Serializable);

                    Generated.DeleteByFK(tran, cvId);

                    foreach(DataRow dr in dtWorkPlaces.Rows)
                    {
                        dr[ColumnNames.CVId]=cvId;
                        BulkOperation.Add(tran, dr);
                    }
                    
                    //transaction Commit
                    tran.Commit();

                }
                catch (Exception ex)
                {
                    //transaction Rollback
                    tran.Rollback();
                    throw new MyException(ex, "PreferredWorkPlaces", "Update");
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
