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

    public partial class FirmsProvider : BaseDataLayer
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
                        ds = ExecuteDataset("BGA_GetFirms", sqlParams);
                    else
                        ds = ExecuteDataset(tran, "BGA_GetFirms", sqlParams);

                    return ds;
                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "FirmsProvider", "Get", ArrangeParamValues(sqlParams));
                }
            }

            public static DataSet GetByParams(int? id, string name, string sector, int? workerCount, string address, string zipcode, int? country, int? city, string description, string webpage, bool? isActive, DateTime? activationDate, DateTime? beforeActivationDate, DateTime? afterOrEqualActivationDate, DateTime? modifyDate, DateTime? beforeModifyDate, DateTime? afterOrEqualModifyDate, DateTime? createDate, DateTime? beforeCreateDate, DateTime? afterOrEqualCreateDate, bool? isDeleted)
            {
                return GetByParams(null, id, name, sector, workerCount, address, zipcode, country, city, description, webpage, isActive, activationDate, beforeActivationDate, afterOrEqualActivationDate, modifyDate, beforeModifyDate, afterOrEqualModifyDate, createDate, beforeCreateDate, afterOrEqualCreateDate, isDeleted)
    ;
            }

            public static DataSet GetByParams(SqlTransaction tran, int? id, string name, string sector, int? workerCount, string address, string zipcode, int? country, int? city, string description, string webpage, bool? isActive, DateTime? activationDate, DateTime? beforeActivationDate, DateTime? afterOrEqualActivationDate, DateTime? modifyDate, DateTime? beforeModifyDate, DateTime? afterOrEqualModifyDate, DateTime? createDate, DateTime? beforeCreateDate, DateTime? afterOrEqualCreateDate, bool? isDeleted)
            {
                SqlParameter[] sqlParams = null;

                try
                {
                    DataSet ds = null;

                    sqlParams = new SqlParameter[] { 
					new SqlParameter("@ID",id),
					new SqlParameter("@Name",name),
					new SqlParameter("@Sector",sector),
					new SqlParameter("@WorkerCount",workerCount),
					new SqlParameter("@Address",address),
					new SqlParameter("@Zipcode",zipcode),
					new SqlParameter("@Country",country),
					new SqlParameter("@City",city),
					new SqlParameter("@Description",description),
					new SqlParameter("@Webpage",webpage),
					new SqlParameter("@IsActive",isActive),
					new SqlParameter("@ActivationDate",activationDate),
					new SqlParameter("@BeforeActivationDate",beforeActivationDate),
					new SqlParameter("@AfterOrEqualActivationDate",afterOrEqualActivationDate),
					new SqlParameter("@ModifyDate",modifyDate),
					new SqlParameter("@BeforeModifyDate",beforeModifyDate),
					new SqlParameter("@AfterOrEqualModifyDate",afterOrEqualModifyDate),
					new SqlParameter("@CreateDate",createDate),
					new SqlParameter("@BeforeCreateDate",beforeCreateDate),
					new SqlParameter("@AfterOrEqualCreateDate",afterOrEqualCreateDate),
					new SqlParameter("@IsDeleted",isDeleted)
                };

                    if (tran == null)
                        ds = ExecuteDataset("BGA_GetFirmsByParams", sqlParams);
                    else
                        ds = ExecuteDataset(tran, "BGA_GetFirmsByParams", sqlParams);

                    return ds;
                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "FirmsProvider", "GetByParams", ArrangeParamValues(sqlParams));
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

                    ds = ExecuteDataset("BGA_GetFirmsByParams", sqlParams);

                    return ds;
                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "FirmsProvider", "GetByParams", ArrangeParamValues(sqlParams));
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
            public static int Update(int id, string name, string sector, int workerCount, string address, string zipcode, int? country, int? city, string description, string webpage, bool isActive, DateTime? activationDate, DateTime modifyDate, bool isDeleted)
            {
                SqlParameter[] sqlParams = null;

                try
                {
                    sqlParams = new SqlParameter[] { 
					new SqlParameter("@ID",id),
					new SqlParameter("@Name",name),
					new SqlParameter("@Sector",sector),
					new SqlParameter("@WorkerCount",workerCount),
					new SqlParameter("@Address",address),
					new SqlParameter("@Zipcode",zipcode),
					new SqlParameter("@Country",country),
					new SqlParameter("@City",city),
					new SqlParameter("@Description",description),
					new SqlParameter("@Webpage",webpage),
					new SqlParameter("@IsActive",isActive),
					new SqlParameter("@ActivationDate",activationDate),
					new SqlParameter("@ModifyDate",modifyDate),
					new SqlParameter("@IsDeleted",isDeleted)
                };

                    return ExecuteNonQuery("BGA_UpdateFirms", sqlParams);

                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "FirmsProvider", "Update", ArrangeParamValues(sqlParams));
                }
            }

            public static int Update(SqlTransaction tran, int id, string name, string sector, int workerCount, string address, string zipcode, int? country, int? city, string description, string webpage, bool isActive, DateTime? activationDate, DateTime modifyDate, bool isDeleted)
            {
                SqlParameter[] sqlParams = null;

                try
                {
                    sqlParams = new SqlParameter[] { 
					new SqlParameter("@ID",id),
					new SqlParameter("@Name",name),
					new SqlParameter("@Sector",sector),
					new SqlParameter("@WorkerCount",workerCount),
					new SqlParameter("@Address",address),
					new SqlParameter("@Zipcode",zipcode),
					new SqlParameter("@Country",country),
					new SqlParameter("@City",city),
					new SqlParameter("@Description",description),
					new SqlParameter("@Webpage",webpage),
					new SqlParameter("@IsActive",isActive),
					new SqlParameter("@ActivationDate",activationDate),
					new SqlParameter("@ModifyDate",modifyDate),
					new SqlParameter("@IsDeleted",isDeleted)
                };

                    return ExecuteNonQuery(tran, "BGA_UpdateFirms", sqlParams);

                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "FirmsProvider", "Update", ArrangeParamValues(sqlParams));
                }
            }

            public static int UpdateByParams(int id, string name, string sector, int? workerCount, string address, string zipcode, int? country, int? city, string description, string webpage, bool? isActive, DateTime? activationDate, DateTime? modifyDate, DateTime? createDate, bool? isDeleted)
            {
                SqlParameter[] sqlParams = null;

                try
                {
                    sqlParams = new SqlParameter[] { 
					new SqlParameter("@ID",id),
					new SqlParameter("@Name",name),
					new SqlParameter("@Sector",sector),
					new SqlParameter("@WorkerCount",workerCount),
					new SqlParameter("@Address",address),
					new SqlParameter("@Zipcode",zipcode),
					new SqlParameter("@Country",country),
					new SqlParameter("@City",city),
					new SqlParameter("@Description",description),
					new SqlParameter("@Webpage",webpage),
					new SqlParameter("@IsActive",isActive),
					new SqlParameter("@ActivationDate",activationDate),
					new SqlParameter("@ModifyDate",modifyDate),
					new SqlParameter("@CreateDate",createDate),
					new SqlParameter("@IsDeleted",isDeleted)
                };

                    return ExecuteNonQuery("BGA_UpdateFirmsByParams", sqlParams);

                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "FirmsProvider", "UpdateByParams", ArrangeParamValues(sqlParams));
                }
            }

            public static int UpdateByParams(params SqlParameter[] sqlParams)
            {
                try
                {

                    return ExecuteNonQuery("BGA_UpdateFirmsByParams", sqlParams);

                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "FirmsProvider", "UpdateByParams", ArrangeParamValues(sqlParams));
                }
            }

            public static int UpdateByParams(SqlTransaction tran, int id, string name, string sector, int? workerCount, string address, string zipcode, int? country, int? city, string description, string webpage, bool? isActive, DateTime? activationDate, DateTime? modifyDate, DateTime? createDate, bool? isDeleted)
            {
                SqlParameter[] sqlParams = null;

                try
                {
                    sqlParams = new SqlParameter[] { 
					new SqlParameter("@ID",id),
					new SqlParameter("@Name",name),
					new SqlParameter("@Sector",sector),
					new SqlParameter("@WorkerCount",workerCount),
					new SqlParameter("@Address",address),
					new SqlParameter("@Zipcode",zipcode),
					new SqlParameter("@Country",country),
					new SqlParameter("@City",city),
					new SqlParameter("@Description",description),
					new SqlParameter("@Webpage",webpage),
					new SqlParameter("@IsActive",isActive),
					new SqlParameter("@ActivationDate",activationDate),
					new SqlParameter("@ModifyDate",modifyDate),
					new SqlParameter("@CreateDate",createDate),
					new SqlParameter("@IsDeleted",isDeleted)
                };

                    return ExecuteNonQuery(tran, "BGA_UpdateFirmsByParams", sqlParams);

                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "FirmsProvider", "UpdateByParams", ArrangeParamValues(sqlParams));
                }
            }

            public static int UpdateByParams(SqlTransaction tran, params SqlParameter[] sqlParams)
            {
                try
                {

                    return ExecuteNonQuery(tran, "BGA_UpdateFirmsByParams", sqlParams);

                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "FirmsProvider", "UpdateByParams", ArrangeParamValues(sqlParams));
                }
            }
            #endregion

            #region Add Functions
            public static int Add(string name, string sector, int workerCount, string address, string zipcode, int? country, int? city, string description, string webpage, bool isActive, DateTime? activationDate, DateTime modifyDate, DateTime createDate, bool isDeleted)
            {
                SqlParameter[] sqlParams = null;

                try
                {
                    sqlParams = new SqlParameter[] { 
					new SqlParameter("@Name",name),
					new SqlParameter("@Sector",sector),
					new SqlParameter("@WorkerCount",workerCount),
					new SqlParameter("@Address",address),
					new SqlParameter("@Zipcode",zipcode),
					new SqlParameter("@Country",country),
					new SqlParameter("@City",city),
					new SqlParameter("@Description",description),
					new SqlParameter("@Webpage",webpage),
					new SqlParameter("@IsActive",isActive),
					new SqlParameter("@ActivationDate",activationDate),
					new SqlParameter("@ModifyDate",modifyDate),
					new SqlParameter("@CreateDate",createDate),
					new SqlParameter("@IsDeleted",isDeleted)
                };

                    return ExecuteScalar("BGA_AddFirms", sqlParams);

                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "FirmsProvider", "Add", ArrangeParamValues(sqlParams));
                }
            }

            public static int Add(SqlTransaction tran, string name, string sector, int workerCount, string address, string zipcode, int? country, int? city, string description, string webpage, bool isActive, DateTime? activationDate, DateTime modifyDate, DateTime createDate, bool isDeleted)
            {
                SqlParameter[] sqlParams = null;

                try
                {
                    sqlParams = new SqlParameter[] { 
					new SqlParameter("@Name",name),
					new SqlParameter("@Sector",sector),
					new SqlParameter("@WorkerCount",workerCount),
					new SqlParameter("@Address",address),
					new SqlParameter("@Zipcode",zipcode),
					new SqlParameter("@Country",country),
					new SqlParameter("@City",city),
					new SqlParameter("@Description",description),
					new SqlParameter("@Webpage",webpage),
					new SqlParameter("@IsActive",isActive),
					new SqlParameter("@ActivationDate",activationDate),
					new SqlParameter("@ModifyDate",modifyDate),
					new SqlParameter("@CreateDate",createDate),
					new SqlParameter("@IsDeleted",isDeleted)
                };

                    return ExecuteScalar(tran, "BGA_AddFirms", sqlParams);

                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "FirmsProvider", "Add", ArrangeParamValues(sqlParams));
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

                    return ExecuteNonQuery("BGA_DeleteFirms", sqlParams);

                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "FirmsProvider", "Delete", ArrangeParamValues(sqlParams));
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

                    return ExecuteNonQuery(tran, "BGA_DeleteFirms", sqlParams);

                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "FirmsProvider", "Delete", ArrangeParamValues(sqlParams));
                }
            }

            public static int DeleteByParams(SqlTransaction tran, int? id, string name, string sector, int? workerCount, string address, string zipcode, int? country, int? city, string description, string webpage, bool? isActive, DateTime? activationDate, DateTime? beforeActivationDate, DateTime? afterOrEqualActivationDate, DateTime? modifyDate, DateTime? beforeModifyDate, DateTime? afterOrEqualModifyDate, DateTime? createDate, DateTime? beforeCreateDate, DateTime? afterOrEqualCreateDate, bool? isDeleted)
            {
                SqlParameter[] sqlParams = null;

                try
                {
                    sqlParams = new SqlParameter[] { 
					new SqlParameter("@ID",id),
					new SqlParameter("@Name",name),
					new SqlParameter("@Sector",sector),
					new SqlParameter("@WorkerCount",workerCount),
					new SqlParameter("@Address",address),
					new SqlParameter("@Zipcode",zipcode),
					new SqlParameter("@Country",country),
					new SqlParameter("@City",city),
					new SqlParameter("@Description",description),
					new SqlParameter("@Webpage",webpage),
					new SqlParameter("@IsActive",isActive),
					new SqlParameter("@ActivationDate",activationDate),
					new SqlParameter("@BeforeActivationDate",beforeActivationDate),
					new SqlParameter("@AfterOrEqualActivationDate",afterOrEqualActivationDate),
					new SqlParameter("@ModifyDate",modifyDate),
					new SqlParameter("@BeforeModifyDate",beforeModifyDate),
					new SqlParameter("@AfterOrEqualModifyDate",afterOrEqualModifyDate),
					new SqlParameter("@CreateDate",createDate),
					new SqlParameter("@BeforeCreateDate",beforeCreateDate),
					new SqlParameter("@AfterOrEqualCreateDate",afterOrEqualCreateDate),
					new SqlParameter("@IsDeleted",isDeleted)
                };

                    if (tran == null)
                        return ExecuteNonQuery("BGA_DeleteFirmsByParams", sqlParams);
                    else
                        return ExecuteNonQuery(tran, "BGA_DeleteFirmsByParams", sqlParams);


                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "FirmsProvider", "DeleteByParams", ArrangeParamValues(sqlParams));
                }
            }

            public static int DeleteByParams(int? id, string name, string sector, int? workerCount, string address, string zipcode, int? country, int? city, string description, string webpage, bool? isActive, DateTime? activationDate, DateTime? beforeActivationDate, DateTime? afterOrEqualActivationDate, DateTime? modifyDate, DateTime? beforeModifyDate, DateTime? afterOrEqualModifyDate, DateTime? createDate, DateTime? beforeCreateDate, DateTime? afterOrEqualCreateDate, bool? isDeleted)
            {
                return DeleteByParams(null, id, name, sector, workerCount, address, zipcode, country, city, description, webpage, isActive, activationDate, beforeActivationDate, afterOrEqualActivationDate, modifyDate, beforeModifyDate, afterOrEqualModifyDate, createDate, beforeCreateDate, afterOrEqualCreateDate, isDeleted)
    ;
            }



            #endregion

        }
    }
}
