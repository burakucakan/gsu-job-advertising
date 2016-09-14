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

    public partial class Banners
    {

        #region ColumnNames
        public struct ColumnNames
        {
            public const string ID = "ID";
            public const string BannerFileId = "BannerFileId";
            public const string PageName = "PageName";
            public const string PageLocation = "PageLocation";
            public const string PublishType = "PublishType";
            public const string StartDate = "StartDate";
            public const string EndDate = "EndDate";
            public const string Order = "Order";
            public const string ModifyDate = "ModifyDate";
            public const string CreateDate = "CreateDate";
        }
        #endregion

        #region Create DataTable
        public static DataTable CreateTable()
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("ID", System.Type.GetType("System.Int32"));
            dt.Columns.Add("BannerFileId", System.Type.GetType("System.Int32"));
            dt.Columns.Add("PageName", System.Type.GetType("System.String"));
            dt.Columns.Add("PageLocation", System.Type.GetType("System.Int32"));
            dt.Columns.Add("PublishType", System.Type.GetType("System.Int32"));
            dt.Columns.Add("StartDate", System.Type.GetType("System.DateTime"));
            dt.Columns.Add("EndDate", System.Type.GetType("System.DateTime"));
            dt.Columns.Add("Order", System.Type.GetType("System.Int32"));
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
                    conn = new SqlConnection(BannersProvider.GetConnectionString());
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
                    throw new MyException(ex.Message, "Banners", "Add");
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
                    conn = new SqlConnection(BannersProvider.GetConnectionString());
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
                    throw new MyException(ex.Message, "Banners", "Update");
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
                return BannersProvider.Generated.Add((int)dr[ColumnNames.BannerFileId],
                                                    dr[ColumnNames.PageName].ToString(),
                                                    (int)dr[ColumnNames.PageLocation],
                                                    (int)dr[ColumnNames.PublishType],
                                                    (DateTime)dr[ColumnNames.StartDate],
                                                    (DateTime)dr[ColumnNames.EndDate],
                                                    (int)dr[ColumnNames.Order],
                                                    (DateTime)dr[ColumnNames.ModifyDate],
                                                    (DateTime)dr[ColumnNames.CreateDate]);

            }

            public static int Add(SqlTransaction tran, DataRow dr)
            {
                return BannersProvider.Generated.Add(tran,
                                                    (int)dr[ColumnNames.BannerFileId],
                                                    dr[ColumnNames.PageName].ToString(),
                                                    (int)dr[ColumnNames.PageLocation],
                                                    (int)dr[ColumnNames.PublishType],
                                                    (DateTime)dr[ColumnNames.StartDate],
                                                    (DateTime)dr[ColumnNames.EndDate],
                                                    (int)dr[ColumnNames.Order],
                                                    (DateTime)dr[ColumnNames.ModifyDate],
                                                    (DateTime)dr[ColumnNames.CreateDate]);

            }

            public static int Update(DataRow dr)
            {
                return BannersProvider.Generated.Update((int)dr[ColumnNames.ID],
                                                    (int)dr[ColumnNames.BannerFileId],
                                                    dr[ColumnNames.PageName].ToString(),
                                                    (int)dr[ColumnNames.PageLocation],
                                                    (int)dr[ColumnNames.PublishType],
                                                    (DateTime)dr[ColumnNames.StartDate],
                                                    (DateTime)dr[ColumnNames.EndDate],
                                                    (int)dr[ColumnNames.Order],
                                                    (DateTime)dr[ColumnNames.ModifyDate]);
            }

            public static int Update(SqlTransaction tran, DataRow dr)
            {
                return BannersProvider.Generated.Update(tran,
                                                    (int)dr[ColumnNames.ID],
                                                    (int)dr[ColumnNames.BannerFileId],
                                                    dr[ColumnNames.PageName].ToString(),
                                                    (int)dr[ColumnNames.PageLocation],
                                                    (int)dr[ColumnNames.PublishType],
                                                    (DateTime)dr[ColumnNames.StartDate],
                                                    (DateTime)dr[ColumnNames.EndDate],
                                                    (int)dr[ColumnNames.Order],
                                                    (DateTime)dr[ColumnNames.ModifyDate]);
            }
        }
        #endregion

        public class Generated
        {

            #region Get Functions
            public static DataTable GetByParams(int? id, int? bannerFileId, string pageName, int? pageLocation, int? publishType, DateTime? startDate, DateTime? beforeStartDate, DateTime? afterOrEqualStartDate, DateTime? endDate, DateTime? beforeEndDate, DateTime? afterOrEqualEndDate, int? order, DateTime? modifyDate, DateTime? beforeModifyDate, DateTime? afterOrEqualModifyDate, DateTime? createDate, DateTime? beforeCreateDate, DateTime? afterOrEqualCreateDate)
            {
                return BannersProvider.Generated.GetByParams(id, bannerFileId, pageName, pageLocation, publishType, startDate, beforeStartDate, afterOrEqualStartDate, endDate, beforeEndDate, afterOrEqualEndDate, order, modifyDate, beforeModifyDate, afterOrEqualModifyDate, createDate, beforeCreateDate, afterOrEqualCreateDate)
    .Tables[0];
            }

            public static DataTable GetByParams(SqlTransaction tran, int? id, int? bannerFileId, string pageName, int? pageLocation, int? publishType, DateTime? startDate, DateTime? beforeStartDate, DateTime? afterOrEqualStartDate, DateTime? endDate, DateTime? beforeEndDate, DateTime? afterOrEqualEndDate, int? order, DateTime? modifyDate, DateTime? beforeModifyDate, DateTime? afterOrEqualModifyDate, DateTime? createDate, DateTime? beforeCreateDate, DateTime? afterOrEqualCreateDate)
            {
                return BannersProvider.Generated.GetByParams(tran, id, bannerFileId, pageName, pageLocation, publishType, startDate, beforeStartDate, afterOrEqualStartDate, endDate, beforeEndDate, afterOrEqualEndDate, order, modifyDate, beforeModifyDate, afterOrEqualModifyDate, createDate, beforeCreateDate, afterOrEqualCreateDate)
    .Tables[0];
            }

            public static DataTable GetByParams(params SqlParameter[] sqlParams)
            {
                return BannersProvider.Generated.GetByParams(sqlParams).Tables[0];
            }

            public static DataTable GetByParams(SqlTransaction tran, params SqlParameter[] sqlParams)
            {
                return BannersProvider.Generated.GetByParams(tran, sqlParams).Tables[0];
            }



            public static DataTable GetAll(SqlTransaction tran)
            {
                return BannersProvider.Generated.GetAll(tran).Tables[0];
            }

            public static DataTable GetAll()
            {
                return BannersProvider.Generated.GetAll().Tables[0];
            }

            public static DataTable Get(SqlTransaction tran, int id)
            {
                return BannersProvider.Generated.Get(tran, id)
    .Tables[0];
            }

            public static DataTable Get(int id)
            {
                return BannersProvider.Generated.Get(id)
    .Tables[0];
            }



            #endregion

            #region Update Functions
            public static int Update(int id, int bannerFileId, string pageName, int pageLocation, int publishType, DateTime startDate, DateTime endDate, int order, DateTime modifyDate)
            {
                return BannersProvider.Generated.Update(id, bannerFileId, pageName, pageLocation, publishType, startDate, endDate, order, modifyDate)
    ;
            }

            public static int Update(SqlTransaction tran, int id, int bannerFileId, string pageName, int pageLocation, int publishType, DateTime startDate, DateTime endDate, int order, DateTime modifyDate)
            {
                return BannersProvider.Generated.Update(id, bannerFileId, pageName, pageLocation, publishType, startDate, endDate, order, modifyDate)
    ;
            }

            public static int UpdateByParams(int id, int? bannerFileId, string pageName, int? pageLocation, int? publishType, DateTime? startDate, DateTime? endDate, int? order, DateTime? modifyDate, DateTime? createDate)
            {
                return BannersProvider.Generated.UpdateByParams(id, bannerFileId, pageName, pageLocation, publishType, startDate, endDate, order, modifyDate, createDate)
    ;
            }

            public static int UpdateByParams(params SqlParameter[] sqlParams)
            {
                return BannersProvider.Generated.UpdateByParams(sqlParams);
            }

            public static int UpdateByParams(SqlTransaction tran, int id, int? bannerFileId, string pageName, int? pageLocation, int? publishType, DateTime? startDate, DateTime? endDate, int? order, DateTime? modifyDate, DateTime? createDate)
            {
                return BannersProvider.Generated.UpdateByParams(tran, id, bannerFileId, pageName, pageLocation, publishType, startDate, endDate, order, modifyDate, createDate)
    ;
            }

            public static int UpdateByParams(SqlTransaction tran, params SqlParameter[] sqlParams)
            {
                return BannersProvider.Generated.UpdateByParams(tran, sqlParams);
            }
            #endregion

            #region Add Functions
            public static int Add(int bannerFileId, string pageName, int pageLocation, int publishType, DateTime startDate, DateTime endDate, int order, DateTime modifyDate, DateTime createDate)
            {
                return BannersProvider.Generated.Add(bannerFileId, pageName, pageLocation, publishType, startDate, endDate, order, modifyDate, createDate)
    ;
            }

            public static int Add(SqlTransaction tran, int bannerFileId, string pageName, int pageLocation, int publishType, DateTime startDate, DateTime endDate, int order, DateTime modifyDate, DateTime createDate)
            {
                return BannersProvider.Generated.Add(tran, bannerFileId, pageName, pageLocation, publishType, startDate, endDate, order, modifyDate, createDate)
    ;
            }
            #endregion

            #region Delete Functions
            public static int DeleteByParams(int? id, int? bannerFileId, string pageName, int? pageLocation, int? publishType, DateTime? startDate, DateTime? beforeStartDate, DateTime? afterOrEqualStartDate, DateTime? endDate, DateTime? beforeEndDate, DateTime? afterOrEqualEndDate, int? order, DateTime? modifyDate, DateTime? beforeModifyDate, DateTime? afterOrEqualModifyDate, DateTime? createDate, DateTime? beforeCreateDate, DateTime? afterOrEqualCreateDate)
            {
                return BannersProvider.Generated.DeleteByParams(null, id, bannerFileId, pageName, pageLocation, publishType, startDate, beforeStartDate, afterOrEqualStartDate, endDate, beforeEndDate, afterOrEqualEndDate, order, modifyDate, beforeModifyDate, afterOrEqualModifyDate, createDate, beforeCreateDate, afterOrEqualCreateDate)
    ;
            }

            public static int DeleteByParams(SqlTransaction tran, int? id, int? bannerFileId, string pageName, int? pageLocation, int? publishType, DateTime? startDate, DateTime? beforeStartDate, DateTime? afterOrEqualStartDate, DateTime? endDate, DateTime? beforeEndDate, DateTime? afterOrEqualEndDate, int? order, DateTime? modifyDate, DateTime? beforeModifyDate, DateTime? afterOrEqualModifyDate, DateTime? createDate, DateTime? beforeCreateDate, DateTime? afterOrEqualCreateDate)
            {
                return BannersProvider.Generated.DeleteByParams(tran, id, bannerFileId, pageName, pageLocation, publishType, startDate, beforeStartDate, afterOrEqualStartDate, endDate, beforeEndDate, afterOrEqualEndDate, order, modifyDate, beforeModifyDate, afterOrEqualModifyDate, createDate, beforeCreateDate, afterOrEqualCreateDate)
    ;
            }

            public static int Delete(int id)
            {
                return BannersProvider.Generated.Delete(id)
    ;
            }

            public static int Delete(SqlTransaction tran, int id)
            {
                return BannersProvider.Generated.Delete(tran, id)
    ;
            }



            #endregion

        }
    }
}
