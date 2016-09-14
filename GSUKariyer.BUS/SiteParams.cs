using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using GSUKariyer.DAL;
using GSUKariyer.COMMON.Exceptions;
using GSUKariyer.COMMON;

namespace GSUKariyer.BUS {

    public partial class SiteParams
    {
        public struct LanguageCodes
        {
            public const string Turkish="tr";
            public const string English="eng";
            public const string French = "fre";
        }

        #region Const Values
        public const int TurkeyCountryCode = 65;
        #endregion

        #region Enums
        public struct ParamGroup
        {
            public const string Countries = "Countries";
            public const string TurkeyCities = "TurkeyCities";
            public const string Positions = "Positions";
            public const string Sectors = "Sectors";
            public const string GSClubs = "GSClubs";
            public const string Gender = "Gender";
            public const string MaritalStatus = "MaritalStatus";
            public const string CigaretteUseType = "CigaretteUseType";
            public const string ContactType = "ContactType";
            public const string EducationState = "EducationState";
            public const string EducationGradeSystem = "EducationGradeSystem";
            public const string UniversityInfo = "UniversityInfo";
            public const string UniversityInstitute = "UniversityInstitude";
            public const string UniversityDepartments = "UniversityDepartments";
            public const string LicenseEducationType = "LicenseEducationType";
            public const string CertificateCategory = "CertificateCategory";
            public const string AdvertisementType = "AdvertisementType";
            public const string SiteContentType = "SiteContentType";
            public const string Languages = "Languages";
            public const string Exams = "Exams";
            public const string WorkerCount = "WorkerCount";
            public const string WorkingType = "WorkingType";
            public const string WorkingStatus = "WorkingStatus";
            public const string WorkingExperience = "WorkingExperience";
            public const string PersonalCount = "PersonalCount";
            public const string Experience = "Experience";
            public const string CVState = "CVState";
            public const string CVView="CVView";
            public const string UserAges = "UserAges";
            public const string LastUploadedExcelFile = "LastUploadedExcelFile";
            public const string SurveyState = "SurveyState";
        }
        public struct ParamName
        {
            public const string AkademicClubs = "AkademicClubs";
            public const string SporClubs = "SporClubs";
            public const string CulturalClubs = "CulturalClubs";
            //CVView
            public const string MaritalStatus = "MaritalStatus";
            public const string Address = "Address";
            public const string BirthPlace = "BirthPlace";
            public const string DateOfBirth = "DateOfBirth";
            public const string DrivingLicense = "DrivingLicense";
            public const string EducationInfo = "EducationInfo";
            public const string EducationState = "EducationState";
            public const string Experiences = "Experiences";
            public const string HomePhone = "HomePhone";
            public const string Military = "Military";
            public const string MobileNo = "MobileNo";
            public const string Nationality = "Nationality";
            public const string PersonalInfo = "PersonalInfo";
            public const string StudentNumber = "StudentNumber";
            public const string WorkStatus = "WorkStatus";
            public const string MasterInfo = "MasterInfo";
            public const string HighSchoolInfo = "HighSchoolInfo";
            public const string LicenseInfo = "LicenseInfo";
            public const string ExperienceInfo = "ExperienceInfo";
            public const string FirmSector = "FirmSector";
            public const string FirmWorkerCount = "FirmWorkerCount";
            public const string PersonelCount = "PersonelCount";
            public const string RelatedPerson = "RelatedPerson";
            public const string WorkType = "WorkType";
            public const string LanguageInfo = "LanguageInfo";
            public const string LanguageRead = "LanguageRead";
            public const string LanguageWrite = "LanguageWrite";
            public const string LanguageTalk = "LanguageTalk";
            public const string ComputerInfo = "ComputerInfo";
            public const string CourseInfo = "CourseInfo";
            public const string CertificateInfo = "CertificateInfo";
            public const string Referances = "Referances";
            public const string CigaretteUsage = "CigaretteUsage";
            public const string GSClubs = "GSClubs";
        }
        #endregion

        #region Cache Functions
        protected static string ArrangeParamKey(string language, string key)
        {
            if (language == LanguageCodes.Turkish)
                return key;

            return String.Concat(key, "_", language);
        }
        private static T GetFromCache<T>(string key)
        {
            CacheManager<string, T> cacheManager = CacheManager<string, T>.GetInstance();
            return (T)cacheManager.Get(key);
        }
        private static void AddToCache(string key, object data, int cacheDurationInSeconds)
        {
            CacheManager<string, object> cacheManager = CacheManager<string, object>.GetInstance();
            cacheManager.Insert(key, data, cacheDurationInSeconds);
        }

        private static string GetDescription(string paramGroup, string value, int cacheDuration)
        {
            if (String.IsNullOrEmpty(value.Trim()))
                return "";

            string cacheKey = "ParamCode_" + paramGroup + "_" + value;
            string cacheItemListKey = "ParamCode_" + paramGroup;

            string cacheDescription = GetFromCache<string>(cacheKey);

            //Check Item List
            if (cacheDescription == null || string.IsNullOrEmpty(cacheDescription))
            {
                DataTable dtItemList = GetFromCache<DataTable>(cacheItemListKey);

                if (dtItemList != null)
                {
                    dtItemList.DefaultView.RowFilter = String.Format("{0}='{1}'", ColumnNames.Value,value);
                    if (dtItemList.DefaultView.Count > 0)
                        cacheDescription = dtItemList.DefaultView[0][ColumnNames.Description].ToString();
                    dtItemList.DefaultView.RowFilter = "";
                }
            }

            if (cacheDescription == null || string.IsNullOrEmpty(cacheDescription))
            {
                DataTable dt = GetParamsByValueFromDB(paramGroup, value);
                if (dt == null || dt.Rows.Count == 0)
                    cacheDescription = string.Empty;
                else
                    cacheDescription = dt.Rows[0][ColumnNames.Description].ToString();

                AddToCache(cacheKey, cacheDescription, cacheDuration);

                return cacheDescription;
            }
            else
                return cacheDescription;
        }
        public static string GetParamValue(string paramGroup, string name, int cacheDuration)
        {
            if (String.IsNullOrEmpty(name.Trim()))
                return String.Empty;

            string cacheKey = "ParamCodeByName_" + paramGroup + "_" + name;
            string cacheItemListKey = "ParamCode_" + paramGroup;

            string cacheValue = GetFromCache<string>(cacheKey);

            //Check Item List
            if (cacheValue == null || string.IsNullOrEmpty(cacheValue))
            {
                DataTable dtItemList = GetFromCache<DataTable>(cacheItemListKey);

                if (dtItemList != null)
                {
                    dtItemList.DefaultView.RowFilter = String.Format("{0}='{1}'",ColumnNames.ParamName ,name) ;
                    if (dtItemList.DefaultView.Count > 0)
                        cacheValue = dtItemList.DefaultView[0][ColumnNames.Value].ToString();
                    dtItemList.DefaultView.RowFilter = "";
                }
            }

            if (cacheValue == null || string.IsNullOrEmpty(cacheValue))
            {
                DataTable dt = GetParamsByNameFromDB(paramGroup, name);
                if (dt == null || dt.Rows.Count == 0)
                    cacheValue = string.Empty;
                else
                    cacheValue = dt.Rows[0][ColumnNames.Value].ToString();

                AddToCache(cacheKey, cacheValue, cacheDuration);

                return cacheValue;
            }
            else
                return cacheValue;
        }

        public static string GetDescriptionValueForCVDetail(string paramGroup, string name, int cacheDuration)
        {
            if (String.IsNullOrEmpty(name.Trim()))
                return String.Empty;

            string cacheKey = "ParamCodeByName_" + paramGroup + "_" + name;
            string cacheItemListKey = "ParamCode_" + paramGroup;

            string cacheValue = GetFromCache<string>(cacheKey);

            //Check Item List
            if (cacheValue == null || string.IsNullOrEmpty(cacheValue))
            {
                DataTable dtItemList = GetFromCache<DataTable>(cacheItemListKey);

                if (dtItemList != null)
                {
                    dtItemList.DefaultView.RowFilter = String.Format("{0}='{1}'", ColumnNames.ParamName, name);
                    if (dtItemList.DefaultView.Count > 0)
                        cacheValue = dtItemList.DefaultView[0][ColumnNames.Value].ToString();
                    dtItemList.DefaultView.RowFilter = "";
                }
            }

            if (cacheValue == null || string.IsNullOrEmpty(cacheValue))
            {
                DataTable dt = GetParamsByNameFromDB(paramGroup, name);
                if (dt == null || dt.Rows.Count == 0)
                    cacheValue = string.Empty;
                else
                    cacheValue = dt.Rows[0][ColumnNames.Description].ToString();

                AddToCache(cacheKey, cacheValue, cacheDuration);

                return cacheValue;
            }
            else
                return cacheValue;
        }

        private static DataTable GetParamsList(string paramGroup, int cacheDuration)
        {
            string cacheItemListKey = "ParamCode_" + paramGroup;

            DataTable dtCachedList = GetFromCache<DataTable>(cacheItemListKey);

            if (dtCachedList == null)
            {
                dtCachedList = GetParamsListFromDB(paramGroup);

                if (dtCachedList != null)
                    AddToCache(cacheItemListKey, dtCachedList, cacheDuration);
            }

            return dtCachedList;
        }
        public static DataTable GetParamsListFromDB(string paramGroup)
        {
            return SiteParamsProvider.GetByParamGroup(paramGroup).Tables[0];
        }

        public static string GetParamValueFromDB(string paramGroup, string value)
        {
            DataTable dtParam = GetParamsByValueFromDB(paramGroup ,value);

            if (dtParam.Rows.Count > 0)
                return dtParam.Rows[0][ColumnNames.Description].ToString();

            return String.Empty;
        }


        private static DataTable GetParamsByValueFromDB(string paramGroup, string value)
        {
            return SiteParamsProvider.GetByValue(paramGroup, value).Tables[0];
        }
        private static DataTable GetParamsByNameFromDB(string paramGroup, string name)
        {
            return SiteParamsProvider.GetByName(paramGroup, name).Tables[0];
        }
        #endregion

        #region Cache Durations
        protected static int TurkeyCitiesCacheDuration = CacheDuration.OneDay;
        protected static int CountriesCacheDuration = CacheDuration.OneDay;
        protected static int PositionsCacheDuration = CacheDuration.OneDay;
        protected static int SectorsCacheDuration = CacheDuration.OneDay;
        protected static int GSClubsCacheDuration = CacheDuration.OneDay;
        protected static int GenderCacheDuration = CacheDuration.OneDay;
        protected static int MaritalStatusCacheDuration = CacheDuration.OneDay;
        protected static int CigaretteUseTypeCacheDuration = CacheDuration.OneDay;
        protected static int ContactTypeCacheDuration = CacheDuration.OneDay;
        protected static int EducationStateCacheDuration = CacheDuration.OneDay;
        protected static int EducationGradeSystemCacheDuration = CacheDuration.OneDay;
        protected static int UniversityInfoCacheDuration = CacheDuration.OneDay;
        protected static int CertificateCategoryCacheDuration = CacheDuration.OneDay;
        protected static int AdvertisementTypeCacheDuration = CacheDuration.OneDay;
        protected static int SiteContentTypeCacheDuration = CacheDuration.OneDay;
        protected static int LanguagesCacheDuration = CacheDuration.OneDay;
        protected static int ExamCacheDuration = CacheDuration.OneDay;
        protected static int WorkerCountCacheDuration = CacheDuration.OneDay;
        protected static int WorkingTypeCacheDuration = CacheDuration.OneDay;
        protected static int PersonalCountCacheDuration= CacheDuration.OneDay;
        protected static int ExperienceCacheDuration = CacheDuration.OneDay;
        protected static int CVStatesCacheDuration = CacheDuration.OneDay;
        protected static int WorkingStateCacheDuration = CacheDuration.OneDay;
        protected static int WorkingExperienceCacheDuration = CacheDuration.OneDay;
        protected static int UserAgeCacheDuration = CacheDuration.OneDay;
        protected static int LastUploadedExcelFileCacheDuration = CacheDuration.None;
        protected static int SurveyStateCacheDuration = CacheDuration.FiveMinutes;
        #endregion

        #region Cached Params

        #region City & Country
        public class CityCountry
        {
            public const int TurkeyCode=65;
            protected const string cityPrefix = "city";
            protected const string countryPrefix = "country";
            public const string otherCityDesc = "-- Diðer";
            public const string otherCityValue = "84";
            public const string otherCountryDesc = "-- Diðer";
            public const string otherCountryValue = "72";
            protected const string allCityDesc = "-- Tüm Türkiye";
            protected const string allCountryDesc = "-- Tüm Ülkeler";

            public static string GetCityCountryDescription(string value)
            {
                return Get(ArrangeSelectedCity(value).ToNullableInt(),
                    ArrangeSelectedCountry(value).ToNullableInt());
            }
            public static string GetCityDescription(int value)
            {
                return GetDescription(ParamGroup.TurkeyCities, value.ToString(), TurkeyCitiesCacheDuration);
            }
            public static DataTable GetCities()
            {
                return GetParamsList(ParamGroup.TurkeyCities, TurkeyCitiesCacheDuration);
            }
            public static DataTable GetCities(bool showOthers, bool showAll)
            {
                DataTable dt = GetParamsList(ParamGroup.TurkeyCities, TurkeyCitiesCacheDuration);
                string filter = String.Empty;

                if (!showOthers)
                {
                    filter = String.Concat(filter,
                        String.Format("{0}<>'{1}'", SiteParams.ColumnNames.Description,
                        otherCityDesc));
                }

                if (!showAll)
                {
                    if (!String.IsNullOrEmpty(filter)) filter = String.Concat(filter, " AND ");

                    filter = String.Concat(filter,
                        String.Format("{0}<>'{1}'", SiteParams.ColumnNames.Description,
                        allCityDesc));
                }

                dt.DefaultView.RowFilter = filter;
                return dt.DefaultView.ToTable();
            }
            public static string GetCountryDescription(int value)
            {
                return GetDescription(ParamGroup.Countries, value.ToString(), CountriesCacheDuration);
            }
            public static DataTable GetCountries()
            {
                return GetParamsList(ParamGroup.Countries, CountriesCacheDuration);
            }
            public static DataTable GetCountries(bool showOthers, bool showAll)
            {
                DataTable dt = GetParamsList(ParamGroup.Countries, CountriesCacheDuration);
                string filter = String.Empty;

                if (!showOthers)
                {
                    filter = String.Concat(filter,
                        String.Format("{0}<>'{1}'",SiteParams.ColumnNames.Description, otherCountryDesc));
                }

                if (!showAll)
                {
                    if (!String.IsNullOrEmpty(filter)) filter = String.Concat(filter, " AND ");

                    filter = String.Concat(filter,
                        String.Format("{0}<>'{1}'",SiteParams.ColumnNames.Description, allCountryDesc));
                }

                dt.DefaultView.RowFilter = filter;
                return dt.DefaultView.ToTable();
            }

            public static string ArrangeSelectedCity(string value)
            {
                if (value.IndexOf(cityPrefix) == -1)
                    return String.Empty;

                return value.Replace(cityPrefix, String.Empty);
            }
            public static string GetSelectedCityValue(int cityId)
            {
                return String.Concat(cityPrefix, cityId.ToString());
            }
            public static string GetSelectedCityValue(string cityId)
            {
                return String.Concat(cityPrefix, cityId);
            }
            public static string GetSelectedCountryValue(int countryId)
            {
                return String.Concat(countryPrefix, countryId.ToString());
            }
            public static string GetSelectedCountryValue(string countryId)
            {
                return String.Concat(countryPrefix, countryId);
            }
            public static string ArrangeSelectedCountry(string value)
            {
                if (value.IndexOf(countryPrefix) == -1)
                    return String.Empty;

                return value.Replace(countryPrefix,String.Empty);
            }
            public static DataTable Get()
            {
                return Get(false,false);
            }
            public static DataTable Get(bool showOthers,bool showAll)
            {
                DataTable dt=SiteParamsProvider.GetCityCountryInfo(ParamGroup.TurkeyCities, ParamGroup.Countries).Tables[0];
                string filter = String.Empty;

                if (!showOthers)
                {
                    filter = String.Concat(filter,
                        String.Format("{0}<>'{1}' AND {2}<>'{3}'", SiteParams.ColumnNames.Description,
                        otherCityDesc, SiteParams.ColumnNames.Description, otherCountryDesc));
                }

                if (!showAll)
                {
                    if (!String.IsNullOrEmpty(filter)) filter = String.Concat(filter, " AND ");

                    filter = String.Concat(filter,
                        String.Format("{0}<>'{1}' AND {2}<>'{3}'", SiteParams.ColumnNames.Description,
                        allCityDesc, SiteParams.ColumnNames.Description, allCountryDesc));
                }

                dt.DefaultView.RowFilter = filter;
                return dt.DefaultView.ToTable();
            }
            public static string Get(int? city, int? country)
            {
                if (country.HasValue)
                {
                    if (country.Value == TurkeyCountryCode)
                        return GetCityDescription(city.Value);
                    else
                        return GetCountryDescription(country.Value);
                }
                else
                    return GetCityDescription(city.Value);
            }
        }
        #endregion

        #region Positions & Sectors
        public static string GetPositionDescription(string value)
        {
            string positionName = GetDescription(ParamGroup.Positions, value, PositionsCacheDuration);

            if (!String.IsNullOrEmpty(positionName))
                if (positionName[0] == '-')
                    return positionName.Substring(1);
            

            return GetDescription(ParamGroup.Positions, value, PositionsCacheDuration);
        }
        public static DataTable GetPositions()
        {
            return GetParamsList(ParamGroup.Positions, PositionsCacheDuration);
        }

        public static string GetSectorDescription(string value)
        {
            return GetDescription(ParamGroup.Sectors, value, SectorsCacheDuration);
        }
        public static DataTable GetSectors()
        {
            return GetParamsList(ParamGroup.Sectors, SectorsCacheDuration);
        }
        #endregion

        #region GSClubs
        public static string GetGSClubDescription(int value)
        {
            return GetDescription(ParamGroup.GSClubs, value.ToString(), GSClubsCacheDuration);
        }
        public static DataTable GetGSClubs()
        {
            return GetParamsList(ParamGroup.GSClubs, GSClubsCacheDuration);
        }
        #endregion

        #region Gender
        public static string GetGenderDescription(int value)
        {
            return GetDescription(ParamGroup.Gender, value.ToString(), GenderCacheDuration);
        }
        public static DataTable GetGenders()
        {
            return GetParamsList(ParamGroup.Gender, GenderCacheDuration);
        }
        #endregion

        #region WorkingState
        public static string GetWorkingStateDescription(int value)
        {
            return GetDescription(ParamGroup.WorkingStatus, value.ToString(),WorkingStateCacheDuration);
        }
        public static DataTable GetWorkingState()
        {
            return GetParamsList(ParamGroup.WorkingStatus, WorkingStateCacheDuration);
        }
        #endregion

        #region UserAges
        public static string GetUserAgeDescription(int value)
        {
            return GetDescription(ParamGroup.UserAges, value.ToString(), UserAgeCacheDuration);
        }
        public static DataTable GetUserAge()
        {
            return GetParamsList(ParamGroup.UserAges, UserAgeCacheDuration);
        }
        #endregion

        #region WorkingExperience
        public static string GetWorkingExperienceDescription(int value)
        {
            return GetDescription(ParamGroup.WorkingExperience, value.ToString(),WorkingExperienceCacheDuration);
        }
        public static DataTable GetWorkingExperiences()
        {
            return GetParamsList(ParamGroup.WorkingExperience, WorkingExperienceCacheDuration);
        }
        #endregion

        #region Marital Status
        public static string GetMaritalStatusDescription(int value)
        {
            return GetMaritalStatusDescription(LanguageCodes.Turkish,value); 
        }
        public static string GetMaritalStatusDescription(string language,int value)
        {

            return GetDescription(ArrangeParamKey(language, ParamGroup.MaritalStatus), value.ToString(), MaritalStatusCacheDuration);
        }
        public static DataTable GetMaritalStatus()
        {
            return GetParamsList(ParamGroup.MaritalStatus, MaritalStatusCacheDuration);
        }
        #endregion

        #region Exams
        public static string GetExamDescription(int value)
        {
            return GetDescription(ParamGroup.Exams, value.ToString(),ExamCacheDuration);
        }
        public static DataTable GetExams()
        {
            return GetParamsList(ParamGroup.Exams, ExamCacheDuration);
        }
        #endregion

        #region Working Type
        public static string GetWorkingTypeDescription(int value)
        {
            return GetDescription(ParamGroup.WorkingType, value.ToString(), WorkingTypeCacheDuration);
        }
        public static DataTable GetWorkingTypes()
        {
            return GetParamsList(ParamGroup.WorkingType, WorkingTypeCacheDuration);
        }
        #endregion

        #region CVStates
        public static string GetCVStateDescription(int value)
        {
            return GetDescription(ParamGroup.CVState, value.ToString(), CVStatesCacheDuration);
        }
        public static DataTable GetCVStates()
        {
            return GetParamsList(ParamGroup.CVState, CVStatesCacheDuration);
        }
        #endregion

        #region Experiences
        public static string GetExperienceDescription(int value)
        {
            return GetDescription(ParamGroup.Experience, value.ToString(), ExperienceCacheDuration);
        }
        public static DataTable GetExperiences()
        {
            return GetParamsList(ParamGroup.Experience, ExperienceCacheDuration);
        }
        #endregion

        #region PersonalCount
        public static string GetPersonalCountDescription(int value)
        {
            return GetDescription(ParamGroup.PersonalCount, value.ToString(), PersonalCountCacheDuration);
        }
        public static DataTable GetPersonalCount()
        {
            return GetParamsList(ParamGroup.PersonalCount, PersonalCountCacheDuration);
        }
        #endregion

        #region WorkerCount
        public static string GetWorkerCountDescription(int value)
        {
            return GetDescription(ParamGroup.WorkerCount, value.ToString(), WorkerCountCacheDuration);
        }
        public static DataTable GetWorkerCounts()
        {
            return GetParamsList(ParamGroup.WorkerCount, WorkerCountCacheDuration);
        }
        #endregion

        #region Cigarette Use Type
        public static string GetCigaretteUseTypeDescription(int value)
        {
            return GetDescription(ParamGroup.CigaretteUseType, value.ToString(), CigaretteUseTypeCacheDuration);
        }
        public static string GetCigaretteUseTypeDescription(string language,int value)
        {
            return GetDescription(ArrangeParamKey(language,ParamGroup.CigaretteUseType), value.ToString(), CigaretteUseTypeCacheDuration);
        }
        public static DataTable GetCigaretteUseTypes()
        {
            return GetParamsList(ParamGroup.CigaretteUseType, CigaretteUseTypeCacheDuration);
        }
        #endregion

        #region Contact Type
        public static string GetContactTypeDescription(int value)
        {
            return GetDescription(ParamGroup.ContactType, value.ToString(), ContactTypeCacheDuration);
        }
        public static DataTable GetContactTypes()
        {
            return GetParamsList(ParamGroup.ContactType, ContactTypeCacheDuration);
        }
        #endregion

        #region Education States
        public static string GetEducatonStateDescription(int value)
        {
            return GetEducatonStateDescription(LanguageCodes.Turkish,value);
        }

        public static string GetEducatonStateDescription(string language,int value)
        {
            return GetDescription(ArrangeParamKey(language,ParamGroup.EducationState), value.ToString(), EducationStateCacheDuration);
        }
        public static DataTable GetEducationStates()
        {
            return GetParamsList(ParamGroup.EducationState, EducationStateCacheDuration);
        }
        #endregion

        #region Languages
        public static string GetLanguageDescription(int value)
        {
            return GetDescription(ParamGroup.Languages, value.ToString(), LanguagesCacheDuration);
        }
        public static DataTable GetLanguages()
        {
            return GetParamsList(ParamGroup.Languages, LanguagesCacheDuration);
        }
        #endregion

        #region Education Grade System
        public static string GetEducatonGradeDescription(int value)
        {
            return GetDescription(ParamGroup.EducationGradeSystem, value.ToString(), EducationGradeSystemCacheDuration);
        }
        public static DataTable GetEducationGrades()
        {
            return GetParamsList(ParamGroup.EducationGradeSystem, EducationGradeSystemCacheDuration);
        }
        #endregion

        #region University Info
        public static DataTable GetRandomTop5Deparments()
        {
            return SiteParamsProvider.CustomGetRandomTop5(ParamGroup.UniversityDepartments).Tables[0];
        }
        public static string GetUniversityInfoDescription(int value)
        {
            return GetDescription(ParamGroup.UniversityInfo, value.ToString(), UniversityInfoCacheDuration);
        }
        public static DataTable GetUniversityInfo()
        {
            return GetParamsList(ParamGroup.UniversityInfo, UniversityInfoCacheDuration);
        }
        public static string GetUniversityInstituteDescription(int value)
        {
            return GetDescription(ParamGroup.UniversityInstitute, value.ToString(), UniversityInfoCacheDuration);
        }
        public static string GetUniversityInstituteDescription(string language,int value)
        {
            return GetDescription(ArrangeParamKey(language,ParamGroup.UniversityInstitute), value.ToString(), UniversityInfoCacheDuration);
        }
        public static DataTable GetUniversityInstitutes()
        {
            return GetParamsList(ParamGroup.UniversityInstitute, UniversityInfoCacheDuration);
        }
        public static DataTable GetUniversityDepartments(string institudeValue)
        {
            return GetParamsByNameFromDB(ParamGroup.UniversityDepartments, institudeValue);
        }
        public static string GetUniversityDepartmentDescription(int value)
        {
            return GetDescription(ParamGroup.UniversityDepartments, value.ToString(), UniversityInfoCacheDuration);
        }
        public static string GetUniversityDepartmentDescription(string language,int value)
        {
            return GetDescription(ArrangeParamKey(language, ParamGroup.UniversityDepartments), value.ToString(), UniversityInfoCacheDuration);
        }
        public static DataTable GetUniversityDepartments()
        {
            return GetParamsList(ParamGroup.UniversityDepartments, UniversityInfoCacheDuration);
        }
        public static string GetLicenseEducationTypeDescription(int value)
        {
            return GetDescription(ParamGroup.LicenseEducationType, value.ToString(), UniversityInfoCacheDuration);
        }
        public static DataTable GetLicenseEducationTypes()
        {
            return GetParamsList(ParamGroup.LicenseEducationType, UniversityInfoCacheDuration);
        }
        #endregion

        #region Certificate Info
        public static string GetCertificateCategoryDescription(int value)
        {
            return GetDescription(ParamGroup.CertificateCategory, value.ToString(), CertificateCategoryCacheDuration);
        }
        public static DataTable GetCertificateCategory()
        {
            return GetParamsList(ParamGroup.CertificateCategory, CertificateCategoryCacheDuration);
        }
        #endregion

        #region Advertisements
        public static string GetAdvertisementTypeDescription(int value)
        {
            return GetDescription(ParamGroup.AdvertisementType, value.ToString(), AdvertisementTypeCacheDuration);
        }
        public static DataTable GetAdvertisementTypes()
        {
            return GetParamsList(ParamGroup.AdvertisementType, AdvertisementTypeCacheDuration);
        }
        #endregion

        #region Site Contents
        public static string GetSiteContentTypeDescription(int value)
        {
            return GetDescription(ParamGroup.SiteContentType, value.ToString(), SiteContentTypeCacheDuration);
        }
        public static DataTable GetSiteContentTypes()
        {
            return GetParamsList(ParamGroup.SiteContentType, SiteContentTypeCacheDuration);
        }
        #endregion

        #region UploadedExcel
        public static string GetLastUploadedExcelFile()
        {
            return GetDescription(ParamGroup.LastUploadedExcelFile, "0", LastUploadedExcelFileCacheDuration);
        }
        public static int UpdateLastUploadedExcelFile(string fileName)
        {
            return SiteParamsProvider.UpdateByParamGroup(null,ParamGroup.LastUploadedExcelFile,fileName,null);
        }
        public static int UpdateLastUploadedExcelFile(SqlTransaction tran,string fileName)
        {
            return SiteParamsProvider.UpdateByParamGroup(tran, ParamGroup.LastUploadedExcelFile, fileName, null);
        }
        #endregion

        #region Survey 
        public static string GetSurveyStateDescription(int value)
        {
            return GetDescription(ParamGroup.SurveyState, value.ToString(), SurveyStateCacheDuration);
        }
        public static DataTable GetSurveyStates()
        {
            return GetParamsList(ParamGroup.SurveyState, SurveyStateCacheDuration);
        }
        #endregion

        #endregion
    }
}
