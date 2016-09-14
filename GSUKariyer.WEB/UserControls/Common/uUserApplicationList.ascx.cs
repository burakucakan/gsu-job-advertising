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

namespace GSUKariyer.WEB.UserControls.Common
{
    public partial class uUserApplicationList : BaseStudentUserControl
    {
        public bool PagingShow
        {
            get { return uPaging.Visible; }
            set { uPaging.Visible = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public void Bind(DataTable dt)
        {
            if (dt.Rows.Count > 0)
            {
                uPaging.GeneratePager(ref dt, rptList);
                PHList.Visible = true;
                ltlNoData.Visible = false;
            }
            else
            {
                PHList.Visible = false;
                ltlNoData.Visible = true;
            }
        }

        protected void ImgMessage_Click(object sender, ImageClickEventArgs e)
        {
        }

        protected void rptList_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
            {
                HyperLink hlJobDetail  = (HyperLink)e.Item.FindControl("hlJobDetail");
                HyperLink hlCompanyDetail = (HyperLink)e.Item.FindControl("hlCompanyDetail");
                HiddenField hdState = (HiddenField)e.Item.FindControl("hdState");
                HiddenField hdEndDate = (HiddenField)e.Item.FindControl("hdEndDate");

                if (Convert.ToDateTime(hdEndDate.Value) < DateTime.Now)
                    hlJobDetail.CssClass = "Und Flu";
                
                BUS.AdvertisementApplications.State State = (BUS.AdvertisementApplications.State)(int.Parse(hdState.Value));

                switch (State)
                {
                    case GSUKariyer.BUS.AdvertisementApplications.State.Viewed:
                        ((Literal)e.Item.FindControl("ltlViewed")).Visible = true;
                        break;
                    case GSUKariyer.BUS.AdvertisementApplications.State.NotViewed:
                        ((Literal)e.Item.FindControl("ltlNotViewed")).Visible = true;
                        break;
                    case GSUKariyer.BUS.AdvertisementApplications.State.Answered:
                        ((Literal)e.Item.FindControl("ltlViewed")).Visible = true;
                        HiddenField hdIsRead = (HiddenField)e.Item.FindControl("hdIsRead");
                        string ImgID = "ImgMessage";
                        if (Convert.ToBoolean(hdIsRead.Value))
                            ImgID = "ImgMessageOpen";
                        ((Image)e.Item.FindControl(ImgID)).Visible = true;
                        break;
                }

                int AdvertisementId = int.Parse(hlJobDetail.NavigateUrl);
                int FirmId = int.Parse(hlCompanyDetail.NavigateUrl);
                string FirmName = hlCompanyDetail.Text;
                hlJobDetail.NavigateUrl = UrlHelper.PageUrl.AdvertisementDetail(AdvertisementId, FirmName, hlJobDetail.Text);
                hlCompanyDetail.NavigateUrl = UrlHelper.PageUrl.FirmDetail(FirmId, FirmName);
            }
        }

        protected void rptList_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
            {
                if (e.CommandName == "MessageOpened" || e.CommandName == "Message") {
                    
                    HiddenField hdAdvertisementAnswer = (HiddenField)e.Item.FindControl("hdAdvertisementAnswer");
                    ltlFullName.Text = this.SessionManager.Name + " " + this.SessionManager.Surname;
                    ltlMessage.Text = Util.r(hdAdvertisementAnswer.Value);
                    MPE.Show();

                    if (e.CommandName == "Message")
                    {
                        int ID = int.Parse(((HiddenField)e.Item.FindControl("hdID")).Value);
                        BUS.AdvertisementApplications.Read(ID);
                        this.SessionManager.UnreadAnswerCount = this.SessionManager.UnreadAnswerCount - 1;
                    }
                }
            }
        }
    }
}