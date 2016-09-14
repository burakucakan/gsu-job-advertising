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
        public class PersonalInfo
        {
            #region ColumnNames
            public struct ColumnNames
            {
                public const string Name = "Name";
                public const string Surname = "Surname";
                public const string BirthDate = "BirthDate";
                public const string Gender = "Gender";
                public const string MaritalStatus = "MaritalStatus";
                public const string BirthPlaceCountry = "BirthPlaceCountry";
                public const string BirthPlaceCity = "BirthPlaceCity";
                public const string BirthPlaceCityFree = "BirthPlaceCityFree";
                public const string Nationality = "Nationality";
            }
            #endregion

            #region Get Functions
            public static DataTable Get(int cvId)
            {
                return CVsProvider.GetCVPersonalInfo(null, cvId).Tables[0];
            }
            #endregion

            #region Update Functions
            public static int Update(int cvId, int maritalStatus, int birthPlaceCountry, int birthPlaceCity,
                string birthPlaceCityFree, int nationality, DateTime modifyDate)
            {
                return CVsProvider.UpdateCVPersonalInfo(null, cvId, maritalStatus, birthPlaceCountry,
                    birthPlaceCity, birthPlaceCityFree, nationality, modifyDate);
            }
            #endregion
        }
    }
}
