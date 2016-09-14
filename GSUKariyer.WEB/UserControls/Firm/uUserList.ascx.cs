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
using GSUKariyer.BUS;
using GSUKariyer.COMMON;

namespace GSUKariyer.WEB.UserControls.Firm
{
    public partial class uUserList : BaseFirmUserControl
    {
        protected struct RepeaterControls
        {
            public const string hlimgUser = "hlimgUser";
            public const string hlUser = "hlUser";
            public const string ltrGender = "ltrGender";
            public const string ltrAge = "ltrAge";
            public const string ltrUnivDepartment = "ltrUnivDepartment";
            public const string ltrEducationState = "ltrEducationState";
            public const string ltrCity = "ltrCity";
            public const string ltrCountry = "ltrCountry";
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void Bind(DataTable dt)
        {
            if (dt.Rows.Count > 0)
            {
                uPaging.Visible = true;
                uPaging.GeneratePager(ref dt, rptUsers);
                rptUsers.Visible = true;
                ltrNoRecord.Visible = false;
            }
            else
            {
                rptUsers.Visible = false;
                uPaging.Visible = false;
                ltrNoRecord.Visible = true;
                ltrNoRecord.Text = FormatHelper.NoRecord();
            }
        }

        #region RepeaterEvents
        protected void rptUsers_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item ||
                e.Item.ItemType == ListItemType.AlternatingItem)
            {
                DataRowView drView = (DataRowView)e.Item.DataItem;

                HyperLink hlimgUser = RepeaterHelper.GetControl<HyperLink>(e.Item,RepeaterControls.hlimgUser);
                HyperLink hlUser = RepeaterHelper.GetControl<HyperLink>(e.Item, RepeaterControls.hlUser);
                Literal ltrGender = RepeaterHelper.GetControl<Literal>(e.Item, RepeaterControls.ltrGender);
                Literal ltrAge = RepeaterHelper.GetControl<Literal>(e.Item, RepeaterControls.ltrAge);
                Literal ltrUnivDepartment = RepeaterHelper.GetControl<Literal>(e.Item, RepeaterControls.ltrUnivDepartment);
                Literal ltrEducationState = RepeaterHelper.GetControl<Literal>(e.Item, RepeaterControls.ltrEducationState);
                Literal ltrCity = RepeaterHelper.GetControl<Literal>(e.Item, RepeaterControls.ltrCity);
                Literal ltrCountry = RepeaterHelper.GetControl<Literal>(e.Item, RepeaterControls.ltrCountry);

                hlimgUser.NavigateUrl = UrlHelper.PageUrl.Cv((int)drView[CVs.ColumnNames.ID],
                    drView[Users.CustomColumnNames.UserName].ToString(),
                    drView[Users.ColumnNames.Surname].ToString());
                hlimgUser.ImageUrl = UrlHelper.ImgUrl.ImgUrlUser((int)drView[Users.CustomColumnNames.UserId],
                    GSUKariyer.COMMON.UrlHelper.ImgUrl.ImgSizes.Square);

                hlUser.NavigateUrl = UrlHelper.PageUrl.Cv((int)drView[CVs.ColumnNames.ID],
                    drView[Users.CustomColumnNames.UserName].ToString(),
                    drView[Users.ColumnNames.Surname].ToString()); 
                hlUser.Text = String.Concat(drView[Users.CustomColumnNames.UserName].ToString(), " ",
                    drView[Users.ColumnNames.Surname].ToString());

                int? gender = drView[Users.ColumnNames.Gender].ToNullableInt();
                if (gender.HasValue)
                    ltrGender.Text = SiteParams.GetGenderDescription(gender.Value);
                
                DateTime? birthDate=drView[Users.ColumnNames.Birthdate].ToNullableDateTime();
                if (birthDate.HasValue)
                    ltrAge.Text = String.Concat("(",Users.GetAge(birthDate.Value).ToString(),")");

                int? educationState = drView[CVs.ColumnNames.EducationState].ToNullableInt();
                if (educationState.HasValue)
                    ltrEducationState.Text = String.Concat("(", SiteParams.GetEducatonStateDescription(educationState.Value),")");

                int? masterDepartment = drView[CVs.ColumnNames.MasterDepartment].ToNullableInt();
                string masterDepartmentFree = drView[CVs.ColumnNames.MasterDepartmentFree].ToString();
                int? licenseDepartment = drView[CVs.ColumnNames.LicenseDepartment].ToNullableInt();
                string licenseDepartmentFree = drView[CVs.ColumnNames.LicenseDepartmentFree].ToString();

                if (masterDepartment.HasValue)
                {
                    if (masterDepartment.Value != CVs.EducationInfo.UniversityDepartment.Other)
                        ltrUnivDepartment.Text = SiteParams.GetUniversityDepartmentDescription(masterDepartment.Value);
                    else if (!String.IsNullOrEmpty(masterDepartmentFree))
                        ltrUnivDepartment.Text = masterDepartmentFree;

                }
                else
                {
                    if (licenseDepartment.Value != CVs.EducationInfo.UniversityDepartment.Other)
                        ltrUnivDepartment.Text = SiteParams.GetUniversityDepartmentDescription(licenseDepartment.Value);
                    else if (!String.IsNullOrEmpty(licenseDepartmentFree))
                        ltrUnivDepartment.Text = licenseDepartmentFree;
                }

                int? city = drView[Users.ColumnNames.City].ToNullableInt();
                if (city.HasValue)
                    ltrCity.Text = SiteParams.CityCountry.GetCityDescription(city.Value);

                int? country = drView[Users.ColumnNames.Country].ToNullableInt();
                if (country.HasValue)
                    ltrCountry.Text = SiteParams.CityCountry.GetCountryDescription(country.Value); ;

            }
        }
        #endregion
    }
}