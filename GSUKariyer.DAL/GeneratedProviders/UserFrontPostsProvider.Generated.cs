using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using GSUKariyer.COMMON.Helpers.DAL;
using GSUKariyer.COMMON.Exceptions;

namespace GSUKariyer.DAL
{

    public partial class UserFrontPostsProvider : BaseDataLayer
    {

        public class Generated
        {

            #region Get Functions
            protected static DataSet GetBasic(SqlTransaction tran, int? id)
            {
                SqlParameter[] sqlParams = null;

                try
                {
                    DataSet ds = null;

                    sqlParams = new SqlParameter[] { 
					new SqlParameter("@ID",id)
                };

                    if (tran == null)
                        ds = ExecuteDataset("BGA_GetUserFrontPosts", sqlParams);
                    else
                        ds = ExecuteDataset(tran, "BGA_GetUserFrontPosts", sqlParams);

                    return ds;
                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "UserFrontPostsProvider", "Get", ArrangeParamValues(sqlParams));
                }
            }

            public static DataSet GetByParams(int? id, int? userId, string title, string content)
            {
                return GetByParams(null, id, userId, title, content)
    ;
            }

            public static DataSet GetByParams(SqlTransaction tran, int? id, int? userId, string title, string content)
            {
                SqlParameter[] sqlParams = null;

                try
                {
                    DataSet ds = null;

                    sqlParams = new SqlParameter[] { 
					new SqlParameter("@ID",id),
					new SqlParameter("@UserId",userId),
					new SqlParameter("@Title",title),
					new SqlParameter("@Content",content)
                };

                    if (tran == null)
                        ds = ExecuteDataset("BGA_GetUserFrontPostsByParams", sqlParams);
                    else
                        ds = ExecuteDataset(tran, "BGA_GetUserFrontPostsByParams", sqlParams);

                    return ds;
                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "UserFrontPostsProvider", "GetByParams", ArrangeParamValues(sqlParams));
                }
            }

            public static DataSet GetByParams(params SqlParameter[] sqlParams)
            {
                return GetByParams(null, sqlParams);
            }

            public static DataSet GetByParams(SqlTransaction tran, params SqlParameter[] sqlParams)
            {
                try
                {
                    DataSet ds = null;

                    ds = ExecuteDataset("BGA_GetUserFrontPostsByParams", sqlParams);

                    return ds;
                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "UserFrontPostsProvider", "GetByParams", ArrangeParamValues(sqlParams));
                }
            }



            public static DataSet GetAll(SqlTransaction tran)
            {
                return GetBasic(tran, null);
            }

            public static DataSet GetAll()
            {
                return GetBasic(null, null);
            }

            public static DataSet Get(SqlTransaction tran, int id)
            {
                return GetBasic(tran, id);
            }

            public static DataSet Get(int id)
            {
                return GetBasic(null, id);
            }



            #endregion

            #region Update Functions
            public static int Update(int id, int userId, string title, string content)
            {
                SqlParameter[] sqlParams = null;

                try
                {
                    sqlParams = new SqlParameter[] { 
					new SqlParameter("@ID",id),
					new SqlParameter("@UserId",userId),
					new SqlParameter("@Title",title),
					new SqlParameter("@Content",content)
                };

                    return ExecuteNonQuery("BGA_UpdateUserFrontPosts", sqlParams);

                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "UserFrontPostsProvider", "Update", ArrangeParamValues(sqlParams));
                }
            }

            public static int Update(SqlTransaction tran, int id, int userId, string title, string content)
            {
                SqlParameter[] sqlParams = null;

                try
                {
                    sqlParams = new SqlParameter[] { 
					new SqlParameter("@ID",id),
					new SqlParameter("@UserId",userId),
					new SqlParameter("@Title",title),
					new SqlParameter("@Content",content)
                };

                    return ExecuteNonQuery(tran, "BGA_UpdateUserFrontPosts", sqlParams);

                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "UserFrontPostsProvider", "Update", ArrangeParamValues(sqlParams));
                }
            }

            public static int UpdateByParams(int id, int? userId, string title, string content)
            {
                SqlParameter[] sqlParams = null;

                try
                {
                    sqlParams = new SqlParameter[] { 
					new SqlParameter("@ID",id),
					new SqlParameter("@UserId",userId),
					new SqlParameter("@Title",title),
					new SqlParameter("@Content",content)
                };

                    return ExecuteNonQuery("BGA_UpdateUserFrontPostsByParams", sqlParams);

                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "UserFrontPostsProvider", "UpdateByParams", ArrangeParamValues(sqlParams));
                }
            }

            public static int UpdateByParams(params SqlParameter[] sqlParams)
            {
                try
                {

                    return ExecuteNonQuery("BGA_UpdateUserFrontPostsByParams", sqlParams);

                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "UserFrontPostsProvider", "UpdateByParams", ArrangeParamValues(sqlParams));
                }
            }

            public static int UpdateByParams(SqlTransaction tran, int id, int? userId, string title, string content)
            {
                SqlParameter[] sqlParams = null;

                try
                {
                    sqlParams = new SqlParameter[] { 
					new SqlParameter("@ID",id),
					new SqlParameter("@UserId",userId),
					new SqlParameter("@Title",title),
					new SqlParameter("@Content",content)
                };

                    return ExecuteNonQuery(tran, "BGA_UpdateUserFrontPostsByParams", sqlParams);

                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "UserFrontPostsProvider", "UpdateByParams", ArrangeParamValues(sqlParams));
                }
            }

            public static int UpdateByParams(SqlTransaction tran, params SqlParameter[] sqlParams)
            {
                try
                {

                    return ExecuteNonQuery(tran, "BGA_UpdateUserFrontPostsByParams", sqlParams);

                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "UserFrontPostsProvider", "UpdateByParams", ArrangeParamValues(sqlParams));
                }
            }
            #endregion

            #region Add Functions
            public static int Add(int userId, string title, string content)
            {
                SqlParameter[] sqlParams = null;

                try
                {
                    sqlParams = new SqlParameter[] { 
					new SqlParameter("@UserId",userId),
					new SqlParameter("@Title",title),
					new SqlParameter("@Content",content)
                };

                    return ExecuteScalar("BGA_AddUserFrontPosts", sqlParams);

                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "UserFrontPostsProvider", "Add", ArrangeParamValues(sqlParams));
                }
            }

            public static int Add(SqlTransaction tran, int userId, string title, string content)
            {
                SqlParameter[] sqlParams = null;

                try
                {
                    sqlParams = new SqlParameter[] { 
					new SqlParameter("@UserId",userId),
					new SqlParameter("@Title",title),
					new SqlParameter("@Content",content)
                };

                    return ExecuteScalar(tran, "BGA_AddUserFrontPosts", sqlParams);

                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "UserFrontPostsProvider", "Add", ArrangeParamValues(sqlParams));
                }
            }
            #endregion

            #region Delete Functions
            public static int Delete(int id)
            {
                SqlParameter[] sqlParams = null;

                try
                {

                    sqlParams = new SqlParameter[] { 
					new SqlParameter("@ID",id)
                };

                    return ExecuteNonQuery("BGA_DeleteUserFrontPosts", sqlParams);

                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "UserFrontPostsProvider", "Delete", ArrangeParamValues(sqlParams));
                }
            }

            public static int Delete(SqlTransaction tran, int id)
            {
                SqlParameter[] sqlParams = null;

                try
                {

                    sqlParams = new SqlParameter[] { 
					new SqlParameter("@ID",id)
                };

                    return ExecuteNonQuery(tran, "BGA_DeleteUserFrontPosts", sqlParams);

                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "UserFrontPostsProvider", "Delete", ArrangeParamValues(sqlParams));
                }
            }

            public static int DeleteByParams(SqlTransaction tran, int? id, int? userId, string title, string content)
            {
                SqlParameter[] sqlParams = null;

                try
                {
                    sqlParams = new SqlParameter[] { 
					new SqlParameter("@ID",id),
					new SqlParameter("@UserId",userId),
					new SqlParameter("@Title",title),
					new SqlParameter("@Content",content)
                };

                    if (tran == null)
                        return ExecuteNonQuery("BGA_DeleteUserFrontPostsByParams", sqlParams);
                    else
                        return ExecuteNonQuery(tran, "BGA_DeleteUserFrontPostsByParams", sqlParams);


                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "UserFrontPostsProvider", "DeleteByParams", ArrangeParamValues(sqlParams));
                }
            }

            public static int DeleteByParams(int? id, int? userId, string title, string content)
            {
                return DeleteByParams(null, id, userId, title, content)
    ;
            }



            #endregion

        }
    }
}
