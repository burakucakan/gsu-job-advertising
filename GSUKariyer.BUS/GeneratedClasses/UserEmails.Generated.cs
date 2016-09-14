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

    public partial class UserEmails
    {

        #region ColumnNames
        public struct ColumnNames
        {
            public const string StudentNumber = "StudentNumber";
            public const string Email = "Email";
        }
        #endregion

        #region Create DataTable
        public static DataTable CreateTable()
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("StudentNumber", System.Type.GetType("System.String"));
            dt.Columns.Add("Email", System.Type.GetType("System.String"));

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
                    conn = new SqlConnection(UserEmailsProvider.GetConnectionString());
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
                    throw new MyException(ex.Message, "UserEmails", "Add");
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
                    conn = new SqlConnection(UserEmailsProvider.GetConnectionString());
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
                    throw new MyException(ex.Message, "UserEmails", "Update");
                }
                finally
                {
                    //Connection Close
                    conn.Close();
                    conn.Dispose();
                }
            }

            public static object Add(DataRow dr)
            {
                return UserEmailsProvider.Generated.Add(dr[ColumnNames.StudentNumber].ToString(),
                                                    dr[ColumnNames.Email].ToString());

            }

            public static object Add(SqlTransaction tran, DataRow dr)
            {
                return UserEmailsProvider.Generated.Add(tran,
                                                    dr[ColumnNames.StudentNumber].ToString(),
                                                    dr[ColumnNames.Email].ToString());

            }

            public static int Update(DataRow dr)
            {
                return UserEmailsProvider.Generated.Update(dr[ColumnNames.StudentNumber].ToString(),
                                                    dr[ColumnNames.Email].ToString());
            }

            public static int Update(SqlTransaction tran, DataRow dr)
            {
                return UserEmailsProvider.Generated.Update(tran,
                                                    dr[ColumnNames.StudentNumber].ToString(),
                                                    dr[ColumnNames.Email].ToString());
            }
        }
        #endregion

        public class Generated
        {

            #region Get Functions
            public static DataTable GetByParams(string studentNumber, string email)
            {
                return UserEmailsProvider.Generated.GetByParams(studentNumber, email)
    .Tables[0];
            }

            public static DataTable GetByParams(SqlTransaction tran, string studentNumber, string email)
            {
                return UserEmailsProvider.Generated.GetByParams(tran, studentNumber, email)
    .Tables[0];
            }

            public static DataTable GetByParams(params SqlParameter[] sqlParams)
            {
                return UserEmailsProvider.Generated.GetByParams(sqlParams).Tables[0];
            }

            public static DataTable GetByParams(SqlTransaction tran, params SqlParameter[] sqlParams)
            {
                return UserEmailsProvider.Generated.GetByParams(tran, sqlParams).Tables[0];
            }



            public static DataTable GetAll(SqlTransaction tran)
            {
                return UserEmailsProvider.Generated.GetAll(tran).Tables[0];
            }

            public static DataTable GetAll()
            {
                return UserEmailsProvider.Generated.GetAll().Tables[0];
            }

            public static DataTable Get(SqlTransaction tran, string studentNumber)
            {
                return UserEmailsProvider.Generated.Get(tran, studentNumber)
    .Tables[0];
            }

            public static DataTable Get(string studentNumber)
            {
                return UserEmailsProvider.Generated.Get(studentNumber)
    .Tables[0];
            }



            #endregion

            #region Update Functions
            public static int Update(string studentNumber, string email)
            {
                return UserEmailsProvider.Generated.Update(studentNumber, email)
    ;
            }

            public static int Update(SqlTransaction tran, string studentNumber, string email)
            {
                return UserEmailsProvider.Generated.Update(studentNumber, email)
    ;
            }

            public static int UpdateByParams(string studentNumber, string email)
            {
                return UserEmailsProvider.Generated.UpdateByParams(studentNumber, email)
    ;
            }

            public static int UpdateByParams(params SqlParameter[] sqlParams)
            {
                return UserEmailsProvider.Generated.UpdateByParams(sqlParams);
            }

            public static int UpdateByParams(SqlTransaction tran, string studentNumber, string email)
            {
                return UserEmailsProvider.Generated.UpdateByParams(tran, studentNumber, email)
    ;
            }

            public static int UpdateByParams(SqlTransaction tran, params SqlParameter[] sqlParams)
            {
                return UserEmailsProvider.Generated.UpdateByParams(tran, sqlParams);
            }
            #endregion

            #region Add Functions
            public static object Add(string studentNumber, string email)
            {
                return UserEmailsProvider.Generated.Add(studentNumber, email)
    ;
            }

            public static object Add(SqlTransaction tran, string studentNumber, string email)
            {
                return UserEmailsProvider.Generated.Add(tran, studentNumber, email)
    ;
            }
            #endregion

            #region Delete Functions
            public static int DeleteByParams(string studentNumber, string email)
            {
                return UserEmailsProvider.Generated.DeleteByParams(null, studentNumber, email)
    ;
            }

            public static int DeleteByParams(SqlTransaction tran, string studentNumber, string email)
            {
                return UserEmailsProvider.Generated.DeleteByParams(tran, studentNumber, email)
    ;
            }

            public static int Delete(string studentNumber)
            {
                return UserEmailsProvider.Generated.Delete(studentNumber)
    ;
            }

            public static int Delete(SqlTransaction tran, string studentNumber)
            {
                return UserEmailsProvider.Generated.Delete(tran, studentNumber)
    ;
            }



            #endregion

        }
    }
}
