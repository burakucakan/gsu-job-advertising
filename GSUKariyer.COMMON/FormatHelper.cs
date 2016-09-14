using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using System.Data;

namespace GSUKariyer.COMMON
{
    public class FormatHelper
    {
        public static string FormatMoney(object money)
        {
            return string.Format("{0:###,###,##0.00}", money);
            //return string.Format("{0:c}", money).Split(' ')[0];
        }

        public static string FormatMoney(object money, string currency)
        {
            return FormatMoney(money) + " " + currency;
        }

        public static string FormatMoneyWithCurrency(object money, string currencyCode)
        {
            if (money == null || string.IsNullOrEmpty(money.ToString()))
                return "";
            return "<table cellpadding=0 cellspacing=0><tr><td>" + FormatMoney(money) + "</td><td>&nbsp;</td><td>" + currencyCode + "</td></tr></table>";
        }

        public static string FormatCurrencyValue(object money)
        {
            return string.Format("{0:###,###,##0.0000}", money);
        }
      
        public static DateTime ConvertStringToDateTime(string stringDateTime, string dateTimeFormat)
        {
            return DateTime.ParseExact(stringDateTime, dateTimeFormat, new DateTimeFormatInfo());
        }

        /// <summary>
        /// Convert dd.MM.yyyy hh:mm:ss formatted string to datetime type
        /// </summary>
        /// <param name="stringDateTime"></param>
        /// <returns></returns>
        public static DateTime ConvertStringToDateTime(string stringDateTime)
        {
            return ConvertStringToDateTime(stringDateTime, "dd.MM.yyyy HH:mm:ss");
        }

        /// <summary>
        /// Convert 06.01.2009 00:00:00 string to 06.01.2009
        /// </summary>
        /// <param name="dbDateTime">string comes from datetime typed column in database</param>
        /// <returns></returns>
        public static string ConvertDBDateTimeStringToShortString(string dbDateTime)
        {
            if (string.IsNullOrEmpty(dbDateTime))
                return "";
            return dbDateTime.Split(' ')[0];
        }

        /// <summary>
        /// Convert 06.01.2009 00:00:00 string to 06.01.2009 00:00
        /// </summary>
        /// <param name="dbDateTime">string comes from datetime typed column in database</param>
        /// <returns></returns>
        public static string ConvertDBDateTimeStringToDateAndTimeString(string dbDateTime)
        {
            if (string.IsNullOrEmpty(dbDateTime))
                return "";

            int index = dbDateTime.LastIndexOf(":");
            return dbDateTime.Substring(0, index);
        }

        /// <summary>
        /// Convert 06.01.2009 00:00:00 string to 06.01.09
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static string ConvertDateTimeToShortString(DateTime dateTime)
        {
            return dateTime.ToString("dd.MM.yy");
        }

        /// <summary>
        /// Returns bool value due to value. if value is null or not bool type return false else return value.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool ConvertObjectToBool(object value)
        {
            if (value == null || !(value is bool))
                return false;
            else
                return (bool)value;
        }

        /// <summary>
        /// Converts given value to int. If value is null or empty string returns 0
        /// </summary>
        /// <param name="value">Nullable and Parsable to Int value</param>
        /// <returns>0 or value</returns>
        public static int ConvertObjectToInt(object value)
        {
            if (DBNullHelper.GetNullableValue<int>(value) == null)
                return 0;
            else
                return DBNullHelper.GetNullableValue<int>(value).Value;
        }

        /// <summary>
        /// Converts given value to string. If value is null or DBNull or empty string returns String.Empty
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ConvertObjectToString(object value)
        {
            if (value == null || value == DBNull.Value || string.IsNullOrEmpty(value.ToString()))
            {
                return String.Empty;
            }
            else
                return value.ToString();
        }

        /// <summary>
        /// Converts given value to double. If value is null or DBNull or empty string returns 0
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static double ConvertObjectToDouble(object value)
        {
            if (DBNullHelper.GetNullableValue<double>(value) == null)
                return 0;
            else
                return DBNullHelper.GetNullableValue<double>(value).Value;
        }

        public static string GetPercentFormat(string value)
        {
            if (!String.IsNullOrEmpty(value))
            {
                return "%" + value;
            }
            else
            {
                return String.Empty;
            }
        }

        /// <summary>
        /// Returns Atoms (FirstName,SecondName,Surname)of a given Fullname
        /// </summary>
        /// <param name="fullName"></param>
        /// <param name="firstName"></param>
        /// <param name="secondName"></param>
        /// <param name="lastName"></param>
        public static void GetFullNameAtoms(string fullName, out string firstName, out string secondName, out string surName)
        {
            char nameSeperator = ' ';
            firstName = secondName = surName = "";
            string[] nameAtoms = fullName.Split(new char[] { nameSeperator }, StringSplitOptions.RemoveEmptyEntries);

            if (nameAtoms.Length >= 2)
            {
                firstName = nameAtoms[0];
                surName = nameAtoms[nameAtoms.Length - 1];

                if (nameAtoms.Length > 3)
                {
                    for (int i = 0; i < nameAtoms.Length - 2; i++)
                    {
                        secondName = nameAtoms[1 + i] + nameSeperator;
                    }

                    secondName = secondName.Trim();
                }
            }
        }

        /// <summary>
        /// Returns fullname by given firstName, secondName, lastName
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="secondName"></param>
        /// <param name="lastName"></param>
        public static string GetFullName(string firstName, string secondName, string surName)
        {
            return firstName + " " + (String.IsNullOrEmpty(secondName) ? "" : secondName + " ") + surName;
        }

        /// <summary>
        /// Returns Formatted Phone Number
        /// </summary>
        /// <param name="cityCode"></param>
        /// <param name="phoneNumber"></param>
        /// <returns></returns>
        public static string GetFormattedPhoneNumber(string cityCode, string phoneNumber)
        {
            string formattedPhoneTemplate = "(||CityCode||) ||PhoneNumber||";
            return formattedPhoneTemplate.Replace("||CityCode||", cityCode).Replace("||PhoneNumber||", phoneNumber);
        }

        public static string ReplaceNoDataWithDash(string data)
        {
            if (String.IsNullOrEmpty(data))
                data = "-";
            return data;
        }

        public static double? ConvertStringToNullableDouble(string s)
        {
            double i;
            if (Double.TryParse(s, out i)) return i;
            return null;
        }

        public struct BoolFunc
        {
            public struct ColumnNames
            {
                public const string Description = "Description";
                public const string Value = "Value";
            }

            public static DataTable GetTrueFalse()
            {
                DataTable dt = new DataTable();
                dt.Columns.Add(new DataColumn(ColumnNames.Description));
                dt.Columns.Add(new DataColumn(ColumnNames.Value));

                DataRow dr = dt.NewRow();

                dr[ColumnNames.Description] = "Evet";
                dr[ColumnNames.Value] = true.ToString();
                dt.Rows.Add(dr);

                dr = dt.NewRow();
                dr[ColumnNames.Description] = "Hayır";
                dr[ColumnNames.Value] = false.ToString();
                dt.Rows.Add(dr);

                return dt;
            }

            public static string GetTrueFalse(bool value)
            {
                return (value ? "Evet" : "Hayır");
            }
            public static string GetOther(bool value)
            {
                return (value ? "Var" : "Yok");
            }
        }

        public static string NoRecord()
        {
            return "<h2>Kayıt bulunamadı.</h2>";
        }
    }
}
