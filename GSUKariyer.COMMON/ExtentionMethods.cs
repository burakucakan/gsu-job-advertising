using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;

namespace GSUKariyer.COMMON
{
    public static class ExtentionMethods
    {
        #region Object Extention Methods
        public static int ToInt(this object value)
        {
            int intValue;

            if (!int.TryParse(value.ToString(), out intValue))
                throw new Exception("Object can not be converted to int");

            return intValue;
        }

        public static DateTime ToDateTime(this object value)
        {
            return Convert.ToDateTime(value,new CultureInfo("tr-Tr")); 
        }

        public static DateTime? ToNullableDateTime(this object value)
        {
            DateTime? retVal = null;
            DateTime dtValue;

            if(value!=null && value!=DBNull.Value)
                if (DateTime.TryParse(value.ToString(), out dtValue))
                    retVal = dtValue;

            return retVal;
        }

        public static int? ToNullableInt(this object value)
        {
            int? retVal = null;
            int intValue;

            if (int.TryParse(value.ToString(), out intValue))
                retVal = intValue;

            return retVal;
        }

        public static bool? ToNullableBool(this object value)
        {
            bool? retVal = null;
            bool blnValue;

            if (bool.TryParse(value.ToString(), out blnValue))
                retVal = blnValue;

            return retVal;
        }
        public static bool ToBool(this object value, bool defaultValue)
        {
            bool retVal;

            if (!bool.TryParse(value.ToString(), out retVal))
                retVal = defaultValue;

            return retVal;
        }
        public static decimal? ToNullableDecimal(this object value)
        {
            decimal? retVal = null;
            decimal decimalValue;

            if (decimal.TryParse(value.ToString(), out decimalValue))
                retVal = decimalValue;

            return retVal;
        }
        #endregion

        #region String Extention Methods
        public static int ToInt(this string value)
        {
            int intValue;

            if (!int.TryParse(value, out intValue))
                throw new Exception("String is can not be converted to int");

            return intValue;
        }

        public static int? ToNullableInt(this string value)
        {
            int? retVal = null;
            int intValue;

            if (int.TryParse(value, out intValue))
                retVal = intValue;

            return retVal;
        }

        public static decimal? ToNullableDecimal(this string value)
        {
            decimal? retVal = null;
            decimal decimalValue;

            if (decimal.TryParse(value, out decimalValue))
                retVal = decimalValue;

            return retVal;
        }

        public static DateTime? ToNullableDateTime(this string value)
        {
            DateTime? retVal = null;
            DateTime dtValue;

            if (DateTime.TryParse(value, out dtValue))
                retVal = dtValue;

            return retVal;
        }

        public static bool? ToNullableBool(this string value)
        {
            bool? retVal = null;
            bool blnValue;

            if (bool.TryParse(value, out blnValue))
                retVal = blnValue;

            return retVal;
        }
        public static bool ToBool(this string value, bool defaultValue)
        {
            bool retVal;

            if (!bool.TryParse(value, out retVal))
                retVal = defaultValue;

            return retVal;
        }

        public static bool TryParseInt(this string value)
        {
            int intValue;

            return int.TryParse(value, out intValue);
        }

        public static bool TryParseInt(this string value, out int intValue)
        {
            return int.TryParse(value, out intValue);
        }
        #endregion
    }
}
