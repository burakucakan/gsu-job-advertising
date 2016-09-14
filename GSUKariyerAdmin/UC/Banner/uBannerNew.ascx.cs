using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using GSUKariyer.BUS;

public partial class UC_Banner_uBannerNew : BaseUserControl
{
    private int BannerID = 0;
    protected string bannerSwfPath = "";
    
    protected void Page_Init(object sender, EventArgs e)
    {
        
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {       
        }
    }

    protected void btnSend_Click(object sender, EventArgs e)
    { 
    
    }

}