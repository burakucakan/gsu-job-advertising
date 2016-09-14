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

    public partial class AdvertisementsProvider : BaseDataLayer
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
                        ds = ExecuteDataset("BGA_GetAdvertisements", sqlParams);
                    else
                        ds = ExecuteDataset(tran, "BGA_GetAdvertisements", sqlParams);

                    return ds;
                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "AdvertisementsProvider", "Get", ArrangeParamValues(sqlParams));
                }
            }

            public static DataSet GetByParams(int? id, int? firmId, string title, string detail, string description, DateTime? startDate, DateTime? beforeStartDate, DateTime? afterOrEqualStartDate, DateTime? endDate, DateTime? beforeEndDate, DateTime? afterOrEqualEndDate, string workPosition, int? type, string city, string country, int? employeesCount, int? state, DateTime? modifyDate, DateTime? beforeModifyDate, DateTime? afterOrEqualModifyDate, int? modifyBy, DateTime? createDate, DateTime? beforeCreateDate, DateTime? afterOrEqualCreateDate, int? createBy, bool? isDeleted)
            {
                return GetByParams(null, id, firmId, title, detail, description, startDate, beforeStartDate, afterOrEqualStartDate, endDate, beforeEndDate, afterOrEqualEndDate, workPosition, type, city, country, employeesCount, state, modifyDate, beforeModifyDate, afterOrEqualModifyDate, modifyBy, createDate, beforeCreateDate, afterOrEqualCreateDate, createBy, isDeleted)
    ;
            }

            public static DataSet GetByParams(SqlTransaction tran, int? id, int? firmId, string title, string detail, string description, DateTime? startDate, DateTime? beforeStartDate, DateTime? afterOrEqualStartDate, DateTime? endDate, DateTime? beforeEndDate, DateTime? afterOrEqualEndDate, string workPosition, int? type, string city, string country, int? employeesCount, int? state, DateTime? modifyDate, DateTime? beforeModifyDate, DateTime? afterOrEqualModifyDate, int? modifyBy, DateTime? createDate, DateTime? beforeCreateDate, DateTime? afterOrEqualCreateDate, int? createBy, bool? isDeleted)
            {
                SqlParameter[] sqlParams = null;

                try
                {
                    DataSet ds = null;

                    sqlParams = new SqlParameter[] { 
					new SqlParameter("@ID",id),
					new SqlParameter("@FirmId",firmId),
					new SqlParameter("@Title",title),
					new SqlParameter("@Detail",detail),
					new SqlParameter("@Description",description),
					new SqlParameter("@StartDate",startDate),
					new SqlParameter("@BeforeStartDate",beforeStartDate),
					new SqlParameter("@AfterOrEqualStartDate",afterOrEqualStartDate),
					new SqlParameter("@EndDate",endDate),
					new SqlParameter("@BeforeEndDate",beforeEndDate),
					new SqlParameter("@AfterOrEqualEndDate",afterOrEqualEndDate),
					new SqlParameter("@WorkPosition",workPosition),
					new SqlParameter("@Type",type),
					new SqlParameter("@City",city),
					new SqlParameter("@Country",country),
					new SqlParameter("@EmployeesCount",employeesCount),
					new SqlParameter("@State",state),
					new SqlParameter("@ModifyDate",modifyDate),
					new SqlParameter("@BeforeModifyDate",beforeModifyDate),
					new SqlParameter("@AfterOrEqualModifyDate",afterOrEqualModifyDate),
					new SqlParameter("@ModifyBy",modifyBy),
					new SqlParameter("@CreateDate",createDate),
					new SqlParameter("@BeforeCreateDate",beforeCreateDate),
					new SqlParameter("@AfterOrEqualCreateDate",afterOrEqualCreateDate),
					new SqlParameter("@CreateBy",createBy),
					new SqlParameter("@IsDeleted",isDeleted)
                };

                    if (tran == null)
                        ds = ExecuteDataset("BGA_GetAdvertisementsByParams", sqlParams);
                    else
                        ds = ExecuteDataset(tran, "BGA_GetAdvertisementsByParams", sqlParams);

                    return ds;
                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "AdvertisementsProvider", "GetByParams", ArrangeParamValues(sqlParams));
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

                    ds = ExecuteDataset("BGA_GetAdvertisementsByParams", sqlParams);

                    return ds;
                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "AdvertisementsProvider", "GetByParams", ArrangeParamValues(sqlParams));
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
            public static int Update(int id, int firmId, string title, string detail, string description, DateTime? startDate, DateTime? endDate, string workPosition, int? type, string city, string country, int? employeesCount, int? state, DateTime modifyDate, int modifyBy, bool isDeleted)
            {
                SqlParameter[] sqlParams = null;

                try
                {
                    sqlParams = new SqlParameter[] { 
					new SqlParameter("@ID",id),
					new SqlParameter("@FirmId",firmId),
					new SqlParameter("@Title",title),
					new SqlParameter("@Detail",detail),
					new SqlParameter("@Description",description),
					new SqlParameter("@StartDate",startDate),
					new SqlParameter("@EndDate",endDate),
					new SqlParameter("@WorkPosition",workPosition),
					new SqlParameter("@Type",type),
					new SqlParameter("@City",city),
					new SqlParameter("@Country",country),
					new SqlParameter("@EmployeesCount",employeesCount),
					new SqlParameter("@State",state),
					new SqlParameter("@ModifyDate",modifyDate),
					new SqlParameter("@ModifyBy",modifyBy),
					new SqlParameter("@IsDeleted",isDeleted)
                };

                    return ExecuteNonQuery("BGA_UpdateAdvertisements", sqlParams);

                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "AdvertisementsProvider", "Update", ArrangeParamValues(sqlParams));
                }
            }

            public static int Update(SqlTransaction tran, int id, int firmId, string title, string detail, string description, DateTime? startDate, DateTime? endDate, string workPosition, int? type, string city, string country, int? employeesCount, int? state, DateTime modifyDate, int modifyBy, bool isDeleted)
            {
                SqlParameter[] sqlParams = null;

                try
                {
                    sqlParams = new SqlParameter[] { 
					new SqlParameter("@ID",id),
					new SqlParameter("@FirmId",firmId),
					new SqlParameter("@Title",title),
					new SqlParameter("@Detail",detail),
					new SqlParameter("@Description",description),
					new SqlParameter("@StartDate",startDate),
					new SqlParameter("@EndDate",endDate),
					new SqlParameter("@WorkPosition",workPosition),
					new SqlParameter("@Type",type),
					new SqlParameter("@City",city),
					new SqlParameter("@Country",country),
					new SqlParameter("@EmployeesCount",employeesCount),
					new SqlParameter("@State",state),
					new SqlParameter("@ModifyDate",modifyDate),
					new SqlParameter("@ModifyBy",modifyBy),
					new SqlParameter("@IsDeleted",isDeleted)
                };

                    return ExecuteNonQuery(tran, "BGA_UpdateAdvertisements", sqlParams);

                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "AdvertisementsProvider", "Update", ArrangeParamValues(sqlParams));
                }
            }

            public static int UpdateByParams(int id, int? firmId, string title, string detail, string description, DateTime? startDate, DateTime? endDate, string workPosition, int? type, string city, string country, int? employeesCount, int? state, DateTime? modifyDate, int? modifyBy, DateTime? createDate, int? createBy, bool? isDeleted)
            {
                SqlParameter[] sqlParams = null;

                try
                {
                    sqlParams = new SqlParameter[] { 
					new SqlParameter("@ID",id),
					new SqlParameter("@FirmId",firmId),
					new SqlParameter("@Title",title),
					new SqlParameter("@Detail",detail),
					new SqlParameter("@Description",description),
					new SqlParameter("@StartDate",startDate),
					new SqlParameter("@EndDate",endDate),
					new SqlParameter("@WorkPosition",workPosition),
					new SqlParameter("@Type",type),
					new SqlParameter("@City",city),
					new SqlParameter("@Country",country),
					new SqlParameter("@EmployeesCount",employeesCount),
					new SqlParameter("@State",state),
					new SqlParameter("@ModifyDate",modifyDate),
					new SqlParameter("@ModifyBy",modifyBy),
					new SqlParameter("@CreateDate",createDate),
					new SqlParameter("@CreateBy",createBy),
					new SqlParameter("@IsDeleted",isDeleted)
                };

                    return ExecuteNonQuery("BGA_UpdateAdvertisementsByParams", sqlParams);

                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "AdvertisementsProvider", "UpdateByParams", ArrangeParamValues(sqlParams));
                }
            }

            public static int UpdateByParams(params SqlParameter[] sqlParams)
            {
                try
                {

                    return ExecuteNonQuery("BGA_UpdateAdvertisementsByParams", sqlParams);

                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "AdvertisementsProvider", "UpdateByParams", ArrangeParamValues(sqlParams));
                }
            }

            public static int UpdateByParams(SqlTransaction tran, int id, int? firmId, string title, string detail, string description, DateTime? startDate, DateTime? endDate, string workPosition, int? type, string city, string country, int? employeesCount, int? state, DateTime? modifyDate, int? modifyBy, DateTime? createDate, int? createBy, bool? isDeleted)
            {
                SqlParameter[] sqlParams = null;

                try
                {
                    sqlParams = new SqlParameter[] { 
					new SqlParameter("@ID",id),
					new SqlParameter("@FirmId",firmId),
					new SqlParameter("@Title",title),
					new SqlParameter("@Detail",detail),
					new SqlParameter("@Description",description),
					new SqlParameter("@StartDate",startDate),
					new SqlParameter("@EndDate",endDate),
					new SqlParameter("@WorkPosition",workPosition),
					new SqlParameter("@Type",type),
					new SqlParameter("@City",city),
					new SqlParameter("@Country",country),
					new SqlParameter("@EmployeesCount",employeesCount),
					new SqlParameter("@State",state),
					new SqlParameter("@ModifyDate",modifyDate),
					new SqlParameter("@ModifyBy",modifyBy),
					new SqlParameter("@CreateDate",createDate),
					new SqlParameter("@CreateBy",createBy),
					new SqlParameter("@IsDeleted",isDeleted)
                };

                    return ExecuteNonQuery(tran, "BGA_UpdateAdvertisementsByParams", sqlParams);

                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "AdvertisementsProvider", "UpdateByParams", ArrangeParamValues(sqlParams));
                }
            }

            public static int UpdateByParams(SqlTransaction tran, params SqlParameter[] sqlParams)
            {
                try
                {

                    return ExecuteNonQuery(tran, "BGA_UpdateAdvertisementsByParams", sqlParams);

                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "AdvertisementsProvider", "UpdateByParams", ArrangeParamValues(sqlParams));
                }
            }
            #endregion

            #region Add Functions
            public static int Add(int firmId, string title, string detail, string description, DateTime? startDate, DateTime? endDate, string workPosition, int? type, string city, string country, int? employeesCount, int? state, DateTime modifyDate, int modifyBy, DateTime createDate, int createBy, bool isDeleted)
            {
                SqlParameter[] sqlParams = null;

                try
                {
                    sqlParams = new SqlParameter[] { 
					new SqlParameter("@FirmId",firmId),
					new SqlParameter("@Title",title),
					new SqlParameter("@Detail",detail),
					new SqlParameter("@Description",description),
					new SqlParameter("@StartDate",startDate),
					new SqlParameter("@EndDate",endDate),
					new SqlParameter("@WorkPosition",workPosition),
					new SqlParameter("@Type",type),
					new SqlParameter("@City",city),
					new SqlParameter("@Country",country),
					new SqlParameter("@EmployeesCount",employeesCount),
					new SqlParameter("@State",state),
					new SqlParameter("@ModifyDate",modifyDate),
					new SqlParameter("@ModifyBy",modifyBy),
					new SqlParameter("@CreateDate",createDate),
					new SqlParameter("@CreateBy",createBy),
					new SqlParameter("@IsDeleted",isDeleted)
                };

                    return ExecuteScalar("BGA_AddAdvertisements", sqlParams);

                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "AdvertisementsProvider", "Add", ArrangeParamValues(sqlParams));
                }
            }

            public static int Add(SqlTransaction tran, int firmId, string title, string detail, string description, DateTime? startDate, DateTime? endDate, string workPosition, int? type, string city, string country, int? employeesCount, int? state, DateTime modifyDate, int modifyBy, DateTime createDate, int createBy, bool isDeleted)
            {
                SqlParameter[] sqlParams = null;

                try
                {
                    sqlParams = new SqlParameter[] { 
					new SqlParameter("@FirmId",firmId),
					new SqlParameter("@Title",title),
					new SqlParameter("@Detail",detail),
					new SqlParameter("@Description",description),
					new SqlParameter("@StartDate",startDate),
					new SqlParameter("@EndDate",endDate),
					new SqlParameter("@WorkPosition",workPosition),
					new SqlParameter("@Type",type),
					new SqlParameter("@City",city),
					new SqlParameter("@Country",country),
					new SqlParameter("@EmployeesCount",employeesCount),
					new SqlParameter("@State",state),
					new SqlParameter("@ModifyDate",modifyDate),
					new SqlParameter("@ModifyBy",modifyBy),
					new SqlParameter("@CreateDate",createDate),
					new SqlParameter("@CreateBy",createBy),
					new SqlParameter("@IsDeleted",isDeleted)
                };

                    return ExecuteScalar(tran, "BGA_AddAdvertisements", sqlParams);

                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "AdvertisementsProvider", "Add", ArrangeParamValues(sqlParams));
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

                    return ExecuteNonQuery("BGA_DeleteAdvertisements", sqlParams);

                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "AdvertisementsProvider", "Delete", ArrangeParamValues(sqlParams));
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

                    return ExecuteNonQuery(tran, "BGA_DeleteAdvertisements", sqlParams);

                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "AdvertisementsProvider", "Delete", ArrangeParamValues(sqlParams));
                }
            }

            public static int DeleteByParams(SqlTransaction tran, int? id, int? firmId, string title, string detail, string description, DateTime? startDate, DateTime? beforeStartDate, DateTime? afterOrEqualStartDate, DateTime? endDate, DateTime? beforeEndDate, DateTime? afterOrEqualEndDate, string workPosition, int? type, string city, string country, int? employeesCount, int? state, DateTime? modifyDate, DateTime? beforeModifyDate, DateTime? afterOrEqualModifyDate, int? modifyBy, DateTime? createDate, DateTime? beforeCreateDate, DateTime? afterOrEqualCreateDate, int? createBy, bool? isDeleted)
            {
                SqlParameter[] sqlParams = null;

                try
                {
                    sqlParams = new SqlParameter[] { 
					new SqlParameter("@ID",id),
					new SqlParameter("@FirmId",firmId),
					new SqlParameter("@Title",title),
					new SqlParameter("@Detail",detail),
					new SqlParameter("@Description",description),
					new SqlParameter("@StartDate",startDate),
					new SqlParameter("@BeforeStartDate",beforeStartDate),
					new SqlParameter("@AfterOrEqualStartDate",afterOrEqualStartDate),
					new SqlParameter("@EndDate",endDate),
					new SqlParameter("@BeforeEndDate",beforeEndDate),
					new SqlParameter("@AfterOrEqualEndDate",afterOrEqualEndDate),
					new SqlParameter("@WorkPosition",workPosition),
					new SqlParameter("@Type",type),
					new SqlParameter("@City",city),
					new SqlParameter("@Country",country),
					new SqlParameter("@EmployeesCount",employeesCount),
					new SqlParameter("@State",state),
					new SqlParameter("@ModifyDate",modifyDate),
					new SqlParameter("@BeforeModifyDate",beforeModifyDate),
					new SqlParameter("@AfterOrEqualModifyDate",afterOrEqualModifyDate),
					new SqlParameter("@ModifyBy",modifyBy),
					new SqlParameter("@CreateDate",createDate),
					new SqlParameter("@BeforeCreateDate",beforeCreateDate),
					new SqlParameter("@AfterOrEqualCreateDate",afterOrEqualCreateDate),
					new SqlParameter("@CreateBy",createBy),
					new SqlParameter("@IsDeleted",isDeleted)
                };

                    if (tran == null)
                        return ExecuteNonQuery("BGA_DeleteAdvertisementsByParams", sqlParams);
                    else
                        return ExecuteNonQuery(tran, "BGA_DeleteAdvertisementsByParams", sqlParams);


                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "AdvertisementsProvider", "DeleteByParams", ArrangeParamValues(sqlParams));
                }
            }

            public static int DeleteByParams(int? id, int? firmId, string title, string detail, string description, DateTime? startDate, DateTime? beforeStartDate, DateTime? afterOrEqualStartDate, DateTime? endDate, DateTime? beforeEndDate, DateTime? afterOrEqualEndDate, string workPosition, int? type, string city, string country, int? employeesCount, int? state, DateTime? modifyDate, DateTime? beforeModifyDate, DateTime? afterOrEqualModifyDate, int? modifyBy, DateTime? createDate, DateTime? beforeCreateDate, DateTime? afterOrEqualCreateDate, int? createBy, bool? isDeleted)
            {
                return DeleteByParams(null, id, firmId, title, detail, description, startDate, beforeStartDate, afterOrEqualStartDate, endDate, beforeEndDate, afterOrEqualEndDate, workPosition, type, city, country, employeesCount, state, modifyDate, beforeModifyDate, afterOrEqualModifyDate, modifyBy, createDate, beforeCreateDate, afterOrEqualCreateDate, createBy, isDeleted)
    ;
            }



            #endregion

        }
    }
}
