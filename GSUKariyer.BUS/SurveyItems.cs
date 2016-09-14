using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using GSUKariyer.DAL;
using GSUKariyer.COMMON.Exceptions;

namespace GSUKariyer.BUS {

	public partial class SurveyItems {

        protected static object objSelectItem = null;

        #region Constructers
        static SurveyItems()
        {
            objSelectItem = new object();
        }
        #endregion

    }
}
