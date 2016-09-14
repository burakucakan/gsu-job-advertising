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
            public class MasterInfo
            {
                #region ColumnNames
                public struct ColumnNames
                {
                    public const string MasterStartDate = CVs.ColumnNames.MasterStartDate;
                    public const string MasterEndDate = CVs.ColumnNames.MasterEndDate;
                    public const string MasterUniversity = CVs.ColumnNames.MasterUniversity;
                    public const string MasterUniversityFree = CVs.ColumnNames.MasterUniversityFree;
                    public const string MasterInstitute = CVs.ColumnNames.MasterInstitute;
                    public const string MasterDepartment = CVs.ColumnNames.MasterDepartment;
                    public const string MasterDepartmentFree = CVs.ColumnNames.MasterDepartmentFree;
                    public const string MasterGradeSystem = CVs.ColumnNames.MasterGradeSystem;
                    public const string MasterGraduationGrade = CVs.ColumnNames.MasterGraduationGrade;
                }
                #endregion

                #region Get Functions
                public static DataTable Get(int cvId)
                {
                    return CVsProvider.GetCVMasterInfo(null,cvId).Tables[0];
                }
                #endregion

                #region Update Functions
                public static int Update(int cvId,DateTime? masterStartDate,DateTime? masterEndDate,
                    int? masterUniversity,string masterUniversityFree,int? masterInstitute,
                    int? masterDepartment,string masterDepartmentFree, int? masterGradeSystem, 
                    decimal? masterGraduationGrade,DateTime modifyDate)
                {
                    return CVsProvider.UpdateCVEducationMasterInfo(null,cvId,masterStartDate,masterEndDate,
                        masterUniversity, masterUniversityFree,masterInstitute,masterDepartment,
                        masterDepartmentFree,masterGradeSystem, masterGraduationGrade,
                        modifyDate);
                }
                public static int Update(SqlTransaction tran,int cvId, DateTime masterStartDate, 
                    DateTime masterEndDate,
                    int masterUniversity, string masterUniversityFree, int masterInstitute, int masterDepartment,
                    string masterDepartmentFree, int masterGradeSystem, decimal masterGraduationGrade,
                    DateTime modifyDate)
                {
                    return CVsProvider.UpdateCVEducationMasterInfo(tran, cvId, masterStartDate, masterEndDate,
                        masterUniversity, masterUniversityFree, masterInstitute, masterDepartment,
                        masterDepartmentFree, masterGradeSystem, masterGraduationGrade,
                        modifyDate);
                }
                #endregion
            }
        }
    }
}
