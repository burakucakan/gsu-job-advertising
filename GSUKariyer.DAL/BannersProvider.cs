using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using GSUKariyer.COMMON.Helpers.DAL;
using GSUKariyer.COMMON.Exceptions;

namespace GSUKariyer.DAL {

	public partial class BannersProvider
    {

        #region Custom Get Functions
        public static DataSet Get(string pageName,string allPagesName,DateTime businessDate,
            int pageLocation)
        {
            SqlParameter[] sqlParams = null;

            try
            {
                DataSet ds = null;

                sqlParams = new SqlParameter[] { 
                    new SqlParameter("@PageName",pageName),
                    new SqlParameter("@AllPagesName",allPagesName),
                    new SqlParameter("@PageLocation",pageLocation),
					new SqlParameter("@BusinessDate",businessDate)
                };

                ds = ExecuteDataset("BGA_CustomGetBanner", sqlParams);

                return ds;
            }
            catch (Exception ex)
            {
                throw new MyException(ex.Message, "BannersProvider", "Get", ArrangeParamValues(sqlParams));
            }
        }
        #endregion

    }
}
