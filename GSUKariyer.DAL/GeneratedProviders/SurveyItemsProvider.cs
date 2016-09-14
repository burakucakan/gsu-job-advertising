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

    public partial class SurveyItemsProvider : BaseDataLayer
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
                        ds = ExecuteDataset("BGA_GetSurveyItems", sqlParams);
                    else
                        ds = ExecuteDataset(tran, "BGA_GetSurveyItems", sqlParams);

                    return ds;
                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "SurveyItemsProvider", "Get", ArrangeParamValues(sqlParams));
                }
            }

            public static DataSet GetByParams(int? id, int? surveyId, string description, int? order, DateTime? modifyDate, DateTime? beforeModifyDate, DateTime? afterOrEqualModifyDate, DateTime? createDate, DateTime? beforeCreateDate, DateTime? afterOrEqualCreateDate, int? voteCount)
            {
                return GetByParams(null, id, surveyId, description, order, modifyDate, beforeModifyDate, afterOrEqualModifyDate, createDate, beforeCreateDate, afterOrEqualCreateDate, voteCount)
    ;
            }

            public static DataSet GetByParams(SqlTransaction tran, int? id, int? surveyId, string description, int? order, DateTime? modifyDate, DateTime? beforeModifyDate, DateTime? afterOrEqualModifyDate, DateTime? createDate, DateTime? beforeCreateDate, DateTime? afterOrEqualCreateDate, int? voteCount)
            {
                SqlParameter[] sqlParams = null;

                try
                {
                    DataSet ds = null;

                    sqlParams = new SqlParameter[] { 
					new SqlParameter("@ID",id),
					new SqlParameter("@SurveyId",surveyId),
					new SqlParameter("@Description",description),
					new SqlParameter("@Order",order),
					new SqlParameter("@ModifyDate",modifyDate),
					new SqlParameter("@BeforeModifyDate",beforeModifyDate),
					new SqlParameter("@AfterOrEqualModifyDate",afterOrEqualModifyDate),
					new SqlParameter("@CreateDate",createDate),
					new SqlParameter("@BeforeCreateDate",beforeCreateDate),
					new SqlParameter("@AfterOrEqualCreateDate",afterOrEqualCreateDate),
					new SqlParameter("@VoteCount",voteCount)
                };

                    if (tran == null)
                        ds = ExecuteDataset("BGA_GetSurveyItemsByParams", sqlParams);
                    else
                        ds = ExecuteDataset(tran, "BGA_GetSurveyItemsByParams", sqlParams);

                    return ds;
                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "SurveyItemsProvider", "GetByParams", ArrangeParamValues(sqlParams));
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

                    ds = ExecuteDataset("BGA_GetSurveyItemsByParams", sqlParams);

                    return ds;
                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "SurveyItemsProvider", "GetByParams", ArrangeParamValues(sqlParams));
                }
            }

            public static DataSet GetByFKBasic(int? surveyId)
            {
                return GetByFKBasic(null, surveyId);
            }

            public static DataSet GetByFKBasic(SqlTransaction tran, int? surveyId)
            {
                SqlParameter[] sqlParams = null;

                try
                {
                    DataSet ds = null;

                    sqlParams = new SqlParameter[] { 
					new SqlParameter("@SurveyId",surveyId)
                };

                    if (tran == null)
                        ds = ExecuteDataset("BGA_GetSurveyItemsByFK", sqlParams);
                    else
                        ds = ExecuteDataset(tran, "BGA_GetSurveyItemsByFK", sqlParams);

                    return ds;
                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "SurveyItemsProvider", "GetByFK", ArrangeParamValues(sqlParams));
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

            public static DataSet GetByFK(SqlTransaction tran, int surveyId)
            {
                return GetByFKBasic(tran, surveyId);
            }

            public static DataSet GetByFK(int surveyId)
            {
                return GetByFKBasic(surveyId);
            }


            #endregion

            #region Update Functions
            public static int Update(int id, int surveyId, string description, int order, DateTime modifyDate, int voteCount)
            {
                SqlParameter[] sqlParams = null;

                try
                {
                    sqlParams = new SqlParameter[] { 
					new SqlParameter("@ID",id),
					new SqlParameter("@SurveyId",surveyId),
					new SqlParameter("@Description",description),
					new SqlParameter("@Order",order),
					new SqlParameter("@ModifyDate",modifyDate),
					new SqlParameter("@VoteCount",voteCount)
                };

                    return ExecuteNonQuery("BGA_UpdateSurveyItems", sqlParams);

                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "SurveyItemsProvider", "Update", ArrangeParamValues(sqlParams));
                }
            }

            public static int Update(SqlTransaction tran, int id, int surveyId, string description, int order, DateTime modifyDate, int voteCount)
            {
                SqlParameter[] sqlParams = null;

                try
                {
                    sqlParams = new SqlParameter[] { 
					new SqlParameter("@ID",id),
					new SqlParameter("@SurveyId",surveyId),
					new SqlParameter("@Description",description),
					new SqlParameter("@Order",order),
					new SqlParameter("@ModifyDate",modifyDate),
					new SqlParameter("@VoteCount",voteCount)
                };

                    return ExecuteNonQuery(tran, "BGA_UpdateSurveyItems", sqlParams);

                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "SurveyItemsProvider", "Update", ArrangeParamValues(sqlParams));
                }
            }

            public static int UpdateByParams(int id, int? surveyId, string description, int? order, DateTime? modifyDate, DateTime? createDate, int? voteCount)
            {
                SqlParameter[] sqlParams = null;

                try
                {
                    sqlParams = new SqlParameter[] { 
					new SqlParameter("@ID",id),
					new SqlParameter("@SurveyId",surveyId),
					new SqlParameter("@Description",description),
					new SqlParameter("@Order",order),
					new SqlParameter("@ModifyDate",modifyDate),
					new SqlParameter("@CreateDate",createDate),
					new SqlParameter("@VoteCount",voteCount)
                };

                    return ExecuteNonQuery("BGA_UpdateSurveyItemsByParams", sqlParams);

                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "SurveyItemsProvider", "UpdateByParams", ArrangeParamValues(sqlParams));
                }
            }

            public static int UpdateByParams(params SqlParameter[] sqlParams)
            {
                try
                {

                    return ExecuteNonQuery("BGA_UpdateSurveyItemsByParams", sqlParams);

                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "SurveyItemsProvider", "UpdateByParams", ArrangeParamValues(sqlParams));
                }
            }

            public static int UpdateByParams(SqlTransaction tran, int id, int? surveyId, string description, int? order, DateTime? modifyDate, DateTime? createDate, int? voteCount)
            {
                SqlParameter[] sqlParams = null;

                try
                {
                    sqlParams = new SqlParameter[] { 
					new SqlParameter("@ID",id),
					new SqlParameter("@SurveyId",surveyId),
					new SqlParameter("@Description",description),
					new SqlParameter("@Order",order),
					new SqlParameter("@ModifyDate",modifyDate),
					new SqlParameter("@CreateDate",createDate),
					new SqlParameter("@VoteCount",voteCount)
                };

                    return ExecuteNonQuery(tran, "BGA_UpdateSurveyItemsByParams", sqlParams);

                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "SurveyItemsProvider", "UpdateByParams", ArrangeParamValues(sqlParams));
                }
            }

            public static int UpdateByParams(SqlTransaction tran, params SqlParameter[] sqlParams)
            {
                try
                {

                    return ExecuteNonQuery(tran, "BGA_UpdateSurveyItemsByParams", sqlParams);

                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "SurveyItemsProvider", "UpdateByParams", ArrangeParamValues(sqlParams));
                }
            }
            #endregion

            #region Add Functions
            public static int Add(int surveyId, string description, int order, DateTime modifyDate, DateTime createDate, int voteCount)
            {
                SqlParameter[] sqlParams = null;

                try
                {
                    sqlParams = new SqlParameter[] { 
					new SqlParameter("@SurveyId",surveyId),
					new SqlParameter("@Description",description),
					new SqlParameter("@Order",order),
					new SqlParameter("@ModifyDate",modifyDate),
					new SqlParameter("@CreateDate",createDate),
					new SqlParameter("@VoteCount",voteCount)
                };

                    return ExecuteScalar("BGA_AddSurveyItems", sqlParams);

                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "SurveyItemsProvider", "Add", ArrangeParamValues(sqlParams));
                }
            }

            public static int Add(SqlTransaction tran, int surveyId, string description, int order, DateTime modifyDate, DateTime createDate, int voteCount)
            {
                SqlParameter[] sqlParams = null;

                try
                {
                    sqlParams = new SqlParameter[] { 
					new SqlParameter("@SurveyId",surveyId),
					new SqlParameter("@Description",description),
					new SqlParameter("@Order",order),
					new SqlParameter("@ModifyDate",modifyDate),
					new SqlParameter("@CreateDate",createDate),
					new SqlParameter("@VoteCount",voteCount)
                };

                    return ExecuteScalar(tran, "BGA_AddSurveyItems", sqlParams);

                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "SurveyItemsProvider", "Add", ArrangeParamValues(sqlParams));
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

                    return ExecuteNonQuery("BGA_DeleteSurveyItems", sqlParams);

                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "SurveyItemsProvider", "Delete", ArrangeParamValues(sqlParams));
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

                    return ExecuteNonQuery(tran, "BGA_DeleteSurveyItems", sqlParams);

                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "SurveyItemsProvider", "Delete", ArrangeParamValues(sqlParams));
                }
            }

            public static int DeleteByParams(SqlTransaction tran, int? id, int? surveyId, string description, int? order, DateTime? modifyDate, DateTime? beforeModifyDate, DateTime? afterOrEqualModifyDate, DateTime? createDate, DateTime? beforeCreateDate, DateTime? afterOrEqualCreateDate, int? voteCount)
            {
                SqlParameter[] sqlParams = null;

                try
                {
                    sqlParams = new SqlParameter[] { 
					new SqlParameter("@ID",id),
					new SqlParameter("@SurveyId",surveyId),
					new SqlParameter("@Description",description),
					new SqlParameter("@Order",order),
					new SqlParameter("@ModifyDate",modifyDate),
					new SqlParameter("@BeforeModifyDate",beforeModifyDate),
					new SqlParameter("@AfterOrEqualModifyDate",afterOrEqualModifyDate),
					new SqlParameter("@CreateDate",createDate),
					new SqlParameter("@BeforeCreateDate",beforeCreateDate),
					new SqlParameter("@AfterOrEqualCreateDate",afterOrEqualCreateDate),
					new SqlParameter("@VoteCount",voteCount)
                };

                    if (tran == null)
                        return ExecuteNonQuery("BGA_DeleteSurveyItemsByParams", sqlParams);
                    else
                        return ExecuteNonQuery(tran, "BGA_DeleteSurveyItemsByParams", sqlParams);


                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "SurveyItemsProvider", "DeleteByParams", ArrangeParamValues(sqlParams));
                }
            }

            public static int DeleteByParams(int? id, int? surveyId, string description, int? order, DateTime? modifyDate, DateTime? beforeModifyDate, DateTime? afterOrEqualModifyDate, DateTime? createDate, DateTime? beforeCreateDate, DateTime? afterOrEqualCreateDate, int? voteCount)
            {
                return DeleteByParams(null, id, surveyId, description, order, modifyDate, beforeModifyDate, afterOrEqualModifyDate, createDate, beforeCreateDate, afterOrEqualCreateDate, voteCount)
    ;
            }

            public static int DeleteByFK(int? surveyId)
            {
                return DeleteByFK(null, surveyId)
    ;
            }

            public static int DeleteByFK(SqlTransaction tran, int? surveyId)
            {
                SqlParameter[] sqlParams = null;

                try
                {

                    sqlParams = new SqlParameter[] { 
					new SqlParameter("@SurveyId",surveyId)
                };

                    if (tran == null)
                        return ExecuteNonQuery("BGA_DeleteSurveyItemsByFK", sqlParams);
                    else
                        return ExecuteNonQuery(tran, "BGA_DeleteSurveyItemsByFK", sqlParams);

                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "SurveyItemsProvider", "DeleteByFK", ArrangeParamValues(sqlParams));
                }
            }


            #endregion

        }
    }
}
