using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using GSUKariyer.COMMON.Helpers.DAL;
using GSUKariyer.COMMON.Exceptions;

namespace GSUKariyer.DAL {

	public partial class CVsProvider
    {

        #region Get Functions
        public static DataSet GetAllData(SqlTransaction tran,int cvId)
        {
            SqlParameter[] sqlParams = null;

            try
            {
                DataSet ds = null;

                sqlParams = new SqlParameter[] { 
					new SqlParameter("@CvId",cvId)
                };

                if (tran == null)
                    ds = ExecuteDataset("BGA_CustomGetCV", sqlParams);
                else
                    ds = ExecuteDataset(tran, "BGA_CustomGetCV", sqlParams);

                return ds;
            }
            catch (Exception ex)
            {
                throw new MyException(ex, "CVsProvider", "GetAllData", ArrangeParamValues(sqlParams));
            }
        }
        
        public static DataSet GetCVPersonalInfo(SqlTransaction tran,int? cvId)
        {
            SqlParameter[] sqlParams = null;

            try
            {
                DataSet ds = null;

                sqlParams = new SqlParameter[] { 
					new SqlParameter("@CvId",cvId)
                };

                if (tran == null)
                    ds = ExecuteDataset("BGA_CustomGetCVPersonalInfo", sqlParams);
                else
                    ds = ExecuteDataset(tran, "BGA_CustomGetCVPersonalInfo", sqlParams);

                return ds;
            }
            catch (Exception ex)
            {
                throw new MyException(ex, "CVsProvider", "GetCVPersonalInfo", ArrangeParamValues(sqlParams));
            }
        }
        
        public static DataSet GetCVCommunicationInfo(SqlTransaction tran,int? cvId)
        {
            SqlParameter[] sqlParams = null;

            try
            {
                DataSet ds = null;

                sqlParams = new SqlParameter[] { 
					new SqlParameter("@CvId",cvId)
                };

                if (tran == null)
                    ds = ExecuteDataset("BGA_CustomGetCVCommunicationInfo", sqlParams);
                else
                    ds = ExecuteDataset(tran, "BGA_CustomGetCVCommunicationInfo", sqlParams);

                return ds;
            }
            catch (Exception ex)
            {
                throw new MyException(ex, "CVsProvider", "GetCVCommunicationInfo", ArrangeParamValues(sqlParams));
            }
        }

        public static DataSet GetCVUserClubsInfo(SqlTransaction tran, int? cvId)
        {
            SqlParameter[] sqlParams = null;

            try
            {
                DataSet ds = null;

                sqlParams = new SqlParameter[] { 
					new SqlParameter("@CvId",cvId)
                };

                if (tran == null)
                    ds = ExecuteDataset("BGA_CustomGetCVUserClubsInfo", sqlParams);
                else
                    ds = ExecuteDataset(tran, "BGA_CustomGetCVUserClubsInfo", sqlParams);

                return ds;
            }
            catch (Exception ex)
            {
                throw new MyException(ex, "CVsProvider", "GetCVUserClubsInfo", ArrangeParamValues(sqlParams));
            }
        }

        public static DataSet GetCVEducationInfo(SqlTransaction tran, int? cvId)
        {
            SqlParameter[] sqlParams = null;

            try
            {
                DataSet ds = null;

                sqlParams = new SqlParameter[] { 
					new SqlParameter("@CvId",cvId)
                };

                if (tran == null)
                    ds = ExecuteDataset("BGA_CustomGetCVEducationInfo", sqlParams);
                else
                    ds = ExecuteDataset(tran, "BGA_CustomGetCVEducationInfo", sqlParams);

                return ds;
            }
            catch (Exception ex)
            {
                throw new MyException(ex, "CVsProvider", "GetCVEducationInfo", ArrangeParamValues(sqlParams));
            }
        }

        public static DataSet GetCVMasterInfo(SqlTransaction tran, int? cvId)
        {
            SqlParameter[] sqlParams = null;

            try
            {
                DataSet ds = null;

                sqlParams = new SqlParameter[] { 
					new SqlParameter("@CvId",cvId)
                };

                if (tran == null)
                    ds = ExecuteDataset("BGA_CustomGetMasterInfo", sqlParams);
                else
                    ds = ExecuteDataset(tran, "BGA_CustomGetMasterInfo", sqlParams);

                return ds;
            }
            catch (Exception ex)
            {
                throw new MyException(ex, "CVsProvider", "GetCVMasterInfo", ArrangeParamValues(sqlParams));
            }
        }

        public static DataSet GetCVLicenseEducationInfo(SqlTransaction tran, int? cvId)
        {
            SqlParameter[] sqlParams = null;

            try
            {
                DataSet ds = null;

                sqlParams = new SqlParameter[] { 
					new SqlParameter("@CvId",cvId)
                };

                if (tran == null)
                    ds = ExecuteDataset("[BGA_CustomGetLicenseEducationInfo]", sqlParams);
                else
                    ds = ExecuteDataset(tran, "[BGA_CustomGetLicenseEducationInfo]", sqlParams);

                return ds;
            }
            catch (Exception ex)
            {
                throw new MyException(ex, "CVsProvider", "GetCVLicenseEducationInfo", ArrangeParamValues(sqlParams));
            }
        }

        public static DataSet GetCVHighSchoolInfo(SqlTransaction tran, int? cvId)
        {
            SqlParameter[] sqlParams = null;

            try
            {
                DataSet ds = null;

                sqlParams = new SqlParameter[] { 
					new SqlParameter("@CvId",cvId)
                };

                if (tran == null)
                    ds = ExecuteDataset("[BGA_CustomGetHighSchoolInfo]", sqlParams);
                else
                    ds = ExecuteDataset(tran, "[BGA_CustomGetHighSchoolInfo]", sqlParams);

                return ds;
            }
            catch (Exception ex)
            {
                throw new MyException(ex, "CVsProvider", "GetCVHighSchoolInfo", ArrangeParamValues(sqlParams));
            }
        }

        public static DataSet GetCVInterestedJobPositions(SqlTransaction tran, int? cvId)
        {
            SqlParameter[] sqlParams = null;

            try
            {
                DataSet ds = null;

                sqlParams = new SqlParameter[] { 
					new SqlParameter("@CvId",cvId)
                };

                if (tran == null)
                    ds = ExecuteDataset("[BGA_CustomGetCVInterestedJobPositions]", sqlParams);
                else
                    ds = ExecuteDataset(tran, "[BGA_CustomGetCVInterestedJobPositions]", sqlParams);

                return ds;
            }
            catch (Exception ex)
            {
                throw new MyException(ex, "CVsProvider", "GetCVInterestedJobPositions", ArrangeParamValues(sqlParams));
            }
        }

        #endregion

        #region Update Functions
        public static int UpdateCVPersonalInfo(SqlTransaction tran,int cvId, int maritalStatus, 
            int birthPlaceCountry, int birthPlaceCity,string birthPlaceCityFree, int nationality,
            DateTime modifyDate)
        {
            SqlParameter[] sqlParams=new SqlParameter[]{
                new SqlParameter("@ID",cvId),
				new SqlParameter("@MaritalStatus",maritalStatus),
				new SqlParameter("@BirthPlaceCountry",birthPlaceCountry),
				new SqlParameter("@BirthPlaceCity",birthPlaceCity),
				new SqlParameter("@BirthPlaceCityFree",birthPlaceCityFree),
				new SqlParameter("@Nationality",nationality),
                new SqlParameter("@ModifyDate",modifyDate)
            };

            if (tran==null)
                return Generated.UpdateByParams(sqlParams);
            else
                return Generated.UpdateByParams(tran,sqlParams);
        }

        public static int UpdateCigaretteUsageInfo(SqlTransaction tran, int cvId, int cigaretteUsageType,
            DateTime modifyDate)
        {
            SqlParameter[] sqlParams = new SqlParameter[]{
                new SqlParameter("@ID",cvId),
				new SqlParameter("@CigaretteUseType",cigaretteUsageType),
                new SqlParameter("@ModifyDate",modifyDate)
            };

            if (tran == null)
                return Generated.UpdateByParams(sqlParams);
            else
                return Generated.UpdateByParams(tran, sqlParams);
        }

        public static int UpdateCVState(SqlTransaction tran, int cvId, int state,
            DateTime modifyDate)
        {
            SqlParameter[] sqlParams = new SqlParameter[]{
                new SqlParameter("@ID",cvId),
				new SqlParameter("@CVState",state),
                new SqlParameter("@ModifyDate",modifyDate)
            };

            if (tran == null)
                return Generated.UpdateByParams(sqlParams);
            else
                return Generated.UpdateByParams(tran, sqlParams);
        }

        public static int UpdateCVDrivingInfo(SqlTransaction tran, int cvId, bool hasDrivingLicense,
            DateTime modifyDate)
        {
            SqlParameter[] sqlParams = new SqlParameter[]{
                new SqlParameter("@ID",cvId),
				new SqlParameter("@HasDrivingLicense",hasDrivingLicense),
                new SqlParameter("@ModifyDate",modifyDate)
            };

            if (tran == null)
                return Generated.UpdateByParams(sqlParams);
            else
                return Generated.UpdateByParams(tran, sqlParams);
        }

        public static int UpdateCVEducationState(SqlTransaction tran, int cvId, int educationState,
            DateTime modifyDate)
        {
            SqlParameter[] sqlParams = new SqlParameter[]{
                new SqlParameter("@ID",cvId),
				new SqlParameter("@EducationState",educationState),
                new SqlParameter("@ModifyDate",modifyDate)
            };

            if (tran == null)
                return Generated.UpdateByParams(sqlParams);
            else
                return Generated.UpdateByParams(tran, sqlParams);
        }

        public static int UpdateCVGeneralInfo(SqlTransaction tran, int cvId, string name, int cvLanguage,
            DateTime modifyDate)
        {
            SqlParameter[] sqlParams = new SqlParameter[]{
                new SqlParameter("@ID",cvId),
				new SqlParameter("@Name",name),
                new SqlParameter("@CvLanguage",cvLanguage),
                new SqlParameter("@ModifyDate",modifyDate)
            };

            if (tran == null)
                return Generated.UpdateByParams(sqlParams);
            else
                return Generated.UpdateByParams(tran, sqlParams);
        }

        public static int UpdateCVAsDefault(SqlTransaction tran, int cvId,int userId, bool isDefault)
        {
            SqlParameter[] sqlParams = null;

            try
            {
                sqlParams = new SqlParameter[] { 
					new SqlParameter("@CvId",cvId),
                    new SqlParameter("@UserId",userId),
                    new SqlParameter("@IsDefault",isDefault)
                };

                if (tran == null)
                    return ExecuteNonQuery("BGA_CustomUpdateCVAsDefault", sqlParams);
                else
                    return ExecuteNonQuery(tran, "BGA_CustomUpdateCVAsDefault", sqlParams);
            }
            catch (Exception ex)
            {
                throw new MyException(ex, "CVsProvider", "UpdateCVAsDefault", ArrangeParamValues(sqlParams));
            }
        }
        
        public static int UpdateCVCommunicationInfo(SqlTransaction tran, int cvId, string homePhone,
            string mobilePhone1, string mobilePhone2, string email, string webpage,int contactType,
            DateTime modifyDate)
        {
            SqlParameter[] sqlParams = new SqlParameter[]{
                new SqlParameter("@ID",cvId),
				new SqlParameter("@HomePhone",homePhone),
				new SqlParameter("@MobilePhone1",mobilePhone1),
				new SqlParameter("@MobilePhone2",mobilePhone2),
				new SqlParameter("@Email",email),
				new SqlParameter("@Webpage",webpage),
				new SqlParameter("@ContactType",contactType),
                new SqlParameter("@ModifyDate",modifyDate)
            };

            if (tran == null)
                return Generated.UpdateByParams(sqlParams);
            else
                return Generated.UpdateByParams(tran, sqlParams);
        }

        public static int UpdateCVUserClubsInfo(SqlTransaction tran, int cvId, string otherClubs, 
            string otherUniversityClubs,DateTime modifyDate)
        {
            SqlParameter[] sqlParams = new SqlParameter[]{
                new SqlParameter("@ID",cvId),
				new SqlParameter("@OtherClubs",otherClubs),
			    new SqlParameter("@OtherUniversityClubs",otherUniversityClubs),
                new SqlParameter("@ModifyDate",modifyDate)
            };

            if (tran == null)
                return Generated.UpdateByParams(sqlParams);
            else
                return Generated.UpdateByParams(tran, sqlParams);
        }

        public static int UpdateCVEducationMasterInfo(SqlTransaction tran, int cvId, 
            DateTime? masterStartDate, DateTime? masterEndDate,
            int? masterUniversity, string masterUniversityFree, int? masterInstitute, int? masterDepartment,
            string masterDepartmentFree, int? masterGradeSystem, decimal? masterGraduationGrade,
            DateTime modifyDate)
        {
            SqlParameter[] sqlParams = new SqlParameter[]{
                new SqlParameter("@ID",cvId),
				new SqlParameter("@MasterStartDate",masterStartDate),
				new SqlParameter("@MasterEndDate",masterEndDate),
				new SqlParameter("@MasterUniversity",masterUniversity),
				new SqlParameter("@MasterUniversityFree",masterUniversityFree),
				new SqlParameter("@MasterInstitute",masterInstitute),
				new SqlParameter("@MasterDepartment",masterDepartment),
				new SqlParameter("@MasterDepartmentFree",masterDepartmentFree),
				new SqlParameter("@MasterGradeSystem",masterGradeSystem),
				new SqlParameter("@MasterGraduationGrade",masterGraduationGrade),
                new SqlParameter("@ModifyDate",modifyDate)
            };

            if (tran == null)
                return Generated.UpdateByParams(sqlParams);
            else
                return Generated.UpdateByParams(tran, sqlParams);
        }

        public static int UpdateCVEducationLicenseInfo(SqlTransaction tran, int cvId, DateTime licenseStartDate, DateTime? licenseEndDate,int? licenseUniversity, string licenseUniversityFree, int? licenseInstitute, int? licenseDepartment, string licenseDepartmentFree, int? licenseEducationType, int? licenseGradeSystem, decimal? licenseGraduationGrade,
            DateTime modifyDate)
        {
            SqlParameter[] sqlParams = new SqlParameter[]{
                new SqlParameter("@ID",cvId),
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
                new SqlParameter("@ModifyDate",modifyDate)
            };

            if (tran == null)
                return Generated.UpdateByParams(sqlParams);
            else
                return Generated.UpdateByParams(tran, sqlParams);
        }

        public static int UpdateCVHighSchoolInfo(SqlTransaction tran, int cvId, string highSchool, 
            DateTime highSchoolEndDate,int highSchoolGradeSystem, decimal highSchoolGraduationGrade, 
            DateTime modifyDate)
        {
            SqlParameter[] sqlParams = new SqlParameter[]{
                new SqlParameter("@ID",cvId),
				new SqlParameter("@HighSchool",highSchool),
				new SqlParameter("@HighSchoolEndDate",highSchoolEndDate),
				new SqlParameter("@HighSchoolGradeSystem",highSchoolGradeSystem),
				new SqlParameter("@HighSchoolGraduationGrade",highSchoolGraduationGrade),
                new SqlParameter("@ModifyDate",modifyDate)
            };

            if (tran == null)
                return Generated.UpdateByParams(sqlParams);
            else
                return Generated.UpdateByParams(tran, sqlParams);
        }

        public static int UpdateInterestedAdvertisementTypes(SqlTransaction tran, int cvId, 
            int interestedAdvertisementTypes,DateTime modifyDate)
        {
            SqlParameter[] sqlParams = new SqlParameter[]{
                new SqlParameter("@ID",cvId),
				new SqlParameter("@InterestedAdvertisementType",interestedAdvertisementTypes),
                new SqlParameter("@ModifyDate",modifyDate)
            };

            if (tran == null)
                return Generated.UpdateByParams(sqlParams);
            else
                return Generated.UpdateByParams(tran, sqlParams);
        }

        public static int UpdateCVComputerInfo(SqlTransaction tran, int cvId,
            string computerInfo, DateTime modifyDate)
        {
            SqlParameter[] sqlParams = new SqlParameter[]{
                new SqlParameter("@ID",cvId),
				new SqlParameter("@ComputerInfo",computerInfo),
                new SqlParameter("@ModifyDate",modifyDate)
            };

            if (tran == null)
                return Generated.UpdateByParams(sqlParams);
            else
                return Generated.UpdateByParams(tran, sqlParams);
        }

        public static int UpdateCVExperienceInfo(SqlTransaction tran, int cvId,
            int? totalExperienceInMonth,int? workingStatus, DateTime modifyDate)
        {
            SqlParameter[] sqlParams = new SqlParameter[]{
                new SqlParameter("@ID",cvId),
				new SqlParameter("@TotalWorkExperienceInMonth",totalExperienceInMonth),
                new SqlParameter("@WorkingStatus",workingStatus),
                new SqlParameter("@ModifyDate",modifyDate)
            };

            if (tran == null)
                return Generated.UpdateByParams(sqlParams);
            else
                return Generated.UpdateByParams(tran, sqlParams);
        }

        public static int CvDefault(int UserId, int CvId)
        {
            SqlParameter[] sqlParams = null;

            try
            {
                sqlParams = new SqlParameter[] { 
					new SqlParameter("@CvId", CvId),
                    new SqlParameter("@UserId", UserId)
                };

                return ExecuteNonQuery("BGA_CustomCvDefault", sqlParams);
            }
            catch (Exception ex)
            {
                throw new MyException(ex, "CVsProvider", "CustomCvDefault", ArrangeParamValues(sqlParams));
            }
        }

        #endregion
    }
}
