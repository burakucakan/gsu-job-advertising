using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using GSUKariyer.COMMON.Helpers.DAL;
using GSUKariyer.COMMON.Exceptions;

namespace GSUKariyer.DAL {

	public partial class AdvertisementApplicationsProvider {

        public static DataSet GetUserApplications(int UserId)
        {
            SqlParameter[] sqlParams = null;

            try
            {
                sqlParams = new SqlParameter[] { 
                    new SqlParameter("@UserId", UserId)
                };

                return ExecuteDataset("BGA_CustomGetUserApplications", sqlParams);
            }
            catch (Exception ex)
            {
                throw new MyException(ex.Message, "AdvertisementApplicationsProvider", "BGA_CustomGetUserApplications", ArrangeParamValues(sqlParams));
            }
        }

        public static DataSet GetUserApplicationsTop(int UserId)
        {
            SqlParameter[] sqlParams = null;

            try
            {
                sqlParams = new SqlParameter[] { 
                    new SqlParameter("@UserId", UserId)
                };

                return ExecuteDataset("BGA_CustomGetUserApplicationsTop", sqlParams);
            }
            catch (Exception ex)
            {
                throw new MyException(ex.Message, "AdvertisementApplicationsProvider", "BGA_CustomGetUserApplicationsTop", ArrangeParamValues(sqlParams));
            }
        }

        public static DataSet GetApplications(int FirmId, int AdvertisementId)
        {
            SqlParameter[] sqlParams = null;

            try
            {
                sqlParams = new SqlParameter[2];
                sqlParams[0] = new SqlParameter("@FirmId", FirmId);
                sqlParams[1] = (AdvertisementId == 0) ? 
                    new SqlParameter("@AdvertisementId", DBNull.Value) : 
                    new SqlParameter("@AdvertisementId", AdvertisementId);

                return ExecuteDataset("BGA_CustomGetApplications", sqlParams);
            }
            catch (Exception ex)
            {
                throw new MyException(ex.Message, "AdvertisementApplicationsProvider", "BGA_CustomGetApplications", ArrangeParamValues(sqlParams));
            }
        }

        public static DataSet GetApplicationsTop(int FirmId)
        {
            SqlParameter[] sqlParams = null;

            try
            {
                sqlParams = new SqlParameter[1];
                sqlParams[0] = new SqlParameter("@FirmId", FirmId);

                return ExecuteDataset("BGA_CustomGetApplicationsTop", sqlParams);
            }
            catch (Exception ex)
            {
                throw new MyException(ex.Message, "AdvertisementApplicationsProvider", "BGA_CustomGetApplicationsTop", ArrangeParamValues(sqlParams));
            }
        }


        #region Update Functions
        public static int Update(int applicationId, string advertisementAnswer, int state, DateTime modifyDate)
        {
            SqlParameter[] sqlparams = new SqlParameter[]{
                new SqlParameter("@ID",applicationId),
				new SqlParameter("@AdvertisementAnswer",advertisementAnswer),
			    new SqlParameter("@State",state),
				new SqlParameter("@ModifyDate",modifyDate),
            };

            return Generated.UpdateByParams(sqlparams);
        }
        #endregion
	}
}
