using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GSUKariyer.COMMON.Exceptions;
using System.Web;

namespace GSUKariyer.COMMON.Helpers.WEB
{
    public class BaseUserControl : System.Web.UI.UserControl
    {
        #region Session Manager
        public SessionHelper SessionManager
        {
            get
            {
                return SessionHelper.GetSessionHelper();
            }
        }
        #endregion

        #region URL Parameter Manager
        
        public string Go(string PageName) {
            return UrlHelper.PageUrl.GetURL(PageName);
        }

        protected Nullable<T> GetUrlParam<T>(string paramName) where T : struct
        {
            if (string.IsNullOrEmpty(Request.Params[paramName]))
                return null;
            else
            {
                object temp = Request.Params[paramName];
                return (T)Convert.ChangeType(temp, typeof(T));
            }
        }

        protected string GetUrlParam(string paramName)
        {
            return Request.QueryString[paramName];
        }
        #endregion

        #region Exception / Error Functions

        /// <summary>
        /// Checks paramNames in QueryString parameters. If anyone's value is null then throws Exception.
        /// </summary>
        /// <param name="methodName">Function name which will be showed in Exception Message</param>
        /// <param name="paramName">ParamName which value will be searched in QueryString</param>
        protected void CheckUrlParamThrowException(string methodName, params string[] paramName)
        {
            for (int cntr = 0; cntr < paramName.Length; cntr++)
            {
                if (string.IsNullOrEmpty(Request.Params[paramName[cntr]]))
                {
                    throw new MyException("Invalid Parameters " + paramName[cntr] + "=NULL", this.GetType().Name + ":" + methodName + "() ");
                }
            }
        }

        /// <summary>
        /// Checks paramNames in QueryString parameters. If anyone's value is null then  Redirect to given URL.
        /// </summary>
        /// <param name="redirectUrl">Redirect URL</param>
        /// <param name="paramName">ParamName which value will be searched in QueryString</param>
        protected void CheckUrlParamRedirect(string redirectUrl, params string[] paramName)
        {
            for (int cntr = 0; cntr < paramName.Length; cntr++)
            {
                if (string.IsNullOrEmpty(Request.Params[paramName[cntr]]))
                {
                    Response.Redirect(redirectUrl);
                    break;
                }
            }
        }

        /// <summary>
        /// Throws An exception specifies no data found.
        /// </summary>
        /// <param name="methodName">Which method throws this exception.</param>
        protected void ThrowNoDataException(string methodName)
        {
            string paramList = "";
            foreach (string key in Request.QueryString.Keys)
            {
                paramList += key + " = " + Request.Params[key] + "&";
            }
            throw new MyException("No Data is Found : QueryString List:" + paramList, this.GetType().Name + ":" + methodName + "() ");
        }
        protected void LogError(string message)
        {
            Logger.LogErrors(new MyException(message, PageHelper.GetPageName(), GetCurrentUser(), Request.UserHostAddress).Message);
        }
        #endregion

        public BaseUserControl()
        {
        }

        #region Others
        public string GetCurrentUser()
        {
            return HttpContext.Current.User.Identity.Name;
        }
        public string SpecialValue {
            get { return (ViewState["SpecialValue"] == null ? String.Empty : ViewState["SpecialValue"].ToString()); }
            set { ViewState["SpecialValue"] = value; }
        }
        #endregion

        public class UrlHelper:COMMON.UrlHelper
        { 
        }

        public class PageName : COMMON.UrlHelper.PageUrl.PageName
        { 
        }

    }
}
