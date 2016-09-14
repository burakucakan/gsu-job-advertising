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

    public partial class CVInterestedJobPositonsProvider : BaseDataLayer
    {

        public class Generated
        {

            #region Get Functions
            protected static DataSet GetBasic(SqlTransaction tran, int? cVId, string interestedJobPositions)
            {
                SqlParameter[] sqlParams = null;

                try
                {
                    DataSet ds = null;

                    sqlParams = new SqlParameter[] { 
					new SqlParameter("@CVId",cVId),
					new SqlParameter("@InterestedJobPositions",interestedJobPositions)
                };

                    if (tran == null)
                        ds = ExecuteDataset("BGA_GetCVInterestedJobPositons", sqlParams);
                    else
                        ds = ExecuteDataset(tran, "BGA_GetCVInterestedJobPositons", sqlParams);

                    return ds;
                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "CVInterestedJobPositonsProvider", "Get", ArrangeParamValues(sqlParams));
                }
            }

            public static DataSet GetByParams(int? cVId, string interestedJobPositions, int? order)
            {
                return GetByParams(null, cVId, interestedJobPositions, order)
    ;
            }

            public static DataSet GetByParams(SqlTransaction tran, int? cVId, string interestedJobPositions, int? order)
            {
                SqlParameter[] sqlParams = null;

                try
                {
                    DataSet ds = null;

                    sqlParams = new SqlParameter[] { 
					new SqlParameter("@CVId",cVId),
					new SqlParameter("@InterestedJobPositions",interestedJobPositions),
					new SqlParameter("@Order",order)
                };

                    if (tran == null)
                        ds = ExecuteDataset("BGA_GetCVInterestedJobPositonsByParams", sqlParams);
                    else
                        ds = ExecuteDataset(tran, "BGA_GetCVInterestedJobPositonsByParams", sqlParams);

                    return ds;
                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "CVInterestedJobPositonsProvider", "GetByParams", ArrangeParamValues(sqlParams));
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

                    ds = ExecuteDataset("BGA_GetCVInterestedJobPositonsByParams", sqlParams);

                    return ds;
                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "CVInterestedJobPositonsProvider", "GetByParams", ArrangeParamValues(sqlParams));
                }
            }



            public static DataSet GetAll(SqlTransaction tran)
            {
                return GetBasic(tran, null, null);
            }

            public static DataSet GetAll()
            {
                return GetBasic(null, null, null);
            }

            public static DataSet Get(SqlTransaction tran, int cVId, string interestedJobPositions)
            {
                return GetBasic(tran, cVId, interestedJobPositions);
            }

            public static DataSet Get(int cVId, string interestedJobPositions)
            {
                return GetBasic(null, cVId, interestedJobPositions);
            }



            #endregion

            #region Update Functions
            public static int Update(int cVId, string interestedJobPositions, int order)
            {
                SqlParameter[] sqlParams = null;

                try
                {
                    sqlParams = new SqlParameter[] { 
					new SqlParameter("@CVId",cVId),
					new SqlParameter("@InterestedJobPositions",interestedJobPositions),
					new SqlParameter("@Order",order)
                };

                    return ExecuteNonQuery("BGA_UpdateCVInterestedJobPositons", sqlParams);

                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "CVInterestedJobPositonsProvider", "Update", ArrangeParamValues(sqlParams));
                }
            }

            public static int Update(SqlTransaction tran, int cVId, string interestedJobPositions, int order)
            {
                SqlParameter[] sqlParams = null;

                try
                {
                    sqlParams = new SqlParameter[] { 
					new SqlParameter("@CVId",cVId),
					new SqlParameter("@InterestedJobPositions",interestedJobPositions),
					new SqlParameter("@Order",order)
                };

                    return ExecuteNonQuery(tran, "BGA_UpdateCVInterestedJobPositons", sqlParams);

                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "CVInterestedJobPositonsProvider", "Update", ArrangeParamValues(sqlParams));
                }
            }

            public static int UpdateByParams(int cVId, string interestedJobPositions, int? order)
            {
                SqlParameter[] sqlParams = null;

                try
                {
                    sqlParams = new SqlParameter[] { 
					new SqlParameter("@CVId",cVId),
					new SqlParameter("@InterestedJobPositions",interestedJobPositions),
					new SqlParameter("@Order",order)
                };

                    return ExecuteNonQuery("BGA_UpdateCVInterestedJobPositonsByParams", sqlParams);

                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "CVInterestedJobPositonsProvider", "UpdateByParams", ArrangeParamValues(sqlParams));
                }
            }

            public static int UpdateByParams(params SqlParameter[] sqlParams)
            {
                try
                {

                    return ExecuteNonQuery("BGA_UpdateCVInterestedJobPositonsByParams", sqlParams);

                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "CVInterestedJobPositonsProvider", "UpdateByParams", ArrangeParamValues(sqlParams));
                }
            }

            public static int UpdateByParams(SqlTransaction tran, int cVId, string interestedJobPositions, int? order)
            {
                SqlParameter[] sqlParams = null;

                try
                {
                    sqlParams = new SqlParameter[] { 
					new SqlParameter("@CVId",cVId),
					new SqlParameter("@InterestedJobPositions",interestedJobPositions),
					new SqlParameter("@Order",order)
                };

                    return ExecuteNonQuery(tran, "BGA_UpdateCVInterestedJobPositonsByParams", sqlParams);

                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "CVInterestedJobPositonsProvider", "UpdateByParams", ArrangeParamValues(sqlParams));
                }
            }

            public static int UpdateByParams(SqlTransaction tran, params SqlParameter[] sqlParams)
            {
                try
                {

                    return ExecuteNonQuery(tran, "BGA_UpdateCVInterestedJobPositonsByParams", sqlParams);

                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "CVInterestedJobPositonsProvider", "UpdateByParams", ArrangeParamValues(sqlParams));
                }
            }
            #endregion

            #region Add Functions
            public static object Add(int cVId, string interestedJobPositions, int order)
            {
                SqlParameter[] sqlParams = null;

                try
                {
                    sqlParams = new SqlParameter[] { 
					new SqlParameter("@CVId",cVId),
					new SqlParameter("@InterestedJobPositions",interestedJobPositions),
					new SqlParameter("@Order",order)
                };


                    return ExecuteScalarObj("BGA_AddCVInterestedJobPositons", sqlParams);

                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "CVInterestedJobPositonsProvider", "Add", ArrangeParamValues(sqlParams));
                }
            }

            public static object Add(SqlTransaction tran, int cVId, string interestedJobPositions, int order)
            {
                SqlParameter[] sqlParams = null;

                try
                {
                    sqlParams = new SqlParameter[] { 
					new SqlParameter("@CVId",cVId),
					new SqlParameter("@InterestedJobPositions",interestedJobPositions),
					new SqlParameter("@Order",order)
                };


                    return ExecuteScalarObj(tran, "BGA_AddCVInterestedJobPositons", sqlParams);

                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "CVInterestedJobPositonsProvider", "Add", ArrangeParamValues(sqlParams));
                }
            }
            #endregion

            #region Delete Functions
            public static int Delete(int cVId, string interestedJobPositions)
            {
                SqlParameter[] sqlParams = null;

                try
                {

                    sqlParams = new SqlParameter[] { 
					new SqlParameter("@CVId",cVId),
					new SqlParameter("@InterestedJobPositions",interestedJobPositions)
                };

                    return ExecuteNonQuery("BGA_DeleteCVInterestedJobPositons", sqlParams);

                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "CVInterestedJobPositonsProvider", "Delete", ArrangeParamValues(sqlParams));
                }
            }

            public static int Delete(SqlTransaction tran, int cVId, string interestedJobPositions)
            {
                SqlParameter[] sqlParams = null;

                try
                {

                    sqlParams = new SqlParameter[] { 
					new SqlParameter("@CVId",cVId),
					new SqlParameter("@InterestedJobPositions",interestedJobPositions)
                };

                    return ExecuteNonQuery(tran, "BGA_DeleteCVInterestedJobPositons", sqlParams);

                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "CVInterestedJobPositonsProvider", "Delete", ArrangeParamValues(sqlParams));
                }
            }

            public static int DeleteByParams(SqlTransaction tran, int? cVId, string interestedJobPositions, int? order)
            {
                SqlParameter[] sqlParams = null;

                try
                {
                    sqlParams = new SqlParameter[] { 
					new SqlParameter("@CVId",cVId),
					new SqlParameter("@InterestedJobPositions",interestedJobPositions),
					new SqlParameter("@Order",order)
                };

                    if (tran == null)
                        return ExecuteNonQuery("BGA_DeleteCVInterestedJobPositonsByParams", sqlParams);
                    else
                        return ExecuteNonQuery(tran, "BGA_DeleteCVInterestedJobPositonsByParams", sqlParams);


                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "CVInterestedJobPositonsProvider", "DeleteByParams", ArrangeParamValues(sqlParams));
                }
            }

            public static int DeleteByParams(int? cVId, string interestedJobPositions, int? order)
            {
                return DeleteByParams(null, cVId, interestedJobPositions, order)
    ;
            }



            #endregion

        }
    }
}
