using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;
using GSUKariyer.COMMON.Helpers.WEB;
using GSUKariyer.COMMON;
using System.Data;

namespace GSUKariyer.BUS
{
    public partial class Advertisements
    {
        public partial class SearchHelper
        {
            public class SearchPage
            {
                #region Enums
                public struct ListColumnNames
                {
                    public const string Definition = "Definition";
                    public const string Value = "Value";
                    public const string ParentControlId = "ParentControlId";
                }
                public struct UserFollowedFirms
                {
                    public const string Description = "Takibimdeki Firmalar";
                    public const string Value = "uff";
                }
                #endregion

                public const int MaxSelectedItemCount = 5;
                public const string FromDetailedSearchValue = "FromDetailedSearch";
                protected const string SearchControl="uSearch1";
                protected const string ContentPlaceHolderId = "ContentPlaceHolder1";

                #region Controls
                public struct ControlId
                {
                    public const string UItem = "UItem1";
                    public const string HfSearchForm = "hfSearchForm";
                    public const string RptSearchKeyword = "rptSearchKeyword";
                    public const string RptFirm = "rptFirm";
                    public const string RptDate = "rptDate";
                    public const string RptSectors = "rptSectors";
                    public const string RptSelectedCityCountry = "rptSelectedCityCountry";
                    public const string RptPositions = "rptPositions";
                    public const string RptWorkTypes = "rptWorkTypes";
                    public const string TxtKeyword = "txtKeyword";
                    public const string RblDateOptions = "rblDateOptions";
                    public const string LbSectors = "lbSectors";
                    public const string LbCityCountry = "lbCityCountry";
                    public const string LbPosition = "lbPosition";
                    public const string LbWorkType = "lbWorkType";
                    public const string TxtFirm = "txtFirm";
                    public const string ChbMyFirms = "chbMyFirms";
                }
                #endregion

                protected UserControl _control;

                #region Constructers
                public SearchPage(UserControl control)
                {
                    _control = control;
                }
                #endregion

                #region Public Functions
                public SearchHelper GetSearchHelper()
                {
                    SearchHelper searchHelper = new SearchHelper();
                    Repeater repeater = null;

                    repeater = _control.FindControl(ControlId.RptSearchKeyword) as Repeater;
                    foreach (RepeaterItem rptItem in repeater.Items)
                    {
                        searchHelper.SearchKeyword = RepeaterHelper.GetControl<BaseUserControl>(
                            rptItem, ControlId.UItem).SpecialValue;
                    }

                    repeater = _control.FindControl(ControlId.RptFirm) as Repeater;
                    foreach (RepeaterItem rptItem in repeater.Items)
                    {
                        string value = RepeaterHelper.GetControl<BaseUserControl>(
                            rptItem, ControlId.UItem).SpecialValue;

                        if (value == SearchPage.UserFollowedFirms.Value)
                            searchHelper.SearchFollowedFirms = true;
                        else
                            searchHelper.Firm = RepeaterHelper.GetControl<BaseUserControl>(
                                rptItem, ControlId.UItem).SpecialValue;
                    }

                    repeater = _control.FindControl(ControlId.RptDate) as Repeater;
                    foreach (RepeaterItem rptItem in repeater.Items)
                    {
                        searchHelper.SearchDateOption = BUS.Advertisements.DateOption.Find(
                            RepeaterHelper.GetControl<BaseUserControl>(
                            rptItem, ControlId.UItem).SpecialValue);
                    }

                    repeater = _control.FindControl(ControlId.RptSectors) as Repeater;
                    foreach (RepeaterItem rptItem in repeater.Items)
                    {
                        searchHelper.SectorList.Add(RepeaterHelper.GetControl<BaseUserControl>(
                            rptItem, ControlId.UItem).SpecialValue);
                    }

                    repeater = _control.FindControl(ControlId.RptSelectedCityCountry) as Repeater;
                    foreach (RepeaterItem rptItem in repeater.Items)
                    {
                        string selectedValue = RepeaterHelper.GetControl<BaseUserControl>(rptItem,ControlId.UItem).SpecialValue;
                        int? selectedCity = SiteParams.CityCountry.ArrangeSelectedCity(selectedValue).ToNullableInt();
                        int? selectedCountry = SiteParams.CityCountry.ArrangeSelectedCountry(selectedValue).ToNullableInt();

                        if (selectedCity.HasValue)
                            searchHelper.CityList.Add(selectedCity.Value);

                        if (selectedCountry.HasValue)
                            searchHelper.CountryList.Add(selectedCountry.Value);
                    }

                    repeater = _control.FindControl(ControlId.RptPositions) as Repeater;
                    foreach (RepeaterItem rptItem in repeater.Items)
                    {
                        searchHelper.PositionList.Add(RepeaterHelper.GetControl<BaseUserControl>(
                            rptItem, ControlId.UItem).SpecialValue);
                    }

                    repeater = _control.FindControl(ControlId.RptWorkTypes) as Repeater;
                    foreach (RepeaterItem rptItem in repeater.Items)
                    {
                        searchHelper.WorkTypeList.Add(RepeaterHelper.GetControl<BaseUserControl>(
                            rptItem, ControlId.UItem).SpecialValue.ToInt());
                    }

                    return searchHelper;
                }
                #endregion

                public static SearchPage Get(Page value)
                {
                    return new SearchPage((UserControl)value.Master.FindControl(
                        ContentPlaceHolderId).FindControl(SearchControl));
                }
                public static DataTable CreateSelectedValueTable()
                {
                    DataTable dt = new DataTable();
                    dt.Columns.Add(ListColumnNames.Definition);
                    dt.Columns.Add(ListColumnNames.Value);
                    dt.Columns.Add(ListColumnNames.ParentControlId);

                    return dt;
                }
            }
        }
    }
}
