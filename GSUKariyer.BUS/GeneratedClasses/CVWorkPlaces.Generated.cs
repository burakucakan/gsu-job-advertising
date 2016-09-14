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

    public partial class CVWorkPlaces
    {

        #region ColumnNames
        public struct ColumnNames
        {
            public const string ID = "ID";
            public const string CVId = "CVId";
            public const string Type = "Type";
            public const string Value = "Value";
            public const string FreeValue = "FreeValue";
            public const string Order = "Order";
            public const string ModifyDate = "ModifyDate";
            public const string CreateDate = "CreateDate";
        }
        #endregion

        #region Create DataTable
        public static DataTable CreateTable()
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("ID", System.Type.GetType("System.Int32"));
            dt.Columns.Add("CVId", System.Type.GetType("System.Int32"));
            dt.Columns.Add("Type", System.Type.GetType("System.Int32"));
            dt.Columns.Add("Value", System.Type.GetType("System.String"));
            dt.Columns.Add("FreeValue", System.Type.GetType("System.String"));
            dt.Columns.Add("Order", System.Type.GetType("System.Int32"));
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
                    conn = new SqlConnection(CVWorkPlacesProvider.GetConnectionString());
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
                    throw new MyException(ex.Message, "CVWorkPlaces", "Add");
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
                    conn = new SqlConnection(CVWorkPlacesProvider.GetConnectionString());
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
                    throw new MyException(ex.Message, "CVWorkPlaces", "Update");
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
                return CVWorkPlacesProvider.Generated.Add((int)dr[ColumnNames.CVId],
                                                    DBNullHelper.GetNullableValue<int>(dr[ColumnNames.Type]),
                                                    dr[ColumnNames.Value].ToString(),
                                                    dr[ColumnNames.FreeValue].ToString(),
                                                    DBNullHelper.GetNullableValue<int>(dr[ColumnNames.Order]),
                                                    (DateTime)dr[ColumnNames.ModifyDate],
                                                    (DateTime)dr[ColumnNames.CreateDate]);

            }

            public static int Add(SqlTransaction tran, DataRow dr)
            {
                return CVWorkPlacesProvider.Generated.Add(tran,
                                                    (int)dr[ColumnNames.CVId],
                                                    DBNullHelper.GetNullableValue<int>(dr[ColumnNames.Type]),
                                                    dr[ColumnNames.Value].ToString(),
                                                    dr[ColumnNames.FreeValue].ToString(),
                                                    DBNullHelper.GetNullableValue<int>(dr[ColumnNames.Order]),
                                                    (DateTime)dr[ColumnNames.ModifyDate],
                                                    (DateTime)dr[ColumnNames.CreateDate]);

            }

            public static int Update(DataRow dr)
            {
                return CVWorkPlacesProvider.Generated.Update((int)dr[ColumnNames.ID],
                                                    (int)dr[ColumnNames.CVId],
                                                    DBNullHelper.GetNullableValue<int>(dr[ColumnNames.Type]),
                                                    dr[ColumnNames.Value].ToString(),
                                                    dr[ColumnNames.FreeValue].ToString(),
                                                    DBNullHelper.GetNullableValue<int>(dr[ColumnNames.Order]),
                                                    (DateTime)dr[ColumnNames.ModifyDate]);
            }

            public static int Update(SqlTransaction tran, DataRow dr)
            {
                return CVWorkPlacesProvider.Generated.Update(tran,
                                                    (int)dr[ColumnNames.ID],
                                                    (int)dr[ColumnNames.CVId],
                                                    DBNullHelper.GetNullableValue<int>(dr[ColumnNames.Type]),
                                                    dr[ColumnNames.Value].ToString(),
                                                    dr[ColumnNames.FreeValue].ToString(),
                                                    DBNullHelper.GetNullableValue<int>(dr[ColumnNames.Order]),
                                                    (DateTime)dr[ColumnNames.ModifyDate]);
            }
        }
        #endregion

        public class Generated
        {

            #region Get Functions
            public static DataTable GetByParams(int? id, int? cVId, int? type, string value, string freeValue, int? order, DateTime? modifyDate, DateTime? beforeModifyDate, DateTime? afterOrEqualModifyDate, DateTime? createDate, DateTime? beforeCreateDate, DateTime? afterOrEqualCreateDate)
            {
                return CVWorkPlacesProvider.Generated.GetByParams(id, cVId, type, value, freeValue, order, modifyDate, beforeModifyDate, afterOrEqualModifyDate, createDate, beforeCreateDate, afterOrEqualCreateDate)
    .Tables[0];
            }

            public static DataTable GetByParams(SqlTransaction tran, int? id, int? cVId, int? type, string value, string freeValue, int? order, DateTime? modifyDate, DateTime? beforeModifyDate, DateTime? afterOrEqualModifyDate, DateTime? createDate, DateTime? beforeCreateDate, DateTime? afterOrEqualCreateDate)
            {
                return CVWorkPlacesProvider.Generated.GetByParams(tran, id, cVId, type, value, freeValue, order, modifyDate, beforeModifyDate, afterOrEqualModifyDate, createDate, beforeCreateDate, afterOrEqualCreateDate)
    .Tables[0];
            }

            public static DataTable GetByParams(params SqlParameter[] sqlParams)
            {
                return CVWorkPlacesProvider.Generated.GetByParams(sqlParams).Tables[0];
            }

            public static DataTable GetByParams(SqlTransaction tran, params SqlParameter[] sqlParams)
            {
                return CVWorkPlacesProvider.Generated.GetByParams(tran, sqlParams).Tables[0];
            }

            public static DataTable GetByFKBasic(int? cVId)
            {
                return CVWorkPlacesProvider.Generated.GetByFKBasic(cVId)
    .Tables[0];
            }

            public static DataTable GetByFKBasic(SqlTransaction tran, int? cVId)
            {
                return CVWorkPlacesProvider.Generated.GetByFKBasic(tran, cVId)
    .Tables[0];
            }


            public static DataTable GetAll(SqlTransaction tran)
            {
                return CVWorkPlacesProvider.Generated.GetAll(tran).Tables[0];
            }

            public static DataTable GetAll()
            {
                return CVWorkPlacesProvider.Generated.GetAll().Tables[0];
            }

            public static DataTable Get(SqlTransaction tran, int id)
            {
                return CVWorkPlacesProvider.Generated.Get(tran, id)
    .Tables[0];
            }

            public static DataTable Get(int id)
            {
                return CVWorkPlacesProvider.Generated.Get(id)
    .Tables[0];
            }

            public static DataTable GetByFK(SqlTransaction tran, int cVId)
            {
                return CVWorkPlacesProvider.Generated.GetByFK(tran, cVId)
    .Tables[0];
            }

            public static DataTable GetByFK(int cVId)
            {
                return CVWorkPlacesProvider.Generated.GetByFK(cVId)
    .Tables[0];
            }


            #endregion

            #region Update Functions
            public static int Update(int id, int cVId, int? type, string value, string freeValue, int? order, DateTime modifyDate)
            {
                return CVWorkPlacesProvider.Generated.Update(id, cVId, type, value, freeValue, order, modifyDate)
    ;
            }

            public static int Update(SqlTransaction tran, int id, int cVId, int? type, string value, string freeValue, int? order, DateTime modifyDate)
            {
                return CVWorkPlacesProvider.Generated.Update(id, cVId, type, value, freeValue, order, modifyDate)
    ;
            }

            public static int UpdateByParams(int id, int? cVId, int? type, string value, string freeValue, int? order, DateTime? modifyDate, DateTime? createDate)
            {
                return CVWorkPlacesProvider.Generated.UpdateByParams(id, cVId, type, value, freeValue, order, modifyDate, createDate)
    ;
            }

            public static int UpdateByParams(params SqlParameter[] sqlParams)
            {
                return CVWorkPlacesProvider.Generated.UpdateByParams(sqlParams);
            }

            public static int UpdateByParams(SqlTransaction tran, int id, int? cVId, int? type, string value, string freeValue, int? order, DateTime? modifyDate, DateTime? createDate)
            {
                return CVWorkPlacesProvider.Generated.UpdateByParams(tran, id, cVId, type, value, freeValue, order, modifyDate, createDate)
    ;
            }

            public static int UpdateByParams(SqlTransaction tran, params SqlParameter[] sqlParams)
            {
                return CVWorkPlacesProvider.Generated.UpdateByParams(tran, sqlParams);
            }
            #endregion

            #region Add Functions
            public static int Add(int cVId, int? type, string value, string freeValue, int? order, DateTime modifyDate, DateTime createDate)
            {
                return CVWorkPlacesProvider.Generated.Add(cVId, type, value, freeValue, order, modifyDate, createDate)
    ;
            }

            public static int Add(SqlTransaction tran, int cVId, int? type, string value, string freeValue, int? order, DateTime modifyDate, DateTime createDate)
            {
                return CVWorkPlacesProvider.Generated.Add(tran, cVId, type, value, freeValue, order, modifyDate, createDate)
    ;
            }
            #endregion

            #region Delete Functions
            public static int DeleteByParams(int? id, int? cVId, int? type, string value, string freeValue, int? order, DateTime? modifyDate, DateTime? beforeModifyDate, DateTime? afterOrEqualModifyDate, DateTime? createDate, DateTime? beforeCreateDate, DateTime? afterOrEqualCreateDate)
            {
                return CVWorkPlacesProvider.Generated.DeleteByParams(null, id, cVId, type, value, freeValue, order, modifyDate, beforeModifyDate, afterOrEqualModifyDate, createDate, beforeCreateDate, afterOrEqualCreateDate)
    ;
            }

            public static int DeleteByParams(SqlTransaction tran, int? id, int? cVId, int? type, string value, string freeValue, int? order, DateTime? modifyDate, DateTime? beforeModifyDate, DateTime? afterOrEqualModifyDate, DateTime? createDate, DateTime? beforeCreateDate, DateTime? afterOrEqualCreateDate)
            {
                return CVWorkPlacesProvider.Generated.DeleteByParams(tran, id, cVId, type, value, freeValue, order, modifyDate, beforeModifyDate, afterOrEqualModifyDate, createDate, beforeCreateDate, afterOrEqualCreateDate)
    ;
            }

            public static int Delete(int id)
            {
                return CVWorkPlacesProvider.Generated.Delete(id)
    ;
            }

            public static int Delete(SqlTransaction tran, int id)
            {
                return CVWorkPlacesProvider.Generated.Delete(tran, id)
    ;
            }

            public static int DeleteByFK(int? cVId)
            {
                return CVWorkPlacesProvider.Generated.DeleteByFK(cVId)
    ;
            }

            public static int DeleteByFK(SqlTransaction tran, int? cVId)
            {
                return CVWorkPlacesProvider.Generated.DeleteByFK(cVId)
    ;
            }


            #endregion

        }
    }
}
