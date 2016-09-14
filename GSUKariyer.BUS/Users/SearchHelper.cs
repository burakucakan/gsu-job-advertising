using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using GSUKariyer.DAL;

namespace GSUKariyer.BUS
{
    public partial class Users
    {
        public partial class SearchHelper
        {
            public const int MaxSelectedItemCount = 5;
            Advertisements.SearchHelper.ListValue<int?> _univDepartmentList;
            Advertisements.SearchHelper.ListValue<CVs.LanguageInfo> _languageList;
            Advertisements.SearchHelper.ListValue<int?> _gsClubsList;
            Advertisements.SearchHelper.ListValue<int?> _certificateList;
            Advertisements.SearchHelper.ListValue<string> _interestedPositionsList;

            protected int? _educationState = null;
            protected int? _age = null;
            protected int? _ageStart=null;
            protected int? _ageEnd=null;
            protected int? _workExperienceInMonth = null;
            protected int? _workingStatus = null;
            protected int? _interestedWorkType = null;

            #region Properties
            public int? EducationState
            {
                get { return _educationState; }
                set { _educationState = value; }
            }
            public int? Age
            {
                get { return _age; }
                set { 
                    _age = value;

                    switch (_age)
                    {
                        case (int)Users.AgeCriteria.NoCriteria:
                            _ageStart = null;
                            _ageEnd = null;
                            break;
                        case (int)Users.AgeCriteria.Below17:
                            _ageStart = 17;
                            _ageEnd = 20;
                            break;
                        case (int)Users.AgeCriteria.Above20:
                            _ageStart = 20;
                            _ageEnd = null;
                            break;
                        case (int)Users.AgeCriteria.Above22:
                            _ageStart = 22;
                            _ageEnd = null;
                            break;
                        case (int)Users.AgeCriteria.Above24:
                            _ageStart = 24;
                            _ageEnd = null;
                            break;
                        case (int)Users.AgeCriteria.Above26:
                            _ageStart = 26;
                            _ageEnd = null;
                            break;
                    }
                }
            }
            public int? WorkExperienceInMonth
            {
                get { return _workExperienceInMonth; }
                set { _workExperienceInMonth = value; }
            }
            public int? WorkingStatus
            {
                get { return _workingStatus; }
                set { _workingStatus = value; }
            }
            public int? InterestedWorkType
            {
                get { return _interestedWorkType; }
                set { _interestedWorkType = value; }
            }
            public Advertisements.SearchHelper.ListValue<int?> UnivDepartmentList
            {
                get { return _univDepartmentList; }
            }
            public Advertisements.SearchHelper.ListValue<CVs.LanguageInfo> LanguageList
            {
                get { return _languageList; }
            }
            public Advertisements.SearchHelper.ListValue<int?> GsClubsList
            {
                get { return _gsClubsList; }
            }
            public Advertisements.SearchHelper.ListValue<int?> CertificateList
            {
                get { return _certificateList; }
            }
            public Advertisements.SearchHelper.ListValue<string> InterestedPositionsList
            {
                get { return _interestedPositionsList; }
            }
            #endregion

            #region Constructers
            public SearchHelper()
            {
                _univDepartmentList = new Advertisements.SearchHelper.ListValue<int?>(5);
                _languageList = new Advertisements.SearchHelper.ListValue<CVs.LanguageInfo>(3);
                _gsClubsList = new Advertisements.SearchHelper.ListValue<int?>(5);
                _certificateList = new Advertisements.SearchHelper.ListValue<int?>(5);
                _interestedPositionsList = new Advertisements.SearchHelper.ListValue<string>(5);
            }
            #endregion

            #region Public Functions
            public DataTable Search()
            {
                for (int i = _univDepartmentList.ListCount; i < _univDepartmentList.MaxListCount; i++)
                    _univDepartmentList.Add(null);
                for (int i = _languageList.ListCount; i < _languageList.MaxListCount; i++)
                    _languageList.Add(new CVs.LanguageInfo());
                for (int i = _gsClubsList.ListCount; i < _gsClubsList.MaxListCount; i++)
                    _gsClubsList.Add(null);
                for (int i = _certificateList.ListCount; i < _certificateList.MaxListCount; i++)
                    _certificateList.Add(null);
                for (int i = _interestedPositionsList.ListCount; i < _interestedPositionsList.MaxListCount; i++)
                    _interestedPositionsList.Add(null);

                
                DataSet dsSearch = UsersProvider.Search(_educationState,_ageStart,_ageEnd,
                    _workExperienceInMonth, _workingStatus,_interestedWorkType, _univDepartmentList[0],
                    _univDepartmentList[1],
                    _univDepartmentList[2], _univDepartmentList[3], _univDepartmentList[4],
                    _languageList[0].Language, _languageList[1].Language, _languageList[2].Language,
                    _languageList[0].TalkGrade, _languageList[1].TalkGrade, _languageList[2].TalkGrade,
                    _languageList[0].WriteGrade, _languageList[1].WriteGrade, _languageList[2].WriteGrade,
                    _languageList[0].ReadGrade, _languageList[1].ReadGrade, _languageList[2].ReadGrade,
                    _gsClubsList[0], _gsClubsList[1], _gsClubsList[2], _gsClubsList[3], _gsClubsList[4],
                    _certificateList[0], _certificateList[1], _certificateList[2], _certificateList[3],
                    _certificateList[4], ArrangeStr(_interestedPositionsList[0]),
                    ArrangeStr(_interestedPositionsList[1]), ArrangeStr(_interestedPositionsList[2]),
                    ArrangeStr(_interestedPositionsList[3]), ArrangeStr(_interestedPositionsList[4]),
                    (int)CVs.CVState.Active,true,true);


                return dsSearch.Tables[0];
            }
            public void Clear()
            {
                _educationState = null;
                _age = null;
                _workExperienceInMonth = null;
                _workingStatus = null;
            }
            #endregion

            #region Others
            protected string ArrangeStr(string value)
            {
                if (string.IsNullOrEmpty(value))
                    return null;

                return value;
            }
            #endregion

        }
    }
}
