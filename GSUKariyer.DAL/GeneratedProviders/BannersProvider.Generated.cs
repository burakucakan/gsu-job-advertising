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

    public partial class BannersProvider : BaseDataLayer
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
                        ds = ExecuteDataset("BGA_GetBanners", sqlParams);
                    else
                        ds = ExecuteDataset(tran, "BGA_GetBanners", sqlParams);

                    return ds;
                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "BannersProvider", "Get", ArrangeParamValues(sqlParams));
                }
            }

            public static DataSet GetByParams(int? id, int? bannerFileId, string pageName, int? pageLocation, int? publishType, DateTime? startDate, DateTime? beforeStartDate, DateTime? afterOrEqualStartDate, DateTime? endDate, DateTime? beforeEndDate, DateTime? afterOrEqualEndDate, int? order, DateTime? modifyDate, DateTime? beforeModifyDate, DateTime? afterOrEqualModifyDate, DateTime? createDate, DateTime? beforeCreateDate, DateTime? afterOrEqualCreateDate)
            {
                return GetByParams(null, id, bannerFileId, pageName, pageLocation, publishType, startDate, beforeStartDate, afterOrEqualStartDate, endDate, beforeEndDate, afterOrEqualEndDate, order, modifyDate, beforeModifyDate, afterOrEqualModifyDate, createDate, beforeCreateDate, afterOrEqualCreateDate)
    ;
            }

            public static DataSet GetByParams(SqlTransaction tran, int? id, int? bannerFileId, string pageName, int? pageLocation, int? publishType, DateTime? startDate, DateTime? beforeStartDate, DateTime? afterOrEqualStartDate, DateTime? endDate, DateTime? beforeEndDate, DateTime? afterOrEqualEndDate, int? order, DateTime? modifyDate, DateTime? beforeModifyDate, DateTime? afterOrEqualModifyDate, DateTime? createDate, DateTime? beforeCreateDate, DateTime? afterOrEqualCreateDate)
            {
                SqlParameter[] sqlParams = null;

                try
                {
                    DataSet ds = null;

                    sqlParams = new SqlParameter[] { 
					new SqlParameter("@ID",id),
					new SqlParameter("@BannerFileId",bannerFileId),
					new SqlParameter("@PageName",pageName),
					new SqlParameter("@PageLocation",pageLocation),
					new SqlParameter("@PublishType",publishType),
					new SqlParameter("@StartDate",startDate),
					new SqlParameter("@BeforeStartDate",beforeStartDate),
					new SqlParameter("@AfterOrEqualStartDate",afterOrEqualStartDate),
					new SqlParameter("@EndDate",endDate),
					new SqlParameter("@BeforeEndDate",beforeEndDate),
					new SqlParameter("@AfterOrEqualEndDate",afterOrEqualEndDate),
					new SqlParameter("@Order",order),
					new SqlParameter("@ModifyDate",modifyDate),
					new SqlParameter("@BeforeModifyDate",beforeModifyDate),
					new SqlParameter("@AfterOrEqualModifyDate",afterOrEqualModifyDate),
					new SqlParameter("@CreateDate",createDate),
					new SqlParameter("@BeforeCreateDate",beforeCreateDate),
					new SqlParameter("@AfterOrEqualCreateDate",afterOrEqualCreateDate)
                };

                    if (tran == null)
                        ds = ExecuteDataset("BGA_GetBannersByParams", sqlParams);
                    else
                        ds = ExecuteDataset(tran, "BGA_GetBannersByParams", sqlParams);

                    return ds;
                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "BannersProvider", "GetByParams", ArrangeParamValues(sqlParams));
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

                    ds = ExecuteDataset("BGA_GetBannersByParams", sqlParams);

                    return ds;
                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "BannersProvider", "GetByParams", ArrangeParamValues(sqlParams));
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
            public static int Update(int id, int bannerFileId, string pageName, int pageLocation, int publishType, DateTime startDate, DateTime endDate, int order, DateTime modifyDate)
            {
                SqlParameter[] sqlParams = null;

                try
                {
                    sqlParams = new SqlParameter[] { 
					new SqlParameter("@ID",id),
					new SqlParameter("@BannerFileId",bannerFileId),
					new SqlParameter("@PageName",pageName),
					new SqlParameter("@PageLocation",pageLocation),
					new SqlParameter("@PublishType",publishType),
					new SqlParameter("@StartDate",startDate),
					new SqlParameter("@EndDate",endDate),
					new SqlParameter("@Order",order),
					new SqlParameter("@ModifyDate",modifyDate)
                };

                    return ExecuteNonQuery("BGA_UpdateBanners", sqlParams);

                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "BannersProvider", "Update", ArrangeParamValues(sqlParams));
                }
            }

            public static int Update(SqlTransaction tran, int id, int bannerFileId, string pageName, int pageLocation, int publishType, DateTime startDate, DateTime endDate, int order, DateTime modifyDate)
            {
                SqlParameter[] sqlParams = null;

                try
                {
                    sqlParams = new SqlParameter[] { 
					new SqlParameter("@ID",id),
					new SqlParameter("@BannerFileId",bannerFileId),
					new SqlParameter("@PageName",pageName),
					new SqlParameter("@PageLocation",pageLocation),
					new SqlParameter("@PublishType",publishType),
					new SqlParameter("@StartDate",startDate),
					new SqlParameter("@EndDate",endDate),
					new SqlParameter("@Order",order),
					new SqlParameter("@ModifyDate",modifyDate)
                };

                    return ExecuteNonQuery(tran, "BGA_UpdateBanners", sqlParams);

                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "BannersProvider", "Update", ArrangeParamValues(sqlParams));
                }
            }

            public static int UpdateByParams(int id, int? bannerFileId, string pageName, int? pageLocation, int? publishType, DateTime? startDate, DateTime? endDate, int? order, DateTime? modifyDate, DateTime? createDate)
            {
                SqlParameter[] sqlParams = null;

                try
                {
                    sqlParams = new SqlParameter[] { 
					new SqlParameter("@ID",id),
					new SqlParameter("@BannerFileId",bannerFileId),
					new SqlParameter("@PageName",pageName),
					new SqlParameter("@PageLocation",pageLocation),
					new SqlParameter("@PublishType",publishType),
					new SqlParameter("@StartDate",startDate),
					new SqlParameter("@EndDate",endDate),
					new SqlParameter("@Order",order),
					new SqlParameter("@ModifyDate",modifyDate),
					new SqlParameter("@CreateDate",createDate)
                };

                    return ExecuteNonQuery("BGA_UpdateBannersByParams", sqlParams);

                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "BannersProvider", "UpdateByParams", ArrangeParamValues(sqlParams));
                }
            }

            public static int UpdateByParams(params SqlParameter[] sqlParams)
            {
                try
                {

                    return ExecuteNonQuery("BGA_UpdateBannersByParams", sqlParams);

                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "BannersProvider", "UpdateByParams", ArrangeParamValues(sqlParams));
                }
            }

            public static int UpdateByParams(SqlTransaction tran, int id, int? bannerFileId, string pageName, int? pageLocation, int? publishType, DateTime? startDate, DateTime? endDate, int? order, DateTime? modifyDate, DateTime? createDate)
            {
                SqlParameter[] sqlParams = null;

                try
                {
                    sqlParams = new SqlParameter[] { 
					new SqlParameter("@ID",id),
					new SqlParameter("@BannerFileId",bannerFileId),
					new SqlParameter("@PageName",pageName),
					new SqlParameter("@PageLocation",pageLocation),
					new SqlParameter("@PublishType",publishType),
					new SqlParameter("@StartDate",startDate),
					new SqlParameter("@EndDate",endDate),
					new SqlParameter("@Order",order),
					new SqlParameter("@ModifyDate",modifyDate),
					new SqlParameter("@CreateDate",createDate)
                };

                    return ExecuteNonQuery(tran, "BGA_UpdateBannersByParams", sqlParams);

                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "BannersProvider", "UpdateByParams", ArrangeParamValues(sqlParams));
                }
            }

            public static int UpdateByParams(SqlTransaction tran, params SqlParameter[] sqlParams)
            {
                try
                {

                    return ExecuteNonQuery(tran, "BGA_UpdateBannersByParams", sqlParams);

                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "BannersProvider", "UpdateByParams", ArrangeParamValues(sqlParams));
                }
            }
            #endregion

            #region Add Functions
            public static int Add(int bannerFileId, string pageName, int pageLocation, int publishType, DateTime startDate, DateTime endDate, int order, DateTime modifyDate, DateTime createDate)
            {
                SqlParameter[] sqlParams = null;

                try
                {
                    sqlParams = new SqlParameter[] { 
					new SqlParameter("@BannerFileId",bannerFileId),
					new SqlParameter("@PageName",pageName),
					new SqlParameter("@PageLocation",pageLocation),
					new SqlParameter("@PublishType",publishType),
					new SqlParameter("@StartDate",startDate),
					new SqlParameter("@EndDate",endDate),
					new SqlParameter("@Order",order),
					new SqlParameter("@ModifyDate",modifyDate),
					new SqlParameter("@CreateDate",createDate)
                };

                    return ExecuteScalar("BGA_AddBanners", sqlParams);

                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "BannersProvider", "Add", ArrangeParamValues(sqlParams));
                }
            }

            public static int Add(SqlTransaction tran, int bannerFileId, string pageName, int pageLocation, int publishType, DateTime startDate, DateTime endDate, int order, DateTime modifyDate, DateTime createDate)
            {
                SqlParameter[] sqlParams = null;

                try
                {
                    sqlParams = new SqlParameter[] { 
					new SqlParameter("@BannerFileId",bannerFileId),
					new SqlParameter("@PageName",pageName),
					new SqlParameter("@PageLocation",pageLocation),
					new SqlParameter("@PublishType",publishType),
					new SqlParameter("@StartDate",startDate),
					new SqlParameter("@EndDate",endDate),
					new SqlParameter("@Order",order),
					new SqlParameter("@ModifyDate",modifyDate),
					new SqlParameter("@CreateDate",createDate)
                };

                    return ExecuteScalar(tran, "BGA_AddBanners", sqlParams);

                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "BannersProvider", "Add", ArrangeParamValues(sqlParams));
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

                    return ExecuteNonQuery("BGA_DeleteBanners", sqlParams);

                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "BannersProvider", "Delete", ArrangeParamValues(sqlParams));
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

                    return ExecuteNonQuery(tran, "BGA_DeleteBanners", sqlParams);

                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "BannersProvider", "Delete", ArrangeParamValues(sqlParams));
                }
            }

            public static int DeleteByParams(SqlTransaction tran, int? id, int? bannerFileId, string pageName, int? pageLocation, int? publishType, DateTime? startDate, DateTime? beforeStartDate, DateTime? afterOrEqualStartDate, DateTime? endDate, DateTime? beforeEndDate, DateTime? afterOrEqualEndDate, int? order, DateTime? modifyDate, DateTime? beforeModifyDate, DateTime? afterOrEqualModifyDate, DateTime? createDate, DateTime? beforeCreateDate, DateTime? afterOrEqualCreateDate)
            {
                SqlParameter[] sqlParams = null;

                try
                {
                    sqlParams = new SqlParameter[] { 
					new SqlParameter("@ID",id),
					new SqlParameter("@BannerFileId",bannerFileId),
					new SqlParameter("@PageName",pageName),
					new SqlParameter("@PageLocation",pageLocation),
					new SqlParameter("@PublishType",publishType),
					new SqlParameter("@StartDate",startDate),
					new SqlParameter("@BeforeStartDate",beforeStartDate),
					new SqlParameter("@AfterOrEqualStartDate",afterOrEqualStartDate),
					new SqlParameter("@EndDate",endDate),
					new SqlParameter("@BeforeEndDate",beforeEndDate),
					new SqlParameter("@AfterOrEqualEndDate",afterOrEqualEndDate),
					new SqlParameter("@Order",order),
					new SqlParameter("@ModifyDate",modifyDate),
					new SqlParameter("@BeforeModifyDate",beforeModifyDate),
					new SqlParameter("@AfterOrEqualModifyDate",afterOrEqualModifyDate),
					new SqlParameter("@CreateDate",createDate),
					new SqlParameter("@BeforeCreateDate",beforeCreateDate),
					new SqlParameter("@AfterOrEqualCreateDate",afterOrEqualCreateDate)
                };

                    if (tran == null)
                        return ExecuteNonQuery("BGA_DeleteBannersByParams", sqlParams);
                    else
                        return ExecuteNonQuery(tran, "BGA_DeleteBannersByParams", sqlParams);


                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "BannersProvider", "DeleteByParams", ArrangeParamValues(sqlParams));
                }
            }

            public static int DeleteByParams(int? id, int? bannerFileId, string pageName, int? pageLocation, int? publishType, DateTime? startDate, DateTime? beforeStartDate, DateTime? afterOrEqualStartDate, DateTime? endDate, DateTime? beforeEndDate, DateTime? afterOrEqualEndDate, int? order, DateTime? modifyDate, DateTime? beforeModifyDate, DateTime? afterOrEqualModifyDate, DateTime? createDate, DateTime? beforeCreateDate, DateTime? afterOrEqualCreateDate)
            {
                return DeleteByParams(null, id, bannerFileId, pageName, pageLocation, publishType, startDate, beforeStartDate, afterOrEqualStartDate, endDate, beforeEndDate, afterOrEqualEndDate, order, modifyDate, beforeModifyDate, afterOrEqualModifyDate, createDate, beforeCreateDate, afterOrEqualCreateDate)
    ;
            }



            #endregion

        }
    }
}
