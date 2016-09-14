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

    public partial class Firms
    {

        #region ColumnNames
        public struct ColumnNames
        {
            public const string ID = "ID";
            public const string Name = "Name";
            public const string Sector = "Sector";
            public const string WorkerCount = "WorkerCount";
            public const string Address = "Address";
            public const string Zipcode = "Zipcode";
            public const string Country = "Country";
            public const string City = "City";
            public const string Description = "Description";
            public const string Webpage = "Webpage";
            public const string IsActive = "IsActive";
            public const string ActivationDate = "ActivationDate";
            public const string ModifyDate = "ModifyDate";
            public const string CreateDate = "CreateDate";
            public const string IsDeleted = "IsDeleted";
        }
        #endregion

        #region Create DataTable
        public static DataTable CreateTable()
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("ID", System.Type.GetType("System.Int32"));
            dt.Columns.Add("Name", System.Type.GetType("System.String"));
            dt.Columns.Add("Sector", System.Type.GetType("System.String"));
            dt.Columns.Add("WorkerCount", System.Type.GetType("System.Int32"));
            dt.Columns.Add("Address", System.Type.GetType("System.String"));
            dt.Columns.Add("Zipcode", System.Type.GetType("System.String"));
            dt.Columns.Add("Country", System.Type.GetType("System.Int32"));
            dt.Columns.Add("City", System.Type.GetType("System.Int32"));
            dt.Columns.Add("Description", System.Type.GetType("System.String"));
            dt.Columns.Add("Webpage", System.Type.GetType("System.String"));
            dt.Columns.Add("IsActive", System.Type.GetType("System.Boolean"));
            dt.Columns.Add("ActivationDate", System.Type.GetType("System.DateTime"));
            dt.Columns.Add("ModifyDate", System.Type.GetType("System.DateTime"));
            dt.Columns.Add("CreateDate", System.Type.GetType("System.DateTime"));
            dt.Columns.Add("IsDeleted", System.Type.GetType("System.Boolean"));

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
                    conn = new SqlConnection(FirmsProvider.GetConnectionString());
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
                    throw new MyException(ex.Message, "Firms", "Add");
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
                    conn = new SqlConnection(FirmsProvider.GetConnectionString());
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
                    throw new MyException(ex.Message, "Firms", "Update");
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
                return FirmsProvider.Generated.Add(dr[ColumnNames.Name].ToString(),
                                                    dr[ColumnNames.Sector].ToString(),
                                                    (int)dr[ColumnNames.WorkerCount],
                                                    dr[ColumnNames.Address].ToString(),
                                                    dr[ColumnNames.Zipcode].ToString(),
                                                    DBNullHelper.GetNullableValue<int>(dr[ColumnNames.Country]),
                                                    DBNullHelper.GetNullableValue<int>(dr[ColumnNames.City]),
                                                    dr[ColumnNames.Description].ToString(),
                                                    dr[ColumnNames.Webpage].ToString(),
                                                    (bool)dr[ColumnNames.IsActive],
                                                    DBNullHelper.GetNullableValue<DateTime>(dr[ColumnNames.ActivationDate]),
                                                    (DateTime)dr[ColumnNames.ModifyDate],
                                                    (DateTime)dr[ColumnNames.CreateDate],
                                                    (bool)dr[ColumnNames.IsDeleted]);

            }

            public static int Add(SqlTransaction tran, DataRow dr)
            {
                return FirmsProvider.Generated.Add(tran,
                                                    dr[ColumnNames.Name].ToString(),
                                                    dr[ColumnNames.Sector].ToString(),
                                                    (int)dr[ColumnNames.WorkerCount],
                                                    dr[ColumnNames.Address].ToString(),
                                                    dr[ColumnNames.Zipcode].ToString(),
                                                    DBNullHelper.GetNullableValue<int>(dr[ColumnNames.Country]),
                                                    DBNullHelper.GetNullableValue<int>(dr[ColumnNames.City]),
                                                    dr[ColumnNames.Description].ToString(),
                                                    dr[ColumnNames.Webpage].ToString(),
                                                    (bool)dr[ColumnNames.IsActive],
                                                    DBNullHelper.GetNullableValue<DateTime>(dr[ColumnNames.ActivationDate]),
                                                    (DateTime)dr[ColumnNames.ModifyDate],
                                                    (DateTime)dr[ColumnNames.CreateDate],
                                                    (bool)dr[ColumnNames.IsDeleted]);

            }

            public static int Update(DataRow dr)
            {
                return FirmsProvider.Generated.Update((int)dr[ColumnNames.ID],
                                                    dr[ColumnNames.Name].ToString(),
                                                    dr[ColumnNames.Sector].ToString(),
                                                    (int)dr[ColumnNames.WorkerCount],
                                                    dr[ColumnNames.Address].ToString(),
                                                    dr[ColumnNames.Zipcode].ToString(),
                                                    DBNullHelper.GetNullableValue<int>(dr[ColumnNames.Country]),
                                                    DBNullHelper.GetNullableValue<int>(dr[ColumnNames.City]),
                                                    dr[ColumnNames.Description].ToString(),
                                                    dr[ColumnNames.Webpage].ToString(),
                                                    (bool)dr[ColumnNames.IsActive],
                                                    DBNullHelper.GetNullableValue<DateTime>(dr[ColumnNames.ActivationDate]),
                                                    (DateTime)dr[ColumnNames.ModifyDate],
                                                    (bool)dr[ColumnNames.IsDeleted]);
            }

            public static int Update(SqlTransaction tran, DataRow dr)
            {
                return FirmsProvider.Generated.Update(tran,
                                                    (int)dr[ColumnNames.ID],
                                                    dr[ColumnNames.Name].ToString(),
                                                    dr[ColumnNames.Sector].ToString(),
                                                    (int)dr[ColumnNames.WorkerCount],
                                                    dr[ColumnNames.Address].ToString(),
                                                    dr[ColumnNames.Zipcode].ToString(),
                                                    DBNullHelper.GetNullableValue<int>(dr[ColumnNames.Country]),
                                                    DBNullHelper.GetNullableValue<int>(dr[ColumnNames.City]),
                                                    dr[ColumnNames.Description].ToString(),
                                                    dr[ColumnNames.Webpage].ToString(),
                                                    (bool)dr[ColumnNames.IsActive],
                                                    DBNullHelper.GetNullableValue<DateTime>(dr[ColumnNames.ActivationDate]),
                                                    (DateTime)dr[ColumnNames.ModifyDate],
                                                    (bool)dr[ColumnNames.IsDeleted]);
            }
        }
        #endregion

        public class Generated
        {

            #region Get Functions
            public static DataTable GetByParams(int? id, string name, string sector, int? workerCount, string address, string zipcode, int? country, int? city, string description, string webpage, bool? isActive, DateTime? activationDate, DateTime? beforeActivationDate, DateTime? afterOrEqualActivationDate, DateTime? modifyDate, DateTime? beforeModifyDate, DateTime? afterOrEqualModifyDate, DateTime? createDate, DateTime? beforeCreateDate, DateTime? afterOrEqualCreateDate, bool? isDeleted)
            {
                return FirmsProvider.Generated.GetByParams(id, name, sector, workerCount, address, zipcode, country, city, description, webpage, isActive, activationDate, beforeActivationDate, afterOrEqualActivationDate, modifyDate, beforeModifyDate, afterOrEqualModifyDate, createDate, beforeCreateDate, afterOrEqualCreateDate, isDeleted)
    .Tables[0];
            }

            public static DataTable GetByParams(SqlTransaction tran, int? id, string name, string sector, int? workerCount, string address, string zipcode, int? country, int? city, string description, string webpage, bool? isActive, DateTime? activationDate, DateTime? beforeActivationDate, DateTime? afterOrEqualActivationDate, DateTime? modifyDate, DateTime? beforeModifyDate, DateTime? afterOrEqualModifyDate, DateTime? createDate, DateTime? beforeCreateDate, DateTime? afterOrEqualCreateDate, bool? isDeleted)
            {
                return FirmsProvider.Generated.GetByParams(tran, id, name, sector, workerCount, address, zipcode, country, city, description, webpage, isActive, activationDate, beforeActivationDate, afterOrEqualActivationDate, modifyDate, beforeModifyDate, afterOrEqualModifyDate, createDate, beforeCreateDate, afterOrEqualCreateDate, isDeleted)
    .Tables[0];
            }

            public static DataTable GetByParams(params SqlParameter[] sqlParams)
            {
                return FirmsProvider.Generated.GetByParams(sqlParams).Tables[0];
            }

            public static DataTable GetByParams(SqlTransaction tran, params SqlParameter[] sqlParams)
            {
                return FirmsProvider.Generated.GetByParams(tran, sqlParams).Tables[0];
            }



            public static DataTable GetAll(SqlTransaction tran)
            {
                return FirmsProvider.Generated.GetAll(tran).Tables[0];
            }

            public static DataTable GetAll()
            {
                return FirmsProvider.Generated.GetAll().Tables[0];
            }

            public static DataTable Get(SqlTransaction tran, int id)
            {
                return FirmsProvider.Generated.Get(tran, id)
    .Tables[0];
            }

            public static DataTable Get(int id)
            {
                return FirmsProvider.Generated.Get(id)
    .Tables[0];
            }



            #endregion

            #region Update Functions
            public static int Update(int id, string name, string sector, int workerCount, string address, string zipcode, int? country, int? city, string description, string webpage, bool isActive, DateTime? activationDate, DateTime modifyDate, bool isDeleted)
            {
                return FirmsProvider.Generated.Update(id, name, sector, workerCount, address, zipcode, country, city, description, webpage, isActive, activationDate, modifyDate, isDeleted)
    ;
            }

            public static int Update(SqlTransaction tran, int id, string name, string sector, int workerCount, string address, string zipcode, int? country, int? city, string description, string webpage, bool isActive, DateTime? activationDate, DateTime modifyDate, bool isDeleted)
            {
                return FirmsProvider.Generated.Update(id, name, sector, workerCount, address, zipcode, country, city, description, webpage, isActive, activationDate, modifyDate, isDeleted)
    ;
            }

            public static int UpdateByParams(int id, string name, string sector, int? workerCount, string address, string zipcode, int? country, int? city, string description, string webpage, bool? isActive, DateTime? activationDate, DateTime? modifyDate, DateTime? createDate, bool? isDeleted)
            {
                return FirmsProvider.Generated.UpdateByParams(id, name, sector, workerCount, address, zipcode, country, city, description, webpage, isActive, activationDate, modifyDate, createDate, isDeleted)
    ;
            }

            public static int UpdateByParams(params SqlParameter[] sqlParams)
            {
                return FirmsProvider.Generated.UpdateByParams(sqlParams);
            }

            public static int UpdateByParams(SqlTransaction tran, int id, string name, string sector, int? workerCount, string address, string zipcode, int? country, int? city, string description, string webpage, bool? isActive, DateTime? activationDate, DateTime? modifyDate, DateTime? createDate, bool? isDeleted)
            {
                return FirmsProvider.Generated.UpdateByParams(tran, id, name, sector, workerCount, address, zipcode, country, city, description, webpage, isActive, activationDate, modifyDate, createDate, isDeleted)
    ;
            }

            public static int UpdateByParams(SqlTransaction tran, params SqlParameter[] sqlParams)
            {
                return FirmsProvider.Generated.UpdateByParams(tran, sqlParams);
            }
            #endregion

            #region Add Functions
            public static int Add(string name, string sector, int workerCount, string address, string zipcode, int? country, int? city, string description, string webpage, bool isActive, DateTime? activationDate, DateTime modifyDate, DateTime createDate, bool isDeleted)
            {
                return FirmsProvider.Generated.Add(name, sector, workerCount, address, zipcode, country, city, description, webpage, isActive, activationDate, modifyDate, createDate, isDeleted)
    ;
            }

            public static int Add(SqlTransaction tran, string name, string sector, int workerCount, string address, string zipcode, int? country, int? city, string description, string webpage, bool isActive, DateTime? activationDate, DateTime modifyDate, DateTime createDate, bool isDeleted)
            {
                return FirmsProvider.Generated.Add(tran, name, sector, workerCount, address, zipcode, country, city, description, webpage, isActive, activationDate, modifyDate, createDate, isDeleted)
    ;
            }
            #endregion

            #region Delete Functions
            public static int DeleteByParams(int? id, string name, string sector, int? workerCount, string address, string zipcode, int? country, int? city, string description, string webpage, bool? isActive, DateTime? activationDate, DateTime? beforeActivationDate, DateTime? afterOrEqualActivationDate, DateTime? modifyDate, DateTime? beforeModifyDate, DateTime? afterOrEqualModifyDate, DateTime? createDate, DateTime? beforeCreateDate, DateTime? afterOrEqualCreateDate, bool? isDeleted)
            {
                return FirmsProvider.Generated.DeleteByParams(null, id, name, sector, workerCount, address, zipcode, country, city, description, webpage, isActive, activationDate, beforeActivationDate, afterOrEqualActivationDate, modifyDate, beforeModifyDate, afterOrEqualModifyDate, createDate, beforeCreateDate, afterOrEqualCreateDate, isDeleted)
    ;
            }

            public static int DeleteByParams(SqlTransaction tran, int? id, string name, string sector, int? workerCount, string address, string zipcode, int? country, int? city, string description, string webpage, bool? isActive, DateTime? activationDate, DateTime? beforeActivationDate, DateTime? afterOrEqualActivationDate, DateTime? modifyDate, DateTime? beforeModifyDate, DateTime? afterOrEqualModifyDate, DateTime? createDate, DateTime? beforeCreateDate, DateTime? afterOrEqualCreateDate, bool? isDeleted)
            {
                return FirmsProvider.Generated.DeleteByParams(tran, id, name, sector, workerCount, address, zipcode, country, city, description, webpage, isActive, activationDate, beforeActivationDate, afterOrEqualActivationDate, modifyDate, beforeModifyDate, afterOrEqualModifyDate, createDate, beforeCreateDate, afterOrEqualCreateDate, isDeleted)
    ;
            }

            public static int Delete(int id)
            {
                return FirmsProvider.Generated.Delete(id)
    ;
            }

            public static int Delete(SqlTransaction tran, int id)
            {
                return FirmsProvider.Generated.Delete(tran, id)
    ;
            }



            #endregion

        }
    }
}
