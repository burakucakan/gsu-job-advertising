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

    public partial class CVs
    {

        #region ColumnNames
        public struct ColumnNames
        {
            public const string ID = "ID";
            public const string UserId = "UserId";
            public const string Name = "Name";
            public const string CvLanguage = "CvLanguage";
            public const string MaritalStatus = "MaritalStatus";
            public const string BirthPlaceCountry = "BirthPlaceCountry";
            public const string BirthPlaceCity = "BirthPlaceCity";
            public const string BirthPlaceCityFree = "BirthPlaceCityFree";
            public const string Nationality = "Nationality";
            public const string HomePhone = "HomePhone";
            public const string MobilePhone1 = "MobilePhone1";
            public const string MobilePhone2 = "MobilePhone2";
            public const string Email = "Email";
            public const string Webpage = "Webpage";
            public const string ContactType = "ContactType";
            public const string CigaretteUseType = "CigaretteUseType";
            public const string OtherClubs = "OtherClubs";
            public const string OtherUniversityClubs = "OtherUniversityClubs";
            public const string EducationState = "EducationState";
            public const string MasterStartDate = "MasterStartDate";
            public const string MasterEndDate = "MasterEndDate";
            public const string MasterUniversity = "MasterUniversity";
            public const string MasterUniversityFree = "MasterUniversityFree";
            public const string MasterInstitute = "MasterInstitute";
            public const string MasterDepartment = "MasterDepartment";
            public const string MasterDepartmentFree = "MasterDepartmentFree";
            public const string MasterGradeSystem = "MasterGradeSystem";
            public const string MasterGraduationGrade = "MasterGraduationGrade";
            public const string LicenseStartDate = "LicenseStartDate";
            public const string LicenseEndDate = "LicenseEndDate";
            public const string LicenseUniversity = "LicenseUniversity";
            public const string LicenseUniversityFree = "LicenseUniversityFree";
            public const string LicenseInstitute = "LicenseInstitute";
            public const string LicenseDepartment = "LicenseDepartment";
            public const string LicenseDepartmentFree = "LicenseDepartmentFree";
            public const string LicenseEducationType = "LicenseEducationType";
            public const string LicenseGradeSystem = "LicenseGradeSystem";
            public const string LicenseGraduationGrade = "LicenseGraduationGrade";
            public const string HighSchool = "HighSchool";
            public const string HighSchoolEndDate = "HighSchoolEndDate";
            public const string HighSchoolGradeSystem = "HighSchoolGradeSystem";
            public const string HighSchoolGraduationGrade = "HighSchoolGraduationGrade";
            public const string ComputerInfo = "ComputerInfo";
            public const string HasDrivingLicense = "HasDrivingLicense";
            public const string InterestedAdvertisementType = "InterestedAdvertisementType";
            public const string TotalWorkExperienceInMonth = "TotalWorkExperienceInMonth";
            public const string WorkingStatus = "WorkingStatus";
            public const string CVState = "CVState";
            public const string IsDefault = "IsDefault";
            public const string ModifyDate = "ModifyDate";
            public const string CreateDate = "CreateDate";
        }
        #endregion

        #region Create DataTable
        public static DataTable CreateTable()
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("ID", System.Type.GetType("System.Int32"));
            dt.Columns.Add("UserId", System.Type.GetType("System.Int32"));
            dt.Columns.Add("Name", System.Type.GetType("System.String"));
            dt.Columns.Add("CvLanguage", System.Type.GetType("System.Int32"));
            dt.Columns.Add("MaritalStatus", System.Type.GetType("System.Int32"));
            dt.Columns.Add("BirthPlaceCountry", System.Type.GetType("System.Int32"));
            dt.Columns.Add("BirthPlaceCity", System.Type.GetType("System.Int32"));
            dt.Columns.Add("BirthPlaceCityFree", System.Type.GetType("System.String"));
            dt.Columns.Add("Nationality", System.Type.GetType("System.Int32"));
            dt.Columns.Add("HomePhone", System.Type.GetType("System.String"));
            dt.Columns.Add("MobilePhone1", System.Type.GetType("System.String"));
            dt.Columns.Add("MobilePhone2", System.Type.GetType("System.String"));
            dt.Columns.Add("Email", System.Type.GetType("System.String"));
            dt.Columns.Add("Webpage", System.Type.GetType("System.String"));
            dt.Columns.Add("ContactType", System.Type.GetType("System.Int32"));
            dt.Columns.Add("CigaretteUseType", System.Type.GetType("System.Int32"));
            dt.Columns.Add("OtherClubs", System.Type.GetType("System.String"));
            dt.Columns.Add("OtherUniversityClubs", System.Type.GetType("System.String"));
            dt.Columns.Add("EducationState", System.Type.GetType("System.Int32"));
            dt.Columns.Add("MasterStartDate", System.Type.GetType("System.DateTime"));
            dt.Columns.Add("MasterEndDate", System.Type.GetType("System.DateTime"));
            dt.Columns.Add("MasterUniversity", System.Type.GetType("System.Int32"));
            dt.Columns.Add("MasterUniversityFree", System.Type.GetType("System.String"));
            dt.Columns.Add("MasterInstitute", System.Type.GetType("System.Int32"));
            dt.Columns.Add("MasterDepartment", System.Type.GetType("System.Int32"));
            dt.Columns.Add("MasterDepartmentFree", System.Type.GetType("System.String"));
            dt.Columns.Add("MasterGradeSystem", System.Type.GetType("System.Int32"));
            dt.Columns.Add("MasterGraduationGrade", System.Type.GetType("System.Decimal"));
            dt.Columns.Add("LicenseStartDate", System.Type.GetType("System.DateTime"));
            dt.Columns.Add("LicenseEndDate", System.Type.GetType("System.DateTime"));
            dt.Columns.Add("LicenseUniversity", System.Type.GetType("System.Int32"));
            dt.Columns.Add("LicenseUniversityFree", System.Type.GetType("System.String"));
            dt.Columns.Add("LicenseInstitute", System.Type.GetType("System.Int32"));
            dt.Columns.Add("LicenseDepartment", System.Type.GetType("System.Int32"));
            dt.Columns.Add("LicenseDepartmentFree", System.Type.GetType("System.String"));
            dt.Columns.Add("LicenseEducationType", System.Type.GetType("System.Int32"));
            dt.Columns.Add("LicenseGradeSystem", System.Type.GetType("System.Int32"));
            dt.Columns.Add("LicenseGraduationGrade", System.Type.GetType("System.Decimal"));
            dt.Columns.Add("HighSchool", System.Type.GetType("System.String"));
            dt.Columns.Add("HighSchoolEndDate", System.Type.GetType("System.DateTime"));
            dt.Columns.Add("HighSchoolGradeSystem", System.Type.GetType("System.Int32"));
            dt.Columns.Add("HighSchoolGraduationGrade", System.Type.GetType("System.Decimal"));
            dt.Columns.Add("ComputerInfo", System.Type.GetType("System.String"));
            dt.Columns.Add("HasDrivingLicense", System.Type.GetType("System.Boolean"));
            dt.Columns.Add("InterestedAdvertisementType", System.Type.GetType("System.Int32"));
            dt.Columns.Add("TotalWorkExperienceInMonth", System.Type.GetType("System.Int32"));
            dt.Columns.Add("WorkingStatus", System.Type.GetType("System.Int32"));
            dt.Columns.Add("CVState", System.Type.GetType("System.Int32"));
            dt.Columns.Add("IsDefault", System.Type.GetType("System.Boolean"));
            dt.Columns.Add("ModifyDate", System.Type.GetType("System.DateTime"));
            dt.Columns.Add("CreateDate", System.Type.GetType("System.DateTime"));

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
                    conn = new SqlConnection(CVsProvider.GetConnectionString());
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
                    throw new MyException(ex.Message, "CVs", "Add");
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
                    conn = new SqlConnection(CVsProvider.GetConnectionString());
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
                    throw new MyException(ex.Message, "CVs", "Update");
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
                return CVsProvider.Generated.Add((int)dr[ColumnNames.UserId],
                                                    dr[ColumnNames.Name].ToString(),
                                                    (int)dr[ColumnNames.CvLanguage],
                                                    (int)dr[ColumnNames.MaritalStatus],
                                                    (int)dr[ColumnNames.BirthPlaceCountry],
                                                    (int)dr[ColumnNames.BirthPlaceCity],
                                                    dr[ColumnNames.BirthPlaceCityFree].ToString(),
                                                    (int)dr[ColumnNames.Nationality],
                                                    dr[ColumnNames.HomePhone].ToString(),
                                                    dr[ColumnNames.MobilePhone1].ToString(),
                                                    dr[ColumnNames.MobilePhone2].ToString(),
                                                    dr[ColumnNames.Email].ToString(),
                                                    dr[ColumnNames.Webpage].ToString(),
                                                    DBNullHelper.GetNullableValue<int>(dr[ColumnNames.ContactType]),
                                                    DBNullHelper.GetNullableValue<int>(dr[ColumnNames.CigaretteUseType]),
                                                    dr[ColumnNames.OtherClubs].ToString(),
                                                    dr[ColumnNames.OtherUniversityClubs].ToString(),
                                                    (int)dr[ColumnNames.EducationState],
                                                    DBNullHelper.GetNullableValue<DateTime>(dr[ColumnNames.MasterStartDate]),
                                                    DBNullHelper.GetNullableValue<DateTime>(dr[ColumnNames.MasterEndDate]),
                                                    DBNullHelper.GetNullableValue<int>(dr[ColumnNames.MasterUniversity]),
                                                    dr[ColumnNames.MasterUniversityFree].ToString(),
                                                    DBNullHelper.GetNullableValue<int>(dr[ColumnNames.MasterInstitute]),
                                                    DBNullHelper.GetNullableValue<int>(dr[ColumnNames.MasterDepartment]),
                                                    dr[ColumnNames.MasterDepartmentFree].ToString(),
                                                    DBNullHelper.GetNullableValue<int>(dr[ColumnNames.MasterGradeSystem]),
                                                    DBNullHelper.GetNullableValue<decimal>(dr[ColumnNames.MasterGraduationGrade]),
                                                    DBNullHelper.GetNullableValue<DateTime>(dr[ColumnNames.LicenseStartDate]),
                                                    DBNullHelper.GetNullableValue<DateTime>(dr[ColumnNames.LicenseEndDate]),
                                                    DBNullHelper.GetNullableValue<int>(dr[ColumnNames.LicenseUniversity]),
                                                    dr[ColumnNames.LicenseUniversityFree].ToString(),
                                                    DBNullHelper.GetNullableValue<int>(dr[ColumnNames.LicenseInstitute]),
                                                    DBNullHelper.GetNullableValue<int>(dr[ColumnNames.LicenseDepartment]),
                                                    dr[ColumnNames.LicenseDepartmentFree].ToString(),
                                                    DBNullHelper.GetNullableValue<int>(dr[ColumnNames.LicenseEducationType]),
                                                    DBNullHelper.GetNullableValue<int>(dr[ColumnNames.LicenseGradeSystem]),
                                                    DBNullHelper.GetNullableValue<decimal>(dr[ColumnNames.LicenseGraduationGrade]),
                                                    dr[ColumnNames.HighSchool].ToString(),
                                                    DBNullHelper.GetNullableValue<DateTime>(dr[ColumnNames.HighSchoolEndDate]),
                                                    DBNullHelper.GetNullableValue<int>(dr[ColumnNames.HighSchoolGradeSystem]),
                                                    DBNullHelper.GetNullableValue<decimal>(dr[ColumnNames.HighSchoolGraduationGrade]),
                                                    dr[ColumnNames.ComputerInfo].ToString(),
                                                    DBNullHelper.GetNullableValue<bool>(dr[ColumnNames.HasDrivingLicense]),
                                                    DBNullHelper.GetNullableValue<int>(dr[ColumnNames.InterestedAdvertisementType]),
                                                    DBNullHelper.GetNullableValue<int>(dr[ColumnNames.TotalWorkExperienceInMonth]),
                                                    DBNullHelper.GetNullableValue<int>(dr[ColumnNames.WorkingStatus]),
                                                    (int)dr[ColumnNames.CVState],
                                                    (bool)dr[ColumnNames.IsDefault],
                                                    (DateTime)dr[ColumnNames.ModifyDate],
                                                    (DateTime)dr[ColumnNames.CreateDate]);

            }

            public static int Add(SqlTransaction tran, DataRow dr)
            {
                return CVsProvider.Generated.Add(tran,
                                                    (int)dr[ColumnNames.UserId],
                                                    dr[ColumnNames.Name].ToString(),
                                                    (int)dr[ColumnNames.CvLanguage],
                                                    (int)dr[ColumnNames.MaritalStatus],
                                                    (int)dr[ColumnNames.BirthPlaceCountry],
                                                    (int)dr[ColumnNames.BirthPlaceCity],
                                                    dr[ColumnNames.BirthPlaceCityFree].ToString(),
                                                    (int)dr[ColumnNames.Nationality],
                                                    dr[ColumnNames.HomePhone].ToString(),
                                                    dr[ColumnNames.MobilePhone1].ToString(),
                                                    dr[ColumnNames.MobilePhone2].ToString(),
                                                    dr[ColumnNames.Email].ToString(),
                                                    dr[ColumnNames.Webpage].ToString(),
                                                    DBNullHelper.GetNullableValue<int>(dr[ColumnNames.ContactType]),
                                                    DBNullHelper.GetNullableValue<int>(dr[ColumnNames.CigaretteUseType]),
                                                    dr[ColumnNames.OtherClubs].ToString(),
                                                    dr[ColumnNames.OtherUniversityClubs].ToString(),
                                                    (int)dr[ColumnNames.EducationState],
                                                    DBNullHelper.GetNullableValue<DateTime>(dr[ColumnNames.MasterStartDate]),
                                                    DBNullHelper.GetNullableValue<DateTime>(dr[ColumnNames.MasterEndDate]),
                                                    DBNullHelper.GetNullableValue<int>(dr[ColumnNames.MasterUniversity]),
                                                    dr[ColumnNames.MasterUniversityFree].ToString(),
                                                    DBNullHelper.GetNullableValue<int>(dr[ColumnNames.MasterInstitute]),
                                                    DBNullHelper.GetNullableValue<int>(dr[ColumnNames.MasterDepartment]),
                                                    dr[ColumnNames.MasterDepartmentFree].ToString(),
                                                    DBNullHelper.GetNullableValue<int>(dr[ColumnNames.MasterGradeSystem]),
                                                    DBNullHelper.GetNullableValue<decimal>(dr[ColumnNames.MasterGraduationGrade]),
                                                    DBNullHelper.GetNullableValue<DateTime>(dr[ColumnNames.LicenseStartDate]),
                                                    DBNullHelper.GetNullableValue<DateTime>(dr[ColumnNames.LicenseEndDate]),
                                                    DBNullHelper.GetNullableValue<int>(dr[ColumnNames.LicenseUniversity]),
                                                    dr[ColumnNames.LicenseUniversityFree].ToString(),
                                                    DBNullHelper.GetNullableValue<int>(dr[ColumnNames.LicenseInstitute]),
                                                    DBNullHelper.GetNullableValue<int>(dr[ColumnNames.LicenseDepartment]),
                                                    dr[ColumnNames.LicenseDepartmentFree].ToString(),
                                                    DBNullHelper.GetNullableValue<int>(dr[ColumnNames.LicenseEducationType]),
                                                    DBNullHelper.GetNullableValue<int>(dr[ColumnNames.LicenseGradeSystem]),
                                                    DBNullHelper.GetNullableValue<decimal>(dr[ColumnNames.LicenseGraduationGrade]),
                                                    dr[ColumnNames.HighSchool].ToString(),
                                                    DBNullHelper.GetNullableValue<DateTime>(dr[ColumnNames.HighSchoolEndDate]),
                                                    DBNullHelper.GetNullableValue<int>(dr[ColumnNames.HighSchoolGradeSystem]),
                                                    DBNullHelper.GetNullableValue<decimal>(dr[ColumnNames.HighSchoolGraduationGrade]),
                                                    dr[ColumnNames.ComputerInfo].ToString(),
                                                    DBNullHelper.GetNullableValue<bool>(dr[ColumnNames.HasDrivingLicense]),
                                                    DBNullHelper.GetNullableValue<int>(dr[ColumnNames.InterestedAdvertisementType]),
                                                    DBNullHelper.GetNullableValue<int>(dr[ColumnNames.TotalWorkExperienceInMonth]),
                                                    DBNullHelper.GetNullableValue<int>(dr[ColumnNames.WorkingStatus]),
                                                    (int)dr[ColumnNames.CVState],
                                                    (bool)dr[ColumnNames.IsDefault],
                                                    (DateTime)dr[ColumnNames.ModifyDate],
                                                    (DateTime)dr[ColumnNames.CreateDate]);

            }

            public static int Update(DataRow dr)
            {
                return CVsProvider.Generated.Update((int)dr[ColumnNames.ID],
                                                    (int)dr[ColumnNames.UserId],
                                                    dr[ColumnNames.Name].ToString(),
                                                    (int)dr[ColumnNames.CvLanguage],
                                                    (int)dr[ColumnNames.MaritalStatus],
                                                    (int)dr[ColumnNames.BirthPlaceCountry],
                                                    (int)dr[ColumnNames.BirthPlaceCity],
                                                    dr[ColumnNames.BirthPlaceCityFree].ToString(),
                                                    (int)dr[ColumnNames.Nationality],
                                                    dr[ColumnNames.HomePhone].ToString(),
                                                    dr[ColumnNames.MobilePhone1].ToString(),
                                                    dr[ColumnNames.MobilePhone2].ToString(),
                                                    dr[ColumnNames.Email].ToString(),
                                                    dr[ColumnNames.Webpage].ToString(),
                                                    DBNullHelper.GetNullableValue<int>(dr[ColumnNames.ContactType]),
                                                    DBNullHelper.GetNullableValue<int>(dr[ColumnNames.CigaretteUseType]),
                                                    dr[ColumnNames.OtherClubs].ToString(),
                                                    dr[ColumnNames.OtherUniversityClubs].ToString(),
                                                    (int)dr[ColumnNames.EducationState],
                                                    DBNullHelper.GetNullableValue<DateTime>(dr[ColumnNames.MasterStartDate]),
                                                    DBNullHelper.GetNullableValue<DateTime>(dr[ColumnNames.MasterEndDate]),
                                                    DBNullHelper.GetNullableValue<int>(dr[ColumnNames.MasterUniversity]),
                                                    dr[ColumnNames.MasterUniversityFree].ToString(),
                                                    DBNullHelper.GetNullableValue<int>(dr[ColumnNames.MasterInstitute]),
                                                    DBNullHelper.GetNullableValue<int>(dr[ColumnNames.MasterDepartment]),
                                                    dr[ColumnNames.MasterDepartmentFree].ToString(),
                                                    DBNullHelper.GetNullableValue<int>(dr[ColumnNames.MasterGradeSystem]),
                                                    DBNullHelper.GetNullableValue<decimal>(dr[ColumnNames.MasterGraduationGrade]),
                                                    DBNullHelper.GetNullableValue<DateTime>(dr[ColumnNames.LicenseStartDate]),
                                                    DBNullHelper.GetNullableValue<DateTime>(dr[ColumnNames.LicenseEndDate]),
                                                    DBNullHelper.GetNullableValue<int>(dr[ColumnNames.LicenseUniversity]),
                                                    dr[ColumnNames.LicenseUniversityFree].ToString(),
                                                    DBNullHelper.GetNullableValue<int>(dr[ColumnNames.LicenseInstitute]),
                                                    DBNullHelper.GetNullableValue<int>(dr[ColumnNames.LicenseDepartment]),
                                                    dr[ColumnNames.LicenseDepartmentFree].ToString(),
                                                    DBNullHelper.GetNullableValue<int>(dr[ColumnNames.LicenseEducationType]),
                                                    DBNullHelper.GetNullableValue<int>(dr[ColumnNames.LicenseGradeSystem]),
                                                    DBNullHelper.GetNullableValue<decimal>(dr[ColumnNames.LicenseGraduationGrade]),
                                                    dr[ColumnNames.HighSchool].ToString(),
                                                    DBNullHelper.GetNullableValue<DateTime>(dr[ColumnNames.HighSchoolEndDate]),
                                                    DBNullHelper.GetNullableValue<int>(dr[ColumnNames.HighSchoolGradeSystem]),
                                                    DBNullHelper.GetNullableValue<decimal>(dr[ColumnNames.HighSchoolGraduationGrade]),
                                                    dr[ColumnNames.ComputerInfo].ToString(),
                                                    DBNullHelper.GetNullableValue<bool>(dr[ColumnNames.HasDrivingLicense]),
                                                    DBNullHelper.GetNullableValue<int>(dr[ColumnNames.InterestedAdvertisementType]),
                                                    DBNullHelper.GetNullableValue<int>(dr[ColumnNames.TotalWorkExperienceInMonth]),
                                                    DBNullHelper.GetNullableValue<int>(dr[ColumnNames.WorkingStatus]),
                                                    (int)dr[ColumnNames.CVState],
                                                    (bool)dr[ColumnNames.IsDefault],
                                                    (DateTime)dr[ColumnNames.ModifyDate]);
            }

            public static int Update(SqlTransaction tran, DataRow dr)
            {
                return CVsProvider.Generated.Update(tran,
                                                    (int)dr[ColumnNames.ID],
                                                    (int)dr[ColumnNames.UserId],
                                                    dr[ColumnNames.Name].ToString(),
                                                    (int)dr[ColumnNames.CvLanguage],
                                                    (int)dr[ColumnNames.MaritalStatus],
                                                    (int)dr[ColumnNames.BirthPlaceCountry],
                                                    (int)dr[ColumnNames.BirthPlaceCity],
                                                    dr[ColumnNames.BirthPlaceCityFree].ToString(),
                                                    (int)dr[ColumnNames.Nationality],
                                                    dr[ColumnNames.HomePhone].ToString(),
                                                    dr[ColumnNames.MobilePhone1].ToString(),
                                                    dr[ColumnNames.MobilePhone2].ToString(),
                                                    dr[ColumnNames.Email].ToString(),
                                                    dr[ColumnNames.Webpage].ToString(),
                                                    DBNullHelper.GetNullableValue<int>(dr[ColumnNames.ContactType]),
                                                    DBNullHelper.GetNullableValue<int>(dr[ColumnNames.CigaretteUseType]),
                                                    dr[ColumnNames.OtherClubs].ToString(),
                                                    dr[ColumnNames.OtherUniversityClubs].ToString(),
                                                    (int)dr[ColumnNames.EducationState],
                                                    DBNullHelper.GetNullableValue<DateTime>(dr[ColumnNames.MasterStartDate]),
                                                    DBNullHelper.GetNullableValue<DateTime>(dr[ColumnNames.MasterEndDate]),
                                                    DBNullHelper.GetNullableValue<int>(dr[ColumnNames.MasterUniversity]),
                                                    dr[ColumnNames.MasterUniversityFree].ToString(),
                                                    DBNullHelper.GetNullableValue<int>(dr[ColumnNames.MasterInstitute]),
                                                    DBNullHelper.GetNullableValue<int>(dr[ColumnNames.MasterDepartment]),
                                                    dr[ColumnNames.MasterDepartmentFree].ToString(),
                                                    DBNullHelper.GetNullableValue<int>(dr[ColumnNames.MasterGradeSystem]),
                                                    DBNullHelper.GetNullableValue<decimal>(dr[ColumnNames.MasterGraduationGrade]),
                                                    DBNullHelper.GetNullableValue<DateTime>(dr[ColumnNames.LicenseStartDate]),
                                                    DBNullHelper.GetNullableValue<DateTime>(dr[ColumnNames.LicenseEndDate]),
                                                    DBNullHelper.GetNullableValue<int>(dr[ColumnNames.LicenseUniversity]),
                                                    dr[ColumnNames.LicenseUniversityFree].ToString(),
                                                    DBNullHelper.GetNullableValue<int>(dr[ColumnNames.LicenseInstitute]),
                                                    DBNullHelper.GetNullableValue<int>(dr[ColumnNames.LicenseDepartment]),
                                                    dr[ColumnNames.LicenseDepartmentFree].ToString(),
                                                    DBNullHelper.GetNullableValue<int>(dr[ColumnNames.LicenseEducationType]),
                                                    DBNullHelper.GetNullableValue<int>(dr[ColumnNames.LicenseGradeSystem]),
                                                    DBNullHelper.GetNullableValue<decimal>(dr[ColumnNames.LicenseGraduationGrade]),
                                                    dr[ColumnNames.HighSchool].ToString(),
                                                    DBNullHelper.GetNullableValue<DateTime>(dr[ColumnNames.HighSchoolEndDate]),
                                                    DBNullHelper.GetNullableValue<int>(dr[ColumnNames.HighSchoolGradeSystem]),
                                                    DBNullHelper.GetNullableValue<decimal>(dr[ColumnNames.HighSchoolGraduationGrade]),
                                                    dr[ColumnNames.ComputerInfo].ToString(),
                                                    DBNullHelper.GetNullableValue<bool>(dr[ColumnNames.HasDrivingLicense]),
                                                    DBNullHelper.GetNullableValue<int>(dr[ColumnNames.InterestedAdvertisementType]),
                                                    DBNullHelper.GetNullableValue<int>(dr[ColumnNames.TotalWorkExperienceInMonth]),
                                                    DBNullHelper.GetNullableValue<int>(dr[ColumnNames.WorkingStatus]),
                                                    (int)dr[ColumnNames.CVState],
                                                    (bool)dr[ColumnNames.IsDefault],
                                                    (DateTime)dr[ColumnNames.ModifyDate]);
            }
        }
        #endregion

        public class Generated
        {

            #region Get Functions
            public static DataTable GetByParams(int? id, int? userId, string name, int? cvLanguage, int? maritalStatus, int? birthPlaceCountry, int? birthPlaceCity, string birthPlaceCityFree, int? nationality, string homePhone, string mobilePhone1, string mobilePhone2, string email, string webpage, int? contactType, int? cigaretteUseType, string otherClubs, string otherUniversityClubs, int? educationState, DateTime? masterStartDate, DateTime? beforeMasterStartDate, DateTime? afterOrEqualMasterStartDate, DateTime? masterEndDate, DateTime? beforeMasterEndDate, DateTime? afterOrEqualMasterEndDate, int? masterUniversity, string masterUniversityFree, int? masterInstitute, int? masterDepartment, string masterDepartmentFree, int? masterGradeSystem, decimal? masterGraduationGrade, DateTime? licenseStartDate, DateTime? beforeLicenseStartDate, DateTime? afterOrEqualLicenseStartDate, DateTime? licenseEndDate, DateTime? beforeLicenseEndDate, DateTime? afterOrEqualLicenseEndDate, int? licenseUniversity, string licenseUniversityFree, int? licenseInstitute, int? licenseDepartment, string licenseDepartmentFree, int? licenseEducationType, int? licenseGradeSystem, decimal? licenseGraduationGrade, string highSchool, DateTime? highSchoolEndDate, DateTime? beforeHighSchoolEndDate, DateTime? afterOrEqualHighSchoolEndDate, int? highSchoolGradeSystem, decimal? highSchoolGraduationGrade, string computerInfo, bool? hasDrivingLicense, int? interestedAdvertisementType, int? totalWorkExperienceInMonth, int? workingStatus, int? cVState, bool? isDefault, DateTime? modifyDate, DateTime? beforeModifyDate, DateTime? afterOrEqualModifyDate, DateTime? createDate, DateTime? beforeCreateDate, DateTime? afterOrEqualCreateDate)
            {
                return CVsProvider.Generated.GetByParams(id, userId, name, cvLanguage, maritalStatus, birthPlaceCountry, birthPlaceCity, birthPlaceCityFree, nationality, homePhone, mobilePhone1, mobilePhone2, email, webpage, contactType, cigaretteUseType, otherClubs, otherUniversityClubs, educationState, masterStartDate, beforeMasterStartDate, afterOrEqualMasterStartDate, masterEndDate, beforeMasterEndDate, afterOrEqualMasterEndDate, masterUniversity, masterUniversityFree, masterInstitute, masterDepartment, masterDepartmentFree, masterGradeSystem, masterGraduationGrade, licenseStartDate, beforeLicenseStartDate, afterOrEqualLicenseStartDate, licenseEndDate, beforeLicenseEndDate, afterOrEqualLicenseEndDate, licenseUniversity, licenseUniversityFree, licenseInstitute, licenseDepartment, licenseDepartmentFree, licenseEducationType, licenseGradeSystem, licenseGraduationGrade, highSchool, highSchoolEndDate, beforeHighSchoolEndDate, afterOrEqualHighSchoolEndDate, highSchoolGradeSystem, highSchoolGraduationGrade, computerInfo, hasDrivingLicense, interestedAdvertisementType, totalWorkExperienceInMonth, workingStatus, cVState, isDefault, modifyDate, beforeModifyDate, afterOrEqualModifyDate, createDate, beforeCreateDate, afterOrEqualCreateDate)
    .Tables[0];
            }

            public static DataTable GetByParams(SqlTransaction tran, int? id, int? userId, string name, int? cvLanguage, int? maritalStatus, int? birthPlaceCountry, int? birthPlaceCity, string birthPlaceCityFree, int? nationality, string homePhone, string mobilePhone1, string mobilePhone2, string email, string webpage, int? contactType, int? cigaretteUseType, string otherClubs, string otherUniversityClubs, int? educationState, DateTime? masterStartDate, DateTime? beforeMasterStartDate, DateTime? afterOrEqualMasterStartDate, DateTime? masterEndDate, DateTime? beforeMasterEndDate, DateTime? afterOrEqualMasterEndDate, int? masterUniversity, string masterUniversityFree, int? masterInstitute, int? masterDepartment, string masterDepartmentFree, int? masterGradeSystem, decimal? masterGraduationGrade, DateTime? licenseStartDate, DateTime? beforeLicenseStartDate, DateTime? afterOrEqualLicenseStartDate, DateTime? licenseEndDate, DateTime? beforeLicenseEndDate, DateTime? afterOrEqualLicenseEndDate, int? licenseUniversity, string licenseUniversityFree, int? licenseInstitute, int? licenseDepartment, string licenseDepartmentFree, int? licenseEducationType, int? licenseGradeSystem, decimal? licenseGraduationGrade, string highSchool, DateTime? highSchoolEndDate, DateTime? beforeHighSchoolEndDate, DateTime? afterOrEqualHighSchoolEndDate, int? highSchoolGradeSystem, decimal? highSchoolGraduationGrade, string computerInfo, bool? hasDrivingLicense, int? interestedAdvertisementType, int? totalWorkExperienceInMonth, int? workingStatus, int? cVState, bool? isDefault, DateTime? modifyDate, DateTime? beforeModifyDate, DateTime? afterOrEqualModifyDate, DateTime? createDate, DateTime? beforeCreateDate, DateTime? afterOrEqualCreateDate)
            {
                return CVsProvider.Generated.GetByParams(tran, id, userId, name, cvLanguage, maritalStatus, birthPlaceCountry, birthPlaceCity, birthPlaceCityFree, nationality, homePhone, mobilePhone1, mobilePhone2, email, webpage, contactType, cigaretteUseType, otherClubs, otherUniversityClubs, educationState, masterStartDate, beforeMasterStartDate, afterOrEqualMasterStartDate, masterEndDate, beforeMasterEndDate, afterOrEqualMasterEndDate, masterUniversity, masterUniversityFree, masterInstitute, masterDepartment, masterDepartmentFree, masterGradeSystem, masterGraduationGrade, licenseStartDate, beforeLicenseStartDate, afterOrEqualLicenseStartDate, licenseEndDate, beforeLicenseEndDate, afterOrEqualLicenseEndDate, licenseUniversity, licenseUniversityFree, licenseInstitute, licenseDepartment, licenseDepartmentFree, licenseEducationType, licenseGradeSystem, licenseGraduationGrade, highSchool, highSchoolEndDate, beforeHighSchoolEndDate, afterOrEqualHighSchoolEndDate, highSchoolGradeSystem, highSchoolGraduationGrade, computerInfo, hasDrivingLicense, interestedAdvertisementType, totalWorkExperienceInMonth, workingStatus, cVState, isDefault, modifyDate, beforeModifyDate, afterOrEqualModifyDate, createDate, beforeCreateDate, afterOrEqualCreateDate)
    .Tables[0];
            }

            public static DataTable GetByParams(params SqlParameter[] sqlParams)
            {
                return CVsProvider.Generated.GetByParams(sqlParams).Tables[0];
            }

            public static DataTable GetByParams(SqlTransaction tran, params SqlParameter[] sqlParams)
            {
                return CVsProvider.Generated.GetByParams(tran, sqlParams).Tables[0];
            }

            public static DataTable GetByFKBasic(int? userId)
            {
                return CVsProvider.Generated.GetByFKBasic(userId)
    .Tables[0];
            }

            public static DataTable GetByFKBasic(SqlTransaction tran, int? userId)
            {
                return CVsProvider.Generated.GetByFKBasic(tran, userId)
    .Tables[0];
            }


            public static DataTable GetAll(SqlTransaction tran)
            {
                return CVsProvider.Generated.GetAll(tran).Tables[0];
            }

            public static DataTable GetAll()
            {
                return CVsProvider.Generated.GetAll().Tables[0];
            }

            public static DataTable Get(SqlTransaction tran, int id)
            {
                return CVsProvider.Generated.Get(tran, id)
    .Tables[0];
            }

            public static DataTable Get(int id)
            {
                return CVsProvider.Generated.Get(id)
    .Tables[0];
            }

            public static DataTable GetByFK(SqlTransaction tran, int userId)
            {
                return CVsProvider.Generated.GetByFK(tran, userId)
    .Tables[0];
            }

            public static DataTable GetByFK(int userId)
            {
                return CVsProvider.Generated.GetByFK(userId)
    .Tables[0];
            }


            #endregion

            #region Update Functions
            public static int Update(int id, int userId, string name, int cvLanguage, int maritalStatus, int birthPlaceCountry, int birthPlaceCity, string birthPlaceCityFree, int nationality, string homePhone, string mobilePhone1, string mobilePhone2, string email, string webpage, int? contactType, int? cigaretteUseType, string otherClubs, string otherUniversityClubs, int educationState, DateTime? masterStartDate, DateTime? masterEndDate, int? masterUniversity, string masterUniversityFree, int? masterInstitute, int? masterDepartment, string masterDepartmentFree, int? masterGradeSystem, decimal? masterGraduationGrade, DateTime? licenseStartDate, DateTime? licenseEndDate, int? licenseUniversity, string licenseUniversityFree, int? licenseInstitute, int? licenseDepartment, string licenseDepartmentFree, int? licenseEducationType, int? licenseGradeSystem, decimal? licenseGraduationGrade, string highSchool, DateTime? highSchoolEndDate, int? highSchoolGradeSystem, decimal? highSchoolGraduationGrade, string computerInfo, bool? hasDrivingLicense, int? interestedAdvertisementType, int? totalWorkExperienceInMonth, int? workingStatus, int cVState, bool isDefault, DateTime modifyDate)
            {
                return CVsProvider.Generated.Update(id, userId, name, cvLanguage, maritalStatus, birthPlaceCountry, birthPlaceCity, birthPlaceCityFree, nationality, homePhone, mobilePhone1, mobilePhone2, email, webpage, contactType, cigaretteUseType, otherClubs, otherUniversityClubs, educationState, masterStartDate, masterEndDate, masterUniversity, masterUniversityFree, masterInstitute, masterDepartment, masterDepartmentFree, masterGradeSystem, masterGraduationGrade, licenseStartDate, licenseEndDate, licenseUniversity, licenseUniversityFree, licenseInstitute, licenseDepartment, licenseDepartmentFree, licenseEducationType, licenseGradeSystem, licenseGraduationGrade, highSchool, highSchoolEndDate, highSchoolGradeSystem, highSchoolGraduationGrade, computerInfo, hasDrivingLicense, interestedAdvertisementType, totalWorkExperienceInMonth, workingStatus, cVState, isDefault, modifyDate)
    ;
            }

            public static int Update(SqlTransaction tran, int id, int userId, string name, int cvLanguage, int maritalStatus, int birthPlaceCountry, int birthPlaceCity, string birthPlaceCityFree, int nationality, string homePhone, string mobilePhone1, string mobilePhone2, string email, string webpage, int? contactType, int? cigaretteUseType, string otherClubs, string otherUniversityClubs, int educationState, DateTime? masterStartDate, DateTime? masterEndDate, int? masterUniversity, string masterUniversityFree, int? masterInstitute, int? masterDepartment, string masterDepartmentFree, int? masterGradeSystem, decimal? masterGraduationGrade, DateTime? licenseStartDate, DateTime? licenseEndDate, int? licenseUniversity, string licenseUniversityFree, int? licenseInstitute, int? licenseDepartment, string licenseDepartmentFree, int? licenseEducationType, int? licenseGradeSystem, decimal? licenseGraduationGrade, string highSchool, DateTime? highSchoolEndDate, int? highSchoolGradeSystem, decimal? highSchoolGraduationGrade, string computerInfo, bool? hasDrivingLicense, int? interestedAdvertisementType, int? totalWorkExperienceInMonth, int? workingStatus, int cVState, bool isDefault, DateTime modifyDate)
            {
                return CVsProvider.Generated.Update(id, userId, name, cvLanguage, maritalStatus, birthPlaceCountry, birthPlaceCity, birthPlaceCityFree, nationality, homePhone, mobilePhone1, mobilePhone2, email, webpage, contactType, cigaretteUseType, otherClubs, otherUniversityClubs, educationState, masterStartDate, masterEndDate, masterUniversity, masterUniversityFree, masterInstitute, masterDepartment, masterDepartmentFree, masterGradeSystem, masterGraduationGrade, licenseStartDate, licenseEndDate, licenseUniversity, licenseUniversityFree, licenseInstitute, licenseDepartment, licenseDepartmentFree, licenseEducationType, licenseGradeSystem, licenseGraduationGrade, highSchool, highSchoolEndDate, highSchoolGradeSystem, highSchoolGraduationGrade, computerInfo, hasDrivingLicense, interestedAdvertisementType, totalWorkExperienceInMonth, workingStatus, cVState, isDefault, modifyDate)
    ;
            }

            public static int UpdateByParams(int id, int? userId, string name, int? cvLanguage, int? maritalStatus, int? birthPlaceCountry, int? birthPlaceCity, string birthPlaceCityFree, int? nationality, string homePhone, string mobilePhone1, string mobilePhone2, string email, string webpage, int? contactType, int? cigaretteUseType, string otherClubs, string otherUniversityClubs, int? educationState, DateTime? masterStartDate, DateTime? masterEndDate, int? masterUniversity, string masterUniversityFree, int? masterInstitute, int? masterDepartment, string masterDepartmentFree, int? masterGradeSystem, decimal? masterGraduationGrade, DateTime? licenseStartDate, DateTime? licenseEndDate, int? licenseUniversity, string licenseUniversityFree, int? licenseInstitute, int? licenseDepartment, string licenseDepartmentFree, int? licenseEducationType, int? licenseGradeSystem, decimal? licenseGraduationGrade, string highSchool, DateTime? highSchoolEndDate, int? highSchoolGradeSystem, decimal? highSchoolGraduationGrade, string computerInfo, bool? hasDrivingLicense, int? interestedAdvertisementType, int? totalWorkExperienceInMonth, int? workingStatus, int? cVState, bool? isDefault, DateTime? modifyDate, DateTime? createDate)
            {
                return CVsProvider.Generated.UpdateByParams(id, userId, name, cvLanguage, maritalStatus, birthPlaceCountry, birthPlaceCity, birthPlaceCityFree, nationality, homePhone, mobilePhone1, mobilePhone2, email, webpage, contactType, cigaretteUseType, otherClubs, otherUniversityClubs, educationState, masterStartDate, masterEndDate, masterUniversity, masterUniversityFree, masterInstitute, masterDepartment, masterDepartmentFree, masterGradeSystem, masterGraduationGrade, licenseStartDate, licenseEndDate, licenseUniversity, licenseUniversityFree, licenseInstitute, licenseDepartment, licenseDepartmentFree, licenseEducationType, licenseGradeSystem, licenseGraduationGrade, highSchool, highSchoolEndDate, highSchoolGradeSystem, highSchoolGraduationGrade, computerInfo, hasDrivingLicense, interestedAdvertisementType, totalWorkExperienceInMonth, workingStatus, cVState, isDefault, modifyDate, createDate)
    ;
            }

            public static int UpdateByParams(params SqlParameter[] sqlParams)
            {
                return CVsProvider.Generated.UpdateByParams(sqlParams);
            }

            public static int UpdateByParams(SqlTransaction tran, int id, int? userId, string name, int? cvLanguage, int? maritalStatus, int? birthPlaceCountry, int? birthPlaceCity, string birthPlaceCityFree, int? nationality, string homePhone, string mobilePhone1, string mobilePhone2, string email, string webpage, int? contactType, int? cigaretteUseType, string otherClubs, string otherUniversityClubs, int? educationState, DateTime? masterStartDate, DateTime? masterEndDate, int? masterUniversity, string masterUniversityFree, int? masterInstitute, int? masterDepartment, string masterDepartmentFree, int? masterGradeSystem, decimal? masterGraduationGrade, DateTime? licenseStartDate, DateTime? licenseEndDate, int? licenseUniversity, string licenseUniversityFree, int? licenseInstitute, int? licenseDepartment, string licenseDepartmentFree, int? licenseEducationType, int? licenseGradeSystem, decimal? licenseGraduationGrade, string highSchool, DateTime? highSchoolEndDate, int? highSchoolGradeSystem, decimal? highSchoolGraduationGrade, string computerInfo, bool? hasDrivingLicense, int? interestedAdvertisementType, int? totalWorkExperienceInMonth, int? workingStatus, int? cVState, bool? isDefault, DateTime? modifyDate, DateTime? createDate)
            {
                return CVsProvider.Generated.UpdateByParams(tran, id, userId, name, cvLanguage, maritalStatus, birthPlaceCountry, birthPlaceCity, birthPlaceCityFree, nationality, homePhone, mobilePhone1, mobilePhone2, email, webpage, contactType, cigaretteUseType, otherClubs, otherUniversityClubs, educationState, masterStartDate, masterEndDate, masterUniversity, masterUniversityFree, masterInstitute, masterDepartment, masterDepartmentFree, masterGradeSystem, masterGraduationGrade, licenseStartDate, licenseEndDate, licenseUniversity, licenseUniversityFree, licenseInstitute, licenseDepartment, licenseDepartmentFree, licenseEducationType, licenseGradeSystem, licenseGraduationGrade, highSchool, highSchoolEndDate, highSchoolGradeSystem, highSchoolGraduationGrade, computerInfo, hasDrivingLicense, interestedAdvertisementType, totalWorkExperienceInMonth, workingStatus, cVState, isDefault, modifyDate, createDate)
    ;
            }

            public static int UpdateByParams(SqlTransaction tran, params SqlParameter[] sqlParams)
            {
                return CVsProvider.Generated.UpdateByParams(tran, sqlParams);
            }
            #endregion

            #region Add Functions
            public static int Add(int userId, string name, int cvLanguage, int maritalStatus, int birthPlaceCountry, int birthPlaceCity, string birthPlaceCityFree, int nationality, string homePhone, string mobilePhone1, string mobilePhone2, string email, string webpage, int? contactType, int? cigaretteUseType, string otherClubs, string otherUniversityClubs, int educationState, DateTime? masterStartDate, DateTime? masterEndDate, int? masterUniversity, string masterUniversityFree, int? masterInstitute, int? masterDepartment, string masterDepartmentFree, int? masterGradeSystem, decimal? masterGraduationGrade, DateTime? licenseStartDate, DateTime? licenseEndDate, int? licenseUniversity, string licenseUniversityFree, int? licenseInstitute, int? licenseDepartment, string licenseDepartmentFree, int? licenseEducationType, int? licenseGradeSystem, decimal? licenseGraduationGrade, string highSchool, DateTime? highSchoolEndDate, int? highSchoolGradeSystem, decimal? highSchoolGraduationGrade, string computerInfo, bool? hasDrivingLicense, int? interestedAdvertisementType, int? totalWorkExperienceInMonth, int? workingStatus, int cVState, bool isDefault, DateTime modifyDate, DateTime createDate)
            {
                return CVsProvider.Generated.Add(userId, name, cvLanguage, maritalStatus, birthPlaceCountry, birthPlaceCity, birthPlaceCityFree, nationality, homePhone, mobilePhone1, mobilePhone2, email, webpage, contactType, cigaretteUseType, otherClubs, otherUniversityClubs, educationState, masterStartDate, masterEndDate, masterUniversity, masterUniversityFree, masterInstitute, masterDepartment, masterDepartmentFree, masterGradeSystem, masterGraduationGrade, licenseStartDate, licenseEndDate, licenseUniversity, licenseUniversityFree, licenseInstitute, licenseDepartment, licenseDepartmentFree, licenseEducationType, licenseGradeSystem, licenseGraduationGrade, highSchool, highSchoolEndDate, highSchoolGradeSystem, highSchoolGraduationGrade, computerInfo, hasDrivingLicense, interestedAdvertisementType, totalWorkExperienceInMonth, workingStatus, cVState, isDefault, modifyDate, createDate)
    ;
            }

            public static int Add(SqlTransaction tran, int userId, string name, int cvLanguage, int maritalStatus, int birthPlaceCountry, int birthPlaceCity, string birthPlaceCityFree, int nationality, string homePhone, string mobilePhone1, string mobilePhone2, string email, string webpage, int? contactType, int? cigaretteUseType, string otherClubs, string otherUniversityClubs, int educationState, DateTime? masterStartDate, DateTime? masterEndDate, int? masterUniversity, string masterUniversityFree, int? masterInstitute, int? masterDepartment, string masterDepartmentFree, int? masterGradeSystem, decimal? masterGraduationGrade, DateTime? licenseStartDate, DateTime? licenseEndDate, int? licenseUniversity, string licenseUniversityFree, int? licenseInstitute, int? licenseDepartment, string licenseDepartmentFree, int? licenseEducationType, int? licenseGradeSystem, decimal? licenseGraduationGrade, string highSchool, DateTime? highSchoolEndDate, int? highSchoolGradeSystem, decimal? highSchoolGraduationGrade, string computerInfo, bool? hasDrivingLicense, int? interestedAdvertisementType, int? totalWorkExperienceInMonth, int? workingStatus, int cVState, bool isDefault, DateTime modifyDate, DateTime createDate)
            {
                return CVsProvider.Generated.Add(tran, userId, name, cvLanguage, maritalStatus, birthPlaceCountry, birthPlaceCity, birthPlaceCityFree, nationality, homePhone, mobilePhone1, mobilePhone2, email, webpage, contactType, cigaretteUseType, otherClubs, otherUniversityClubs, educationState, masterStartDate, masterEndDate, masterUniversity, masterUniversityFree, masterInstitute, masterDepartment, masterDepartmentFree, masterGradeSystem, masterGraduationGrade, licenseStartDate, licenseEndDate, licenseUniversity, licenseUniversityFree, licenseInstitute, licenseDepartment, licenseDepartmentFree, licenseEducationType, licenseGradeSystem, licenseGraduationGrade, highSchool, highSchoolEndDate, highSchoolGradeSystem, highSchoolGraduationGrade, computerInfo, hasDrivingLicense, interestedAdvertisementType, totalWorkExperienceInMonth, workingStatus, cVState, isDefault, modifyDate, createDate)
    ;
            }
            #endregion

            #region Delete Functions
            public static int DeleteByParams(int? id, int? userId, string name, int? cvLanguage, int? maritalStatus, int? birthPlaceCountry, int? birthPlaceCity, string birthPlaceCityFree, int? nationality, string homePhone, string mobilePhone1, string mobilePhone2, string email, string webpage, int? contactType, int? cigaretteUseType, string otherClubs, string otherUniversityClubs, int? educationState, DateTime? masterStartDate, DateTime? beforeMasterStartDate, DateTime? afterOrEqualMasterStartDate, DateTime? masterEndDate, DateTime? beforeMasterEndDate, DateTime? afterOrEqualMasterEndDate, int? masterUniversity, string masterUniversityFree, int? masterInstitute, int? masterDepartment, string masterDepartmentFree, int? masterGradeSystem, decimal? masterGraduationGrade, DateTime? licenseStartDate, DateTime? beforeLicenseStartDate, DateTime? afterOrEqualLicenseStartDate, DateTime? licenseEndDate, DateTime? beforeLicenseEndDate, DateTime? afterOrEqualLicenseEndDate, int? licenseUniversity, string licenseUniversityFree, int? licenseInstitute, int? licenseDepartment, string licenseDepartmentFree, int? licenseEducationType, int? licenseGradeSystem, decimal? licenseGraduationGrade, string highSchool, DateTime? highSchoolEndDate, DateTime? beforeHighSchoolEndDate, DateTime? afterOrEqualHighSchoolEndDate, int? highSchoolGradeSystem, decimal? highSchoolGraduationGrade, string computerInfo, bool? hasDrivingLicense, int? interestedAdvertisementType, int? totalWorkExperienceInMonth, int? workingStatus, int? cVState, bool? isDefault, DateTime? modifyDate, DateTime? beforeModifyDate, DateTime? afterOrEqualModifyDate, DateTime? createDate, DateTime? beforeCreateDate, DateTime? afterOrEqualCreateDate)
            {
                return CVsProvider.Generated.DeleteByParams(null, id, userId, name, cvLanguage, maritalStatus, birthPlaceCountry, birthPlaceCity, birthPlaceCityFree, nationality, homePhone, mobilePhone1, mobilePhone2, email, webpage, contactType, cigaretteUseType, otherClubs, otherUniversityClubs, educationState, masterStartDate, beforeMasterStartDate, afterOrEqualMasterStartDate, masterEndDate, beforeMasterEndDate, afterOrEqualMasterEndDate, masterUniversity, masterUniversityFree, masterInstitute, masterDepartment, masterDepartmentFree, masterGradeSystem, masterGraduationGrade, licenseStartDate, beforeLicenseStartDate, afterOrEqualLicenseStartDate, licenseEndDate, beforeLicenseEndDate, afterOrEqualLicenseEndDate, licenseUniversity, licenseUniversityFree, licenseInstitute, licenseDepartment, licenseDepartmentFree, licenseEducationType, licenseGradeSystem, licenseGraduationGrade, highSchool, highSchoolEndDate, beforeHighSchoolEndDate, afterOrEqualHighSchoolEndDate, highSchoolGradeSystem, highSchoolGraduationGrade, computerInfo, hasDrivingLicense, interestedAdvertisementType, totalWorkExperienceInMonth, workingStatus, cVState, isDefault, modifyDate, beforeModifyDate, afterOrEqualModifyDate, createDate, beforeCreateDate, afterOrEqualCreateDate)
    ;
            }

            public static int DeleteByParams(SqlTransaction tran, int? id, int? userId, string name, int? cvLanguage, int? maritalStatus, int? birthPlaceCountry, int? birthPlaceCity, string birthPlaceCityFree, int? nationality, string homePhone, string mobilePhone1, string mobilePhone2, string email, string webpage, int? contactType, int? cigaretteUseType, string otherClubs, string otherUniversityClubs, int? educationState, DateTime? masterStartDate, DateTime? beforeMasterStartDate, DateTime? afterOrEqualMasterStartDate, DateTime? masterEndDate, DateTime? beforeMasterEndDate, DateTime? afterOrEqualMasterEndDate, int? masterUniversity, string masterUniversityFree, int? masterInstitute, int? masterDepartment, string masterDepartmentFree, int? masterGradeSystem, decimal? masterGraduationGrade, DateTime? licenseStartDate, DateTime? beforeLicenseStartDate, DateTime? afterOrEqualLicenseStartDate, DateTime? licenseEndDate, DateTime? beforeLicenseEndDate, DateTime? afterOrEqualLicenseEndDate, int? licenseUniversity, string licenseUniversityFree, int? licenseInstitute, int? licenseDepartment, string licenseDepartmentFree, int? licenseEducationType, int? licenseGradeSystem, decimal? licenseGraduationGrade, string highSchool, DateTime? highSchoolEndDate, DateTime? beforeHighSchoolEndDate, DateTime? afterOrEqualHighSchoolEndDate, int? highSchoolGradeSystem, decimal? highSchoolGraduationGrade, string computerInfo, bool? hasDrivingLicense, int? interestedAdvertisementType, int? totalWorkExperienceInMonth, int? workingStatus, int? cVState, bool? isDefault, DateTime? modifyDate, DateTime? beforeModifyDate, DateTime? afterOrEqualModifyDate, DateTime? createDate, DateTime? beforeCreateDate, DateTime? afterOrEqualCreateDate)
            {
                return CVsProvider.Generated.DeleteByParams(tran, id, userId, name, cvLanguage, maritalStatus, birthPlaceCountry, birthPlaceCity, birthPlaceCityFree, nationality, homePhone, mobilePhone1, mobilePhone2, email, webpage, contactType, cigaretteUseType, otherClubs, otherUniversityClubs, educationState, masterStartDate, beforeMasterStartDate, afterOrEqualMasterStartDate, masterEndDate, beforeMasterEndDate, afterOrEqualMasterEndDate, masterUniversity, masterUniversityFree, masterInstitute, masterDepartment, masterDepartmentFree, masterGradeSystem, masterGraduationGrade, licenseStartDate, beforeLicenseStartDate, afterOrEqualLicenseStartDate, licenseEndDate, beforeLicenseEndDate, afterOrEqualLicenseEndDate, licenseUniversity, licenseUniversityFree, licenseInstitute, licenseDepartment, licenseDepartmentFree, licenseEducationType, licenseGradeSystem, licenseGraduationGrade, highSchool, highSchoolEndDate, beforeHighSchoolEndDate, afterOrEqualHighSchoolEndDate, highSchoolGradeSystem, highSchoolGraduationGrade, computerInfo, hasDrivingLicense, interestedAdvertisementType, totalWorkExperienceInMonth, workingStatus, cVState, isDefault, modifyDate, beforeModifyDate, afterOrEqualModifyDate, createDate, beforeCreateDate, afterOrEqualCreateDate)
    ;
            }

            public static int Delete(int id)
            {
                return CVsProvider.Generated.Delete(id)
    ;
            }

            public static int Delete(SqlTransaction tran, int id)
            {
                return CVsProvider.Generated.Delete(tran, id)
    ;
            }

            public static int DeleteByFK(int? userId)
            {
                return CVsProvider.Generated.DeleteByFK(userId)
    ;
            }

            public static int DeleteByFK(SqlTransaction tran, int? userId)
            {
                return CVsProvider.Generated.DeleteByFK(userId)
    ;
            }


            #endregion

        }
    }
}
