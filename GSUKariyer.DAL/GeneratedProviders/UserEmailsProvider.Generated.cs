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

    public partial class UserEmailsProvider : BaseDataLayer
    {

        public class Generated
        {

            #region Get Functions
            protected static DataSet GetBasic(SqlTransaction tran, string studentNumber)
            {
                SqlParameter[] sqlParams = null;

                try
                {
                    DataSet ds = null;

                    sqlParams = new SqlParameter[] { 
					new SqlParameter("@StudentNumber",studentNumber)
                };

                    if (tran == null)
                        ds = ExecuteDataset("BGA_GetUserEmails", sqlParams);
                    else
                        ds = ExecuteDataset(tran, "BGA_GetUserEmails", sqlParams);

                    return ds;
                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "UserEmailsProvider", "Get", ArrangeParamValues(sqlParams));
                }
            }

            public static DataSet GetByParams(string studentNumber, string email)
            {
                return GetByParams(null, studentNumber, email)
    ;
            }

            public static DataSet GetByParams(SqlTransaction tran, string studentNumber, string email)
            {
                SqlParameter[] sqlParams = null;

                try
                {
                    DataSet ds = null;

                    sqlParams = new SqlParameter[] { 
					new SqlParameter("@StudentNumber",studentNumber),
					new SqlParameter("@Email",email)
                };

                    if (tran == null)
                        ds = ExecuteDataset("BGA_GetUserEmailsByParams", sqlParams);
                    else
                        ds = ExecuteDataset(tran, "BGA_GetUserEmailsByParams", sqlParams);

                    return ds;
                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "UserEmailsProvider", "GetByParams", ArrangeParamValues(sqlParams));
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

                    ds = ExecuteDataset("BGA_GetUserEmailsByParams", sqlParams);

                    return ds;
                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "UserEmailsProvider", "GetByParams", ArrangeParamValues(sqlParams));
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

            public static DataSet Get(SqlTransaction tran, string studentNumber)
            {
                return GetBasic(tran, studentNumber);
            }

            public static DataSet Get(string studentNumber)
            {
                return GetBasic(null, studentNumber);
            }



            #endregion

            #region Update Functions
            public static int Update(string studentNumber, string email)
            {
                SqlParameter[] sqlParams = null;

                try
                {
                    sqlParams = new SqlParameter[] { 
					new SqlParameter("@StudentNumber",studentNumber),
					new SqlParameter("@Email",email)
                };

                    return ExecuteNonQuery("BGA_UpdateUserEmails", sqlParams);

                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "UserEmailsProvider", "Update", ArrangeParamValues(sqlParams));
                }
            }

            public static int Update(SqlTransaction tran, string studentNumber, string email)
            {
                SqlParameter[] sqlParams = null;

                try
                {
                    sqlParams = new SqlParameter[] { 
					new SqlParameter("@StudentNumber",studentNumber),
					new SqlParameter("@Email",email)
                };

                    return ExecuteNonQuery(tran, "BGA_UpdateUserEmails", sqlParams);

                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "UserEmailsProvider", "Update", ArrangeParamValues(sqlParams));
                }
            }

            public static int UpdateByParams(string studentNumber, string email)
            {
                SqlParameter[] sqlParams = null;

                try
                {
                    sqlParams = new SqlParameter[] { 
					new SqlParameter("@StudentNumber",studentNumber),
					new SqlParameter("@Email",email)
                };

                    return ExecuteNonQuery("BGA_UpdateUserEmailsByParams", sqlParams);

                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "UserEmailsProvider", "UpdateByParams", ArrangeParamValues(sqlParams));
                }
            }

            public static int UpdateByParams(params SqlParameter[] sqlParams)
            {
                try
                {

                    return ExecuteNonQuery("BGA_UpdateUserEmailsByParams", sqlParams);

                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "UserEmailsProvider", "UpdateByParams", ArrangeParamValues(sqlParams));
                }
            }

            public static int UpdateByParams(SqlTransaction tran, string studentNumber, string email)
            {
                SqlParameter[] sqlParams = null;

                try
                {
                    sqlParams = new SqlParameter[] { 
					new SqlParameter("@StudentNumber",studentNumber),
					new SqlParameter("@Email",email)
                };

                    return ExecuteNonQuery(tran, "BGA_UpdateUserEmailsByParams", sqlParams);

                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "UserEmailsProvider", "UpdateByParams", ArrangeParamValues(sqlParams));
                }
            }

            public static int UpdateByParams(SqlTransaction tran, params SqlParameter[] sqlParams)
            {
                try
                {

                    return ExecuteNonQuery(tran, "BGA_UpdateUserEmailsByParams", sqlParams);

                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "UserEmailsProvider", "UpdateByParams", ArrangeParamValues(sqlParams));
                }
            }
            #endregion

            #region Add Functions
            public static object Add(string studentNumber, string email)
            {
                SqlParameter[] sqlParams = null;

                try
                {
                    sqlParams = new SqlParameter[] { 
					new SqlParameter("@StudentNumber",studentNumber),
					new SqlParameter("@Email",email)
                };


                    return ExecuteScalarObj("BGA_AddUserEmails", sqlParams);

                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "UserEmailsProvider", "Add", ArrangeParamValues(sqlParams));
                }
            }

            public static object Add(SqlTransaction tran, string studentNumber, string email)
            {
                SqlParameter[] sqlParams = null;

                try
                {
                    sqlParams = new SqlParameter[] { 
					new SqlParameter("@StudentNumber",studentNumber),
					new SqlParameter("@Email",email)
                };


                    return ExecuteScalarObj(tran, "BGA_AddUserEmails", sqlParams);

                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "UserEmailsProvider", "Add", ArrangeParamValues(sqlParams));
                }
            }
            #endregion

            #region Delete Functions
            public static int Delete(string studentNumber)
            {
                SqlParameter[] sqlParams = null;

                try
                {

                    sqlParams = new SqlParameter[] { 
					new SqlParameter("@StudentNumber",studentNumber)
                };

                    return ExecuteNonQuery("BGA_DeleteUserEmails", sqlParams);

                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "UserEmailsProvider", "Delete", ArrangeParamValues(sqlParams));
                }
            }

            public static int Delete(SqlTransaction tran, string studentNumber)
            {
                SqlParameter[] sqlParams = null;

                try
                {

                    sqlParams = new SqlParameter[] { 
					new SqlParameter("@StudentNumber",studentNumber)
                };

                    return ExecuteNonQuery(tran, "BGA_DeleteUserEmails", sqlParams);

                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "UserEmailsProvider", "Delete", ArrangeParamValues(sqlParams));
                }
            }

            public static int DeleteByParams(SqlTransaction tran, string studentNumber, string email)
            {
                SqlParameter[] sqlParams = null;

                try
                {
                    sqlParams = new SqlParameter[] { 
					new SqlParameter("@StudentNumber",studentNumber),
					new SqlParameter("@Email",email)
                };

                    if (tran == null)
                        return ExecuteNonQuery("BGA_DeleteUserEmailsByParams", sqlParams);
                    else
                        return ExecuteNonQuery(tran, "BGA_DeleteUserEmailsByParams", sqlParams);


                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "UserEmailsProvider", "DeleteByParams", ArrangeParamValues(sqlParams));
                }
            }

            public static int DeleteByParams(string studentNumber, string email)
            {
                return DeleteByParams(null, studentNumber, email)
    ;
            }



            #endregion

        }
    }
}
