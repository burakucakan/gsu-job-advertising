﻿using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class UC_Common_FreeTextBox : System.Web.UI.UserControl
{
    public string Text
    {
        get { return txtCKEditor.InnerHtml; }
        set { txtCKEditor.InnerHtml = value; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
    }
}
