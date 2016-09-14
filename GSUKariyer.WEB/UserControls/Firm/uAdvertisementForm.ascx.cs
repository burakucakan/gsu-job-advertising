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
    public partial class uAdvertisementForm : BaseFirmUserControl
    {
        

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Fill();
                SetLocationSettings();
                if (Util.IsNumeric(Request.QueryString["Id"]))
                    imgBtnSend.CommandArgument = Request.QueryString["Id"].ToString();

                Bind();
            }
        }

        private void Fill()
        {
            uCountries1.SelectedValue = ((int)BUS.SiteParams.TurkeyCountryCode).ToString();
        }

        protected void SetLocationSettings()
        {
            uCities1.FreeItemValue = SiteParams.CityCountry.otherCityValue;
            uCities1.ParentControl = uCountries1;
        }

        protected void Bind()
        {
            if ((imgBtnSend.CommandArgument != "") && (int.Parse(imgBtnSend.CommandArgument) > 0))
            {
                int ID = int.Parse(imgBtnSend.CommandArgument);
                DataTable dt = BUS.Advertisements.Generated.Get(ID);
                if (dt.Rows.Count > 0) {
                    DataRow dr = dt.Rows[0];
                    txtTitle.Text = dr[BUS.Advertisements.ColumnNames.Title].ToString();
                    txtStartDate.Text = dr[BUS.Advertisements.ColumnNames.StartDate].ToDateTime().ToShortDateString();
                    txtEndDate.Text = dr[BUS.Advertisements.ColumnNames.EndDate].ToDateTime().ToShortDateString();
                    uAdvertisementTypes1.SelectedValue = dr[BUS.Advertisements.ColumnNames.Type].ToString();
                    uPositions1.SelectedValue = dr[BUS.Advertisements.ColumnNames.WorkPosition].ToString();
                    uCountries1.SelectedValue = dr[BUS.Advertisements.ColumnNames.Country].ToString();
                    uCities1.SelectedValue = dr[BUS.Advertisements.ColumnNames.City].ToString();
                    txtEmployeesCount.Text = dr[BUS.Advertisements.ColumnNames.EmployeesCount].ToString();
                    txtDetail.Text = Util.rt(dr[BUS.Advertisements.ColumnNames.Detail].ToString());
                    txtDescription.Text = Util.rt(dr[BUS.Advertisements.ColumnNames.Description].ToString());
                }
            }
        }

        protected void imgBtnSend_Click(object sender, ImageClickEventArgs e)
        {
            string Title = Util.r(txtTitle.Text);
            DateTime StartDate = Util.IsDate(txtStartDate.Text) ? DateTime.Parse(txtStartDate.Text) : DateTime.MinValue;
            DateTime EndDate = Util.IsDate(txtEndDate.Text) ? DateTime.Parse(txtEndDate.Text) : DateTime.MinValue;
            string WorkPosition = uPositions1.SelectedValue;
            int AdvertisementType = int.Parse(uAdvertisementTypes1.SelectedValue);
            string City = uCities1.SelectedValue;
            string Country = uCountries1.SelectedValue;
            int? EmployeesCount = txtEmployeesCount.Text.ToNullableInt();
            string Detail = Util.r(txtDetail.Text);
            string Description = Util.r(txtDescription.Text);

            int ID = imgBtnSend.CommandArgument == "" ? 0 : imgBtnSend.CommandArgument.ToInt();

            if (ID == 0)
                succSave.Visible = BUS.Advertisements.Generated.Add(this.SessionManager.FirmId, Title, Detail, Description, StartDate, EndDate, WorkPosition, AdvertisementType, City, Country, EmployeesCount, (int)BUS.Advertisements.State.Live, DateTime.Now, this.SessionManager.FirmId, DateTime.Now, this.SessionManager.FirmId, false) > 0;
            else
                succUpdate.Visible = BUS.Advertisements.Generated.Update(ID, this.SessionManager.FirmId, Title, Detail, Description, StartDate, EndDate, WorkPosition, AdvertisementType, City, Country, EmployeesCount, (int)BUS.Advertisements.State.Live, DateTime.Now, this.SessionManager.FirmId, false) > 0;

            errSave.Visible = !(succSave.Visible || succUpdate.Visible);
            pnlForm.Visible = !(succSave.Visible || succUpdate.Visible);
        }
    }
}