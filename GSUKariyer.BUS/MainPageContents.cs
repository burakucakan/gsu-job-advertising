using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using GSUKariyer.DAL;
using GSUKariyer.COMMON.Exceptions;
using GSUKariyer.COMMON;

namespace GSUKariyer.BUS {

	public partial class MainPageContents
    {

        #region CustomColumnNames
        public struct CustomColumnNames
        {
            public const string AdvertisementCount = "AdvertisementCount";
            public const string FirmCount = "FirmCount";
        }
        #endregion

        public static DataSet GetAdvertisements()
        {
            return MainPageContentsProvider.GetAdvertisements(DateTime.Now);
        }

        public static DataTable GetAnnouncements()
        {
            return MainPageContentsProvider.GetAnnouncements((int)SiteContents.Type.Announcements).Tables[0];
        }

        public static DataTable GetCareerPlanings()
        {
            return MainPageContentsProvider.GetCareerPlanings((int)SiteContents.Type.Announcements).Tables[0];
        }
	
	}
}
