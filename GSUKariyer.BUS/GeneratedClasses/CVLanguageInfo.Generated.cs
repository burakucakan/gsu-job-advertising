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

    public partial class CVLanguageInfo
    {

        #region ColumnNames
        public struct ColumnNames
        {
            public const string ID = "ID";
            public const string CVId = "CVId";
            public const string LanguageId = "LanguageId";
            public const string ReadGrade = "ReadGrade";
            public const string WriteGrade = "WriteGrade";
            public const string TalkGrade = "TalkGrade";
            public const string HowLearned = "HowLearned";
        }
        #endregion

        #region Create DataTable
        public static DataTable CreateTable()
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("ID", System.Type.GetType("System.Int32"));
            dt.Columns.Add("CVId", System.Type.GetType("System.Int32"));
            dt.Columns.Add("LanguageId", System.Type.GetType("System.Int32"));
            dt.Columns.Add("ReadGrade", System.Type.GetType("System.Int32"));
            dt.Columns.Add("WriteGrade", System.Type.GetType("System.Int32"));
            dt.Columns.Add("TalkGrade", System.Type.GetType("System.Int32"));
            dt.Columns.Add("HowLearned", System.Type.GetType("System.String"));

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
                    conn = new SqlConnection(CVLanguageInfoProvider.GetConnectionString());
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
                    throw new MyException(ex.Message, "CVLanguageInfo", "Add");
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
                    conn = new SqlConnection(CVLanguageInfoProvider.GetConnectionString());
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
                    throw new MyException(ex.Message, "CVLanguageInfo", "Update");
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
                return CVLanguageInfoProvider.Generated.Add((int)dr[ColumnNames.CVId],
                                                    (int)dr[ColumnNames.LanguageId],
                                                    DBNullHelper.GetNullableValue<int>(dr[ColumnNames.ReadGrade]),
                                                    DBNullHelper.GetNullableValue<int>(dr[ColumnNames.WriteGrade]),
                                                    DBNullHelper.GetNullableValue<int>(dr[ColumnNames.TalkGrade]),
                                                    dr[ColumnNames.HowLearned].ToString());

            }

            public static int Add(SqlTransaction tran, DataRow dr)
            {
                return CVLanguageInfoProvider.Generated.Add(tran,
                                                    (int)dr[ColumnNames.CVId],
                                                    (int)dr[ColumnNames.LanguageId],
                                                    DBNullHelper.GetNullableValue<int>(dr[ColumnNames.ReadGrade]),
                                                    DBNullHelper.GetNullableValue<int>(dr[ColumnNames.WriteGrade]),
                                                    DBNullHelper.GetNullableValue<int>(dr[ColumnNames.TalkGrade]),
                                                    dr[ColumnNames.HowLearned].ToString());

            }

            public static int Update(DataRow dr)
            {
                return CVLanguageInfoProvider.Generated.Update((int)dr[ColumnNames.ID],
                                                    (int)dr[ColumnNames.CVId],
                                                    (int)dr[ColumnNames.LanguageId],
                                                    DBNullHelper.GetNullableValue<int>(dr[ColumnNames.ReadGrade]),
                                                    DBNullHelper.GetNullableValue<int>(dr[ColumnNames.WriteGrade]),
                                                    DBNullHelper.GetNullableValue<int>(dr[ColumnNames.TalkGrade]),
                                                    dr[ColumnNames.HowLearned].ToString());
            }

            public static int Update(SqlTransaction tran, DataRow dr)
            {
                return CVLanguageInfoProvider.Generated.Update(tran,
                                                    (int)dr[ColumnNames.ID],
                                                    (int)dr[ColumnNames.CVId],
                                                    (int)dr[ColumnNames.LanguageId],
                                                    DBNullHelper.GetNullableValue<int>(dr[ColumnNames.ReadGrade]),
                                                    DBNullHelper.GetNullableValue<int>(dr[ColumnNames.WriteGrade]),
                                                    DBNullHelper.GetNullableValue<int>(dr[ColumnNames.TalkGrade]),
                                                    dr[ColumnNames.HowLearned].ToString());
            }
        }
        #endregion

        public class Generated
        {

            #region Get Functions
            public static DataTable GetByParams(int? id, int? cVId, int? languageId, int? readGrade, int? writeGrade, int? talkGrade, string howLearned)
            {
                return CVLanguageInfoProvider.Generated.GetByParams(id, cVId, languageId, readGrade, writeGrade, talkGrade, howLearned)
    .Tables[0];
            }

            public static DataTable GetByParams(SqlTransaction tran, int? id, int? cVId, int? languageId, int? readGrade, int? writeGrade, int? talkGrade, string howLearned)
            {
                return CVLanguageInfoProvider.Generated.GetByParams(tran, id, cVId, languageId, readGrade, writeGrade, talkGrade, howLearned)
    .Tables[0];
            }

            public static DataTable GetByParams(params SqlParameter[] sqlParams)
            {
                return CVLanguageInfoProvider.Generated.GetByParams(sqlParams).Tables[0];
            }

            public static DataTable GetByParams(SqlTransaction tran, params SqlParameter[] sqlParams)
            {
                return CVLanguageInfoProvider.Generated.GetByParams(tran, sqlParams).Tables[0];
            }

            public static DataTable GetByFKBasic(int? cVId)
            {
                return CVLanguageInfoProvider.Generated.GetByFKBasic(cVId)
    .Tables[0];
            }

            public static DataTable GetByFKBasic(SqlTransaction tran, int? cVId)
            {
                return CVLanguageInfoProvider.Generated.GetByFKBasic(tran, cVId)
    .Tables[0];
            }


            public static DataTable GetAll(SqlTransaction tran)
            {
                return CVLanguageInfoProvider.Generated.GetAll(tran).Tables[0];
            }

            public static DataTable GetAll()
            {
                return CVLanguageInfoProvider.Generated.GetAll().Tables[0];
            }

            public static DataTable Get(SqlTransaction tran, int id)
            {
                return CVLanguageInfoProvider.Generated.Get(tran, id)
    .Tables[0];
            }

            public static DataTable Get(int id)
            {
                return CVLanguageInfoProvider.Generated.Get(id)
    .Tables[0];
            }

            public static DataTable GetByFK(SqlTransaction tran, int cVId)
            {
                return CVLanguageInfoProvider.Generated.GetByFK(tran, cVId)
    .Tables[0];
            }

            public static DataTable GetByFK(int cVId)
            {
                return CVLanguageInfoProvider.Generated.GetByFK(cVId)
    .Tables[0];
            }


            #endregion

            #region Update Functions
            public static int Update(int id, int cVId, int languageId, int? readGrade, int? writeGrade, int? talkGrade, string howLearned)
            {
                return CVLanguageInfoProvider.Generated.Update(id, cVId, languageId, readGrade, writeGrade, talkGrade, howLearned)
    ;
            }

            public static int Update(SqlTransaction tran, int id, int cVId, int languageId, int? readGrade, int? writeGrade, int? talkGrade, string howLearned)
            {
                return CVLanguageInfoProvider.Generated.Update(id, cVId, languageId, readGrade, writeGrade, talkGrade, howLearned)
    ;
            }

            public static int UpdateByParams(int id, int? cVId, int? languageId, int? readGrade, int? writeGrade, int? talkGrade, string howLearned)
            {
                return CVLanguageInfoProvider.Generated.UpdateByParams(id, cVId, languageId, readGrade, writeGrade, talkGrade, howLearned)
    ;
            }

            public static int UpdateByParams(params SqlParameter[] sqlParams)
            {
                return CVLanguageInfoProvider.Generated.UpdateByParams(sqlParams);
            }

            public static int UpdateByParams(SqlTransaction tran, int id, int? cVId, int? languageId, int? readGrade, int? writeGrade, int? talkGrade, string howLearned)
            {
                return CVLanguageInfoProvider.Generated.UpdateByParams(tran, id, cVId, languageId, readGrade, writeGrade, talkGrade, howLearned)
    ;
            }

            public static int UpdateByParams(SqlTransaction tran, params SqlParameter[] sqlParams)
            {
                return CVLanguageInfoProvider.Generated.UpdateByParams(tran, sqlParams);
            }
            #endregion

            #region Add Functions
            public static int Add(int cVId, int languageId, int? readGrade, int? writeGrade, int? talkGrade, string howLearned)
            {
                return CVLanguageInfoProvider.Generated.Add(cVId, languageId, readGrade, writeGrade, talkGrade, howLearned)
    ;
            }

            public static int Add(SqlTransaction tran, int cVId, int languageId, int? readGrade, int? writeGrade, int? talkGrade, string howLearned)
            {
                return CVLanguageInfoProvider.Generated.Add(tran, cVId, languageId, readGrade, writeGrade, talkGrade, howLearned)
    ;
            }
            #endregion

            #region Delete Functions
            public static int DeleteByParams(int? id, int? cVId, int? languageId, int? readGrade, int? writeGrade, int? talkGrade, string howLearned)
            {
                return CVLanguageInfoProvider.Generated.DeleteByParams(null, id, cVId, languageId, readGrade, writeGrade, talkGrade, howLearned)
    ;
            }

            public static int DeleteByParams(SqlTransaction tran, int? id, int? cVId, int? languageId, int? readGrade, int? writeGrade, int? talkGrade, string howLearned)
            {
                return CVLanguageInfoProvider.Generated.DeleteByParams(tran, id, cVId, languageId, readGrade, writeGrade, talkGrade, howLearned)
    ;
            }

            public static int Delete(int id)
            {
                return CVLanguageInfoProvider.Generated.Delete(id)
    ;
            }

            public static int Delete(SqlTransaction tran, int id)
            {
                return CVLanguageInfoProvider.Generated.Delete(tran, id)
    ;
            }

            public static int DeleteByFK(int? cVId)
            {
                return CVLanguageInfoProvider.Generated.DeleteByFK(cVId)
    ;
            }

            public static int DeleteByFK(SqlTransaction tran, int? cVId)
            {
                return CVLanguageInfoProvider.Generated.DeleteByFK(cVId)
    ;
            }


            #endregion

        }
    }
}
