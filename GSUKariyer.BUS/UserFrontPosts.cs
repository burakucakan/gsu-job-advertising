using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using GSUKariyer.DAL;
using GSUKariyer.COMMON.Exceptions;

namespace GSUKariyer.BUS {

	public partial class UserFrontPosts {

        public static DataTable GetByUserId(int UserId)
        {
            DataTable dt = UserFrontPosts.Generated.GetByParams(
                            new SqlParameter("UserId", UserId)
                            );
            dt.DefaultView.Sort = "ID DESC";
            return dt.DefaultView.Table;
        }
	
	}
}
