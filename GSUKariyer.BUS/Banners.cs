using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using GSUKariyer.DAL;
using GSUKariyer.COMMON.Exceptions;
using System.Globalization;

namespace GSUKariyer.BUS {

	public partial class Banners {
	    
        #region Enums
        public enum PublishType
        {
            Static=0
        }
        public enum PageLocation
        {
            Right=0
        }
        public struct PageName
        {
            public const string All = "All";
        }
        #endregion

        #region Get Functions
        public static DataTable Get(string pageName,PageLocation pageLocation)
        {
            return BannersProvider.Get(pageName.ToLower(new CultureInfo("en-US", false)), PageName.All,
                DateTime.Now, (int)pageLocation).Tables[0];
        }
        #endregion

    }
}
