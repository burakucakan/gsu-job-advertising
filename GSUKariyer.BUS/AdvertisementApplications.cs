using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using GSUKariyer.DAL;
using GSUKariyer.COMMON.Exceptions;

namespace GSUKariyer.BUS {

	public partial class AdvertisementApplications {

        public enum State
        {
            Viewed = 1,
            NotViewed = 2,
            Answered = 3
        }

        public static bool IsApplied(int AdvertisementId, int UserId) {
            return BUS.AdvertisementApplications.Generated.GetByParams(new SqlParameter("AdvertisementId", AdvertisementId),
                new SqlParameter("UserId", UserId)).Rows.Count > 0;
        }

        public static DataTable GetAdvertisementApplication(int AdvertisementId, int UserId)
        {
            return BUS.AdvertisementApplications.Generated.GetByParams(new SqlParameter("AdvertisementId", AdvertisementId),
                new SqlParameter("UserId", UserId));
        }

        public static DataTable GetUserApplications(int UserId)
        {
            return AdvertisementApplicationsProvider.GetUserApplications(UserId).Tables[0];
        }

        public static DataTable GetUserApplicationsTop(int UserId)
        {
            return AdvertisementApplicationsProvider.GetUserApplicationsTop(UserId).Tables[0];
        }

        public static bool Read(int AdvertisementApplicationID)
        {
            return AdvertisementApplicationsProvider.Generated.UpdateByParams(
                new SqlParameter(BUS.AdvertisementApplications.ColumnNames.ID, AdvertisementApplicationID),
                new SqlParameter(BUS.AdvertisementApplications.ColumnNames.IsRead, true)) > 0;
        }


        public static DataTable GetApplications(int FirmId, int AdvertisementId)
        {
            return AdvertisementApplicationsProvider.GetApplications(FirmId, AdvertisementId).Tables[0];
        }

        public static DataTable GetApplicationsTop(int FirmId)
        {
            return AdvertisementApplicationsProvider.GetApplicationsTop(FirmId).Tables[0];
        }


        #region Update Functions
        public static int Update(int applicationId, string advertisementAnswer, int state, DateTime modifyDate)
        {
            return AdvertisementApplicationsProvider.Update(applicationId, advertisementAnswer, state, modifyDate);
        }
        #endregion
    }
}
