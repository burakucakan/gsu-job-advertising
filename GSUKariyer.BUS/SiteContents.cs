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

	public partial class SiteContents {

        public enum Type
        {
            Announcements=0,
            Interview=1,
            SuccessStories=2,
            Articles=3
        }
        
        public static DataTable GetSiteContentList(int ContentType)
        {
            return SiteContentsProvider.Generated.GetByParams(new SqlParameter("ContentType", ContentType)).Tables[0];
        }

        public static bool Delete(ArrayList arrIDs)
        {
            SqlConnection conn = new SqlConnection(AdminPermissionsProvider.GetConnectionString());
            conn.Open();

            SqlTransaction tran = conn.BeginTransaction(IsolationLevel.Serializable);

            try
            {
                for (int i = 0; i < arrIDs.Count; i++)
                {
                    if (Util.IsNumeric(arrIDs[i]))
                        SiteContentsProvider.Generated.Delete(tran, Convert.ToInt32(arrIDs[i]));
                }
                tran.Commit();
                return true;
            }
            catch (Exception)
            {
                tran.Rollback();
                return false;
            }
        }
	}
}
