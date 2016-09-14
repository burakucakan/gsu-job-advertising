using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using GSUKariyer.DAL;
using GSUKariyer.COMMON.Exceptions;
using GSUKariyer.COMMON;

namespace GSUKariyer.BUS
{

    public partial class CVInterestedJobPositons
    {

        #region ColumnNames
        public struct ColumnNames
        {
            public const string CVId = "CVId";
            public const string InterestedJobPositions = "InterestedJobPositions";
            public const string Order = "Order";
        }
        #endregion

        #region Create DataTable
        public static DataTable CreateTable()
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("CVId", System.Type.GetType("System.Int32"));
            dt.Columns.Add("InterestedJobPositions", System.Type.GetType("System.String"));
            dt.Columns.Add("Order", System.Type.GetType("System.Int32"));

            return dt;
        }

        #endregion

        #region Bulk Operations
        public class BulkOperation
        {

            public static void Add(SqlTransaction tran, DataTable dt)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    Add(tran, dr);
                }
            }

            public static void Add(DataTable dt)
            {
                SqlConnection conn = null;
                SqlTransaction tran = null;

                try
                {
                    conn = new SqlConnection(CVInterestedJobPositonsProvider.GetConnectionString());
                    conn.Open();

                    tran = conn.BeginTransaction(IsolationLevel.Serializable);

                    foreach (DataRow dr in dt.Rows)
                    {
                        Add(tran, dr);
                    }

                    //transaction Commit
                    tran.Commit();

                }
                catch (Exception ex)
                {
                    //transaction Rollback
                    tran.Rollback();
                    throw new MyException(ex.Message, "CVInterestedJobPositons", "Add");
                }
                finally
                {
                    //Connection Close
                    conn.Close();
                    conn.Dispose();
                }

            }

            public static void Update(SqlTransaction tran, DataTable dt)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    Update(tran, dr);
                }
            }

            public static void Update(DataTable dt)
            {
                SqlConnection conn = null;
                SqlTransaction tran = null;

                try
                {
                    conn = new SqlConnection(CVInterestedJobPositonsProvider.GetConnectionString());
                    conn.Open();

                    tran = conn.BeginTransaction(IsolationLevel.Serializable);

                    foreach (DataRow dr in dt.Rows)
                    {
                        Update(tran, dr);
                    }

                    //transaction Commit
                    tran.Commit();

                }
                catch (Exception ex)
                {
                    //transaction Rollback
                    tran.Rollback();
                    throw new MyException(ex.Message, "CVInterestedJobPositons", "Update");
                }
                finally
                {
                    //Connection Close
                    conn.Close();
                    conn.Dispose();
                }
            }

            public static void Add(DataRow dr)
            {
                CVInterestedJobPositonsProvider.Generated.Add((int)dr[ColumnNames.CVId],
                                                    dr[ColumnNames.InterestedJobPositions].ToString(),
                                                    (int)dr[ColumnNames.Order]);

            }

            public static void Add(SqlTransaction tran, DataRow dr)
            {
                CVInterestedJobPositonsProvider.Generated.Add(tran,
                                                    (int)dr[ColumnNames.CVId],
                                                    dr[ColumnNames.InterestedJobPositions].ToString(),
                                                    (int)dr[ColumnNames.Order]);

            }

            public static int Update(DataRow dr)
            {
                return CVInterestedJobPositonsProvider.Generated.Update((int)dr[ColumnNames.CVId],
                                                    dr[ColumnNames.InterestedJobPositions].ToString(),
                                                    (int)dr[ColumnNames.Order]);
            }

            public static int Update(SqlTransaction tran, DataRow dr)
            {
                return CVInterestedJobPositonsProvider.Generated.Update(tran,
                                                    (int)dr[ColumnNames.CVId],
                                                    dr[ColumnNames.InterestedJobPositions].ToString(),
                                                    (int)dr[ColumnNames.Order]);
            }
        }
        #endregion

        public class Generated
        {

            #region Get Functions
            public static DataTable GetByParams(int? cVId, string interestedJobPositions, int? order)
            {
                return CVInterestedJobPositonsProvider.Generated.GetByParams(cVId, interestedJobPositions, order)
    .Tables[0];
            }

            public static DataTable GetByParams(SqlTransaction tran, int? cVId, string interestedJobPositions, int? order)
            {
                return CVInterestedJobPositonsProvider.Generated.GetByParams(tran, cVId, interestedJobPositions, order)
    .Tables[0];
            }

            public static DataTable GetByParams(params SqlParameter[] sqlParams)
            {
                return CVInterestedJobPositonsProvider.Generated.GetByParams(sqlParams).Tables[0];
            }

            public static DataTable GetByParams(SqlTransaction tran, params SqlParameter[] sqlParams)
            {
                return CVInterestedJobPositonsProvider.Generated.GetByParams(tran, sqlParams).Tables[0];
            }



            public static DataTable GetAll(SqlTransaction tran)
            {
                return CVInterestedJobPositonsProvider.Generated.GetAll(tran).Tables[0];
            }

            public static DataTable GetAll()
            {
                return CVInterestedJobPositonsProvider.Generated.GetAll().Tables[0];
            }

            public static DataTable Get(SqlTransaction tran, int cVId, string interestedJobPositions)
            {
                return CVInterestedJobPositonsProvider.Generated.Get(tran, cVId, interestedJobPositions)
    .Tables[0];
            }

            public static DataTable Get(int cVId, string interestedJobPositions)
            {
                return CVInterestedJobPositonsProvider.Generated.Get(cVId, interestedJobPositions)
    .Tables[0];
            }



            #endregion

            #region Update Functions
            public static int Update(int cVId, string interestedJobPositions, int order)
            {
                return CVInterestedJobPositonsProvider.Generated.Update(cVId, interestedJobPositions, order)
    ;
            }

            public static int Update(SqlTransaction tran, int cVId, string interestedJobPositions, int order)
            {
                return CVInterestedJobPositonsProvider.Generated.Update(cVId, interestedJobPositions, order)
    ;
            }

            public static int UpdateByParams(int cVId, string interestedJobPositions, int? order)
            {
                return CVInterestedJobPositonsProvider.Generated.UpdateByParams(cVId, interestedJobPositions, order)
    ;
            }

            public static int UpdateByParams(params SqlParameter[] sqlParams)
            {
                return CVInterestedJobPositonsProvider.Generated.UpdateByParams(sqlParams);
            }

            public static int UpdateByParams(SqlTransaction tran, int cVId, string interestedJobPositions, int? order)
            {
                return CVInterestedJobPositonsProvider.Generated.UpdateByParams(tran, cVId, interestedJobPositions, order)
    ;
            }

            public static int UpdateByParams(SqlTransaction tran, params SqlParameter[] sqlParams)
            {
                return CVInterestedJobPositonsProvider.Generated.UpdateByParams(tran, sqlParams);
            }
            #endregion

            #region Add Functions
            public static object Add(int cVId, string interestedJobPositions, int order)
            {
                return CVInterestedJobPositonsProvider.Generated.Add(cVId, interestedJobPositions, order)
    ;
            }

            public static object Add(SqlTransaction tran, int cVId, string interestedJobPositions, int order)
            {
                return CVInterestedJobPositonsProvider.Generated.Add(tran, cVId, interestedJobPositions, order)
    ;
            }
            #endregion

            #region Delete Functions
            public static int DeleteByParams(int? cVId, string interestedJobPositions, int? order)
            {
                return CVInterestedJobPositonsProvider.Generated.DeleteByParams(null, cVId, interestedJobPositions, order)
    ;
            }

            public static int DeleteByParams(SqlTransaction tran, int? cVId, string interestedJobPositions, int? order)
            {
                return CVInterestedJobPositonsProvider.Generated.DeleteByParams(tran, cVId, interestedJobPositions, order)
    ;
            }

            public static int Delete(int cVId, string interestedJobPositions)
            {
                return CVInterestedJobPositonsProvider.Generated.Delete(cVId, interestedJobPositions)
    ;
            }

            public static int Delete(SqlTransaction tran, int cVId, string interestedJobPositions)
            {
                return CVInterestedJobPositonsProvider.Generated.Delete(tran, cVId, interestedJobPositions)
    ;
            }



            #endregion

        }
    }
}
