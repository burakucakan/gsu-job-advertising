using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using GSUKariyer.COMMON.Helpers.DAL;
using GSUKariyer.COMMON.Exceptions;

namespace GSUKariyer.DAL
{

    public partial class SiteParamsProvider
    {
        #region Get Functions
        public static DataSet GetByParamGroup(string paramGroup)
        {
            return CustomGet(paramGroup, null, null);
        }

        public static DataSet GetByValue(string paramGroup,string value)
        {
            return CustomGet(paramGroup, null, value);
        }

        public static DataSet GetByName(string paramGroup, string name)
        {
            return CustomGet(paramGroup,name,null);
        }

        public static DataSet CustomGet(string paramGroup, string name, string value)
        {
            SqlParameter[] sqlParams = null;

            try
            {
                sqlParams = new SqlParameter[] { 
					new SqlParameter("@ParamName",name),
					new SqlParameter("@ParamGroup",paramGroup),
					new SqlParameter("@Value",value)
                };


                return ExecuteDataset("BGA_CustomGetSiteParams", sqlParams);                              
            }
            catch (Exception ex)
            {
                throw new MyException(ex.Message, "SiteParamsProvider", "CustomGet", ArrangeParamValues(sqlParams));
            }

        }

        public static DataSet CustomGetRandomTop5(string paramGroup)
        {
            SqlParameter[] sqlParams = null;

            try
            {
                sqlParams = new SqlParameter[] { 
					new SqlParameter("@UnivDepartmentParamGroup",paramGroup)
                };


                return ExecuteDataset("BGA_CustomGetRandomUnivDepartments", sqlParams);
            }
            catch (Exception ex)
            {
                throw new MyException(ex.Message, "SiteParamsProvider", "CustomGetRandomTop5", ArrangeParamValues(sqlParams));
            }

        }

        public static DataSet GetCityCountryInfo(string cityParamCode, string countryParamCode)
        {
            SqlParameter[] sqlParams = null;

            try
            {
                sqlParams = new SqlParameter[] { 
					new SqlParameter("@CityParamCode",cityParamCode),
					new SqlParameter("@CountryParamCode",countryParamCode)
                };


                return ExecuteDataset("BGA_CustomGetCityCountriesInfo", sqlParams);
            }
            catch (Exception ex)
            {
                throw new MyException(ex.Message, "SiteParamsProvider", "GetCityCountryInfo", ArrangeParamValues(sqlParams));
            }

        }

        #endregion 

        #region Update Functions
        public static int UpdateByParamGroup(SqlTransaction tran,string paramGroup, string description, string value)
        {
            SqlParameter[] sqlParams = null;

            try
            {
                sqlParams = new SqlParameter[] { 
					new SqlParameter("@ParamGroup",paramGroup),
					new SqlParameter("@Description",description),
					new SqlParameter("@Value",value)
                };

                if(tran==null)
                    return ExecuteNonQuery("BGA_CustomUpdateSiteParamByParamGroup", sqlParams);
                else
                    return ExecuteNonQuery(tran,"BGA_CustomUpdateSiteParamByParamGroup", sqlParams);

            }
            catch (Exception ex)
            {
                throw new MyException(ex.Message, "SiteParamsProvider", "UpdateByParamGroup", ArrangeParamValues(sqlParams));
            }
        }
        #endregion
    }
}
