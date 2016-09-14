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
using GSUKariyer.BUS.Helpers;
using GSUKariyer.COMMON;
using GSUKariyer.BUS;
using GSUKariyer.WEB.UserControls.Common.HelperControls;

namespace GSUKariyer.WEB.UserControls.Advertisement
{
    public partial class uAdvertisements : BaseUserControl
    {
        private static readonly object EventOpenSearchCriteria = new object();
        protected BUS.Advertisements.SearchHelper searchHelper;

        #region Properties
        public event EventHandler OpenSearchCriteria
        {
            add { base.Events.AddHandler(EventOpenSearchCriteria, value); }
            remove { base.Events.RemoveHandler(EventOpenSearchCriteria, value); }
        }
        protected string Mode
        {
            get { return GetUrlParam(UrlHelper.PageUrl.UrlKey.Mode); }
        }
        protected string Value
        {
            get { return GetUrlParam(UrlHelper.PageUrl.UrlKey.Value); }
        }
        protected string Keyword
        {
            get { return Server.UrlDecode(GetUrlParam(UrlHelper.PageUrl.UrlKey.Keyword)); }
        }
        protected string CityCountry
        {
            get { return GetUrlParam(UrlHelper.PageUrl.UrlKey.CityCountry); }
        }
        protected string Position
        {
            get { return GetUrlParam(UrlHelper.PageUrl.UrlKey.Position); }
        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ArrangeForm();
                BindForm();
            }
        }

        #region ArrangeForm & BindForm 
        protected void ArrangeForm()
        {
            lbtnOpenSearchCriteria.PostBackUrl = UrlHelper.PageUrl.DetailSearch();


            if (!IsPostBack)
            {
            
            if (!String.IsNullOrEmpty(Mode))
            {
                switch (Mode)
                {
                    case BUS.Advertisements.SearchHelper.AdvertisementsPage.Mode.Date:
                        BUS.Advertisements.DateOption dateOption =
                            BUS.Advertisements.DateOption.Find(Value);

                        if (dateOption != null)
                        {
                            searchHelper = new BUS.Advertisements.SearchHelper();
                            searchHelper.SearchDateOption = dateOption;
                        }
                        break;
                    case BUS.Advertisements.SearchHelper.AdvertisementsPage.Mode.Sectors:
                        if (!String.IsNullOrEmpty(Value))
                        {
                            searchHelper = new BUS.Advertisements.SearchHelper();
                            searchHelper.SectorList.Add(Value);
                        }
                        break;
                    case BUS.Advertisements.SearchHelper.AdvertisementsPage.Mode.CityCountry:
                        if (!String.IsNullOrEmpty(Value))
                        {
                            searchHelper = new BUS.Advertisements.SearchHelper();

                            int? cityId = SiteParams.CityCountry.ArrangeSelectedCity(Value).ToNullableInt();
                            int? countryId = SiteParams.CityCountry.ArrangeSelectedCountry(Value).ToNullableInt();
                            if (cityId.HasValue)
                                searchHelper.CityList.Add(cityId.Value);
                            if (countryId.HasValue)
                                searchHelper.CountryList.Add(countryId.Value);
                        }
                        break;
                    case BUS.Advertisements.SearchHelper.AdvertisementsPage.Mode.WorkType:
                        searchHelper = new BUS.Advertisements.SearchHelper();
                        searchHelper.WorkTypeList.Add((int)BUS.Advertisements.WorkType.AbroadInternship);
                        searchHelper.WorkTypeList.Add((int)BUS.Advertisements.WorkType.DomesticInternship);
                        break;
                    case BUS.Advertisements.SearchHelper.AdvertisementsPage.Mode.Fast:
                        searchHelper = new GSUKariyer.BUS.Advertisements.SearchHelper();
                        if (!String.IsNullOrEmpty(Keyword))
                            searchHelper.SearchKeyword = Keyword;
                        if (!String.IsNullOrEmpty(Position))
                            searchHelper.PositionList.Add(Position);
                        if (!String.IsNullOrEmpty(CityCountry))
                        {
                            int? cityId = SiteParams.CityCountry.ArrangeSelectedCity(CityCountry).ToNullableInt();
                            int? countryId = SiteParams.CityCountry.ArrangeSelectedCountry(CityCountry).ToNullableInt();

                            if (cityId.HasValue)
                                searchHelper.CityList.Add(cityId.Value);
                            if (countryId.HasValue)
                                searchHelper.CountryList.Add(countryId.Value);
                        }
                        break;
                    case BUS.Advertisements.SearchHelper.AdvertisementsPage.Mode.MostSuitable:
                        if (SessionManager.UserId.HasValue)
                        {
                            searchHelper = new BUS.Advertisements.SearchHelper();
                            searchHelper.UsersSuitableAdv.UserId = SessionManager.UserId.Value;
                        }
                        else
                            //TODO: Üye girişi yapılması lazım
                            ;

                        break;
                }
            }
            else
            {

                
                    if (!String.IsNullOrEmpty(Request.Form[BUS.Advertisements.SearchHelper.SearchPage.ControlId.HfSearchForm]))
                    {
                        if (Request.Form[BUS.Advertisements.SearchHelper.SearchPage.ControlId.HfSearchForm] ==
                            BUS.Advertisements.SearchHelper.SearchPage.FromDetailedSearchValue)
                        {
                            if (this.Page.PreviousPage != null)
                            {
                                searchHelper = BUS.Advertisements.SearchHelper.SearchPage.Get(this.Page.PreviousPage).GetSearchHelper();
                                hfSearchCriteria.Value = searchHelper.GetCriteriaString();
                            }
                        }
                    }
            }

                }
            else
            {
                searchHelper = BUS.Advertisements.SearchHelper.CriteriaString.GetSearchHelper(hfSearchCriteria.Value);
            }

            if (searchHelper != null && String.IsNullOrEmpty(hfSearchCriteria.Value))
                hfSearchCriteria.Value = searchHelper.GetCriteriaString();
        }
        protected void BindForm()
        {
            if (searchHelper != null)
            {
                if (searchHelper.HasCriteria())
                    uAdvertisementList1.Bind(searchHelper.Search());
                else
                    ltrMessage.Text="<h2>Kriter seçemeden arama yapamazsınız.</h2>";

            }
            else
                Response.Redirect(UrlHelper.PageUrl.DetailSearch());
        }
        #endregion

        #region Button Events
        protected void lbtnOpenSearchCriteria_Click(object sender, EventArgs e)
        {
            EventHandler handler=(EventHandler)base.Events[EventOpenSearchCriteria];

            if (handler != null)
                handler(this,null);
        }
        #endregion

        protected void uAdvertisementList1_PageChanged(object sender, EventArgs e)
        {
            ArrangeForm();
            BindForm();
        }
    }
}