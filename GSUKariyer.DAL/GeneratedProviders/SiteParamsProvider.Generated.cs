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

    public partial class SiteParamsProvider : BaseDataLayer
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
                        ds = ExecuteDataset("BGA_GetSiteParams", sqlParams);
                    else
                        ds = ExecuteDataset(tran, "BGA_GetSiteParams", sqlParams);

                    return ds;
                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "SiteParamsProvider", "Get", ArrangeParamValues(sqlParams));
                }
            }

            public static DataSet GetByParams(int? id, string paramName, string paramGroup, string description, string value, int? order)
            {
                return GetByParams(null, id, paramName, paramGroup, description, value, order)
    ;
            }

            public static DataSet GetByParams(SqlTransaction tran, int? id, string paramName, string paramGroup, string description, string value, int? order)
            {
                SqlParameter[] sqlParams = null;

                try
                {
                    DataSet ds = null;

                    sqlParams = new SqlParameter[] { 
					new SqlParameter("@ID",id),
					new SqlParameter("@ParamName",paramName),
					new SqlParameter("@ParamGroup",paramGroup),
					new SqlParameter("@Description",description),
					new SqlParameter("@Value",value),
					new SqlParameter("@Order",order)
                };

                    if (tran == null)
                        ds = ExecuteDataset("BGA_GetSiteParamsByParams", sqlParams);
                    else
                        ds = ExecuteDataset(tran, "BGA_GetSiteParamsByParams", sqlParams);

                    return ds;
                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "SiteParamsProvider", "GetByParams", ArrangeParamValues(sqlParams));
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

                    ds = ExecuteDataset("BGA_GetSiteParamsByParams", sqlParams);

                    return ds;
                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "SiteParamsProvider", "GetByParams", ArrangeParamValues(sqlParams));
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
            public static int Update(int id, string paramName, string paramGroup, string description, string value, int? order)
            {
                SqlParameter[] sqlParams = null;

                try
                {
                    sqlParams = new SqlParameter[] { 
					new SqlParameter("@ID",id),
					new SqlParameter("@ParamName",paramName),
					new SqlParameter("@ParamGroup",paramGroup),
					new SqlParameter("@Description",description),
					new SqlParameter("@Value",value),
					new SqlParameter("@Order",order)
                };

                    return ExecuteNonQuery("BGA_UpdateSiteParams", sqlParams);

                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "SiteParamsProvider", "Update", ArrangeParamValues(sqlParams));
                }
            }

            public static int Update(SqlTransaction tran, int id, string paramName, string paramGroup, string description, string value, int? order)
            {
                SqlParameter[] sqlParams = null;

                try
                {
                    sqlParams = new SqlParameter[] { 
					new SqlParameter("@ID",id),
					new SqlParameter("@ParamName",paramName),
					new SqlParameter("@ParamGroup",paramGroup),
					new SqlParameter("@Description",description),
					new SqlParameter("@Value",value),
					new SqlParameter("@Order",order)
                };

                    return ExecuteNonQuery(tran, "BGA_UpdateSiteParams", sqlParams);

                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "SiteParamsProvider", "Update", ArrangeParamValues(sqlParams));
                }
            }

            public static int UpdateByParams(int id, string paramName, string paramGroup, string description, string value, int? order)
            {
                SqlParameter[] sqlParams = null;

                try
                {
                    sqlParams = new SqlParameter[] { 
					new SqlParameter("@ID",id),
					new SqlParameter("@ParamName",paramName),
					new SqlParameter("@ParamGroup",paramGroup),
					new SqlParameter("@Description",description),
					new SqlParameter("@Value",value),
					new SqlParameter("@Order",order)
                };

                    return ExecuteNonQuery("BGA_UpdateSiteParamsByParams", sqlParams);

                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "SiteParamsProvider", "UpdateByParams", ArrangeParamValues(sqlParams));
                }
            }

            public static int UpdateByParams(params SqlParameter[] sqlParams)
            {
                try
                {

                    return ExecuteNonQuery("BGA_UpdateSiteParamsByParams", sqlParams);

                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "SiteParamsProvider", "UpdateByParams", ArrangeParamValues(sqlParams));
                }
            }

            public static int UpdateByParams(SqlTransaction tran, int id, string paramName, string paramGroup, string description, string value, int? order)
            {
                SqlParameter[] sqlParams = null;

                try
                {
                    sqlParams = new SqlParameter[] { 
					new SqlParameter("@ID",id),
					new SqlParameter("@ParamName",paramName),
					new SqlParameter("@ParamGroup",paramGroup),
					new SqlParameter("@Description",description),
					new SqlParameter("@Value",value),
					new SqlParameter("@Order",order)
                };

                    return ExecuteNonQuery(tran, "BGA_UpdateSiteParamsByParams", sqlParams);

                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "SiteParamsProvider", "UpdateByParams", ArrangeParamValues(sqlParams));
                }
            }

            public static int UpdateByParams(SqlTransaction tran, params SqlParameter[] sqlParams)
            {
                try
                {

                    return ExecuteNonQuery(tran, "BGA_UpdateSiteParamsByParams", sqlParams);

                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "SiteParamsProvider", "UpdateByParams", ArrangeParamValues(sqlParams));
                }
            }
            #endregion

            #region Add Functions
            public static int Add(string paramName, string paramGroup, string description, string value, int? order)
            {
                SqlParameter[] sqlParams = null;

                try
                {
                    sqlParams = new SqlParameter[] { 
					new SqlParameter("@ParamName",paramName),
					new SqlParameter("@ParamGroup",paramGroup),
					new SqlParameter("@Description",description),
					new SqlParameter("@Value",value),
					new SqlParameter("@Order",order)
                };

                    return ExecuteScalar("BGA_AddSiteParams", sqlParams);

                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "SiteParamsProvider", "Add", ArrangeParamValues(sqlParams));
                }
            }

            public static int Add(SqlTransaction tran, string paramName, string paramGroup, string description, string value, int? order)
            {
                SqlParameter[] sqlParams = null;

                try
                {
                    sqlParams = new SqlParameter[] { 
					new SqlParameter("@ParamName",paramName),
					new SqlParameter("@ParamGroup",paramGroup),
					new SqlParameter("@Description",description),
					new SqlParameter("@Value",value),
					new SqlParameter("@Order",order)
                };

                    return ExecuteScalar(tran, "BGA_AddSiteParams", sqlParams);

                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "SiteParamsProvider", "Add", ArrangeParamValues(sqlParams));
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

                    return ExecuteNonQuery("BGA_DeleteSiteParams", sqlParams);

                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "SiteParamsProvider", "Delete", ArrangeParamValues(sqlParams));
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

                    return ExecuteNonQuery(tran, "BGA_DeleteSiteParams", sqlParams);

                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "SiteParamsProvider", "Delete", ArrangeParamValues(sqlParams));
                }
            }

            public static int DeleteByParams(SqlTransaction tran, int? id, string paramName, string paramGroup, string description, string value, int? order)
            {
                SqlParameter[] sqlParams = null;

                try
                {
                    sqlParams = new SqlParameter[] { 
					new SqlParameter("@ID",id),
					new SqlParameter("@ParamName",paramName),
					new SqlParameter("@ParamGroup",paramGroup),
					new SqlParameter("@Description",description),
					new SqlParameter("@Value",value),
					new SqlParameter("@Order",order)
                };

                    if (tran == null)
                        return ExecuteNonQuery("BGA_DeleteSiteParamsByParams", sqlParams);
                    else
                        return ExecuteNonQuery(tran, "BGA_DeleteSiteParamsByParams", sqlParams);


                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "SiteParamsProvider", "DeleteByParams", ArrangeParamValues(sqlParams));
                }
            }

            public static int DeleteByParams(int? id, string paramName, string paramGroup, string description, string value, int? order)
            {
                return DeleteByParams(null, id, paramName, paramGroup, description, value, order)
    ;
            }



            #endregion

        }
    }
}
