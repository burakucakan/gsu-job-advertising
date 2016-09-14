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
    public partial class uUserActivation : BaseUserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string ActivationCode = String.Empty;
            if (Util.IsString(Request.QueryString["AC"]))
            {
                ActivationCode = Util.r(Request.QueryString["AC"].ToString());
                succ.Visible = BUS.Users.UserActivate(ActivationCode);
                err.Visible = !succ.Visible;
            }
        }
    }
}