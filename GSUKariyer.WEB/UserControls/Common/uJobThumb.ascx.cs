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
    public partial class uJobThumb : BaseUserControl
    {
        protected int _advetisementId;

        public string CompanyName { get { return lblCompanyName.Text; } set { lblCompanyName.Text = value; } }
        public string Desc { get { return ltlDesc.Text; } set { ltlDesc.Text = value; } }

        public int AdvertisementID { set { _advetisementId = value; } }
        public int CompanyID { set { imgCompany.ImageUrl = UrlHelper.ImgUrl.ImgUrlCompany(value, UrlHelper.ImgUrl.ImgSizes.Thumb); } }


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                hlJobThumb1.NavigateUrl = UrlHelper.PageUrl.AdvertisementDetail(_advetisementId, this.CompanyName, this.Desc);
            }
        }
    }
}