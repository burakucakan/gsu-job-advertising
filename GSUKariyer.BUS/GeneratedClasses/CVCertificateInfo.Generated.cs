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

    public partial class CVCertificateInfo
    {

        #region ColumnNames
        public struct ColumnNames
        {
            public const string ID = "ID";
            public const string CVId = "CVId";
            public const string CertificateDate = "CertificateDate";
            public const string Category = "Category";
            public const string Name = "Name";
            public const string TakenInstitution = "TakenInstitution";
            public const string Description = "Description";
        }
        #endregion

        #region Create DataTable
        public static DataTable CreateTable()
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("ID", System.Type.GetType("System.Int32"));
            dt.Columns.Add("CVId", System.Type.GetType("System.Int32"));
            dt.Columns.Add("CertificateDate", System.Type.GetType("System.DateTime"));
            dt.Columns.Add("Category", System.Type.GetType("System.Int32"));
            dt.Columns.Add("Name", System.Type.GetType("System.String"));
            dt.Columns.Add("TakenInstitution", System.Type.GetType("System.String"));
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
                    conn = new SqlConnection(CVCertificateInfoProvider.GetConnectionString());
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
                    throw new MyException(ex.Message, "CVCertificateInfo", "Add");
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
                    conn = new SqlConnection(CVCertificateInfoProvider.GetConnectionString());
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
                    throw new MyException(ex.Message, "CVCertificateInfo", "Update");
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
                return CVCertificateInfoProvider.Generated.Add((int)dr[ColumnNames.CVId],
                                                    DBNullHelper.GetNullableValue<DateTime>(dr[ColumnNames.CertificateDate]),
                                                    DBNullHelper.GetNullableValue<int>(dr[ColumnNames.Category]),
                                                    dr[ColumnNames.Name].ToString(),
                                                    dr[ColumnNames.TakenInstitution].ToString(),
                                                    dr[ColumnNames.Description].ToString());

            }

            public static int Add(SqlTransaction tran, DataRow dr)
            {
                return CVCertificateInfoProvider.Generated.Add(tran,
                                                    (int)dr[ColumnNames.CVId],
                                                    DBNullHelper.GetNullableValue<DateTime>(dr[ColumnNames.CertificateDate]),
                                                    DBNullHelper.GetNullableValue<int>(dr[ColumnNames.Category]),
                                                    dr[ColumnNames.Name].ToString(),
                                                    dr[ColumnNames.TakenInstitution].ToString(),
                                                    dr[ColumnNames.Description].ToString());

            }

            public static int Update(DataRow dr)
            {
                return CVCertificateInfoProvider.Generated.Update((int)dr[ColumnNames.ID],
                                                    (int)dr[ColumnNames.CVId],
                                                    DBNullHelper.GetNullableValue<DateTime>(dr[ColumnNames.CertificateDate]),
                                                    DBNullHelper.GetNullableValue<int>(dr[ColumnNames.Category]),
                                                    dr[ColumnNames.Name].ToString(),
                                                    dr[ColumnNames.TakenInstitution].ToString(),
                                                    dr[ColumnNames.Description].ToString());
            }

            public static int Update(SqlTransaction tran, DataRow dr)
            {
                return CVCertificateInfoProvider.Generated.Update(tran,
                                                    (int)dr[ColumnNames.ID],
                                                    (int)dr[ColumnNames.CVId],
                                                    DBNullHelper.GetNullableValue<DateTime>(dr[ColumnNames.CertificateDate]),
                                                    DBNullHelper.GetNullableValue<int>(dr[ColumnNames.Category]),
                                                    dr[ColumnNames.Name].ToString(),
                                                    dr[ColumnNames.TakenInstitution].ToString(),
                                                    dr[ColumnNames.Description].ToString());
            }
        }
        #endregion

        public class Generated
        {

            #region Get Functions
            public static DataTable GetByParams(int? id, int? cVId, DateTime? certificateDate, DateTime? beforeCertificateDate, DateTime? afterOrEqualCertificateDate, int? category, string name, string takenInstitution, string description)
            {
                return CVCertificateInfoProvider.Generated.GetByParams(id, cVId, certificateDate, beforeCertificateDate, afterOrEqualCertificateDate, category, name, takenInstitution, description)
    .Tables[0];
            }

            public static DataTable GetByParams(SqlTransaction tran, int? id, int? cVId, DateTime? certificateDate, DateTime? beforeCertificateDate, DateTime? afterOrEqualCertificateDate, int? category, string name, string takenInstitution, string description)
            {
                return CVCertificateInfoProvider.Generated.GetByParams(tran, id, cVId, certificateDate, beforeCertificateDate, afterOrEqualCertificateDate, category, name, takenInstitution, description)
    .Tables[0];
            }

            public static DataTable GetByParams(params SqlParameter[] sqlParams)
            {
                return CVCertificateInfoProvider.Generated.GetByParams(sqlParams).Tables[0];
            }

            public static DataTable GetByParams(SqlTransaction tran, params SqlParameter[] sqlParams)
            {
                return CVCertificateInfoProvider.Generated.GetByParams(tran, sqlParams).Tables[0];
            }

            public static DataTable GetByFKBasic(int? cVId)
            {
                return CVCertificateInfoProvider.Generated.GetByFKBasic(cVId)
    .Tables[0];
            }

            public static DataTable GetByFKBasic(SqlTransaction tran, int? cVId)
            {
                return CVCertificateInfoProvider.Generated.GetByFKBasic(tran, cVId)
    .Tables[0];
            }


            public static DataTable GetAll(SqlTransaction tran)
            {
                return CVCertificateInfoProvider.Generated.GetAll(tran).Tables[0];
            }

            public static DataTable GetAll()
            {
                return CVCertificateInfoProvider.Generated.GetAll().Tables[0];
            }

            public static DataTable Get(SqlTransaction tran, int id)
            {
                return CVCertificateInfoProvider.Generated.Get(tran, id)
    .Tables[0];
            }

            public static DataTable Get(int id)
            {
                return CVCertificateInfoProvider.Generated.Get(id)
    .Tables[0];
            }

            public static DataTable GetByFK(SqlTransaction tran, int cVId)
            {
                return CVCertificateInfoProvider.Generated.GetByFK(tran, cVId)
    .Tables[0];
            }

            public static DataTable GetByFK(int cVId)
            {
                return CVCertificateInfoProvider.Generated.GetByFK(cVId)
    .Tables[0];
            }


            #endregion

            #region Update Functions
            public static int Update(int id, int cVId, DateTime? certificateDate, int? category, string name, string takenInstitution, string description)
            {
                return CVCertificateInfoProvider.Generated.Update(id, cVId, certificateDate, category, name, takenInstitution, description)
    ;
            }

            public static int Update(SqlTransaction tran, int id, int cVId, DateTime? certificateDate, int? category, string name, string takenInstitution, string description)
            {
                return CVCertificateInfoProvider.Generated.Update(id, cVId, certificateDate, category, name, takenInstitution, description)
    ;
            }

            public static int UpdateByParams(int id, int? cVId, DateTime? certificateDate, int? category, string name, string takenInstitution, string description)
            {
                return CVCertificateInfoProvider.Generated.UpdateByParams(id, cVId, certificateDate, category, name, takenInstitution, description)
    ;
            }

            public static int UpdateByParams(params SqlParameter[] sqlParams)
            {
                return CVCertificateInfoProvider.Generated.UpdateByParams(sqlParams);
            }

            public static int UpdateByParams(SqlTransaction tran, int id, int? cVId, DateTime? certificateDate, int? category, string name, string takenInstitution, string description)
            {
                return CVCertificateInfoProvider.Generated.UpdateByParams(tran, id, cVId, certificateDate, category, name, takenInstitution, description)
    ;
            }

            public static int UpdateByParams(SqlTransaction tran, params SqlParameter[] sqlParams)
            {
                return CVCertificateInfoProvider.Generated.UpdateByParams(tran, sqlParams);
            }
            #endregion

            #region Add Functions
            public static int Add(int cVId, DateTime? certificateDate, int? category, string name, string takenInstitution, string description)
            {
                return CVCertificateInfoProvider.Generated.Add(cVId, certificateDate, category, name, takenInstitution, description)
    ;
            }

            public static int Add(SqlTransaction tran, int cVId, DateTime? certificateDate, int? category, string name, string takenInstitution, string description)
            {
                return CVCertificateInfoProvider.Generated.Add(tran, cVId, certificateDate, category, name, takenInstitution, description)
    ;
            }
            #endregion

            #region Delete Functions
            public static int DeleteByParams(int? id, int? cVId, DateTime? certificateDate, DateTime? beforeCertificateDate, DateTime? afterOrEqualCertificateDate, int? category, string name, string takenInstitution, string description)
            {
                return CVCertificateInfoProvider.Generated.DeleteByParams(null, id, cVId, certificateDate, beforeCertificateDate, afterOrEqualCertificateDate, category, name, takenInstitution, description)
    ;
            }

            public static int DeleteByParams(SqlTransaction tran, int? id, int? cVId, DateTime? certificateDate, DateTime? beforeCertificateDate, DateTime? afterOrEqualCertificateDate, int? category, string name, string takenInstitution, string description)
            {
                return CVCertificateInfoProvider.Generated.DeleteByParams(tran, id, cVId, certificateDate, beforeCertificateDate, afterOrEqualCertificateDate, category, name, takenInstitution, description)
    ;
            }

            public static int Delete(int id)
            {
                return CVCertificateInfoProvider.Generated.Delete(id)
    ;
            }

            public static int Delete(SqlTransaction tran, int id)
            {
                return CVCertificateInfoProvider.Generated.Delete(tran, id)
    ;
            }

            public static int DeleteByFK(int? cVId)
            {
                return CVCertificateInfoProvider.Generated.DeleteByFK(cVId)
    ;
            }

            public static int DeleteByFK(SqlTransaction tran, int? cVId)
            {
                return CVCertificateInfoProvider.Generated.DeleteByFK(cVId)
    ;
            }


            #endregion

        }
    }
}
