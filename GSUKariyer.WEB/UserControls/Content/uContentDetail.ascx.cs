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
using GSUKariyer.BUS;

namespace GSUKariyer.WEB.UserControls.Content
{
    public partial class uContentDetail : BaseUserControl
    {
        #region Properties
        protected int? ContentId
        {
            get {
                return GetUrlParam<int>(UrlHelper.PageUrl.UrlKey.Id);
            }
        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CheckUrlParamRedirect(UrlHelper.PageUrl.Default(),UrlHelper.PageUrl.UrlKey.Id);
                BindForm();
            }
        }

        #region BindForm
        protected void BindForm()
        {
            DataTable dtSiteContent = SiteContents.Generated.Get(ContentId.Value);

            if (dtSiteContent.Rows.Count > 0)
            {
                ltrContent.Text = dtSiteContent.Rows[0][SiteContents.ColumnNames.Content].ToString();
                ltrContentTitle.Text = dtSiteContent.Rows[0][SiteContents.ColumnNames.Title].ToString();
                ltrContentCategory.Text = SiteParams.GetSiteContentTypeDescription(
                    dtSiteContent.Rows[0][SiteContents.ColumnNames.ContentType].ToInt());
                
                imgContent.ImageUrl = UrlHelper.ImgUrl.ImgUrlContent(ContentId.Value,                
                                            (UrlHelper.ContentTypes)(dtSiteContent.Rows[0][SiteContents.ColumnNames.ContentType].ToInt()),
                                            UrlHelper.ImgUrl.ImgSizes.Default);
                divImage.Visible = imgContent.ImageUrl.Length > 0;

                ltrImageDesc.Text = dtSiteContent.Rows[0][SiteContents.ColumnNames.ContentImageDescription].ToString();                
            }
            else
                ThrowNoDataException("BindForm");
        }
        #endregion
    }
}