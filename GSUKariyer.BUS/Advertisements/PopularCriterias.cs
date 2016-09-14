using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using GSUKariyer.DAL;
using GSUKariyer.COMMON;

namespace GSUKariyer.BUS
{
    public partial class Advertisements
    {
        public class PopularCriterias
        {
            public class CityCountry
            {
                public struct Columns
                {
                    public const string Value = "Value";
                    public const string Desc = "Desc";
                    public const string ItemCount = "ItemCount";
                }

                public static DataTable GetTop5()
                {
                    DataTable dt = AdvertisementsProvider.GetTop5AdvertisementCityCountry(DateTime.Now.Date).Tables[0];
                    dt.Columns.Add(Columns.Desc, System.Type.GetType("System.String"));
                    
                    foreach (DataRow dr in dt.Rows)
                    {
                        int? cityId=SiteParams.CityCountry.ArrangeSelectedCity(dr[Columns.Value].ToString()).ToNullableInt();
                        int? countryId=SiteParams.CityCountry.ArrangeSelectedCountry(dr[Columns.Value].ToString()).ToNullableInt();

                        if (cityId.HasValue)
                            dr[Columns.Desc] = SiteParams.CityCountry.GetCityDescription(cityId.Value);

                        if (countryId.HasValue)
                            dr[Columns.Desc] = SiteParams.CityCountry.GetCountryDescription(countryId.Value);
                            
                    }

                    return dt;
                }
            }
            public class Firms
            {
                public struct Columns
                {
                    public const string Value = "Value";
                    public const string Desc = "Desc";
                    public const string ItemCount = "ItemCount";
                }

                public static DataTable GetTop5()
                {
                    return AdvertisementsProvider.GetTop5AdvertisementFirm(DateTime.Now.Date).Tables[0];
                }
            }
            public class Sectors
            {
                public struct Columns
                {
                    public const string Value = "Value";
                    public const string Desc = "Desc";
                    public const string ItemCount = "ItemCount";
                }

                public static DataTable GetTop5()
                {
                    DataTable dt=AdvertisementsProvider.GetTop5AdvertisementSector(DateTime.Now.Date).Tables[0];

                    dt.Columns.Add(Columns.Desc, System.Type.GetType("System.String"));

                    foreach (DataRow dr in dt.Rows)
                    {
                        dr[Columns.Desc] = SiteParams.GetSectorDescription(dr[Columns.Value].ToString());
                    }

                    return dt;
                }
            }
        }
    }
}
