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

namespace GSUKariyer.WEB.UserControls.Firm
{
    public partial class uFirmApplications : BaseFirmUserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Util.IsNumeric(Request.QueryString["Id"]))
                    hdAdvertisementId.Value = Request.QueryString["Id"].ToString();

                BindData();
            }
        }

        protected void BindData()
        {
            DataTable dt = BUS.AdvertisementApplications.GetApplications(this.SessionManager.FirmId, hdAdvertisementId.Value.ToInt());
            uFirmApplicationList1.Bind(dt);
        }
    }
}