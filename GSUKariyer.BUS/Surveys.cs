using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using GSUKariyer.DAL;
using GSUKariyer.COMMON.Exceptions;

namespace GSUKariyer.BUS {

	public partial class Surveys {

        public enum State
        {
            Passive=0,
            Active=1
        }

        public static DataSet GetActive()
        {
            return SurveysProvider.GetActive((int)State.Active);
        }

        public static bool HasVoted(int UserId)
        {
            return SurveysProvider.HasVoted(UserId) > 0;
        }

        public static DataTable GetSurveyList(int? surveyId)
        {
            return SurveysProvider.GetSurveyList(surveyId).Tables[0];
        }
	
	}
}
