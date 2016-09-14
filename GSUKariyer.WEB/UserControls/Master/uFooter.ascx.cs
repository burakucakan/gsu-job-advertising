using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using GSUKariyer.COMMON.Helpers.WEB;
using GSUKariyer.COMMON;

namespace GSUKariyer.WEB.UserControls.Master
{
    public partial class uFooter : BaseUserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Arrange();
            }
        }

        protected void Arrange()
        {
            hlFooterMainPage.NavigateUrl = UrlHelper.PageUrl.Default();
            hlFooterAbout.NavigateUrl = Go(PageName.AboutUs);
            hlFooterTerms.NavigateUrl = Go(PageName.TermsOfUse);
            hlFooterContact.NavigateUrl = Go(PageName.Contact);
        }
    }
}