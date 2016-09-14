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

    public partial class Users
    {

        #region ColumnNames
        public struct ColumnNames
        {
            public const string ID = "ID";
            public const string Name = "Name";
            public const string Surname = "Surname";
            public const string NationalId = "NationalId";
            public const string Birthdate = "Birthdate";
            public const string StudentNumber = "StudentNumber";
            public const string Gender = "Gender";
            public const string Email = "Email";
            public const string HomePhone = "HomePhone";
            public const string Address = "Address";
            public const string Country = "Country";
            public const string City = "City";
            public const string UserPhoto = "UserPhoto";
            public const string Password = "Password";
            public const string ActivationCode = "ActivationCode";
            public const string IsActive = "IsActive";
            public const string IsDeleted = "IsDeleted";
            public const string ActivationDate = "ActivationDate";
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
            dt.Columns.Add("Surname", System.Type.GetType("System.String"));
            dt.Columns.Add("NationalId", System.Type.GetType("System.String"));
            dt.Columns.Add("Birthdate", System.Type.GetType("System.DateTime"));
            dt.Columns.Add("StudentNumber", System.Type.GetType("System.String"));
            dt.Columns.Add("Gender", System.Type.GetType("System.Int32"));
            dt.Columns.Add("Email", System.Type.GetType("System.String"));
            dt.Columns.Add("HomePhone", System.Type.GetType("System.String"));
            dt.Columns.Add("Address", System.Type.GetType("System.String"));
            dt.Columns.Add("Country", System.Type.GetType("System.Int32"));
            dt.Columns.Add("City", System.Type.GetType("System.Int32"));
            dt.Columns.Add("UserPhoto", System.Type.GetType("System.String"));
            dt.Columns.Add("Password", System.Type.GetType("System.String"));
            dt.Columns.Add("ActivationCode", System.Type.GetType("System.String"));
            dt.Columns.Add("IsActive", System.Type.GetType("System.Boolean"));
            dt.Columns.Add("IsDeleted", System.Type.GetType("System.Boolean"));
            dt.Columns.Add("ActivationDate", System.Type.GetType("System.DateTime"));
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
                    conn = new SqlConnection(UsersProvider.GetConnectionString());
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
                    throw new MyException(ex.Message, "Users", "Add");
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
                    conn = new SqlConnection(UsersProvider.GetConnectionString());
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
                    throw new MyException(ex.Message, "Users", "Update");
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
                return UsersProvider.Generated.Add(dr[ColumnNames.Name].ToString(),
                                                    dr[ColumnNames.Surname].ToString(),
                                                    dr[ColumnNames.NationalId].ToString(),
                                                    DBNullHelper.GetNullableValue<DateTime>(dr[ColumnNames.Birthdate]),
                                                    dr[ColumnNames.StudentNumber].ToString(),
                                                    (int)dr[ColumnNames.Gender],
                                                    dr[ColumnNames.Email].ToString(),
                                                    dr[ColumnNames.HomePhone].ToString(),
                                                    dr[ColumnNames.Address].ToString(),
                                                    DBNullHelper.GetNullableValue<int>(dr[ColumnNames.Country]),
                                                    DBNullHelper.GetNullableValue<int>(dr[ColumnNames.City]),
                                                    dr[ColumnNames.UserPhoto].ToString(),
                                                    dr[ColumnNames.Password].ToString(),
                                                    dr[ColumnNames.ActivationCode].ToString(),
                                                    (bool)dr[ColumnNames.IsActive],
                                                    DBNullHelper.GetNullableValue<bool>(dr[ColumnNames.IsDeleted]),
                                                    DBNullHelper.GetNullableValue<DateTime>(dr[ColumnNames.ActivationDate]),
                                                    (DateTime)dr[ColumnNames.ModifyDate],
                                                    (DateTime)dr[ColumnNames.CreateDate]);

            }

            public static int Add(SqlTransaction tran, DataRow dr)
            {
                return UsersProvider.Generated.Add(tran,
                                                    dr[ColumnNames.Name].ToString(),
                                                    dr[ColumnNames.Surname].ToString(),
                                                    dr[ColumnNames.NationalId].ToString(),
                                                    DBNullHelper.GetNullableValue<DateTime>(dr[ColumnNames.Birthdate]),
                                                    dr[ColumnNames.StudentNumber].ToString(),
                                                    (int)dr[ColumnNames.Gender],
                                                    dr[ColumnNames.Email].ToString(),
                                                    dr[ColumnNames.HomePhone].ToString(),
                                                    dr[ColumnNames.Address].ToString(),
                                                    DBNullHelper.GetNullableValue<int>(dr[ColumnNames.Country]),
                                                    DBNullHelper.GetNullableValue<int>(dr[ColumnNames.City]),
                                                    dr[ColumnNames.UserPhoto].ToString(),
                                                    dr[ColumnNames.Password].ToString(),
                                                    dr[ColumnNames.ActivationCode].ToString(),
                                                    (bool)dr[ColumnNames.IsActive],
                                                    DBNullHelper.GetNullableValue<bool>(dr[ColumnNames.IsDeleted]),
                                                    DBNullHelper.GetNullableValue<DateTime>(dr[ColumnNames.ActivationDate]),
                                                    (DateTime)dr[ColumnNames.ModifyDate],
                                                    (DateTime)dr[ColumnNames.CreateDate]);

            }

            public static int Update(DataRow dr)
            {
                return UsersProvider.Generated.Update((int)dr[ColumnNames.ID],
                                                    dr[ColumnNames.Name].ToString(),
                                                    dr[ColumnNames.Surname].ToString(),
                                                    dr[ColumnNames.NationalId].ToString(),
                                                    DBNullHelper.GetNullableValue<DateTime>(dr[ColumnNames.Birthdate]),
                                                    dr[ColumnNames.StudentNumber].ToString(),
                                                    (int)dr[ColumnNames.Gender],
                                                    dr[ColumnNames.Email].ToString(),
                                                    dr[ColumnNames.HomePhone].ToString(),
                                                    dr[ColumnNames.Address].ToString(),
                                                    DBNullHelper.GetNullableValue<int>(dr[ColumnNames.Country]),
                                                    DBNullHelper.GetNullableValue<int>(dr[ColumnNames.City]),
                                                    dr[ColumnNames.UserPhoto].ToString(),
                                                    dr[ColumnNames.Password].ToString(),
                                                    dr[ColumnNames.ActivationCode].ToString(),
                                                    (bool)dr[ColumnNames.IsActive],
                                                    DBNullHelper.GetNullableValue<bool>(dr[ColumnNames.IsDeleted]),
                                                    DBNullHelper.GetNullableValue<DateTime>(dr[ColumnNames.ActivationDate]),
                                                    (DateTime)dr[ColumnNames.ModifyDate]);
            }

            public static int Update(SqlTransaction tran, DataRow dr)
            {
                return UsersProvider.Generated.Update(tran,
                                                    (int)dr[ColumnNames.ID],
                                                    dr[ColumnNames.Name].ToString(),
                                                    dr[ColumnNames.Surname].ToString(),
                                                    dr[ColumnNames.NationalId].ToString(),
                                                    DBNullHelper.GetNullableValue<DateTime>(dr[ColumnNames.Birthdate]),
                                                    dr[ColumnNames.StudentNumber].ToString(),
                                                    (int)dr[ColumnNames.Gender],
                                                    dr[ColumnNames.Email].ToString(),
                                                    dr[ColumnNames.HomePhone].ToString(),
                                                    dr[ColumnNames.Address].ToString(),
                                                    DBNullHelper.GetNullableValue<int>(dr[ColumnNames.Country]),
                                                    DBNullHelper.GetNullableValue<int>(dr[ColumnNames.City]),
                                                    dr[ColumnNames.UserPhoto].ToString(),
                                                    dr[ColumnNames.Password].ToString(),
                                                    dr[ColumnNames.ActivationCode].ToString(),
                                                    (bool)dr[ColumnNames.IsActive],
                                                    DBNullHelper.GetNullableValue<bool>(dr[ColumnNames.IsDeleted]),
                                                    DBNullHelper.GetNullableValue<DateTime>(dr[ColumnNames.ActivationDate]),
                                                    (DateTime)dr[ColumnNames.ModifyDate]);
            }
        }
        #endregion

        public class Generated
        {

            #region Get Functions
            public static DataTable GetByParams(int? id, string name, string surname, string nationalId, DateTime? birthdate, DateTime? beforeBirthdate, DateTime? afterOrEqualBirthdate, string studentNumber, int? gender, string email, string homePhone, string address, int? country, int? city, string userPhoto, string password, string activationCode, bool? isActive, bool? isDeleted, DateTime? activationDate, DateTime? beforeActivationDate, DateTime? afterOrEqualActivationDate, DateTime? modifyDate, DateTime? beforeModifyDate, DateTime? afterOrEqualModifyDate, DateTime? createDate, DateTime? beforeCreateDate, DateTime? afterOrEqualCreateDate)
            {
                return UsersProvider.Generated.GetByParams(id, name, surname, nationalId, birthdate, beforeBirthdate, afterOrEqualBirthdate, studentNumber, gender, email, homePhone, address, country, city, userPhoto, password, activationCode, isActive, isDeleted, activationDate, beforeActivationDate, afterOrEqualActivationDate, modifyDate, beforeModifyDate, afterOrEqualModifyDate, createDate, beforeCreateDate, afterOrEqualCreateDate)
    .Tables[0];
            }

            public static DataTable GetByParams(SqlTransaction tran, int? id, string name, string surname, string nationalId, DateTime? birthdate, DateTime? beforeBirthdate, DateTime? afterOrEqualBirthdate, string studentNumber, int? gender, string email, string homePhone, string address, int? country, int? city, string userPhoto, string password, string activationCode, bool? isActive, bool? isDeleted, DateTime? activationDate, DateTime? beforeActivationDate, DateTime? afterOrEqualActivationDate, DateTime? modifyDate, DateTime? beforeModifyDate, DateTime? afterOrEqualModifyDate, DateTime? createDate, DateTime? beforeCreateDate, DateTime? afterOrEqualCreateDate)
            {
                return UsersProvider.Generated.GetByParams(tran, id, name, surname, nationalId, birthdate, beforeBirthdate, afterOrEqualBirthdate, studentNumber, gender, email, homePhone, address, country, city, userPhoto, password, activationCode, isActive, isDeleted, activationDate, beforeActivationDate, afterOrEqualActivationDate, modifyDate, beforeModifyDate, afterOrEqualModifyDate, createDate, beforeCreateDate, afterOrEqualCreateDate)
    .Tables[0];
            }

            public static DataTable GetByParams(params SqlParameter[] sqlParams)
            {
                return UsersProvider.Generated.GetByParams(sqlParams).Tables[0];
            }

            public static DataTable GetByParams(SqlTransaction tran, params SqlParameter[] sqlParams)
            {
                return UsersProvider.Generated.GetByParams(tran, sqlParams).Tables[0];
            }



            public static DataTable GetAll(SqlTransaction tran)
            {
                return UsersProvider.Generated.GetAll(tran).Tables[0];
            }

            public static DataTable GetAll()
            {
                return UsersProvider.Generated.GetAll().Tables[0];
            }

            public static DataTable Get(SqlTransaction tran, int id)
            {
                return UsersProvider.Generated.Get(tran, id)
    .Tables[0];
            }

            public static DataTable Get(int id)
            {
                return UsersProvider.Generated.Get(id)
    .Tables[0];
            }



            #endregion

            #region Update Functions
            public static int Update(int id, string name, string surname, string nationalId, DateTime? birthdate, string studentNumber, int gender, string email, string homePhone, string address, int? country, int? city, string userPhoto, string password, string activationCode, bool isActive, bool? isDeleted, DateTime? activationDate, DateTime modifyDate)
            {
                return UsersProvider.Generated.Update(id, name, surname, nationalId, birthdate, studentNumber, gender, email, homePhone, address, country, city, userPhoto, password, activationCode, isActive, isDeleted, activationDate, modifyDate)
    ;
            }

            public static int Update(SqlTransaction tran, int id, string name, string surname, string nationalId, DateTime? birthdate, string studentNumber, int gender, string email, string homePhone, string address, int? country, int? city, string userPhoto, string password, string activationCode, bool isActive, bool? isDeleted, DateTime? activationDate, DateTime modifyDate)
            {
                return UsersProvider.Generated.Update(id, name, surname, nationalId, birthdate, studentNumber, gender, email, homePhone, address, country, city, userPhoto, password, activationCode, isActive, isDeleted, activationDate, modifyDate)
    ;
            }

            public static int UpdateByParams(int id, string name, string surname, string nationalId, DateTime? birthdate, string studentNumber, int? gender, string email, string homePhone, string address, int? country, int? city, string userPhoto, string password, string activationCode, bool? isActive, bool? isDeleted, DateTime? activationDate, DateTime? modifyDate, DateTime? createDate)
            {
                return UsersProvider.Generated.UpdateByParams(id, name, surname, nationalId, birthdate, studentNumber, gender, email, homePhone, address, country, city, userPhoto, password, activationCode, isActive, isDeleted, activationDate, modifyDate, createDate)
    ;
            }

            public static int UpdateByParams(params SqlParameter[] sqlParams)
            {
                return UsersProvider.Generated.UpdateByParams(sqlParams);
            }

            public static int UpdateByParams(SqlTransaction tran, int id, string name, string surname, string nationalId, DateTime? birthdate, string studentNumber, int? gender, string email, string homePhone, string address, int? country, int? city, string userPhoto, string password, string activationCode, bool? isActive, bool? isDeleted, DateTime? activationDate, DateTime? modifyDate, DateTime? createDate)
            {
                return UsersProvider.Generated.UpdateByParams(tran, id, name, surname, nationalId, birthdate, studentNumber, gender, email, homePhone, address, country, city, userPhoto, password, activationCode, isActive, isDeleted, activationDate, modifyDate, createDate)
    ;
            }

            public static int UpdateByParams(SqlTransaction tran, params SqlParameter[] sqlParams)
            {
                return UsersProvider.Generated.UpdateByParams(tran, sqlParams);
            }
            #endregion

            #region Add Functions
            public static int Add(string name, string surname, string nationalId, DateTime? birthdate, string studentNumber, int gender, string email, string homePhone, string address, int? country, int? city, string userPhoto, string password, string activationCode, bool isActive, bool? isDeleted, DateTime? activationDate, DateTime modifyDate, DateTime createDate)
            {
                return UsersProvider.Generated.Add(name, surname, nationalId, birthdate, studentNumber, gender, email, homePhone, address, country, city, userPhoto, password, activationCode, isActive, isDeleted, activationDate, modifyDate, createDate)
    ;
            }

            public static int Add(SqlTransaction tran, string name, string surname, string nationalId, DateTime? birthdate, string studentNumber, int gender, string email, string homePhone, string address, int? country, int? city, string userPhoto, string password, string activationCode, bool isActive, bool? isDeleted, DateTime? activationDate, DateTime modifyDate, DateTime createDate)
            {
                return UsersProvider.Generated.Add(tran, name, surname, nationalId, birthdate, studentNumber, gender, email, homePhone, address, country, city, userPhoto, password, activationCode, isActive, isDeleted, activationDate, modifyDate, createDate)
    ;
            }
            #endregion

            #region Delete Functions
            public static int DeleteByParams(int? id, string name, string surname, string nationalId, DateTime? birthdate, DateTime? beforeBirthdate, DateTime? afterOrEqualBirthdate, string studentNumber, int? gender, string email, string homePhone, string address, int? country, int? city, string userPhoto, string password, string activationCode, bool? isActive, bool? isDeleted, DateTime? activationDate, DateTime? beforeActivationDate, DateTime? afterOrEqualActivationDate, DateTime? modifyDate, DateTime? beforeModifyDate, DateTime? afterOrEqualModifyDate, DateTime? createDate, DateTime? beforeCreateDate, DateTime? afterOrEqualCreateDate)
            {
                return UsersProvider.Generated.DeleteByParams(null, id, name, surname, nationalId, birthdate, beforeBirthdate, afterOrEqualBirthdate, studentNumber, gender, email, homePhone, address, country, city, userPhoto, password, activationCode, isActive, isDeleted, activationDate, beforeActivationDate, afterOrEqualActivationDate, modifyDate, beforeModifyDate, afterOrEqualModifyDate, createDate, beforeCreateDate, afterOrEqualCreateDate)
    ;
            }

            public static int DeleteByParams(SqlTransaction tran, int? id, string name, string surname, string nationalId, DateTime? birthdate, DateTime? beforeBirthdate, DateTime? afterOrEqualBirthdate, string studentNumber, int? gender, string email, string homePhone, string address, int? country, int? city, string userPhoto, string password, string activationCode, bool? isActive, bool? isDeleted, DateTime? activationDate, DateTime? beforeActivationDate, DateTime? afterOrEqualActivationDate, DateTime? modifyDate, DateTime? beforeModifyDate, DateTime? afterOrEqualModifyDate, DateTime? createDate, DateTime? beforeCreateDate, DateTime? afterOrEqualCreateDate)
            {
                return UsersProvider.Generated.DeleteByParams(tran, id, name, surname, nationalId, birthdate, beforeBirthdate, afterOrEqualBirthdate, studentNumber, gender, email, homePhone, address, country, city, userPhoto, password, activationCode, isActive, isDeleted, activationDate, beforeActivationDate, afterOrEqualActivationDate, modifyDate, beforeModifyDate, afterOrEqualModifyDate, createDate, beforeCreateDate, afterOrEqualCreateDate)
    ;
            }

            public static int Delete(int id)
            {
                return UsersProvider.Generated.Delete(id)
    ;
            }

            public static int Delete(SqlTransaction tran, int id)
            {
                return UsersProvider.Generated.Delete(tran, id)
    ;
            }



            #endregion

        }
    }
}
