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

    public partial class FirmUsersProvider : BaseDataLayer
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
                        ds = ExecuteDataset("BGA_GetFirmUsers", sqlParams);
                    else
                        ds = ExecuteDataset(tran, "BGA_GetFirmUsers", sqlParams);

                    return ds;
                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "FirmUsersProvider", "Get", ArrangeParamValues(sqlParams));
                }
            }

            public static DataSet GetByParams(int? id, int? firmId, string name, string surname, string position, string phone, string phoneSuffix, string fax, string email, string password, string userRole, DateTime? modifyDate, DateTime? beforeModifyDate, DateTime? afterOrEqualModifyDate, string modifyBy, DateTime? createDate, DateTime? beforeCreateDate, DateTime? afterOrEqualCreateDate, string createBy)
            {
                return GetByParams(null, id, firmId, name, surname, position, phone, phoneSuffix, fax, email, password, userRole, modifyDate, beforeModifyDate, afterOrEqualModifyDate, modifyBy, createDate, beforeCreateDate, afterOrEqualCreateDate, createBy)
    ;
            }

            public static DataSet GetByParams(SqlTransaction tran, int? id, int? firmId, string name, string surname, string position, string phone, string phoneSuffix, string fax, string email, string password, string userRole, DateTime? modifyDate, DateTime? beforeModifyDate, DateTime? afterOrEqualModifyDate, string modifyBy, DateTime? createDate, DateTime? beforeCreateDate, DateTime? afterOrEqualCreateDate, string createBy)
            {
                SqlParameter[] sqlParams = null;

                try
                {
                    DataSet ds = null;

                    sqlParams = new SqlParameter[] { 
					new SqlParameter("@ID",id),
					new SqlParameter("@FirmId",firmId),
					new SqlParameter("@Name",name),
					new SqlParameter("@Surname",surname),
					new SqlParameter("@Position",position),
					new SqlParameter("@Phone",phone),
					new SqlParameter("@PhoneSuffix",phoneSuffix),
					new SqlParameter("@Fax",fax),
					new SqlParameter("@Email",email),
					new SqlParameter("@Password",password),
					new SqlParameter("@UserRole",userRole),
					new SqlParameter("@ModifyDate",modifyDate),
					new SqlParameter("@BeforeModifyDate",beforeModifyDate),
					new SqlParameter("@AfterOrEqualModifyDate",afterOrEqualModifyDate),
					new SqlParameter("@ModifyBy",modifyBy),
					new SqlParameter("@CreateDate",createDate),
					new SqlParameter("@BeforeCreateDate",beforeCreateDate),
					new SqlParameter("@AfterOrEqualCreateDate",afterOrEqualCreateDate),
					new SqlParameter("@CreateBy",createBy)
                };

                    if (tran == null)
                        ds = ExecuteDataset("BGA_GetFirmUsersByParams", sqlParams);
                    else
                        ds = ExecuteDataset(tran, "BGA_GetFirmUsersByParams", sqlParams);

                    return ds;
                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "FirmUsersProvider", "GetByParams", ArrangeParamValues(sqlParams));
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

                    ds = ExecuteDataset("BGA_GetFirmUsersByParams", sqlParams);

                    return ds;
                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "FirmUsersProvider", "GetByParams", ArrangeParamValues(sqlParams));
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
            public static int Update(int id, int firmId, string name, string surname, string position, string phone, string phoneSuffix, string fax, string email, string password, string userRole, DateTime modifyDate, string modifyBy)
            {
                SqlParameter[] sqlParams = null;

                try
                {
                    sqlParams = new SqlParameter[] { 
					new SqlParameter("@ID",id),
					new SqlParameter("@FirmId",firmId),
					new SqlParameter("@Name",name),
					new SqlParameter("@Surname",surname),
					new SqlParameter("@Position",position),
					new SqlParameter("@Phone",phone),
					new SqlParameter("@PhoneSuffix",phoneSuffix),
					new SqlParameter("@Fax",fax),
					new SqlParameter("@Email",email),
					new SqlParameter("@Password",password),
					new SqlParameter("@UserRole",userRole),
					new SqlParameter("@ModifyDate",modifyDate),
					new SqlParameter("@ModifyBy",modifyBy)
                };

                    return ExecuteNonQuery("BGA_UpdateFirmUsers", sqlParams);

                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "FirmUsersProvider", "Update", ArrangeParamValues(sqlParams));
                }
            }

            public static int Update(SqlTransaction tran, int id, int firmId, string name, string surname, string position, string phone, string phoneSuffix, string fax, string email, string password, string userRole, DateTime modifyDate, string modifyBy)
            {
                SqlParameter[] sqlParams = null;

                try
                {
                    sqlParams = new SqlParameter[] { 
					new SqlParameter("@ID",id),
					new SqlParameter("@FirmId",firmId),
					new SqlParameter("@Name",name),
					new SqlParameter("@Surname",surname),
					new SqlParameter("@Position",position),
					new SqlParameter("@Phone",phone),
					new SqlParameter("@PhoneSuffix",phoneSuffix),
					new SqlParameter("@Fax",fax),
					new SqlParameter("@Email",email),
					new SqlParameter("@Password",password),
					new SqlParameter("@UserRole",userRole),
					new SqlParameter("@ModifyDate",modifyDate),
					new SqlParameter("@ModifyBy",modifyBy)
                };

                    return ExecuteNonQuery(tran, "BGA_UpdateFirmUsers", sqlParams);

                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "FirmUsersProvider", "Update", ArrangeParamValues(sqlParams));
                }
            }

            public static int UpdateByParams(int id, int? firmId, string name, string surname, string position, string phone, string phoneSuffix, string fax, string email, string password, string userRole, DateTime? modifyDate, string modifyBy, DateTime? createDate, string createBy)
            {
                SqlParameter[] sqlParams = null;

                try
                {
                    sqlParams = new SqlParameter[] { 
					new SqlParameter("@ID",id),
					new SqlParameter("@FirmId",firmId),
					new SqlParameter("@Name",name),
					new SqlParameter("@Surname",surname),
					new SqlParameter("@Position",position),
					new SqlParameter("@Phone",phone),
					new SqlParameter("@PhoneSuffix",phoneSuffix),
					new SqlParameter("@Fax",fax),
					new SqlParameter("@Email",email),
					new SqlParameter("@Password",password),
					new SqlParameter("@UserRole",userRole),
					new SqlParameter("@ModifyDate",modifyDate),
					new SqlParameter("@ModifyBy",modifyBy),
					new SqlParameter("@CreateDate",createDate),
					new SqlParameter("@CreateBy",createBy)
                };

                    return ExecuteNonQuery("BGA_UpdateFirmUsersByParams", sqlParams);

                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "FirmUsersProvider", "UpdateByParams", ArrangeParamValues(sqlParams));
                }
            }

            public static int UpdateByParams(params SqlParameter[] sqlParams)
            {
                try
                {

                    return ExecuteNonQuery("BGA_UpdateFirmUsersByParams", sqlParams);

                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "FirmUsersProvider", "UpdateByParams", ArrangeParamValues(sqlParams));
                }
            }

            public static int UpdateByParams(SqlTransaction tran, int id, int? firmId, string name, string surname, string position, string phone, string phoneSuffix, string fax, string email, string password, string userRole, DateTime? modifyDate, string modifyBy, DateTime? createDate, string createBy)
            {
                SqlParameter[] sqlParams = null;

                try
                {
                    sqlParams = new SqlParameter[] { 
					new SqlParameter("@ID",id),
					new SqlParameter("@FirmId",firmId),
					new SqlParameter("@Name",name),
					new SqlParameter("@Surname",surname),
					new SqlParameter("@Position",position),
					new SqlParameter("@Phone",phone),
					new SqlParameter("@PhoneSuffix",phoneSuffix),
					new SqlParameter("@Fax",fax),
					new SqlParameter("@Email",email),
					new SqlParameter("@Password",password),
					new SqlParameter("@UserRole",userRole),
					new SqlParameter("@ModifyDate",modifyDate),
					new SqlParameter("@ModifyBy",modifyBy),
					new SqlParameter("@CreateDate",createDate),
					new SqlParameter("@CreateBy",createBy)
                };

                    return ExecuteNonQuery(tran, "BGA_UpdateFirmUsersByParams", sqlParams);

                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "FirmUsersProvider", "UpdateByParams", ArrangeParamValues(sqlParams));
                }
            }

            public static int UpdateByParams(SqlTransaction tran, params SqlParameter[] sqlParams)
            {
                try
                {

                    return ExecuteNonQuery(tran, "BGA_UpdateFirmUsersByParams", sqlParams);

                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "FirmUsersProvider", "UpdateByParams", ArrangeParamValues(sqlParams));
                }
            }
            #endregion

            #region Add Functions
            public static int Add(int firmId, string name, string surname, string position, string phone, string phoneSuffix, string fax, string email, string password, string userRole, DateTime modifyDate, string modifyBy, DateTime createDate, string createBy)
            {
                SqlParameter[] sqlParams = null;

                try
                {
                    sqlParams = new SqlParameter[] { 
					new SqlParameter("@FirmId",firmId),
					new SqlParameter("@Name",name),
					new SqlParameter("@Surname",surname),
					new SqlParameter("@Position",position),
					new SqlParameter("@Phone",phone),
					new SqlParameter("@PhoneSuffix",phoneSuffix),
					new SqlParameter("@Fax",fax),
					new SqlParameter("@Email",email),
					new SqlParameter("@Password",password),
					new SqlParameter("@UserRole",userRole),
					new SqlParameter("@ModifyDate",modifyDate),
					new SqlParameter("@ModifyBy",modifyBy),
					new SqlParameter("@CreateDate",createDate),
					new SqlParameter("@CreateBy",createBy)
                };

                    return ExecuteScalar("BGA_AddFirmUsers", sqlParams);

                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "FirmUsersProvider", "Add", ArrangeParamValues(sqlParams));
                }
            }

            public static int Add(SqlTransaction tran, int firmId, string name, string surname, string position, string phone, string phoneSuffix, string fax, string email, string password, string userRole, DateTime modifyDate, string modifyBy, DateTime createDate, string createBy)
            {
                SqlParameter[] sqlParams = null;

                try
                {
                    sqlParams = new SqlParameter[] { 
					new SqlParameter("@FirmId",firmId),
					new SqlParameter("@Name",name),
					new SqlParameter("@Surname",surname),
					new SqlParameter("@Position",position),
					new SqlParameter("@Phone",phone),
					new SqlParameter("@PhoneSuffix",phoneSuffix),
					new SqlParameter("@Fax",fax),
					new SqlParameter("@Email",email),
					new SqlParameter("@Password",password),
					new SqlParameter("@UserRole",userRole),
					new SqlParameter("@ModifyDate",modifyDate),
					new SqlParameter("@ModifyBy",modifyBy),
					new SqlParameter("@CreateDate",createDate),
					new SqlParameter("@CreateBy",createBy)
                };

                    return ExecuteScalar(tran, "BGA_AddFirmUsers", sqlParams);

                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "FirmUsersProvider", "Add", ArrangeParamValues(sqlParams));
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

                    return ExecuteNonQuery("BGA_DeleteFirmUsers", sqlParams);

                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "FirmUsersProvider", "Delete", ArrangeParamValues(sqlParams));
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

                    return ExecuteNonQuery(tran, "BGA_DeleteFirmUsers", sqlParams);

                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "FirmUsersProvider", "Delete", ArrangeParamValues(sqlParams));
                }
            }

            public static int DeleteByParams(SqlTransaction tran, int? id, int? firmId, string name, string surname, string position, string phone, string phoneSuffix, string fax, string email, string password, string userRole, DateTime? modifyDate, DateTime? beforeModifyDate, DateTime? afterOrEqualModifyDate, string modifyBy, DateTime? createDate, DateTime? beforeCreateDate, DateTime? afterOrEqualCreateDate, string createBy)
            {
                SqlParameter[] sqlParams = null;

                try
                {
                    sqlParams = new SqlParameter[] { 
					new SqlParameter("@ID",id),
					new SqlParameter("@FirmId",firmId),
					new SqlParameter("@Name",name),
					new SqlParameter("@Surname",surname),
					new SqlParameter("@Position",position),
					new SqlParameter("@Phone",phone),
					new SqlParameter("@PhoneSuffix",phoneSuffix),
					new SqlParameter("@Fax",fax),
					new SqlParameter("@Email",email),
					new SqlParameter("@Password",password),
					new SqlParameter("@UserRole",userRole),
					new SqlParameter("@ModifyDate",modifyDate),
					new SqlParameter("@BeforeModifyDate",beforeModifyDate),
					new SqlParameter("@AfterOrEqualModifyDate",afterOrEqualModifyDate),
					new SqlParameter("@ModifyBy",modifyBy),
					new SqlParameter("@CreateDate",createDate),
					new SqlParameter("@BeforeCreateDate",beforeCreateDate),
					new SqlParameter("@AfterOrEqualCreateDate",afterOrEqualCreateDate),
					new SqlParameter("@CreateBy",createBy)
                };

                    if (tran == null)
                        return ExecuteNonQuery("BGA_DeleteFirmUsersByParams", sqlParams);
                    else
                        return ExecuteNonQuery(tran, "BGA_DeleteFirmUsersByParams", sqlParams);


                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "FirmUsersProvider", "DeleteByParams", ArrangeParamValues(sqlParams));
                }
            }

            public static int DeleteByParams(int? id, int? firmId, string name, string surname, string position, string phone, string phoneSuffix, string fax, string email, string password, string userRole, DateTime? modifyDate, DateTime? beforeModifyDate, DateTime? afterOrEqualModifyDate, string modifyBy, DateTime? createDate, DateTime? beforeCreateDate, DateTime? afterOrEqualCreateDate, string createBy)
            {
                return DeleteByParams(null, id, firmId, name, surname, position, phone, phoneSuffix, fax, email, password, userRole, modifyDate, beforeModifyDate, afterOrEqualModifyDate, modifyBy, createDate, beforeCreateDate, afterOrEqualCreateDate, createBy)
    ;
            }



            #endregion

        }
    }
}
