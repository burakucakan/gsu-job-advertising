using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using GSUKariyer.DAL;
using GSUKariyer.COMMON;

namespace GSUKariyer.BUS
{
    public partial class Advertisements
    {
        public partial class SearchHelper
        {
            protected string _keyword;
            protected string _firm;
            protected DateOption _dateOption;
            protected ListValue<string> _sectorList;
            protected ListValue<int> _cityList;
            protected ListValue<int> _countryList;
            protected ListValue<string> _positionList;
            protected ListValue<int> _workTypeList;
            protected SuitableAdvertisements _suitableAdvertisements;
            protected bool _searchFollowedFirms;
            protected int? _userId;

            #region Properties
            public string SearchKeyword
            {
                get { return _keyword; }
                set { _keyword = value; }
            }
            public string Firm
            {
                get { return _firm; }
                set { _firm = value; }
            }
            public DateOption SearchDateOption
            {
                get { return _dateOption; }
                set { _dateOption = value; }
            }
            public ListValue<string> SectorList
            {
                get { return _sectorList; }
            }
            public ListValue<int> CityList
            {
                get { return _cityList; }
            }
            public ListValue<int> CountryList
            {
                get { return _countryList; }
            }
            public ListValue<string> PositionList
            {
                get { return _positionList; }
            }
            public ListValue<int> WorkTypeList
            {
                get { return _workTypeList; }
            }
            public SuitableAdvertisements UsersSuitableAdv
            {
                get
                {
                    return _suitableAdvertisements;
                }
            }
            public bool SearchFollowedFirms
            {
                get { return _searchFollowedFirms; }
                set { _searchFollowedFirms = value; }
            }
            public int? UserId
            {
                get { return _userId; }
                set { _userId = value; }
            }
            #endregion

            #region Constructers
            public SearchHelper()
            {
                _sectorList = new ListValue<string>(5);
                _cityList = new ListValue<int>(5);
                _countryList=new ListValue<int>(5);
                _positionList = new ListValue<string>(5);
                _workTypeList = new ListValue<int>(5);

                _dateOption = DateOption.All;
                _suitableAdvertisements = new SuitableAdvertisements(this);
                _searchFollowedFirms = false;
            }
            #endregion

            #region HelperClasses
            public class ListValue<T>
            {
                int _maxListCount;
                protected List<T> _valueList;

                public int MaxListCount
                {
                    get { return _maxListCount; }
                }
                public int ListCount
                {
                    get { return _valueList.Count; }
                }
                public T this[int pos]
                {
                    get { return _valueList[pos]; }
                }

                public ListValue(int maxListCount)
                {
                    _valueList = new List<T>();
                    _maxListCount = maxListCount;
                }

                public bool Add(T value)
                {
                    if (_valueList.Count < _maxListCount)
                    {
                        _valueList.Add(value);
                        return true;
                    }

                    return false;
                }
                public void Clear()
                {
                    _valueList.Clear();
                }
            }
            public class CriteriaString
            {
                protected const string CriteriaSplitter = "||";
                protected const string CategorySplitter = "&&";
                SearchHelper _searchHelper;

                public CriteriaString(SearchHelper searchHelper)
                {
                    _searchHelper = searchHelper;
                }
                
                public string GetString()
                {
                    StringBuilder criteriaBuilder = new StringBuilder();

                    criteriaBuilder.Append(_searchHelper._keyword);
                    criteriaBuilder.Append(CategorySplitter);

                    criteriaBuilder.Append(_searchHelper._firm);
                    criteriaBuilder.Append(CategorySplitter);

                    if (_searchHelper._searchFollowedFirms)
                        criteriaBuilder.Append(SearchPage.UserFollowedFirms.Value);
                    else
                        criteriaBuilder.Append(String.Empty);

                    criteriaBuilder.Append(CategorySplitter);

                    if (_searchHelper._dateOption != null)
                        criteriaBuilder.Append(_searchHelper._dateOption.Value);
                    
                    criteriaBuilder.Append(CategorySplitter);

                    for (int i = 0; i < _searchHelper._sectorList.ListCount;i++ )
                    {
                        criteriaBuilder.Append(_searchHelper._sectorList[i]);
                        criteriaBuilder.Append(CriteriaSplitter);
                    }
                    criteriaBuilder.Append(CategorySplitter);

                    for (int i = 0; i < _searchHelper._cityList.ListCount; i++)
                    {
                        criteriaBuilder.Append(_searchHelper._cityList[i].ToString());
                        criteriaBuilder.Append(CriteriaSplitter);
                    }
                    criteriaBuilder.Append(CategorySplitter);

                    for (int i = 0; i < _searchHelper._countryList.ListCount; i++)
                    {
                        criteriaBuilder.Append(_searchHelper._countryList[i].ToString());
                        criteriaBuilder.Append(CriteriaSplitter);
                    }
                    criteriaBuilder.Append(CategorySplitter);


                    for (int i = 0; i < _searchHelper._positionList.ListCount; i++)
                    {
                        criteriaBuilder.Append(_searchHelper._positionList[i].ToString());
                        criteriaBuilder.Append(CriteriaSplitter);
                    }
                    criteriaBuilder.Append(CategorySplitter);

                    for (int i = 0; i < _searchHelper._workTypeList.ListCount; i++)
                    {
                        criteriaBuilder.Append(_searchHelper._workTypeList[i].ToString());
                        criteriaBuilder.Append(CriteriaSplitter);
                    }
                    criteriaBuilder.Append(CategorySplitter);

                    return criteriaBuilder.ToString();
                }
                public static SearchHelper GetSearchHelper(string value)
                {
                    string[] categorySplitter=new string[]{CategorySplitter};
                    string[] criteriaSplitter=new string[]{CriteriaSplitter};
                    SearchHelper searchHelper = new SearchHelper();

                    string[] categoryAtoms = value.Split(categorySplitter, StringSplitOptions.None);

                    if (categoryAtoms.Length == 10)
                    {
                        if (!String.IsNullOrEmpty(categoryAtoms[0]))
                            searchHelper.SearchKeyword = categoryAtoms[0];
                        if (!String.IsNullOrEmpty(categoryAtoms[1]))
                            searchHelper.Firm = categoryAtoms[1];
                        if ((!String.IsNullOrEmpty(categoryAtoms[2])) && categoryAtoms[2] == SearchPage.UserFollowedFirms.Value)
                            searchHelper.SearchFollowedFirms = true;
                        else
                            searchHelper.SearchFollowedFirms = false;
                        if (!String.IsNullOrEmpty(categoryAtoms[3]))
                        {
                            DateOption dateFound=DateOption.Find(categoryAtoms[3]);
                            if (dateFound != DateOption.All)
                                searchHelper.SearchDateOption = dateFound;
                        }
                        
                        string[] sectors=categoryAtoms[4].Split(criteriaSplitter,StringSplitOptions.RemoveEmptyEntries);
                        for (int i = 0; i < sectors.Length; i++)
                        {
                            searchHelper.SectorList.Add(sectors[i]);
                        }

                        string[] citys = categoryAtoms[5].Split(criteriaSplitter, StringSplitOptions.RemoveEmptyEntries);
                        for (int i = 0; i < citys.Length; i++)
                        {
                            searchHelper.CityList.Add(citys[i].ToInt());
                        }

                        string[] countrys = categoryAtoms[6].Split(criteriaSplitter, StringSplitOptions.RemoveEmptyEntries);
                        for (int i = 0; i < countrys.Length; i++)
                        {
                            searchHelper.CityList.Add(countrys[i].ToInt());
                        }

                        string[] positions = categoryAtoms[7].Split(criteriaSplitter, StringSplitOptions.RemoveEmptyEntries);
                        for (int i = 0; i < positions.Length; i++)
                        {
                            searchHelper.PositionList.Add(positions[i]);
                        }

                        string[] workTypes = categoryAtoms[8].Split(criteriaSplitter, StringSplitOptions.RemoveEmptyEntries);
                        for (int i = 0; i < workTypes.Length; i++)
                        {
                            searchHelper.WorkTypeList.Add(workTypes[i].ToInt());
                        }
                    }
                    else
                        throw new Exception("Search Criteria Error!!");

                    return searchHelper;
                }
            }
            public class SuitableAdvertisements
            {
                protected SearchHelper _searchHelper;
                protected int? _userId;

                public SuitableAdvertisements(SearchHelper searchHelper)
                {
                    _searchHelper = searchHelper;
                }
                public int? UserId
                {
                    set{
                        if (value.HasValue)
                        {
                            if (_userId.HasValue)
                                if (_userId.Value == value.Value)
                                    return;

                            _userId = value;

                            DataSet dsSuitableCriterias=AdvertisementsProvider.GetSuitableAdvCriterias(_userId.Value,
                                (int)CVs.CVState.Active);

                            DataTable dtAdvertisement = dsSuitableCriterias.Tables[0];
                            DataTable dtInterestedJobPositions = dsSuitableCriterias.Tables[1];
                            DataTable dtCvWorkPlaces = dsSuitableCriterias.Tables[2];

                            foreach (DataRow dr in dtAdvertisement.Rows)
                            {
                                _searchHelper.WorkTypeList.Add((int)dr[CVs.ColumnNames.InterestedAdvertisementType]);
                            }

                            foreach (DataRow dr in dtInterestedJobPositions.Rows)
                            {
                                _searchHelper.PositionList.Add(dr[CVInterestedJobPositons.ColumnNames.InterestedJobPositions].ToString());
                            }

                            foreach (DataRow dr in dtCvWorkPlaces.Rows)
                            {
                                int? cityCountry = DBNullHelper.GetNullableValue<int>(dr[CVWorkPlaces.ColumnNames.Value]);
                                if (cityCountry.HasValue)
                                {
                                    if ((int)dr[CVWorkPlaces.ColumnNames.Type] ==
                                        (int)CVs.PreferredWorkPlaces.Type.City)
                                        _searchHelper.CityList.Add(cityCountry.Value);
                                    else if ((int)dr[CVWorkPlaces.ColumnNames.Type] ==
                                        (int)CVs.PreferredWorkPlaces.Type.Country)
                                        _searchHelper.CityList.Add(cityCountry.Value);
                                }
                            }

                            _searchHelper._userId=value;
                            _searchHelper._searchFollowedFirms=true;
                        }
                    }
                    get { return _userId; }
                }
            }
            #endregion

            #region Public Functions
            public bool HasCriteria()
            {
                bool retval = false;

                if (!String.IsNullOrEmpty(_keyword))
                    retval = true;

                if (!String.IsNullOrEmpty(_firm))
                    retval = true;

                if (_dateOption != DateOption.All)
                    retval = true;

                if (_searchFollowedFirms == true)
                    retval = true;

                if (_sectorList.ListCount > 0)
                    retval = true;

                if (_cityList.ListCount > 0)
                    retval = true;

                if (_countryList.ListCount > 0)
                    retval = true;

                if (_positionList.ListCount > 0)
                    retval = true;

                if (_workTypeList.ListCount > 0)
                    retval = true;

                if (UserId.HasValue)
                    retval = true;

                return retval;
            }
            public DataTable Search()
            {
                for (int i = _sectorList.ListCount; i < _sectorList.MaxListCount; i++)
                    _sectorList.Add(null);
                for (int i = _positionList.ListCount; i < _positionList.MaxListCount; i++)
                    _positionList.Add(null);
                for (int i = _cityList.ListCount; i < _cityList.MaxListCount; i++)
                    _cityList.Add(-1);
                for (int i = _countryList.ListCount; i < _countryList.MaxListCount; i++)
                    _countryList.Add(-1);
                for (int i = _workTypeList.ListCount; i < _workTypeList.MaxListCount; i++)
                    _workTypeList.Add(-1);

                DateTime? dateStart;
                DateTime? dateEnd;
                ArrangeDateOption(_dateOption,out dateStart ,out dateEnd);

                DataSet dsSearch = AdvertisementsProvider.Search(DateTime.Now,ArrangeStr(_keyword),ArrangeStr(_firm),
                    dateStart, dateEnd, _sectorList[0], _sectorList[1], _sectorList[2], _sectorList[3],
                    _sectorList[4], _positionList[0], _positionList[1],_positionList[2],_positionList[3],
                    _positionList[4], ArrangeInt(_cityList[0]), ArrangeInt(_cityList[1]),
                    ArrangeInt(_cityList[2]), ArrangeInt(_cityList[3]), ArrangeInt(_cityList[4]),
                    ArrangeInt(_countryList[0]), ArrangeInt(_countryList[1]), ArrangeInt(_countryList[2]),
                    ArrangeInt(_countryList[3]), ArrangeInt(_countryList[4]), ArrangeInt(_workTypeList[0]),
                    ArrangeInt(_workTypeList[1]), ArrangeInt(_workTypeList[2]), ArrangeInt(_workTypeList[3]),
                    ArrangeInt(_workTypeList[4]),_searchFollowedFirms,_userId,
                    (int)Advertisements.State.Live,false);
                

                return dsSearch.Tables[0];
            }
            public string GetCriteriaString()
            {
                CriteriaString criteriaString = new CriteriaString(this);
                return criteriaString.GetString();
            }
            public DataSet GetRptDataSources()
            {
                DataSet dataSet = new DataSet();

                #region Keyword
                DataTable dtCriteria = SearchPage.CreateSelectedValueTable();
                if (!String.IsNullOrEmpty(_keyword))
                {
                    DataRow dr = dtCriteria.NewRow();
                    dr[SearchPage.ListColumnNames.Definition] = _keyword;
                    dr[SearchPage.ListColumnNames.Value] = _keyword;
                    dr[SearchPage.ListColumnNames.ParentControlId] = SearchPage.ControlId.TxtKeyword;
                    dtCriteria.Rows.Add(dr);
                }
                #endregion

                #region DateOption
                DataTable dtDateOption=SearchPage.CreateSelectedValueTable();
                if (_dateOption != DateOption.All)
                {
                    DataRow dr = dtDateOption.NewRow();
                    dr[SearchPage.ListColumnNames.Definition] = _dateOption.Description;
                    dr[SearchPage.ListColumnNames.Value] = _dateOption.Value;
                    dr[SearchPage.ListColumnNames.ParentControlId] = SearchPage.ControlId.RblDateOptions;
                    dtDateOption.Rows.Add(dr);
                }
                #endregion

                #region Sectors
                DataTable dtSectors = SearchPage.CreateSelectedValueTable();
                for (int i = 0; i < _sectorList.ListCount; i++)
                {
                    DataRow dr = dtSectors.NewRow();
                    dr[SearchPage.ListColumnNames.Definition] = SiteParams.GetSectorDescription(_sectorList[i]);
                    dr[SearchPage.ListColumnNames.Value] = _sectorList[i];
                    dr[SearchPage.ListColumnNames.ParentControlId] = SearchPage.ControlId.LbSectors;
                    dtSectors.Rows.Add(dr);
                }
                #endregion

                #region CityCountry
                DataTable dtCityCountry = SearchPage.CreateSelectedValueTable();
                for (int i = 0; i < _cityList.ListCount; i++)
                {
                    DataRow dr = dtCityCountry.NewRow();
                    dr[SearchPage.ListColumnNames.Definition] = SiteParams.CityCountry.GetCityDescription(_cityList[i]);
                    dr[SearchPage.ListColumnNames.Value] = SiteParams.CityCountry.GetSelectedCityValue(_cityList[i].ToInt());
                    dr[SearchPage.ListColumnNames.ParentControlId] = SearchPage.ControlId.LbCityCountry;
                    dtCityCountry.Rows.Add(dr);
                }
                for (int i = 0; i < _countryList.ListCount; i++)
                {
                    DataRow dr = dtCityCountry.NewRow();
                    dr[SearchPage.ListColumnNames.Definition] = SiteParams.CityCountry.GetCountryDescription(_countryList[i]);
                    dr[SearchPage.ListColumnNames.Value] = SiteParams.CityCountry.GetSelectedCountryValue(_countryList[i].ToInt());
                    dr[SearchPage.ListColumnNames.ParentControlId] = SearchPage.ControlId.LbCityCountry;
                    dtCityCountry.Rows.Add(dr);
                }
                #endregion

                #region Position
                DataTable dtPosition = SearchPage.CreateSelectedValueTable();
                for (int i = 0; i < _positionList.ListCount; i++)
                {
                    DataRow dr = dtPosition.NewRow();
                    dr[SearchPage.ListColumnNames.Definition] = SiteParams.GetPositionDescription( _positionList[i]);
                    dr[SearchPage.ListColumnNames.Value] = _positionList[i];
                    dr[SearchPage.ListColumnNames.ParentControlId] = SearchPage.ControlId.LbPosition;
                    dtPosition.Rows.Add(dr);
                }
                #endregion

                #region WorkTypes
                DataTable dtWorkType = SearchPage.CreateSelectedValueTable();
                for (int i = 0; i < _workTypeList.ListCount; i++)
                {
                    DataRow dr = dtWorkType.NewRow();
                    dr[SearchPage.ListColumnNames.Definition] = SiteParams.GetAdvertisementTypeDescription(_workTypeList[i]);
                    dr[SearchPage.ListColumnNames.Value] = _workTypeList[i];
                    dr[SearchPage.ListColumnNames.ParentControlId] = SearchPage.ControlId.LbWorkType;
                    dtWorkType.Rows.Add(dr);
                }
                #endregion

                #region Firm
                DataTable dtFirm = SearchPage.CreateSelectedValueTable();
                if (!String.IsNullOrEmpty(_firm))
                {
                    DataRow dr = dtFirm.NewRow();
                    dr[SearchPage.ListColumnNames.Definition] = _firm;
                    dr[SearchPage.ListColumnNames.Value] = _firm;
                    dr[SearchPage.ListColumnNames.ParentControlId] = SearchPage.ControlId.TxtFirm;
                    dtFirm.Rows.Add(dr);
                }
                if (_searchFollowedFirms)
                {
                    DataRow dr = dtFirm.NewRow();
                    dr[SearchPage.ListColumnNames.Definition] = SearchPage.UserFollowedFirms.Description;
                    dr[SearchPage.ListColumnNames.Value] = SearchPage.UserFollowedFirms.Value ;
                    dr[SearchPage.ListColumnNames.ParentControlId] = SearchPage.ControlId.ChbMyFirms;
                    dtFirm.Rows.Add(dr);
                }
                #endregion

                dataSet.Tables.Add(dtCriteria);
                dataSet.Tables.Add(dtDateOption);
                dataSet.Tables.Add(dtSectors);
                dataSet.Tables.Add(dtCityCountry);
                dataSet.Tables.Add(dtPosition);
                dataSet.Tables.Add(dtWorkType);
                dataSet.Tables.Add(dtFirm);
                return dataSet;
            }
            public void Clear()
            {
                _keyword = String.Empty;
                _firm = String.Empty;
                _dateOption = DateOption.All;
                _searchFollowedFirms = false;
                _sectorList.Clear();
                _cityList.Clear();
                _countryList.Clear();
                _positionList.Clear();
                _workTypeList.Clear();
            }
            #endregion

            #region Others
            protected int? ArrangeInt(int value)
            {
                return (value==-1?null:(int?)value);
            }
            protected string ArrangeStr(string value)
            {
                if (string.IsNullOrEmpty(value))
                    return null;

                return value;
            }
            protected void ArrangeDateOption(DateOption dateOption, out DateTime? dateStart,
                out DateTime? dateEnd)
            {
                dateStart = null;
                dateEnd = null;

                if (dateOption == DateOption.All)
                    ;
                else if (dateOption == DateOption.Today)
                {
                    dateStart = DateTime.Today;
                    dateEnd = DateTime.Today.AddDays(1);
                }
                else if (dateOption == DateOption.Last3Days)
                {
                    dateStart = DateTime.Today.AddDays(-3);
                    dateEnd = DateTime.Today.AddDays(1);
                }
                else if (dateOption == DateOption.Last7Days)
                {
                    dateStart = DateTime.Today.AddDays(-7);
                    dateEnd = DateTime.Today.AddDays(1);
                }
                else if (dateOption == DateOption.Last15Days)
                {
                    dateStart = DateTime.Today.AddDays(-15);
                    dateEnd = DateTime.Today.AddDays(1);
                }
                else if (dateOption == DateOption.LastMonth)
                {
                    dateStart = DateTime.Today.AddMonths(-1);
                    dateEnd = DateTime.Today.AddDays(1);
                }

            }
            #endregion
        }
    }
}
