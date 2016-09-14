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

    public partial class Surveys
    {

        #region ColumnNames
        public struct ColumnNames
        {
            public const string ID = "ID";
            public const string Name = "Name";
            public const string Description = "Description";
            public const string Question = "Question";
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
            dt.Columns.Add("Name", System.Type.GetType("System.String"));
            dt.Columns.Add("Description", System.Type.GetType("System.String"));
            dt.Columns.Add("Question", System.Type.GetType("System.String"));
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
                    conn = new SqlConnection(SurveysProvider.GetConnectionString());
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
                    throw new MyException(ex.Message, "Surveys", "Add");
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
                    conn = new SqlConnection(SurveysProvider.GetConnectionString());
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
                    throw new MyException(ex.Message, "Surveys", "Update");
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
                return SurveysProvider.Generated.Add(dr[ColumnNames.Name].ToString(),
                                                    dr[ColumnNames.Description].ToString(),
                                                    dr[ColumnNames.Question].ToString(),
                                                    (int)dr[ColumnNames.State],
                                                    (DateTime)dr[ColumnNames.ModifyDate],
                                                    (DateTime)dr[ColumnNames.CreateDate]);

            }

            public static int Add(SqlTransaction tran, DataRow dr)
            {
                return SurveysProvider.Generated.Add(tran,
                                                    dr[ColumnNames.Name].ToString(),
                                                    dr[ColumnNames.Description].ToString(),
                                                    dr[ColumnNames.Question].ToString(),
                                                    (int)dr[ColumnNames.State],
                                                    (DateTime)dr[ColumnNames.ModifyDate],
                                                    (DateTime)dr[ColumnNames.CreateDate]);

            }

            public static int Update(DataRow dr)
            {
                return SurveysProvider.Generated.Update((int)dr[ColumnNames.ID],
                                                    dr[ColumnNames.Name].ToString(),
                                                    dr[ColumnNames.Description].ToString(),
                                                    dr[ColumnNames.Question].ToString(),
                                                    (int)dr[ColumnNames.State],
                                                    (DateTime)dr[ColumnNames.ModifyDate]);
            }

            public static int Update(SqlTransaction tran, DataRow dr)
            {
                return SurveysProvider.Generated.Update(tran,
                                                    (int)dr[ColumnNames.ID],
                                                    dr[ColumnNames.Name].ToString(),
                                                    dr[ColumnNames.Description].ToString(),
                                                    dr[ColumnNames.Question].ToString(),
                                                    (int)dr[ColumnNames.State],
                                                    (DateTime)dr[ColumnNames.ModifyDate]);
            }
        }
        #endregion

        public class Generated
        {

            #region Get Functions
            public static DataTable GetByParams(int? id, string name, string description, string question, int? state, DateTime? modifyDate, DateTime? beforeModifyDate, DateTime? afterOrEqualModifyDate, DateTime? createDate, DateTime? beforeCreateDate, DateTime? afterOrEqualCreateDate)
            {
                return SurveysProvider.Generated.GetByParams(id, name, description, question, state, modifyDate, beforeModifyDate, afterOrEqualModifyDate, createDate, beforeCreateDate, afterOrEqualCreateDate)
    .Tables[0];
            }

            public static DataTable GetByParams(SqlTransaction tran, int? id, string name, string description, string question, int? state, DateTime? modifyDate, DateTime? beforeModifyDate, DateTime? afterOrEqualModifyDate, DateTime? createDate, DateTime? beforeCreateDate, DateTime? afterOrEqualCreateDate)
            {
                return SurveysProvider.Generated.GetByParams(tran, id, name, description, question, state, modifyDate, beforeModifyDate, afterOrEqualModifyDate, createDate, beforeCreateDate, afterOrEqualCreateDate)
    .Tables[0];
            }

            public static DataTable GetByParams(params SqlParameter[] sqlParams)
            {
                return SurveysProvider.Generated.GetByParams(sqlParams).Tables[0];
            }

            public static DataTable GetByParams(SqlTransaction tran, params SqlParameter[] sqlParams)
            {
                return SurveysProvider.Generated.GetByParams(tran, sqlParams).Tables[0];
            }



            public static DataTable GetAll(SqlTransaction tran)
            {
                return SurveysProvider.Generated.GetAll(tran).Tables[0];
            }

            public static DataTable GetAll()
            {
                return SurveysProvider.Generated.GetAll().Tables[0];
            }

            public static DataTable Get(SqlTransaction tran, int id)
            {
                return SurveysProvider.Generated.Get(tran, id)
    .Tables[0];
            }

            public static DataTable Get(int id)
            {
                return SurveysProvider.Generated.Get(id)
    .Tables[0];
            }



            #endregion

            #region Update Functions
            public static int Update(int id, string name, string description, string question, int state, DateTime modifyDate)
            {
                return SurveysProvider.Generated.Update(id, name, description, question, state, modifyDate)
    ;
            }

            public static int Update(SqlTransaction tran, int id, string name, string description, string question, int state, DateTime modifyDate)
            {
                return SurveysProvider.Generated.Update(id, name, description, question, state, modifyDate)
    ;
            }

            public static int UpdateByParams(int id, string name, string description, string question, int? state, DateTime? modifyDate, DateTime? createDate)
            {
                return SurveysProvider.Generated.UpdateByParams(id, name, description, question, state, modifyDate, createDate)
    ;
            }

            public static int UpdateByParams(params SqlParameter[] sqlParams)
            {
                return SurveysProvider.Generated.UpdateByParams(sqlParams);
            }

            public static int UpdateByParams(SqlTransaction tran, int id, string name, string description, string question, int? state, DateTime? modifyDate, DateTime? createDate)
            {
                return SurveysProvider.Generated.UpdateByParams(tran, id, name, description, question, state, modifyDate, createDate)
    ;
            }

            public static int UpdateByParams(SqlTransaction tran, params SqlParameter[] sqlParams)
            {
                return SurveysProvider.Generated.UpdateByParams(tran, sqlParams);
            }
            #endregion

            #region Add Functions
            public static int Add(string name, string description, string question, int state, DateTime modifyDate, DateTime createDate)
            {
                return SurveysProvider.Generated.Add(name, description, question, state, modifyDate, createDate)
    ;
            }

            public static int Add(SqlTransaction tran, string name, string description, string question, int state, DateTime modifyDate, DateTime createDate)
            {
                return SurveysProvider.Generated.Add(tran, name, description, question, state, modifyDate, createDate)
    ;
            }
            #endregion

            #region Delete Functions
            public static int DeleteByParams(int? id, string name, string description, string question, int? state, DateTime? modifyDate, DateTime? beforeModifyDate, DateTime? afterOrEqualModifyDate, DateTime? createDate, DateTime? beforeCreateDate, DateTime? afterOrEqualCreateDate)
            {
                return SurveysProvider.Generated.DeleteByParams(null, id, name, description, question, state, modifyDate, beforeModifyDate, afterOrEqualModifyDate, createDate, beforeCreateDate, afterOrEqualCreateDate)
    ;
            }

            public static int DeleteByParams(SqlTransaction tran, int? id, string name, string description, string question, int? state, DateTime? modifyDate, DateTime? beforeModifyDate, DateTime? afterOrEqualModifyDate, DateTime? createDate, DateTime? beforeCreateDate, DateTime? afterOrEqualCreateDate)
            {
                return SurveysProvider.Generated.DeleteByParams(tran, id, name, description, question, state, modifyDate, beforeModifyDate, afterOrEqualModifyDate, createDate, beforeCreateDate, afterOrEqualCreateDate)
    ;
            }

            public static int Delete(int id)
            {
                return SurveysProvider.Generated.Delete(id)
    ;
            }

            public static int Delete(SqlTransaction tran, int id)
            {
                return SurveysProvider.Generated.Delete(tran, id)
    ;
            }



            #endregion

        }
    }
}
