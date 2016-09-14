using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;
using GSUKariyer.COMMON.Helpers.WEB;

namespace GSUKariyer.WEB
{
    public partial class UserSearch : BaseFirmPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            uUserSearch1.BannerShow = new GSUKariyer.WEB.UserControls.Firm.uUserSearch.BannerShow_EventHandler(BannerShow);  
        }

        public void BannerShow(bool isVisible)
        {
            uBanner1.Visible = isVisible;
        }
    }
}
