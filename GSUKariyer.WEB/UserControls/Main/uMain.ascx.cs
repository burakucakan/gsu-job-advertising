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
using GSUKariyer.BUS;
using GSUKariyer.COMMON;
using GSUKariyer.COMMON.Helpers.WEB;

namespace GSUKariyer.WEB.UserControls.Main
{
    public partial class uMain : BaseUserControl
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                BindForm();
        }

        #region BindForm
        protected void BindForm()
        {
            //Advertisements
            DataSet ds = MainPageContents.GetAdvertisements(); 
            DataTable dtAdvertisementSummary=ds.Tables[0];
            DataTable dtAdvertisements = ds.Tables[1];

            ltrFirmsCount.Text = dtAdvertisementSummary.Rows[0][MainPageContents.CustomColumnNames.FirmCount].ToString();
            ltrAdvertisementCount.Text = dtAdvertisementSummary.Rows[0][MainPageContents.CustomColumnNames.AdvertisementCount].ToString();

            uAdvertisementThumbList1.Bind(dtAdvertisements);

            //Career Planning
            DataTable dtCareerPlaning=MainPageContents.GetCareerPlanings();

            rptCareerPlanings.DataSource=dtCareerPlaning;
            rptCareerPlanings.DataBind();
        }
        #endregion

        #region Repeater Events
        protected UrlHelper.ContentTypes ArrangeContentTypeDesc(string ContentTypeTitle)
        {
            return (UrlHelper.ContentTypes)(ContentTypeTitle.ToInt());
        }        
        #endregion
    }
}