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
        public class InterestedJobPositions : CVInterestedJobPositons
        {
            #region ColumnNames
            public struct SummaryColumnNames
            {
                public const string InterestedAdvertisementType = CVs.ColumnNames.InterestedAdvertisementType;
            }
            #endregion

            #region Get Functions
            public static DataTable Get(int cvId,out string interestedAdvertisementType)
            {
                DataTable dtInterestedJobPositions=CreateTable();
                interestedAdvertisementType = String.Empty;
                
                DataSet ds = CVsProvider.GetCVInterestedJobPositions(null,cvId);

                if (ds.Tables.Count > 1)
                {
                    if(ds.Tables[0].Rows.Count>0)
                    {
                        interestedAdvertisementType=
                            ds.Tables[0].Rows[0][SummaryColumnNames.InterestedAdvertisementType].ToString();
                        dtInterestedJobPositions = ds.Tables[1];
                    }
                }

                return dtInterestedJobPositions;
            }
            #endregion

            #region Update Functions
            public static void Update(SqlTransaction tran,int cvId, int interestedAdvertisementTypes,
                DataTable dtInterestedJobPositons,DateTime modifyDate)
            {
                CVsProvider.UpdateInterestedAdvertisementTypes(tran,cvId,interestedAdvertisementTypes,
                    modifyDate);

                Generated.DeleteByParams(tran,cvId,null,null);

                foreach (DataRow dr in dtInterestedJobPositons.Rows)
                {
                    dr[ColumnNames.CVId] = cvId;
                    BulkOperation.Add(tran, dr);
                }
            }
            public static void Update(int cvId, int interestedAdvertisementTypes,
                DataTable dtInterestedJobPositons, DateTime modifyDate)
            {
                SqlConnection conn = null;
                SqlTransaction tran = null;

                try
                {
                    conn = new SqlConnection(CVUniversityClubsProvider.GetConnectionString());
                    conn.Open();

                    tran = conn.BeginTransaction(IsolationLevel.Serializable);

                    Update(tran, cvId,interestedAdvertisementTypes,dtInterestedJobPositons,modifyDate);

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
