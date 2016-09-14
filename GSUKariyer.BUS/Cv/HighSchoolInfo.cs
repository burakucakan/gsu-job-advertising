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
            public class HighSchoolInfo
            {
                #region ColumnNames
                public struct ColumnNames
                {
                    public const string HighSchool = "HighSchool";
                    public const string HighSchoolEndDate = "HighSchoolEndDate";
                    public const string HighSchoolGradeSystem = "HighSchoolGradeSystem";
                    public const string HighSchoolGraduationGrade = "HighSchoolGraduationGrade";
                }
                #endregion

                #region Get Functions
                public static DataTable Get(int cvId)
                {
                    return CVsProvider.GetCVHighSchoolInfo(null,cvId).Tables[0];
                }
                #endregion

                #region Update Functions
                public static int Update(int cvId, string highSchool, DateTime highSchoolEndDate, 
                    int highSchoolGradeSystem,decimal highSchoolGraduationGrade,
                    DateTime modifyDate)
                {
                    return CVsProvider.UpdateCVHighSchoolInfo(null,cvId,highSchool,highSchoolEndDate, 
                        highSchoolGradeSystem,highSchoolGraduationGrade,modifyDate);
                }
                public static int Update(SqlTransaction tran,int cvId, string highSchool, 
                    DateTime highSchoolEndDate,int highSchoolGradeSystem,decimal highSchoolGraduationGrade,
                    DateTime modifyDate)
                {
                    return CVsProvider.UpdateCVHighSchoolInfo(tran, cvId, highSchool, highSchoolEndDate,
                        highSchoolGradeSystem, highSchoolGraduationGrade, modifyDate);
                }
                #endregion
            }
        }
    }
}
