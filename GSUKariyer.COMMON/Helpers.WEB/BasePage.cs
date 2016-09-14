using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GSUKariyer.COMMON.Exceptions;
using System.Web;

namespace GSUKariyer.COMMON.Helpers.WEB
{
    public class BasePage : System.Web.UI.Page
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

        public BasePage()
        {

        }

        #region PageEvents
        protected override void OnPreInit(EventArgs e)
        {
            base.OnPreInit(e);
        }
        protected void Page_Init(object sender, EventArgs e)
        {
            //PageLevelAuthorizationHelper.AuthorizeCurrentUser();
        }
              
        protected void Page_Error(object sender, EventArgs e)
        {
            //Gets Last Error
            Exception appException = Server.GetLastError();

            //Adds PageName,User ID,User IP to the exception
            throw new MyException(appException, PageHelper.GetPageName(), GetCurrentUser(), Request.UserHostAddress);
        }
        #endregion

        #region Others
        public string GetCurrentUser()
        {
            return HttpContext.Current.User.Identity.Name;
        }
        #endregion
    }
}
