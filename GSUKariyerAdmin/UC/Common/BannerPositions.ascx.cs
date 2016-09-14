using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GSUKariyer.COMMON;

public partial class UC_Common_BannerPositions : System.Web.UI.UserControl
{
    public string SelectedValue { get { return ddlBannerPositions.SelectedValue; } set { ddlBannerPositions.SelectedValue = value; } }
    public string ValidationGroup { set { rqBannerPositions.ValidationGroup = value; } }

    protected void Page_Init(object sender, EventArgs e)
    {

    }
}
