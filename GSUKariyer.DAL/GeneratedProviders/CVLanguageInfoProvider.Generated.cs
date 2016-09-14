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

    public partial class CVLanguageInfoProvider : BaseDataLayer
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
                        ds = ExecuteDataset("BGA_GetCVLanguageInfo", sqlParams);
                    else
                        ds = ExecuteDataset(tran, "BGA_GetCVLanguageInfo", sqlParams);

                    return ds;
                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "CVLanguageInfoProvider", "Get", ArrangeParamValues(sqlParams));
                }
            }

            public static DataSet GetByParams(int? id, int? cVId, int? languageId, int? readGrade, int? writeGrade, int? talkGrade, string howLearned)
            {
                return GetByParams(null, id, cVId, languageId, readGrade, writeGrade, talkGrade, howLearned)
    ;
            }

            public static DataSet GetByParams(SqlTransaction tran, int? id, int? cVId, int? languageId, int? readGrade, int? writeGrade, int? talkGrade, string howLearned)
            {
                SqlParameter[] sqlParams = null;

                try
                {
                    DataSet ds = null;

                    sqlParams = new SqlParameter[] { 
					new SqlParameter("@ID",id),
					new SqlParameter("@CVId",cVId),
					new SqlParameter("@LanguageId",languageId),
					new SqlParameter("@ReadGrade",readGrade),
					new SqlParameter("@WriteGrade",writeGrade),
					new SqlParameter("@TalkGrade",talkGrade),
					new SqlParameter("@HowLearned",howLearned)
                };

                    if (tran == null)
                        ds = ExecuteDataset("BGA_GetCVLanguageInfoByParams", sqlParams);
                    else
                        ds = ExecuteDataset(tran, "BGA_GetCVLanguageInfoByParams", sqlParams);

                    return ds;
                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "CVLanguageInfoProvider", "GetByParams", ArrangeParamValues(sqlParams));
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

                    ds = ExecuteDataset("BGA_GetCVLanguageInfoByParams", sqlParams);

                    return ds;
                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "CVLanguageInfoProvider", "GetByParams", ArrangeParamValues(sqlParams));
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
                        ds = ExecuteDataset("BGA_GetCVLanguageInfoByFK", sqlParams);
                    else
                        ds = ExecuteDataset(tran, "BGA_GetCVLanguageInfoByFK", sqlParams);

                    return ds;
                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "CVLanguageInfoProvider", "GetByFK", ArrangeParamValues(sqlParams));
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
            public static int Update(int id, int cVId, int languageId, int? readGrade, int? writeGrade, int? talkGrade, string howLearned)
            {
                SqlParameter[] sqlParams = null;

                try
                {
                    sqlParams = new SqlParameter[] { 
					new SqlParameter("@ID",id),
					new SqlParameter("@CVId",cVId),
					new SqlParameter("@LanguageId",languageId),
					new SqlParameter("@ReadGrade",readGrade),
					new SqlParameter("@WriteGrade",writeGrade),
					new SqlParameter("@TalkGrade",talkGrade),
					new SqlParameter("@HowLearned",howLearned)
                };

                    return ExecuteNonQuery("BGA_UpdateCVLanguageInfo", sqlParams);

                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "CVLanguageInfoProvider", "Update", ArrangeParamValues(sqlParams));
                }
            }

            public static int Update(SqlTransaction tran, int id, int cVId, int languageId, int? readGrade, int? writeGrade, int? talkGrade, string howLearned)
            {
                SqlParameter[] sqlParams = null;

                try
                {
                    sqlParams = new SqlParameter[] { 
					new SqlParameter("@ID",id),
					new SqlParameter("@CVId",cVId),
					new SqlParameter("@LanguageId",languageId),
					new SqlParameter("@ReadGrade",readGrade),
					new SqlParameter("@WriteGrade",writeGrade),
					new SqlParameter("@TalkGrade",talkGrade),
					new SqlParameter("@HowLearned",howLearned)
                };

                    return ExecuteNonQuery(tran, "BGA_UpdateCVLanguageInfo", sqlParams);

                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "CVLanguageInfoProvider", "Update", ArrangeParamValues(sqlParams));
                }
            }

            public static int UpdateByParams(int id, int? cVId, int? languageId, int? readGrade, int? writeGrade, int? talkGrade, string howLearned)
            {
                SqlParameter[] sqlParams = null;

                try
                {
                    sqlParams = new SqlParameter[] { 
					new SqlParameter("@ID",id),
					new SqlParameter("@CVId",cVId),
					new SqlParameter("@LanguageId",languageId),
					new SqlParameter("@ReadGrade",readGrade),
					new SqlParameter("@WriteGrade",writeGrade),
					new SqlParameter("@TalkGrade",talkGrade),
					new SqlParameter("@HowLearned",howLearned)
                };

                    return ExecuteNonQuery("BGA_UpdateCVLanguageInfoByParams", sqlParams);

                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "CVLanguageInfoProvider", "UpdateByParams", ArrangeParamValues(sqlParams));
                }
            }

            public static int UpdateByParams(params SqlParameter[] sqlParams)
            {
                try
                {

                    return ExecuteNonQuery("BGA_UpdateCVLanguageInfoByParams", sqlParams);

                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "CVLanguageInfoProvider", "UpdateByParams", ArrangeParamValues(sqlParams));
                }
            }

            public static int UpdateByParams(SqlTransaction tran, int id, int? cVId, int? languageId, int? readGrade, int? writeGrade, int? talkGrade, string howLearned)
            {
                SqlParameter[] sqlParams = null;

                try
                {
                    sqlParams = new SqlParameter[] { 
					new SqlParameter("@ID",id),
					new SqlParameter("@CVId",cVId),
					new SqlParameter("@LanguageId",languageId),
					new SqlParameter("@ReadGrade",readGrade),
					new SqlParameter("@WriteGrade",writeGrade),
					new SqlParameter("@TalkGrade",talkGrade),
					new SqlParameter("@HowLearned",howLearned)
                };

                    return ExecuteNonQuery(tran, "BGA_UpdateCVLanguageInfoByParams", sqlParams);

                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "CVLanguageInfoProvider", "UpdateByParams", ArrangeParamValues(sqlParams));
                }
            }

            public static int UpdateByParams(SqlTransaction tran, params SqlParameter[] sqlParams)
            {
                try
                {

                    return ExecuteNonQuery(tran, "BGA_UpdateCVLanguageInfoByParams", sqlParams);

                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "CVLanguageInfoProvider", "UpdateByParams", ArrangeParamValues(sqlParams));
                }
            }
            #endregion

            #region Add Functions
            public static int Add(int cVId, int languageId, int? readGrade, int? writeGrade, int? talkGrade, string howLearned)
            {
                SqlParameter[] sqlParams = null;

                try
                {
                    sqlParams = new SqlParameter[] { 
					new SqlParameter("@CVId",cVId),
					new SqlParameter("@LanguageId",languageId),
					new SqlParameter("@ReadGrade",readGrade),
					new SqlParameter("@WriteGrade",writeGrade),
					new SqlParameter("@TalkGrade",talkGrade),
					new SqlParameter("@HowLearned",howLearned)
                };

                    return ExecuteScalar("BGA_AddCVLanguageInfo", sqlParams);

                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "CVLanguageInfoProvider", "Add", ArrangeParamValues(sqlParams));
                }
            }

            public static int Add(SqlTransaction tran, int cVId, int languageId, int? readGrade, int? writeGrade, int? talkGrade, string howLearned)
            {
                SqlParameter[] sqlParams = null;

                try
                {
                    sqlParams = new SqlParameter[] { 
					new SqlParameter("@CVId",cVId),
					new SqlParameter("@LanguageId",languageId),
					new SqlParameter("@ReadGrade",readGrade),
					new SqlParameter("@WriteGrade",writeGrade),
					new SqlParameter("@TalkGrade",talkGrade),
					new SqlParameter("@HowLearned",howLearned)
                };

                    return ExecuteScalar(tran, "BGA_AddCVLanguageInfo", sqlParams);

                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "CVLanguageInfoProvider", "Add", ArrangeParamValues(sqlParams));
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

                    return ExecuteNonQuery("BGA_DeleteCVLanguageInfo", sqlParams);

                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "CVLanguageInfoProvider", "Delete", ArrangeParamValues(sqlParams));
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

                    return ExecuteNonQuery(tran, "BGA_DeleteCVLanguageInfo", sqlParams);

                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "CVLanguageInfoProvider", "Delete", ArrangeParamValues(sqlParams));
                }
            }

            public static int DeleteByParams(SqlTransaction tran, int? id, int? cVId, int? languageId, int? readGrade, int? writeGrade, int? talkGrade, string howLearned)
            {
                SqlParameter[] sqlParams = null;

                try
                {
                    sqlParams = new SqlParameter[] { 
					new SqlParameter("@ID",id),
					new SqlParameter("@CVId",cVId),
					new SqlParameter("@LanguageId",languageId),
					new SqlParameter("@ReadGrade",readGrade),
					new SqlParameter("@WriteGrade",writeGrade),
					new SqlParameter("@TalkGrade",talkGrade),
					new SqlParameter("@HowLearned",howLearned)
                };

                    if (tran == null)
                        return ExecuteNonQuery("BGA_DeleteCVLanguageInfoByParams", sqlParams);
                    else
                        return ExecuteNonQuery(tran, "BGA_DeleteCVLanguageInfoByParams", sqlParams);


                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "CVLanguageInfoProvider", "DeleteByParams", ArrangeParamValues(sqlParams));
                }
            }

            public static int DeleteByParams(int? id, int? cVId, int? languageId, int? readGrade, int? writeGrade, int? talkGrade, string howLearned)
            {
                return DeleteByParams(null, id, cVId, languageId, readGrade, writeGrade, talkGrade, howLearned)
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
                        return ExecuteNonQuery("BGA_DeleteCVLanguageInfoByFK", sqlParams);
                    else
                        return ExecuteNonQuery(tran, "BGA_DeleteCVLanguageInfoByFK", sqlParams);

                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "CVLanguageInfoProvider", "DeleteByFK", ArrangeParamValues(sqlParams));
                }
            }


            #endregion

        }
    }
}
