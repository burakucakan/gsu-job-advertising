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

    public partial class SurveyItems
    {

        #region ColumnNames
        public struct ColumnNames
        {
            public const string ID = "ID";
            public const string SurveyId = "SurveyId";
            public const string Description = "Description";
            public const string Order = "Order";
            public const string ModifyDate = "ModifyDate";
            public const string CreateDate = "CreateDate";
            public const string VoteCount = "VoteCount";
        }
        #endregion

        #region Create DataTable
        public static DataTable CreateTable()
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("ID", System.Type.GetType("System.Int32"));
            dt.Columns.Add("SurveyId", System.Type.GetType("System.Int32"));
            dt.Columns.Add("Description", System.Type.GetType("System.String"));
            dt.Columns.Add("Order", System.Type.GetType("System.Int32"));
            dt.Columns.Add("ModifyDate", System.Type.GetType("System.DateTime"));
            dt.Columns.Add("CreateDate", System.Type.GetType("System.DateTime"));
            dt.Columns.Add("VoteCount", System.Type.GetType("System.Int32"));

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
                    conn = new SqlConnection(SurveyItemsProvider.GetConnectionString());
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
                    throw new MyException(ex.Message, "SurveyItems", "Add");
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
                    conn = new SqlConnection(SurveyItemsProvider.GetConnectionString());
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
                    throw new MyException(ex.Message, "SurveyItems", "Update");
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
                return SurveyItemsProvider.Generated.Add((int)dr[ColumnNames.SurveyId],
                                                    dr[ColumnNames.Description].ToString(),
                                                    (int)dr[ColumnNames.Order],
                                                    (DateTime)dr[ColumnNames.ModifyDate],
                                                    (DateTime)dr[ColumnNames.CreateDate],
                                                    (int)dr[ColumnNames.VoteCount]);

            }

            public static int Add(SqlTransaction tran, DataRow dr)
            {
                return SurveyItemsProvider.Generated.Add(tran,
                                                    (int)dr[ColumnNames.SurveyId],
                                                    dr[ColumnNames.Description].ToString(),
                                                    (int)dr[ColumnNames.Order],
                                                    (DateTime)dr[ColumnNames.ModifyDate],
                                                    (DateTime)dr[ColumnNames.CreateDate],
                                                    (int)dr[ColumnNames.VoteCount]);

            }

            public static int Update(DataRow dr)
            {
                return SurveyItemsProvider.Generated.Update((int)dr[ColumnNames.ID],
                                                    (int)dr[ColumnNames.SurveyId],
                                                    dr[ColumnNames.Description].ToString(),
                                                    (int)dr[ColumnNames.Order],
                                                    (DateTime)dr[ColumnNames.ModifyDate],
                                                    (int)dr[ColumnNames.VoteCount]);
            }

            public static int Update(SqlTransaction tran, DataRow dr)
            {
                return SurveyItemsProvider.Generated.Update(tran,
                                                    (int)dr[ColumnNames.ID],
                                                    (int)dr[ColumnNames.SurveyId],
                                                    dr[ColumnNames.Description].ToString(),
                                                    (int)dr[ColumnNames.Order],
                                                    (DateTime)dr[ColumnNames.ModifyDate],
                                                    (int)dr[ColumnNames.VoteCount]);
            }
        }
        #endregion

        public class Generated
        {

            #region Get Functions
            public static DataTable GetByParams(int? id, int? surveyId, string description, int? order, DateTime? modifyDate, DateTime? beforeModifyDate, DateTime? afterOrEqualModifyDate, DateTime? createDate, DateTime? beforeCreateDate, DateTime? afterOrEqualCreateDate, int? voteCount)
            {
                return SurveyItemsProvider.Generated.GetByParams(id, surveyId, description, order, modifyDate, beforeModifyDate, afterOrEqualModifyDate, createDate, beforeCreateDate, afterOrEqualCreateDate, voteCount)
    .Tables[0];
            }

            public static DataTable GetByParams(SqlTransaction tran, int? id, int? surveyId, string description, int? order, DateTime? modifyDate, DateTime? beforeModifyDate, DateTime? afterOrEqualModifyDate, DateTime? createDate, DateTime? beforeCreateDate, DateTime? afterOrEqualCreateDate, int? voteCount)
            {
                return SurveyItemsProvider.Generated.GetByParams(tran, id, surveyId, description, order, modifyDate, beforeModifyDate, afterOrEqualModifyDate, createDate, beforeCreateDate, afterOrEqualCreateDate, voteCount)
    .Tables[0];
            }

            public static DataTable GetByParams(params SqlParameter[] sqlParams)
            {
                return SurveyItemsProvider.Generated.GetByParams(sqlParams).Tables[0];
            }

            public static DataTable GetByParams(SqlTransaction tran, params SqlParameter[] sqlParams)
            {
                return SurveyItemsProvider.Generated.GetByParams(tran, sqlParams).Tables[0];
            }

            public static DataTable GetByFKBasic(int? surveyId)
            {
                return SurveyItemsProvider.Generated.GetByFKBasic(surveyId)
    .Tables[0];
            }

            public static DataTable GetByFKBasic(SqlTransaction tran, int? surveyId)
            {
                return SurveyItemsProvider.Generated.GetByFKBasic(tran, surveyId)
    .Tables[0];
            }


            public static DataTable GetAll(SqlTransaction tran)
            {
                return SurveyItemsProvider.Generated.GetAll(tran).Tables[0];
            }

            public static DataTable GetAll()
            {
                return SurveyItemsProvider.Generated.GetAll().Tables[0];
            }

            public static DataTable Get(SqlTransaction tran, int id)
            {
                return SurveyItemsProvider.Generated.Get(tran, id)
    .Tables[0];
            }

            public static DataTable Get(int id)
            {
                return SurveyItemsProvider.Generated.Get(id)
    .Tables[0];
            }

            public static DataTable GetByFK(SqlTransaction tran, int surveyId)
            {
                return SurveyItemsProvider.Generated.GetByFK(tran, surveyId)
    .Tables[0];
            }

            public static DataTable GetByFK(int surveyId)
            {
                return SurveyItemsProvider.Generated.GetByFK(surveyId)
    .Tables[0];
            }


            #endregion

            #region Update Functions
            public static int Update(int id, int surveyId, string description, int order, DateTime modifyDate, int voteCount)
            {
                return SurveyItemsProvider.Generated.Update(id, surveyId, description, order, modifyDate, voteCount)
    ;
            }

            public static int Update(SqlTransaction tran, int id, int surveyId, string description, int order, DateTime modifyDate, int voteCount)
            {
                return SurveyItemsProvider.Generated.Update(id, surveyId, description, order, modifyDate, voteCount)
    ;
            }

            public static int UpdateByParams(int id, int? surveyId, string description, int? order, DateTime? modifyDate, DateTime? createDate, int? voteCount)
            {
                return SurveyItemsProvider.Generated.UpdateByParams(id, surveyId, description, order, modifyDate, createDate, voteCount)
    ;
            }

            public static int UpdateByParams(params SqlParameter[] sqlParams)
            {
                return SurveyItemsProvider.Generated.UpdateByParams(sqlParams);
            }

            public static int UpdateByParams(SqlTransaction tran, int id, int? surveyId, string description, int? order, DateTime? modifyDate, DateTime? createDate, int? voteCount)
            {
                return SurveyItemsProvider.Generated.UpdateByParams(tran, id, surveyId, description, order, modifyDate, createDate, voteCount)
    ;
            }

            public static int UpdateByParams(SqlTransaction tran, params SqlParameter[] sqlParams)
            {
                return SurveyItemsProvider.Generated.UpdateByParams(tran, sqlParams);
            }
            #endregion

            #region Add Functions
            public static int Add(int surveyId, string description, int order, DateTime modifyDate, DateTime createDate, int voteCount)
            {
                return SurveyItemsProvider.Generated.Add(surveyId, description, order, modifyDate, createDate, voteCount)
    ;
            }

            public static int Add(SqlTransaction tran, int surveyId, string description, int order, DateTime modifyDate, DateTime createDate, int voteCount)
            {
                return SurveyItemsProvider.Generated.Add(tran, surveyId, description, order, modifyDate, createDate, voteCount)
    ;
            }
            #endregion

            #region Delete Functions
            public static int DeleteByParams(int? id, int? surveyId, string description, int? order, DateTime? modifyDate, DateTime? beforeModifyDate, DateTime? afterOrEqualModifyDate, DateTime? createDate, DateTime? beforeCreateDate, DateTime? afterOrEqualCreateDate, int? voteCount)
            {
                return SurveyItemsProvider.Generated.DeleteByParams(null, id, surveyId, description, order, modifyDate, beforeModifyDate, afterOrEqualModifyDate, createDate, beforeCreateDate, afterOrEqualCreateDate, voteCount)
    ;
            }

            public static int DeleteByParams(SqlTransaction tran, int? id, int? surveyId, string description, int? order, DateTime? modifyDate, DateTime? beforeModifyDate, DateTime? afterOrEqualModifyDate, DateTime? createDate, DateTime? beforeCreateDate, DateTime? afterOrEqualCreateDate, int? voteCount)
            {
                return SurveyItemsProvider.Generated.DeleteByParams(tran, id, surveyId, description, order, modifyDate, beforeModifyDate, afterOrEqualModifyDate, createDate, beforeCreateDate, afterOrEqualCreateDate, voteCount)
    ;
            }

            public static int Delete(int id)
            {
                return SurveyItemsProvider.Generated.Delete(id)
    ;
            }

            public static int Delete(SqlTransaction tran, int id)
            {
                return SurveyItemsProvider.Generated.Delete(tran, id)
    ;
            }

            public static int DeleteByFK(int? surveyId)
            {
                return SurveyItemsProvider.Generated.DeleteByFK(surveyId)
    ;
            }

            public static int DeleteByFK(SqlTransaction tran, int? surveyId)
            {
                return SurveyItemsProvider.Generated.DeleteByFK(surveyId)
    ;
            }


            #endregion

        }
    }
}
