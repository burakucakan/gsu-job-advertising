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
using GSUKariyer.COMMON.Helpers.WEB;

namespace GSUKariyer.WEB.UserControls.Common
{
    public partial class uCareerPlaningThumb : BaseUserControl
    {
        public int SiteContentID { get; set; }
        public string ContentTypeTitle { get { return ltlSiteContentType.Text; } set { ltlSiteContentType.Text = value; } }
        public string Title { get { return ltlTitle.Text; } set { ltlTitle.Text = Util.Left(value, 42); ; } }
        public string Name { get { return ltlName.Text; } set { ltlName.Text = Util.Left(value, 24); ; } }
        public string Desc { get { return ltlDesc.Text; } set { ltlDesc.Text = Util.Left(value, 120); } }
        public UrlHelper.ContentTypes ContentType { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            hlCareerDetail.NavigateUrl = UrlHelper.PageUrl.ContentDetail(this.SiteContentID, this.ContentType, this.Name);
            imgThumb.ImageUrl = UrlHelper.ImgUrl.ImgUrlContent(this.SiteContentID, this.ContentType, UrlHelper.ImgUrl.ImgSizes.Thumb);   
        }
    }
}