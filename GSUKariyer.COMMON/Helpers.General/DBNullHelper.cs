using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GSUKariyer.COMMON
{
    public class DBNullHelper
    {
        /// <summary>
        /// if value is null then returns DBNULL else return exact value
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static object ConvertValueToDBNull(object value)
        {
            if (value == null)
                return DBNull.Value;
            else
                return value;

        }


        /// <summary>
        /// if value is null then returns DBNULL else return exact value. If convertEmptyStringToNull is true, returns DBNull if given value is string.isnullOrEmpty
        /// </summary>
        /// <param name="value"></param>
        /// <param name="convertEmptyStringToNull"></param>
        /// <returns></returns>
        public static object ConvertValueToDBNull(string value, bool convertEmptyStringToNull)
        {
            if (value == null || (string.IsNullOrEmpty(value) && convertEmptyStringToNull))
                return DBNull.Value;
            else
                return value;
        }




        /// <summary>
        /// Convert value Nullable type of T. If value == null return null else return value with type of T
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static Nullable<T> GetNullableValue<T>(object value) where T : struct
        {
            if (value == null || value == DBNull.Value || (typeof(T) != typeof(string) && value.ToString() == ""))
                return null;
            else
                return (T)Convert.ChangeType(value, typeof(T));

        }


        /// <summary>
        /// Convert string value to nullable int.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static int? GetNullableValue(string value)
        {
            int retVal;
            if (int.TryParse(value, out retVal))
                return retVal;

            return null;
        }

        /// <summary>
        /// Convert value to decimal. If value is null, returns 0
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static decimal GetMoneyValue(object value)
        {
            return (DBNullHelper.GetNullableValue<decimal>(value) ?? 0);
        }
    }
}
