using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace GSUKariyer.COMMON.Helpers.WEB
{
    public class BaseStudentPage : BaseCompressedPage
    {

        public BaseStudentPage()
        {
        }

        #region Page Events
        protected void Page_Init(object sender, EventArgs e)
        {
            if (!this.SessionManager.IsLoggedIn)
                HttpContext.Current.Response.Redirect(UrlHelper.PageUrl.Signup());
        }
        #endregion
    }
}
