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
    public partial class uCityCountryInfo : BaseCvEditUserControl
    {
        #region Const Values
        protected struct RepeaterControls
        {
            public const string uCities1 = "uCities1";
            public const string uCountries1 = "uCountries1";
        }

        protected const string PFreeClass = "Free";
        protected const int MaxItemCount = 4;
        #endregion

        #region Properties
        public override int ControlOrder
        {
            get
            {
                return CVs.Forms.ControlOrders.CityCountryInfoForm;
            }
        }
        #endregion

        protected bool _isArranged = false;
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
            if (!_isArranged)
            {
                DataTable dt = CVs.PreferredWorkPlaces.CreateTable();
                _isArranged = true;
                Bind(dt);
            }
        }
        #endregion

        #region ButtonEvents
        protected void imgBtnSend_Click(object sender, ImageClickEventArgs e)
        {
            if (!IsNewCV)
                CVs.PreferredWorkPlaces.Update(CVId.Value, GetData());

            Submit();
        }
        #endregion

        public void Bind(DataTable dt)
        {
            _isArranged = true;

            DataTable dtCities;
            DataTable dtCountries;

            dt.DefaultView.RowFilter = String.Format("{0}={1}",
                CVs.PreferredWorkPlaces.ColumnNames.Type, (int)CVs.PreferredWorkPlaces.Type.City);
            dtCities = dt.DefaultView.ToTable();
            dtCities = ArrangeData(dtCities);

            dt.DefaultView.RowFilter = String.Format("{0}={1}",
                CVs.PreferredWorkPlaces.ColumnNames.Type, (int)CVs.PreferredWorkPlaces.Type.Country);
            dtCountries = dt.DefaultView.ToTable();
            dtCountries = ArrangeData(dtCountries);

            rptCities.DataSource = dtCities;
            rptCities.DataBind();

            rptCountry.DataSource = dtCountries;
            rptCountry.DataBind();                 
        }

        #region Repeater Events
        protected string ArrangePClass(RepeaterItem rptItem)
        {
            return (rptItem.ItemIndex == 0 ? String.Empty : PFreeClass);
        }
        protected bool ArrangeValidation(RepeaterItem rptItem)
        {
            return (rptItem.ItemIndex==0);
        }
        protected string ArrangeCityDesc(RepeaterItem rptItem)
        {
            return String.Format("Şehir {0}",rptItem.ItemIndex + 1);
        }
        protected string ArrangeCityValidation(RepeaterItem rptItem)
        {
            return String.Format("Şehir {0} Bilgisini Giriniz", rptItem.ItemIndex + 1);
        }
        protected string ArrangeCityFreeItemValue()
        {
            return SiteParams.CityCountry.otherCityValue;
        }
        protected string ArrangeCountryDesc(RepeaterItem rptItem)
        {
            return String.Format("Ülke {0}",rptItem.ItemIndex + 1);
        }
        protected string ArrangeCountryValidation(RepeaterItem rptItem)
        {
            return String.Format("Ülke {0} Bilgisini Giriniz", rptItem.ItemIndex + 1);
        }
        protected string ArrangeCountryFreeItemValue()
        {
            return SiteParams.CityCountry.otherCountryValue;
        }
        #endregion

        #region Others
        protected DataTable ArrangeData(DataTable dt)
        { 
            for (int i=dt.Rows.Count;i<MaxItemCount;i++)
            {
                DataRow dr=dt.NewRow();

                dr[CVs.PreferredWorkPlaces.ColumnNames.Value] = String.Empty;
                dt.Rows.Add(dr);
            }

            return dt;
        }
        public DataTable GetData()
        {
            DataTable dt = CVs.PreferredWorkPlaces.CreateTable();

            foreach (RepeaterItem rptItem in rptCities.Items)
            {
                string freeValue = RepeaterHelper.GetControl<SiteParamControls.uCities>(
                    rptItem, RepeaterControls.uCities1).FreeValue;
                string value = RepeaterHelper.GetControl<SiteParamControls.uCities>(
                    rptItem, RepeaterControls.uCities1).SelectedValue;

                if (!(String.IsNullOrEmpty(freeValue) && String.IsNullOrEmpty(value)))
                {
                    DataRow dr = dt.NewRow();

                    dr[CVs.PreferredWorkPlaces.ColumnNames.CreateDate] = DateTime.Now;
                    dr[CVs.PreferredWorkPlaces.ColumnNames.ModifyDate] = DateTime.Now;
                    dr[CVs.PreferredWorkPlaces.ColumnNames.FreeValue] = freeValue;
                    dr[CVs.PreferredWorkPlaces.ColumnNames.Order] = rptItem.ItemIndex;
                    dr[CVs.PreferredWorkPlaces.ColumnNames.Value] = value;
                    dr[CVs.PreferredWorkPlaces.ColumnNames.Type] = (int)CVs.PreferredWorkPlaces.Type.City;

                    dt.Rows.Add(dr);
                }
            }

            foreach (RepeaterItem rptItem in rptCountry.Items)
            {
                string freeValue = RepeaterHelper.GetControl<SiteParamControls.uCountries>(
                    rptItem, RepeaterControls.uCountries1).FreeValue;
                string value = RepeaterHelper.GetControl<SiteParamControls.uCountries>(
                    rptItem, RepeaterControls.uCountries1).SelectedValue;

                if (!(String.IsNullOrEmpty(freeValue) && String.IsNullOrEmpty(value)))
                {

                    DataRow dr = dt.NewRow();

                    dr[CVs.PreferredWorkPlaces.ColumnNames.CreateDate] = DateTime.Now;
                    dr[CVs.PreferredWorkPlaces.ColumnNames.ModifyDate] = DateTime.Now;
                    dr[CVs.PreferredWorkPlaces.ColumnNames.FreeValue] = freeValue;
                    dr[CVs.PreferredWorkPlaces.ColumnNames.Order] = rptItem.ItemIndex;
                    dr[CVs.PreferredWorkPlaces.ColumnNames.Value] = value;
                    dr[CVs.PreferredWorkPlaces.ColumnNames.Type] = (int)CVs.PreferredWorkPlaces.Type.Country;

                    dt.Rows.Add(dr);
                }
            }

            return dt;
        }
        #endregion
    }
}