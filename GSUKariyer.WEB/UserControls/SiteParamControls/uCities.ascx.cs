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

namespace GSUKariyer.WEB.UserControls.SiteParamControls
{
    public partial class uCities : BaseEditViewListControl
    {
        protected struct ViewStateKeys
        {
            public const string ShowOthers = "SO";
            public const string ShowAll = "SA";
        }

        public bool ShowOthers
        {
            get { return DBNullHelper.GetNullableValue<bool>(ViewState[ViewStateKeys.ShowOthers]) ?? true; }
            set { ViewState.Add(ViewStateKeys.ShowOthers, value); }
        }
        public bool ShowAll
        {
            get { return DBNullHelper.GetNullableValue<bool>(ViewState[ViewStateKeys.ShowAll]) ?? true; }
            set { ViewState.Add(ViewStateKeys.ShowAll, value); }
        }

        protected override void BindData(string value)
        {
            if (value == SiteParams.CityCountry.TurkeyCode.ToString() || ParentControl==null)
            {
                uEditViewControl1.BindControl(SiteParams.CityCountry.GetCities(ShowOthers, ShowAll),
                    SiteParams.ColumnNames.Description,
                    SiteParams.ColumnNames.Value);
            }
            else
            {
                DataTable dt = new DataTable();
                dt.Columns.Add(SiteParams.ColumnNames.Description);
                dt.Columns.Add(SiteParams.ColumnNames.Value);

                DataRow dr = dt.NewRow();
                dr[SiteParams.ColumnNames.Description] =SiteParams.CityCountry.otherCityDesc ;
                dr[SiteParams.ColumnNames.Value] = SiteParams.CityCountry.otherCityValue;
                dt.Rows.Add(dr);

                uEditViewControl1.BindControl(dt,
                    SiteParams.ColumnNames.Description,
                    SiteParams.ColumnNames.Value);
            }

        }
        protected override void SetViewData(string value)
        {
            int? cityId=value.ToNullableInt();

            if (cityId.HasValue)
                uEditViewControl1.SelectedValue = SiteParams.CityCountry.GetCityDescription(cityId.Value);                  
            else
                uEditViewControl1.SelectedValue = String.Empty;
        }

    }
}