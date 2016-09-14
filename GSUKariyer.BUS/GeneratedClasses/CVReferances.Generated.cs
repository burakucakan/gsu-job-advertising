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

    public partial class CVReferances
    {

        #region ColumnNames
        public struct ColumnNames
        {
            public const string ID = "ID";
            public const string CVId = "CVId";
            public const string Name = "Name";
            public const string Surname = "Surname";
            public const string Email = "Email";
            public const string Phone = "Phone";
            public const string WorkingFirm = "WorkingFirm";
            public const string FirmSector = "FirmSector";
            public const string WorkingPosition = "WorkingPosition";
        }
        #endregion

        #region Create DataTable
        public static DataTable CreateTable()
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("ID", System.Type.GetType("System.Int32"));
            dt.Columns.Add("CVId", System.Type.GetType("System.Int32"));
            dt.Columns.Add("Name", System.Type.GetType("System.String"));
            dt.Columns.Add("Surname", System.Type.GetType("System.String"));
            dt.Columns.Add("Email", System.Type.GetType("System.String"));
            dt.Columns.Add("Phone", System.Type.GetType("System.String"));
            dt.Columns.Add("WorkingFirm", System.Type.GetType("System.String"));
            dt.Columns.Add("FirmSector", System.Type.GetType("System.String"));
            dt.Columns.Add("WorkingPosition", System.Type.GetType("System.String"));

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
                    conn = new SqlConnection(CVReferancesProvider.GetConnectionString());
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
                    throw new MyException(ex.Message, "CVReferances", "Add");
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
                    conn = new SqlConnection(CVReferancesProvider.GetConnectionString());
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
                    throw new MyException(ex.Message, "CVReferances", "Update");
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
                return CVReferancesProvider.Generated.Add((int)dr[ColumnNames.CVId],
                                                    dr[ColumnNames.Name].ToString(),
                                                    dr[ColumnNames.Surname].ToString(),
                                                    dr[ColumnNames.Email].ToString(),
                                                    dr[ColumnNames.Phone].ToString(),
                                                    dr[ColumnNames.WorkingFirm].ToString(),
                                                    dr[ColumnNames.FirmSector].ToString(),
                                                    dr[ColumnNames.WorkingPosition].ToString());

            }

            public static int Add(SqlTransaction tran, DataRow dr)
            {
                return CVReferancesProvider.Generated.Add(tran,
                                                    (int)dr[ColumnNames.CVId],
                                                    dr[ColumnNames.Name].ToString(),
                                                    dr[ColumnNames.Surname].ToString(),
                                                    dr[ColumnNames.Email].ToString(),
                                                    dr[ColumnNames.Phone].ToString(),
                                                    dr[ColumnNames.WorkingFirm].ToString(),
                                                    dr[ColumnNames.FirmSector].ToString(),
                                                    dr[ColumnNames.WorkingPosition].ToString());

            }

            public static int Update(DataRow dr)
            {
                return CVReferancesProvider.Generated.Update((int)dr[ColumnNames.ID],
                                                    (int)dr[ColumnNames.CVId],
                                                    dr[ColumnNames.Name].ToString(),
                                                    dr[ColumnNames.Surname].ToString(),
                                                    dr[ColumnNames.Email].ToString(),
                                                    dr[ColumnNames.Phone].ToString(),
                                                    dr[ColumnNames.WorkingFirm].ToString(),
                                                    dr[ColumnNames.FirmSector].ToString(),
                                                    dr[ColumnNames.WorkingPosition].ToString());
            }

            public static int Update(SqlTransaction tran, DataRow dr)
            {
                return CVReferancesProvider.Generated.Update(tran,
                                                    (int)dr[ColumnNames.ID],
                                                    (int)dr[ColumnNames.CVId],
                                                    dr[ColumnNames.Name].ToString(),
                                                    dr[ColumnNames.Surname].ToString(),
                                                    dr[ColumnNames.Email].ToString(),
                                                    dr[ColumnNames.Phone].ToString(),
                                                    dr[ColumnNames.WorkingFirm].ToString(),
                                                    dr[ColumnNames.FirmSector].ToString(),
                                                    dr[ColumnNames.WorkingPosition].ToString());
            }
        }
        #endregion

        public class Generated
        {

            #region Get Functions
            public static DataTable GetByParams(int? id, int? cVId, string name, string surname, string email, string phone, string workingFirm, string firmSector, string workingPosition)
            {
                return CVReferancesProvider.Generated.GetByParams(id, cVId, name, surname, email, phone, workingFirm, firmSector, workingPosition)
    .Tables[0];
            }

            public static DataTable GetByParams(SqlTransaction tran, int? id, int? cVId, string name, string surname, string email, string phone, string workingFirm, string firmSector, string workingPosition)
            {
                return CVReferancesProvider.Generated.GetByParams(tran, id, cVId, name, surname, email, phone, workingFirm, firmSector, workingPosition)
    .Tables[0];
            }

            public static DataTable GetByParams(params SqlParameter[] sqlParams)
            {
                return CVReferancesProvider.Generated.GetByParams(sqlParams).Tables[0];
            }

            public static DataTable GetByParams(SqlTransaction tran, params SqlParameter[] sqlParams)
            {
                return CVReferancesProvider.Generated.GetByParams(tran, sqlParams).Tables[0];
            }

            public static DataTable GetByFKBasic(int? cVId)
            {
                return CVReferancesProvider.Generated.GetByFKBasic(cVId)
    .Tables[0];
            }

            public static DataTable GetByFKBasic(SqlTransaction tran, int? cVId)
            {
                return CVReferancesProvider.Generated.GetByFKBasic(tran, cVId)
    .Tables[0];
            }


            public static DataTable GetAll(SqlTransaction tran)
            {
                return CVReferancesProvider.Generated.GetAll(tran).Tables[0];
            }

            public static DataTable GetAll()
            {
                return CVReferancesProvider.Generated.GetAll().Tables[0];
            }

            public static DataTable Get(SqlTransaction tran, int id)
            {
                return CVReferancesProvider.Generated.Get(tran, id)
    .Tables[0];
            }

            public static DataTable Get(int id)
            {
                return CVReferancesProvider.Generated.Get(id)
    .Tables[0];
            }

            public static DataTable GetByFK(SqlTransaction tran, int cVId)
            {
                return CVReferancesProvider.Generated.GetByFK(tran, cVId)
    .Tables[0];
            }

            public static DataTable GetByFK(int cVId)
            {
                return CVReferancesProvider.Generated.GetByFK(cVId)
    .Tables[0];
            }


            #endregion

            #region Update Functions
            public static int Update(int id, int cVId, string name, string surname, string email, string phone, string workingFirm, string firmSector, string workingPosition)
            {
                return CVReferancesProvider.Generated.Update(id, cVId, name, surname, email, phone, workingFirm, firmSector, workingPosition)
    ;
            }

            public static int Update(SqlTransaction tran, int id, int cVId, string name, string surname, string email, string phone, string workingFirm, string firmSector, string workingPosition)
            {
                return CVReferancesProvider.Generated.Update(id, cVId, name, surname, email, phone, workingFirm, firmSector, workingPosition)
    ;
            }

            public static int UpdateByParams(int id, int? cVId, string name, string surname, string email, string phone, string workingFirm, string firmSector, string workingPosition)
            {
                return CVReferancesProvider.Generated.UpdateByParams(id, cVId, name, surname, email, phone, workingFirm, firmSector, workingPosition)
    ;
            }

            public static int UpdateByParams(params SqlParameter[] sqlParams)
            {
                return CVReferancesProvider.Generated.UpdateByParams(sqlParams);
            }

            public static int UpdateByParams(SqlTransaction tran, int id, int? cVId, string name, string surname, string email, string phone, string workingFirm, string firmSector, string workingPosition)
            {
                return CVReferancesProvider.Generated.UpdateByParams(tran, id, cVId, name, surname, email, phone, workingFirm, firmSector, workingPosition)
    ;
            }

            public static int UpdateByParams(SqlTransaction tran, params SqlParameter[] sqlParams)
            {
                return CVReferancesProvider.Generated.UpdateByParams(tran, sqlParams);
            }
            #endregion

            #region Add Functions
            public static int Add(int cVId, string name, string surname, string email, string phone, string workingFirm, string firmSector, string workingPosition)
            {
                return CVReferancesProvider.Generated.Add(cVId, name, surname, email, phone, workingFirm, firmSector, workingPosition)
    ;
            }

            public static int Add(SqlTransaction tran, int cVId, string name, string surname, string email, string phone, string workingFirm, string firmSector, string workingPosition)
            {
                return CVReferancesProvider.Generated.Add(tran, cVId, name, surname, email, phone, workingFirm, firmSector, workingPosition)
    ;
            }
            #endregion

            #region Delete Functions
            public static int DeleteByParams(int? id, int? cVId, string name, string surname, string email, string phone, string workingFirm, string firmSector, string workingPosition)
            {
                return CVReferancesProvider.Generated.DeleteByParams(null, id, cVId, name, surname, email, phone, workingFirm, firmSector, workingPosition)
    ;
            }

            public static int DeleteByParams(SqlTransaction tran, int? id, int? cVId, string name, string surname, string email, string phone, string workingFirm, string firmSector, string workingPosition)
            {
                return CVReferancesProvider.Generated.DeleteByParams(tran, id, cVId, name, surname, email, phone, workingFirm, firmSector, workingPosition)
    ;
            }

            public static int Delete(int id)
            {
                return CVReferancesProvider.Generated.Delete(id)
    ;
            }

            public static int Delete(SqlTransaction tran, int id)
            {
                return CVReferancesProvider.Generated.Delete(tran, id)
    ;
            }

            public static int DeleteByFK(int? cVId)
            {
                return CVReferancesProvider.Generated.DeleteByFK(cVId)
    ;
            }

            public static int DeleteByFK(SqlTransaction tran, int? cVId)
            {
                return CVReferancesProvider.Generated.DeleteByFK(cVId)
    ;
            }


            #endregion

        }
    }
}
