using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using GSUKariyer.DAL;
using GSUKariyer.COMMON.Exceptions;

namespace GSUKariyer.BUS {

	public partial class FirmUsers {


        public static DataTable GetFirmUser(int FirmId)
        {
            return FirmUsers.Generated.GetByParams(
                            new SqlParameter("FirmId", FirmId)
                            );
        }

        public static bool HasUser(string Email)
        {
            return FirmUsers.Generated.GetByParams(
                new SqlParameter(ColumnNames.Email, Email)
                ).Rows.Count > 0;
        }

        public static DataTable GetFirmByEmail(string Email)
        {
            return FirmUsers.Generated.GetByParams(
                            new SqlParameter("Email", Email)
                            );
        }
	}
}
