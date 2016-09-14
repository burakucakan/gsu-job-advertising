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

    public partial class SiteParams
    {

        #region ColumnNames
        public struct ColumnNames
        {
            public const string ID = "ID";
            public const string ParamName = "ParamName";
            public const string ParamGroup = "ParamGroup";
            public const string Description = "Description";
            public const string Value = "Value";
            public const string Order = "Order";
        }
        #endregion

        #region Create DataTable
        public static DataTable CreateTable()
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("ID", System.Type.GetType("System.Int32"));
            dt.Columns.Add("ParamName", System.Type.GetType("System.String"));
            dt.Columns.Add("ParamGroup", System.Type.GetType("System.String"));
            dt.Columns.Add("Description", System.Type.GetType("System.String"));
            dt.Columns.Add("Value", System.Type.GetType("System.String"));
            dt.Columns.Add("Order", System.Type.GetType("System.Int32"));

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
                    conn = new SqlConnection(SiteParamsProvider.GetConnectionString());
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
                    throw new MyException(ex.Message, "SiteParams", "Add");
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
                    conn = new SqlConnection(SiteParamsProvider.GetConnectionString());
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
                    throw new MyException(ex.Message, "SiteParams", "Update");
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
                return SiteParamsProvider.Generated.Add(dr[ColumnNames.ParamName].ToString(),
                                                    dr[ColumnNames.ParamGroup].ToString(),
                                                    dr[ColumnNames.Description].ToString(),
                                                    dr[ColumnNames.Value].ToString(),
                                                    DBNullHelper.GetNullableValue<int>(dr[ColumnNames.Order]));

            }

            public static int Add(SqlTransaction tran, DataRow dr)
            {
                return SiteParamsProvider.Generated.Add(tran,
                                                    dr[ColumnNames.ParamName].ToString(),
                                                    dr[ColumnNames.ParamGroup].ToString(),
                                                    dr[ColumnNames.Description].ToString(),
                                                    dr[ColumnNames.Value].ToString(),
                                                    DBNullHelper.GetNullableValue<int>(dr[ColumnNames.Order]));

            }

            public static int Update(DataRow dr)
            {
                return SiteParamsProvider.Generated.Update((int)dr[ColumnNames.ID],
                                                    dr[ColumnNames.ParamName].ToString(),
                                                    dr[ColumnNames.ParamGroup].ToString(),
                                                    dr[ColumnNames.Description].ToString(),
                                                    dr[ColumnNames.Value].ToString(),
                                                    DBNullHelper.GetNullableValue<int>(dr[ColumnNames.Order]));
            }

            public static int Update(SqlTransaction tran, DataRow dr)
            {
                return SiteParamsProvider.Generated.Update(tran,
                                                    (int)dr[ColumnNames.ID],
                                                    dr[ColumnNames.ParamName].ToString(),
                                                    dr[ColumnNames.ParamGroup].ToString(),
                                                    dr[ColumnNames.Description].ToString(),
                                                    dr[ColumnNames.Value].ToString(),
                                                    DBNullHelper.GetNullableValue<int>(dr[ColumnNames.Order]));
            }
        }
        #endregion

        public class Generated
        {

            #region Get Functions
            public static DataTable GetByParams(int? id, string paramName, string paramGroup, string description, string value, int? order)
            {
                return SiteParamsProvider.Generated.GetByParams(id, paramName, paramGroup, description, value, order)
    .Tables[0];
            }

            public static DataTable GetByParams(SqlTransaction tran, int? id, string paramName, string paramGroup, string description, string value, int? order)
            {
                return SiteParamsProvider.Generated.GetByParams(tran, id, paramName, paramGroup, description, value, order)
    .Tables[0];
            }

            public static DataTable GetByParams(params SqlParameter[] sqlParams)
            {
                return SiteParamsProvider.Generated.GetByParams(sqlParams).Tables[0];
            }

            public static DataTable GetByParams(SqlTransaction tran, params SqlParameter[] sqlParams)
            {
                return SiteParamsProvider.Generated.GetByParams(tran, sqlParams).Tables[0];
            }



            public static DataTable GetAll(SqlTransaction tran)
            {
                return SiteParamsProvider.Generated.GetAll(tran).Tables[0];
            }

            public static DataTable GetAll()
            {
                return SiteParamsProvider.Generated.GetAll().Tables[0];
            }

            public static DataTable Get(SqlTransaction tran, int id)
            {
                return SiteParamsProvider.Generated.Get(tran, id)
    .Tables[0];
            }

            public static DataTable Get(int id)
            {
                return SiteParamsProvider.Generated.Get(id)
    .Tables[0];
            }



            #endregion

            #region Update Functions
            public static int Update(int id, string paramName, string paramGroup, string description, string value, int? order)
            {
                return SiteParamsProvider.Generated.Update(id, paramName, paramGroup, description, value, order)
    ;
            }

            public static int Update(SqlTransaction tran, int id, string paramName, string paramGroup, string description, string value, int? order)
            {
                return SiteParamsProvider.Generated.Update(id, paramName, paramGroup, description, value, order)
    ;
            }

            public static int UpdateByParams(int id, string paramName, string paramGroup, string description, string value, int? order)
            {
                return SiteParamsProvider.Generated.UpdateByParams(id, paramName, paramGroup, description, value, order)
    ;
            }

            public static int UpdateByParams(params SqlParameter[] sqlParams)
            {
                return SiteParamsProvider.Generated.UpdateByParams(sqlParams);
            }

            public static int UpdateByParams(SqlTransaction tran, int id, string paramName, string paramGroup, string description, string value, int? order)
            {
                return SiteParamsProvider.Generated.UpdateByParams(tran, id, paramName, paramGroup, description, value, order)
    ;
            }

            public static int UpdateByParams(SqlTransaction tran, params SqlParameter[] sqlParams)
            {
                return SiteParamsProvider.Generated.UpdateByParams(tran, sqlParams);
            }
            #endregion

            #region Add Functions
            public static int Add(string paramName, string paramGroup, string description, string value, int? order)
            {
                return SiteParamsProvider.Generated.Add(paramName, paramGroup, description, value, order)
    ;
            }

            public static int Add(SqlTransaction tran, string paramName, string paramGroup, string description, string value, int? order)
            {
                return SiteParamsProvider.Generated.Add(tran, paramName, paramGroup, description, value, order)
    ;
            }
            #endregion

            #region Delete Functions
            public static int DeleteByParams(int? id, string paramName, string paramGroup, string description, string value, int? order)
            {
                return SiteParamsProvider.Generated.DeleteByParams(null, id, paramName, paramGroup, description, value, order)
    ;
            }

            public static int DeleteByParams(SqlTransaction tran, int? id, string paramName, string paramGroup, string description, string value, int? order)
            {
                return SiteParamsProvider.Generated.DeleteByParams(tran, id, paramName, paramGroup, description, value, order)
    ;
            }

            public static int Delete(int id)
            {
                return SiteParamsProvider.Generated.Delete(id)
    ;
            }

            public static int Delete(SqlTransaction tran, int id)
            {
                return SiteParamsProvider.Generated.Delete(tran, id)
    ;
            }



            #endregion

        }
    }
}
