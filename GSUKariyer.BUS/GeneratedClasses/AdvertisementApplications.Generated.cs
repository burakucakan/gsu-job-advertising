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

    public partial class AdvertisementApplications
    {

        #region ColumnNames
        public struct ColumnNames
        {
            public const string ID = "ID";
            public const string AdvertisementId = "AdvertisementId";
            public const string UserId = "UserId";
            public const string CvId = "CvId";
            public const string FrontPostTitle = "FrontPostTitle";
            public const string FrontPost = "FrontPost";
            public const string AdvertisementAnswer = "AdvertisementAnswer";
            public const string IsRead = "IsRead";
            public const string State = "State";
            public const string ModifyDate = "ModifyDate";
            public const string CreateDate = "CreateDate";
        }
        #endregion

        #region Create DataTable
        public static DataTable CreateTable()
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("ID", System.Type.GetType("System.Int32"));
            dt.Columns.Add("AdvertisementId", System.Type.GetType("System.Int32"));
            dt.Columns.Add("UserId", System.Type.GetType("System.Int32"));
            dt.Columns.Add("CvId", System.Type.GetType("System.Int32"));
            dt.Columns.Add("FrontPostTitle", System.Type.GetType("System.String"));
            dt.Columns.Add("FrontPost", System.Type.GetType("System.String"));
            dt.Columns.Add("AdvertisementAnswer", System.Type.GetType("System.String"));
            dt.Columns.Add("IsRead", System.Type.GetType("System.Boolean"));
            dt.Columns.Add("State", System.Type.GetType("System.Int32"));
            dt.Columns.Add("ModifyDate", System.Type.GetType("System.DateTime"));
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
                    conn = new SqlConnection(AdvertisementApplicationsProvider.GetConnectionString());
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
                    throw new MyException(ex.Message, "AdvertisementApplications", "Add");
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
                    conn = new SqlConnection(AdvertisementApplicationsProvider.GetConnectionString());
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
                    throw new MyException(ex.Message, "AdvertisementApplications", "Update");
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
                return AdvertisementApplicationsProvider.Generated.Add((int)dr[ColumnNames.AdvertisementId],
                                                    (int)dr[ColumnNames.UserId],
                                                    (int)dr[ColumnNames.CvId],
                                                    dr[ColumnNames.FrontPostTitle].ToString(),
                                                    dr[ColumnNames.FrontPost].ToString(),
                                                    dr[ColumnNames.AdvertisementAnswer].ToString(),
                                                    (bool)dr[ColumnNames.IsRead],
                                                    (int)dr[ColumnNames.State],
                                                    (DateTime)dr[ColumnNames.ModifyDate],
                                                    (DateTime)dr[ColumnNames.CreateDate]);

            }

            public static int Add(SqlTransaction tran, DataRow dr)
            {
                return AdvertisementApplicationsProvider.Generated.Add(tran,
                                                    (int)dr[ColumnNames.AdvertisementId],
                                                    (int)dr[ColumnNames.UserId],
                                                    (int)dr[ColumnNames.CvId],
                                                    dr[ColumnNames.FrontPostTitle].ToString(),
                                                    dr[ColumnNames.FrontPost].ToString(),
                                                    dr[ColumnNames.AdvertisementAnswer].ToString(),
                                                    (bool)dr[ColumnNames.IsRead],
                                                    (int)dr[ColumnNames.State],
                                                    (DateTime)dr[ColumnNames.ModifyDate],
                                                    (DateTime)dr[ColumnNames.CreateDate]);

            }

            public static int Update(DataRow dr)
            {
                return AdvertisementApplicationsProvider.Generated.Update((int)dr[ColumnNames.ID],
                                                    (int)dr[ColumnNames.AdvertisementId],
                                                    (int)dr[ColumnNames.UserId],
                                                    (int)dr[ColumnNames.CvId],
                                                    dr[ColumnNames.FrontPostTitle].ToString(),
                                                    dr[ColumnNames.FrontPost].ToString(),
                                                    dr[ColumnNames.AdvertisementAnswer].ToString(),
                                                    (bool)dr[ColumnNames.IsRead],
                                                    (int)dr[ColumnNames.State],
                                                    (DateTime)dr[ColumnNames.ModifyDate]);
            }

            public static int Update(SqlTransaction tran, DataRow dr)
            {
                return AdvertisementApplicationsProvider.Generated.Update(tran,
                                                    (int)dr[ColumnNames.ID],
                                                    (int)dr[ColumnNames.AdvertisementId],
                                                    (int)dr[ColumnNames.UserId],
                                                    (int)dr[ColumnNames.CvId],
                                                    dr[ColumnNames.FrontPostTitle].ToString(),
                                                    dr[ColumnNames.FrontPost].ToString(),
                                                    dr[ColumnNames.AdvertisementAnswer].ToString(),
                                                    (bool)dr[ColumnNames.IsRead],
                                                    (int)dr[ColumnNames.State],
                                                    (DateTime)dr[ColumnNames.ModifyDate]);
            }
        }
        #endregion

        public class Generated
        {

            #region Get Functions
            public static DataTable GetByParams(int? id, int? advertisementId, int? userId, int? cvId, string frontPostTitle, string frontPost, string advertisementAnswer, bool? isRead, int? state, DateTime? modifyDate, DateTime? beforeModifyDate, DateTime? afterOrEqualModifyDate, DateTime? createDate, DateTime? beforeCreateDate, DateTime? afterOrEqualCreateDate)
            {
                return AdvertisementApplicationsProvider.Generated.GetByParams(id, advertisementId, userId, cvId, frontPostTitle, frontPost, advertisementAnswer, isRead, state, modifyDate, beforeModifyDate, afterOrEqualModifyDate, createDate, beforeCreateDate, afterOrEqualCreateDate)
    .Tables[0];
            }

            public static DataTable GetByParams(SqlTransaction tran, int? id, int? advertisementId, int? userId, int? cvId, string frontPostTitle, string frontPost, string advertisementAnswer, bool? isRead, int? state, DateTime? modifyDate, DateTime? beforeModifyDate, DateTime? afterOrEqualModifyDate, DateTime? createDate, DateTime? beforeCreateDate, DateTime? afterOrEqualCreateDate)
            {
                return AdvertisementApplicationsProvider.Generated.GetByParams(tran, id, advertisementId, userId, cvId, frontPostTitle, frontPost, advertisementAnswer, isRead, state, modifyDate, beforeModifyDate, afterOrEqualModifyDate, createDate, beforeCreateDate, afterOrEqualCreateDate)
    .Tables[0];
            }

            public static DataTable GetByParams(params SqlParameter[] sqlParams)
            {
                return AdvertisementApplicationsProvider.Generated.GetByParams(sqlParams).Tables[0];
            }

            public static DataTable GetByParams(SqlTransaction tran, params SqlParameter[] sqlParams)
            {
                return AdvertisementApplicationsProvider.Generated.GetByParams(tran, sqlParams).Tables[0];
            }

            public static DataTable GetByFKBasic(int? userId)
            {
                return AdvertisementApplicationsProvider.Generated.GetByFKBasic(userId)
    .Tables[0];
            }

            public static DataTable GetByFKBasic(SqlTransaction tran, int? userId)
            {
                return AdvertisementApplicationsProvider.Generated.GetByFKBasic(tran, userId)
    .Tables[0];
            }


            public static DataTable GetAll(SqlTransaction tran)
            {
                return AdvertisementApplicationsProvider.Generated.GetAll(tran).Tables[0];
            }

            public static DataTable GetAll()
            {
                return AdvertisementApplicationsProvider.Generated.GetAll().Tables[0];
            }

            public static DataTable Get(SqlTransaction tran, int id)
            {
                return AdvertisementApplicationsProvider.Generated.Get(tran, id)
    .Tables[0];
            }

            public static DataTable Get(int id)
            {
                return AdvertisementApplicationsProvider.Generated.Get(id)
    .Tables[0];
            }

            public static DataTable GetByFK(SqlTransaction tran, int userId)
            {
                return AdvertisementApplicationsProvider.Generated.GetByFK(tran, userId)
    .Tables[0];
            }

            public static DataTable GetByFK(int userId)
            {
                return AdvertisementApplicationsProvider.Generated.GetByFK(userId)
    .Tables[0];
            }


            #endregion

            #region Update Functions
            public static int Update(int id, int advertisementId, int userId, int cvId, string frontPostTitle, string frontPost, string advertisementAnswer, bool isRead, int state, DateTime modifyDate)
            {
                return AdvertisementApplicationsProvider.Generated.Update(id, advertisementId, userId, cvId, frontPostTitle, frontPost, advertisementAnswer, isRead, state, modifyDate)
    ;
            }

            public static int Update(SqlTransaction tran, int id, int advertisementId, int userId, int cvId, string frontPostTitle, string frontPost, string advertisementAnswer, bool isRead, int state, DateTime modifyDate)
            {
                return AdvertisementApplicationsProvider.Generated.Update(id, advertisementId, userId, cvId, frontPostTitle, frontPost, advertisementAnswer, isRead, state, modifyDate)
    ;
            }

            public static int UpdateByParams(int id, int? advertisementId, int? userId, int? cvId, string frontPostTitle, string frontPost, string advertisementAnswer, bool? isRead, int? state, DateTime? modifyDate, DateTime? createDate)
            {
                return AdvertisementApplicationsProvider.Generated.UpdateByParams(id, advertisementId, userId, cvId, frontPostTitle, frontPost, advertisementAnswer, isRead, state, modifyDate, createDate)
    ;
            }

            public static int UpdateByParams(params SqlParameter[] sqlParams)
            {
                return AdvertisementApplicationsProvider.Generated.UpdateByParams(sqlParams);
            }

            public static int UpdateByParams(SqlTransaction tran, int id, int? advertisementId, int? userId, int? cvId, string frontPostTitle, string frontPost, string advertisementAnswer, bool? isRead, int? state, DateTime? modifyDate, DateTime? createDate)
            {
                return AdvertisementApplicationsProvider.Generated.UpdateByParams(tran, id, advertisementId, userId, cvId, frontPostTitle, frontPost, advertisementAnswer, isRead, state, modifyDate, createDate)
    ;
            }

            public static int UpdateByParams(SqlTransaction tran, params SqlParameter[] sqlParams)
            {
                return AdvertisementApplicationsProvider.Generated.UpdateByParams(tran, sqlParams);
            }
            #endregion

            #region Add Functions
            public static int Add(int advertisementId, int userId, int cvId, string frontPostTitle, string frontPost, string advertisementAnswer, bool isRead, int state, DateTime modifyDate, DateTime createDate)
            {
                return AdvertisementApplicationsProvider.Generated.Add(advertisementId, userId, cvId, frontPostTitle, frontPost, advertisementAnswer, isRead, state, modifyDate, createDate)
    ;
            }

            public static int Add(SqlTransaction tran, int advertisementId, int userId, int cvId, string frontPostTitle, string frontPost, string advertisementAnswer, bool isRead, int state, DateTime modifyDate, DateTime createDate)
            {
                return AdvertisementApplicationsProvider.Generated.Add(tran, advertisementId, userId, cvId, frontPostTitle, frontPost, advertisementAnswer, isRead, state, modifyDate, createDate)
    ;
            }
            #endregion

            #region Delete Functions
            public static int DeleteByParams(int? id, int? advertisementId, int? userId, int? cvId, string frontPostTitle, string frontPost, string advertisementAnswer, bool? isRead, int? state, DateTime? modifyDate, DateTime? beforeModifyDate, DateTime? afterOrEqualModifyDate, DateTime? createDate, DateTime? beforeCreateDate, DateTime? afterOrEqualCreateDate)
            {
                return AdvertisementApplicationsProvider.Generated.DeleteByParams(null, id, advertisementId, userId, cvId, frontPostTitle, frontPost, advertisementAnswer, isRead, state, modifyDate, beforeModifyDate, afterOrEqualModifyDate, createDate, beforeCreateDate, afterOrEqualCreateDate)
    ;
            }

            public static int DeleteByParams(SqlTransaction tran, int? id, int? advertisementId, int? userId, int? cvId, string frontPostTitle, string frontPost, string advertisementAnswer, bool? isRead, int? state, DateTime? modifyDate, DateTime? beforeModifyDate, DateTime? afterOrEqualModifyDate, DateTime? createDate, DateTime? beforeCreateDate, DateTime? afterOrEqualCreateDate)
            {
                return AdvertisementApplicationsProvider.Generated.DeleteByParams(tran, id, advertisementId, userId, cvId, frontPostTitle, frontPost, advertisementAnswer, isRead, state, modifyDate, beforeModifyDate, afterOrEqualModifyDate, createDate, beforeCreateDate, afterOrEqualCreateDate)
    ;
            }

            public static int Delete(int id)
            {
                return AdvertisementApplicationsProvider.Generated.Delete(id)
    ;
            }

            public static int Delete(SqlTransaction tran, int id)
            {
                return AdvertisementApplicationsProvider.Generated.Delete(tran, id)
    ;
            }

            public static int DeleteByFK(int? userId)
            {
                return AdvertisementApplicationsProvider.Generated.DeleteByFK(userId)
    ;
            }

            public static int DeleteByFK(SqlTransaction tran, int? userId)
            {
                return AdvertisementApplicationsProvider.Generated.DeleteByFK(userId)
    ;
            }


            #endregion

        }
    }
}
