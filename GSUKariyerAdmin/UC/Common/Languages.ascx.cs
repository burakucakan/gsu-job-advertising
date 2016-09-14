using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UC_Common_Languages : System.Web.UI.UserControl
{
    public string SelectedValue { get { return ddlLanguages.SelectedValue; } set { ddlLanguages.SelectedValue = value; } }
    public string ValidationGroup { set { rqLanguages.ValidationGroup = value; } }

    protected void Page_Load(object sender, EventArgs e)
    {

    }
}
