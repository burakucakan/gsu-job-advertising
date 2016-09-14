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

    public partial class CVWorkExperiencesProvider : BaseDataLayer
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
                        ds = ExecuteDataset("BGA_GetCVWorkExperiences", sqlParams);
                    else
                        ds = ExecuteDataset(tran, "BGA_GetCVWorkExperiences", sqlParams);

                    return ds;
                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "CVWorkExperiencesProvider", "Get", ArrangeParamValues(sqlParams));
                }
            }

            public static DataSet GetByParams(int? id, int? cVId, string firmName, DateTime? workStartDate, DateTime? beforeWorkStartDate, DateTime? afterOrEqualWorkStartDate, DateTime? workEndDate, DateTime? beforeWorkEndDate, DateTime? afterOrEqualWorkEndDate, string workCity, string firmSector, int? firmWorkerCount, string workingPosition, int? workingType, int? numberOfPeopleOnResponsibility, int? workingExperience, string jobLeavingReason, int? jobFindingType, string jobDescription, string responsibleName, string responsibleTitle, string responsiblePhone)
            {
                return GetByParams(null, id, cVId, firmName, workStartDate, beforeWorkStartDate, afterOrEqualWorkStartDate, workEndDate, beforeWorkEndDate, afterOrEqualWorkEndDate, workCity, firmSector, firmWorkerCount, workingPosition, workingType, numberOfPeopleOnResponsibility, workingExperience, jobLeavingReason, jobFindingType, jobDescription, responsibleName, responsibleTitle, responsiblePhone)
    ;
            }

            public static DataSet GetByParams(SqlTransaction tran, int? id, int? cVId, string firmName, DateTime? workStartDate, DateTime? beforeWorkStartDate, DateTime? afterOrEqualWorkStartDate, DateTime? workEndDate, DateTime? beforeWorkEndDate, DateTime? afterOrEqualWorkEndDate, string workCity, string firmSector, int? firmWorkerCount, string workingPosition, int? workingType, int? numberOfPeopleOnResponsibility, int? workingExperience, string jobLeavingReason, int? jobFindingType, string jobDescription, string responsibleName, string responsibleTitle, string responsiblePhone)
            {
                SqlParameter[] sqlParams = null;

                try
                {
                    DataSet ds = null;

                    sqlParams = new SqlParameter[] { 
					new SqlParameter("@ID",id),
					new SqlParameter("@CVId",cVId),
					new SqlParameter("@FirmName",firmName),
					new SqlParameter("@WorkStartDate",workStartDate),
					new SqlParameter("@BeforeWorkStartDate",beforeWorkStartDate),
					new SqlParameter("@AfterOrEqualWorkStartDate",afterOrEqualWorkStartDate),
					new SqlParameter("@WorkEndDate",workEndDate),
					new SqlParameter("@BeforeWorkEndDate",beforeWorkEndDate),
					new SqlParameter("@AfterOrEqualWorkEndDate",afterOrEqualWorkEndDate),
					new SqlParameter("@WorkCity",workCity),
					new SqlParameter("@FirmSector",firmSector),
					new SqlParameter("@FirmWorkerCount",firmWorkerCount),
					new SqlParameter("@WorkingPosition",workingPosition),
					new SqlParameter("@WorkingType",workingType),
					new SqlParameter("@NumberOfPeopleOnResponsibility",numberOfPeopleOnResponsibility),
					new SqlParameter("@WorkingExperience",workingExperience),
					new SqlParameter("@JobLeavingReason",jobLeavingReason),
					new SqlParameter("@JobFindingType",jobFindingType),
					new SqlParameter("@JobDescription",jobDescription),
					new SqlParameter("@ResponsibleName",responsibleName),
					new SqlParameter("@ResponsibleTitle",responsibleTitle),
					new SqlParameter("@ResponsiblePhone",responsiblePhone)
                };

                    if (tran == null)
                        ds = ExecuteDataset("BGA_GetCVWorkExperiencesByParams", sqlParams);
                    else
                        ds = ExecuteDataset(tran, "BGA_GetCVWorkExperiencesByParams", sqlParams);

                    return ds;
                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "CVWorkExperiencesProvider", "GetByParams", ArrangeParamValues(sqlParams));
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

                    ds = ExecuteDataset("BGA_GetCVWorkExperiencesByParams", sqlParams);

                    return ds;
                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "CVWorkExperiencesProvider", "GetByParams", ArrangeParamValues(sqlParams));
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
                        ds = ExecuteDataset("BGA_GetCVWorkExperiencesByFK", sqlParams);
                    else
                        ds = ExecuteDataset(tran, "BGA_GetCVWorkExperiencesByFK", sqlParams);

                    return ds;
                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "CVWorkExperiencesProvider", "GetByFK", ArrangeParamValues(sqlParams));
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
            public static int Update(int id, int cVId, string firmName, DateTime workStartDate, DateTime? workEndDate, string workCity, string firmSector, int? firmWorkerCount, string workingPosition, int? workingType, int? numberOfPeopleOnResponsibility, int? workingExperience, string jobLeavingReason, int? jobFindingType, string jobDescription, string responsibleName, string responsibleTitle, string responsiblePhone)
            {
                SqlParameter[] sqlParams = null;

                try
                {
                    sqlParams = new SqlParameter[] { 
					new SqlParameter("@ID",id),
					new SqlParameter("@CVId",cVId),
					new SqlParameter("@FirmName",firmName),
					new SqlParameter("@WorkStartDate",workStartDate),
					new SqlParameter("@WorkEndDate",workEndDate),
					new SqlParameter("@WorkCity",workCity),
					new SqlParameter("@FirmSector",firmSector),
					new SqlParameter("@FirmWorkerCount",firmWorkerCount),
					new SqlParameter("@WorkingPosition",workingPosition),
					new SqlParameter("@WorkingType",workingType),
					new SqlParameter("@NumberOfPeopleOnResponsibility",numberOfPeopleOnResponsibility),
					new SqlParameter("@WorkingExperience",workingExperience),
					new SqlParameter("@JobLeavingReason",jobLeavingReason),
					new SqlParameter("@JobFindingType",jobFindingType),
					new SqlParameter("@JobDescription",jobDescription),
					new SqlParameter("@ResponsibleName",responsibleName),
					new SqlParameter("@ResponsibleTitle",responsibleTitle),
					new SqlParameter("@ResponsiblePhone",responsiblePhone)
                };

                    return ExecuteNonQuery("BGA_UpdateCVWorkExperiences", sqlParams);

                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "CVWorkExperiencesProvider", "Update", ArrangeParamValues(sqlParams));
                }
            }

            public static int Update(SqlTransaction tran, int id, int cVId, string firmName, DateTime workStartDate, DateTime? workEndDate, string workCity, string firmSector, int? firmWorkerCount, string workingPosition, int? workingType, int? numberOfPeopleOnResponsibility, int? workingExperience, string jobLeavingReason, int? jobFindingType, string jobDescription, string responsibleName, string responsibleTitle, string responsiblePhone)
            {
                SqlParameter[] sqlParams = null;

                try
                {
                    sqlParams = new SqlParameter[] { 
					new SqlParameter("@ID",id),
					new SqlParameter("@CVId",cVId),
					new SqlParameter("@FirmName",firmName),
					new SqlParameter("@WorkStartDate",workStartDate),
					new SqlParameter("@WorkEndDate",workEndDate),
					new SqlParameter("@WorkCity",workCity),
					new SqlParameter("@FirmSector",firmSector),
					new SqlParameter("@FirmWorkerCount",firmWorkerCount),
					new SqlParameter("@WorkingPosition",workingPosition),
					new SqlParameter("@WorkingType",workingType),
					new SqlParameter("@NumberOfPeopleOnResponsibility",numberOfPeopleOnResponsibility),
					new SqlParameter("@WorkingExperience",workingExperience),
					new SqlParameter("@JobLeavingReason",jobLeavingReason),
					new SqlParameter("@JobFindingType",jobFindingType),
					new SqlParameter("@JobDescription",jobDescription),
					new SqlParameter("@ResponsibleName",responsibleName),
					new SqlParameter("@ResponsibleTitle",responsibleTitle),
					new SqlParameter("@ResponsiblePhone",responsiblePhone)
                };

                    return ExecuteNonQuery(tran, "BGA_UpdateCVWorkExperiences", sqlParams);

                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "CVWorkExperiencesProvider", "Update", ArrangeParamValues(sqlParams));
                }
            }

            public static int UpdateByParams(int id, int? cVId, string firmName, DateTime? workStartDate, DateTime? workEndDate, string workCity, string firmSector, int? firmWorkerCount, string workingPosition, int? workingType, int? numberOfPeopleOnResponsibility, int? workingExperience, string jobLeavingReason, int? jobFindingType, string jobDescription, string responsibleName, string responsibleTitle, string responsiblePhone)
            {
                SqlParameter[] sqlParams = null;

                try
                {
                    sqlParams = new SqlParameter[] { 
					new SqlParameter("@ID",id),
					new SqlParameter("@CVId",cVId),
					new SqlParameter("@FirmName",firmName),
					new SqlParameter("@WorkStartDate",workStartDate),
					new SqlParameter("@WorkEndDate",workEndDate),
					new SqlParameter("@WorkCity",workCity),
					new SqlParameter("@FirmSector",firmSector),
					new SqlParameter("@FirmWorkerCount",firmWorkerCount),
					new SqlParameter("@WorkingPosition",workingPosition),
					new SqlParameter("@WorkingType",workingType),
					new SqlParameter("@NumberOfPeopleOnResponsibility",numberOfPeopleOnResponsibility),
					new SqlParameter("@WorkingExperience",workingExperience),
					new SqlParameter("@JobLeavingReason",jobLeavingReason),
					new SqlParameter("@JobFindingType",jobFindingType),
					new SqlParameter("@JobDescription",jobDescription),
					new SqlParameter("@ResponsibleName",responsibleName),
					new SqlParameter("@ResponsibleTitle",responsibleTitle),
					new SqlParameter("@ResponsiblePhone",responsiblePhone)
                };

                    return ExecuteNonQuery("BGA_UpdateCVWorkExperiencesByParams", sqlParams);

                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "CVWorkExperiencesProvider", "UpdateByParams", ArrangeParamValues(sqlParams));
                }
            }

            public static int UpdateByParams(params SqlParameter[] sqlParams)
            {
                try
                {

                    return ExecuteNonQuery("BGA_UpdateCVWorkExperiencesByParams", sqlParams);

                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "CVWorkExperiencesProvider", "UpdateByParams", ArrangeParamValues(sqlParams));
                }
            }

            public static int UpdateByParams(SqlTransaction tran, int id, int? cVId, string firmName, DateTime? workStartDate, DateTime? workEndDate, string workCity, string firmSector, int? firmWorkerCount, string workingPosition, int? workingType, int? numberOfPeopleOnResponsibility, int? workingExperience, string jobLeavingReason, int? jobFindingType, string jobDescription, string responsibleName, string responsibleTitle, string responsiblePhone)
            {
                SqlParameter[] sqlParams = null;

                try
                {
                    sqlParams = new SqlParameter[] { 
					new SqlParameter("@ID",id),
					new SqlParameter("@CVId",cVId),
					new SqlParameter("@FirmName",firmName),
					new SqlParameter("@WorkStartDate",workStartDate),
					new SqlParameter("@WorkEndDate",workEndDate),
					new SqlParameter("@WorkCity",workCity),
					new SqlParameter("@FirmSector",firmSector),
					new SqlParameter("@FirmWorkerCount",firmWorkerCount),
					new SqlParameter("@WorkingPosition",workingPosition),
					new SqlParameter("@WorkingType",workingType),
					new SqlParameter("@NumberOfPeopleOnResponsibility",numberOfPeopleOnResponsibility),
					new SqlParameter("@WorkingExperience",workingExperience),
					new SqlParameter("@JobLeavingReason",jobLeavingReason),
					new SqlParameter("@JobFindingType",jobFindingType),
					new SqlParameter("@JobDescription",jobDescription),
					new SqlParameter("@ResponsibleName",responsibleName),
					new SqlParameter("@ResponsibleTitle",responsibleTitle),
					new SqlParameter("@ResponsiblePhone",responsiblePhone)
                };

                    return ExecuteNonQuery(tran, "BGA_UpdateCVWorkExperiencesByParams", sqlParams);

                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "CVWorkExperiencesProvider", "UpdateByParams", ArrangeParamValues(sqlParams));
                }
            }

            public static int UpdateByParams(SqlTransaction tran, params SqlParameter[] sqlParams)
            {
                try
                {

                    return ExecuteNonQuery(tran, "BGA_UpdateCVWorkExperiencesByParams", sqlParams);

                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "CVWorkExperiencesProvider", "UpdateByParams", ArrangeParamValues(sqlParams));
                }
            }
            #endregion

            #region Add Functions
            public static int Add(int cVId, string firmName, DateTime workStartDate, DateTime? workEndDate, string workCity, string firmSector, int? firmWorkerCount, string workingPosition, int? workingType, int? numberOfPeopleOnResponsibility, int? workingExperience, string jobLeavingReason, int? jobFindingType, string jobDescription, string responsibleName, string responsibleTitle, string responsiblePhone)
            {
                SqlParameter[] sqlParams = null;

                try
                {
                    sqlParams = new SqlParameter[] { 
					new SqlParameter("@CVId",cVId),
					new SqlParameter("@FirmName",firmName),
					new SqlParameter("@WorkStartDate",workStartDate),
					new SqlParameter("@WorkEndDate",workEndDate),
					new SqlParameter("@WorkCity",workCity),
					new SqlParameter("@FirmSector",firmSector),
					new SqlParameter("@FirmWorkerCount",firmWorkerCount),
					new SqlParameter("@WorkingPosition",workingPosition),
					new SqlParameter("@WorkingType",workingType),
					new SqlParameter("@NumberOfPeopleOnResponsibility",numberOfPeopleOnResponsibility),
					new SqlParameter("@WorkingExperience",workingExperience),
					new SqlParameter("@JobLeavingReason",jobLeavingReason),
					new SqlParameter("@JobFindingType",jobFindingType),
					new SqlParameter("@JobDescription",jobDescription),
					new SqlParameter("@ResponsibleName",responsibleName),
					new SqlParameter("@ResponsibleTitle",responsibleTitle),
					new SqlParameter("@ResponsiblePhone",responsiblePhone)
                };

                    return ExecuteScalar("BGA_AddCVWorkExperiences", sqlParams);

                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "CVWorkExperiencesProvider", "Add", ArrangeParamValues(sqlParams));
                }
            }

            public static int Add(SqlTransaction tran, int cVId, string firmName, DateTime workStartDate, DateTime? workEndDate, string workCity, string firmSector, int? firmWorkerCount, string workingPosition, int? workingType, int? numberOfPeopleOnResponsibility, int? workingExperience, string jobLeavingReason, int? jobFindingType, string jobDescription, string responsibleName, string responsibleTitle, string responsiblePhone)
            {
                SqlParameter[] sqlParams = null;

                try
                {
                    sqlParams = new SqlParameter[] { 
					new SqlParameter("@CVId",cVId),
					new SqlParameter("@FirmName",firmName),
					new SqlParameter("@WorkStartDate",workStartDate),
					new SqlParameter("@WorkEndDate",workEndDate),
					new SqlParameter("@WorkCity",workCity),
					new SqlParameter("@FirmSector",firmSector),
					new SqlParameter("@FirmWorkerCount",firmWorkerCount),
					new SqlParameter("@WorkingPosition",workingPosition),
					new SqlParameter("@WorkingType",workingType),
					new SqlParameter("@NumberOfPeopleOnResponsibility",numberOfPeopleOnResponsibility),
					new SqlParameter("@WorkingExperience",workingExperience),
					new SqlParameter("@JobLeavingReason",jobLeavingReason),
					new SqlParameter("@JobFindingType",jobFindingType),
					new SqlParameter("@JobDescription",jobDescription),
					new SqlParameter("@ResponsibleName",responsibleName),
					new SqlParameter("@ResponsibleTitle",responsibleTitle),
					new SqlParameter("@ResponsiblePhone",responsiblePhone)
                };

                    return ExecuteScalar(tran, "BGA_AddCVWorkExperiences", sqlParams);

                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "CVWorkExperiencesProvider", "Add", ArrangeParamValues(sqlParams));
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

                    return ExecuteNonQuery("BGA_DeleteCVWorkExperiences", sqlParams);

                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "CVWorkExperiencesProvider", "Delete", ArrangeParamValues(sqlParams));
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

                    return ExecuteNonQuery(tran, "BGA_DeleteCVWorkExperiences", sqlParams);

                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "CVWorkExperiencesProvider", "Delete", ArrangeParamValues(sqlParams));
                }
            }

            public static int DeleteByParams(SqlTransaction tran, int? id, int? cVId, string firmName, DateTime? workStartDate, DateTime? beforeWorkStartDate, DateTime? afterOrEqualWorkStartDate, DateTime? workEndDate, DateTime? beforeWorkEndDate, DateTime? afterOrEqualWorkEndDate, string workCity, string firmSector, int? firmWorkerCount, string workingPosition, int? workingType, int? numberOfPeopleOnResponsibility, int? workingExperience, string jobLeavingReason, int? jobFindingType, string jobDescription, string responsibleName, string responsibleTitle, string responsiblePhone)
            {
                SqlParameter[] sqlParams = null;

                try
                {
                    sqlParams = new SqlParameter[] { 
					new SqlParameter("@ID",id),
					new SqlParameter("@CVId",cVId),
					new SqlParameter("@FirmName",firmName),
					new SqlParameter("@WorkStartDate",workStartDate),
					new SqlParameter("@BeforeWorkStartDate",beforeWorkStartDate),
					new SqlParameter("@AfterOrEqualWorkStartDate",afterOrEqualWorkStartDate),
					new SqlParameter("@WorkEndDate",workEndDate),
					new SqlParameter("@BeforeWorkEndDate",beforeWorkEndDate),
					new SqlParameter("@AfterOrEqualWorkEndDate",afterOrEqualWorkEndDate),
					new SqlParameter("@WorkCity",workCity),
					new SqlParameter("@FirmSector",firmSector),
					new SqlParameter("@FirmWorkerCount",firmWorkerCount),
					new SqlParameter("@WorkingPosition",workingPosition),
					new SqlParameter("@WorkingType",workingType),
					new SqlParameter("@NumberOfPeopleOnResponsibility",numberOfPeopleOnResponsibility),
					new SqlParameter("@WorkingExperience",workingExperience),
					new SqlParameter("@JobLeavingReason",jobLeavingReason),
					new SqlParameter("@JobFindingType",jobFindingType),
					new SqlParameter("@JobDescription",jobDescription),
					new SqlParameter("@ResponsibleName",responsibleName),
					new SqlParameter("@ResponsibleTitle",responsibleTitle),
					new SqlParameter("@ResponsiblePhone",responsiblePhone)
                };

                    if (tran == null)
                        return ExecuteNonQuery("BGA_DeleteCVWorkExperiencesByParams", sqlParams);
                    else
                        return ExecuteNonQuery(tran, "BGA_DeleteCVWorkExperiencesByParams", sqlParams);


                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "CVWorkExperiencesProvider", "DeleteByParams", ArrangeParamValues(sqlParams));
                }
            }

            public static int DeleteByParams(int? id, int? cVId, string firmName, DateTime? workStartDate, DateTime? beforeWorkStartDate, DateTime? afterOrEqualWorkStartDate, DateTime? workEndDate, DateTime? beforeWorkEndDate, DateTime? afterOrEqualWorkEndDate, string workCity, string firmSector, int? firmWorkerCount, string workingPosition, int? workingType, int? numberOfPeopleOnResponsibility, int? workingExperience, string jobLeavingReason, int? jobFindingType, string jobDescription, string responsibleName, string responsibleTitle, string responsiblePhone)
            {
                return DeleteByParams(null, id, cVId, firmName, workStartDate, beforeWorkStartDate, afterOrEqualWorkStartDate, workEndDate, beforeWorkEndDate, afterOrEqualWorkEndDate, workCity, firmSector, firmWorkerCount, workingPosition, workingType, numberOfPeopleOnResponsibility, workingExperience, jobLeavingReason, jobFindingType, jobDescription, responsibleName, responsibleTitle, responsiblePhone)
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
                        return ExecuteNonQuery("BGA_DeleteCVWorkExperiencesByFK", sqlParams);
                    else
                        return ExecuteNonQuery(tran, "BGA_DeleteCVWorkExperiencesByFK", sqlParams);

                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "CVWorkExperiencesProvider", "DeleteByFK", ArrangeParamValues(sqlParams));
                }
            }


            #endregion

        }
    }
}
