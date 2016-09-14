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

    public partial class CVsProvider : BaseDataLayer
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
                        ds = ExecuteDataset("BGA_GetCVs", sqlParams);
                    else
                        ds = ExecuteDataset(tran, "BGA_GetCVs", sqlParams);

                    return ds;
                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "CVsProvider", "Get", ArrangeParamValues(sqlParams));
                }
            }

            public static DataSet GetByParams(int? id, int? userId, string name, int? cvLanguage, int? maritalStatus, int? birthPlaceCountry, int? birthPlaceCity, string birthPlaceCityFree, int? nationality, string homePhone, string mobilePhone1, string mobilePhone2, string email, string webpage, int? contactType, int? cigaretteUseType, string otherClubs, string otherUniversityClubs, int? educationState, DateTime? masterStartDate, DateTime? beforeMasterStartDate, DateTime? afterOrEqualMasterStartDate, DateTime? masterEndDate, DateTime? beforeMasterEndDate, DateTime? afterOrEqualMasterEndDate, int? masterUniversity, string masterUniversityFree, int? masterInstitute, int? masterDepartment, string masterDepartmentFree, int? masterGradeSystem, decimal? masterGraduationGrade, DateTime? licenseStartDate, DateTime? beforeLicenseStartDate, DateTime? afterOrEqualLicenseStartDate, DateTime? licenseEndDate, DateTime? beforeLicenseEndDate, DateTime? afterOrEqualLicenseEndDate, int? licenseUniversity, string licenseUniversityFree, int? licenseInstitute, int? licenseDepartment, string licenseDepartmentFree, int? licenseEducationType, int? licenseGradeSystem, decimal? licenseGraduationGrade, string highSchool, DateTime? highSchoolEndDate, DateTime? beforeHighSchoolEndDate, DateTime? afterOrEqualHighSchoolEndDate, int? highSchoolGradeSystem, decimal? highSchoolGraduationGrade, string computerInfo, bool? hasDrivingLicense, int? interestedAdvertisementType, int? totalWorkExperienceInMonth, int? workingStatus, int? cVState, bool? isDefault, DateTime? modifyDate, DateTime? beforeModifyDate, DateTime? afterOrEqualModifyDate, DateTime? createDate, DateTime? beforeCreateDate, DateTime? afterOrEqualCreateDate)
            {
                return GetByParams(null, id, userId, name, cvLanguage, maritalStatus, birthPlaceCountry, birthPlaceCity, birthPlaceCityFree, nationality, homePhone, mobilePhone1, mobilePhone2, email, webpage, contactType, cigaretteUseType, otherClubs, otherUniversityClubs, educationState, masterStartDate, beforeMasterStartDate, afterOrEqualMasterStartDate, masterEndDate, beforeMasterEndDate, afterOrEqualMasterEndDate, masterUniversity, masterUniversityFree, masterInstitute, masterDepartment, masterDepartmentFree, masterGradeSystem, masterGraduationGrade, licenseStartDate, beforeLicenseStartDate, afterOrEqualLicenseStartDate, licenseEndDate, beforeLicenseEndDate, afterOrEqualLicenseEndDate, licenseUniversity, licenseUniversityFree, licenseInstitute, licenseDepartment, licenseDepartmentFree, licenseEducationType, licenseGradeSystem, licenseGraduationGrade, highSchool, highSchoolEndDate, beforeHighSchoolEndDate, afterOrEqualHighSchoolEndDate, highSchoolGradeSystem, highSchoolGraduationGrade, computerInfo, hasDrivingLicense, interestedAdvertisementType, totalWorkExperienceInMonth, workingStatus, cVState, isDefault, modifyDate, beforeModifyDate, afterOrEqualModifyDate, createDate, beforeCreateDate, afterOrEqualCreateDate)
    ;
            }

            public static DataSet GetByParams(SqlTransaction tran, int? id, int? userId, string name, int? cvLanguage, int? maritalStatus, int? birthPlaceCountry, int? birthPlaceCity, string birthPlaceCityFree, int? nationality, string homePhone, string mobilePhone1, string mobilePhone2, string email, string webpage, int? contactType, int? cigaretteUseType, string otherClubs, string otherUniversityClubs, int? educationState, DateTime? masterStartDate, DateTime? beforeMasterStartDate, DateTime? afterOrEqualMasterStartDate, DateTime? masterEndDate, DateTime? beforeMasterEndDate, DateTime? afterOrEqualMasterEndDate, int? masterUniversity, string masterUniversityFree, int? masterInstitute, int? masterDepartment, string masterDepartmentFree, int? masterGradeSystem, decimal? masterGraduationGrade, DateTime? licenseStartDate, DateTime? beforeLicenseStartDate, DateTime? afterOrEqualLicenseStartDate, DateTime? licenseEndDate, DateTime? beforeLicenseEndDate, DateTime? afterOrEqualLicenseEndDate, int? licenseUniversity, string licenseUniversityFree, int? licenseInstitute, int? licenseDepartment, string licenseDepartmentFree, int? licenseEducationType, int? licenseGradeSystem, decimal? licenseGraduationGrade, string highSchool, DateTime? highSchoolEndDate, DateTime? beforeHighSchoolEndDate, DateTime? afterOrEqualHighSchoolEndDate, int? highSchoolGradeSystem, decimal? highSchoolGraduationGrade, string computerInfo, bool? hasDrivingLicense, int? interestedAdvertisementType, int? totalWorkExperienceInMonth, int? workingStatus, int? cVState, bool? isDefault, DateTime? modifyDate, DateTime? beforeModifyDate, DateTime? afterOrEqualModifyDate, DateTime? createDate, DateTime? beforeCreateDate, DateTime? afterOrEqualCreateDate)
            {
                SqlParameter[] sqlParams = null;

                try
                {
                    DataSet ds = null;

                    sqlParams = new SqlParameter[] { 
					new SqlParameter("@ID",id),
					new SqlParameter("@UserId",userId),
					new SqlParameter("@Name",name),
					new SqlParameter("@CvLanguage",cvLanguage),
					new SqlParameter("@MaritalStatus",maritalStatus),
					new SqlParameter("@BirthPlaceCountry",birthPlaceCountry),
					new SqlParameter("@BirthPlaceCity",birthPlaceCity),
					new SqlParameter("@BirthPlaceCityFree",birthPlaceCityFree),
					new SqlParameter("@Nationality",nationality),
					new SqlParameter("@HomePhone",homePhone),
					new SqlParameter("@MobilePhone1",mobilePhone1),
					new SqlParameter("@MobilePhone2",mobilePhone2),
					new SqlParameter("@Email",email),
					new SqlParameter("@Webpage",webpage),
					new SqlParameter("@ContactType",contactType),
					new SqlParameter("@CigaretteUseType",cigaretteUseType),
					new SqlParameter("@OtherClubs",otherClubs),
					new SqlParameter("@OtherUniversityClubs",otherUniversityClubs),
					new SqlParameter("@EducationState",educationState),
					new SqlParameter("@MasterStartDate",masterStartDate),
					new SqlParameter("@BeforeMasterStartDate",beforeMasterStartDate),
					new SqlParameter("@AfterOrEqualMasterStartDate",afterOrEqualMasterStartDate),
					new SqlParameter("@MasterEndDate",masterEndDate),
					new SqlParameter("@BeforeMasterEndDate",beforeMasterEndDate),
					new SqlParameter("@AfterOrEqualMasterEndDate",afterOrEqualMasterEndDate),
					new SqlParameter("@MasterUniversity",masterUniversity),
					new SqlParameter("@MasterUniversityFree",masterUniversityFree),
					new SqlParameter("@MasterInstitute",masterInstitute),
					new SqlParameter("@MasterDepartment",masterDepartment),
					new SqlParameter("@MasterDepartmentFree",masterDepartmentFree),
					new SqlParameter("@MasterGradeSystem",masterGradeSystem),
					new SqlParameter("@MasterGraduationGrade",masterGraduationGrade),
					new SqlParameter("@LicenseStartDate",licenseStartDate),
					new SqlParameter("@BeforeLicenseStartDate",beforeLicenseStartDate),
					new SqlParameter("@AfterOrEqualLicenseStartDate",afterOrEqualLicenseStartDate),
					new SqlParameter("@LicenseEndDate",licenseEndDate),
					new SqlParameter("@BeforeLicenseEndDate",beforeLicenseEndDate),
					new SqlParameter("@AfterOrEqualLicenseEndDate",afterOrEqualLicenseEndDate),
					new SqlParameter("@LicenseUniversity",licenseUniversity),
					new SqlParameter("@LicenseUniversityFree",licenseUniversityFree),
					new SqlParameter("@LicenseInstitute",licenseInstitute),
					new SqlParameter("@LicenseDepartment",licenseDepartment),
					new SqlParameter("@LicenseDepartmentFree",licenseDepartmentFree),
					new SqlParameter("@LicenseEducationType",licenseEducationType),
					new SqlParameter("@LicenseGradeSystem",licenseGradeSystem),
					new SqlParameter("@LicenseGraduationGrade",licenseGraduationGrade),
					new SqlParameter("@HighSchool",highSchool),
					new SqlParameter("@HighSchoolEndDate",highSchoolEndDate),
					new SqlParameter("@BeforeHighSchoolEndDate",beforeHighSchoolEndDate),
					new SqlParameter("@AfterOrEqualHighSchoolEndDate",afterOrEqualHighSchoolEndDate),
					new SqlParameter("@HighSchoolGradeSystem",highSchoolGradeSystem),
					new SqlParameter("@HighSchoolGraduationGrade",highSchoolGraduationGrade),
					new SqlParameter("@ComputerInfo",computerInfo),
					new SqlParameter("@HasDrivingLicense",hasDrivingLicense),
					new SqlParameter("@InterestedAdvertisementType",interestedAdvertisementType),
					new SqlParameter("@TotalWorkExperienceInMonth",totalWorkExperienceInMonth),
					new SqlParameter("@WorkingStatus",workingStatus),
					new SqlParameter("@CVState",cVState),
					new SqlParameter("@IsDefault",isDefault),
					new SqlParameter("@ModifyDate",modifyDate),
					new SqlParameter("@BeforeModifyDate",beforeModifyDate),
					new SqlParameter("@AfterOrEqualModifyDate",afterOrEqualModifyDate),
					new SqlParameter("@CreateDate",createDate),
					new SqlParameter("@BeforeCreateDate",beforeCreateDate),
					new SqlParameter("@AfterOrEqualCreateDate",afterOrEqualCreateDate)
                };

                    if (tran == null)
                        ds = ExecuteDataset("BGA_GetCVsByParams", sqlParams);
                    else
                        ds = ExecuteDataset(tran, "BGA_GetCVsByParams", sqlParams);

                    return ds;
                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "CVsProvider", "GetByParams", ArrangeParamValues(sqlParams));
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

                    ds = ExecuteDataset("BGA_GetCVsByParams", sqlParams);

                    return ds;
                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "CVsProvider", "GetByParams", ArrangeParamValues(sqlParams));
                }
            }

            public static DataSet GetByFKBasic(int? userId)
            {
                return GetByFKBasic(null, userId);
            }

            public static DataSet GetByFKBasic(SqlTransaction tran, int? userId)
            {
                SqlParameter[] sqlParams = null;

                try
                {
                    DataSet ds = null;

                    sqlParams = new SqlParameter[] { 
					new SqlParameter("@UserId",userId)
                };

                    if (tran == null)
                        ds = ExecuteDataset("BGA_GetCVsByFK", sqlParams);
                    else
                        ds = ExecuteDataset(tran, "BGA_GetCVsByFK", sqlParams);

                    return ds;
                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "CVsProvider", "GetByFK", ArrangeParamValues(sqlParams));
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

            public static DataSet GetByFK(SqlTransaction tran, int userId)
            {
                return GetByFKBasic(tran, userId);
            }

            public static DataSet GetByFK(int userId)
            {
                return GetByFKBasic(userId);
            }


            #endregion

            #region Update Functions
            public static int Update(int id, int userId, string name, int cvLanguage, int maritalStatus, int birthPlaceCountry, int birthPlaceCity, string birthPlaceCityFree, int nationality, string homePhone, string mobilePhone1, string mobilePhone2, string email, string webpage, int? contactType, int? cigaretteUseType, string otherClubs, string otherUniversityClubs, int educationState, DateTime? masterStartDate, DateTime? masterEndDate, int? masterUniversity, string masterUniversityFree, int? masterInstitute, int? masterDepartment, string masterDepartmentFree, int? masterGradeSystem, decimal? masterGraduationGrade, DateTime? licenseStartDate, DateTime? licenseEndDate, int? licenseUniversity, string licenseUniversityFree, int? licenseInstitute, int? licenseDepartment, string licenseDepartmentFree, int? licenseEducationType, int? licenseGradeSystem, decimal? licenseGraduationGrade, string highSchool, DateTime? highSchoolEndDate, int? highSchoolGradeSystem, decimal? highSchoolGraduationGrade, string computerInfo, bool? hasDrivingLicense, int? interestedAdvertisementType, int? totalWorkExperienceInMonth, int? workingStatus, int cVState, bool isDefault, DateTime modifyDate)
            {
                SqlParameter[] sqlParams = null;

                try
                {
                    sqlParams = new SqlParameter[] { 
					new SqlParameter("@ID",id),
					new SqlParameter("@UserId",userId),
					new SqlParameter("@Name",name),
					new SqlParameter("@CvLanguage",cvLanguage),
					new SqlParameter("@MaritalStatus",maritalStatus),
					new SqlParameter("@BirthPlaceCountry",birthPlaceCountry),
					new SqlParameter("@BirthPlaceCity",birthPlaceCity),
					new SqlParameter("@BirthPlaceCityFree",birthPlaceCityFree),
					new SqlParameter("@Nationality",nationality),
					new SqlParameter("@HomePhone",homePhone),
					new SqlParameter("@MobilePhone1",mobilePhone1),
					new SqlParameter("@MobilePhone2",mobilePhone2),
					new SqlParameter("@Email",email),
					new SqlParameter("@Webpage",webpage),
					new SqlParameter("@ContactType",contactType),
					new SqlParameter("@CigaretteUseType",cigaretteUseType),
					new SqlParameter("@OtherClubs",otherClubs),
					new SqlParameter("@OtherUniversityClubs",otherUniversityClubs),
					new SqlParameter("@EducationState",educationState),
					new SqlParameter("@MasterStartDate",masterStartDate),
					new SqlParameter("@MasterEndDate",masterEndDate),
					new SqlParameter("@MasterUniversity",masterUniversity),
					new SqlParameter("@MasterUniversityFree",masterUniversityFree),
					new SqlParameter("@MasterInstitute",masterInstitute),
					new SqlParameter("@MasterDepartment",masterDepartment),
					new SqlParameter("@MasterDepartmentFree",masterDepartmentFree),
					new SqlParameter("@MasterGradeSystem",masterGradeSystem),
					new SqlParameter("@MasterGraduationGrade",masterGraduationGrade),
					new SqlParameter("@LicenseStartDate",licenseStartDate),
					new SqlParameter("@LicenseEndDate",licenseEndDate),
					new SqlParameter("@LicenseUniversity",licenseUniversity),
					new SqlParameter("@LicenseUniversityFree",licenseUniversityFree),
					new SqlParameter("@LicenseInstitute",licenseInstitute),
					new SqlParameter("@LicenseDepartment",licenseDepartment),
					new SqlParameter("@LicenseDepartmentFree",licenseDepartmentFree),
					new SqlParameter("@LicenseEducationType",licenseEducationType),
					new SqlParameter("@LicenseGradeSystem",licenseGradeSystem),
					new SqlParameter("@LicenseGraduationGrade",licenseGraduationGrade),
					new SqlParameter("@HighSchool",highSchool),
					new SqlParameter("@HighSchoolEndDate",highSchoolEndDate),
					new SqlParameter("@HighSchoolGradeSystem",highSchoolGradeSystem),
					new SqlParameter("@HighSchoolGraduationGrade",highSchoolGraduationGrade),
					new SqlParameter("@ComputerInfo",computerInfo),
					new SqlParameter("@HasDrivingLicense",hasDrivingLicense),
					new SqlParameter("@InterestedAdvertisementType",interestedAdvertisementType),
					new SqlParameter("@TotalWorkExperienceInMonth",totalWorkExperienceInMonth),
					new SqlParameter("@WorkingStatus",workingStatus),
					new SqlParameter("@CVState",cVState),
					new SqlParameter("@IsDefault",isDefault),
					new SqlParameter("@ModifyDate",modifyDate)
                };

                    return ExecuteNonQuery("BGA_UpdateCVs", sqlParams);

                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "CVsProvider", "Update", ArrangeParamValues(sqlParams));
                }
            }

            public static int Update(SqlTransaction tran, int id, int userId, string name, int cvLanguage, int maritalStatus, int birthPlaceCountry, int birthPlaceCity, string birthPlaceCityFree, int nationality, string homePhone, string mobilePhone1, string mobilePhone2, string email, string webpage, int? contactType, int? cigaretteUseType, string otherClubs, string otherUniversityClubs, int educationState, DateTime? masterStartDate, DateTime? masterEndDate, int? masterUniversity, string masterUniversityFree, int? masterInstitute, int? masterDepartment, string masterDepartmentFree, int? masterGradeSystem, decimal? masterGraduationGrade, DateTime? licenseStartDate, DateTime? licenseEndDate, int? licenseUniversity, string licenseUniversityFree, int? licenseInstitute, int? licenseDepartment, string licenseDepartmentFree, int? licenseEducationType, int? licenseGradeSystem, decimal? licenseGraduationGrade, string highSchool, DateTime? highSchoolEndDate, int? highSchoolGradeSystem, decimal? highSchoolGraduationGrade, string computerInfo, bool? hasDrivingLicense, int? interestedAdvertisementType, int? totalWorkExperienceInMonth, int? workingStatus, int cVState, bool isDefault, DateTime modifyDate)
            {
                SqlParameter[] sqlParams = null;

                try
                {
                    sqlParams = new SqlParameter[] { 
					new SqlParameter("@ID",id),
					new SqlParameter("@UserId",userId),
					new SqlParameter("@Name",name),
					new SqlParameter("@CvLanguage",cvLanguage),
					new SqlParameter("@MaritalStatus",maritalStatus),
					new SqlParameter("@BirthPlaceCountry",birthPlaceCountry),
					new SqlParameter("@BirthPlaceCity",birthPlaceCity),
					new SqlParameter("@BirthPlaceCityFree",birthPlaceCityFree),
					new SqlParameter("@Nationality",nationality),
					new SqlParameter("@HomePhone",homePhone),
					new SqlParameter("@MobilePhone1",mobilePhone1),
					new SqlParameter("@MobilePhone2",mobilePhone2),
					new SqlParameter("@Email",email),
					new SqlParameter("@Webpage",webpage),
					new SqlParameter("@ContactType",contactType),
					new SqlParameter("@CigaretteUseType",cigaretteUseType),
					new SqlParameter("@OtherClubs",otherClubs),
					new SqlParameter("@OtherUniversityClubs",otherUniversityClubs),
					new SqlParameter("@EducationState",educationState),
					new SqlParameter("@MasterStartDate",masterStartDate),
					new SqlParameter("@MasterEndDate",masterEndDate),
					new SqlParameter("@MasterUniversity",masterUniversity),
					new SqlParameter("@MasterUniversityFree",masterUniversityFree),
					new SqlParameter("@MasterInstitute",masterInstitute),
					new SqlParameter("@MasterDepartment",masterDepartment),
					new SqlParameter("@MasterDepartmentFree",masterDepartmentFree),
					new SqlParameter("@MasterGradeSystem",masterGradeSystem),
					new SqlParameter("@MasterGraduationGrade",masterGraduationGrade),
					new SqlParameter("@LicenseStartDate",licenseStartDate),
					new SqlParameter("@LicenseEndDate",licenseEndDate),
					new SqlParameter("@LicenseUniversity",licenseUniversity),
					new SqlParameter("@LicenseUniversityFree",licenseUniversityFree),
					new SqlParameter("@LicenseInstitute",licenseInstitute),
					new SqlParameter("@LicenseDepartment",licenseDepartment),
					new SqlParameter("@LicenseDepartmentFree",licenseDepartmentFree),
					new SqlParameter("@LicenseEducationType",licenseEducationType),
					new SqlParameter("@LicenseGradeSystem",licenseGradeSystem),
					new SqlParameter("@LicenseGraduationGrade",licenseGraduationGrade),
					new SqlParameter("@HighSchool",highSchool),
					new SqlParameter("@HighSchoolEndDate",highSchoolEndDate),
					new SqlParameter("@HighSchoolGradeSystem",highSchoolGradeSystem),
					new SqlParameter("@HighSchoolGraduationGrade",highSchoolGraduationGrade),
					new SqlParameter("@ComputerInfo",computerInfo),
					new SqlParameter("@HasDrivingLicense",hasDrivingLicense),
					new SqlParameter("@InterestedAdvertisementType",interestedAdvertisementType),
					new SqlParameter("@TotalWorkExperienceInMonth",totalWorkExperienceInMonth),
					new SqlParameter("@WorkingStatus",workingStatus),
					new SqlParameter("@CVState",cVState),
					new SqlParameter("@IsDefault",isDefault),
					new SqlParameter("@ModifyDate",modifyDate)
                };

                    return ExecuteNonQuery(tran, "BGA_UpdateCVs", sqlParams);

                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "CVsProvider", "Update", ArrangeParamValues(sqlParams));
                }
            }

            public static int UpdateByParams(int id, int? userId, string name, int? cvLanguage, int? maritalStatus, int? birthPlaceCountry, int? birthPlaceCity, string birthPlaceCityFree, int? nationality, string homePhone, string mobilePhone1, string mobilePhone2, string email, string webpage, int? contactType, int? cigaretteUseType, string otherClubs, string otherUniversityClubs, int? educationState, DateTime? masterStartDate, DateTime? masterEndDate, int? masterUniversity, string masterUniversityFree, int? masterInstitute, int? masterDepartment, string masterDepartmentFree, int? masterGradeSystem, decimal? masterGraduationGrade, DateTime? licenseStartDate, DateTime? licenseEndDate, int? licenseUniversity, string licenseUniversityFree, int? licenseInstitute, int? licenseDepartment, string licenseDepartmentFree, int? licenseEducationType, int? licenseGradeSystem, decimal? licenseGraduationGrade, string highSchool, DateTime? highSchoolEndDate, int? highSchoolGradeSystem, decimal? highSchoolGraduationGrade, string computerInfo, bool? hasDrivingLicense, int? interestedAdvertisementType, int? totalWorkExperienceInMonth, int? workingStatus, int? cVState, bool? isDefault, DateTime? modifyDate, DateTime? createDate)
            {
                SqlParameter[] sqlParams = null;

                try
                {
                    sqlParams = new SqlParameter[] { 
					new SqlParameter("@ID",id),
					new SqlParameter("@UserId",userId),
					new SqlParameter("@Name",name),
					new SqlParameter("@CvLanguage",cvLanguage),
					new SqlParameter("@MaritalStatus",maritalStatus),
					new SqlParameter("@BirthPlaceCountry",birthPlaceCountry),
					new SqlParameter("@BirthPlaceCity",birthPlaceCity),
					new SqlParameter("@BirthPlaceCityFree",birthPlaceCityFree),
					new SqlParameter("@Nationality",nationality),
					new SqlParameter("@HomePhone",homePhone),
					new SqlParameter("@MobilePhone1",mobilePhone1),
					new SqlParameter("@MobilePhone2",mobilePhone2),
					new SqlParameter("@Email",email),
					new SqlParameter("@Webpage",webpage),
					new SqlParameter("@ContactType",contactType),
					new SqlParameter("@CigaretteUseType",cigaretteUseType),
					new SqlParameter("@OtherClubs",otherClubs),
					new SqlParameter("@OtherUniversityClubs",otherUniversityClubs),
					new SqlParameter("@EducationState",educationState),
					new SqlParameter("@MasterStartDate",masterStartDate),
					new SqlParameter("@MasterEndDate",masterEndDate),
					new SqlParameter("@MasterUniversity",masterUniversity),
					new SqlParameter("@MasterUniversityFree",masterUniversityFree),
					new SqlParameter("@MasterInstitute",masterInstitute),
					new SqlParameter("@MasterDepartment",masterDepartment),
					new SqlParameter("@MasterDepartmentFree",masterDepartmentFree),
					new SqlParameter("@MasterGradeSystem",masterGradeSystem),
					new SqlParameter("@MasterGraduationGrade",masterGraduationGrade),
					new SqlParameter("@LicenseStartDate",licenseStartDate),
					new SqlParameter("@LicenseEndDate",licenseEndDate),
					new SqlParameter("@LicenseUniversity",licenseUniversity),
					new SqlParameter("@LicenseUniversityFree",licenseUniversityFree),
					new SqlParameter("@LicenseInstitute",licenseInstitute),
					new SqlParameter("@LicenseDepartment",licenseDepartment),
					new SqlParameter("@LicenseDepartmentFree",licenseDepartmentFree),
					new SqlParameter("@LicenseEducationType",licenseEducationType),
					new SqlParameter("@LicenseGradeSystem",licenseGradeSystem),
					new SqlParameter("@LicenseGraduationGrade",licenseGraduationGrade),
					new SqlParameter("@HighSchool",highSchool),
					new SqlParameter("@HighSchoolEndDate",highSchoolEndDate),
					new SqlParameter("@HighSchoolGradeSystem",highSchoolGradeSystem),
					new SqlParameter("@HighSchoolGraduationGrade",highSchoolGraduationGrade),
					new SqlParameter("@ComputerInfo",computerInfo),
					new SqlParameter("@HasDrivingLicense",hasDrivingLicense),
					new SqlParameter("@InterestedAdvertisementType",interestedAdvertisementType),
					new SqlParameter("@TotalWorkExperienceInMonth",totalWorkExperienceInMonth),
					new SqlParameter("@WorkingStatus",workingStatus),
					new SqlParameter("@CVState",cVState),
					new SqlParameter("@IsDefault",isDefault),
					new SqlParameter("@ModifyDate",modifyDate),
					new SqlParameter("@CreateDate",createDate)
                };

                    return ExecuteNonQuery("BGA_UpdateCVsByParams", sqlParams);

                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "CVsProvider", "UpdateByParams", ArrangeParamValues(sqlParams));
                }
            }

            public static int UpdateByParams(params SqlParameter[] sqlParams)
            {
                try
                {

                    return ExecuteNonQuery("BGA_UpdateCVsByParams", sqlParams);

                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "CVsProvider", "UpdateByParams", ArrangeParamValues(sqlParams));
                }
            }

            public static int UpdateByParams(SqlTransaction tran, int id, int? userId, string name, int? cvLanguage, int? maritalStatus, int? birthPlaceCountry, int? birthPlaceCity, string birthPlaceCityFree, int? nationality, string homePhone, string mobilePhone1, string mobilePhone2, string email, string webpage, int? contactType, int? cigaretteUseType, string otherClubs, string otherUniversityClubs, int? educationState, DateTime? masterStartDate, DateTime? masterEndDate, int? masterUniversity, string masterUniversityFree, int? masterInstitute, int? masterDepartment, string masterDepartmentFree, int? masterGradeSystem, decimal? masterGraduationGrade, DateTime? licenseStartDate, DateTime? licenseEndDate, int? licenseUniversity, string licenseUniversityFree, int? licenseInstitute, int? licenseDepartment, string licenseDepartmentFree, int? licenseEducationType, int? licenseGradeSystem, decimal? licenseGraduationGrade, string highSchool, DateTime? highSchoolEndDate, int? highSchoolGradeSystem, decimal? highSchoolGraduationGrade, string computerInfo, bool? hasDrivingLicense, int? interestedAdvertisementType, int? totalWorkExperienceInMonth, int? workingStatus, int? cVState, bool? isDefault, DateTime? modifyDate, DateTime? createDate)
            {
                SqlParameter[] sqlParams = null;

                try
                {
                    sqlParams = new SqlParameter[] { 
					new SqlParameter("@ID",id),
					new SqlParameter("@UserId",userId),
					new SqlParameter("@Name",name),
					new SqlParameter("@CvLanguage",cvLanguage),
					new SqlParameter("@MaritalStatus",maritalStatus),
					new SqlParameter("@BirthPlaceCountry",birthPlaceCountry),
					new SqlParameter("@BirthPlaceCity",birthPlaceCity),
					new SqlParameter("@BirthPlaceCityFree",birthPlaceCityFree),
					new SqlParameter("@Nationality",nationality),
					new SqlParameter("@HomePhone",homePhone),
					new SqlParameter("@MobilePhone1",mobilePhone1),
					new SqlParameter("@MobilePhone2",mobilePhone2),
					new SqlParameter("@Email",email),
					new SqlParameter("@Webpage",webpage),
					new SqlParameter("@ContactType",contactType),
					new SqlParameter("@CigaretteUseType",cigaretteUseType),
					new SqlParameter("@OtherClubs",otherClubs),
					new SqlParameter("@OtherUniversityClubs",otherUniversityClubs),
					new SqlParameter("@EducationState",educationState),
					new SqlParameter("@MasterStartDate",masterStartDate),
					new SqlParameter("@MasterEndDate",masterEndDate),
					new SqlParameter("@MasterUniversity",masterUniversity),
					new SqlParameter("@MasterUniversityFree",masterUniversityFree),
					new SqlParameter("@MasterInstitute",masterInstitute),
					new SqlParameter("@MasterDepartment",masterDepartment),
					new SqlParameter("@MasterDepartmentFree",masterDepartmentFree),
					new SqlParameter("@MasterGradeSystem",masterGradeSystem),
					new SqlParameter("@MasterGraduationGrade",masterGraduationGrade),
					new SqlParameter("@LicenseStartDate",licenseStartDate),
					new SqlParameter("@LicenseEndDate",licenseEndDate),
					new SqlParameter("@LicenseUniversity",licenseUniversity),
					new SqlParameter("@LicenseUniversityFree",licenseUniversityFree),
					new SqlParameter("@LicenseInstitute",licenseInstitute),
					new SqlParameter("@LicenseDepartment",licenseDepartment),
					new SqlParameter("@LicenseDepartmentFree",licenseDepartmentFree),
					new SqlParameter("@LicenseEducationType",licenseEducationType),
					new SqlParameter("@LicenseGradeSystem",licenseGradeSystem),
					new SqlParameter("@LicenseGraduationGrade",licenseGraduationGrade),
					new SqlParameter("@HighSchool",highSchool),
					new SqlParameter("@HighSchoolEndDate",highSchoolEndDate),
					new SqlParameter("@HighSchoolGradeSystem",highSchoolGradeSystem),
					new SqlParameter("@HighSchoolGraduationGrade",highSchoolGraduationGrade),
					new SqlParameter("@ComputerInfo",computerInfo),
					new SqlParameter("@HasDrivingLicense",hasDrivingLicense),
					new SqlParameter("@InterestedAdvertisementType",interestedAdvertisementType),
					new SqlParameter("@TotalWorkExperienceInMonth",totalWorkExperienceInMonth),
					new SqlParameter("@WorkingStatus",workingStatus),
					new SqlParameter("@CVState",cVState),
					new SqlParameter("@IsDefault",isDefault),
					new SqlParameter("@ModifyDate",modifyDate),
					new SqlParameter("@CreateDate",createDate)
                };

                    return ExecuteNonQuery(tran, "BGA_UpdateCVsByParams", sqlParams);

                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "CVsProvider", "UpdateByParams", ArrangeParamValues(sqlParams));
                }
            }

            public static int UpdateByParams(SqlTransaction tran, params SqlParameter[] sqlParams)
            {
                try
                {

                    return ExecuteNonQuery(tran, "BGA_UpdateCVsByParams", sqlParams);

                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "CVsProvider", "UpdateByParams", ArrangeParamValues(sqlParams));
                }
            }
            #endregion

            #region Add Functions
            public static int Add(int userId, string name, int cvLanguage, int maritalStatus, int birthPlaceCountry, int birthPlaceCity, string birthPlaceCityFree, int nationality, string homePhone, string mobilePhone1, string mobilePhone2, string email, string webpage, int? contactType, int? cigaretteUseType, string otherClubs, string otherUniversityClubs, int educationState, DateTime? masterStartDate, DateTime? masterEndDate, int? masterUniversity, string masterUniversityFree, int? masterInstitute, int? masterDepartment, string masterDepartmentFree, int? masterGradeSystem, decimal? masterGraduationGrade, DateTime? licenseStartDate, DateTime? licenseEndDate, int? licenseUniversity, string licenseUniversityFree, int? licenseInstitute, int? licenseDepartment, string licenseDepartmentFree, int? licenseEducationType, int? licenseGradeSystem, decimal? licenseGraduationGrade, string highSchool, DateTime? highSchoolEndDate, int? highSchoolGradeSystem, decimal? highSchoolGraduationGrade, string computerInfo, bool? hasDrivingLicense, int? interestedAdvertisementType, int? totalWorkExperienceInMonth, int? workingStatus, int cVState, bool isDefault, DateTime modifyDate, DateTime createDate)
            {
                SqlParameter[] sqlParams = null;

                try
                {
                    sqlParams = new SqlParameter[] { 
					new SqlParameter("@UserId",userId),
					new SqlParameter("@Name",name),
					new SqlParameter("@CvLanguage",cvLanguage),
					new SqlParameter("@MaritalStatus",maritalStatus),
					new SqlParameter("@BirthPlaceCountry",birthPlaceCountry),
					new SqlParameter("@BirthPlaceCity",birthPlaceCity),
					new SqlParameter("@BirthPlaceCityFree",birthPlaceCityFree),
					new SqlParameter("@Nationality",nationality),
					new SqlParameter("@HomePhone",homePhone),
					new SqlParameter("@MobilePhone1",mobilePhone1),
					new SqlParameter("@MobilePhone2",mobilePhone2),
					new SqlParameter("@Email",email),
					new SqlParameter("@Webpage",webpage),
					new SqlParameter("@ContactType",contactType),
					new SqlParameter("@CigaretteUseType",cigaretteUseType),
					new SqlParameter("@OtherClubs",otherClubs),
					new SqlParameter("@OtherUniversityClubs",otherUniversityClubs),
					new SqlParameter("@EducationState",educationState),
					new SqlParameter("@MasterStartDate",masterStartDate),
					new SqlParameter("@MasterEndDate",masterEndDate),
					new SqlParameter("@MasterUniversity",masterUniversity),
					new SqlParameter("@MasterUniversityFree",masterUniversityFree),
					new SqlParameter("@MasterInstitute",masterInstitute),
					new SqlParameter("@MasterDepartment",masterDepartment),
					new SqlParameter("@MasterDepartmentFree",masterDepartmentFree),
					new SqlParameter("@MasterGradeSystem",masterGradeSystem),
					new SqlParameter("@MasterGraduationGrade",masterGraduationGrade),
					new SqlParameter("@LicenseStartDate",licenseStartDate),
					new SqlParameter("@LicenseEndDate",licenseEndDate),
					new SqlParameter("@LicenseUniversity",licenseUniversity),
					new SqlParameter("@LicenseUniversityFree",licenseUniversityFree),
					new SqlParameter("@LicenseInstitute",licenseInstitute),
					new SqlParameter("@LicenseDepartment",licenseDepartment),
					new SqlParameter("@LicenseDepartmentFree",licenseDepartmentFree),
					new SqlParameter("@LicenseEducationType",licenseEducationType),
					new SqlParameter("@LicenseGradeSystem",licenseGradeSystem),
					new SqlParameter("@LicenseGraduationGrade",licenseGraduationGrade),
					new SqlParameter("@HighSchool",highSchool),
					new SqlParameter("@HighSchoolEndDate",highSchoolEndDate),
					new SqlParameter("@HighSchoolGradeSystem",highSchoolGradeSystem),
					new SqlParameter("@HighSchoolGraduationGrade",highSchoolGraduationGrade),
					new SqlParameter("@ComputerInfo",computerInfo),
					new SqlParameter("@HasDrivingLicense",hasDrivingLicense),
					new SqlParameter("@InterestedAdvertisementType",interestedAdvertisementType),
					new SqlParameter("@TotalWorkExperienceInMonth",totalWorkExperienceInMonth),
					new SqlParameter("@WorkingStatus",workingStatus),
					new SqlParameter("@CVState",cVState),
					new SqlParameter("@IsDefault",isDefault),
					new SqlParameter("@ModifyDate",modifyDate),
					new SqlParameter("@CreateDate",createDate)
                };

                    return ExecuteScalar("BGA_AddCVs", sqlParams);

                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "CVsProvider", "Add", ArrangeParamValues(sqlParams));
                }
            }

            public static int Add(SqlTransaction tran, int userId, string name, int cvLanguage, int maritalStatus, int birthPlaceCountry, int birthPlaceCity, string birthPlaceCityFree, int nationality, string homePhone, string mobilePhone1, string mobilePhone2, string email, string webpage, int? contactType, int? cigaretteUseType, string otherClubs, string otherUniversityClubs, int educationState, DateTime? masterStartDate, DateTime? masterEndDate, int? masterUniversity, string masterUniversityFree, int? masterInstitute, int? masterDepartment, string masterDepartmentFree, int? masterGradeSystem, decimal? masterGraduationGrade, DateTime? licenseStartDate, DateTime? licenseEndDate, int? licenseUniversity, string licenseUniversityFree, int? licenseInstitute, int? licenseDepartment, string licenseDepartmentFree, int? licenseEducationType, int? licenseGradeSystem, decimal? licenseGraduationGrade, string highSchool, DateTime? highSchoolEndDate, int? highSchoolGradeSystem, decimal? highSchoolGraduationGrade, string computerInfo, bool? hasDrivingLicense, int? interestedAdvertisementType, int? totalWorkExperienceInMonth, int? workingStatus, int cVState, bool isDefault, DateTime modifyDate, DateTime createDate)
            {
                SqlParameter[] sqlParams = null;

                try
                {
                    sqlParams = new SqlParameter[] { 
					new SqlParameter("@UserId",userId),
					new SqlParameter("@Name",name),
					new SqlParameter("@CvLanguage",cvLanguage),
					new SqlParameter("@MaritalStatus",maritalStatus),
					new SqlParameter("@BirthPlaceCountry",birthPlaceCountry),
					new SqlParameter("@BirthPlaceCity",birthPlaceCity),
					new SqlParameter("@BirthPlaceCityFree",birthPlaceCityFree),
					new SqlParameter("@Nationality",nationality),
					new SqlParameter("@HomePhone",homePhone),
					new SqlParameter("@MobilePhone1",mobilePhone1),
					new SqlParameter("@MobilePhone2",mobilePhone2),
					new SqlParameter("@Email",email),
					new SqlParameter("@Webpage",webpage),
					new SqlParameter("@ContactType",contactType),
					new SqlParameter("@CigaretteUseType",cigaretteUseType),
					new SqlParameter("@OtherClubs",otherClubs),
					new SqlParameter("@OtherUniversityClubs",otherUniversityClubs),
					new SqlParameter("@EducationState",educationState),
					new SqlParameter("@MasterStartDate",masterStartDate),
					new SqlParameter("@MasterEndDate",masterEndDate),
					new SqlParameter("@MasterUniversity",masterUniversity),
					new SqlParameter("@MasterUniversityFree",masterUniversityFree),
					new SqlParameter("@MasterInstitute",masterInstitute),
					new SqlParameter("@MasterDepartment",masterDepartment),
					new SqlParameter("@MasterDepartmentFree",masterDepartmentFree),
					new SqlParameter("@MasterGradeSystem",masterGradeSystem),
					new SqlParameter("@MasterGraduationGrade",masterGraduationGrade),
					new SqlParameter("@LicenseStartDate",licenseStartDate),
					new SqlParameter("@LicenseEndDate",licenseEndDate),
					new SqlParameter("@LicenseUniversity",licenseUniversity),
					new SqlParameter("@LicenseUniversityFree",licenseUniversityFree),
					new SqlParameter("@LicenseInstitute",licenseInstitute),
					new SqlParameter("@LicenseDepartment",licenseDepartment),
					new SqlParameter("@LicenseDepartmentFree",licenseDepartmentFree),
					new SqlParameter("@LicenseEducationType",licenseEducationType),
					new SqlParameter("@LicenseGradeSystem",licenseGradeSystem),
					new SqlParameter("@LicenseGraduationGrade",licenseGraduationGrade),
					new SqlParameter("@HighSchool",highSchool),
					new SqlParameter("@HighSchoolEndDate",highSchoolEndDate),
					new SqlParameter("@HighSchoolGradeSystem",highSchoolGradeSystem),
					new SqlParameter("@HighSchoolGraduationGrade",highSchoolGraduationGrade),
					new SqlParameter("@ComputerInfo",computerInfo),
					new SqlParameter("@HasDrivingLicense",hasDrivingLicense),
					new SqlParameter("@InterestedAdvertisementType",interestedAdvertisementType),
					new SqlParameter("@TotalWorkExperienceInMonth",totalWorkExperienceInMonth),
					new SqlParameter("@WorkingStatus",workingStatus),
					new SqlParameter("@CVState",cVState),
					new SqlParameter("@IsDefault",isDefault),
					new SqlParameter("@ModifyDate",modifyDate),
					new SqlParameter("@CreateDate",createDate)
                };

                    return ExecuteScalar(tran, "BGA_AddCVs", sqlParams);

                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "CVsProvider", "Add", ArrangeParamValues(sqlParams));
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

                    return ExecuteNonQuery("BGA_DeleteCVs", sqlParams);

                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "CVsProvider", "Delete", ArrangeParamValues(sqlParams));
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

                    return ExecuteNonQuery(tran, "BGA_DeleteCVs", sqlParams);

                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "CVsProvider", "Delete", ArrangeParamValues(sqlParams));
                }
            }

            public static int DeleteByParams(SqlTransaction tran, int? id, int? userId, string name, int? cvLanguage, int? maritalStatus, int? birthPlaceCountry, int? birthPlaceCity, string birthPlaceCityFree, int? nationality, string homePhone, string mobilePhone1, string mobilePhone2, string email, string webpage, int? contactType, int? cigaretteUseType, string otherClubs, string otherUniversityClubs, int? educationState, DateTime? masterStartDate, DateTime? beforeMasterStartDate, DateTime? afterOrEqualMasterStartDate, DateTime? masterEndDate, DateTime? beforeMasterEndDate, DateTime? afterOrEqualMasterEndDate, int? masterUniversity, string masterUniversityFree, int? masterInstitute, int? masterDepartment, string masterDepartmentFree, int? masterGradeSystem, decimal? masterGraduationGrade, DateTime? licenseStartDate, DateTime? beforeLicenseStartDate, DateTime? afterOrEqualLicenseStartDate, DateTime? licenseEndDate, DateTime? beforeLicenseEndDate, DateTime? afterOrEqualLicenseEndDate, int? licenseUniversity, string licenseUniversityFree, int? licenseInstitute, int? licenseDepartment, string licenseDepartmentFree, int? licenseEducationType, int? licenseGradeSystem, decimal? licenseGraduationGrade, string highSchool, DateTime? highSchoolEndDate, DateTime? beforeHighSchoolEndDate, DateTime? afterOrEqualHighSchoolEndDate, int? highSchoolGradeSystem, decimal? highSchoolGraduationGrade, string computerInfo, bool? hasDrivingLicense, int? interestedAdvertisementType, int? totalWorkExperienceInMonth, int? workingStatus, int? cVState, bool? isDefault, DateTime? modifyDate, DateTime? beforeModifyDate, DateTime? afterOrEqualModifyDate, DateTime? createDate, DateTime? beforeCreateDate, DateTime? afterOrEqualCreateDate)
            {
                SqlParameter[] sqlParams = null;

                try
                {
                    sqlParams = new SqlParameter[] { 
					new SqlParameter("@ID",id),
					new SqlParameter("@UserId",userId),
					new SqlParameter("@Name",name),
					new SqlParameter("@CvLanguage",cvLanguage),
					new SqlParameter("@MaritalStatus",maritalStatus),
					new SqlParameter("@BirthPlaceCountry",birthPlaceCountry),
					new SqlParameter("@BirthPlaceCity",birthPlaceCity),
					new SqlParameter("@BirthPlaceCityFree",birthPlaceCityFree),
					new SqlParameter("@Nationality",nationality),
					new SqlParameter("@HomePhone",homePhone),
					new SqlParameter("@MobilePhone1",mobilePhone1),
					new SqlParameter("@MobilePhone2",mobilePhone2),
					new SqlParameter("@Email",email),
					new SqlParameter("@Webpage",webpage),
					new SqlParameter("@ContactType",contactType),
					new SqlParameter("@CigaretteUseType",cigaretteUseType),
					new SqlParameter("@OtherClubs",otherClubs),
					new SqlParameter("@OtherUniversityClubs",otherUniversityClubs),
					new SqlParameter("@EducationState",educationState),
					new SqlParameter("@MasterStartDate",masterStartDate),
					new SqlParameter("@BeforeMasterStartDate",beforeMasterStartDate),
					new SqlParameter("@AfterOrEqualMasterStartDate",afterOrEqualMasterStartDate),
					new SqlParameter("@MasterEndDate",masterEndDate),
					new SqlParameter("@BeforeMasterEndDate",beforeMasterEndDate),
					new SqlParameter("@AfterOrEqualMasterEndDate",afterOrEqualMasterEndDate),
					new SqlParameter("@MasterUniversity",masterUniversity),
					new SqlParameter("@MasterUniversityFree",masterUniversityFree),
					new SqlParameter("@MasterInstitute",masterInstitute),
					new SqlParameter("@MasterDepartment",masterDepartment),
					new SqlParameter("@MasterDepartmentFree",masterDepartmentFree),
					new SqlParameter("@MasterGradeSystem",masterGradeSystem),
					new SqlParameter("@MasterGraduationGrade",masterGraduationGrade),
					new SqlParameter("@LicenseStartDate",licenseStartDate),
					new SqlParameter("@BeforeLicenseStartDate",beforeLicenseStartDate),
					new SqlParameter("@AfterOrEqualLicenseStartDate",afterOrEqualLicenseStartDate),
					new SqlParameter("@LicenseEndDate",licenseEndDate),
					new SqlParameter("@BeforeLicenseEndDate",beforeLicenseEndDate),
					new SqlParameter("@AfterOrEqualLicenseEndDate",afterOrEqualLicenseEndDate),
					new SqlParameter("@LicenseUniversity",licenseUniversity),
					new SqlParameter("@LicenseUniversityFree",licenseUniversityFree),
					new SqlParameter("@LicenseInstitute",licenseInstitute),
					new SqlParameter("@LicenseDepartment",licenseDepartment),
					new SqlParameter("@LicenseDepartmentFree",licenseDepartmentFree),
					new SqlParameter("@LicenseEducationType",licenseEducationType),
					new SqlParameter("@LicenseGradeSystem",licenseGradeSystem),
					new SqlParameter("@LicenseGraduationGrade",licenseGraduationGrade),
					new SqlParameter("@HighSchool",highSchool),
					new SqlParameter("@HighSchoolEndDate",highSchoolEndDate),
					new SqlParameter("@BeforeHighSchoolEndDate",beforeHighSchoolEndDate),
					new SqlParameter("@AfterOrEqualHighSchoolEndDate",afterOrEqualHighSchoolEndDate),
					new SqlParameter("@HighSchoolGradeSystem",highSchoolGradeSystem),
					new SqlParameter("@HighSchoolGraduationGrade",highSchoolGraduationGrade),
					new SqlParameter("@ComputerInfo",computerInfo),
					new SqlParameter("@HasDrivingLicense",hasDrivingLicense),
					new SqlParameter("@InterestedAdvertisementType",interestedAdvertisementType),
					new SqlParameter("@TotalWorkExperienceInMonth",totalWorkExperienceInMonth),
					new SqlParameter("@WorkingStatus",workingStatus),
					new SqlParameter("@CVState",cVState),
					new SqlParameter("@IsDefault",isDefault),
					new SqlParameter("@ModifyDate",modifyDate),
					new SqlParameter("@BeforeModifyDate",beforeModifyDate),
					new SqlParameter("@AfterOrEqualModifyDate",afterOrEqualModifyDate),
					new SqlParameter("@CreateDate",createDate),
					new SqlParameter("@BeforeCreateDate",beforeCreateDate),
					new SqlParameter("@AfterOrEqualCreateDate",afterOrEqualCreateDate)
                };

                    if (tran == null)
                        return ExecuteNonQuery("BGA_DeleteCVsByParams", sqlParams);
                    else
                        return ExecuteNonQuery(tran, "BGA_DeleteCVsByParams", sqlParams);


                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "CVsProvider", "DeleteByParams", ArrangeParamValues(sqlParams));
                }
            }

            public static int DeleteByParams(int? id, int? userId, string name, int? cvLanguage, int? maritalStatus, int? birthPlaceCountry, int? birthPlaceCity, string birthPlaceCityFree, int? nationality, string homePhone, string mobilePhone1, string mobilePhone2, string email, string webpage, int? contactType, int? cigaretteUseType, string otherClubs, string otherUniversityClubs, int? educationState, DateTime? masterStartDate, DateTime? beforeMasterStartDate, DateTime? afterOrEqualMasterStartDate, DateTime? masterEndDate, DateTime? beforeMasterEndDate, DateTime? afterOrEqualMasterEndDate, int? masterUniversity, string masterUniversityFree, int? masterInstitute, int? masterDepartment, string masterDepartmentFree, int? masterGradeSystem, decimal? masterGraduationGrade, DateTime? licenseStartDate, DateTime? beforeLicenseStartDate, DateTime? afterOrEqualLicenseStartDate, DateTime? licenseEndDate, DateTime? beforeLicenseEndDate, DateTime? afterOrEqualLicenseEndDate, int? licenseUniversity, string licenseUniversityFree, int? licenseInstitute, int? licenseDepartment, string licenseDepartmentFree, int? licenseEducationType, int? licenseGradeSystem, decimal? licenseGraduationGrade, string highSchool, DateTime? highSchoolEndDate, DateTime? beforeHighSchoolEndDate, DateTime? afterOrEqualHighSchoolEndDate, int? highSchoolGradeSystem, decimal? highSchoolGraduationGrade, string computerInfo, bool? hasDrivingLicense, int? interestedAdvertisementType, int? totalWorkExperienceInMonth, int? workingStatus, int? cVState, bool? isDefault, DateTime? modifyDate, DateTime? beforeModifyDate, DateTime? afterOrEqualModifyDate, DateTime? createDate, DateTime? beforeCreateDate, DateTime? afterOrEqualCreateDate)
            {
                return DeleteByParams(null, id, userId, name, cvLanguage, maritalStatus, birthPlaceCountry, birthPlaceCity, birthPlaceCityFree, nationality, homePhone, mobilePhone1, mobilePhone2, email, webpage, contactType, cigaretteUseType, otherClubs, otherUniversityClubs, educationState, masterStartDate, beforeMasterStartDate, afterOrEqualMasterStartDate, masterEndDate, beforeMasterEndDate, afterOrEqualMasterEndDate, masterUniversity, masterUniversityFree, masterInstitute, masterDepartment, masterDepartmentFree, masterGradeSystem, masterGraduationGrade, licenseStartDate, beforeLicenseStartDate, afterOrEqualLicenseStartDate, licenseEndDate, beforeLicenseEndDate, afterOrEqualLicenseEndDate, licenseUniversity, licenseUniversityFree, licenseInstitute, licenseDepartment, licenseDepartmentFree, licenseEducationType, licenseGradeSystem, licenseGraduationGrade, highSchool, highSchoolEndDate, beforeHighSchoolEndDate, afterOrEqualHighSchoolEndDate, highSchoolGradeSystem, highSchoolGraduationGrade, computerInfo, hasDrivingLicense, interestedAdvertisementType, totalWorkExperienceInMonth, workingStatus, cVState, isDefault, modifyDate, beforeModifyDate, afterOrEqualModifyDate, createDate, beforeCreateDate, afterOrEqualCreateDate)
    ;
            }

            public static int DeleteByFK(int? userId)
            {
                return DeleteByFK(null, userId)
    ;
            }

            public static int DeleteByFK(SqlTransaction tran, int? userId)
            {
                SqlParameter[] sqlParams = null;

                try
                {

                    sqlParams = new SqlParameter[] { 
					new SqlParameter("@UserId",userId)
                };

                    if (tran == null)
                        return ExecuteNonQuery("BGA_DeleteCVsByFK", sqlParams);
                    else
                        return ExecuteNonQuery(tran, "BGA_DeleteCVsByFK", sqlParams);

                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "CVsProvider", "DeleteByFK", ArrangeParamValues(sqlParams));
                }
            }


            #endregion

        }
    }
}
