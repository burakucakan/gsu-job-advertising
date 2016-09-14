using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using GSUKariyer.COMMON.Helpers.DAL;
using GSUKariyer.COMMON.Exceptions;

namespace GSUKariyer.DAL
{

    public partial class UsersProvider : BaseDataLayer
    {

        public class Generated
        {

            #region Get Functions
            protected static DataSet GetBasic(SqlTransaction tran, int? id)
            {
                SqlParameter[] sqlParams = null;

                try
                {
                    DataSet ds = null;

                    sqlParams = new SqlParameter[] { 
					new SqlParameter("@ID",id)
                };

                    if (tran == null)
                        ds = ExecuteDataset("BGA_GetUsers", sqlParams);
                    else
                        ds = ExecuteDataset(tran, "BGA_GetUsers", sqlParams);

                    return ds;
                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "UsersProvider", "Get", ArrangeParamValues(sqlParams));
                }
            }

            public static DataSet GetByParams(int? id, string name, string surname, string nationalId, DateTime? birthdate, DateTime? beforeBirthdate, DateTime? afterOrEqualBirthdate, string studentNumber, int? gender, string email, string homePhone, string address, int? country, int? city, string userPhoto, string password, string activationCode, bool? isActive, bool? isDeleted, DateTime? activationDate, DateTime? beforeActivationDate, DateTime? afterOrEqualActivationDate, DateTime? modifyDate, DateTime? beforeModifyDate, DateTime? afterOrEqualModifyDate, DateTime? createDate, DateTime? beforeCreateDate, DateTime? afterOrEqualCreateDate)
            {
                return GetByParams(null, id, name, surname, nationalId, birthdate, beforeBirthdate, afterOrEqualBirthdate, studentNumber, gender, email, homePhone, address, country, city, userPhoto, password, activationCode, isActive, isDeleted, activationDate, beforeActivationDate, afterOrEqualActivationDate, modifyDate, beforeModifyDate, afterOrEqualModifyDate, createDate, beforeCreateDate, afterOrEqualCreateDate)
    ;
            }

            public static DataSet GetByParams(SqlTransaction tran, int? id, string name, string surname, string nationalId, DateTime? birthdate, DateTime? beforeBirthdate, DateTime? afterOrEqualBirthdate, string studentNumber, int? gender, string email, string homePhone, string address, int? country, int? city, string userPhoto, string password, string activationCode, bool? isActive, bool? isDeleted, DateTime? activationDate, DateTime? beforeActivationDate, DateTime? afterOrEqualActivationDate, DateTime? modifyDate, DateTime? beforeModifyDate, DateTime? afterOrEqualModifyDate, DateTime? createDate, DateTime? beforeCreateDate, DateTime? afterOrEqualCreateDate)
            {
                SqlParameter[] sqlParams = null;

                try
                {
                    DataSet ds = null;

                    sqlParams = new SqlParameter[] { 
					new SqlParameter("@ID",id),
					new SqlParameter("@Name",name),
					new SqlParameter("@Surname",surname),
					new SqlParameter("@NationalId",nationalId),
					new SqlParameter("@Birthdate",birthdate),
					new SqlParameter("@BeforeBirthdate",beforeBirthdate),
					new SqlParameter("@AfterOrEqualBirthdate",afterOrEqualBirthdate),
					new SqlParameter("@StudentNumber",studentNumber),
					new SqlParameter("@Gender",gender),
					new SqlParameter("@Email",email),
					new SqlParameter("@HomePhone",homePhone),
					new SqlParameter("@Address",address),
					new SqlParameter("@Country",country),
					new SqlParameter("@City",city),
					new SqlParameter("@UserPhoto",userPhoto),
					new SqlParameter("@Password",password),
					new SqlParameter("@ActivationCode",activationCode),
					new SqlParameter("@IsActive",isActive),
					new SqlParameter("@IsDeleted",isDeleted),
					new SqlParameter("@ActivationDate",activationDate),
					new SqlParameter("@BeforeActivationDate",beforeActivationDate),
					new SqlParameter("@AfterOrEqualActivationDate",afterOrEqualActivationDate),
					new SqlParameter("@ModifyDate",modifyDate),
					new SqlParameter("@BeforeModifyDate",beforeModifyDate),
					new SqlParameter("@AfterOrEqualModifyDate",afterOrEqualModifyDate),
					new SqlParameter("@CreateDate",createDate),
					new SqlParameter("@BeforeCreateDate",beforeCreateDate),
					new SqlParameter("@AfterOrEqualCreateDate",afterOrEqualCreateDate)
                };

                    if (tran == null)
                        ds = ExecuteDataset("BGA_GetUsersByParams", sqlParams);
                    else
                        ds = ExecuteDataset(tran, "BGA_GetUsersByParams", sqlParams);

                    return ds;
                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "UsersProvider", "GetByParams", ArrangeParamValues(sqlParams));
                }
            }

            public static DataSet GetByParams(params SqlParameter[] sqlParams)
            {
                return GetByParams(null, sqlParams);
            }

            public static DataSet GetByParams(SqlTransaction tran, params SqlParameter[] sqlParams)
            {
                try
                {
                    DataSet ds = null;

                    ds = ExecuteDataset("BGA_GetUsersByParams", sqlParams);

                    return ds;
                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "UsersProvider", "GetByParams", ArrangeParamValues(sqlParams));
                }
            }



            public static DataSet GetAll(SqlTransaction tran)
            {
                return GetBasic(tran, null);
            }

            public static DataSet GetAll()
            {
                return GetBasic(null, null);
            }

            public static DataSet Get(SqlTransaction tran, int id)
            {
                return GetBasic(tran, id);
            }

            public static DataSet Get(int id)
            {
                return GetBasic(null, id);
            }



            #endregion

            #region Update Functions
            public static int Update(int id, string name, string surname, string nationalId, DateTime? birthdate, string studentNumber, int gender, string email, string homePhone, string address, int? country, int? city, string userPhoto, string password, string activationCode, bool isActive, bool? isDeleted, DateTime? activationDate, DateTime modifyDate)
            {
                SqlParameter[] sqlParams = null;

                try
                {
                    sqlParams = new SqlParameter[] { 
					new SqlParameter("@ID",id),
					new SqlParameter("@Name",name),
					new SqlParameter("@Surname",surname),
					new SqlParameter("@NationalId",nationalId),
					new SqlParameter("@Birthdate",birthdate),
					new SqlParameter("@StudentNumber",studentNumber),
					new SqlParameter("@Gender",gender),
					new SqlParameter("@Email",email),
					new SqlParameter("@HomePhone",homePhone),
					new SqlParameter("@Address",address),
					new SqlParameter("@Country",country),
					new SqlParameter("@City",city),
					new SqlParameter("@UserPhoto",userPhoto),
					new SqlParameter("@Password",password),
					new SqlParameter("@ActivationCode",activationCode),
					new SqlParameter("@IsActive",isActive),
					new SqlParameter("@IsDeleted",isDeleted),
					new SqlParameter("@ActivationDate",activationDate),
					new SqlParameter("@ModifyDate",modifyDate)
                };

                    return ExecuteNonQuery("BGA_UpdateUsers", sqlParams);

                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "UsersProvider", "Update", ArrangeParamValues(sqlParams));
                }
            }

            public static int Update(SqlTransaction tran, int id, string name, string surname, string nationalId, DateTime? birthdate, string studentNumber, int gender, string email, string homePhone, string address, int? country, int? city, string userPhoto, string password, string activationCode, bool isActive, bool? isDeleted, DateTime? activationDate, DateTime modifyDate)
            {
                SqlParameter[] sqlParams = null;

                try
                {
                    sqlParams = new SqlParameter[] { 
					new SqlParameter("@ID",id),
					new SqlParameter("@Name",name),
					new SqlParameter("@Surname",surname),
					new SqlParameter("@NationalId",nationalId),
					new SqlParameter("@Birthdate",birthdate),
					new SqlParameter("@StudentNumber",studentNumber),
					new SqlParameter("@Gender",gender),
					new SqlParameter("@Email",email),
					new SqlParameter("@HomePhone",homePhone),
					new SqlParameter("@Address",address),
					new SqlParameter("@Country",country),
					new SqlParameter("@City",city),
					new SqlParameter("@UserPhoto",userPhoto),
					new SqlParameter("@Password",password),
					new SqlParameter("@ActivationCode",activationCode),
					new SqlParameter("@IsActive",isActive),
					new SqlParameter("@IsDeleted",isDeleted),
					new SqlParameter("@ActivationDate",activationDate),
					new SqlParameter("@ModifyDate",modifyDate)
                };

                    return ExecuteNonQuery(tran, "BGA_UpdateUsers", sqlParams);

                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "UsersProvider", "Update", ArrangeParamValues(sqlParams));
                }
            }

            public static int UpdateByParams(int id, string name, string surname, string nationalId, DateTime? birthdate, string studentNumber, int? gender, string email, string homePhone, string address, int? country, int? city, string userPhoto, string password, string activationCode, bool? isActive, bool? isDeleted, DateTime? activationDate, DateTime? modifyDate, DateTime? createDate)
            {
                SqlParameter[] sqlParams = null;

                try
                {
                    sqlParams = new SqlParameter[] { 
					new SqlParameter("@ID",id),
					new SqlParameter("@Name",name),
					new SqlParameter("@Surname",surname),
					new SqlParameter("@NationalId",nationalId),
					new SqlParameter("@Birthdate",birthdate),
					new SqlParameter("@StudentNumber",studentNumber),
					new SqlParameter("@Gender",gender),
					new SqlParameter("@Email",email),
					new SqlParameter("@HomePhone",homePhone),
					new SqlParameter("@Address",address),
					new SqlParameter("@Country",country),
					new SqlParameter("@City",city),
					new SqlParameter("@UserPhoto",userPhoto),
					new SqlParameter("@Password",password),
					new SqlParameter("@ActivationCode",activationCode),
					new SqlParameter("@IsActive",isActive),
					new SqlParameter("@IsDeleted",isDeleted),
					new SqlParameter("@ActivationDate",activationDate),
					new SqlParameter("@ModifyDate",modifyDate),
					new SqlParameter("@CreateDate",createDate)
                };

                    return ExecuteNonQuery("BGA_UpdateUsersByParams", sqlParams);

                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "UsersProvider", "UpdateByParams", ArrangeParamValues(sqlParams));
                }
            }

            public static int UpdateByParams(params SqlParameter[] sqlParams)
            {
                try
                {

                    return ExecuteNonQuery("BGA_UpdateUsersByParams", sqlParams);

                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "UsersProvider", "UpdateByParams", ArrangeParamValues(sqlParams));
                }
            }

            public static int UpdateByParams(SqlTransaction tran, int id, string name, string surname, string nationalId, DateTime? birthdate, string studentNumber, int? gender, string email, string homePhone, string address, int? country, int? city, string userPhoto, string password, string activationCode, bool? isActive, bool? isDeleted, DateTime? activationDate, DateTime? modifyDate, DateTime? createDate)
            {
                SqlParameter[] sqlParams = null;

                try
                {
                    sqlParams = new SqlParameter[] { 
					new SqlParameter("@ID",id),
					new SqlParameter("@Name",name),
					new SqlParameter("@Surname",surname),
					new SqlParameter("@NationalId",nationalId),
					new SqlParameter("@Birthdate",birthdate),
					new SqlParameter("@StudentNumber",studentNumber),
					new SqlParameter("@Gender",gender),
					new SqlParameter("@Email",email),
					new SqlParameter("@HomePhone",homePhone),
					new SqlParameter("@Address",address),
					new SqlParameter("@Country",country),
					new SqlParameter("@City",city),
					new SqlParameter("@UserPhoto",userPhoto),
					new SqlParameter("@Password",password),
					new SqlParameter("@ActivationCode",activationCode),
					new SqlParameter("@IsActive",isActive),
					new SqlParameter("@IsDeleted",isDeleted),
					new SqlParameter("@ActivationDate",activationDate),
					new SqlParameter("@ModifyDate",modifyDate),
					new SqlParameter("@CreateDate",createDate)
                };

                    return ExecuteNonQuery(tran, "BGA_UpdateUsersByParams", sqlParams);

                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "UsersProvider", "UpdateByParams", ArrangeParamValues(sqlParams));
                }
            }

            public static int UpdateByParams(SqlTransaction tran, params SqlParameter[] sqlParams)
            {
                try
                {

                    return ExecuteNonQuery(tran, "BGA_UpdateUsersByParams", sqlParams);

                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "UsersProvider", "UpdateByParams", ArrangeParamValues(sqlParams));
                }
            }
            #endregion

            #region Add Functions
            public static int Add(string name, string surname, string nationalId, DateTime? birthdate, string studentNumber, int gender, string email, string homePhone, string address, int? country, int? city, string userPhoto, string password, string activationCode, bool isActive, bool? isDeleted, DateTime? activationDate, DateTime modifyDate, DateTime createDate)
            {
                SqlParameter[] sqlParams = null;

                try
                {
                    sqlParams = new SqlParameter[] { 
					new SqlParameter("@Name",name),
					new SqlParameter("@Surname",surname),
					new SqlParameter("@NationalId",nationalId),
					new SqlParameter("@Birthdate",birthdate),
					new SqlParameter("@StudentNumber",studentNumber),
					new SqlParameter("@Gender",gender),
					new SqlParameter("@Email",email),
					new SqlParameter("@HomePhone",homePhone),
					new SqlParameter("@Address",address),
					new SqlParameter("@Country",country),
					new SqlParameter("@City",city),
					new SqlParameter("@UserPhoto",userPhoto),
					new SqlParameter("@Password",password),
					new SqlParameter("@ActivationCode",activationCode),
					new SqlParameter("@IsActive",isActive),
					new SqlParameter("@IsDeleted",isDeleted),
					new SqlParameter("@ActivationDate",activationDate),
					new SqlParameter("@ModifyDate",modifyDate),
					new SqlParameter("@CreateDate",createDate)
                };

                    return ExecuteScalar("BGA_AddUsers", sqlParams);

                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "UsersProvider", "Add", ArrangeParamValues(sqlParams));
                }
            }

            public static int Add(SqlTransaction tran, string name, string surname, string nationalId, DateTime? birthdate, string studentNumber, int gender, string email, string homePhone, string address, int? country, int? city, string userPhoto, string password, string activationCode, bool isActive, bool? isDeleted, DateTime? activationDate, DateTime modifyDate, DateTime createDate)
            {
                SqlParameter[] sqlParams = null;

                try
                {
                    sqlParams = new SqlParameter[] { 
					new SqlParameter("@Name",name),
					new SqlParameter("@Surname",surname),
					new SqlParameter("@NationalId",nationalId),
					new SqlParameter("@Birthdate",birthdate),
					new SqlParameter("@StudentNumber",studentNumber),
					new SqlParameter("@Gender",gender),
					new SqlParameter("@Email",email),
					new SqlParameter("@HomePhone",homePhone),
					new SqlParameter("@Address",address),
					new SqlParameter("@Country",country),
					new SqlParameter("@City",city),
					new SqlParameter("@UserPhoto",userPhoto),
					new SqlParameter("@Password",password),
					new SqlParameter("@ActivationCode",activationCode),
					new SqlParameter("@IsActive",isActive),
					new SqlParameter("@IsDeleted",isDeleted),
					new SqlParameter("@ActivationDate",activationDate),
					new SqlParameter("@ModifyDate",modifyDate),
					new SqlParameter("@CreateDate",createDate)
                };

                    return ExecuteScalar(tran, "BGA_AddUsers", sqlParams);

                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "UsersProvider", "Add", ArrangeParamValues(sqlParams));
                }
            }
            #endregion

            #region Delete Functions
            public static int Delete(int id)
            {
                SqlParameter[] sqlParams = null;

                try
                {

                    sqlParams = new SqlParameter[] { 
					new SqlParameter("@ID",id)
                };

                    return ExecuteNonQuery("BGA_DeleteUsers", sqlParams);

                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "UsersProvider", "Delete", ArrangeParamValues(sqlParams));
                }
            }

            public static int Delete(SqlTransaction tran, int id)
            {
                SqlParameter[] sqlParams = null;

                try
                {

                    sqlParams = new SqlParameter[] { 
					new SqlParameter("@ID",id)
                };

                    return ExecuteNonQuery(tran, "BGA_DeleteUsers", sqlParams);

                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "UsersProvider", "Delete", ArrangeParamValues(sqlParams));
                }
            }

            public static int DeleteByParams(SqlTransaction tran, int? id, string name, string surname, string nationalId, DateTime? birthdate, DateTime? beforeBirthdate, DateTime? afterOrEqualBirthdate, string studentNumber, int? gender, string email, string homePhone, string address, int? country, int? city, string userPhoto, string password, string activationCode, bool? isActive, bool? isDeleted, DateTime? activationDate, DateTime? beforeActivationDate, DateTime? afterOrEqualActivationDate, DateTime? modifyDate, DateTime? beforeModifyDate, DateTime? afterOrEqualModifyDate, DateTime? createDate, DateTime? beforeCreateDate, DateTime? afterOrEqualCreateDate)
            {
                SqlParameter[] sqlParams = null;

                try
                {
                    sqlParams = new SqlParameter[] { 
					new SqlParameter("@ID",id),
					new SqlParameter("@Name",name),
					new SqlParameter("@Surname",surname),
					new SqlParameter("@NationalId",nationalId),
					new SqlParameter("@Birthdate",birthdate),
					new SqlParameter("@BeforeBirthdate",beforeBirthdate),
					new SqlParameter("@AfterOrEqualBirthdate",afterOrEqualBirthdate),
					new SqlParameter("@StudentNumber",studentNumber),
					new SqlParameter("@Gender",gender),
					new SqlParameter("@Email",email),
					new SqlParameter("@HomePhone",homePhone),
					new SqlParameter("@Address",address),
					new SqlParameter("@Country",country),
					new SqlParameter("@City",city),
					new SqlParameter("@UserPhoto",userPhoto),
					new SqlParameter("@Password",password),
					new SqlParameter("@ActivationCode",activationCode),
					new SqlParameter("@IsActive",isActive),
					new SqlParameter("@IsDeleted",isDeleted),
					new SqlParameter("@ActivationDate",activationDate),
					new SqlParameter("@BeforeActivationDate",beforeActivationDate),
					new SqlParameter("@AfterOrEqualActivationDate",afterOrEqualActivationDate),
					new SqlParameter("@ModifyDate",modifyDate),
					new SqlParameter("@BeforeModifyDate",beforeModifyDate),
					new SqlParameter("@AfterOrEqualModifyDate",afterOrEqualModifyDate),
					new SqlParameter("@CreateDate",createDate),
					new SqlParameter("@BeforeCreateDate",beforeCreateDate),
					new SqlParameter("@AfterOrEqualCreateDate",afterOrEqualCreateDate)
                };

                    if (tran == null)
                        return ExecuteNonQuery("BGA_DeleteUsersByParams", sqlParams);
                    else
                        return ExecuteNonQuery(tran, "BGA_DeleteUsersByParams", sqlParams);


                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "UsersProvider", "DeleteByParams", ArrangeParamValues(sqlParams));
                }
            }

            public static int DeleteByParams(int? id, string name, string surname, string nationalId, DateTime? birthdate, DateTime? beforeBirthdate, DateTime? afterOrEqualBirthdate, string studentNumber, int? gender, string email, string homePhone, string address, int? country, int? city, string userPhoto, string password, string activationCode, bool? isActive, bool? isDeleted, DateTime? activationDate, DateTime? beforeActivationDate, DateTime? afterOrEqualActivationDate, DateTime? modifyDate, DateTime? beforeModifyDate, DateTime? afterOrEqualModifyDate, DateTime? createDate, DateTime? beforeCreateDate, DateTime? afterOrEqualCreateDate)
            {
                return DeleteByParams(null, id, name, surname, nationalId, birthdate, beforeBirthdate, afterOrEqualBirthdate, studentNumber, gender, email, homePhone, address, country, city, userPhoto, password, activationCode, isActive, isDeleted, activationDate, beforeActivationDate, afterOrEqualActivationDate, modifyDate, beforeModifyDate, afterOrEqualModifyDate, createDate, beforeCreateDate, afterOrEqualCreateDate)
    ;
            }



            #endregion

        }
    }
}
