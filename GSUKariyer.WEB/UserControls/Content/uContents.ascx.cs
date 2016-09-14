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

namespace GSUKariyer.WEB.UserControls.Content
{
    public partial class uContents : BaseUserControl
    {
        private int ContentType;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                if (Util.IsString(Request.QueryString["ContentType"]))
                {
                    string ContentType = Request.QueryString["ContentType"].ToString();
                    Bind(ContentType);
                }
                else
                    UrlHelper.PageUrl.Default();
            }
        }

        private void Bind(string ContentType)
        {
            UrlHelper.ContentTypes t = (UrlHelper.ContentTypes)Enum.Parse(typeof(UrlHelper.ContentTypes), ContentType);
            switch (t)
            {
                case UrlHelper.ContentTypes.Duyurular:
                    this.ContentType = (int)UrlHelper.ContentTypes.Duyurular;
                    ltlTitle.Text = "duyurular";
                    break;
                case UrlHelper.ContentTypes.Roportajlar:
                    this.ContentType = (int)UrlHelper.ContentTypes.Roportajlar;
                    ltlTitle.Text = "roportajlar";
                    break;
                case UrlHelper.ContentTypes.BasariHikayeleri:
                    this.ContentType = (int)UrlHelper.ContentTypes.BasariHikayeleri;
                    ltlTitle.Text = "başarı hikayeleri";
                    break;
                case UrlHelper.ContentTypes.Makaleler:
                    this.ContentType = (int)UrlHelper.ContentTypes.Makaleler;
                    ltlTitle.Text = "makaleler";
                    break;
                default:
                    break;
            }

            DataTable dt = BUS.SiteContents.GetSiteContentList(this.ContentType);
            uPaging.GeneratePager(ref dt, rptList);
        }

        protected void rptList_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
            {
                int ContentId = ((HiddenField)e.Item.FindControl("hdID")).Value.ToInt();
                UrlHelper.ContentTypes ContentType = (UrlHelper.ContentTypes)(((HiddenField)e.Item.FindControl("hdContentType")).Value.ToInt());
                string Title = ((Literal)e.Item.FindControl("ltlTitle")).Text;

                HyperLink hlContent = (HyperLink)e.Item.FindControl("hlContent");
                hlContent.NavigateUrl = UrlHelper.PageUrl.ContentDetail(ContentId, ContentType, Title);

                Image img = (Image)e.Item.FindControl("img");
                img.ImageUrl = UrlHelper.ImgUrl.ImgUrlContent(ContentId, ContentType, GSUKariyer.COMMON.UrlHelper.ImgUrl.ImgSizes.Thumb);
            }
        }
    }
}