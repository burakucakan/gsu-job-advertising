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

namespace GSUKariyer.WEB.UserControls.Firm
{
    public partial class uFirmDetail : BaseUserControl
    {
        public int FirmId { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Arrange();
                BindForm();
            }
        }

        protected void Arrange()
        {
            if (Util.IsNumeric(Request.QueryString["Id"]))
                this.FirmId = int.Parse(Request.QueryString["Id"]);
            else 
            { Response.Redirect(UrlHelper.PageUrl.Default()); }
        }

        protected void BindForm()
        {
            DataTable dt = BUS.Firms.Generated.Get(this.FirmId);
            if (dt.Rows.Count < 1) Response.Redirect(UrlHelper.PageUrl.Default());
            else { 
                DataRow dr = dt.Rows[0];
                ltlFirmName.Text = dr[BUS.Firms.ColumnNames.Name].ToString();
                ltlDescription.Text = Util.Nl2Br(dr[BUS.Firms.ColumnNames.Description].ToString());

                imgLogo.ImageUrl = UrlHelper.ImgUrl.ImgUrlCompany(this.FirmId, GSUKariyer.COMMON.UrlHelper.ImgUrl.ImgSizes.Default);
                imgLogo.Visible = imgLogo.ImageUrl.Length > 0;
                
                hlWebPage.NavigateUrl = Util.FormatWebPage(dr[BUS.Firms.ColumnNames.Webpage].ToString());
            }

            if (!this.SessionManager.IsLoggedIn)
                uSendCv1.Visible = false;
            else
                uSendCv1.FirmId = this.FirmId;

            DataTable dtFirmAdvs = Firms.Advertisements.GetActiveOnes(FirmId);
            if (dtFirmAdvs.Rows.Count > 0)
            {
                uAdvertisementList1.Bind(dtFirmAdvs);
                ltlNoAdvs.Visible = false;
            }
            else
                ltlNoAdvs.Visible = true;
        }
    }
}