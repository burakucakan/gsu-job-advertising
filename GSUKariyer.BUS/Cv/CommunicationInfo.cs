using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using GSUKariyer.DAL;
using GSUKariyer.COMMON;
using GSUKariyer.COMMON.Exceptions;

namespace GSUKariyer.BUS
{
    public partial class CVs
    {
        public class CommunicationInfo
        {
            #region ColumnNames
            public struct ColumnNames
            {
                public const string HomePhone = "HomePhone";
                public const string MobilePhone1 = "MobilePhone1";
                public const string MobilePhone2 = "MobilePhone2";
                public const string Email = "Email";
                public const string Webpage = "Webpage";
                public const string ContactType = "ContactType";
            }
            #endregion

            #region Get Functions
            public static DataTable Get(int cvId)
            {
                return CVsProvider.GetCVCommunicationInfo(null, cvId).Tables[0];
            }
            #endregion

            #region Update Functions
            public static int Update(int cvId, string homePhone,
                string mobilePhone1, string mobilePhone2, string email, string webpage, int contactType,
                DateTime modifyDate)
            {
                return CVsProvider.UpdateCVCommunicationInfo(null, cvId, homePhone, mobilePhone1, mobilePhone2,
                    email, webpage, contactType, modifyDate);
            }
            #endregion
        }
    }
}
