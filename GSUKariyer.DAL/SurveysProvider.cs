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

    public partial class SurveysProvider
    {

        public static DataSet GetActive(int activeState)
        {
            SqlParameter[] sqlParams = null;

            try
            {
                DataSet ds = null;

                sqlParams = new SqlParameter[] { 
					new SqlParameter("@SurveyActiveState",activeState)
                };

                ds = ExecuteDataset("BGA_CustomGetSurvey", sqlParams);

                return ds;
            }
            catch (Exception ex)
            {
                throw new MyException(ex.Message, "SurveysProvider", "GetActive", ArrangeParamValues(sqlParams));
            }
        }

        public static DataSet GetSurveyList(int? surveyId)
        {
            SqlParameter[] sqlParams = null;

            try
            {
                DataSet ds = null;

                sqlParams = new SqlParameter[] { 
					new SqlParameter("@SurveyId",surveyId)
                };

                ds = ExecuteDataset("BGA_CustomGetSurveyList", sqlParams);

                return ds;
            }
            catch (Exception ex)
            {
                throw new MyException(ex.Message, "SurveysProvider", "GetSurveyList", ArrangeParamValues(sqlParams));
            }
        }

        public static int HasVoted(int UserId)
        {
            SqlParameter[] sqlParams = null;

            try
            {               
                sqlParams = new SqlParameter[] { 
					new SqlParameter("@UserId", UserId)
                };

                return Convert.ToInt32(ExecuteDataset("BGA_CustomSurveyHasVoted", sqlParams).Tables[0].Rows[0][0]);
            }
            catch (Exception ex)
            {
                throw new MyException(ex.Message, "SurveysProvider", "HasVoted", ArrangeParamValues(sqlParams));
            }
        }

    }
}
