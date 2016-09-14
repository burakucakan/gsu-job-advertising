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

    public partial class AdvertisementApplicationsProvider : BaseDataLayer
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
                        ds = ExecuteDataset("BGA_GetAdvertisementApplications", sqlParams);
                    else
                        ds = ExecuteDataset(tran, "BGA_GetAdvertisementApplications", sqlParams);

                    return ds;
                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "AdvertisementApplicationsProvider", "Get", ArrangeParamValues(sqlParams));
                }
            }

            public static DataSet GetByParams(int? id, int? advertisementId, int? userId, int? cvId, string frontPostTitle, string frontPost, string advertisementAnswer, bool? isRead, int? state, DateTime? modifyDate, DateTime? beforeModifyDate, DateTime? afterOrEqualModifyDate, DateTime? createDate, DateTime? beforeCreateDate, DateTime? afterOrEqualCreateDate)
            {
                return GetByParams(null, id, advertisementId, userId, cvId, frontPostTitle, frontPost, advertisementAnswer, isRead, state, modifyDate, beforeModifyDate, afterOrEqualModifyDate, createDate, beforeCreateDate, afterOrEqualCreateDate)
    ;
            }

            public static DataSet GetByParams(SqlTransaction tran, int? id, int? advertisementId, int? userId, int? cvId, string frontPostTitle, string frontPost, string advertisementAnswer, bool? isRead, int? state, DateTime? modifyDate, DateTime? beforeModifyDate, DateTime? afterOrEqualModifyDate, DateTime? createDate, DateTime? beforeCreateDate, DateTime? afterOrEqualCreateDate)
            {
                SqlParameter[] sqlParams = null;

                try
                {
                    DataSet ds = null;

                    sqlParams = new SqlParameter[] { 
					new SqlParameter("@ID",id),
					new SqlParameter("@AdvertisementId",advertisementId),
					new SqlParameter("@UserId",userId),
					new SqlParameter("@CvId",cvId),
					new SqlParameter("@FrontPostTitle",frontPostTitle),
					new SqlParameter("@FrontPost",frontPost),
					new SqlParameter("@AdvertisementAnswer",advertisementAnswer),
					new SqlParameter("@IsRead",isRead),
					new SqlParameter("@State",state),
					new SqlParameter("@ModifyDate",modifyDate),
					new SqlParameter("@BeforeModifyDate",beforeModifyDate),
					new SqlParameter("@AfterOrEqualModifyDate",afterOrEqualModifyDate),
					new SqlParameter("@CreateDate",createDate),
					new SqlParameter("@BeforeCreateDate",beforeCreateDate),
					new SqlParameter("@AfterOrEqualCreateDate",afterOrEqualCreateDate)
                };

                    if (tran == null)
                        ds = ExecuteDataset("BGA_GetAdvertisementApplicationsByParams", sqlParams);
                    else
                        ds = ExecuteDataset(tran, "BGA_GetAdvertisementApplicationsByParams", sqlParams);

                    return ds;
                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "AdvertisementApplicationsProvider", "GetByParams", ArrangeParamValues(sqlParams));
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

                    ds = ExecuteDataset("BGA_GetAdvertisementApplicationsByParams", sqlParams);

                    return ds;
                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "AdvertisementApplicationsProvider", "GetByParams", ArrangeParamValues(sqlParams));
                }
            }

            public static DataSet GetByFKBasic(int? userId)
            {
                return GetByFKBasic(null, userId);
            }

            public static DataSet GetByFKBasic(SqlTransaction tran, int? userId)
            {
                SqlParameter[] sqlParams = null;

                try
                {
                    DataSet ds = null;

                    sqlParams = new SqlParameter[] { 
					new SqlParameter("@UserId",userId)
                };

                    if (tran == null)
                        ds = ExecuteDataset("BGA_GetAdvertisementApplicationsByFK", sqlParams);
                    else
                        ds = ExecuteDataset(tran, "BGA_GetAdvertisementApplicationsByFK", sqlParams);

                    return ds;
                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "AdvertisementApplicationsProvider", "GetByFK", ArrangeParamValues(sqlParams));
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

            public static DataSet GetByFK(SqlTransaction tran, int userId)
            {
                return GetByFKBasic(tran, userId);
            }

            public static DataSet GetByFK(int userId)
            {
                return GetByFKBasic(userId);
            }


            #endregion

            #region Update Functions
            public static int Update(int id, int advertisementId, int userId, int cvId, string frontPostTitle, string frontPost, string advertisementAnswer, bool isRead, int state, DateTime modifyDate)
            {
                SqlParameter[] sqlParams = null;

                try
                {
                    sqlParams = new SqlParameter[] { 
					new SqlParameter("@ID",id),
					new SqlParameter("@AdvertisementId",advertisementId),
					new SqlParameter("@UserId",userId),
					new SqlParameter("@CvId",cvId),
					new SqlParameter("@FrontPostTitle",frontPostTitle),
					new SqlParameter("@FrontPost",frontPost),
					new SqlParameter("@AdvertisementAnswer",advertisementAnswer),
					new SqlParameter("@IsRead",isRead),
					new SqlParameter("@State",state),
					new SqlParameter("@ModifyDate",modifyDate)
                };

                    return ExecuteNonQuery("BGA_UpdateAdvertisementApplications", sqlParams);

                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "AdvertisementApplicationsProvider", "Update", ArrangeParamValues(sqlParams));
                }
            }

            public static int Update(SqlTransaction tran, int id, int advertisementId, int userId, int cvId, string frontPostTitle, string frontPost, string advertisementAnswer, bool isRead, int state, DateTime modifyDate)
            {
                SqlParameter[] sqlParams = null;

                try
                {
                    sqlParams = new SqlParameter[] { 
					new SqlParameter("@ID",id),
					new SqlParameter("@AdvertisementId",advertisementId),
					new SqlParameter("@UserId",userId),
					new SqlParameter("@CvId",cvId),
					new SqlParameter("@FrontPostTitle",frontPostTitle),
					new SqlParameter("@FrontPost",frontPost),
					new SqlParameter("@AdvertisementAnswer",advertisementAnswer),
					new SqlParameter("@IsRead",isRead),
					new SqlParameter("@State",state),
					new SqlParameter("@ModifyDate",modifyDate)
                };

                    return ExecuteNonQuery(tran, "BGA_UpdateAdvertisementApplications", sqlParams);

                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "AdvertisementApplicationsProvider", "Update", ArrangeParamValues(sqlParams));
                }
            }

            public static int UpdateByParams(int id, int? advertisementId, int? userId, int? cvId, string frontPostTitle, string frontPost, string advertisementAnswer, bool? isRead, int? state, DateTime? modifyDate, DateTime? createDate)
            {
                SqlParameter[] sqlParams = null;

                try
                {
                    sqlParams = new SqlParameter[] { 
					new SqlParameter("@ID",id),
					new SqlParameter("@AdvertisementId",advertisementId),
					new SqlParameter("@UserId",userId),
					new SqlParameter("@CvId",cvId),
					new SqlParameter("@FrontPostTitle",frontPostTitle),
					new SqlParameter("@FrontPost",frontPost),
					new SqlParameter("@AdvertisementAnswer",advertisementAnswer),
					new SqlParameter("@IsRead",isRead),
					new SqlParameter("@State",state),
					new SqlParameter("@ModifyDate",modifyDate),
					new SqlParameter("@CreateDate",createDate)
                };

                    return ExecuteNonQuery("BGA_UpdateAdvertisementApplicationsByParams", sqlParams);

                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "AdvertisementApplicationsProvider", "UpdateByParams", ArrangeParamValues(sqlParams));
                }
            }

            public static int UpdateByParams(params SqlParameter[] sqlParams)
            {
                try
                {

                    return ExecuteNonQuery("BGA_UpdateAdvertisementApplicationsByParams", sqlParams);

                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "AdvertisementApplicationsProvider", "UpdateByParams", ArrangeParamValues(sqlParams));
                }
            }

            public static int UpdateByParams(SqlTransaction tran, int id, int? advertisementId, int? userId, int? cvId, string frontPostTitle, string frontPost, string advertisementAnswer, bool? isRead, int? state, DateTime? modifyDate, DateTime? createDate)
            {
                SqlParameter[] sqlParams = null;

                try
                {
                    sqlParams = new SqlParameter[] { 
					new SqlParameter("@ID",id),
					new SqlParameter("@AdvertisementId",advertisementId),
					new SqlParameter("@UserId",userId),
					new SqlParameter("@CvId",cvId),
					new SqlParameter("@FrontPostTitle",frontPostTitle),
					new SqlParameter("@FrontPost",frontPost),
					new SqlParameter("@AdvertisementAnswer",advertisementAnswer),
					new SqlParameter("@IsRead",isRead),
					new SqlParameter("@State",state),
					new SqlParameter("@ModifyDate",modifyDate),
					new SqlParameter("@CreateDate",createDate)
                };

                    return ExecuteNonQuery(tran, "BGA_UpdateAdvertisementApplicationsByParams", sqlParams);

                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "AdvertisementApplicationsProvider", "UpdateByParams", ArrangeParamValues(sqlParams));
                }
            }

            public static int UpdateByParams(SqlTransaction tran, params SqlParameter[] sqlParams)
            {
                try
                {

                    return ExecuteNonQuery(tran, "BGA_UpdateAdvertisementApplicationsByParams", sqlParams);

                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "AdvertisementApplicationsProvider", "UpdateByParams", ArrangeParamValues(sqlParams));
                }
            }
            #endregion

            #region Add Functions
            public static int Add(int advertisementId, int userId, int cvId, string frontPostTitle, string frontPost, string advertisementAnswer, bool isRead, int state, DateTime modifyDate, DateTime createDate)
            {
                SqlParameter[] sqlParams = null;

                try
                {
                    sqlParams = new SqlParameter[] { 
					new SqlParameter("@AdvertisementId",advertisementId),
					new SqlParameter("@UserId",userId),
					new SqlParameter("@CvId",cvId),
					new SqlParameter("@FrontPostTitle",frontPostTitle),
					new SqlParameter("@FrontPost",frontPost),
					new SqlParameter("@AdvertisementAnswer",advertisementAnswer),
					new SqlParameter("@IsRead",isRead),
					new SqlParameter("@State",state),
					new SqlParameter("@ModifyDate",modifyDate),
					new SqlParameter("@CreateDate",createDate)
                };

                    return ExecuteScalar("BGA_AddAdvertisementApplications", sqlParams);

                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "AdvertisementApplicationsProvider", "Add", ArrangeParamValues(sqlParams));
                }
            }

            public static int Add(SqlTransaction tran, int advertisementId, int userId, int cvId, string frontPostTitle, string frontPost, string advertisementAnswer, bool isRead, int state, DateTime modifyDate, DateTime createDate)
            {
                SqlParameter[] sqlParams = null;

                try
                {
                    sqlParams = new SqlParameter[] { 
					new SqlParameter("@AdvertisementId",advertisementId),
					new SqlParameter("@UserId",userId),
					new SqlParameter("@CvId",cvId),
					new SqlParameter("@FrontPostTitle",frontPostTitle),
					new SqlParameter("@FrontPost",frontPost),
					new SqlParameter("@AdvertisementAnswer",advertisementAnswer),
					new SqlParameter("@IsRead",isRead),
					new SqlParameter("@State",state),
					new SqlParameter("@ModifyDate",modifyDate),
					new SqlParameter("@CreateDate",createDate)
                };

                    return ExecuteScalar(tran, "BGA_AddAdvertisementApplications", sqlParams);

                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "AdvertisementApplicationsProvider", "Add", ArrangeParamValues(sqlParams));
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

                    return ExecuteNonQuery("BGA_DeleteAdvertisementApplications", sqlParams);

                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "AdvertisementApplicationsProvider", "Delete", ArrangeParamValues(sqlParams));
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

                    return ExecuteNonQuery(tran, "BGA_DeleteAdvertisementApplications", sqlParams);

                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "AdvertisementApplicationsProvider", "Delete", ArrangeParamValues(sqlParams));
                }
            }

            public static int DeleteByParams(SqlTransaction tran, int? id, int? advertisementId, int? userId, int? cvId, string frontPostTitle, string frontPost, string advertisementAnswer, bool? isRead, int? state, DateTime? modifyDate, DateTime? beforeModifyDate, DateTime? afterOrEqualModifyDate, DateTime? createDate, DateTime? beforeCreateDate, DateTime? afterOrEqualCreateDate)
            {
                SqlParameter[] sqlParams = null;

                try
                {
                    sqlParams = new SqlParameter[] { 
					new SqlParameter("@ID",id),
					new SqlParameter("@AdvertisementId",advertisementId),
					new SqlParameter("@UserId",userId),
					new SqlParameter("@CvId",cvId),
					new SqlParameter("@FrontPostTitle",frontPostTitle),
					new SqlParameter("@FrontPost",frontPost),
					new SqlParameter("@AdvertisementAnswer",advertisementAnswer),
					new SqlParameter("@IsRead",isRead),
					new SqlParameter("@State",state),
					new SqlParameter("@ModifyDate",modifyDate),
					new SqlParameter("@BeforeModifyDate",beforeModifyDate),
					new SqlParameter("@AfterOrEqualModifyDate",afterOrEqualModifyDate),
					new SqlParameter("@CreateDate",createDate),
					new SqlParameter("@BeforeCreateDate",beforeCreateDate),
					new SqlParameter("@AfterOrEqualCreateDate",afterOrEqualCreateDate)
                };

                    if (tran == null)
                        return ExecuteNonQuery("BGA_DeleteAdvertisementApplicationsByParams", sqlParams);
                    else
                        return ExecuteNonQuery(tran, "BGA_DeleteAdvertisementApplicationsByParams", sqlParams);


                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "AdvertisementApplicationsProvider", "DeleteByParams", ArrangeParamValues(sqlParams));
                }
            }

            public static int DeleteByParams(int? id, int? advertisementId, int? userId, int? cvId, string frontPostTitle, string frontPost, string advertisementAnswer, bool? isRead, int? state, DateTime? modifyDate, DateTime? beforeModifyDate, DateTime? afterOrEqualModifyDate, DateTime? createDate, DateTime? beforeCreateDate, DateTime? afterOrEqualCreateDate)
            {
                return DeleteByParams(null, id, advertisementId, userId, cvId, frontPostTitle, frontPost, advertisementAnswer, isRead, state, modifyDate, beforeModifyDate, afterOrEqualModifyDate, createDate, beforeCreateDate, afterOrEqualCreateDate)
    ;
            }

            public static int DeleteByFK(int? userId)
            {
                return DeleteByFK(null, userId)
    ;
            }

            public static int DeleteByFK(SqlTransaction tran, int? userId)
            {
                SqlParameter[] sqlParams = null;

                try
                {

                    sqlParams = new SqlParameter[] { 
					new SqlParameter("@UserId",userId)
                };

                    if (tran == null)
                        return ExecuteNonQuery("BGA_DeleteAdvertisementApplicationsByFK", sqlParams);
                    else
                        return ExecuteNonQuery(tran, "BGA_DeleteAdvertisementApplicationsByFK", sqlParams);

                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "AdvertisementApplicationsProvider", "DeleteByFK", ArrangeParamValues(sqlParams));
                }
            }


            #endregion

        }
    }
}
