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
using GSUKariyer.COMMON;
using GSUKariyer.BUS;

namespace GSUKariyer.WEB.UserControls.Main
{
    public partial class uMainAnnouncements : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
                BindForm();
        }

        #region BindForm
        protected void BindForm()
        {
            rptMainAnnouncements.DataSource= MainPageContents.GetAnnouncements();
            rptMainAnnouncements.DataBind();
        }
        #endregion

        #region Repeater Events
        protected string ArrangeImageUrl(string id)
        {
            return UrlHelper.ImgUrl.ImgUrlContent(id.ToInt(), UrlHelper.ContentTypes.Duyurular, UrlHelper.ImgUrl.ImgSizes.Thumb); 
        }
        protected string ArrangeNavigateUrl(string id,string title)
        {
            return UrlHelper.PageUrl.ContentDetail(id.ToInt(), UrlHelper.ContentTypes.Duyurular, title);
        }
        #endregion
    }
}