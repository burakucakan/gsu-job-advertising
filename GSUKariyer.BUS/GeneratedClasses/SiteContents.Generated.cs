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

    public partial class SiteContents
    {

        #region ColumnNames
        public struct ColumnNames
        {
            public const string ID = "ID";
            public const string ContentType = "ContentType";
            public const string Title = "Title";
            public const string ShortContent = "ShortContent";
            public const string Content = "Content";
            public const string ContentImageDescription = "ContentImageDescription";
            public const string Author = "Author";
            public const string ModifyDate = "ModifyDate";
            public const string CreateDate = "CreateDate";
        }
        #endregion

        #region Create DataTable
        public static DataTable CreateTable()
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("ID", System.Type.GetType("System.Int32"));
            dt.Columns.Add("ContentType", System.Type.GetType("System.Int32"));
            dt.Columns.Add("Title", System.Type.GetType("System.String"));
            dt.Columns.Add("ShortContent", System.Type.GetType("System.String"));
            dt.Columns.Add("Content", System.Type.GetType("System.String"));
            dt.Columns.Add("ContentImageDescription", System.Type.GetType("System.String"));
            dt.Columns.Add("Author", System.Type.GetType("System.String"));
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
                    conn = new SqlConnection(SiteContentsProvider.GetConnectionString());
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
                    throw new MyException(ex.Message, "SiteContents", "Add");
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
                    conn = new SqlConnection(SiteContentsProvider.GetConnectionString());
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
                    throw new MyException(ex.Message, "SiteContents", "Update");
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
                return SiteContentsProvider.Generated.Add((int)dr[ColumnNames.ContentType],
                                                    dr[ColumnNames.Title].ToString(),
                                                    dr[ColumnNames.ShortContent].ToString(),
                                                    dr[ColumnNames.Content].ToString(),
                                                    dr[ColumnNames.ContentImageDescription].ToString(),
                                                    dr[ColumnNames.Author].ToString(),
                                                    (DateTime)dr[ColumnNames.ModifyDate],
                                                    (DateTime)dr[ColumnNames.CreateDate]);

            }

            public static int Add(SqlTransaction tran, DataRow dr)
            {
                return SiteContentsProvider.Generated.Add(tran,
                                                    (int)dr[ColumnNames.ContentType],
                                                    dr[ColumnNames.Title].ToString(),
                                                    dr[ColumnNames.ShortContent].ToString(),
                                                    dr[ColumnNames.Content].ToString(),
                                                    dr[ColumnNames.ContentImageDescription].ToString(),
                                                    dr[ColumnNames.Author].ToString(),
                                                    (DateTime)dr[ColumnNames.ModifyDate],
                                                    (DateTime)dr[ColumnNames.CreateDate]);

            }

            public static int Update(DataRow dr)
            {
                return SiteContentsProvider.Generated.Update((int)dr[ColumnNames.ID],
                                                    (int)dr[ColumnNames.ContentType],
                                                    dr[ColumnNames.Title].ToString(),
                                                    dr[ColumnNames.ShortContent].ToString(),
                                                    dr[ColumnNames.Content].ToString(),
                                                    dr[ColumnNames.ContentImageDescription].ToString(),
                                                    dr[ColumnNames.Author].ToString(),
                                                    (DateTime)dr[ColumnNames.ModifyDate]);
            }

            public static int Update(SqlTransaction tran, DataRow dr)
            {
                return SiteContentsProvider.Generated.Update(tran,
                                                    (int)dr[ColumnNames.ID],
                                                    (int)dr[ColumnNames.ContentType],
                                                    dr[ColumnNames.Title].ToString(),
                                                    dr[ColumnNames.ShortContent].ToString(),
                                                    dr[ColumnNames.Content].ToString(),
                                                    dr[ColumnNames.ContentImageDescription].ToString(),
                                                    dr[ColumnNames.Author].ToString(),
                                                    (DateTime)dr[ColumnNames.ModifyDate]);
            }
        }
        #endregion

        public class Generated
        {

            #region Get Functions
            public static DataTable GetByParams(int? id, int? contentType, string title, string shortContent, string content, string contentImageDescription, string author, DateTime? modifyDate, DateTime? beforeModifyDate, DateTime? afterOrEqualModifyDate, DateTime? createDate, DateTime? beforeCreateDate, DateTime? afterOrEqualCreateDate)
            {
                return SiteContentsProvider.Generated.GetByParams(id, contentType, title, shortContent, content, contentImageDescription, author, modifyDate, beforeModifyDate, afterOrEqualModifyDate, createDate, beforeCreateDate, afterOrEqualCreateDate)
    .Tables[0];
            }

            public static DataTable GetByParams(SqlTransaction tran, int? id, int? contentType, string title, string shortContent, string content, string contentImageDescription, string author, DateTime? modifyDate, DateTime? beforeModifyDate, DateTime? afterOrEqualModifyDate, DateTime? createDate, DateTime? beforeCreateDate, DateTime? afterOrEqualCreateDate)
            {
                return SiteContentsProvider.Generated.GetByParams(tran, id, contentType, title, shortContent, content, contentImageDescription, author, modifyDate, beforeModifyDate, afterOrEqualModifyDate, createDate, beforeCreateDate, afterOrEqualCreateDate)
    .Tables[0];
            }

            public static DataTable GetByParams(params SqlParameter[] sqlParams)
            {
                return SiteContentsProvider.Generated.GetByParams(sqlParams).Tables[0];
            }

            public static DataTable GetByParams(SqlTransaction tran, params SqlParameter[] sqlParams)
            {
                return SiteContentsProvider.Generated.GetByParams(tran, sqlParams).Tables[0];
            }



            public static DataTable GetAll(SqlTransaction tran)
            {
                return SiteContentsProvider.Generated.GetAll(tran).Tables[0];
            }

            public static DataTable GetAll()
            {
                return SiteContentsProvider.Generated.GetAll().Tables[0];
            }

            public static DataTable Get(SqlTransaction tran, int id)
            {
                return SiteContentsProvider.Generated.Get(tran, id)
    .Tables[0];
            }

            public static DataTable Get(int id)
            {
                return SiteContentsProvider.Generated.Get(id)
    .Tables[0];
            }



            #endregion

            #region Update Functions
            public static int Update(int id, int contentType, string title, string shortContent, string content, string contentImageDescription, string author, DateTime modifyDate)
            {
                return SiteContentsProvider.Generated.Update(id, contentType, title, shortContent, content, contentImageDescription, author, modifyDate)
    ;
            }

            public static int Update(SqlTransaction tran, int id, int contentType, string title, string shortContent, string content, string contentImageDescription, string author, DateTime modifyDate)
            {
                return SiteContentsProvider.Generated.Update(id, contentType, title, shortContent, content, contentImageDescription, author, modifyDate)
    ;
            }

            public static int UpdateByParams(int id, int? contentType, string title, string shortContent, string content, string contentImageDescription, string author, DateTime? modifyDate, DateTime? createDate)
            {
                return SiteContentsProvider.Generated.UpdateByParams(id, contentType, title, shortContent, content, contentImageDescription, author, modifyDate, createDate)
    ;
            }

            public static int UpdateByParams(params SqlParameter[] sqlParams)
            {
                return SiteContentsProvider.Generated.UpdateByParams(sqlParams);
            }

            public static int UpdateByParams(SqlTransaction tran, int id, int? contentType, string title, string shortContent, string content, string contentImageDescription, string author, DateTime? modifyDate, DateTime? createDate)
            {
                return SiteContentsProvider.Generated.UpdateByParams(tran, id, contentType, title, shortContent, content, contentImageDescription, author, modifyDate, createDate)
    ;
            }

            public static int UpdateByParams(SqlTransaction tran, params SqlParameter[] sqlParams)
            {
                return SiteContentsProvider.Generated.UpdateByParams(tran, sqlParams);
            }
            #endregion

            #region Add Functions
            public static int Add(int contentType, string title, string shortContent, string content, string contentImageDescription, string author, DateTime modifyDate, DateTime createDate)
            {
                return SiteContentsProvider.Generated.Add(contentType, title, shortContent, content, contentImageDescription, author, modifyDate, createDate)
    ;
            }

            public static int Add(SqlTransaction tran, int contentType, string title, string shortContent, string content, string contentImageDescription, string author, DateTime modifyDate, DateTime createDate)
            {
                return SiteContentsProvider.Generated.Add(tran, contentType, title, shortContent, content, contentImageDescription, author, modifyDate, createDate)
    ;
            }
            #endregion

            #region Delete Functions
            public static int DeleteByParams(int? id, int? contentType, string title, string shortContent, string content, string contentImageDescription, string author, DateTime? modifyDate, DateTime? beforeModifyDate, DateTime? afterOrEqualModifyDate, DateTime? createDate, DateTime? beforeCreateDate, DateTime? afterOrEqualCreateDate)
            {
                return SiteContentsProvider.Generated.DeleteByParams(null, id, contentType, title, shortContent, content, contentImageDescription, author, modifyDate, beforeModifyDate, afterOrEqualModifyDate, createDate, beforeCreateDate, afterOrEqualCreateDate)
    ;
            }

            public static int DeleteByParams(SqlTransaction tran, int? id, int? contentType, string title, string shortContent, string content, string contentImageDescription, string author, DateTime? modifyDate, DateTime? beforeModifyDate, DateTime? afterOrEqualModifyDate, DateTime? createDate, DateTime? beforeCreateDate, DateTime? afterOrEqualCreateDate)
            {
                return SiteContentsProvider.Generated.DeleteByParams(tran, id, contentType, title, shortContent, content, contentImageDescription, author, modifyDate, beforeModifyDate, afterOrEqualModifyDate, createDate, beforeCreateDate, afterOrEqualCreateDate)
    ;
            }

            public static int Delete(int id)
            {
                return SiteContentsProvider.Generated.Delete(id)
    ;
            }

            public static int Delete(SqlTransaction tran, int id)
            {
                return SiteContentsProvider.Generated.Delete(tran, id)
    ;
            }



            #endregion

        }
    }
}
