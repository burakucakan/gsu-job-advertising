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

    public partial class BannerFiles
    {

        #region ColumnNames
        public struct ColumnNames
        {
            public const string ID = "ID";
            public const string Name = "Name";
            public const string FileName = "FileName";
            public const string Type = "Type";
            public const string Link = "Link";
            public const string Width = "Width";
            public const string Height = "Height";
            public const string ModifyDate = "ModifyDate";
            public const string CreateDate = "CreateDate";
        }
        #endregion

        #region Create DataTable
        public static DataTable CreateTable()
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("ID", System.Type.GetType("System.Int32"));
            dt.Columns.Add("Name", System.Type.GetType("System.String"));
            dt.Columns.Add("FileName", System.Type.GetType("System.String"));
            dt.Columns.Add("Type", System.Type.GetType("System.Int32"));
            dt.Columns.Add("Link", System.Type.GetType("System.String"));
            dt.Columns.Add("Width", System.Type.GetType("System.Int32"));
            dt.Columns.Add("Height", System.Type.GetType("System.Int32"));
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
                    conn = new SqlConnection(BannerFilesProvider.GetConnectionString());
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
                    throw new MyException(ex.Message, "BannerFiles", "Add");
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
                    conn = new SqlConnection(BannerFilesProvider.GetConnectionString());
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
                    throw new MyException(ex.Message, "BannerFiles", "Update");
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
                return BannerFilesProvider.Generated.Add(dr[ColumnNames.Name].ToString(),
                                                    dr[ColumnNames.FileName].ToString(),
                                                    (int)dr[ColumnNames.Type],
                                                    dr[ColumnNames.Link].ToString(),
                                                    DBNullHelper.GetNullableValue<int>(dr[ColumnNames.Width]),
                                                    DBNullHelper.GetNullableValue<int>(dr[ColumnNames.Height]),
                                                    (DateTime)dr[ColumnNames.ModifyDate],
                                                    (DateTime)dr[ColumnNames.CreateDate]);

            }

            public static int Add(SqlTransaction tran, DataRow dr)
            {
                return BannerFilesProvider.Generated.Add(tran,
                                                    dr[ColumnNames.Name].ToString(),
                                                    dr[ColumnNames.FileName].ToString(),
                                                    (int)dr[ColumnNames.Type],
                                                    dr[ColumnNames.Link].ToString(),
                                                    DBNullHelper.GetNullableValue<int>(dr[ColumnNames.Width]),
                                                    DBNullHelper.GetNullableValue<int>(dr[ColumnNames.Height]),
                                                    (DateTime)dr[ColumnNames.ModifyDate],
                                                    (DateTime)dr[ColumnNames.CreateDate]);

            }

            public static int Update(DataRow dr)
            {
                return BannerFilesProvider.Generated.Update((int)dr[ColumnNames.ID],
                                                    dr[ColumnNames.Name].ToString(),
                                                    dr[ColumnNames.FileName].ToString(),
                                                    (int)dr[ColumnNames.Type],
                                                    dr[ColumnNames.Link].ToString(),
                                                    DBNullHelper.GetNullableValue<int>(dr[ColumnNames.Width]),
                                                    DBNullHelper.GetNullableValue<int>(dr[ColumnNames.Height]),
                                                    (DateTime)dr[ColumnNames.ModifyDate]);
            }

            public static int Update(SqlTransaction tran, DataRow dr)
            {
                return BannerFilesProvider.Generated.Update(tran,
                                                    (int)dr[ColumnNames.ID],
                                                    dr[ColumnNames.Name].ToString(),
                                                    dr[ColumnNames.FileName].ToString(),
                                                    (int)dr[ColumnNames.Type],
                                                    dr[ColumnNames.Link].ToString(),
                                                    DBNullHelper.GetNullableValue<int>(dr[ColumnNames.Width]),
                                                    DBNullHelper.GetNullableValue<int>(dr[ColumnNames.Height]),
                                                    (DateTime)dr[ColumnNames.ModifyDate]);
            }
        }
        #endregion

        public class Generated
        {

            #region Get Functions
            public static DataTable GetByParams(int? id, string name, string fileName, int? type, string link, int? width, int? height, DateTime? modifyDate, DateTime? beforeModifyDate, DateTime? afterOrEqualModifyDate, DateTime? createDate, DateTime? beforeCreateDate, DateTime? afterOrEqualCreateDate)
            {
                return BannerFilesProvider.Generated.GetByParams(id, name, fileName, type, link, width, height, modifyDate, beforeModifyDate, afterOrEqualModifyDate, createDate, beforeCreateDate, afterOrEqualCreateDate)
    .Tables[0];
            }

            public static DataTable GetByParams(SqlTransaction tran, int? id, string name, string fileName, int? type, string link, int? width, int? height, DateTime? modifyDate, DateTime? beforeModifyDate, DateTime? afterOrEqualModifyDate, DateTime? createDate, DateTime? beforeCreateDate, DateTime? afterOrEqualCreateDate)
            {
                return BannerFilesProvider.Generated.GetByParams(tran, id, name, fileName, type, link, width, height, modifyDate, beforeModifyDate, afterOrEqualModifyDate, createDate, beforeCreateDate, afterOrEqualCreateDate)
    .Tables[0];
            }

            public static DataTable GetByParams(params SqlParameter[] sqlParams)
            {
                return BannerFilesProvider.Generated.GetByParams(sqlParams).Tables[0];
            }

            public static DataTable GetByParams(SqlTransaction tran, params SqlParameter[] sqlParams)
            {
                return BannerFilesProvider.Generated.GetByParams(tran, sqlParams).Tables[0];
            }



            public static DataTable GetAll(SqlTransaction tran)
            {
                return BannerFilesProvider.Generated.GetAll(tran).Tables[0];
            }

            public static DataTable GetAll()
            {
                return BannerFilesProvider.Generated.GetAll().Tables[0];
            }

            public static DataTable Get(SqlTransaction tran, int id)
            {
                return BannerFilesProvider.Generated.Get(tran, id)
    .Tables[0];
            }

            public static DataTable Get(int id)
            {
                return BannerFilesProvider.Generated.Get(id)
    .Tables[0];
            }



            #endregion

            #region Update Functions
            public static int Update(int id, string name, string fileName, int type, string link, int? width, int? height, DateTime modifyDate)
            {
                return BannerFilesProvider.Generated.Update(id, name, fileName, type, link, width, height, modifyDate)
    ;
            }

            public static int Update(SqlTransaction tran, int id, string name, string fileName, int type, string link, int? width, int? height, DateTime modifyDate)
            {
                return BannerFilesProvider.Generated.Update(id, name, fileName, type, link, width, height, modifyDate)
    ;
            }

            public static int UpdateByParams(int id, string name, string fileName, int? type, string link, int? width, int? height, DateTime? modifyDate, DateTime? createDate)
            {
                return BannerFilesProvider.Generated.UpdateByParams(id, name, fileName, type, link, width, height, modifyDate, createDate)
    ;
            }

            public static int UpdateByParams(params SqlParameter[] sqlParams)
            {
                return BannerFilesProvider.Generated.UpdateByParams(sqlParams);
            }

            public static int UpdateByParams(SqlTransaction tran, int id, string name, string fileName, int? type, string link, int? width, int? height, DateTime? modifyDate, DateTime? createDate)
            {
                return BannerFilesProvider.Generated.UpdateByParams(tran, id, name, fileName, type, link, width, height, modifyDate, createDate)
    ;
            }

            public static int UpdateByParams(SqlTransaction tran, params SqlParameter[] sqlParams)
            {
                return BannerFilesProvider.Generated.UpdateByParams(tran, sqlParams);
            }
            #endregion

            #region Add Functions
            public static int Add(string name, string fileName, int type, string link, int? width, int? height, DateTime modifyDate, DateTime createDate)
            {
                return BannerFilesProvider.Generated.Add(name, fileName, type, link, width, height, modifyDate, createDate)
    ;
            }

            public static int Add(SqlTransaction tran, string name, string fileName, int type, string link, int? width, int? height, DateTime modifyDate, DateTime createDate)
            {
                return BannerFilesProvider.Generated.Add(tran, name, fileName, type, link, width, height, modifyDate, createDate)
    ;
            }
            #endregion

            #region Delete Functions
            public static int DeleteByParams(int? id, string name, string fileName, int? type, string link, int? width, int? height, DateTime? modifyDate, DateTime? beforeModifyDate, DateTime? afterOrEqualModifyDate, DateTime? createDate, DateTime? beforeCreateDate, DateTime? afterOrEqualCreateDate)
            {
                return BannerFilesProvider.Generated.DeleteByParams(null, id, name, fileName, type, link, width, height, modifyDate, beforeModifyDate, afterOrEqualModifyDate, createDate, beforeCreateDate, afterOrEqualCreateDate)
    ;
            }

            public static int DeleteByParams(SqlTransaction tran, int? id, string name, string fileName, int? type, string link, int? width, int? height, DateTime? modifyDate, DateTime? beforeModifyDate, DateTime? afterOrEqualModifyDate, DateTime? createDate, DateTime? beforeCreateDate, DateTime? afterOrEqualCreateDate)
            {
                return BannerFilesProvider.Generated.DeleteByParams(tran, id, name, fileName, type, link, width, height, modifyDate, beforeModifyDate, afterOrEqualModifyDate, createDate, beforeCreateDate, afterOrEqualCreateDate)
    ;
            }

            public static int Delete(int id)
            {
                return BannerFilesProvider.Generated.Delete(id)
    ;
            }

            public static int Delete(SqlTransaction tran, int id)
            {
                return BannerFilesProvider.Generated.Delete(tran, id)
    ;
            }



            #endregion

        }
    }
}
