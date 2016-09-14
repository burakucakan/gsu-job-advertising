using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using GSUKariyer.DAL;
using GSUKariyer.COMMON.Exceptions;
using GSUKariyer.COMMON;

namespace GSUKariyer.BUS
{

    public partial class CVWorkExperiences
    {

        #region ColumnNames
        public struct ColumnNames
        {
            public const string ID = "ID";
            public const string CVId = "CVId";
            public const string FirmName = "FirmName";
            public const string WorkStartDate = "WorkStartDate";
            public const string WorkEndDate = "WorkEndDate";
            public const string WorkCity = "WorkCity";
            public const string FirmSector = "FirmSector";
            public const string FirmWorkerCount = "FirmWorkerCount";
            public const string WorkingPosition = "WorkingPosition";
            public const string WorkingType = "WorkingType";
            public const string NumberOfPeopleOnResponsibility = "NumberOfPeopleOnResponsibility";
            public const string WorkingExperience = "WorkingExperience";
            public const string JobLeavingReason = "JobLeavingReason";
            public const string JobFindingType = "JobFindingType";
            public const string JobDescription = "JobDescription";
            public const string ResponsibleName = "ResponsibleName";
            public const string ResponsibleTitle = "ResponsibleTitle";
            public const string ResponsiblePhone = "ResponsiblePhone";
        }
        #endregion

        #region Create DataTable
        public static DataTable CreateTable()
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("ID", System.Type.GetType("System.Int32"));
            dt.Columns.Add("CVId", System.Type.GetType("System.Int32"));
            dt.Columns.Add("FirmName", System.Type.GetType("System.String"));
            dt.Columns.Add("WorkStartDate", System.Type.GetType("System.DateTime"));
            dt.Columns.Add("WorkEndDate", System.Type.GetType("System.DateTime"));
            dt.Columns.Add("WorkCity", System.Type.GetType("System.String"));
            dt.Columns.Add("FirmSector", System.Type.GetType("System.String"));
            dt.Columns.Add("FirmWorkerCount", System.Type.GetType("System.Int32"));
            dt.Columns.Add("WorkingPosition", System.Type.GetType("System.String"));
            dt.Columns.Add("WorkingType", System.Type.GetType("System.Int32"));
            dt.Columns.Add("NumberOfPeopleOnResponsibility", System.Type.GetType("System.Int32"));
            dt.Columns.Add("WorkingExperience", System.Type.GetType("System.Int32"));
            dt.Columns.Add("JobLeavingReason", System.Type.GetType("System.String"));
            dt.Columns.Add("JobFindingType", System.Type.GetType("System.Int32"));
            dt.Columns.Add("JobDescription", System.Type.GetType("System.String"));
            dt.Columns.Add("ResponsibleName", System.Type.GetType("System.String"));
            dt.Columns.Add("ResponsibleTitle", System.Type.GetType("System.String"));
            dt.Columns.Add("ResponsiblePhone", System.Type.GetType("System.String"));

            return dt;
        }

        #endregion

        #region Bulk Operations
        public class BulkOperation
        {

            public static void Add(SqlTransaction tran, DataTable dt)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    Add(tran, dr);
                }
            }

            public static void Add(DataTable dt)
            {
                SqlConnection conn = null;
                SqlTransaction tran = null;

                try
                {
                    conn = new SqlConnection(CVWorkExperiencesProvider.GetConnectionString());
                    conn.Open();

                    tran = conn.BeginTransaction(IsolationLevel.Serializable);

                    foreach (DataRow dr in dt.Rows)
                    {
                        Add(tran, dr);
                    }

                    //transaction Commit
                    tran.Commit();

                }
                catch (Exception ex)
                {
                    //transaction Rollback
                    tran.Rollback();
                    throw new MyException(ex.Message, "CVWorkExperiences", "Add");
                }
                finally
                {
                    //Connection Close
                    conn.Close();
                    conn.Dispose();
                }

            }

            public static void Update(SqlTransaction tran, DataTable dt)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    Update(tran, dr);
                }
            }

            public static void Update(DataTable dt)
            {
                SqlConnection conn = null;
                SqlTransaction tran = null;

                try
                {
                    conn = new SqlConnection(CVWorkExperiencesProvider.GetConnectionString());
                    conn.Open();

                    tran = conn.BeginTransaction(IsolationLevel.Serializable);

                    foreach (DataRow dr in dt.Rows)
                    {
                        Update(tran, dr);
                    }

                    //transaction Commit
                    tran.Commit();

                }
                catch (Exception ex)
                {
                    //transaction Rollback
                    tran.Rollback();
                    throw new MyException(ex.Message, "CVWorkExperiences", "Update");
                }
                finally
                {
                    //Connection Close
                    conn.Close();
                    conn.Dispose();
                }
            }

            public static int Add(DataRow dr)
            {
                return CVWorkExperiencesProvider.Generated.Add((int)dr[ColumnNames.CVId],
                                                    dr[ColumnNames.FirmName].ToString(),
                                                    (DateTime)dr[ColumnNames.WorkStartDate],
                                                    DBNullHelper.GetNullableValue<DateTime>(dr[ColumnNames.WorkEndDate]),
                                                    dr[ColumnNames.WorkCity].ToString(),
                                                    dr[ColumnNames.FirmSector].ToString(),
                                                    DBNullHelper.GetNullableValue<int>(dr[ColumnNames.FirmWorkerCount]),
                                                    dr[ColumnNames.WorkingPosition].ToString(),
                                                    DBNullHelper.GetNullableValue<int>(dr[ColumnNames.WorkingType]),
                                                    DBNullHelper.GetNullableValue<int>(dr[ColumnNames.NumberOfPeopleOnResponsibility]),
                                                    DBNullHelper.GetNullableValue<int>(dr[ColumnNames.WorkingExperience]),
                                                    dr[ColumnNames.JobLeavingReason].ToString(),
                                                    DBNullHelper.GetNullableValue<int>(dr[ColumnNames.JobFindingType]),
                                                    dr[ColumnNames.JobDescription].ToString(),
                                                    dr[ColumnNames.ResponsibleName].ToString(),
                                                    dr[ColumnNames.ResponsibleTitle].ToString(),
                                                    dr[ColumnNames.ResponsiblePhone].ToString());

            }

            public static int Add(SqlTransaction tran, DataRow dr)
            {
                return CVWorkExperiencesProvider.Generated.Add(tran,
                                                    (int)dr[ColumnNames.CVId],
                                                    dr[ColumnNames.FirmName].ToString(),
                                                    (DateTime)dr[ColumnNames.WorkStartDate],
                                                    DBNullHelper.GetNullableValue<DateTime>(dr[ColumnNames.WorkEndDate]),
                                                    dr[ColumnNames.WorkCity].ToString(),
                                                    dr[ColumnNames.FirmSector].ToString(),
                                                    DBNullHelper.GetNullableValue<int>(dr[ColumnNames.FirmWorkerCount]),
                                                    dr[ColumnNames.WorkingPosition].ToString(),
                                                    DBNullHelper.GetNullableValue<int>(dr[ColumnNames.WorkingType]),
                                                    DBNullHelper.GetNullableValue<int>(dr[ColumnNames.NumberOfPeopleOnResponsibility]),
                                                    DBNullHelper.GetNullableValue<int>(dr[ColumnNames.WorkingExperience]),
                                                    dr[ColumnNames.JobLeavingReason].ToString(),
                                                    DBNullHelper.GetNullableValue<int>(dr[ColumnNames.JobFindingType]),
                                                    dr[ColumnNames.JobDescription].ToString(),
                                                    dr[ColumnNames.ResponsibleName].ToString(),
                                                    dr[ColumnNames.ResponsibleTitle].ToString(),
                                                    dr[ColumnNames.ResponsiblePhone].ToString());

            }

            public static int Update(DataRow dr)
            {
                return CVWorkExperiencesProvider.Generated.Update((int)dr[ColumnNames.ID],
                                                    (int)dr[ColumnNames.CVId],
                                                    dr[ColumnNames.FirmName].ToString(),
                                                    (DateTime)dr[ColumnNames.WorkStartDate],
                                                    DBNullHelper.GetNullableValue<DateTime>(dr[ColumnNames.WorkEndDate]),
                                                    dr[ColumnNames.WorkCity].ToString(),
                                                    dr[ColumnNames.FirmSector].ToString(),
                                                    DBNullHelper.GetNullableValue<int>(dr[ColumnNames.FirmWorkerCount]),
                                                    dr[ColumnNames.WorkingPosition].ToString(),
                                                    DBNullHelper.GetNullableValue<int>(dr[ColumnNames.WorkingType]),
                                                    DBNullHelper.GetNullableValue<int>(dr[ColumnNames.NumberOfPeopleOnResponsibility]),
                                                    DBNullHelper.GetNullableValue<int>(dr[ColumnNames.WorkingExperience]),
                                                    dr[ColumnNames.JobLeavingReason].ToString(),
                                                    DBNullHelper.GetNullableValue<int>(dr[ColumnNames.JobFindingType]),
                                                    dr[ColumnNames.JobDescription].ToString(),
                                                    dr[ColumnNames.ResponsibleName].ToString(),
                                                    dr[ColumnNames.ResponsibleTitle].ToString(),
                                                    dr[ColumnNames.ResponsiblePhone].ToString());
            }

            public static int Update(SqlTransaction tran, DataRow dr)
            {
                return CVWorkExperiencesProvider.Generated.Update(tran,
                                                    (int)dr[ColumnNames.ID],
                                                    (int)dr[ColumnNames.CVId],
                                                    dr[ColumnNames.FirmName].ToString(),
                                                    (DateTime)dr[ColumnNames.WorkStartDate],
                                                    DBNullHelper.GetNullableValue<DateTime>(dr[ColumnNames.WorkEndDate]),
                                                    dr[ColumnNames.WorkCity].ToString(),
                                                    dr[ColumnNames.FirmSector].ToString(),
                                                    DBNullHelper.GetNullableValue<int>(dr[ColumnNames.FirmWorkerCount]),
                                                    dr[ColumnNames.WorkingPosition].ToString(),
                                                    DBNullHelper.GetNullableValue<int>(dr[ColumnNames.WorkingType]),
                                                    DBNullHelper.GetNullableValue<int>(dr[ColumnNames.NumberOfPeopleOnResponsibility]),
                                                    DBNullHelper.GetNullableValue<int>(dr[ColumnNames.WorkingExperience]),
                                                    dr[ColumnNames.JobLeavingReason].ToString(),
                                                    DBNullHelper.GetNullableValue<int>(dr[ColumnNames.JobFindingType]),
                                                    dr[ColumnNames.JobDescription].ToString(),
                                                    dr[ColumnNames.ResponsibleName].ToString(),
                                                    dr[ColumnNames.ResponsibleTitle].ToString(),
                                                    dr[ColumnNames.ResponsiblePhone].ToString());
            }
        }
        #endregion

        public class Generated
        {

            #region Get Functions
            public static DataTable GetByParams(int? id, int? cVId, string firmName, DateTime? workStartDate, DateTime? beforeWorkStartDate, DateTime? afterOrEqualWorkStartDate, DateTime? workEndDate, DateTime? beforeWorkEndDate, DateTime? afterOrEqualWorkEndDate, string workCity, string firmSector, int? firmWorkerCount, string workingPosition, int? workingType, int? numberOfPeopleOnResponsibility, int? workingExperience, string jobLeavingReason, int? jobFindingType, string jobDescription, string responsibleName, string responsibleTitle, string responsiblePhone)
            {
                return CVWorkExperiencesProvider.Generated.GetByParams(id, cVId, firmName, workStartDate, beforeWorkStartDate, afterOrEqualWorkStartDate, workEndDate, beforeWorkEndDate, afterOrEqualWorkEndDate, workCity, firmSector, firmWorkerCount, workingPosition, workingType, numberOfPeopleOnResponsibility, workingExperience, jobLeavingReason, jobFindingType, jobDescription, responsibleName, responsibleTitle, responsiblePhone)
    .Tables[0];
            }

            public static DataTable GetByParams(SqlTransaction tran, int? id, int? cVId, string firmName, DateTime? workStartDate, DateTime? beforeWorkStartDate, DateTime? afterOrEqualWorkStartDate, DateTime? workEndDate, DateTime? beforeWorkEndDate, DateTime? afterOrEqualWorkEndDate, string workCity, string firmSector, int? firmWorkerCount, string workingPosition, int? workingType, int? numberOfPeopleOnResponsibility, int? workingExperience, string jobLeavingReason, int? jobFindingType, string jobDescription, string responsibleName, string responsibleTitle, string responsiblePhone)
            {
                return CVWorkExperiencesProvider.Generated.GetByParams(tran, id, cVId, firmName, workStartDate, beforeWorkStartDate, afterOrEqualWorkStartDate, workEndDate, beforeWorkEndDate, afterOrEqualWorkEndDate, workCity, firmSector, firmWorkerCount, workingPosition, workingType, numberOfPeopleOnResponsibility, workingExperience, jobLeavingReason, jobFindingType, jobDescription, responsibleName, responsibleTitle, responsiblePhone)
    .Tables[0];
            }

            public static DataTable GetByParams(params SqlParameter[] sqlParams)
            {
                return CVWorkExperiencesProvider.Generated.GetByParams(sqlParams).Tables[0];
            }

            public static DataTable GetByParams(SqlTransaction tran, params SqlParameter[] sqlParams)
            {
                return CVWorkExperiencesProvider.Generated.GetByParams(tran, sqlParams).Tables[0];
            }

            public static DataTable GetByFKBasic(int? cVId)
            {
                return CVWorkExperiencesProvider.Generated.GetByFKBasic(cVId)
    .Tables[0];
            }

            public static DataTable GetByFKBasic(SqlTransaction tran, int? cVId)
            {
                return CVWorkExperiencesProvider.Generated.GetByFKBasic(tran, cVId)
    .Tables[0];
            }


            public static DataTable GetAll(SqlTransaction tran)
            {
                return CVWorkExperiencesProvider.Generated.GetAll(tran).Tables[0];
            }

            public static DataTable GetAll()
            {
                return CVWorkExperiencesProvider.Generated.GetAll().Tables[0];
            }

            public static DataTable Get(SqlTransaction tran, int id)
            {
                return CVWorkExperiencesProvider.Generated.Get(tran, id)
    .Tables[0];
            }

            public static DataTable Get(int id)
            {
                return CVWorkExperiencesProvider.Generated.Get(id)
    .Tables[0];
            }

            public static DataTable GetByFK(SqlTransaction tran, int cVId)
            {
                return CVWorkExperiencesProvider.Generated.GetByFK(tran, cVId)
    .Tables[0];
            }

            public static DataTable GetByFK(int cVId)
            {
                return CVWorkExperiencesProvider.Generated.GetByFK(cVId)
    .Tables[0];
            }


            #endregion

            #region Update Functions
            public static int Update(int id, int cVId, string firmName, DateTime workStartDate, DateTime? workEndDate, string workCity, string firmSector, int? firmWorkerCount, string workingPosition, int? workingType, int? numberOfPeopleOnResponsibility, int? workingExperience, string jobLeavingReason, int? jobFindingType, string jobDescription, string responsibleName, string responsibleTitle, string responsiblePhone)
            {
                return CVWorkExperiencesProvider.Generated.Update(id, cVId, firmName, workStartDate, workEndDate, workCity, firmSector, firmWorkerCount, workingPosition, workingType, numberOfPeopleOnResponsibility, workingExperience, jobLeavingReason, jobFindingType, jobDescription, responsibleName, responsibleTitle, responsiblePhone)
    ;
            }

            public static int Update(SqlTransaction tran, int id, int cVId, string firmName, DateTime workStartDate, DateTime? workEndDate, string workCity, string firmSector, int? firmWorkerCount, string workingPosition, int? workingType, int? numberOfPeopleOnResponsibility, int? workingExperience, string jobLeavingReason, int? jobFindingType, string jobDescription, string responsibleName, string responsibleTitle, string responsiblePhone)
            {
                return CVWorkExperiencesProvider.Generated.Update(id, cVId, firmName, workStartDate, workEndDate, workCity, firmSector, firmWorkerCount, workingPosition, workingType, numberOfPeopleOnResponsibility, workingExperience, jobLeavingReason, jobFindingType, jobDescription, responsibleName, responsibleTitle, responsiblePhone)
    ;
            }

            public static int UpdateByParams(int id, int? cVId, string firmName, DateTime? workStartDate, DateTime? workEndDate, string workCity, string firmSector, int? firmWorkerCount, string workingPosition, int? workingType, int? numberOfPeopleOnResponsibility, int? workingExperience, string jobLeavingReason, int? jobFindingType, string jobDescription, string responsibleName, string responsibleTitle, string responsiblePhone)
            {
                return CVWorkExperiencesProvider.Generated.UpdateByParams(id, cVId, firmName, workStartDate, workEndDate, workCity, firmSector, firmWorkerCount, workingPosition, workingType, numberOfPeopleOnResponsibility, workingExperience, jobLeavingReason, jobFindingType, jobDescription, responsibleName, responsibleTitle, responsiblePhone)
    ;
            }

            public static int UpdateByParams(params SqlParameter[] sqlParams)
            {
                return CVWorkExperiencesProvider.Generated.UpdateByParams(sqlParams);
            }

            public static int UpdateByParams(SqlTransaction tran, int id, int? cVId, string firmName, DateTime? workStartDate, DateTime? workEndDate, string workCity, string firmSector, int? firmWorkerCount, string workingPosition, int? workingType, int? numberOfPeopleOnResponsibility, int? workingExperience, string jobLeavingReason, int? jobFindingType, string jobDescription, string responsibleName, string responsibleTitle, string responsiblePhone)
            {
                return CVWorkExperiencesProvider.Generated.UpdateByParams(tran, id, cVId, firmName, workStartDate, workEndDate, workCity, firmSector, firmWorkerCount, workingPosition, workingType, numberOfPeopleOnResponsibility, workingExperience, jobLeavingReason, jobFindingType, jobDescription, responsibleName, responsibleTitle, responsiblePhone)
    ;
            }

            public static int UpdateByParams(SqlTransaction tran, params SqlParameter[] sqlParams)
            {
                return CVWorkExperiencesProvider.Generated.UpdateByParams(tran, sqlParams);
            }
            #endregion

            #region Add Functions
            public static int Add(int cVId, string firmName, DateTime workStartDate, DateTime? workEndDate, string workCity, string firmSector, int? firmWorkerCount, string workingPosition, int? workingType, int? numberOfPeopleOnResponsibility, int? workingExperience, string jobLeavingReason, int? jobFindingType, string jobDescription, string responsibleName, string responsibleTitle, string responsiblePhone)
            {
                return CVWorkExperiencesProvider.Generated.Add(cVId, firmName, workStartDate, workEndDate, workCity, firmSector, firmWorkerCount, workingPosition, workingType, numberOfPeopleOnResponsibility, workingExperience, jobLeavingReason, jobFindingType, jobDescription, responsibleName, responsibleTitle, responsiblePhone)
    ;
            }

            public static int Add(SqlTransaction tran, int cVId, string firmName, DateTime workStartDate, DateTime? workEndDate, string workCity, string firmSector, int? firmWorkerCount, string workingPosition, int? workingType, int? numberOfPeopleOnResponsibility, int? workingExperience, string jobLeavingReason, int? jobFindingType, string jobDescription, string responsibleName, string responsibleTitle, string responsiblePhone)
            {
                return CVWorkExperiencesProvider.Generated.Add(tran, cVId, firmName, workStartDate, workEndDate, workCity, firmSector, firmWorkerCount, workingPosition, workingType, numberOfPeopleOnResponsibility, workingExperience, jobLeavingReason, jobFindingType, jobDescription, responsibleName, responsibleTitle, responsiblePhone)
    ;
            }
            #endregion

            #region Delete Functions
            public static int DeleteByParams(int? id, int? cVId, string firmName, DateTime? workStartDate, DateTime? beforeWorkStartDate, DateTime? afterOrEqualWorkStartDate, DateTime? workEndDate, DateTime? beforeWorkEndDate, DateTime? afterOrEqualWorkEndDate, string workCity, string firmSector, int? firmWorkerCount, string workingPosition, int? workingType, int? numberOfPeopleOnResponsibility, int? workingExperience, string jobLeavingReason, int? jobFindingType, string jobDescription, string responsibleName, string responsibleTitle, string responsiblePhone)
            {
                return CVWorkExperiencesProvider.Generated.DeleteByParams(null, id, cVId, firmName, workStartDate, beforeWorkStartDate, afterOrEqualWorkStartDate, workEndDate, beforeWorkEndDate, afterOrEqualWorkEndDate, workCity, firmSector, firmWorkerCount, workingPosition, workingType, numberOfPeopleOnResponsibility, workingExperience, jobLeavingReason, jobFindingType, jobDescription, responsibleName, responsibleTitle, responsiblePhone)
    ;
            }

            public static int DeleteByParams(SqlTransaction tran, int? id, int? cVId, string firmName, DateTime? workStartDate, DateTime? beforeWorkStartDate, DateTime? afterOrEqualWorkStartDate, DateTime? workEndDate, DateTime? beforeWorkEndDate, DateTime? afterOrEqualWorkEndDate, string workCity, string firmSector, int? firmWorkerCount, string workingPosition, int? workingType, int? numberOfPeopleOnResponsibility, int? workingExperience, string jobLeavingReason, int? jobFindingType, string jobDescription, string responsibleName, string responsibleTitle, string responsiblePhone)
            {
                return CVWorkExperiencesProvider.Generated.DeleteByParams(tran, id, cVId, firmName, workStartDate, beforeWorkStartDate, afterOrEqualWorkStartDate, workEndDate, beforeWorkEndDate, afterOrEqualWorkEndDate, workCity, firmSector, firmWorkerCount, workingPosition, workingType, numberOfPeopleOnResponsibility, workingExperience, jobLeavingReason, jobFindingType, jobDescription, responsibleName, responsibleTitle, responsiblePhone)
    ;
            }

            public static int Delete(int id)
            {
                return CVWorkExperiencesProvider.Generated.Delete(id)
    ;
            }

            public static int Delete(SqlTransaction tran, int id)
            {
                return CVWorkExperiencesProvider.Generated.Delete(tran, id)
    ;
            }

            public static int DeleteByFK(int? cVId)
            {
                return CVWorkExperiencesProvider.Generated.DeleteByFK(cVId)
    ;
            }

            public static int DeleteByFK(SqlTransaction tran, int? cVId)
            {
                return CVWorkExperiencesProvider.Generated.DeleteByFK(cVId)
    ;
            }


            #endregion

        }
    }
}
