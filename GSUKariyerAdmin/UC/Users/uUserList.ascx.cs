﻿using System;
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
using System.IO;
using OfficeOpenXml;

public partial class UC_Users_uUserList : BaseUserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public void BindData(DataTable dt)
    {
        if (dt.Rows.Count > 0)
        {
            pnlList.Visible = true;
            Paging1.GeneratePager(ref dt, rptList);
        }
        else
            pnlList.Visible = false;

        pnlNoData.Visible = !pnlList.Visible;
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
       uSuccess1.Visible = (Users.Delete(this.Checkeds(rptList), this.smAdminID));
       uError1.Visible = !uSuccess1.Visible;
    }

    protected void chAll_CheckedChanged(object sender, EventArgs e)
    {
        this.CheckAll(rptList, chAll.Checked);
    }

    protected string ArrangeDate(object date)
    {
        if (date == DBNull.Value)
            return "-";

        return ((DateTime)date).ToShortDateString();
    }
    protected string ArrangeIsActive(object isActive)
    {
        if (isActive == DBNull.Value)
            return "√";

        if ((bool)isActive)
            return "√";

        return "x";
    }
}