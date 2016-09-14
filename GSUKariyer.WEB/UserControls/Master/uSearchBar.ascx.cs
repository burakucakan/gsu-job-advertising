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

namespace GSUKariyer.WEB.UserControls.Master
{
    public partial class uSearchBar : BaseUserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        #region Button Functions
        protected void btnSearch_Click(object sender, ImageClickEventArgs e)
        {
            string keyword = txtSearch.Text.Trim();
            if (keyword == "Anahtar Kelime ?")
                keyword = String.Empty;

            if (String.IsNullOrEmpty(keyword) && String.IsNullOrEmpty(uCityCountry1.SelectedValue) &&
                String.IsNullOrEmpty(uSearchPosition.SelectedValue))
                Response.Redirect(UrlHelper.PageUrl.Advertisements());


            Response.Redirect(UrlHelper.PageUrl.Advertisements(BUS.Advertisements.SearchHelper.AdvertisementsPage.Mode.Fast,
                Server.UrlEncode(keyword),uCityCountry1.SelectedValue, uSearchPosition.SelectedValue));
        }
        #endregion
    }
}