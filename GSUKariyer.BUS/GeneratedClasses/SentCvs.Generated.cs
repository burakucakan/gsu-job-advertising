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

    public partial class SentCvs
    {

        #region ColumnNames
        public struct ColumnNames
        {
            public const string ID = "ID";
            public const string UserId = "UserId";
            public const string CvId = "CvId";
            public const string FirmId = "FirmId";
            public const string CreateDate = "CreateDate";
        }
        #endregion

        #region Create DataTable
        public static DataTable CreateTable()
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("ID", System.Type.GetType("System.Int32"));
            dt.Columns.Add("UserId", System.Type.GetType("System.Int32"));
            dt.Columns.Add("CvId", System.Type.GetType("System.Int32"));
            dt.Columns.Add("FirmId", System.Type.GetType("System.Int32"));
            dt.Columns.Add("CreateDate", System.Type.GetType("System.DateTime"));

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
                    conn = new SqlConnection(SentCvsProvider.GetConnectionString());
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
                    throw new MyException(ex.Message, "SentCvs", "Add");
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
                    conn = new SqlConnection(SentCvsProvider.GetConnectionString());
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
                    throw new MyException(ex.Message, "SentCvs", "Update");
                }
                finally
                {
                    //Connection Close
                    conn.Close();
                    conn.Dispose();
                }
            }

            public static int Add(DataRow dr)
            {
                return SentCvsProvider.Generated.Add((int)dr[ColumnNames.UserId],
                                                    (int)dr[ColumnNames.CvId],
                                                    (int)dr[ColumnNames.FirmId],
                                                    (DateTime)dr[ColumnNames.CreateDate]);

            }

            public static int Add(SqlTransaction tran, DataRow dr)
            {
                return SentCvsProvider.Generated.Add(tran,
                                                    (int)dr[ColumnNames.UserId],
                                                    (int)dr[ColumnNames.CvId],
                                                    (int)dr[ColumnNames.FirmId],
                                                    (DateTime)dr[ColumnNames.CreateDate]);

            }

            public static int Update(DataRow dr)
            {
                return SentCvsProvider.Generated.Update((int)dr[ColumnNames.ID],
                                                    (int)dr[ColumnNames.UserId],
                                                    (int)dr[ColumnNames.CvId],
                                                    (int)dr[ColumnNames.FirmId]);
            }

            public static int Update(SqlTransaction tran, DataRow dr)
            {
                return SentCvsProvider.Generated.Update(tran,
                                                    (int)dr[ColumnNames.ID],
                                                    (int)dr[ColumnNames.UserId],
                                                    (int)dr[ColumnNames.CvId],
                                                    (int)dr[ColumnNames.FirmId]);
            }
        }
        #endregion

        public class Generated
        {

            #region Get Functions
            public static DataTable GetByParams(int? id, int? userId, int? cvId, int? firmId, DateTime? createDate, DateTime? beforeCreateDate, DateTime? afterOrEqualCreateDate)
            {
                return SentCvsProvider.Generated.GetByParams(id, userId, cvId, firmId, createDate, beforeCreateDate, afterOrEqualCreateDate)
    .Tables[0];
            }

            public static DataTable GetByParams(SqlTransaction tran, int? id, int? userId, int? cvId, int? firmId, DateTime? createDate, DateTime? beforeCreateDate, DateTime? afterOrEqualCreateDate)
            {
                return SentCvsProvider.Generated.GetByParams(tran, id, userId, cvId, firmId, createDate, beforeCreateDate, afterOrEqualCreateDate)
    .Tables[0];
            }

            public static DataTable GetByParams(params SqlParameter[] sqlParams)
            {
                return SentCvsProvider.Generated.GetByParams(sqlParams).Tables[0];
            }

            public static DataTable GetByParams(SqlTransaction tran, params SqlParameter[] sqlParams)
            {
                return SentCvsProvider.Generated.GetByParams(tran, sqlParams).Tables[0];
            }



            public static DataTable GetAll(SqlTransaction tran)
            {
                return SentCvsProvider.Generated.GetAll(tran).Tables[0];
            }

            public static DataTable GetAll()
            {
                return SentCvsProvider.Generated.GetAll().Tables[0];
            }

            public static DataTable Get(SqlTransaction tran, int id)
            {
                return SentCvsProvider.Generated.Get(tran, id)
    .Tables[0];
            }

            public static DataTable Get(int id)
            {
                return SentCvsProvider.Generated.Get(id)
    .Tables[0];
            }



            #endregion

            #region Update Functions
            public static int Update(int id, int userId, int cvId, int firmId)
            {
                return SentCvsProvider.Generated.Update(id, userId, cvId, firmId)
    ;
            }

            public static int Update(SqlTransaction tran, int id, int userId, int cvId, int firmId)
            {
                return SentCvsProvider.Generated.Update(id, userId, cvId, firmId)
    ;
            }

            public static int UpdateByParams(int id, int? userId, int? cvId, int? firmId, DateTime? createDate)
            {
                return SentCvsProvider.Generated.UpdateByParams(id, userId, cvId, firmId, createDate)
    ;
            }

            public static int UpdateByParams(params SqlParameter[] sqlParams)
            {
                return SentCvsProvider.Generated.UpdateByParams(sqlParams);
            }

            public static int UpdateByParams(SqlTransaction tran, int id, int? userId, int? cvId, int? firmId, DateTime? createDate)
            {
                return SentCvsProvider.Generated.UpdateByParams(tran, id, userId, cvId, firmId, createDate)
    ;
            }

            public static int UpdateByParams(SqlTransaction tran, params SqlParameter[] sqlParams)
            {
                return SentCvsProvider.Generated.UpdateByParams(tran, sqlParams);
            }
            #endregion

            #region Add Functions
            public static int Add(int userId, int cvId, int firmId, DateTime createDate)
            {
                return SentCvsProvider.Generated.Add(userId, cvId, firmId, createDate)
    ;
            }

            public static int Add(SqlTransaction tran, int userId, int cvId, int firmId, DateTime createDate)
            {
                return SentCvsProvider.Generated.Add(tran, userId, cvId, firmId, createDate)
    ;
            }
            #endregion

            #region Delete Functions
            public static int DeleteByParams(int? id, int? userId, int? cvId, int? firmId, DateTime? createDate, DateTime? beforeCreateDate, DateTime? afterOrEqualCreateDate)
            {
                return SentCvsProvider.Generated.DeleteByParams(null, id, userId, cvId, firmId, createDate, beforeCreateDate, afterOrEqualCreateDate)
    ;
            }

            public static int DeleteByParams(SqlTransaction tran, int? id, int? userId, int? cvId, int? firmId, DateTime? createDate, DateTime? beforeCreateDate, DateTime? afterOrEqualCreateDate)
            {
                return SentCvsProvider.Generated.DeleteByParams(tran, id, userId, cvId, firmId, createDate, beforeCreateDate, afterOrEqualCreateDate)
    ;
            }

            public static int Delete(int id)
            {
                return SentCvsProvider.Generated.Delete(id)
    ;
            }

            public static int Delete(SqlTransaction tran, int id)
            {
                return SentCvsProvider.Generated.Delete(tran, id)
    ;
            }



            #endregion

        }
    }
}
