using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using GSUKariyer.DAL;
using GSUKariyer.COMMON.Exceptions;

namespace GSUKariyer.BUS {

	public partial class Advertisements
    {
        public enum WorkType
        {
            Fulltime=1,
            Parttime=2,
            DomesticInternship=3,
            AbroadInternship=4
        }

        public enum State
        {
            Live = 1,
            Archive = 2,
        }

        #region CustomColumnNames
        public struct CustomColumnNames
        {
            public const string FirmId = "FirmId";
            public const string FirmName = "FirmName";
            public const string FirmSector = "FirmSector";
        }
        #endregion

        #region Get Functions
        public static DataTable GetDetail(int id)
        {
            return AdvertisementsProvider.GetDetail(id, null).Tables[0];
        }

        public static DataTable GetLastFirmAdvertisements(int FirmId) {
            return AdvertisementsProvider.GetLastFirmAdvertisements(FirmId, (int)AdvertisementApplications.State.NotViewed, (int)Advertisements.State.Live).Tables[0];
        }

        public static DataTable GetFirmAdvertisements(int FirmId, Advertisements.State AdvertisementsState)
        {
            return AdvertisementsProvider.GetFirmAdvertisements(FirmId, (int)AdvertisementApplications.State.NotViewed, (int)AdvertisementsState, "", DateTime.MinValue, DateTime.MaxValue).Tables[0];
        }

        public static DataTable GetFirmAdvertisements(int FirmId, State AdvertisementState, string Title, DateTime StartDate, DateTime EndDate)
        {
            return AdvertisementsProvider.GetFirmAdvertisements(FirmId, (int)AdvertisementApplications.State.NotViewed, (int)AdvertisementState, Title, StartDate, EndDate).Tables[0];
        }

        #endregion

        public static bool Passive(int AdvertisementId, int ModifyBy)
        {
            return Advertisements.Generated.UpdateByParams(
                new SqlParameter(ColumnNames.ID, AdvertisementId),
                new SqlParameter(ColumnNames.ModifyBy, ModifyBy),
                new SqlParameter(ColumnNames.ModifyDate, DateTime.Now),
                new SqlParameter(ColumnNames.State, State.Archive)
                ) > 0;
        }

        public static bool Active(int AdvertisementId, int ModifyBy)
        {
            return Advertisements.Generated.UpdateByParams(
                new SqlParameter(ColumnNames.ID, AdvertisementId),
                new SqlParameter(ColumnNames.ModifyBy, ModifyBy),
                new SqlParameter(ColumnNames.ModifyDate, DateTime.Now),
                new SqlParameter(ColumnNames.State, State.Live)
                ) > 0;
        }

        public static bool Delete(int AdvertisementId, int ModifyBy) {
            return Advertisements.Generated.UpdateByParams(
                new SqlParameter(ColumnNames.ID, AdvertisementId),                
                new SqlParameter(ColumnNames.ModifyBy, ModifyBy),
                new SqlParameter(ColumnNames.ModifyDate, DateTime.Now),
                new SqlParameter(ColumnNames.IsDeleted, true)
                ) > 0;
        }
    }
}
