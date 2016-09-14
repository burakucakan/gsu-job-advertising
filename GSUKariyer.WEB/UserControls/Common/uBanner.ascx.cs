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
using GSUKariyer.BUS;

namespace GSUKariyer.WEB.UserControls.Common
{
    public partial class uBanner : BaseUserControl
    {
        protected const string hlBanner = "hlBanner";
        protected Banners.PageLocation _pageLocation;

        #region Properties
        public Banners.PageLocation PageLocation
        {
            get { return _pageLocation; }
            set { _pageLocation = value; }
        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindForm();
            }
        }

        #region BindForm
        protected void BindForm()
        {
            DataTable dtBanners = Banners.Get(PageHelper.GetPageName(),_pageLocation);

            rptBanners.DataSource = dtBanners;
            rptBanners.DataBind();
        }
        #endregion

        #region Repeater Functions
        protected string ArrangeImageUrl(string fileName)
        {
            return String.Format("~/Images/_U/Banner/{0}",fileName);
        }
        protected string ArrangeNavigateUrl(string link)
        {
            if (String.IsNullOrEmpty(link))
                return "#";

            return link;
        }
        protected void rptBanners_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                DataRowView dataView= (DataRowView) e.Item.DataItem;

                RepeaterHelper.GetControl<HyperLink>(e.Item, hlBanner).NavigateUrl = ArrangeNavigateUrl(
                    dataView[BannerFiles.ColumnNames.Link].ToString());
            }
        }
        #endregion

    }
}