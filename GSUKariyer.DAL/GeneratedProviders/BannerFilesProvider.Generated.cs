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

    public partial class BannerFilesProvider : BaseDataLayer
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
                        ds = ExecuteDataset("BGA_GetBannerFiles", sqlParams);
                    else
                        ds = ExecuteDataset(tran, "BGA_GetBannerFiles", sqlParams);

                    return ds;
                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "BannerFilesProvider", "Get", ArrangeParamValues(sqlParams));
                }
            }

            public static DataSet GetByParams(int? id, string name, string fileName, int? type, string link, int? width, int? height, DateTime? modifyDate, DateTime? beforeModifyDate, DateTime? afterOrEqualModifyDate, DateTime? createDate, DateTime? beforeCreateDate, DateTime? afterOrEqualCreateDate)
            {
                return GetByParams(null, id, name, fileName, type, link, width, height, modifyDate, beforeModifyDate, afterOrEqualModifyDate, createDate, beforeCreateDate, afterOrEqualCreateDate)
    ;
            }

            public static DataSet GetByParams(SqlTransaction tran, int? id, string name, string fileName, int? type, string link, int? width, int? height, DateTime? modifyDate, DateTime? beforeModifyDate, DateTime? afterOrEqualModifyDate, DateTime? createDate, DateTime? beforeCreateDate, DateTime? afterOrEqualCreateDate)
            {
                SqlParameter[] sqlParams = null;

                try
                {
                    DataSet ds = null;

                    sqlParams = new SqlParameter[] { 
					new SqlParameter("@ID",id),
					new SqlParameter("@Name",name),
					new SqlParameter("@FileName",fileName),
					new SqlParameter("@Type",type),
					new SqlParameter("@Link",link),
					new SqlParameter("@Width",width),
					new SqlParameter("@Height",height),
					new SqlParameter("@ModifyDate",modifyDate),
					new SqlParameter("@BeforeModifyDate",beforeModifyDate),
					new SqlParameter("@AfterOrEqualModifyDate",afterOrEqualModifyDate),
					new SqlParameter("@CreateDate",createDate),
					new SqlParameter("@BeforeCreateDate",beforeCreateDate),
					new SqlParameter("@AfterOrEqualCreateDate",afterOrEqualCreateDate)
                };

                    if (tran == null)
                        ds = ExecuteDataset("BGA_GetBannerFilesByParams", sqlParams);
                    else
                        ds = ExecuteDataset(tran, "BGA_GetBannerFilesByParams", sqlParams);

                    return ds;
                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "BannerFilesProvider", "GetByParams", ArrangeParamValues(sqlParams));
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

                    ds = ExecuteDataset("BGA_GetBannerFilesByParams", sqlParams);

                    return ds;
                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "BannerFilesProvider", "GetByParams", ArrangeParamValues(sqlParams));
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
            public static int Update(int id, string name, string fileName, int type, string link, int? width, int? height, DateTime modifyDate)
            {
                SqlParameter[] sqlParams = null;

                try
                {
                    sqlParams = new SqlParameter[] { 
					new SqlParameter("@ID",id),
					new SqlParameter("@Name",name),
					new SqlParameter("@FileName",fileName),
					new SqlParameter("@Type",type),
					new SqlParameter("@Link",link),
					new SqlParameter("@Width",width),
					new SqlParameter("@Height",height),
					new SqlParameter("@ModifyDate",modifyDate)
                };

                    return ExecuteNonQuery("BGA_UpdateBannerFiles", sqlParams);

                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "BannerFilesProvider", "Update", ArrangeParamValues(sqlParams));
                }
            }

            public static int Update(SqlTransaction tran, int id, string name, string fileName, int type, string link, int? width, int? height, DateTime modifyDate)
            {
                SqlParameter[] sqlParams = null;

                try
                {
                    sqlParams = new SqlParameter[] { 
					new SqlParameter("@ID",id),
					new SqlParameter("@Name",name),
					new SqlParameter("@FileName",fileName),
					new SqlParameter("@Type",type),
					new SqlParameter("@Link",link),
					new SqlParameter("@Width",width),
					new SqlParameter("@Height",height),
					new SqlParameter("@ModifyDate",modifyDate)
                };

                    return ExecuteNonQuery(tran, "BGA_UpdateBannerFiles", sqlParams);

                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "BannerFilesProvider", "Update", ArrangeParamValues(sqlParams));
                }
            }

            public static int UpdateByParams(int id, string name, string fileName, int? type, string link, int? width, int? height, DateTime? modifyDate, DateTime? createDate)
            {
                SqlParameter[] sqlParams = null;

                try
                {
                    sqlParams = new SqlParameter[] { 
					new SqlParameter("@ID",id),
					new SqlParameter("@Name",name),
					new SqlParameter("@FileName",fileName),
					new SqlParameter("@Type",type),
					new SqlParameter("@Link",link),
					new SqlParameter("@Width",width),
					new SqlParameter("@Height",height),
					new SqlParameter("@ModifyDate",modifyDate),
					new SqlParameter("@CreateDate",createDate)
                };

                    return ExecuteNonQuery("BGA_UpdateBannerFilesByParams", sqlParams);

                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "BannerFilesProvider", "UpdateByParams", ArrangeParamValues(sqlParams));
                }
            }

            public static int UpdateByParams(params SqlParameter[] sqlParams)
            {
                try
                {

                    return ExecuteNonQuery("BGA_UpdateBannerFilesByParams", sqlParams);

                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "BannerFilesProvider", "UpdateByParams", ArrangeParamValues(sqlParams));
                }
            }

            public static int UpdateByParams(SqlTransaction tran, int id, string name, string fileName, int? type, string link, int? width, int? height, DateTime? modifyDate, DateTime? createDate)
            {
                SqlParameter[] sqlParams = null;

                try
                {
                    sqlParams = new SqlParameter[] { 
					new SqlParameter("@ID",id),
					new SqlParameter("@Name",name),
					new SqlParameter("@FileName",fileName),
					new SqlParameter("@Type",type),
					new SqlParameter("@Link",link),
					new SqlParameter("@Width",width),
					new SqlParameter("@Height",height),
					new SqlParameter("@ModifyDate",modifyDate),
					new SqlParameter("@CreateDate",createDate)
                };

                    return ExecuteNonQuery(tran, "BGA_UpdateBannerFilesByParams", sqlParams);

                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "BannerFilesProvider", "UpdateByParams", ArrangeParamValues(sqlParams));
                }
            }

            public static int UpdateByParams(SqlTransaction tran, params SqlParameter[] sqlParams)
            {
                try
                {

                    return ExecuteNonQuery(tran, "BGA_UpdateBannerFilesByParams", sqlParams);

                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "BannerFilesProvider", "UpdateByParams", ArrangeParamValues(sqlParams));
                }
            }
            #endregion

            #region Add Functions
            public static int Add(string name, string fileName, int type, string link, int? width, int? height, DateTime modifyDate, DateTime createDate)
            {
                SqlParameter[] sqlParams = null;

                try
                {
                    sqlParams = new SqlParameter[] { 
					new SqlParameter("@Name",name),
					new SqlParameter("@FileName",fileName),
					new SqlParameter("@Type",type),
					new SqlParameter("@Link",link),
					new SqlParameter("@Width",width),
					new SqlParameter("@Height",height),
					new SqlParameter("@ModifyDate",modifyDate),
					new SqlParameter("@CreateDate",createDate)
                };

                    return ExecuteScalar("BGA_AddBannerFiles", sqlParams);

                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "BannerFilesProvider", "Add", ArrangeParamValues(sqlParams));
                }
            }

            public static int Add(SqlTransaction tran, string name, string fileName, int type, string link, int? width, int? height, DateTime modifyDate, DateTime createDate)
            {
                SqlParameter[] sqlParams = null;

                try
                {
                    sqlParams = new SqlParameter[] { 
					new SqlParameter("@Name",name),
					new SqlParameter("@FileName",fileName),
					new SqlParameter("@Type",type),
					new SqlParameter("@Link",link),
					new SqlParameter("@Width",width),
					new SqlParameter("@Height",height),
					new SqlParameter("@ModifyDate",modifyDate),
					new SqlParameter("@CreateDate",createDate)
                };

                    return ExecuteScalar(tran, "BGA_AddBannerFiles", sqlParams);

                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "BannerFilesProvider", "Add", ArrangeParamValues(sqlParams));
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

                    return ExecuteNonQuery("BGA_DeleteBannerFiles", sqlParams);

                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "BannerFilesProvider", "Delete", ArrangeParamValues(sqlParams));
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

                    return ExecuteNonQuery(tran, "BGA_DeleteBannerFiles", sqlParams);

                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "BannerFilesProvider", "Delete", ArrangeParamValues(sqlParams));
                }
            }

            public static int DeleteByParams(SqlTransaction tran, int? id, string name, string fileName, int? type, string link, int? width, int? height, DateTime? modifyDate, DateTime? beforeModifyDate, DateTime? afterOrEqualModifyDate, DateTime? createDate, DateTime? beforeCreateDate, DateTime? afterOrEqualCreateDate)
            {
                SqlParameter[] sqlParams = null;

                try
                {
                    sqlParams = new SqlParameter[] { 
					new SqlParameter("@ID",id),
					new SqlParameter("@Name",name),
					new SqlParameter("@FileName",fileName),
					new SqlParameter("@Type",type),
					new SqlParameter("@Link",link),
					new SqlParameter("@Width",width),
					new SqlParameter("@Height",height),
					new SqlParameter("@ModifyDate",modifyDate),
					new SqlParameter("@BeforeModifyDate",beforeModifyDate),
					new SqlParameter("@AfterOrEqualModifyDate",afterOrEqualModifyDate),
					new SqlParameter("@CreateDate",createDate),
					new SqlParameter("@BeforeCreateDate",beforeCreateDate),
					new SqlParameter("@AfterOrEqualCreateDate",afterOrEqualCreateDate)
                };

                    if (tran == null)
                        return ExecuteNonQuery("BGA_DeleteBannerFilesByParams", sqlParams);
                    else
                        return ExecuteNonQuery(tran, "BGA_DeleteBannerFilesByParams", sqlParams);


                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "BannerFilesProvider", "DeleteByParams", ArrangeParamValues(sqlParams));
                }
            }

            public static int DeleteByParams(int? id, string name, string fileName, int? type, string link, int? width, int? height, DateTime? modifyDate, DateTime? beforeModifyDate, DateTime? afterOrEqualModifyDate, DateTime? createDate, DateTime? beforeCreateDate, DateTime? afterOrEqualCreateDate)
            {
                return DeleteByParams(null, id, name, fileName, type, link, width, height, modifyDate, beforeModifyDate, afterOrEqualModifyDate, createDate, beforeCreateDate, afterOrEqualCreateDate)
    ;
            }



            #endregion

        }
    }
}
