using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using GSUKariyer.COMMON;
using GSUKariyer.COMMON.Helpers.DAL;

namespace GSUKariyer.DAL
{
    public class AdminLoginProvider : BaseDataLayer
    {
        public static int Login(string UserName, string Password)
        {
            try
            {
                DataTable dt = ExecuteDataset("BGA_CustomAdminLogin",
                    new SqlParameter("@UserName", Util.r(UserName)),
                    new SqlParameter("@Password", Encryption.Encrypt(Util.r(Password)))
                    ).Tables[0];
                if (dt != null)
                {
                    DataRow dr = dt.Rows[0];
                    if (dr != null)
                        return Convert.ToInt32(dr["AdminID"]);
                }
                return 0;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public static DataTable GetUserPermission(int AdminID)
        {
            try
            {
                return ExecuteDataset("BGA_CustomGetAdminPermissions",
                    new SqlParameter("@AdminID", AdminID)).Tables[0];
            }
            catch (Exception)
            {
                return null;
            }
        }        
    }
}
