using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using GSUKariyer.DAL;

namespace GSUKariyer.BUS {
    public class AdminLogin
    {
        public static int Login(string UserName, string Password)
        {
            return AdminLoginProvider.Login(UserName, Password);
        }

        public static DataTable GetUserPermission(int AdminID)
        {
            return AdminLoginProvider.GetUserPermission(AdminID);
        }
    }
}
