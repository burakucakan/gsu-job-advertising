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

namespace GSUKariyer.WEB.UserControls.User
{
    public partial class uUserApplications : BaseStudentUserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {


                BindData();
            }
        }

        protected void BindData()
        {
            DataTable dtApps = BUS.AdvertisementApplications.GetUserApplications(this.SessionManager.UserId.Value);
            uUserApplicationList1.Bind(dtApps);
        }
    }
}