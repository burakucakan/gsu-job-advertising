using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using GSUKariyer.COMMON.Helpers.DAL;
using GSUKariyer.COMMON.Exceptions;

namespace GSUKariyer.DAL {

	public partial class UserEmailsProvider {

        public static int Truncate(SqlTransaction tran)
        {
            try
            {
                if (tran==null)
                    return ExecuteNonQuery("BGA_CustomTruncateUserEmails");
                else
                    return ExecuteNonQuery(tran,"BGA_CustomTruncateUserEmails");
            }
            catch (Exception ex)
            {
                throw new MyException(ex.Message, "UserEmailsProvider", "Truncate");
            }
        }
	}
}
