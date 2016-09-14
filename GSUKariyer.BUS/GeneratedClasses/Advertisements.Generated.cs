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

    public partial class Advertisements
    {

        #region ColumnNames
        public struct ColumnNames
        {
            public const string ID = "ID";
            public const string FirmId = "FirmId";
            public const string Title = "Title";
            public const string Detail = "Detail";
            public const string Description = "Description";
            public const string StartDate = "StartDate";
            public const string EndDate = "EndDate";
            public const string WorkPosition = "WorkPosition";
            public const string Type = "Type";
            public const string City = "City";
            public const string Country = "Country";
            public const string EmployeesCount = "EmployeesCount";
            public const string State = "State";
            public const string ModifyDate = "ModifyDate";
            public const string ModifyBy = "ModifyBy";
            public const string CreateDate = "CreateDate";
            public const string CreateBy = "CreateBy";
            public const string IsDeleted = "IsDeleted";
        }
        #endregion

        #region Create DataTable
        public static DataTable CreateTable()
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("ID", System.Type.GetType("System.Int32"));
            dt.Columns.Add("FirmId", System.Type.GetType("System.Int32"));
            dt.Columns.Add("Title", System.Type.GetType("System.String"));
            dt.Columns.Add("Detail", System.Type.GetType("System.String"));
            dt.Columns.Add("Description", System.Type.GetType("System.String"));
            dt.Columns.Add("StartDate", System.Type.GetType("System.DateTime"));
            dt.Columns.Add("EndDate", System.Type.GetType("System.DateTime"));
            dt.Columns.Add("WorkPosition", System.Type.GetType("System.String"));
            dt.Columns.Add("Type", System.Type.GetType("System.Int32"));
            dt.Columns.Add("City", System.Type.GetType("System.String"));
            dt.Columns.Add("Country", System.Type.GetType("System.String"));
            dt.Columns.Add("EmployeesCount", System.Type.GetType("System.Int32"));
            dt.Columns.Add("State", System.Type.GetType("System.Int32"));
            dt.Columns.Add("ModifyDate", System.Type.GetType("System.DateTime"));
            dt.Columns.Add("ModifyBy", System.Type.GetType("System.Int32"));
            dt.Columns.Add("CreateDate", System.Type.GetType("System.DateTime"));
            dt.Columns.Add("CreateBy", System.Type.GetType("System.Int32"));
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
                    conn = new SqlConnection(AdvertisementsProvider.GetConnectionString());
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
                    throw new MyException(ex.Message, "Advertisements", "Add");
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
                    conn = new SqlConnection(AdvertisementsProvider.GetConnectionString());
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
                    throw new MyException(ex.Message, "Advertisements", "Update");
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
                return AdvertisementsProvider.Generated.Add((int)dr[ColumnNames.FirmId],
                                                    dr[ColumnNames.Title].ToString(),
                                                    dr[ColumnNames.Detail].ToString(),
                                                    dr[ColumnNames.Description].ToString(),
                                                    DBNullHelper.GetNullableValue<DateTime>(dr[ColumnNames.StartDate]),
                                                    DBNullHelper.GetNullableValue<DateTime>(dr[ColumnNames.EndDate]),
                                                    dr[ColumnNames.WorkPosition].ToString(),
                                                    DBNullHelper.GetNullableValue<int>(dr[ColumnNames.Type]),
                                                    dr[ColumnNames.City].ToString(),
                                                    dr[ColumnNames.Country].ToString(),
                                                    DBNullHelper.GetNullableValue<int>(dr[ColumnNames.EmployeesCount]),
                                                    DBNullHelper.GetNullableValue<int>(dr[ColumnNames.State]),
                                                    (DateTime)dr[ColumnNames.ModifyDate],
                                                    (int)dr[ColumnNames.ModifyBy],
                                                    (DateTime)dr[ColumnNames.CreateDate],
                                                    (int)dr[ColumnNames.CreateBy],
                                                    (bool)dr[ColumnNames.IsDeleted]);

            }

            public static int Add(SqlTransaction tran, DataRow dr)
            {
                return AdvertisementsProvider.Generated.Add(tran,
                                                    (int)dr[ColumnNames.FirmId],
                                                    dr[ColumnNames.Title].ToString(),
                                                    dr[ColumnNames.Detail].ToString(),
                                                    dr[ColumnNames.Description].ToString(),
                                                    DBNullHelper.GetNullableValue<DateTime>(dr[ColumnNames.StartDate]),
                                                    DBNullHelper.GetNullableValue<DateTime>(dr[ColumnNames.EndDate]),
                                                    dr[ColumnNames.WorkPosition].ToString(),
                                                    DBNullHelper.GetNullableValue<int>(dr[ColumnNames.Type]),
                                                    dr[ColumnNames.City].ToString(),
                                                    dr[ColumnNames.Country].ToString(),
                                                    DBNullHelper.GetNullableValue<int>(dr[ColumnNames.EmployeesCount]),
                                                    DBNullHelper.GetNullableValue<int>(dr[ColumnNames.State]),
                                                    (DateTime)dr[ColumnNames.ModifyDate],
                                                    (int)dr[ColumnNames.ModifyBy],
                                                    (DateTime)dr[ColumnNames.CreateDate],
                                                    (int)dr[ColumnNames.CreateBy],
                                                    (bool)dr[ColumnNames.IsDeleted]);

            }

            public static int Update(DataRow dr)
            {
                return AdvertisementsProvider.Generated.Update((int)dr[ColumnNames.ID],
                                                    (int)dr[ColumnNames.FirmId],
                                                    dr[ColumnNames.Title].ToString(),
                                                    dr[ColumnNames.Detail].ToString(),
                                                    dr[ColumnNames.Description].ToString(),
                                                    DBNullHelper.GetNullableValue<DateTime>(dr[ColumnNames.StartDate]),
                                                    DBNullHelper.GetNullableValue<DateTime>(dr[ColumnNames.EndDate]),
                                                    dr[ColumnNames.WorkPosition].ToString(),
                                                    DBNullHelper.GetNullableValue<int>(dr[ColumnNames.Type]),
                                                    dr[ColumnNames.City].ToString(),
                                                    dr[ColumnNames.Country].ToString(),
                                                    DBNullHelper.GetNullableValue<int>(dr[ColumnNames.EmployeesCount]),
                                                    DBNullHelper.GetNullableValue<int>(dr[ColumnNames.State]),
                                                    (DateTime)dr[ColumnNames.ModifyDate],
                                                    (int)dr[ColumnNames.ModifyBy],
                                                    (bool)dr[ColumnNames.IsDeleted]);
            }

            public static int Update(SqlTransaction tran, DataRow dr)
            {
                return AdvertisementsProvider.Generated.Update(tran,
                                                    (int)dr[ColumnNames.ID],
                                                    (int)dr[ColumnNames.FirmId],
                                                    dr[ColumnNames.Title].ToString(),
                                                    dr[ColumnNames.Detail].ToString(),
                                                    dr[ColumnNames.Description].ToString(),
                                                    DBNullHelper.GetNullableValue<DateTime>(dr[ColumnNames.StartDate]),
                                                    DBNullHelper.GetNullableValue<DateTime>(dr[ColumnNames.EndDate]),
                                                    dr[ColumnNames.WorkPosition].ToString(),
                                                    DBNullHelper.GetNullableValue<int>(dr[ColumnNames.Type]),
                                                    dr[ColumnNames.City].ToString(),
                                                    dr[ColumnNames.Country].ToString(),
                                                    DBNullHelper.GetNullableValue<int>(dr[ColumnNames.EmployeesCount]),
                                                    DBNullHelper.GetNullableValue<int>(dr[ColumnNames.State]),
                                                    (DateTime)dr[ColumnNames.ModifyDate],
                                                    (int)dr[ColumnNames.ModifyBy],
                                                    (bool)dr[ColumnNames.IsDeleted]);
            }
        }
        #endregion

        public class Generated
        {

            #region Get Functions
            public static DataTable GetByParams(int? id, int? firmId, string title, string detail, string description, DateTime? startDate, DateTime? beforeStartDate, DateTime? afterOrEqualStartDate, DateTime? endDate, DateTime? beforeEndDate, DateTime? afterOrEqualEndDate, string workPosition, int? type, string city, string country, int? employeesCount, int? state, DateTime? modifyDate, DateTime? beforeModifyDate, DateTime? afterOrEqualModifyDate, int? modifyBy, DateTime? createDate, DateTime? beforeCreateDate, DateTime? afterOrEqualCreateDate, int? createBy, bool? isDeleted)
            {
                return AdvertisementsProvider.Generated.GetByParams(id, firmId, title, detail, description, startDate, beforeStartDate, afterOrEqualStartDate, endDate, beforeEndDate, afterOrEqualEndDate, workPosition, type, city, country, employeesCount, state, modifyDate, beforeModifyDate, afterOrEqualModifyDate, modifyBy, createDate, beforeCreateDate, afterOrEqualCreateDate, createBy, isDeleted)
    .Tables[0];
            }

            public static DataTable GetByParams(SqlTransaction tran, int? id, int? firmId, string title, string detail, string description, DateTime? startDate, DateTime? beforeStartDate, DateTime? afterOrEqualStartDate, DateTime? endDate, DateTime? beforeEndDate, DateTime? afterOrEqualEndDate, string workPosition, int? type, string city, string country, int? employeesCount, int? state, DateTime? modifyDate, DateTime? beforeModifyDate, DateTime? afterOrEqualModifyDate, int? modifyBy, DateTime? createDate, DateTime? beforeCreateDate, DateTime? afterOrEqualCreateDate, int? createBy, bool? isDeleted)
            {
                return AdvertisementsProvider.Generated.GetByParams(tran, id, firmId, title, detail, description, startDate, beforeStartDate, afterOrEqualStartDate, endDate, beforeEndDate, afterOrEqualEndDate, workPosition, type, city, country, employeesCount, state, modifyDate, beforeModifyDate, afterOrEqualModifyDate, modifyBy, createDate, beforeCreateDate, afterOrEqualCreateDate, createBy, isDeleted)
    .Tables[0];
            }

            public static DataTable GetByParams(params SqlParameter[] sqlParams)
            {
                return AdvertisementsProvider.Generated.GetByParams(sqlParams).Tables[0];
            }

            public static DataTable GetByParams(SqlTransaction tran, params SqlParameter[] sqlParams)
            {
                return AdvertisementsProvider.Generated.GetByParams(tran, sqlParams).Tables[0];
            }



            public static DataTable GetAll(SqlTransaction tran)
            {
                return AdvertisementsProvider.Generated.GetAll(tran).Tables[0];
            }

            public static DataTable GetAll()
            {
                return AdvertisementsProvider.Generated.GetAll().Tables[0];
            }

            public static DataTable Get(SqlTransaction tran, int id)
            {
                return AdvertisementsProvider.Generated.Get(tran, id)
    .Tables[0];
            }

            public static DataTable Get(int id)
            {
                return AdvertisementsProvider.Generated.Get(id)
    .Tables[0];
            }



            #endregion

            #region Update Functions
            public static int Update(int id, int firmId, string title, string detail, string description, DateTime? startDate, DateTime? endDate, string workPosition, int? type, string city, string country, int? employeesCount, int? state, DateTime modifyDate, int modifyBy, bool isDeleted)
            {
                return AdvertisementsProvider.Generated.Update(id, firmId, title, detail, description, startDate, endDate, workPosition, type, city, country, employeesCount, state, modifyDate, modifyBy, isDeleted)
    ;
            }

            public static int Update(SqlTransaction tran, int id, int firmId, string title, string detail, string description, DateTime? startDate, DateTime? endDate, string workPosition, int? type, string city, string country, int? employeesCount, int? state, DateTime modifyDate, int modifyBy, bool isDeleted)
            {
                return AdvertisementsProvider.Generated.Update(id, firmId, title, detail, description, startDate, endDate, workPosition, type, city, country, employeesCount, state, modifyDate, modifyBy, isDeleted)
    ;
            }

            public static int UpdateByParams(int id, int? firmId, string title, string detail, string description, DateTime? startDate, DateTime? endDate, string workPosition, int? type, string city, string country, int? employeesCount, int? state, DateTime? modifyDate, int? modifyBy, DateTime? createDate, int? createBy, bool? isDeleted)
            {
                return AdvertisementsProvider.Generated.UpdateByParams(id, firmId, title, detail, description, startDate, endDate, workPosition, type, city, country, employeesCount, state, modifyDate, modifyBy, createDate, createBy, isDeleted)
    ;
            }

            public static int UpdateByParams(params SqlParameter[] sqlParams)
            {
                return AdvertisementsProvider.Generated.UpdateByParams(sqlParams);
            }

            public static int UpdateByParams(SqlTransaction tran, int id, int? firmId, string title, string detail, string description, DateTime? startDate, DateTime? endDate, string workPosition, int? type, string city, string country, int? employeesCount, int? state, DateTime? modifyDate, int? modifyBy, DateTime? createDate, int? createBy, bool? isDeleted)
            {
                return AdvertisementsProvider.Generated.UpdateByParams(tran, id, firmId, title, detail, description, startDate, endDate, workPosition, type, city, country, employeesCount, state, modifyDate, modifyBy, createDate, createBy, isDeleted)
    ;
            }

            public static int UpdateByParams(SqlTransaction tran, params SqlParameter[] sqlParams)
            {
                return AdvertisementsProvider.Generated.UpdateByParams(tran, sqlParams);
            }
            #endregion

            #region Add Functions
            public static int Add(int firmId, string title, string detail, string description, DateTime? startDate, DateTime? endDate, string workPosition, int? type, string city, string country, int? employeesCount, int? state, DateTime modifyDate, int modifyBy, DateTime createDate, int createBy, bool isDeleted)
            {
                return AdvertisementsProvider.Generated.Add(firmId, title, detail, description, startDate, endDate, workPosition, type, city, country, employeesCount, state, modifyDate, modifyBy, createDate, createBy, isDeleted)
    ;
            }

            public static int Add(SqlTransaction tran, int firmId, string title, string detail, string description, DateTime? startDate, DateTime? endDate, string workPosition, int? type, string city, string country, int? employeesCount, int? state, DateTime modifyDate, int modifyBy, DateTime createDate, int createBy, bool isDeleted)
            {
                return AdvertisementsProvider.Generated.Add(tran, firmId, title, detail, description, startDate, endDate, workPosition, type, city, country, employeesCount, state, modifyDate, modifyBy, createDate, createBy, isDeleted)
    ;
            }
            #endregion

            #region Delete Functions
            public static int DeleteByParams(int? id, int? firmId, string title, string detail, string description, DateTime? startDate, DateTime? beforeStartDate, DateTime? afterOrEqualStartDate, DateTime? endDate, DateTime? beforeEndDate, DateTime? afterOrEqualEndDate, string workPosition, int? type, string city, string country, int? employeesCount, int? state, DateTime? modifyDate, DateTime? beforeModifyDate, DateTime? afterOrEqualModifyDate, int? modifyBy, DateTime? createDate, DateTime? beforeCreateDate, DateTime? afterOrEqualCreateDate, int? createBy, bool? isDeleted)
            {
                return AdvertisementsProvider.Generated.DeleteByParams(null, id, firmId, title, detail, description, startDate, beforeStartDate, afterOrEqualStartDate, endDate, beforeEndDate, afterOrEqualEndDate, workPosition, type, city, country, employeesCount, state, modifyDate, beforeModifyDate, afterOrEqualModifyDate, modifyBy, createDate, beforeCreateDate, afterOrEqualCreateDate, createBy, isDeleted)
    ;
            }

            public static int DeleteByParams(SqlTransaction tran, int? id, int? firmId, string title, string detail, string description, DateTime? startDate, DateTime? beforeStartDate, DateTime? afterOrEqualStartDate, DateTime? endDate, DateTime? beforeEndDate, DateTime? afterOrEqualEndDate, string workPosition, int? type, string city, string country, int? employeesCount, int? state, DateTime? modifyDate, DateTime? beforeModifyDate, DateTime? afterOrEqualModifyDate, int? modifyBy, DateTime? createDate, DateTime? beforeCreateDate, DateTime? afterOrEqualCreateDate, int? createBy, bool? isDeleted)
            {
                return AdvertisementsProvider.Generated.DeleteByParams(tran, id, firmId, title, detail, description, startDate, beforeStartDate, afterOrEqualStartDate, endDate, beforeEndDate, afterOrEqualEndDate, workPosition, type, city, country, employeesCount, state, modifyDate, beforeModifyDate, afterOrEqualModifyDate, modifyBy, createDate, beforeCreateDate, afterOrEqualCreateDate, createBy, isDeleted)
    ;
            }

            public static int Delete(int id)
            {
                return AdvertisementsProvider.Generated.Delete(id)
    ;
            }

            public static int Delete(SqlTransaction tran, int id)
            {
                return AdvertisementsProvider.Generated.Delete(tran, id)
    ;
            }



            #endregion

        }
    }
}
