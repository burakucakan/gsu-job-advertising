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
    public partial class uCountries : BaseEditViewListControl
    {
        protected struct ViewStateKeys
        {
            public const string ShowOthers = "SO";
            public const string ShowAll = "SA";
        }

        public bool ShowOthers
        {
            get { return DBNullHelper.GetNullableValue<bool>(ViewState[ViewStateKeys.ShowOthers]) ?? true; }
            set { ViewState.Add(ViewStateKeys.ShowOthers,value); }
        }
        public bool ShowAll
        {
            get { return DBNullHelper.GetNullableValue<bool>(ViewState[ViewStateKeys.ShowAll]) ?? true; }
            set { ViewState.Add(ViewStateKeys.ShowAll, value); }
        }

        protected override void BindData(string value)
        {
            uEditViewControl1.BindControl(SiteParams.CityCountry.GetCountries(ShowOthers,ShowAll),
                SiteParams.ColumnNames.Description, 
                SiteParams.ColumnNames.Value);
        }
        protected override void SetViewData(string value)
        {
            int? valueId=value.ToNullableInt();

            if (valueId.HasValue)
                uEditViewControl1.SelectedValue = SiteParams.CityCountry.GetCountryDescription(valueId.Value);
            else
                uEditViewControl1.SelectedValue = String.Empty;
        }

    }
}