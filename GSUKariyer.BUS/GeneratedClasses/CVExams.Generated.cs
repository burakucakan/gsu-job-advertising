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

    public partial class CVExams
    {

        #region ColumnNames
        public struct ColumnNames
        {
            public const string ID = "ID";
            public const string CVId = "CVId";
            public const string ExamName = "ExamName";
            public const string ExamCorporation = "ExamCorporation";
            public const string StartYear = "StartYear";
            public const string ExamScore = "ExamScore";
            public const string Description = "Description";
        }
        #endregion

        #region Create DataTable
        public static DataTable CreateTable()
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("ID", System.Type.GetType("System.Int32"));
            dt.Columns.Add("CVId", System.Type.GetType("System.Int32"));
            dt.Columns.Add("ExamName", System.Type.GetType("System.String"));
            dt.Columns.Add("ExamCorporation", System.Type.GetType("System.String"));
            dt.Columns.Add("StartYear", System.Type.GetType("System.Int32"));
            dt.Columns.Add("ExamScore", System.Type.GetType("System.Int32"));
            dt.Columns.Add("Description", System.Type.GetType("System.String"));

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
                    conn = new SqlConnection(CVExamsProvider.GetConnectionString());
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
                    throw new MyException(ex.Message, "CVExams", "Add");
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
                    conn = new SqlConnection(CVExamsProvider.GetConnectionString());
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
                    throw new MyException(ex.Message, "CVExams", "Update");
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
                return CVExamsProvider.Generated.Add((int)dr[ColumnNames.CVId],
                                                    dr[ColumnNames.ExamName].ToString(),
                                                    dr[ColumnNames.ExamCorporation].ToString(),
                                                    (int)dr[ColumnNames.StartYear],
                                                    (int)dr[ColumnNames.ExamScore],
                                                    dr[ColumnNames.Description].ToString());

            }

            public static int Add(SqlTransaction tran, DataRow dr)
            {
                return CVExamsProvider.Generated.Add(tran,
                                                    (int)dr[ColumnNames.CVId],
                                                    dr[ColumnNames.ExamName].ToString(),
                                                    dr[ColumnNames.ExamCorporation].ToString(),
                                                    (int)dr[ColumnNames.StartYear],
                                                    (int)dr[ColumnNames.ExamScore],
                                                    dr[ColumnNames.Description].ToString());

            }

            public static int Update(DataRow dr)
            {
                return CVExamsProvider.Generated.Update((int)dr[ColumnNames.ID],
                                                    (int)dr[ColumnNames.CVId],
                                                    dr[ColumnNames.ExamName].ToString(),
                                                    dr[ColumnNames.ExamCorporation].ToString(),
                                                    (int)dr[ColumnNames.StartYear],
                                                    (int)dr[ColumnNames.ExamScore],
                                                    dr[ColumnNames.Description].ToString());
            }

            public static int Update(SqlTransaction tran, DataRow dr)
            {
                return CVExamsProvider.Generated.Update(tran,
                                                    (int)dr[ColumnNames.ID],
                                                    (int)dr[ColumnNames.CVId],
                                                    dr[ColumnNames.ExamName].ToString(),
                                                    dr[ColumnNames.ExamCorporation].ToString(),
                                                    (int)dr[ColumnNames.StartYear],
                                                    (int)dr[ColumnNames.ExamScore],
                                                    dr[ColumnNames.Description].ToString());
            }
        }
        #endregion

        public class Generated
        {

            #region Get Functions
            public static DataTable GetByParams(int? id, int? cVId, string examName, string examCorporation, int? startYear, int? examScore, string description)
            {
                return CVExamsProvider.Generated.GetByParams(id, cVId, examName, examCorporation, startYear, examScore, description)
    .Tables[0];
            }

            public static DataTable GetByParams(SqlTransaction tran, int? id, int? cVId, string examName, string examCorporation, int? startYear, int? examScore, string description)
            {
                return CVExamsProvider.Generated.GetByParams(tran, id, cVId, examName, examCorporation, startYear, examScore, description)
    .Tables[0];
            }

            public static DataTable GetByParams(params SqlParameter[] sqlParams)
            {
                return CVExamsProvider.Generated.GetByParams(sqlParams).Tables[0];
            }

            public static DataTable GetByParams(SqlTransaction tran, params SqlParameter[] sqlParams)
            {
                return CVExamsProvider.Generated.GetByParams(tran, sqlParams).Tables[0];
            }

            public static DataTable GetByFKBasic(int? cVId)
            {
                return CVExamsProvider.Generated.GetByFKBasic(cVId)
    .Tables[0];
            }

            public static DataTable GetByFKBasic(SqlTransaction tran, int? cVId)
            {
                return CVExamsProvider.Generated.GetByFKBasic(tran, cVId)
    .Tables[0];
            }


            public static DataTable GetAll(SqlTransaction tran)
            {
                return CVExamsProvider.Generated.GetAll(tran).Tables[0];
            }

            public static DataTable GetAll()
            {
                return CVExamsProvider.Generated.GetAll().Tables[0];
            }

            public static DataTable Get(SqlTransaction tran, int id)
            {
                return CVExamsProvider.Generated.Get(tran, id)
    .Tables[0];
            }

            public static DataTable Get(int id)
            {
                return CVExamsProvider.Generated.Get(id)
    .Tables[0];
            }

            public static DataTable GetByFK(SqlTransaction tran, int cVId)
            {
                return CVExamsProvider.Generated.GetByFK(tran, cVId)
    .Tables[0];
            }

            public static DataTable GetByFK(int cVId)
            {
                return CVExamsProvider.Generated.GetByFK(cVId)
    .Tables[0];
            }


            #endregion

            #region Update Functions
            public static int Update(int id, int cVId, string examName, string examCorporation, int startYear, int examScore, string description)
            {
                return CVExamsProvider.Generated.Update(id, cVId, examName, examCorporation, startYear, examScore, description)
    ;
            }

            public static int Update(SqlTransaction tran, int id, int cVId, string examName, string examCorporation, int startYear, int examScore, string description)
            {
                return CVExamsProvider.Generated.Update(id, cVId, examName, examCorporation, startYear, examScore, description)
    ;
            }

            public static int UpdateByParams(int id, int? cVId, string examName, string examCorporation, int? startYear, int? examScore, string description)
            {
                return CVExamsProvider.Generated.UpdateByParams(id, cVId, examName, examCorporation, startYear, examScore, description)
    ;
            }

            public static int UpdateByParams(params SqlParameter[] sqlParams)
            {
                return CVExamsProvider.Generated.UpdateByParams(sqlParams);
            }

            public static int UpdateByParams(SqlTransaction tran, int id, int? cVId, string examName, string examCorporation, int? startYear, int? examScore, string description)
            {
                return CVExamsProvider.Generated.UpdateByParams(tran, id, cVId, examName, examCorporation, startYear, examScore, description)
    ;
            }

            public static int UpdateByParams(SqlTransaction tran, params SqlParameter[] sqlParams)
            {
                return CVExamsProvider.Generated.UpdateByParams(tran, sqlParams);
            }
            #endregion

            #region Add Functions
            public static int Add(int cVId, string examName, string examCorporation, int startYear, int examScore, string description)
            {
                return CVExamsProvider.Generated.Add(cVId, examName, examCorporation, startYear, examScore, description)
    ;
            }

            public static int Add(SqlTransaction tran, int cVId, string examName, string examCorporation, int startYear, int examScore, string description)
            {
                return CVExamsProvider.Generated.Add(tran, cVId, examName, examCorporation, startYear, examScore, description)
    ;
            }
            #endregion

            #region Delete Functions
            public static int DeleteByParams(int? id, int? cVId, string examName, string examCorporation, int? startYear, int? examScore, string description)
            {
                return CVExamsProvider.Generated.DeleteByParams(null, id, cVId, examName, examCorporation, startYear, examScore, description)
    ;
            }

            public static int DeleteByParams(SqlTransaction tran, int? id, int? cVId, string examName, string examCorporation, int? startYear, int? examScore, string description)
            {
                return CVExamsProvider.Generated.DeleteByParams(tran, id, cVId, examName, examCorporation, startYear, examScore, description)
    ;
            }

            public static int Delete(int id)
            {
                return CVExamsProvider.Generated.Delete(id)
    ;
            }

            public static int Delete(SqlTransaction tran, int id)
            {
                return CVExamsProvider.Generated.Delete(tran, id)
    ;
            }

            public static int DeleteByFK(int? cVId)
            {
                return CVExamsProvider.Generated.DeleteByFK(cVId)
    ;
            }

            public static int DeleteByFK(SqlTransaction tran, int? cVId)
            {
                return CVExamsProvider.Generated.DeleteByFK(cVId)
    ;
            }


            #endregion

        }
    }
}
