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

    public partial class SurveyResultsProvider : BaseDataLayer
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
                        ds = ExecuteDataset("BGA_GetSurveyResults", sqlParams);
                    else
                        ds = ExecuteDataset(tran, "BGA_GetSurveyResults", sqlParams);

                    return ds;
                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "SurveyResultsProvider", "Get", ArrangeParamValues(sqlParams));
                }
            }

            public static DataSet GetByParams(int? id, int? surveyItemId, int? userID, DateTime? createDate, DateTime? beforeCreateDate, DateTime? afterOrEqualCreateDate)
            {
                return GetByParams(null, id, surveyItemId, userID, createDate, beforeCreateDate, afterOrEqualCreateDate)
    ;
            }

            public static DataSet GetByParams(SqlTransaction tran, int? id, int? surveyItemId, int? userID, DateTime? createDate, DateTime? beforeCreateDate, DateTime? afterOrEqualCreateDate)
            {
                SqlParameter[] sqlParams = null;

                try
                {
                    DataSet ds = null;

                    sqlParams = new SqlParameter[] { 
					new SqlParameter("@ID",id),
					new SqlParameter("@SurveyItemId",surveyItemId),
					new SqlParameter("@UserID",userID),
					new SqlParameter("@CreateDate",createDate),
					new SqlParameter("@BeforeCreateDate",beforeCreateDate),
					new SqlParameter("@AfterOrEqualCreateDate",afterOrEqualCreateDate)
                };

                    if (tran == null)
                        ds = ExecuteDataset("BGA_GetSurveyResultsByParams", sqlParams);
                    else
                        ds = ExecuteDataset(tran, "BGA_GetSurveyResultsByParams", sqlParams);

                    return ds;
                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "SurveyResultsProvider", "GetByParams", ArrangeParamValues(sqlParams));
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

                    ds = ExecuteDataset("BGA_GetSurveyResultsByParams", sqlParams);

                    return ds;
                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "SurveyResultsProvider", "GetByParams", ArrangeParamValues(sqlParams));
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
            public static int Update(int id, int surveyItemId, int userID)
            {
                SqlParameter[] sqlParams = null;

                try
                {
                    sqlParams = new SqlParameter[] { 
					new SqlParameter("@ID",id),
					new SqlParameter("@SurveyItemId",surveyItemId),
					new SqlParameter("@UserID",userID)
                };

                    return ExecuteNonQuery("BGA_UpdateSurveyResults", sqlParams);

                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "SurveyResultsProvider", "Update", ArrangeParamValues(sqlParams));
                }
            }

            public static int Update(SqlTransaction tran, int id, int surveyItemId, int userID)
            {
                SqlParameter[] sqlParams = null;

                try
                {
                    sqlParams = new SqlParameter[] { 
					new SqlParameter("@ID",id),
					new SqlParameter("@SurveyItemId",surveyItemId),
					new SqlParameter("@UserID",userID)
                };

                    return ExecuteNonQuery(tran, "BGA_UpdateSurveyResults", sqlParams);

                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "SurveyResultsProvider", "Update", ArrangeParamValues(sqlParams));
                }
            }

            public static int UpdateByParams(int id, int? surveyItemId, int? userID, DateTime? createDate)
            {
                SqlParameter[] sqlParams = null;

                try
                {
                    sqlParams = new SqlParameter[] { 
					new SqlParameter("@ID",id),
					new SqlParameter("@SurveyItemId",surveyItemId),
					new SqlParameter("@UserID",userID),
					new SqlParameter("@CreateDate",createDate)
                };

                    return ExecuteNonQuery("BGA_UpdateSurveyResultsByParams", sqlParams);

                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "SurveyResultsProvider", "UpdateByParams", ArrangeParamValues(sqlParams));
                }
            }

            public static int UpdateByParams(params SqlParameter[] sqlParams)
            {
                try
                {

                    return ExecuteNonQuery("BGA_UpdateSurveyResultsByParams", sqlParams);

                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "SurveyResultsProvider", "UpdateByParams", ArrangeParamValues(sqlParams));
                }
            }

            public static int UpdateByParams(SqlTransaction tran, int id, int? surveyItemId, int? userID, DateTime? createDate)
            {
                SqlParameter[] sqlParams = null;

                try
                {
                    sqlParams = new SqlParameter[] { 
					new SqlParameter("@ID",id),
					new SqlParameter("@SurveyItemId",surveyItemId),
					new SqlParameter("@UserID",userID),
					new SqlParameter("@CreateDate",createDate)
                };

                    return ExecuteNonQuery(tran, "BGA_UpdateSurveyResultsByParams", sqlParams);

                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "SurveyResultsProvider", "UpdateByParams", ArrangeParamValues(sqlParams));
                }
            }

            public static int UpdateByParams(SqlTransaction tran, params SqlParameter[] sqlParams)
            {
                try
                {

                    return ExecuteNonQuery(tran, "BGA_UpdateSurveyResultsByParams", sqlParams);

                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "SurveyResultsProvider", "UpdateByParams", ArrangeParamValues(sqlParams));
                }
            }
            #endregion

            #region Add Functions
            public static int Add(int surveyItemId, int userID, DateTime createDate)
            {
                SqlParameter[] sqlParams = null;

                try
                {
                    sqlParams = new SqlParameter[] { 
					new SqlParameter("@SurveyItemId",surveyItemId),
					new SqlParameter("@UserID",userID),
					new SqlParameter("@CreateDate",createDate)
                };

                    return ExecuteScalar("BGA_AddSurveyResults", sqlParams);

                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "SurveyResultsProvider", "Add", ArrangeParamValues(sqlParams));
                }
            }

            public static int Add(SqlTransaction tran, int surveyItemId, int userID, DateTime createDate)
            {
                SqlParameter[] sqlParams = null;

                try
                {
                    sqlParams = new SqlParameter[] { 
					new SqlParameter("@SurveyItemId",surveyItemId),
					new SqlParameter("@UserID",userID),
					new SqlParameter("@CreateDate",createDate)
                };

                    return ExecuteScalar(tran, "BGA_AddSurveyResults", sqlParams);

                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "SurveyResultsProvider", "Add", ArrangeParamValues(sqlParams));
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

                    return ExecuteNonQuery("BGA_DeleteSurveyResults", sqlParams);

                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "SurveyResultsProvider", "Delete", ArrangeParamValues(sqlParams));
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

                    return ExecuteNonQuery(tran, "BGA_DeleteSurveyResults", sqlParams);

                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "SurveyResultsProvider", "Delete", ArrangeParamValues(sqlParams));
                }
            }

            public static int DeleteByParams(SqlTransaction tran, int? id, int? surveyItemId, int? userID, DateTime? createDate, DateTime? beforeCreateDate, DateTime? afterOrEqualCreateDate)
            {
                SqlParameter[] sqlParams = null;

                try
                {
                    sqlParams = new SqlParameter[] { 
					new SqlParameter("@ID",id),
					new SqlParameter("@SurveyItemId",surveyItemId),
					new SqlParameter("@UserID",userID),
					new SqlParameter("@CreateDate",createDate),
					new SqlParameter("@BeforeCreateDate",beforeCreateDate),
					new SqlParameter("@AfterOrEqualCreateDate",afterOrEqualCreateDate)
                };

                    if (tran == null)
                        return ExecuteNonQuery("BGA_DeleteSurveyResultsByParams", sqlParams);
                    else
                        return ExecuteNonQuery(tran, "BGA_DeleteSurveyResultsByParams", sqlParams);


                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "SurveyResultsProvider", "DeleteByParams", ArrangeParamValues(sqlParams));
                }
            }

            public static int DeleteByParams(int? id, int? surveyItemId, int? userID, DateTime? createDate, DateTime? beforeCreateDate, DateTime? afterOrEqualCreateDate)
            {
                return DeleteByParams(null, id, surveyItemId, userID, createDate, beforeCreateDate, afterOrEqualCreateDate)
    ;
            }



            #endregion

        }
    }
}
