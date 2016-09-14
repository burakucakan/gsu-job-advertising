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
using GSUKariyer.BUS;

namespace GSUKariyer.WEB.UserControls.Firm
{
    public partial class uFirmAdvertisementList : BaseUserControl
    {
        public bool PagingShow { set { uPaging.Visible = value; } }

        protected void Page_Load(object sender, EventArgs e)
        {
            pnlSuccActive.Visible = false;
            pnlSuccPassive.Visible = false;
            pnlSuccDel.Visible = false;
        }

        public void Bind(DataTable dt)
        {
            if (dt.Rows.Count > 0)
            {
                uPaging.Visible = true;
                uPaging.GeneratePager(ref dt, rpt);
                rpt.Visible = true;
                ltlNoData.Visible = false;
            }
            else
            {
                rpt.Visible = false;
                ltlNoData.Visible = true;
                uPaging.Visible = false;
            }
        }

        protected void rpt_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
            {
                int AdvertisementId = ((HiddenField)e.Item.FindControl("hdId")).Value.ToInt();
                HyperLink hlTitle = (HyperLink)e.Item.FindControl("hlTitle");
                Literal ltlCity = (Literal)e.Item.FindControl("ltlCity");
                HyperLink hlApplications = (HyperLink)e.Item.FindControl("hlApplications");
                HyperLink hlEdit = (HyperLink)e.Item.FindControl("hlEdit");
                Literal ltlState = (Literal)e.Item.FindControl("ltlState");
                LinkButton lnkActive = (LinkButton)e.Item.FindControl("lnkActive");
                LinkButton lnkPassive = (LinkButton)e.Item.FindControl("lnkPassive");

                hlTitle.NavigateUrl = UrlHelper.PageUrl.AdvertisementDetail(AdvertisementId, this.SessionManager.FirmName, hlTitle.Text);
                ltlCity.Text = SiteParams.CityCountry.GetCityDescription(ltlCity.Text.ToInt());
                hlEdit.NavigateUrl = UrlHelper.PageUrl.AdvertisementForm(AdvertisementId);
                hlApplications.NavigateUrl = UrlHelper.PageUrl.FirmApplications(AdvertisementId);
                switch (ltlState.Text.ToInt())
                {
                    case (int)BUS.Advertisements.State.Live:
                        lnkActive.Visible = false;
                        lnkPassive.Visible = true;
                        break;
                    case (int)BUS.Advertisements.State.Archive:
                        lnkActive.Visible = true;
                        lnkPassive.Visible = false;
                        break;
                }
            }
        }

        protected void rpt_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
            {
                pnlSuccPassive.Visible = false;
                pnlSuccDel.Visible = false;
                int AdvertisementId = e.CommandArgument.ToInt();
                switch (e.CommandName)
                {
                    case "Passive":
                        pnlSuccPassive.Visible = BUS.Advertisements.Passive(AdvertisementId, this.SessionManager.FirmId);
                        break;
                    case "Active":
                        pnlSuccActive.Visible = BUS.Advertisements.Active(AdvertisementId, this.SessionManager.FirmId);
                        break;
                    case "Del":
                        pnlSuccDel.Visible = BUS.Advertisements.Delete(AdvertisementId, this.SessionManager.FirmId);
                        break;
                }
                Response.Redirect(UrlHelper.PageUrl.FirmAdvertisements());
            }
        }
    }
}