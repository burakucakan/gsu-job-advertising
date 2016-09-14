using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using GSUKariyer.BUS;

public partial class UC_News_uNewsManagement : BaseUserControl
{
    public GSUKariyer.BUS.SiteContents.Type _Type
    {
        get { return (ViewState["_Type"] == null ? GSUKariyer.BUS.SiteContents.Type.Announcements : (GSUKariyer.BUS.SiteContents.Type)(Convert.ToInt32(ViewState["_Type"]))); }
        set { ViewState["_Type"] = (int)value; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            SetType();
            BindData();
        }            
    }

    protected void BindData()
    {
        DataTable dt = GSUKariyer.BUS.SiteContents.GetSiteContentList((int)this._Type);
        Paging1.GeneratePager(ref dt, rptList);
    }


    protected void btnDelete_Click(object sender, EventArgs e)
    {
        uSuccess1.Visible = (SiteContents.Delete(this.Checkeds(rptList)));
        uError1.Visible = !uSuccess1.Visible;
        BindData();
    }
    protected void chAll_CheckedChanged(object sender, EventArgs e)
    {
        this.CheckAll(rptList, chAll.Checked);
    }


    private void SetType()
    {
        switch (this._Type)
        {
            case SiteContents.Type.Announcements:
                ltlTitleAnnouncement.Visible = true;
                break;

            case SiteContents.Type.Interview:
                ltlTitleInterview.Visible = true;
                break;

            case SiteContents.Type.SuccessStories:
                ltlTitleSuccessStory.Visible = true;
                break;

            case SiteContents.Type.Articles:
                ltlTitleArticle.Visible = true;
                break;
        }
    }

    protected string GoURL(int ID) {

        string NewPageName = "";

        switch (_Type)
        {
            case SiteContents.Type.Announcements:
                NewPageName = "AnnouncementNew.aspx";
                break;

            case SiteContents.Type.Interview:
                NewPageName = "InterviewNew.aspx";
                break;

            case SiteContents.Type.SuccessStories:
                NewPageName = "SuccessStoryNew.aspx";
                break;

            case SiteContents.Type.Articles:
                NewPageName = "ArticleNew.aspx";
                break;
        }
        
        return "go('" + NewPageName + "?j=" + ID.ToString() + "')";
    }

    protected void rptList_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
        {
            Literal ltlRow = (Literal)e.Item.FindControl("ltlRow");
            int ID = int.Parse(((Literal)e.Item.FindControl("ltlID")).Text);
            ltlRow.Text = "<td onclick=\"" + GoURL(ID) + "\">";
        }
    }
}
