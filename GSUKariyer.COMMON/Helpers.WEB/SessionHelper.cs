using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace GSUKariyer.COMMON.Helpers.WEB
{
    public partial class SessionHelper
    {
        private static SessionHelper _sessionHelper = null;

        private const string SessionKey = "SessRoot";
        private Dictionary<string, object> SessionDictionary
        {
            get
            {
                if (HttpContext.Current.Session[SessionKey] == null)
                    HttpContext.Current.Session.Add(SessionKey, new Dictionary<string, object>());

                return (Dictionary<string, object>)HttpContext.Current.Session[SessionKey];
            }
        }

        private SessionHelper()
        {
        }

        #region Public Functions
        public static SessionHelper GetSessionHelper()
        {
            if (HttpContext.Current.Session != null)
            {
                if (_sessionHelper == null)
                    _sessionHelper = new SessionHelper();

                return _sessionHelper;
            }

            return null;
        }

        public object GetSessionValue(string key)
        {
            if (SessionDictionary.ContainsKey(key))
            {
                return SessionDictionary[key];
            }
            return null;
        }
        public T GetSessionValue<T>(string key)
        {
            if (SessionDictionary.ContainsKey(key))
            {
                return (T)SessionDictionary[key];
            }
            return default(T);
        }
        public void SetSessionValue(string key, object value)
        {
            if (SessionDictionary.ContainsKey(key))
                SessionDictionary[key] = value;
            else
                SessionDictionary.Add(key, value);
        }
        public void RemoveFromSession(string key)
        {
            if (SessionDictionary.ContainsKey(key))
                SessionDictionary.Remove(key);
        }
        public void KillAllSessions()
        {
            HttpContext.Current.Session.Clear();
            HttpContext.Current.Session.Abandon();
        }
        #endregion 
    }
}
