using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using GSUKariyer.BUS;

public partial class UC_Banner_uBannerManagement : BaseUserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            BindData();
    }

    protected void BindData()
    {
        //DataTable dt = Banners.GetBanners();
        //Paging1.GeneratePager(ref dt, rptList);
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        //uSuccess1.Visible = (Banners.Delete(this.Checkeds(rptList), this.smAdminID));
        //uError1.Visible = !uSuccess1.Visible;
        //BindData();
    }

    protected void chAll_CheckedChanged(object sender, EventArgs e)
    {
        this.CheckAll(rptList, chAll.Checked);
    }
}