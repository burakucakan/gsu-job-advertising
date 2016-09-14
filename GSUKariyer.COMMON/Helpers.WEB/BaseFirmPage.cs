using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace GSUKariyer.COMMON.Helpers.WEB
{
    public class BaseFirmPage : BaseCompressedPage
    {
        public BaseFirmPage()
        {
        }

        #region Page Events
        protected void Page_Init(object sender, EventArgs e)
        {
            if (!this.SessionManager.IsFirmLoggedIn)
                HttpContext.Current.Response.Redirect(UrlHelper.PageUrl.FirmLogin());
        }
        #endregion
    }
}
