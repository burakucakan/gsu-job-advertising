using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using GSUKariyer.DAL;
using GSUKariyer.COMMON;
using GSUKariyer.COMMON.Exceptions;

namespace GSUKariyer.BUS
{
    public partial class CVs
    {
        public partial class EducationInfo
        {
            public class LicenseInfo
            {
                #region ColumnNames
                public struct ColumnNames
                {
                    public const string LicenseStartDate = CVs.ColumnNames.LicenseStartDate;
                    public const string LicenseEndDate = CVs.ColumnNames.LicenseEndDate;
                    public const string LicenseUniversity = CVs.ColumnNames.LicenseUniversity;
                    public const string LicenseUniversityFree = CVs.ColumnNames.LicenseUniversityFree;
                    public const string LicenseInstitute = CVs.ColumnNames.LicenseInstitute;
                    public const string LicenseDepartment = CVs.ColumnNames.LicenseDepartment;
                    public const string LicenseDepartmentFree = CVs.ColumnNames.LicenseDepartmentFree;
                    public const string LicenseEducationType = CVs.ColumnNames.LicenseEducationType;
                    public const string LicenseGradeSystem = CVs.ColumnNames.LicenseGradeSystem;
                    public const string LicenseGraduationGrade = CVs.ColumnNames.LicenseGraduationGrade;
                }
                #endregion

                #region Get Functions
                public static DataTable Get(int cvId)
                {
                    return CVsProvider.GetCVLicenseEducationInfo(null,cvId).Tables[0];
                }
                #endregion

                #region Update Functions
                public static int Update(int cvId, DateTime licenseStartDate,
                    DateTime? licenseEndDate, int? licenseUniversity, string licenseUniversityFree,
                    int? licenseInstitute, int licenseDepartment, string licenseDepartmentFree,
                    int? licenseEducationType, int? licenseGradeSystem, decimal? licenseGraduationGrade,
                    DateTime modifyDate)
                {
                    return CVsProvider.UpdateCVEducationLicenseInfo(null,cvId, licenseStartDate,
                        licenseEndDate, licenseUniversity, licenseUniversityFree,
                        licenseInstitute, licenseDepartment, licenseDepartmentFree,
                        licenseEducationType, licenseGradeSystem, licenseGraduationGrade, modifyDate);
                }
                public static int Update(SqlTransaction tran, int cvId, DateTime licenseStartDate, 
                    DateTime licenseEndDate, int licenseUniversity, string licenseUniversityFree, 
                    int licenseInstitute, int licenseDepartment, string licenseDepartmentFree, 
                    int licenseEducationType, int licenseGradeSystem, decimal? licenseGraduationGrade,
                    DateTime modifyDate)
                {
                    return CVsProvider.UpdateCVEducationLicenseInfo(tran, cvId, licenseStartDate, 
                        licenseEndDate, licenseUniversity, licenseUniversityFree, 
                        licenseInstitute,licenseDepartment, licenseDepartmentFree, 
                        licenseEducationType,licenseGradeSystem, licenseGraduationGrade, modifyDate);
                }
                #endregion
            }
        }
    }
}
