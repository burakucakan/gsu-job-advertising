using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using GSUKariyer.COMMON.Helpers.DAL;
using GSUKariyer.COMMON.Exceptions;

namespace GSUKariyer.DAL {

	public partial class MainPageContentsProvider
    {

        #region Custom Get Functions
        public static DataSet GetAdvertisements(DateTime businessDate)
        {
            SqlParameter[] sqlParams = null;

            try
            {
                DataSet ds = null;

                sqlParams = new SqlParameter[] { 
					new SqlParameter("@BusinessDate",businessDate)
                };

                ds = ExecuteDataset("BGA_CustomGetMainAdvertisements", sqlParams);
               
                return ds;
            }
            catch (Exception ex)
            {
                throw new MyException(ex.Message, "MainPageContentsProvider", "GetAdvertisements", ArrangeParamValues(sqlParams));
            }		
        }

        public static DataSet GetAnnouncements(int announcementContentType)
        {
            SqlParameter[] sqlParams = null;

            try
            {
                DataSet ds = null;

                sqlParams = new SqlParameter[] { 
					new SqlParameter("@AnnouncementContentType",announcementContentType)
                };

                ds = ExecuteDataset("BGA_CustomGetMainAnnouncements", sqlParams);

                return ds;
            }
            catch (Exception ex)
            {
                throw new MyException(ex.Message, "MainPageContentsProvider", "GetAnnouncements", ArrangeParamValues(sqlParams));
            }
        }

        public static DataSet GetCareerPlanings(int AnnouncementTypeCode)
        {
            SqlParameter[] sqlParams = null;

            try
            {
                DataSet ds = null;

                sqlParams = new SqlParameter[] { 
					new SqlParameter("@AnnouncementTypeCode",AnnouncementTypeCode)
                };

                ds = ExecuteDataset("BGA_CustomGetMainCareerPlanings", sqlParams);

                return ds;
            }
            catch (Exception ex)
            {
                throw new MyException(ex.Message, "MainPageContentsProvider", "GetCareerPlanings", ArrangeParamValues(sqlParams));
            }
        }
        #endregion

    }
}
