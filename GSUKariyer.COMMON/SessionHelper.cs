using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GSUKariyer.COMMON.Helpers.WEB
{
    public partial class SessionHelper
    {
        public struct Keys
        {
            public const string CurrentError = "Error";
            public const string IsLoggedIn = "IsLoggedIn";
            public const string UserId = "UserId";
            public const string NationalId = "NationalId";
            public const string Email = "Email";
            public const string Name = "Name";
            public const string Surname = "Surname";
            public const string StudentNumber = "StudentNumber";
            public const string LoginTime = "LoginTime";
            public const string ApplicationCount = "ApplicationCount";
            public const string UnreadAnswerCount = "UnreadAnswerCount";

            public const string IsFirmLoggedIn = "IsFirmLoggedIn";
            public const string FirmId = "FirmId";
            public const string FirmName = "FirmName";
            public const string FirmEmail = "FirmEmail";
            public const string FirmApplicationCount = "FirmApplicationCount";            
        }


        //Üye Sessions
        public bool IsLoggedIn 
        {
            get { return DBNullHelper.GetNullableValue<bool>(GetSessionValue(Keys.IsLoggedIn)) ?? false; }
            set { SetSessionValue(Keys.IsLoggedIn, value); }
        }

        public bool IsFirmLoggedIn
        {
            get { return DBNullHelper.GetNullableValue<bool>(GetSessionValue(Keys.IsFirmLoggedIn)) ?? false; }
            set { SetSessionValue(Keys.IsFirmLoggedIn, value); }
        }

        public int? UserId
        {
            get { return DBNullHelper.GetNullableValue<int>(GetSessionValue(Keys.UserId)) ?? 0; }
            set { SetSessionValue(Keys.UserId, value); }
        }

        public string NationalId
        {
            get { return GetSessionValue(Keys.NationalId).ToString(); }
            set { SetSessionValue(Keys.NationalId, value); }
        }

        public string Email
        {
            get { return GetSessionValue(Keys.Email).ToString(); }
            set { SetSessionValue(Keys.Email, value); }
        }

        public string Name
        {
            get { return GetSessionValue(Keys.Name).ToString(); }
            set { SetSessionValue(Keys.Name, value); }
        }

        public string Surname
        {
            get { return GetSessionValue(Keys.Surname).ToString(); }
            set { SetSessionValue(Keys.Surname, value); }
        }

        public string StudentNumber
        {
            get { return GetSessionValue(Keys.StudentNumber).ToString(); }
            set { SetSessionValue(Keys.StudentNumber, value); }
        }

        public int ApplicationCount
        {
            get { return DBNullHelper.GetNullableValue<int>(GetSessionValue(Keys.ApplicationCount)) ?? 0; }
            set { SetSessionValue(Keys.ApplicationCount, value); }
        }

        public int UnreadAnswerCount
        {
            get { return DBNullHelper.GetNullableValue<int>(GetSessionValue(Keys.UnreadAnswerCount)) ?? 0; }
            set { SetSessionValue(Keys.UnreadAnswerCount, value); }
        }


        //Firma Sesion
        public int FirmId
        {
            get { return DBNullHelper.GetNullableValue<int>(GetSessionValue(Keys.FirmId)) ?? 0; }
            set { SetSessionValue(Keys.FirmId, value); }
        }

        public string FirmName
        {
            get { return GetSessionValue(Keys.FirmName).ToString(); }
            set { SetSessionValue(Keys.FirmName, value); }
        }

        public string FirmEmail
        {
            get { return GetSessionValue(Keys.FirmEmail).ToString(); }
            set { SetSessionValue(Keys.FirmEmail, value); }
        }

        public int FirmApplicationCount
        {
            get { return DBNullHelper.GetNullableValue<int>(GetSessionValue(Keys.FirmApplicationCount)) ?? 0; }
            set { SetSessionValue(Keys.FirmApplicationCount, value); }
        }


        //Ortak Sessions
        public DateTime LoginTime
        {
            get { return DBNullHelper.GetNullableValue<DateTime>(GetSessionValue(Keys.LoginTime)) ?? DateTime.Now; }
            set { SetSessionValue(Keys.LoginTime, value); }
        }

    }
}
