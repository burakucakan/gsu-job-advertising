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

    public partial class FirmUsers
    {

        #region ColumnNames
        public struct ColumnNames
        {
            public const string ID = "ID";
            public const string FirmId = "FirmId";
            public const string Name = "Name";
            public const string Surname = "Surname";
            public const string Position = "Position";
            public const string Phone = "Phone";
            public const string PhoneSuffix = "PhoneSuffix";
            public const string Fax = "Fax";
            public const string Email = "Email";
            public const string Password = "Password";
            public const string UserRole = "UserRole";
            public const string ModifyDate = "ModifyDate";
            public const string ModifyBy = "ModifyBy";
            public const string CreateDate = "CreateDate";
            public const string CreateBy = "CreateBy";
        }
        #endregion

        #region Create DataTable
        public static DataTable CreateTable()
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("ID", System.Type.GetType("System.Int32"));
            dt.Columns.Add("FirmId", System.Type.GetType("System.Int32"));
            dt.Columns.Add("Name", System.Type.GetType("System.String"));
            dt.Columns.Add("Surname", System.Type.GetType("System.String"));
            dt.Columns.Add("Position", System.Type.GetType("System.String"));
            dt.Columns.Add("Phone", System.Type.GetType("System.String"));
            dt.Columns.Add("PhoneSuffix", System.Type.GetType("System.String"));
            dt.Columns.Add("Fax", System.Type.GetType("System.String"));
            dt.Columns.Add("Email", System.Type.GetType("System.String"));
            dt.Columns.Add("Password", System.Type.GetType("System.String"));
            dt.Columns.Add("UserRole", System.Type.GetType("System.String"));
            dt.Columns.Add("ModifyDate", System.Type.GetType("System.DateTime"));
            dt.Columns.Add("ModifyBy", System.Type.GetType("System.String"));
            dt.Columns.Add("CreateDate", System.Type.GetType("System.DateTime"));
            dt.Columns.Add("CreateBy", System.Type.GetType("System.String"));

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
                    conn = new SqlConnection(FirmUsersProvider.GetConnectionString());
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
                    throw new MyException(ex.Message, "FirmUsers", "Add");
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
                    conn = new SqlConnection(FirmUsersProvider.GetConnectionString());
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
                    throw new MyException(ex.Message, "FirmUsers", "Update");
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
                return FirmUsersProvider.Generated.Add((int)dr[ColumnNames.FirmId],
                                                    dr[ColumnNames.Name].ToString(),
                                                    dr[ColumnNames.Surname].ToString(),
                                                    dr[ColumnNames.Position].ToString(),
                                                    dr[ColumnNames.Phone].ToString(),
                                                    dr[ColumnNames.PhoneSuffix].ToString(),
                                                    dr[ColumnNames.Fax].ToString(),
                                                    dr[ColumnNames.Email].ToString(),
                                                    dr[ColumnNames.Password].ToString(),
                                                    dr[ColumnNames.UserRole].ToString(),
                                                    (DateTime)dr[ColumnNames.ModifyDate],
                                                    dr[ColumnNames.ModifyBy].ToString(),
                                                    (DateTime)dr[ColumnNames.CreateDate],
                                                    dr[ColumnNames.CreateBy].ToString());

            }

            public static int Add(SqlTransaction tran, DataRow dr)
            {
                return FirmUsersProvider.Generated.Add(tran,
                                                    (int)dr[ColumnNames.FirmId],
                                                    dr[ColumnNames.Name].ToString(),
                                                    dr[ColumnNames.Surname].ToString(),
                                                    dr[ColumnNames.Position].ToString(),
                                                    dr[ColumnNames.Phone].ToString(),
                                                    dr[ColumnNames.PhoneSuffix].ToString(),
                                                    dr[ColumnNames.Fax].ToString(),
                                                    dr[ColumnNames.Email].ToString(),
                                                    dr[ColumnNames.Password].ToString(),
                                                    dr[ColumnNames.UserRole].ToString(),
                                                    (DateTime)dr[ColumnNames.ModifyDate],
                                                    dr[ColumnNames.ModifyBy].ToString(),
                                                    (DateTime)dr[ColumnNames.CreateDate],
                                                    dr[ColumnNames.CreateBy].ToString());

            }

            public static int Update(DataRow dr)
            {
                return FirmUsersProvider.Generated.Update((int)dr[ColumnNames.ID],
                                                    (int)dr[ColumnNames.FirmId],
                                                    dr[ColumnNames.Name].ToString(),
                                                    dr[ColumnNames.Surname].ToString(),
                                                    dr[ColumnNames.Position].ToString(),
                                                    dr[ColumnNames.Phone].ToString(),
                                                    dr[ColumnNames.PhoneSuffix].ToString(),
                                                    dr[ColumnNames.Fax].ToString(),
                                                    dr[ColumnNames.Email].ToString(),
                                                    dr[ColumnNames.Password].ToString(),
                                                    dr[ColumnNames.UserRole].ToString(),
                                                    (DateTime)dr[ColumnNames.ModifyDate],
                                                    dr[ColumnNames.ModifyBy].ToString());
            }

            public static int Update(SqlTransaction tran, DataRow dr)
            {
                return FirmUsersProvider.Generated.Update(tran,
                                                    (int)dr[ColumnNames.ID],
                                                    (int)dr[ColumnNames.FirmId],
                                                    dr[ColumnNames.Name].ToString(),
                                                    dr[ColumnNames.Surname].ToString(),
                                                    dr[ColumnNames.Position].ToString(),
                                                    dr[ColumnNames.Phone].ToString(),
                                                    dr[ColumnNames.PhoneSuffix].ToString(),
                                                    dr[ColumnNames.Fax].ToString(),
                                                    dr[ColumnNames.Email].ToString(),
                                                    dr[ColumnNames.Password].ToString(),
                                                    dr[ColumnNames.UserRole].ToString(),
                                                    (DateTime)dr[ColumnNames.ModifyDate],
                                                    dr[ColumnNames.ModifyBy].ToString());
            }
        }
        #endregion

        public class Generated
        {

            #region Get Functions
            public static DataTable GetByParams(int? id, int? firmId, string name, string surname, string position, string phone, string phoneSuffix, string fax, string email, string password, string userRole, DateTime? modifyDate, DateTime? beforeModifyDate, DateTime? afterOrEqualModifyDate, string modifyBy, DateTime? createDate, DateTime? beforeCreateDate, DateTime? afterOrEqualCreateDate, string createBy)
            {
                return FirmUsersProvider.Generated.GetByParams(id, firmId, name, surname, position, phone, phoneSuffix, fax, email, password, userRole, modifyDate, beforeModifyDate, afterOrEqualModifyDate, modifyBy, createDate, beforeCreateDate, afterOrEqualCreateDate, createBy)
    .Tables[0];
            }

            public static DataTable GetByParams(SqlTransaction tran, int? id, int? firmId, string name, string surname, string position, string phone, string phoneSuffix, string fax, string email, string password, string userRole, DateTime? modifyDate, DateTime? beforeModifyDate, DateTime? afterOrEqualModifyDate, string modifyBy, DateTime? createDate, DateTime? beforeCreateDate, DateTime? afterOrEqualCreateDate, string createBy)
            {
                return FirmUsersProvider.Generated.GetByParams(tran, id, firmId, name, surname, position, phone, phoneSuffix, fax, email, password, userRole, modifyDate, beforeModifyDate, afterOrEqualModifyDate, modifyBy, createDate, beforeCreateDate, afterOrEqualCreateDate, createBy)
    .Tables[0];
            }

            public static DataTable GetByParams(params SqlParameter[] sqlParams)
            {
                return FirmUsersProvider.Generated.GetByParams(sqlParams).Tables[0];
            }

            public static DataTable GetByParams(SqlTransaction tran, params SqlParameter[] sqlParams)
            {
                return FirmUsersProvider.Generated.GetByParams(tran, sqlParams).Tables[0];
            }



            public static DataTable GetAll(SqlTransaction tran)
            {
                return FirmUsersProvider.Generated.GetAll(tran).Tables[0];
            }

            public static DataTable GetAll()
            {
                return FirmUsersProvider.Generated.GetAll().Tables[0];
            }

            public static DataTable Get(SqlTransaction tran, int id)
            {
                return FirmUsersProvider.Generated.Get(tran, id)
    .Tables[0];
            }

            public static DataTable Get(int id)
            {
                return FirmUsersProvider.Generated.Get(id)
    .Tables[0];
            }



            #endregion

            #region Update Functions
            public static int Update(int id, int firmId, string name, string surname, string position, string phone, string phoneSuffix, string fax, string email, string password, string userRole, DateTime modifyDate, string modifyBy)
            {
                return FirmUsersProvider.Generated.Update(id, firmId, name, surname, position, phone, phoneSuffix, fax, email, password, userRole, modifyDate, modifyBy)
    ;
            }

            public static int Update(SqlTransaction tran, int id, int firmId, string name, string surname, string position, string phone, string phoneSuffix, string fax, string email, string password, string userRole, DateTime modifyDate, string modifyBy)
            {
                return FirmUsersProvider.Generated.Update(id, firmId, name, surname, position, phone, phoneSuffix, fax, email, password, userRole, modifyDate, modifyBy)
    ;
            }

            public static int UpdateByParams(int id, int? firmId, string name, string surname, string position, string phone, string phoneSuffix, string fax, string email, string password, string userRole, DateTime? modifyDate, string modifyBy, DateTime? createDate, string createBy)
            {
                return FirmUsersProvider.Generated.UpdateByParams(id, firmId, name, surname, position, phone, phoneSuffix, fax, email, password, userRole, modifyDate, modifyBy, createDate, createBy)
    ;
            }

            public static int UpdateByParams(params SqlParameter[] sqlParams)
            {
                return FirmUsersProvider.Generated.UpdateByParams(sqlParams);
            }

            public static int UpdateByParams(SqlTransaction tran, int id, int? firmId, string name, string surname, string position, string phone, string phoneSuffix, string fax, string email, string password, string userRole, DateTime? modifyDate, string modifyBy, DateTime? createDate, string createBy)
            {
                return FirmUsersProvider.Generated.UpdateByParams(tran, id, firmId, name, surname, position, phone, phoneSuffix, fax, email, password, userRole, modifyDate, modifyBy, createDate, createBy)
    ;
            }

            public static int UpdateByParams(SqlTransaction tran, params SqlParameter[] sqlParams)
            {
                return FirmUsersProvider.Generated.UpdateByParams(tran, sqlParams);
            }
            #endregion

            #region Add Functions
            public static int Add(int firmId, string name, string surname, string position, string phone, string phoneSuffix, string fax, string email, string password, string userRole, DateTime modifyDate, string modifyBy, DateTime createDate, string createBy)
            {
                return FirmUsersProvider.Generated.Add(firmId, name, surname, position, phone, phoneSuffix, fax, email, password, userRole, modifyDate, modifyBy, createDate, createBy)
    ;
            }

            public static int Add(SqlTransaction tran, int firmId, string name, string surname, string position, string phone, string phoneSuffix, string fax, string email, string password, string userRole, DateTime modifyDate, string modifyBy, DateTime createDate, string createBy)
            {
                return FirmUsersProvider.Generated.Add(tran, firmId, name, surname, position, phone, phoneSuffix, fax, email, password, userRole, modifyDate, modifyBy, createDate, createBy)
    ;
            }
            #endregion

            #region Delete Functions
            public static int DeleteByParams(int? id, int? firmId, string name, string surname, string position, string phone, string phoneSuffix, string fax, string email, string password, string userRole, DateTime? modifyDate, DateTime? beforeModifyDate, DateTime? afterOrEqualModifyDate, string modifyBy, DateTime? createDate, DateTime? beforeCreateDate, DateTime? afterOrEqualCreateDate, string createBy)
            {
                return FirmUsersProvider.Generated.DeleteByParams(null, id, firmId, name, surname, position, phone, phoneSuffix, fax, email, password, userRole, modifyDate, beforeModifyDate, afterOrEqualModifyDate, modifyBy, createDate, beforeCreateDate, afterOrEqualCreateDate, createBy)
    ;
            }

            public static int DeleteByParams(SqlTransaction tran, int? id, int? firmId, string name, string surname, string position, string phone, string phoneSuffix, string fax, string email, string password, string userRole, DateTime? modifyDate, DateTime? beforeModifyDate, DateTime? afterOrEqualModifyDate, string modifyBy, DateTime? createDate, DateTime? beforeCreateDate, DateTime? afterOrEqualCreateDate, string createBy)
            {
                return FirmUsersProvider.Generated.DeleteByParams(tran, id, firmId, name, surname, position, phone, phoneSuffix, fax, email, password, userRole, modifyDate, beforeModifyDate, afterOrEqualModifyDate, modifyBy, createDate, beforeCreateDate, afterOrEqualCreateDate, createBy)
    ;
            }

            public static int Delete(int id)
            {
                return FirmUsersProvider.Generated.Delete(id)
    ;
            }

            public static int Delete(SqlTransaction tran, int id)
            {
                return FirmUsersProvider.Generated.Delete(tran, id)
    ;
            }



            #endregion

        }
    }
}
