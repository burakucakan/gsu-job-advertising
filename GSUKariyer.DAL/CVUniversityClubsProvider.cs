using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using GSUKariyer.COMMON.Helpers.DAL;
using GSUKariyer.COMMON.Exceptions;

namespace GSUKariyer.DAL {

	public partial class CVUniversityClubsProvider
    {

        #region Get Functions
        public static DataSet GetGsClubs(SqlTransaction tran,int cvId)
        {
            SqlParameter[] sqlParams = new SqlParameter[] { 
					new SqlParameter("@CVId",cvId)
                };

            if (tran == null)
                return Generated.GetByParams(sqlParams);
            else
                return Generated.GetByParams(tran, sqlParams);
        }
        #endregion

    }
}
