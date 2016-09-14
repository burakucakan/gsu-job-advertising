using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace GSUKariyer.COMMON
{
    public partial class Validator
    {
        private const string _nationalIdRegexPattern = @"\w\d{10}";
        public static string NationalIdRegexPattern
        {
            get { return _nationalIdRegexPattern; }
        }

        private const string _taxNumberRegexPattern = @"^\d{10}$";
        public static string TaxNumberRegexPattern
        {
            get { return _taxNumberRegexPattern; }
        }

        private const string _postCodeRegexPattern = @"^\d{4,5}$";  // 4000 or 34000
        public static string PostCodeRegexPattern
        {
            get { return _postCodeRegexPattern; }

        }

        private const string _yearRegexPattern = @"^\d{4}$";  // 2009
        private const string _emailRegexPattern = @"^(['_a-z0-9-]+)(\.['_a-z0-9-]+)*@([a-z0-9-]+)(\.[a-z0-9-]+)*(\.[a-z]{2,5})$";
        public static string EmailRegexPattern
        {
            get { return _emailRegexPattern; }
        }

        private const string _phoneRegexPattern = @"^\(\d{3,4}\)\s*\d{7}.*";  // Sample: (212) 1234567

        public static bool IsValidNationalId(string input)
        {
            return Regex.IsMatch(input, _nationalIdRegexPattern);
        }

        public static bool IsValidTaxNumber(string input)
        {
            return Regex.IsMatch(input, _taxNumberRegexPattern);
        }

        public static bool IsValidPostCode(string input)
        {
            return Regex.IsMatch(input, _postCodeRegexPattern);
        }

        public static bool IsValidYear(string input)
        {
            return Regex.IsMatch(input, _yearRegexPattern);
        }

        public static bool IsValidEmail(string input)
        {
            return Regex.IsMatch(input, _emailRegexPattern);
        }

        public static bool IsValidPhoneNumber(string input)
        {
            return Regex.IsMatch(input, _phoneRegexPattern);
        }

        public static bool IsValidFaxNumber(string input)
        {
            return Regex.IsMatch(input, _phoneRegexPattern);
        }

        /// <summary>
        /// Returns false if given birthdate lower than 18 years.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static bool IsValidBirthDate_18YearsOldCheck(DateTime input)
        {
            // check grater or equal 18 years old.
            DateTime requiredBirthDate = DateTime.Now.AddYears(-18);
            return (DateTime.Compare(input, requiredBirthDate) <= 0);
        }
    }
}
