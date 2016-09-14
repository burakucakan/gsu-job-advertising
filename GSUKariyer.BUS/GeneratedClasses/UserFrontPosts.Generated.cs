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

    public partial class UserFrontPosts
    {

        #region ColumnNames
        public struct ColumnNames
        {
            public const string ID = "ID";
            public const string UserId = "UserId";
            public const string Title = "Title";
            public const string Content = "Content";
        }
        #endregion

        #region Create DataTable
        public static DataTable CreateTable()
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("ID", System.Type.GetType("System.Int32"));
            dt.Columns.Add("UserId", System.Type.GetType("System.Int32"));
            dt.Columns.Add("Title", System.Type.GetType("System.String"));
            dt.Columns.Add("Content", System.Type.GetType("System.String"));

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
                    conn = new SqlConnection(UserFrontPostsProvider.GetConnectionString());
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
                    throw new MyException(ex.Message, "UserFrontPosts", "Add");
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
                    conn = new SqlConnection(UserFrontPostsProvider.GetConnectionString());
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
                    throw new MyException(ex.Message, "UserFrontPosts", "Update");
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
                return UserFrontPostsProvider.Generated.Add((int)dr[ColumnNames.UserId],
                                                    dr[ColumnNames.Title].ToString(),
                                                    dr[ColumnNames.Content].ToString());

            }

            public static int Add(SqlTransaction tran, DataRow dr)
            {
                return UserFrontPostsProvider.Generated.Add(tran,
                                                    (int)dr[ColumnNames.UserId],
                                                    dr[ColumnNames.Title].ToString(),
                                                    dr[ColumnNames.Content].ToString());

            }

            public static int Update(DataRow dr)
            {
                return UserFrontPostsProvider.Generated.Update((int)dr[ColumnNames.ID],
                                                    (int)dr[ColumnNames.UserId],
                                                    dr[ColumnNames.Title].ToString(),
                                                    dr[ColumnNames.Content].ToString());
            }

            public static int Update(SqlTransaction tran, DataRow dr)
            {
                return UserFrontPostsProvider.Generated.Update(tran,
                                                    (int)dr[ColumnNames.ID],
                                                    (int)dr[ColumnNames.UserId],
                                                    dr[ColumnNames.Title].ToString(),
                                                    dr[ColumnNames.Content].ToString());
            }
        }
        #endregion

        public class Generated
        {

            #region Get Functions
            public static DataTable GetByParams(int? id, int? userId, string title, string content)
            {
                return UserFrontPostsProvider.Generated.GetByParams(id, userId, title, content)
    .Tables[0];
            }

            public static DataTable GetByParams(SqlTransaction tran, int? id, int? userId, string title, string content)
            {
                return UserFrontPostsProvider.Generated.GetByParams(tran, id, userId, title, content)
    .Tables[0];
            }

            public static DataTable GetByParams(params SqlParameter[] sqlParams)
            {
                return UserFrontPostsProvider.Generated.GetByParams(sqlParams).Tables[0];
            }

            public static DataTable GetByParams(SqlTransaction tran, params SqlParameter[] sqlParams)
            {
                return UserFrontPostsProvider.Generated.GetByParams(tran, sqlParams).Tables[0];
            }



            public static DataTable GetAll(SqlTransaction tran)
            {
                return UserFrontPostsProvider.Generated.GetAll(tran).Tables[0];
            }

            public static DataTable GetAll()
            {
                return UserFrontPostsProvider.Generated.GetAll().Tables[0];
            }

            public static DataTable Get(SqlTransaction tran, int id)
            {
                return UserFrontPostsProvider.Generated.Get(tran, id)
    .Tables[0];
            }

            public static DataTable Get(int id)
            {
                return UserFrontPostsProvider.Generated.Get(id)
    .Tables[0];
            }



            #endregion

            #region Update Functions
            public static int Update(int id, int userId, string title, string content)
            {
                return UserFrontPostsProvider.Generated.Update(id, userId, title, content)
    ;
            }

            public static int Update(SqlTransaction tran, int id, int userId, string title, string content)
            {
                return UserFrontPostsProvider.Generated.Update(id, userId, title, content)
    ;
            }

            public static int UpdateByParams(int id, int? userId, string title, string content)
            {
                return UserFrontPostsProvider.Generated.UpdateByParams(id, userId, title, content)
    ;
            }

            public static int UpdateByParams(params SqlParameter[] sqlParams)
            {
                return UserFrontPostsProvider.Generated.UpdateByParams(sqlParams);
            }

            public static int UpdateByParams(SqlTransaction tran, int id, int? userId, string title, string content)
            {
                return UserFrontPostsProvider.Generated.UpdateByParams(tran, id, userId, title, content)
    ;
            }

            public static int UpdateByParams(SqlTransaction tran, params SqlParameter[] sqlParams)
            {
                return UserFrontPostsProvider.Generated.UpdateByParams(tran, sqlParams);
            }
            #endregion

            #region Add Functions
            public static int Add(int userId, string title, string content)
            {
                return UserFrontPostsProvider.Generated.Add(userId, title, content)
    ;
            }

            public static int Add(SqlTransaction tran, int userId, string title, string content)
            {
                return UserFrontPostsProvider.Generated.Add(tran, userId, title, content)
    ;
            }
            #endregion

            #region Delete Functions
            public static int DeleteByParams(int? id, int? userId, string title, string content)
            {
                return UserFrontPostsProvider.Generated.DeleteByParams(null, id, userId, title, content)
    ;
            }

            public static int DeleteByParams(SqlTransaction tran, int? id, int? userId, string title, string content)
            {
                return UserFrontPostsProvider.Generated.DeleteByParams(tran, id, userId, title, content)
    ;
            }

            public static int Delete(int id)
            {
                return UserFrontPostsProvider.Generated.Delete(id)
    ;
            }

            public static int Delete(SqlTransaction tran, int id)
            {
                return UserFrontPostsProvider.Generated.Delete(tran, id)
    ;
            }



            #endregion

        }
    }
}
