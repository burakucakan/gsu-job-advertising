using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using GSUKariyer.COMMON.Helpers.DAL;
using GSUKariyer.COMMON.Exceptions;

namespace GSUKariyer.DAL {

	public partial class AdvertisementsProvider
    {
        #region Get Functions
        public static DataSet GetDetail(int? advertisementId,int? firmId)
        {
            SqlParameter[] sqlParams = null;

            try
            {
                DataSet ds = null;

                sqlParams = new SqlParameter[] { 
					new SqlParameter("@AdvertisementId",advertisementId),
                    new SqlParameter("@FirmId",firmId),
                };

                ds = ExecuteDataset("BGA_CustomGetAdvertisementDetail", sqlParams);

                return ds;
            }
            catch (Exception ex)
            {
                throw new MyException(ex.Message, "AdvertisementsProvider", "GetDetail", ArrangeParamValues(sqlParams));
            }
        }

        public static DataSet GetSuitableAdvCriterias(int userId, int activeCvState)
        {
            SqlParameter[] sqlParams = null;

            try
            {
                DataSet ds = null;

                sqlParams = new SqlParameter[] { 
					new SqlParameter("@UserId",userId),
                    new SqlParameter("@ActiveCvState",activeCvState),
                };

                ds = ExecuteDataset("BGA_CustomGetUsersSuitableAdvCriterias", sqlParams);

                return ds;
            }
            catch (Exception ex)
            {
                throw new MyException(ex.Message, "AdvertisementsProvider", "GetSuitableAdvCriterias", ArrangeParamValues(sqlParams));
            }
        }

        public static DataSet GetTop5AdvertisementCityCountry(DateTime businessDate)
        {
            SqlParameter[] sqlParams = null;

            try
            {
                DataSet ds = null;

                sqlParams = new SqlParameter[] { 
                    new SqlParameter("@BusinessDate",businessDate)
                };

                ds = ExecuteDataset("BGA_CustomGetTop5AdvertisementCityCountry", sqlParams);

                return ds;
            }
            catch (Exception ex)
            {
                throw new MyException(ex.Message, "AdvertisementsProvider", "GetTop5AdvertisementCityCountry", ArrangeParamValues(sqlParams));
            }
        }

        public static DataSet GetTop5AdvertisementFirm(DateTime businessDate)
        {
            SqlParameter[] sqlParams = null;

            try
            {
                DataSet ds = null;

                sqlParams = new SqlParameter[] { 
                    new SqlParameter("@BusinessDate",businessDate)
                };

                ds = ExecuteDataset("BGA_CustomGetTop5AdvertisementFirms", sqlParams);

                return ds;
            }
            catch (Exception ex)
            {
                throw new MyException(ex.Message, "AdvertisementsProvider", "GetTop5AdvertisementFirm", ArrangeParamValues(sqlParams));
            }
        }

        public static DataSet GetTop5AdvertisementSector(DateTime businessDate)
        {
            SqlParameter[] sqlParams = null;

            try
            {
                DataSet ds = null;

                sqlParams = new SqlParameter[] { 
                    new SqlParameter("@BusinessDate",businessDate)
                };

                ds = ExecuteDataset("BGA_CustomGetTop5AdvertisementSectors", sqlParams);

                return ds;
            }
            catch (Exception ex)
            {
                throw new MyException(ex.Message, "AdvertisementsProvider", "GetTop5AdvertisementSector", ArrangeParamValues(sqlParams));
            }
        }

        public static DataSet GetFirmActiveAdvertisements(DateTime businessDate,int firmId)
        {
            SqlParameter[] sqlParams = null;

            try
            {
                DataSet ds = null;

                sqlParams = new SqlParameter[] { 
                    new SqlParameter("@FirmId",firmId),
                    new SqlParameter("@BusinessDate",businessDate)
                };

                ds = ExecuteDataset("BGA_CustomGetFirmActiveAdvertisements", sqlParams);

                return ds;
            }
            catch (Exception ex)
            {
                throw new MyException(ex.Message, "AdvertisementsProvider", "GetFirmActiveAdvertisements", ArrangeParamValues(sqlParams));
            }
        }

        public static DataSet Search(DateTime businessDate,string searchKeyword,string firmName,
            DateTime? dateStart,DateTime? dateEnd,string sector1,string sector2,string sector3,string sector4,
            string sector5,string position1, string position2, string position3, string position4, 
            string position5,int? city1,int? city2,int? city3,int? city4,int? city5,int? country1,int? country2,
            int? country3,int? country4, int? country5, int? workType1, int? workType2, int? workType3, 
            int? workType4,int? workType5,bool searchUserFollowedFirms,int? userId,int liveState,
            bool isDeleted)
        {
            SqlParameter[] sqlParams = null;

            try
            {
                DataSet ds = null;

                sqlParams = new SqlParameter[] { 
                    new SqlParameter("@BusinessDate",businessDate),
					new SqlParameter("@SearchKeyword",searchKeyword),
                    new SqlParameter("@FirmName",firmName),
                    new SqlParameter("@DateStart",dateStart),
                    new SqlParameter("@DateEnd",dateEnd),
                    new SqlParameter("@Sector1",sector1),
                    new SqlParameter("@Sector2",sector2),
                    new SqlParameter("@Sector3",sector3),
                    new SqlParameter("@Sector4",sector4),
                    new SqlParameter("@Sector5",sector5),
                    new SqlParameter("@Position1",position1),
                    new SqlParameter("@Position2",position2),
                    new SqlParameter("@Position3",position3),
                    new SqlParameter("@Position4",position4),
                    new SqlParameter("@Position5",position5),
                    new SqlParameter("@City1",city1),
                    new SqlParameter("@City2",city2),
                    new SqlParameter("@City3",city3),
                    new SqlParameter("@City4",city4),
                    new SqlParameter("@City5",city5),
                    new SqlParameter("@Country1",country1),
                    new SqlParameter("@Country2",country2),
                    new SqlParameter("@Country3",country3),
                    new SqlParameter("@Country4",country4),
                    new SqlParameter("@Country5",country5),
                    new SqlParameter("@WorkType1",workType1),
                    new SqlParameter("@WorkType2",workType2),
                    new SqlParameter("@WorkType3",workType3),
                    new SqlParameter("@WorkType4",workType4),
                    new SqlParameter("@WorkType5",workType5),
                    new SqlParameter("@SearchUserFollowedFirms",searchUserFollowedFirms),
                    new SqlParameter("@UserId",userId),
                    new SqlParameter("@LiveState",liveState),
                    new SqlParameter("@IsDeleted",isDeleted)
                };
                             
                ds = ExecuteDataset("BGA_CustomSearchAdvertisement", sqlParams);

                return ds;
            }
            catch (Exception ex)
            {
                throw new MyException(ex.Message, "AdvertisementsProvider", "Search", ArrangeParamValues(sqlParams));
            }
        }
        #endregion

        public static DataSet GetFirmAdvertisements(int FirmId, int NewAppState, int AdvertisementState, string Title, DateTime StartDate, DateTime EndDate)
        {
            SqlParameter[] sqlParams = null;

            try
            {
                DataSet ds = null;

                sqlParams = new SqlParameter[6];
                sqlParams[0] = new SqlParameter("@FirmId", FirmId);
                sqlParams[1] = new SqlParameter("@NewAppState", NewAppState);
                sqlParams[2] = new SqlParameter("@AdvertisementState", AdvertisementState);

                if (Title == "") sqlParams[3] = new SqlParameter("@Title", DBNull.Value);
                else sqlParams[3] = new SqlParameter("@Title", Title);

                if (StartDate == DateTime.MinValue) sqlParams[4] = new SqlParameter("@StartDate", DBNull.Value);
                else sqlParams[4] = new SqlParameter("@StartDate", StartDate);

                if (EndDate == DateTime.MaxValue) sqlParams[5] = new SqlParameter("@EndDate", DBNull.Value);
                else sqlParams[5] = new SqlParameter("@EndDate", EndDate);                

                ds = ExecuteDataset("BGA_CustomGetFirmAdvertisements", sqlParams);

                return ds;
            }
            catch (Exception ex)
            {
                throw new MyException(ex.Message, "AdvertisementsProvider", "GetFirmAdvertisements", ArrangeParamValues(sqlParams));
            }
        }

        public static DataSet GetLastFirmAdvertisements(int FirmId, int NewAppState, int AdvertisementState)
        {
            SqlParameter[] sqlParams = null;

            try
            {
                DataSet ds = null;

                sqlParams = new SqlParameter[] { 
					new SqlParameter("@FirmId",FirmId),
                    new SqlParameter("@NewAppState",NewAppState),
                    new SqlParameter("@AdvertisementState",AdvertisementState)
                };

                ds = ExecuteDataset("BGA_CustomGetLastFirmAdvertisements", sqlParams);

                return ds;
            }
            catch (Exception ex)
            {
                throw new MyException(ex.Message, "AdvertisementsProvider", "GetLastFirmAdvertisements", ArrangeParamValues(sqlParams));
            }
        }

        
    }
}
