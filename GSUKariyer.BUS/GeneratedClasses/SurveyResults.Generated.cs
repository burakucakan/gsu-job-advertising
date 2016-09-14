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

    public partial class SurveyResults
    {

        #region ColumnNames
        public struct ColumnNames
        {
            public const string ID = "ID";
            public const string SurveyItemId = "SurveyItemId";
            public const string UserID = "UserID";
            public const string CreateDate = "CreateDate";
        }
        #endregion

        #region Create DataTable
        public static DataTable CreateTable()
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("ID", System.Type.GetType("System.Int32"));
            dt.Columns.Add("SurveyItemId", System.Type.GetType("System.Int32"));
            dt.Columns.Add("UserID", System.Type.GetType("System.Int32"));
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
                    conn = new SqlConnection(SurveyResultsProvider.GetConnectionString());
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
                    throw new MyException(ex.Message, "SurveyResults", "Add");
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
                    conn = new SqlConnection(SurveyResultsProvider.GetConnectionString());
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
                    throw new MyException(ex.Message, "SurveyResults", "Update");
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
                return SurveyResultsProvider.Generated.Add((int)dr[ColumnNames.SurveyItemId],
                                                    (int)dr[ColumnNames.UserID],
                                                    (DateTime)dr[ColumnNames.CreateDate]);

            }

            public static int Add(SqlTransaction tran, DataRow dr)
            {
                return SurveyResultsProvider.Generated.Add(tran,
                                                    (int)dr[ColumnNames.SurveyItemId],
                                                    (int)dr[ColumnNames.UserID],
                                                    (DateTime)dr[ColumnNames.CreateDate]);

            }

            public static int Update(DataRow dr)
            {
                return SurveyResultsProvider.Generated.Update((int)dr[ColumnNames.ID],
                                                    (int)dr[ColumnNames.SurveyItemId],
                                                    (int)dr[ColumnNames.UserID]);
            }

            public static int Update(SqlTransaction tran, DataRow dr)
            {
                return SurveyResultsProvider.Generated.Update(tran,
                                                    (int)dr[ColumnNames.ID],
                                                    (int)dr[ColumnNames.SurveyItemId],
                                                    (int)dr[ColumnNames.UserID]);
            }
        }
        #endregion

        public class Generated
        {

            #region Get Functions
            public static DataTable GetByParams(int? id, int? surveyItemId, int? userID, DateTime? createDate, DateTime? beforeCreateDate, DateTime? afterOrEqualCreateDate)
            {
                return SurveyResultsProvider.Generated.GetByParams(id, surveyItemId, userID, createDate, beforeCreateDate, afterOrEqualCreateDate)
    .Tables[0];
            }

            public static DataTable GetByParams(SqlTransaction tran, int? id, int? surveyItemId, int? userID, DateTime? createDate, DateTime? beforeCreateDate, DateTime? afterOrEqualCreateDate)
            {
                return SurveyResultsProvider.Generated.GetByParams(tran, id, surveyItemId, userID, createDate, beforeCreateDate, afterOrEqualCreateDate)
    .Tables[0];
            }

            public static DataTable GetByParams(params SqlParameter[] sqlParams)
            {
                return SurveyResultsProvider.Generated.GetByParams(sqlParams).Tables[0];
            }

            public static DataTable GetByParams(SqlTransaction tran, params SqlParameter[] sqlParams)
            {
                return SurveyResultsProvider.Generated.GetByParams(tran, sqlParams).Tables[0];
            }



            public static DataTable GetAll(SqlTransaction tran)
            {
                return SurveyResultsProvider.Generated.GetAll(tran).Tables[0];
            }

            public static DataTable GetAll()
            {
                return SurveyResultsProvider.Generated.GetAll().Tables[0];
            }

            public static DataTable Get(SqlTransaction tran, int id)
            {
                return SurveyResultsProvider.Generated.Get(tran, id)
    .Tables[0];
            }

            public static DataTable Get(int id)
            {
                return SurveyResultsProvider.Generated.Get(id)
    .Tables[0];
            }



            #endregion

            #region Update Functions
            public static int Update(int id, int surveyItemId, int userID)
            {
                return SurveyResultsProvider.Generated.Update(id, surveyItemId, userID)
    ;
            }

            public static int Update(SqlTransaction tran, int id, int surveyItemId, int userID)
            {
                return SurveyResultsProvider.Generated.Update(id, surveyItemId, userID)
    ;
            }

            public static int UpdateByParams(int id, int? surveyItemId, int? userID, DateTime? createDate)
            {
                return SurveyResultsProvider.Generated.UpdateByParams(id, surveyItemId, userID, createDate)
    ;
            }

            public static int UpdateByParams(params SqlParameter[] sqlParams)
            {
                return SurveyResultsProvider.Generated.UpdateByParams(sqlParams);
            }

            public static int UpdateByParams(SqlTransaction tran, int id, int? surveyItemId, int? userID, DateTime? createDate)
            {
                return SurveyResultsProvider.Generated.UpdateByParams(tran, id, surveyItemId, userID, createDate)
    ;
            }

            public static int UpdateByParams(SqlTransaction tran, params SqlParameter[] sqlParams)
            {
                return SurveyResultsProvider.Generated.UpdateByParams(tran, sqlParams);
            }
            #endregion

            #region Add Functions
            public static int Add(int surveyItemId, int userID, DateTime createDate)
            {
                return SurveyResultsProvider.Generated.Add(surveyItemId, userID, createDate)
    ;
            }

            public static int Add(SqlTransaction tran, int surveyItemId, int userID, DateTime createDate)
            {
                return SurveyResultsProvider.Generated.Add(tran, surveyItemId, userID, createDate)
    ;
            }
            #endregion

            #region Delete Functions
            public static int DeleteByParams(int? id, int? surveyItemId, int? userID, DateTime? createDate, DateTime? beforeCreateDate, DateTime? afterOrEqualCreateDate)
            {
                return SurveyResultsProvider.Generated.DeleteByParams(null, id, surveyItemId, userID, createDate, beforeCreateDate, afterOrEqualCreateDate)
    ;
            }

            public static int DeleteByParams(SqlTransaction tran, int? id, int? surveyItemId, int? userID, DateTime? createDate, DateTime? beforeCreateDate, DateTime? afterOrEqualCreateDate)
            {
                return SurveyResultsProvider.Generated.DeleteByParams(tran, id, surveyItemId, userID, createDate, beforeCreateDate, afterOrEqualCreateDate)
    ;
            }

            public static int Delete(int id)
            {
                return SurveyResultsProvider.Generated.Delete(id)
    ;
            }

            public static int Delete(SqlTransaction tran, int id)
            {
                return SurveyResultsProvider.Generated.Delete(tran, id)
    ;
            }



            #endregion

        }
    }
}
