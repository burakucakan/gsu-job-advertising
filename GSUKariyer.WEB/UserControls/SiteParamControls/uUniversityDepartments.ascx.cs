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
    public partial class uUniversityDepartments : BaseEditViewListControl
    { 
        protected override void BindData(string value)
        {
            if (value == CVs.EducationInfo.UniversityInstitute.Other.ToString())
            {
                DataTable dt = SiteParams.CreateTable();

                DataRow dr = dt.NewRow();
                dr[SiteParams.ColumnNames.Description] = "Diğer";
                dr[SiteParams.ColumnNames.Value] = CVs.EducationInfo.UniversityDepartment.Other;
                dt.Rows.InsertAt(dr, 0);

                uEditViewControl1.BindControl(dt, SiteParams.ColumnNames.Description,
                    SiteParams.ColumnNames.Value);
            }
            else
            {
                DataTable dt=SiteParams.GetUniversityDepartments(value);

                DataRow dr = dt.NewRow();
                dr[SiteParams.ColumnNames.Description] = "Diğer";
                dr[SiteParams.ColumnNames.Value] = CVs.EducationInfo.UniversityDepartment.Other;
                dt.Rows.InsertAt(dr,0);

                uEditViewControl1.BindControl(dt, SiteParams.ColumnNames.Description,
                    SiteParams.ColumnNames.Value);
            }
        }
        protected override void SetViewData(string value)
        {
            int? valueId=value.ToNullableInt();

            if (valueId.HasValue)
                uEditViewControl1.SelectedValue = SiteParams.GetUniversityDepartmentDescription(valueId.Value);
            else
                uEditViewControl1.SelectedValue = String.Empty;
        }

    }
}