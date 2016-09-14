using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Web;

namespace GSUKariyer.COMMON
{
    public partial class UrlHelper
    {

        public enum ContentTypes
        {
            Duyurular = 0,
            Roportajlar = 1,
            BasariHikayeleri = 2,
            Makaleler = 3
        }

        public class PageUrl
        {
            public class PageName
            {
                public const string Default = "Kariyer.aspx";  //Ana Sayfa
                public const string Error = "Error.aspx";  //Hata Sayfası

                public const string AboutUs = "AboutUs.aspx";  //Hakkımızda
                public const string TermsOfUse = "TermsOfUse.aspx";  //Kullanım Şartları
                public const string Contact = "Contact.aspx"; //İletişim                

                public const string Contents = "Contents.aspx";  //İçerik Listesi
                public const string ContentDetail = "ContentDetail.aspx";  //İçerik Detayı

                public const string Search = "Search.aspx"; //Arama
                public const string Sectors = "Sectors.aspx"; //Sektörler

                public const string Advertisements = "Advertisements.aspx"; //İlan Listesi / Arama Sonuçları
                public const string AdvertisementDetail = "AdvertisementDetail.aspx"; //İlan Detay

                public const string Student = "Student.aspx"; //Öğrenci Ana Sayfası / Login Sonrası

                public const string Signup = "Signup.aspx";  //Üyelik Formu
                public const string UserApplications = "UserApplications.aspx";  //Başvurularım
                public const string UserFrontPosts = "UserFrontPosts.aspx";  //Ön Yazılarım

                public const string UserCvWizard = "UserCvWizard.aspx"; //Cv Düzenleme Formu
                public const string Cv = "Cv.aspx"; //Cv Görüntüleme
                public const string CvForm = "CvForm.aspx"; //Cv Düzenleme, Ekleme


                public const string Firm = "Firm.aspx";  //Firma Ana Sayfa / Login Sonrası

                public const string AllFirms = "AllFirms.aspx";  //Firmalar Listesi
                public const string FirmDetail = "FirmDetail.aspx";  //Firma Detay Sayfası

                public const string FirmLogin = "FirmLogin.aspx";  //Firma Login
                public const string FirmSignup = "FirmSignup.aspx";  //Firma Üyelik Başvurusu

                public const string UserSearch = "UserSearch.aspx";  //Eleman Ara
                public const string Users = "Users.aspx";  //Elemanlar / Arama sonuçları
                public const string Departments = "Departments.aspx"; //Bölümler

                public const string AdvertisementForm = "AdvertisementForm.aspx";  //Yeni İlan / Güncelle
                public const string FirmAdvertisements = "FirmAdvertisements.aspx";  //İlanlarım
                public const string FirmApplications = "FirmApplications.aspx";  //Başvurular
            }

            public struct UrlKey
            {
                public const string Id = "Id";
                public const string AdvertisementId = "AdvertisementId";
                public const string AdvertisementApplicationId = "AdvertisementApplicationId";
                public const string Title = "Title";
                public const string Position = "Position";
                public const string Name = "Name";
                public const string ContentType = "ContentType";
                public const string Mode = "Mode";
                public const string Value = "Value";
                public const string Keyword = "Keyword";
                public const string CityCountry = "CityCountry";
                public const string Age = "Age";
                public const string EducationState = "EducationState";
                public const string WorkStatus = "WorkStatus";
                public const string InterestedWorkType = "InterestedWorkType";
                public const string Department = "Department";
            }

            public static string GetURL(string Url)
            {
                return GetURLWithParams(Url, true);
            }

            public static string Default() {
                return GetURLWithParams(PageName.Default, true);
            }

            public static string Signup()
            {
                return GetURLWithParams(PageName.Signup, true);
            }

            public static string Sectors(int SectorId)
            {
                return GetURLWithParams(PageName.Sectors, true, new UrlParam(UrlKey.Id, SectorId.ToString()));
            }

            public static string AdvertisementDetail(int AdvertisementID, string CompanyName, string Title)
            {
                return GetURLWithParams(PageName.AdvertisementDetail, true, 
                    new UrlParam(UrlKey.Id, AdvertisementID.ToString()),
                    new UrlParam(UrlKey.Name, CompanyName),
                    new UrlParam(UrlKey.Title, Title));
            }

            public static string Contents(UrlHelper.ContentTypes ContentType)
            {
                //gasukariyer.com/Contents.aspx?ContentType=roportajlar = //gasukariyer.com/roprtajlar/
                return GetURLWithParams(PageName.Contents, true, new UrlParam(UrlKey.ContentType, ContentType.ToString()));
            }

            public static string ContentDetail(int SiteContentID, UrlHelper.ContentTypes ContentType, string ContentTitle)
            {
                //gsukariyer.com/__j24/makaleler/makeladi.gsu
                return GetURLWithParams(PageName.ContentDetail, true,
                    new UrlParam(UrlKey.Id, SiteContentID.ToString()), //__j24
                    new UrlParam(UrlKey.ContentType, ContentType.ToString()),  //makaleler
                    new UrlParam(UrlKey.Title, Util.FormatURL(ContentTitle)));  //makale adı
            }

            public static string FirmDetail(int FirmID, string FirmName)
            {
                return GetURLWithParams(PageName.FirmDetail, true,
                    new UrlParam(UrlKey.Id, FirmID.ToString()));
            }

            public static string DetailSearch()
            {
                return GetURLWithParams(PageName.Search, true);
            }

            public static string Advertisements(string mode, string value)
            {
                return GetURLWithParams(PageName.Advertisements, true,
                    new UrlParam(UrlKey.Mode,mode),
                    new UrlParam(UrlKey.Value, value));
            }

            public static string Advertisements(string fastMode,string keyword, string cityCountry,string position)
            {
                return GetURLWithParams(PageName.Advertisements, true,
                    new UrlParam(UrlKey.Mode, fastMode),
                    new UrlParam(UrlKey.Keyword, keyword),
                    new UrlParam(UrlKey.Position, position),
                    new UrlParam(UrlKey.CityCountry, cityCountry));
            }

            public static string Advertisements()
            {
                return GetURLWithParams(PageName.Advertisements, true);
            }

            public static string Users()
            {
                return GetURLWithParams(PageName.Users, true);
            }


            public static string Users(string fastMode, string department, string age, string educationState,
                string interestedWorkType)
            {
                return GetURLWithParams(PageName.Users, true,
                    new UrlParam(UrlKey.Mode, fastMode),
                    new UrlParam(UrlKey.Department, department),
                    new UrlParam(UrlKey.Age, age),
                    new UrlParam(UrlKey.EducationState, educationState),
                    new UrlParam(UrlKey.InterestedWorkType, interestedWorkType));
            }

            public static string FirmAdvertisements()
            {
                return GetURLWithParams(PageName.FirmAdvertisements, true);
            }
            
            public static string Departments(int DepartmentId)
            {
                return GetURLWithParams(PageName.Departments, true, new UrlParam(UrlKey.Id, DepartmentId.ToString()));
            }

            public static string FirmLogin()
            {
                return GetURLWithParams(PageName.FirmLogin, true);
            }

            public static string Student()
            {
                return GetURLWithParams(PageName.Student, true);
            }
        
            public static string Firm()
            {
                return GetURLWithParams(PageName.Firm, true);
            }

            public static string UserApplications()
            {
                return GetURLWithParams(PageName.UserApplications, true);
            }

            public static string UserMessages()
            {
                return GetURLWithParams(PageName.UserApplications, true, new UrlParam(UrlKey.Value, "Messages"));
            }

            public static string UserFrontPosts()
            {
                return GetURLWithParams(PageName.UserFrontPosts, true);
            }           

            public static string Cv(int CvId, string Name, string Surname)
            {
                return GetURLWithParams(PageName.Cv, true, new UrlParam(UrlKey.Id, CvId.ToString()));
            }

            public static string Cv(int CvId, string Name, string Surname, int applicationId)
            {
                return GetURLWithParams(PageName.Cv, true, 
                    new UrlParam(UrlKey.Id, CvId.ToString()), 
                    new UrlParam(UrlKey.AdvertisementApplicationId, applicationId.ToString()
                        ));
            }

            public static string SendCv(int CvId, string Name, string Surname) {
                return string.Concat(GSUKariyer.COMMON.Util.ApplicationRootPath(), GetURLWithParams(PageName.Cv, false, new UrlParam(UrlKey.Id, CvId.ToString())));
            }
            
            public static string CvAdd()
            {
                return GetURLWithParams(PageName.CvForm, true);
            }

            public static string CvEdit(int cvId)
            {
                return GetURLWithParams(PageName.CvForm, true, new UrlParam(UrlKey.Id, cvId.ToString()));
            }

            public static string AdvertisementForm()
            {
                return GetURLWithParams(PageName.AdvertisementForm, true);
            }

            public static string UserSearch()
            {
                return GetURLWithParams(PageName.UserSearch, true);
            }            

            public static string AdvertisementForm(int AdvertisementId)
            {
                return GetURLWithParams(PageName.AdvertisementForm, true, new UrlParam(UrlKey.Id, AdvertisementId.ToString()));
            }

            public static string FirmApplications()
            {
                return GetURLWithParams(PageName.FirmApplications, true);
            }

            public static string AllFirms() {
                return GetURLWithParams(PageName.AllFirms, true);
            }

            public static string FirmApplications(int AdvertisementId)
            {
                return GetURLWithParams(PageName.FirmApplications, true, new UrlParam(UrlKey.Id, AdvertisementId.ToString()));
            }
        }

        public class ImgUrl
        {
            #region Enums
            public enum ImgSizes
            {
                Default,
                Thumb,
                Square,
                Original
            }

            public enum ImgFirmLogoSizes { 
                DefaultW = 246,
                DefaultH = 120,
                ThumbW = 126,
                ThumbH = 60
            }

            public enum ImgUserPhotoSizes
            {
                DefaultW = 150,
                Thumb = 80,
                Square = 50
            }

            public enum ImgCareerPlaningSizes
            {
                DefaultW = 217,
                ThumbW = 57,
                ThumbH = 61
            }

            #endregion

            public const string ImgNameKey = "gsu_";

            public static string ImgUrlCompany(int CompanyID, ImgSizes ImgSize)
            { 
                return ImgUrlCompany( CompanyID, ImgSize,true);
            }
            public static string ImgUrlCompany(int CompanyID, ImgSizes ImgSize, bool checkFileExist)
            {
                string Folder = ConfigurationHelper.GetAppSetting(ConfigurationHelper.AppSettingKeys.ImgPathCompany);
                string ImgPath = GetImgUrl(Folder, ImgSize, ImgNameKey + CompanyID + ".jpg");

                if (checkFileExist)
                {
                    if (File.Exists(HttpContext.Current.Request.MapPath(ImgPath)))
                        return ImgPath;
                    else
                        return "";
                }

                return ImgPath;
            }

            public static string ImgUrlUser(int UserId, ImgSizes ImgSize)
            {
                return ImgUrlUser(UserId, ImgSize,true);
            }
            public static string ImgUrlUser(int UserId, ImgSizes ImgSize,bool checkFileExist)
            {
                string Folder = ConfigurationHelper.GetAppSetting(ConfigurationHelper.AppSettingKeys.ImgPathUsers);
                string ImgPath = GetImgUrl(Folder, ImgSize, ImgNameKey + UserId + ".jpg");

                if (checkFileExist)
                {
                    if (File.Exists(HttpContext.Current.Request.MapPath(ImgPath)))
                        return ImgPath;
                    else
                        return "";
                }

                return ImgPath;
            }

            public static string ImgUrlContent(int SiteContentID, ContentTypes ContentType, ImgSizes ImgSize)
            { 
                return ImgUrlContent(SiteContentID, ContentType, ImgSize,true);
            }
            public static string ImgUrlContent(int SiteContentID, ContentTypes ContentType, ImgSizes ImgSize, bool checkFileExist)
            {
                string Folder = "";
                if (ContentType != ContentTypes.Duyurular) 
                    Folder += ConfigurationHelper.GetAppSetting(ConfigurationHelper.AppSettingKeys.ImgPathRootCarrerPlaning);
                Folder += ContentType.ToString() + "/";
                string ImgPath = GetImgUrl(Folder, ImgSize, ImgNameKey + SiteContentID + ".jpg");

                if (checkFileExist)
                {
                    if (File.Exists(HttpContext.Current.Request.MapPath(ImgPath)))
                        return ImgPath;
                    else
                        return "";
                }

                return ImgPath;
            }

            public static string GetImgUrl(string Folder, ImgSizes ImgSize, string ImgName)
            {
                string Root = ConfigurationHelper.GetAppSetting(ConfigurationHelper.AppSettingKeys.ImgPathRoot);
                return String.Concat("~/", Root, Folder, ImgSize.ToString(), "/", ImgName);
            }

            public static bool CheckImgExist(string imgUrl)
            {
                if (File.Exists(String.Concat(
                    ConfigurationHelper.GetAppSetting(ConfigurationHelper.AppSettingKeys.WebPath),
                    imgUrl.Replace("~/", String.Empty).Replace("/", @"\"))))
                    return true;

                return false;
            }
            public static string ArrangeImgUrlFromAdmin(string url)
            {
                return String.Concat(ConfigurationHelper.GetAppSetting("ApplicationUrl"),
                    url.Replace("~/",String.Empty));
            }
        }
    }
}