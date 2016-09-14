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

namespace GSUKariyer.WEB.UserControls.Cv.Edit
{
    public partial class uPersonalInfo : BaseCvEditUserControl
    {
        #region Properties
        public override int ControlOrder
        {
            get
            {
                return CVs.Forms.ControlOrders.PersonalInfoForm;
            }
        }
        public string Name
        {
            get { return txtName.Text; }
        }
        public string Surname
        {
            get { return txtSurname.Text; }
        }
        public DateTime BirthDate
        {
            get { return DateTime.Now; }
        }
        public int? Gender
        {
            get { return uGenders1.SelectedValue.ToNullableInt(); }
        }
        public int? MaritalStatus
        {
            get { return uMaritalStatus1.SelectedValue.ToNullableInt(); }
        }
        public int? BirthCity
        {
            get { return uCities1.SelectedValue.ToNullableInt(); }
        }
        public string BirthCityFree
        {
            get { return uCities1.FreeValue; }
        }
        public int? BirthCountry
        {
            get { return uCountries1.SelectedValue.ToNullableInt(); }
        }
        public string BirthCountryFree
        {
            get { return uCountries1.FreeValue; }
        }
        public int? Nationality
        {
            get { return uNationality.SelectedValue.ToNullableInt(); }
        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ArrangeForm();
            }
        }

        #region ArrangeForm
        protected void ArrangeForm()
        {
            uCities1.FreeItemValue = SiteParams.CityCountry.otherCityValue;
            uCities1.ParentControl = uCountries1;

            if (UserId.HasValue)
            {
                DataTable dtUser = Users.Generated.Get(UserId.Value);

                if (dtUser.Rows.Count > 0)
                {
                    txtName.Text = dtUser.Rows[0][Users.ColumnNames.Name].ToString();
                    txtSurname.Text = dtUser.Rows[0][Users.ColumnNames.Surname].ToString();
                    uBirthDate.SelectedValue = dtUser.Rows[0][Users.ColumnNames.Birthdate].ToNullableDateTime();
                    uGenders1.SelectedValue = dtUser.Rows[0][Users.ColumnNames.Gender].ToString();
                }
                else
                    Response.Redirect(UrlHelper.PageUrl.Default());
            }
        }
        #endregion

        #region ButtonEvents
        protected void imgBtnSend_Click(object sender, ImageClickEventArgs e)
        {
            if (!IsNewCV)
                CVs.PersonalInfo.Update(CVId.Value,MaritalStatus.Value,BirthCountry.Value,BirthCity.Value,
                    BirthCityFree,Nationality.Value,DateTime.Now);

            Submit();
        }
        #endregion

        public void Bind(DataTable dt)
        {
            if (dt.Rows.Count>0)
            {
                DataRow dr=dt.Rows[0];
                txtName.Text = dr[CVs.CustomColumnNames.UserName].ToString();
                txtSurname.Text = dr[Users.ColumnNames.Surname].ToString();
                uBirthDate.SelectedValue = dr[Users.ColumnNames.Birthdate].ToNullableDateTime();
                uGenders1.SelectedValue = dr[Users.ColumnNames.Gender].ToString();
                uMaritalStatus1.SelectedValue = dr[CVs.ColumnNames.MaritalStatus].ToString();
                uCountries1.SelectedValue = dr[CVs.ColumnNames.BirthPlaceCountry].ToString();
                uCities1.SelectedValue = dr[CVs.ColumnNames.BirthPlaceCity].ToString();
                uNationality.SelectedValue = dr[CVs.ColumnNames.Nationality].ToString();
            }else
                ThrowNoDataException("Bind");
        }
    }
}