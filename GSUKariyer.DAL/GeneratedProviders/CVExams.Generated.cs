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

    public partial class CVExamsProvider : BaseDataLayer
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
                        ds = ExecuteDataset("BGA_GetCVExams", sqlParams);
                    else
                        ds = ExecuteDataset(tran, "BGA_GetCVExams", sqlParams);

                    return ds;
                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "CVExamsProvider", "Get", ArrangeParamValues(sqlParams));
                }
            }

            public static DataSet GetByParams(int? id, int? cVId, string examName, string examCorporation, int? startYear, int? examScore, string description)
            {
                return GetByParams(null, id, cVId, examName, examCorporation, startYear, examScore, description)
    ;
            }

            public static DataSet GetByParams(SqlTransaction tran, int? id, int? cVId, string examName, string examCorporation, int? startYear, int? examScore, string description)
            {
                SqlParameter[] sqlParams = null;

                try
                {
                    DataSet ds = null;

                    sqlParams = new SqlParameter[] { 
					new SqlParameter("@ID",id),
					new SqlParameter("@CVId",cVId),
					new SqlParameter("@ExamName",examName),
					new SqlParameter("@ExamCorporation",examCorporation),
					new SqlParameter("@StartYear",startYear),
					new SqlParameter("@ExamScore",examScore),
					new SqlParameter("@Description",description)
                };

                    if (tran == null)
                        ds = ExecuteDataset("BGA_GetCVExamsByParams", sqlParams);
                    else
                        ds = ExecuteDataset(tran, "BGA_GetCVExamsByParams", sqlParams);

                    return ds;
                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "CVExamsProvider", "GetByParams", ArrangeParamValues(sqlParams));
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

                    ds = ExecuteDataset("BGA_GetCVExamsByParams", sqlParams);

                    return ds;
                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "CVExamsProvider", "GetByParams", ArrangeParamValues(sqlParams));
                }
            }

            public static DataSet GetByFKBasic(int? cVId)
            {
                return GetByFKBasic(null, cVId);
            }

            public static DataSet GetByFKBasic(SqlTransaction tran, int? cVId)
            {
                SqlParameter[] sqlParams = null;

                try
                {
                    DataSet ds = null;

                    sqlParams = new SqlParameter[] { 
					new SqlParameter("@CVId",cVId)
                };

                    if (tran == null)
                        ds = ExecuteDataset("BGA_GetCVExamsByFK", sqlParams);
                    else
                        ds = ExecuteDataset(tran, "BGA_GetCVExamsByFK", sqlParams);

                    return ds;
                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "CVExamsProvider", "GetByFK", ArrangeParamValues(sqlParams));
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

            public static DataSet GetByFK(SqlTransaction tran, int cVId)
            {
                return GetByFKBasic(tran, cVId);
            }

            public static DataSet GetByFK(int cVId)
            {
                return GetByFKBasic(cVId);
            }


            #endregion

            #region Update Functions
            public static int Update(int id, int cVId, string examName, string examCorporation, int startYear, int examScore, string description)
            {
                SqlParameter[] sqlParams = null;

                try
                {
                    sqlParams = new SqlParameter[] { 
					new SqlParameter("@ID",id),
					new SqlParameter("@CVId",cVId),
					new SqlParameter("@ExamName",examName),
					new SqlParameter("@ExamCorporation",examCorporation),
					new SqlParameter("@StartYear",startYear),
					new SqlParameter("@ExamScore",examScore),
					new SqlParameter("@Description",description)
                };

                    return ExecuteNonQuery("BGA_UpdateCVExams", sqlParams);

                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "CVExamsProvider", "Update", ArrangeParamValues(sqlParams));
                }
            }

            public static int Update(SqlTransaction tran, int id, int cVId, string examName, string examCorporation, int startYear, int examScore, string description)
            {
                SqlParameter[] sqlParams = null;

                try
                {
                    sqlParams = new SqlParameter[] { 
					new SqlParameter("@ID",id),
					new SqlParameter("@CVId",cVId),
					new SqlParameter("@ExamName",examName),
					new SqlParameter("@ExamCorporation",examCorporation),
					new SqlParameter("@StartYear",startYear),
					new SqlParameter("@ExamScore",examScore),
					new SqlParameter("@Description",description)
                };

                    return ExecuteNonQuery(tran, "BGA_UpdateCVExams", sqlParams);

                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "CVExamsProvider", "Update", ArrangeParamValues(sqlParams));
                }
            }

            public static int UpdateByParams(int id, int? cVId, string examName, string examCorporation, int? startYear, int? examScore, string description)
            {
                SqlParameter[] sqlParams = null;

                try
                {
                    sqlParams = new SqlParameter[] { 
					new SqlParameter("@ID",id),
					new SqlParameter("@CVId",cVId),
					new SqlParameter("@ExamName",examName),
					new SqlParameter("@ExamCorporation",examCorporation),
					new SqlParameter("@StartYear",startYear),
					new SqlParameter("@ExamScore",examScore),
					new SqlParameter("@Description",description)
                };

                    return ExecuteNonQuery("BGA_UpdateCVExamsByParams", sqlParams);

                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "CVExamsProvider", "UpdateByParams", ArrangeParamValues(sqlParams));
                }
            }

            public static int UpdateByParams(params SqlParameter[] sqlParams)
            {
                try
                {

                    return ExecuteNonQuery("BGA_UpdateCVExamsByParams", sqlParams);

                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "CVExamsProvider", "UpdateByParams", ArrangeParamValues(sqlParams));
                }
            }

            public static int UpdateByParams(SqlTransaction tran, int id, int? cVId, string examName, string examCorporation, int? startYear, int? examScore, string description)
            {
                SqlParameter[] sqlParams = null;

                try
                {
                    sqlParams = new SqlParameter[] { 
					new SqlParameter("@ID",id),
					new SqlParameter("@CVId",cVId),
					new SqlParameter("@ExamName",examName),
					new SqlParameter("@ExamCorporation",examCorporation),
					new SqlParameter("@StartYear",startYear),
					new SqlParameter("@ExamScore",examScore),
					new SqlParameter("@Description",description)
                };

                    return ExecuteNonQuery(tran, "BGA_UpdateCVExamsByParams", sqlParams);

                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "CVExamsProvider", "UpdateByParams", ArrangeParamValues(sqlParams));
                }
            }

            public static int UpdateByParams(SqlTransaction tran, params SqlParameter[] sqlParams)
            {
                try
                {

                    return ExecuteNonQuery(tran, "BGA_UpdateCVExamsByParams", sqlParams);

                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "CVExamsProvider", "UpdateByParams", ArrangeParamValues(sqlParams));
                }
            }
            #endregion

            #region Add Functions
            public static int Add(int cVId, string examName, string examCorporation, int startYear, int examScore, string description)
            {
                SqlParameter[] sqlParams = null;

                try
                {
                    sqlParams = new SqlParameter[] { 
					new SqlParameter("@CVId",cVId),
					new SqlParameter("@ExamName",examName),
					new SqlParameter("@ExamCorporation",examCorporation),
					new SqlParameter("@StartYear",startYear),
					new SqlParameter("@ExamScore",examScore),
					new SqlParameter("@Description",description)
                };

                    return ExecuteScalar("BGA_AddCVExams", sqlParams);

                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "CVExamsProvider", "Add", ArrangeParamValues(sqlParams));
                }
            }

            public static int Add(SqlTransaction tran, int cVId, string examName, string examCorporation, int startYear, int examScore, string description)
            {
                SqlParameter[] sqlParams = null;

                try
                {
                    sqlParams = new SqlParameter[] { 
					new SqlParameter("@CVId",cVId),
					new SqlParameter("@ExamName",examName),
					new SqlParameter("@ExamCorporation",examCorporation),
					new SqlParameter("@StartYear",startYear),
					new SqlParameter("@ExamScore",examScore),
					new SqlParameter("@Description",description)
                };

                    return ExecuteScalar(tran, "BGA_AddCVExams", sqlParams);

                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "CVExamsProvider", "Add", ArrangeParamValues(sqlParams));
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

                    return ExecuteNonQuery("BGA_DeleteCVExams", sqlParams);

                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "CVExamsProvider", "Delete", ArrangeParamValues(sqlParams));
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

                    return ExecuteNonQuery(tran, "BGA_DeleteCVExams", sqlParams);

                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "CVExamsProvider", "Delete", ArrangeParamValues(sqlParams));
                }
            }

            public static int DeleteByParams(SqlTransaction tran, int? id, int? cVId, string examName, string examCorporation, int? startYear, int? examScore, string description)
            {
                SqlParameter[] sqlParams = null;

                try
                {
                    sqlParams = new SqlParameter[] { 
					new SqlParameter("@ID",id),
					new SqlParameter("@CVId",cVId),
					new SqlParameter("@ExamName",examName),
					new SqlParameter("@ExamCorporation",examCorporation),
					new SqlParameter("@StartYear",startYear),
					new SqlParameter("@ExamScore",examScore),
					new SqlParameter("@Description",description)
                };

                    if (tran == null)
                        return ExecuteNonQuery("BGA_DeleteCVExamsByParams", sqlParams);
                    else
                        return ExecuteNonQuery(tran, "BGA_DeleteCVExamsByParams", sqlParams);


                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "CVExamsProvider", "DeleteByParams", ArrangeParamValues(sqlParams));
                }
            }

            public static int DeleteByParams(int? id, int? cVId, string examName, string examCorporation, int? startYear, int? examScore, string description)
            {
                return DeleteByParams(null, id, cVId, examName, examCorporation, startYear, examScore, description)
    ;
            }

            public static int DeleteByFK(int? cVId)
            {
                return DeleteByFK(null, cVId)
    ;
            }

            public static int DeleteByFK(SqlTransaction tran, int? cVId)
            {
                SqlParameter[] sqlParams = null;

                try
                {

                    sqlParams = new SqlParameter[] { 
					new SqlParameter("@CVId",cVId)
                };

                    if (tran == null)
                        return ExecuteNonQuery("BGA_DeleteCVExamsByFK", sqlParams);
                    else
                        return ExecuteNonQuery(tran, "BGA_DeleteCVExamsByFK", sqlParams);

                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "CVExamsProvider", "DeleteByFK", ArrangeParamValues(sqlParams));
                }
            }


            #endregion

        }
    }
}
