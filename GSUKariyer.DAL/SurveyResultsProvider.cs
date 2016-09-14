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

    public partial class SurveyResultsProvider
    {

        public static DataSet GetSurveyResults()
        {
            SqlParameter[] sqlParams = null;

            try
            {
                DataSet ds = null;
                ds = ExecuteDataset("BGA_CustomGetSurveyResults");

                return ds;
            }
            catch (Exception ex)
            {
                throw new MyException(ex.Message, "SurveyResultsProvider", "GetSurveyResults", ArrangeParamValues(sqlParams));
            }
        }

    }
}
