using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using GSUKariyer.COMMON.Helpers.DAL;
using GSUKariyer.COMMON.Exceptions;

namespace GSUKariyer.DAL {

	public partial class FirmsProvider {

        public static DataSet Login(string Email, string Password)
        {
            SqlParameter[] sqlParams = null;

            try
            {
                sqlParams = new SqlParameter[] { 
                    new SqlParameter("@Email", Email),
                    new SqlParameter("@Password", Password)
                };

                return ExecuteDataset("BGA_CustomFirmLogin", sqlParams);
            }
            catch (Exception ex)
            {
                throw new MyException(ex.Message, "FirmsProvider", "Get", ArrangeParamValues(sqlParams));
            }
        }
	
	}
}
