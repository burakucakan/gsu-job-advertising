using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using GSUKariyer.DAL;
using GSUKariyer.COMMON;
using GSUKariyer.COMMON.Helpers;
using GSUKariyer.COMMON.Exceptions;

namespace GSUKariyer.BUS
{
    public partial class CVs
    {
        public class Viewer 
        {
            #region CategoryTitles
            public class BaseCategoryTitle
            {
                protected const int _cacheDuration = CacheDuration.OneDay;
                protected string _defaultValue;
                protected string _paramName;

                protected string FindTitle(string language)
                {
                    string retVal = SiteParams.GetDescriptionValueForCVDetail(SiteParams.ParamGroup.CVView,
                        String.Concat(_paramName,"_",language),
                        _cacheDuration);

                    return (String.IsNullOrEmpty(retVal) ? _defaultValue : retVal);
                }
            }
            public class BaseEducationTitle:BaseCategoryTitle
            {
                public static string ArrangeDates(DateTime startDate,DateTime? endDate)
                {
                    string retval = String.Concat(FormatDateAtom(startDate.Month), ".",
                        FormatDateAtom(startDate.Year), " - ");

                    if (endDate.HasValue)
                        retval = String.Concat(retval, FormatDateAtom(endDate.Value.Month), ".",
                        FormatDateAtom(endDate.Value.Year));
                    else
                        retval = String.Concat(retval,"?");

                    return retval;
                }
                public static string ArrangeScore(decimal? graduationGrade,int? gradeSystem)
                {
                    if ((!graduationGrade.HasValue) || (!gradeSystem.HasValue))
                        return String.Empty;

                    return String.Concat(graduationGrade.ToString()," / ",
                        SiteParams.GetEducatonGradeDescription(gradeSystem.Value));
                }
                public static string ArrageDesc(string language,int? institute,int? department,string departmentOther)
                {
                    string retval=String.Empty;
                    
                    if (institute.HasValue)
                        retval=SiteParams.GetUniversityInstituteDescription(language,institute.Value);

                    string departmentDesc=String.Empty;
                    if (department.HasValue)
                    {
                        if (department == CVs.EducationInfo.UniversityDepartment.Other)
                            departmentDesc = departmentOther;
                        else
                            departmentDesc = SiteParams.GetUniversityDepartmentDescription(language,department.Value);

                        retval = String.Concat(retval, ", ", departmentDesc);
                    }

                    return retval;
                }

                protected static string FormatDateAtom(int value)
                {
                    string retval=value.ToString();
                    if (retval.Length < 2)
                        retval = String.Concat("0", retval);

                    return retval;
                }
                protected static string FormatUniversity(int university,string otherValue)
                {
                    string retval= SiteParams.GetUniversityInfoDescription(university);

                    if (university == (int)CVs.EducationInfo.UniversityInfo.Other)
                        retval = (String.IsNullOrEmpty(otherValue) ? retval : otherValue);

                    return retval;
                }
            }
            public class MaritalStatus: BaseCategoryTitle
            {
                protected MaritalStatus() : base()
                {
                    _defaultValue = "Medeni Durum";
                    _paramName = SiteParams.ParamName.MaritalStatus;
                }

                public static string GetTitle(string language)
                {
                    return new MaritalStatus().FindTitle(language);
                }
                public static string GetDescription(string language,int? value)
                {
                    if (!value.HasValue)
                        return String.Empty;

                    return SiteParams.GetMaritalStatusDescription(language,value.Value);
                }
            }
            public class Address : BaseCategoryTitle
            {
                protected Address()
                {
                    _defaultValue = "Adres";
                    _paramName = SiteParams.ParamName.Address;
                }

                public static string GetTitle(string language)
                {
                    return new Address().FindTitle(language);
                }
            }
            public class BirthPlace : BaseCategoryTitle
            {
                protected BirthPlace()
                {
                    _defaultValue = "Doğum Yeri";
                    _paramName = SiteParams.ParamName.BirthPlace;
                }

                public static string GetTitle(string language)
                {
                    return new BirthPlace().FindTitle(language);
                }
                public static string GetDescription(int? country,int? city,string cityFree)
                {
                    string countryDesc,cityDesc,retval;
                    countryDesc = cityDesc = retval = String.Empty;

                    if (country.HasValue)
                        countryDesc = SiteParams.CityCountry.GetCountryDescription(country.Value);
                    if (city.HasValue)
                        cityDesc = SiteParams.CityCountry.GetCityDescription(city.Value);
                    if (!String.IsNullOrEmpty(cityFree))
                        cityDesc = cityFree;

                    retval = countryDesc;

                    if (!String.IsNullOrEmpty(cityDesc))
                        retval = String.Concat(retval, "-", cityDesc);

                    return retval;
                }
            }
            public class DateOfBirth : BaseCategoryTitle
            {
                protected DateOfBirth()
                {
                    _defaultValue = "Doğum Tarihi";
                    _paramName = SiteParams.ParamName.DateOfBirth;
                }

                public static string GetTitle(string language)
                {
                    return new DateOfBirth().FindTitle(language);
                }
            }
            public class DrivingLicense : BaseCategoryTitle
            {
                protected DrivingLicense()
                {
                    _defaultValue = "Ehliyet";
                    _paramName = SiteParams.ParamName.DrivingLicense;
                }

                public static string GetTitle(string language)
                {
                    return new DrivingLicense().FindTitle(language);
                }
                public static string GetDescription(bool hasDrivingLicense)
                {
                    return FormatHelper.BoolFunc.GetOther(hasDrivingLicense);
                }
            }
            public class EducationInfo : BaseCategoryTitle
            {
                protected EducationInfo()
                {
                    _defaultValue = "Eğitim Bilgileri";
                    _paramName = SiteParams.ParamName.EducationInfo;
                }

                public static string GetTitle(string language)
                {
                    return new EducationInfo().FindTitle(language);
                }
            }
            public class EducationState : BaseCategoryTitle
            {
                protected EducationState()
                {
                    _defaultValue = "Eğitim Durumu";
                    _paramName = SiteParams.ParamName.EducationState;
                }

                public static string GetTitle(string language)
                {
                    return new EducationState().FindTitle(language);
                }
                public static string GetDescription(string language,int? value)
                {
                    return (value.HasValue? 
                        SiteParams.GetEducatonStateDescription(language,value.Value):
                        String.Empty);
                }
            }
            public class Experiences : BaseCategoryTitle
            {
                protected Experiences()
                {
                    _defaultValue = "İş Tecrübeleri";
                    _paramName = SiteParams.ParamName.Experiences;
                }

                public static string GetTitle(string language)
                {
                    return new Experiences().FindTitle(language);
                }
                public static string GetDescription(int? value)
                {
                    if (value.HasValue)
                        return String.Concat(value.ToString(), " ay");
                    else
                        return String.Empty;
                }
            }
            public class HomePhone : BaseCategoryTitle
            {
                protected HomePhone()
                {
                    _defaultValue = "Ev Telefonu";
                    _paramName = SiteParams.ParamName.HomePhone;
                }

                public static string GetTitle(string language)
                {
                    return new HomePhone().FindTitle(language);
                }
                public static string GetDescription(string value)
                {
                    if (value.IndexOf("-") == -1)
                        return String.Empty;

                    string[] atoms=value.Split(new string[]{"-"}, StringSplitOptions.RemoveEmptyEntries);
                    return String.Concat("(", atoms[0],") ",atoms[1]);
                }
            }
            public class Military : BaseCategoryTitle
            {
                protected Military()
                {
                    _defaultValue = "Askerlik Durumu";
                    _paramName = SiteParams.ParamName.Military;
                }

                public static string GetTitle(string language)
                {
                    return new Military().FindTitle(language);
                }
            }
            public class MobileNo : BaseCategoryTitle
            {
                protected MobileNo()
                {
                    _defaultValue = "Cep";
                    _paramName = SiteParams.ParamName.MobileNo;
                }

                public static string GetTitle(string language)
                {
                    return new MobileNo().FindTitle(language);
                }
                public static string GetDescription(string value1,string value2)
                {
                    string retval = "-";

                    if (!String.IsNullOrEmpty(value1.Replace("-", String.Empty)))
                        return retval;

                    string[] atoms = value1.Split(new string[] { "-" }, StringSplitOptions.None);
                    retval= String.Concat("(", atoms[0], ") ", atoms[1]);

                    if (!String.IsNullOrEmpty(value2.Replace("-",String.Empty)))
                    {
                        retval = String.Concat(retval, " - ");
                        atoms = value2.Split(new string[] { "-" }, StringSplitOptions.None);
                        retval = String.Concat(retval ,"(", atoms[0], ") ", atoms[1]);
                    }
                    return retval;
                }
            }
            public class Nationality : BaseCategoryTitle
            {
                protected Nationality()
                {
                    _defaultValue = "Uyruk";
                    _paramName = SiteParams.ParamName.Nationality;
                }

                public static string GetTitle(string language)
                {
                    return new Nationality().FindTitle(language);
                }
                public static string GetDescription(int? value)
                {
                    if (value.HasValue)
                        return SiteParams.CityCountry.GetCountryDescription(value.Value);

                    return String.Empty;
                }
            }
            public class PersonalInfo : BaseCategoryTitle
            {
                protected PersonalInfo()
                {
                    _defaultValue = "Kişisel Bilgiler";
                    _paramName = SiteParams.ParamName.PersonalInfo;
                }
                public static string GetTitle(string language)
                {
                    return new PersonalInfo().FindTitle(language);
                }
            }
            public class StudentNumber : BaseCategoryTitle
            {
                protected StudentNumber()
                {
                    _defaultValue = "Öğrenci Numarası";
                    _paramName = SiteParams.ParamName.StudentNumber;
                }
                public static string GetTitle(string language)
                {
                    return new StudentNumber().FindTitle(language);
                }
                public static string GetDescription(string value)
                {
                    return value;
                }
            }
            public class WorkStatus : BaseCategoryTitle
            {
                protected WorkStatus()
                {
                    _defaultValue = "Çalışma Durumu";
                    _paramName = SiteParams.ParamName.WorkStatus;
                }
                public static string GetTitle(string language)
                {
                    return new WorkStatus().FindTitle(language);
                }
                public static string GetDescription(int? value)
                {
                    if (value.HasValue)
                        return SiteParams.GetWorkingStateDescription(value.Value);

                    return String.Empty;
                }
            }
            public class MasterInfo : BaseEducationTitle
            {
                protected MasterInfo()
                {
                    _defaultValue = "Yüksek Lisans";
                    _paramName = SiteParams.ParamName.MasterInfo;
                }
                public static string GetTitle(string language)
                {
                    return new MasterInfo().FindTitle(language);
                }
                public static string GetDescription(int value)
                {
                    return string.Empty;
                }
                public static string ArrangeUniversity(int? university, string otherValue)
                {
                    if (university.HasValue)
                        return FormatUniversity(university.Value,otherValue);

                    return String.Empty;
                }
                public static bool ArrangeVisibility(int? university)
                {
                    return university.HasValue;
                }
            }
            public class HighSchoolInfo : BaseEducationTitle
            {
                protected HighSchoolInfo()
                {
                    _defaultValue = "Lise";
                    _paramName = SiteParams.ParamName.HighSchoolInfo;
                }
                public static string GetTitle(string language)
                {
                    return new HighSchoolInfo().FindTitle(language);
                }
                public static string GetDescription(int value)
                {
                    return string.Empty;
                }
                public static string ArrangeDates(DateTime endDate)
                {
                    return String.Concat(FormatDateAtom(endDate.Month), ".",
                        FormatDateAtom(endDate.Year));
                }
                public static string ArrangeHighSchool(string name)
                {
                    return name;
                }
            }
            public class LicenseInfo : BaseEducationTitle
            {
                protected LicenseInfo()
                {
                    _defaultValue = "Lisans";
                    _paramName = SiteParams.ParamName.LicenseInfo;
                }
                public static string GetTitle(string language)
                {
                    return new LicenseInfo().FindTitle(language);
                }
                public static string GetDescription(int value)
                {
                    return string.Empty;
                }
                public static string ArrangeUniversity(int university, string otherValue)
                {
                    return FormatUniversity(university, otherValue);
                }
            }
            public class ExperienceInfo : BaseCategoryTitle
            {
                protected ExperienceInfo()
                {
                    _defaultValue = "İş Tecrübeleri";
                    _paramName = SiteParams.ParamName.ExperienceInfo;
                }
                public static string GetTitle(string language)
                {
                    return new ExperienceInfo().FindTitle(language);
                }
                public static string GetDescription(string value)
                {
                    return value;
                }
                public static string ArrangeDates(DateTime startDate, DateTime? endDate)
                {
                    string retval = String.Concat(FormatDateAtom(startDate.Month), ".",
                        FormatDateAtom(startDate.Year), " - ");

                    if (endDate.HasValue)
                        retval = String.Concat(retval, FormatDateAtom(endDate.Value.Month), ".",
                        FormatDateAtom(endDate.Value.Year));
                    else
                        retval = String.Concat(retval, "?");

                    return retval;
                }
                public static string ArrangeWorkCityCountry(string value)
                {
                    if (String.IsNullOrEmpty(value))
                        return String.Empty;

                    return SiteParams.CityCountry.GetCityCountryDescription(value);
                }
                public static string ArrangeFirmName(string value)
                {
                    return value;
                }
                public static string ArrangePosition(string value)
                {
                    return SiteParams.GetPositionDescription(value);
                }

                protected static string FormatDateAtom(int value)
                {
                    string retval = value.ToString();
                    if (retval.Length < 2)
                        retval = String.Concat("0", retval);

                    return retval;
                }                

                public class FirmSector : BaseCategoryTitle
                {
                    protected FirmSector()
                    {
                        _defaultValue = "Firmanın Sektörü";
                        _paramName = SiteParams.ParamName.FirmSector;
                    }
                    public static string GetTitle(string language)
                    {
                        return new FirmSector().FindTitle(language);
                    }
                    public static string GetDescription(string value)
                    {
                        string description = SiteParams.GetSectorDescription(value);

                        if (description.Length > 1)
                            if (description[0] == '-')
                                description = description.Replace("-", String.Empty);

                        return description.Trim();
                    }
                }
                public class FirmWorkerCount : BaseCategoryTitle
                {
                    protected FirmWorkerCount()
                    {
                        _defaultValue = "Çalışan Sayısı";
                        _paramName = SiteParams.ParamName.FirmWorkerCount;
                    }
                    public static string GetTitle(string language)
                    {
                        return new FirmWorkerCount().FindTitle(language);
                    }
                    public static string GetDescription(int? value)
                    {
                        if (value.HasValue)
                            return SiteParams.GetWorkerCountDescription(value.Value);

                        return String.Empty;
                    }
                }
                public class PersonelCount : BaseCategoryTitle
                {
                    protected PersonelCount()
                    {
                        _defaultValue = "Size Bağlı Personel Sayısı";
                        _paramName = SiteParams.ParamName.PersonelCount;
                    }
                    public static string GetTitle(string language)
                    {
                        return new PersonelCount().FindTitle(language);
                    }
                    public static string GetDescription(int? value)
                    {
                        if (value.HasValue)
                            return SiteParams.GetPersonalCountDescription(value.Value);
                        else
                            return String.Empty;
                    }
                }
                public class RelatedPerson : BaseCategoryTitle
                {
                    protected RelatedPerson()
                    {
                        _defaultValue = "Firmada Bağlı Olduğu Kişi";
                        _paramName = SiteParams.ParamName.RelatedPerson;
                    }
                    public static string GetTitle(string language)
                    {
                        return new RelatedPerson().FindTitle(language);
                    }
                    public static string GetDescription(string name,string phoneNumber)
                    {
                        string phoneDesc=String.Empty;
                        if (phoneNumber.IndexOf("-") != -1)
                        {

                            string[] atoms = phoneNumber.Split(new string[] { "-" }, StringSplitOptions.RemoveEmptyEntries);
                            if (atoms.Length==2)
                                return String.Concat(name," - ","(", atoms[0], ") ", atoms[1]);
                        }

                        return String.Concat(name);
                    }
                }
                public class WorkType : BaseCategoryTitle
                {
                    protected WorkType()
                    {
                        _defaultValue = "Çalışma Şekli";
                        _paramName = SiteParams.ParamName.WorkType;
                    }
                    public static string GetTitle(string language)
                    {
                        return new WorkType().FindTitle(language);
                    }
                    public static string GetDescription(int? value)
                    {
                        if (value.HasValue)
                            return SiteParams.GetWorkingTypeDescription(value.Value);

                        return String.Empty;
                    }
                }
            }
            public class LanguageInfo : BaseCategoryTitle
            {
                protected LanguageInfo()
                {
                    _defaultValue = "Yabancı Dil";
                    _paramName = SiteParams.ParamName.LanguageInfo;
                }
                public static string GetTitle(string language)
                {
                    return new LanguageInfo().FindTitle(language);
                }
                public static string GetDescription(int? value)
                {
                    if (value.HasValue)
                        return SiteParams.GetLanguageDescription(value.Value);

                    return String.Empty;
                }
                public static string GetHowLearned(string value)
                {
                    return FormatHelper.ReplaceNoDataWithDash(value);
                }
                public static string GetDetail(string language,int readGrade, int writeGrade, 
                    int talkGrade)
                {
                    return String.Concat("(",LanguageRead.GetTitle(language),":",readGrade.ToString(),
                        " ",LanguageWrite.GetTitle(language),":",writeGrade.ToString()," ",
                        LanguageTalk.GetTitle(language),":",talkGrade.ToString(),")");
                }

                public class LanguageRead : BaseCategoryTitle
                {
                    protected LanguageRead()
                    {
                        _defaultValue = "Okuma";
                        _paramName = SiteParams.ParamName.LanguageRead;
                    }
                    public static string GetTitle(string language)
                    {
                        return new LanguageRead().FindTitle(language);
                    }
                }
                public class LanguageWrite : BaseCategoryTitle
                {
                    protected LanguageWrite()
                    {
                        _defaultValue = "Yazma";
                        _paramName = SiteParams.ParamName.LanguageWrite;
                    }
                    public static string GetTitle(string language)
                    {
                        return new LanguageWrite().FindTitle(language);
                    }
                }
                public class LanguageTalk : BaseCategoryTitle
                {
                    protected LanguageTalk()
                    {
                        _defaultValue = "Konuşma";
                        _paramName = SiteParams.ParamName.LanguageTalk;
                    }
                    public static string GetTitle(string language)
                    {
                        return new LanguageTalk().FindTitle(language);
                    }
                }
            }
            public class ComputerInfo : BaseCategoryTitle
            {
                protected ComputerInfo()
                {
                    _defaultValue = "Bilgisayar Bilgileri";
                    _paramName = SiteParams.ParamName.ComputerInfo;
                }
                public static string GetTitle(string language)
                {
                    return new ComputerInfo().FindTitle(language);
                }
                public static string GetDescription(string value)
                {
                    return value;
                }
            }
            public class CourseInfo : BaseCategoryTitle
            {
                protected CourseInfo()
                {
                    _defaultValue = "Eğitimler";
                    _paramName = SiteParams.ParamName.CourseInfo;
                }
                public static string GetTitle(string language)
                {
                    return new CourseInfo().FindTitle(language);
                }
                public static string GetDescription(string value)
                {
                    return value;
                }

                public static string GetDetail(string language,string courseFirm,DateTime? startDate,DateTime? endDate,
                    int? hour)
                {
                    string retval=String.Empty;

                    retval=courseFirm;

                    if (startDate.HasValue && endDate.HasValue)
                    {
                        retval=String.Concat(retval," <i>", startDate.Value.ToShortDateString(),
                            " - ",endDate.Value.ToShortDateString(),"</i>");
                    }

                    if (hour.HasValue)
                    {
                        retval= String.Concat(retval," (",hour.ToString()," {0}",")");
                        switch(language)
                        {
                            case SiteParams.LanguageCodes.Turkish:
                                retval=String.Format(retval,"Saat" );
                                break;
                            case SiteParams.LanguageCodes.English:
                                retval=String.Format(retval,"Hours" );
                                break;
                            case SiteParams.LanguageCodes.French:
                                retval=String.Format(retval,"h" );
                                break;
                        }
                    }
                    return retval;
                }
            }
            public class CertificateInfo : BaseCategoryTitle
            {
                protected CertificateInfo()
                {
                    _defaultValue = "Sertifika Bilgileri";
                    _paramName = SiteParams.ParamName.CertificateInfo;
                }
                public static string GetTitle(string language)
                {
                    return new CertificateInfo().FindTitle(language);
                }
                public static string GetDescription(string value)
                {
                    return value;
                }

                public static string GetDetail(string certificateFirm, DateTime? certificateDate)
                {
                    string retval = String.Empty;

                    retval = certificateFirm;

                    if (certificateDate.HasValue)
                    {
                        retval = String.Concat(retval, " - <i>", certificateDate.Value.ToShortDateString(),
                            "</i>");
                    }

                    return retval;
                }
            }
            public class Referances : BaseCategoryTitle
            {
                protected Referances()
                {
                    _defaultValue = "Referanslar";
                    _paramName = SiteParams.ParamName.Referances;
                }
                public static string GetTitle(string language)
                {
                    return new Referances().FindTitle(language);
                }
                public static string GetDescription(string name,string surname)
                {
                    return String.Concat(name," ",surname);
                }

                public static string GetDetail(string language,string workingFirm,string workingPosition,
                    string email, string phone)
                {
                    string retval = String.Empty;

                    if (!String.IsNullOrEmpty(workingFirm))
                    retval = workingFirm;

                    if (!String.IsNullOrEmpty(workingPosition))
                        retval = String.Concat(retval, " ", SiteParams.GetPositionDescription(workingPosition)) ;

                    if(!String.IsNullOrEmpty(retval))
                        retval=String.Concat(retval,"<br>");

                    if (!String.IsNullOrEmpty(phone))
                    {
                        retval = String.Concat(retval, "{0}:", phone," ");
                        switch (language)
                        {
                            case SiteParams.LanguageCodes.Turkish:
                                retval = String.Format(retval, "Tel");
                                break;
                            case SiteParams.LanguageCodes.English:
                                retval = String.Format(retval, "Phone");
                                break;
                            case SiteParams.LanguageCodes.French:
                                retval = String.Format(retval, "Téléphone");
                                break;
                        }
                    }

                    if (!String.IsNullOrEmpty(email))
                    {
                        retval = String.Concat(retval, "{0}:", email);
                        switch (language)
                        {
                            case SiteParams.LanguageCodes.Turkish:
                                retval = String.Format(retval,"E-posta");
                                break;
                            case SiteParams.LanguageCodes.English:
                                retval = String.Format(retval, "E-mail");
                                break;
                            case SiteParams.LanguageCodes.French:
                                retval = String.Format(retval, "E-mail");
                                break;
                        }
                    }

                    return retval;
                }
            }
            public class CigaretteUsage : BaseCategoryTitle
            {
                protected CigaretteUsage()
                {
                    _defaultValue = "Sigara Kullanımı";
                    _paramName = SiteParams.ParamName.CigaretteUsage;
                }
                public static string GetTitle(string language)
                {
                    return new CigaretteUsage().FindTitle(language);
                }
                public static string GetDescription(string value)
                {
                    return value;
                }

                public static string GetDetail(string language,int? value)
                {
                    if (!value.HasValue)
                        return String.Empty;

                    return SiteParams.GetCigaretteUseTypeDescription(language,value.Value);
                }
            }
            public class GSClubs : BaseCategoryTitle
            {
                protected GSClubs()
                {
                    _defaultValue = "Dernekler & Kulüpler";
                    _paramName = SiteParams.ParamName.GSClubs;
                }
                public static string GetTitle(string language)
                {
                    return new GSClubs().FindTitle(language);
                }
                public static string GetDescription(string value)
                {
                    return value;
                }

                public static string GetDetail(string language, DataTable dtClubs)
                {
                    string retval=String.Empty;

                    foreach (DataRow dr in dtClubs.Rows)
                    {
                        retval=String.Concat(retval,SiteParams.GetGSClubDescription(dr[CVs.UnivercityClubs.ColumnNames.UniversityClub].ToInt()),", ");
                    }

                    return (String.IsNullOrEmpty(retval)?retval : retval.Substring(0,retval.Length-2));
                }
            }

            #endregion
        }
    }
}
