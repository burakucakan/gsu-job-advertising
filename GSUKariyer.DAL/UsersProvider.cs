using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using GSUKariyer.COMMON.Helpers.DAL;
using GSUKariyer.COMMON.Exceptions;

namespace GSUKariyer.DAL {

	public partial class UsersProvider {

        public static bool UserActivate(string ActivationCode)
        {
            SqlParameter[] sqlParams = null;

            try
            {
                sqlParams = new SqlParameter[] { 
                    new SqlParameter("@ActivationCode", ActivationCode)
                };

                //return ExecuteScalar("BGA_CustomUserActivate", sqlParams);
                return ExecuteNonQuery("BGA_CustomUserActivate", sqlParams) > 0;
            }
            catch (Exception ex)
            {
                throw new MyException(ex.Message, "UsersProvider", "Get", ArrangeParamValues(sqlParams));
            }
        }

        public static DataSet UserLogin(string StudentNumber, string Password)
        {
            SqlParameter[] sqlParams = null;

            try
            {
               sqlParams = new SqlParameter[] { 
                    new SqlParameter("@StudentNumber", StudentNumber),
                    new SqlParameter("@Password", Password)
                };

                return ExecuteDataset("BGA_CustomUserLogin", sqlParams);
            }
            catch (Exception ex)
            {
                throw new MyException(ex.Message, "UsersProvider", "Get", ArrangeParamValues(sqlParams));
            }
        }

        public static DataSet Search(int? educationState, int? ageStart,int? ageEnd,int? workExperienceInMonth,
            int? workingStatus, int? interestedWorkType, int? univDeparment1, int? univDeparment2, 
            int? univDeparment3,int? univDeparment4, int? univDeparment5, int? language1, int? language2, 
            int? language3,int? language1TalkGrade, int? language2TalkGrade, int? language3TalkGrade,
            int? language1WriteGrade, int? language2WriteGrade, int? language3WriteGrade,
            int? language1ReadGrade, int? language2ReadGrade, int? language3ReadGrade,
            int? gsClub1, int? gsClub2, int? gsClub3, int? gsClub4, int? gsClub5, int? certificate1,
            int? certificate2, int? certificate3, int? certificate4, int? certificate5,string position1,
            string position2,string position3,string position4,string position5,int cvActiveState,
            bool cvIsDefault, bool userIsActive)
        {
            SqlParameter[] sqlParams = null;

            try
            {

                sqlParams = new SqlParameter[] { 
                    new SqlParameter("@EducationState", educationState),
                    new SqlParameter("@AgeStart", ageStart),
                    new SqlParameter("@AgeEnd", ageEnd),
                    new SqlParameter("@WorkExperienceInMonth", workExperienceInMonth),
                    new SqlParameter("@WorkingStatus", workingStatus),
                    new SqlParameter("@InterestedWorkType",interestedWorkType),
                    new SqlParameter("@UnivDeparment1", univDeparment1),
                    new SqlParameter("@UnivDeparment2", univDeparment2),
                    new SqlParameter("@UnivDeparment3", univDeparment3),
                    new SqlParameter("@UnivDeparment4", univDeparment4),
                    new SqlParameter("@UnivDeparment5", univDeparment5),
                    new SqlParameter("@Language1", language1),
                    new SqlParameter("@Language2", language2),
                    new SqlParameter("@Language3", language3),
                    new SqlParameter("@Language1TalkGrade", language1TalkGrade),
                    new SqlParameter("@Language2TalkGrade", language2TalkGrade),
                    new SqlParameter("@Language3TalkGrade", language3TalkGrade),
                    new SqlParameter("@Language1WriteGrade", language1WriteGrade),
                    new SqlParameter("@Language2WriteGrade", language2WriteGrade),
                    new SqlParameter("@Language3WriteGrade", language3WriteGrade),
                    new SqlParameter("@Language1ReadGrade", language1ReadGrade),
                    new SqlParameter("@Language2ReadGrade", language2ReadGrade),
                    new SqlParameter("@Language3ReadGrade", language3ReadGrade),
                    new SqlParameter("@GsClub1", gsClub1),
                    new SqlParameter("@GsClub2", gsClub2),
                    new SqlParameter("@GsClub3", gsClub3),
                    new SqlParameter("@GsClub4", gsClub4),
                    new SqlParameter("@GsClub5", gsClub5),
                    new SqlParameter("@Certificate1", certificate1),
                    new SqlParameter("@Certificate2", certificate2),
                    new SqlParameter("@Certificate3", certificate3),
                    new SqlParameter("@Certificate4", certificate4),
                    new SqlParameter("@Certificate5", certificate5),
                    new SqlParameter("@Position1", position1),
                    new SqlParameter("@Position2", position2),
                    new SqlParameter("@Position3", position3),
                    new SqlParameter("@Position4", position4),
                    new SqlParameter("@Position5", position5),
                    new SqlParameter("@CVActiveState", cvActiveState),
                    new SqlParameter("@CVIsDefault", cvIsDefault),
                    new SqlParameter("@UserIsActive", userIsActive)
                };

                return ExecuteDataset("BGA_CustomSearchUser", sqlParams);
            }
            catch (Exception ex)
            {
                string innerstr="";
                if (ex.InnerException != null)
                    innerstr = ex.InnerException.ToString();
                throw new MyException(ex.Message, "UsersProvider", "Search", ArrangeParamValues(sqlParams));
            }
        }

        #region Delete Functions
        public static int CustomDelete(SqlTransaction tran,int userId)
        {
            SqlParameter[] sqlParams = null;

                try
                {

                    sqlParams = new SqlParameter[] { 
					new SqlParameter("@UserId",userId)
                };

                    if (tran==null)
                        return ExecuteNonQuery("BGA_CustomDeleteUser", sqlParams);
                    else
                        return ExecuteNonQuery(tran,"BGA_CustomDeleteUser", sqlParams);

                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "UsersProvider", "CustomDelete", ArrangeParamValues(sqlParams));
                }
        }
        #endregion
    }
}
