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
    public partial class uExperienceCount : BaseEditViewListControl
    {
        protected override void BindData(string value)
        {
            uEditViewControl1.BindControl(SiteParams.GetExperiences(),SiteParams.ColumnNames.Description, 
                SiteParams.ColumnNames.Value);
        }
        protected override void SetViewData(string value)
        {
            int? valueId=value.ToNullableInt();

            if (valueId.HasValue)
                uEditViewControl1.SelectedValue = SiteParams.GetExperienceDescription(valueId.Value);     
            else
                uEditViewControl1.SelectedValue = String.Empty;
        }

    }
}