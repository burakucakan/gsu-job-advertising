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
            #region Enums
            public enum UniversityInfo
            {
                GsUniversity=0,
                Other=1
            }
            public struct UniversityInstitute
            {
                public const int Other = -1;
            }
            public struct UniversityDepartment
            {
                public const int Other = -1;
            }
            #endregion

            #region ColumnNames
            public struct ColumnNames
            {
                public const string EducationState = CVs.ColumnNames.EducationState;
                public const string MasterStartDate = CVs.ColumnNames.MasterStartDate;
                public const string MasterEndDate = CVs.ColumnNames.MasterEndDate;
                public const string MasterUniversity = CVs.ColumnNames.MasterUniversity;
                public const string MasterUniversityFree = CVs.ColumnNames.MasterUniversityFree;
                public const string MasterInstitute = CVs.ColumnNames.MasterInstitute;
                public const string MasterDepartment = CVs.ColumnNames.MasterDepartment;
                public const string MasterDepartmentFree = CVs.ColumnNames.MasterDepartmentFree;
                public const string MasterGradeSystem = CVs.ColumnNames.MasterGradeSystem;
                public const string MasterGraduationGrade = CVs.ColumnNames.MasterGraduationGrade;
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
                public const string HighSchool = CVs.ColumnNames.HighSchool;
                public const string HighSchoolEndDate = CVs.ColumnNames.HighSchoolEndDate;
                public const string HighSchoolGradeSystem = CVs.ColumnNames.HighSchoolGradeSystem;
                public const string HighSchoolGraduationGrade = CVs.ColumnNames.HighSchoolGraduationGrade;
                public const string ComputerInfo = CVs.ColumnNames.ComputerInfo;
            }
            #endregion

            #region Get Functions
            public static DataTable Get(int cvId)
            {
                return CVsProvider.GetCVEducationInfo(null,cvId).Tables[0];
            }
            #endregion

            #region ComputerInfo
            public class ComputerInfo
            {
                public static int Update(int cvId, string computerInfo, DateTime modifyDate)
                {
                    return CVsProvider.UpdateCVComputerInfo(null, cvId, computerInfo, modifyDate);
                }
            }
            #endregion

            #region State
            public class State
            {
                public const int Student = 0;
                public const int Graduated = 1;

                public static int Update(int cvId,int state,DateTime modifyDate)
                {
                    return CVsProvider.UpdateCVEducationState(null,cvId,state,modifyDate);
                }
            }
            #endregion
        }
    }
}
