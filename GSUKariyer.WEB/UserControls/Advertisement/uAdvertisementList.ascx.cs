using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GSUKariyer.COMMON.Helpers.WEB;
using System.Data;
using GSUKariyer.BUS;
using GSUKariyer.COMMON;
using GSUKariyer.BUS.Helpers;
using GSUKariyer.WEB.UserControls.Common;

namespace GSUKariyer.WEB.UserControls.Advertisement
{
    public partial class uAdvertisementList : BaseUserControl
    {
        private static object PageChangedEvent = new object();

        #region Const Values
        protected const string ltrDateDefinitionId = "ltrDateDefinition";
        protected const string hlJobDetailId = "hlJobDetail";
        protected const string ltrCityCountryId = "ltrCityCountry";
        protected const string hlCompanyDetailId = "hlCompanyDetail";
        #endregion

        public event EventHandler PageChanged
        {
            add {
                base.Events.AddHandler(PageChangedEvent,value);
            }
            remove {
                base.Events.RemoveHandler(PageChangedEvent,value);
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }


        public void Bind(DataTable dt)
        {
            if (dt.Rows.Count > 0)
            {
                uPagingPostback1.GeneratePager(dt, rptAdvertisements, uPagingPostback1.ObjectTypes.Repeater);
                //uPaging.GeneratePager(ref dt, rptAdvertisements);
                rptAdvertisements.Visible = true;
                ltlNoData.Visible = false;
            }
            else
            {
                rptAdvertisements.Visible = false;
                ltlNoData.Visible = true;
            }
        }

        #region RepeaterFunctions
        protected void rptAdvertisements_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item ||
                e.Item.ItemType == ListItemType.AlternatingItem)
            {
                DataRowView rowView = (DataRowView)e.Item.DataItem;

                RepeaterHelper.GetControl<Literal>(e.Item, ltrDateDefinitionId).Text = new DateDefinitionHelper(
                    rowView[BUS.Advertisements.ColumnNames.StartDate].ToDateTime()).Definition;

                RepeaterHelper.GetControl<Literal>(e.Item, ltrCityCountryId).Text =
                    SiteParams.CityCountry.Get(
                    DBNullHelper.GetNullableValue<int>(rowView[BUS.Advertisements.ColumnNames.City]),
                    DBNullHelper.GetNullableValue<int>(rowView[BUS.Advertisements.ColumnNames.Country]));

                HyperLink hlJobDetail = RepeaterHelper.GetControl<HyperLink>(e.Item, hlJobDetailId);
                hlJobDetail.NavigateUrl = UrlHelper.PageUrl.AdvertisementDetail(
                    (int)rowView[BUS.Advertisements.ColumnNames.ID],
                    rowView[BUS.Advertisements.CustomColumnNames.FirmName].ToString(),
                    rowView[BUS.Advertisements.ColumnNames.Title].ToString());
                hlJobDetail.Text = rowView[BUS.Advertisements.ColumnNames.Title].ToString();

                HyperLink hlCompanyDetail = RepeaterHelper.GetControl<HyperLink>(e.Item, hlCompanyDetailId);
                hlCompanyDetail.NavigateUrl = UrlHelper.PageUrl.FirmDetail(
                    (int)rowView[BUS.Advertisements.ColumnNames.FirmId],
                    rowView[BUS.Advertisements.CustomColumnNames.FirmName].ToString());
                hlCompanyDetail.Text = rowView[BUS.Advertisements.CustomColumnNames.FirmName].ToString();
            }
        }
        #endregion

        protected void uPagingPostback1_PageChanged(object sender, EventArgs e)
        {
            EventHandler eventHandler = (EventHandler)base.Events[PageChangedEvent];

            if (eventHandler != null)
                eventHandler(sender,null);
        }
    }
}