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
using GSUKariyer.COMMON;

namespace GSUKariyer.WEB.UserControls.Lists
{
    public partial class uAllFirms : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                Fill();
        }

        protected void Fill()
        {
            DataTable dtAllFirms = BUS.Firms.GetAll();
            DataBindHelper.BindDatalist(ref dlList, dtAllFirms);
        }

        protected void dlList_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
            {
                int FirmId = ((Literal)e.Item.FindControl("ltlFirmId")).Text.ToInt();
                string FirmName = ((Literal)e.Item.FindControl("ltlFirmName")).Text;
                HyperLink hlFirmDetail = ((HyperLink)e.Item.FindControl("hlFirmDetail"));
                hlFirmDetail.NavigateUrl = UrlHelper.PageUrl.FirmDetail(FirmId, FirmName);

                hlFirmDetail.ImageUrl = UrlHelper.ImgUrl.ImgUrlCompany(FirmId, UrlHelper.ImgUrl.ImgSizes.Thumb);
            }
        }
    }
}