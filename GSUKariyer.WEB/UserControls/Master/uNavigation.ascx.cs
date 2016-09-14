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
using AjaxControlToolkit;
using GSUKariyer.BUS;

namespace GSUKariyer.WEB.UserControls.Master
{
    public partial class uNavigation : BaseUserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Arrange();
            if (!IsPostBack)
            {
                BindLinks();                
            }
        }

        #region Arrange & BindForm
        protected void Arrange()
        {
            phFirmMenu.Visible = this.SessionManager.IsFirmLoggedIn;
            phDefaultMenu.Visible = !phFirmMenu.Visible;
        }
        protected void BindLinks()
        {
            //ÖĞRENCİ MENU GRUBU 1

            //ana sayfa
            Menu(accUser1_Main, "hlUser1_MainPage", false, UrlHelper.PageUrl.Default());


            //iş arıyorum
            Menu(accUser1_Search, "hlUser1_Advertisements_Today", true, UrlHelper.PageUrl.Advertisements(
                BUS.Advertisements.SearchHelper.AdvertisementsPage.Mode.Date,
                BUS.Advertisements.DateOption.Today.Value));  //**
            Menu(accUser1_Search, "hlUser1_Advertisements_ThisWeek", true, UrlHelper.PageUrl.Advertisements(
                BUS.Advertisements.SearchHelper.AdvertisementsPage.Mode.Date,
                BUS.Advertisements.DateOption.Last7Days.Value));
            Menu(accUser1_Search, "hlUser1_Advertisements_LastMonth", true, UrlHelper.PageUrl.Advertisements(
                BUS.Advertisements.SearchHelper.AdvertisementsPage.Mode.Date,
                BUS.Advertisements.DateOption.LastMonth.Value));
            Menu(accUser1_Search, "hlUser1_Advertisements_Internship", true, UrlHelper.PageUrl.Advertisements(
                BUS.Advertisements.SearchHelper.AdvertisementsPage.Mode.WorkType,
                String.Empty));  
            Menu(accUser1_Search, "hlUser1_Advertisements_DetailSearch", true, Go(PageName.Search));

            if (SessionManager.IsLoggedIn)
                Menu(accUser1_Search, "hlUser1_Advertisements_Related", true, UrlHelper.PageUrl.Advertisements(BUS.Advertisements.SearchHelper.AdvertisementsPage.Mode.MostSuitable,true.ToString()));
            else
                Menu(accUser1_Search, "hlUser1_Advertisements_Related", true, UrlHelper.PageUrl.Signup() );
            


            //cv yolla
            Repeater repeater= accUser1_SendCv.FindControl("rptFirms") as Repeater;
            repeater.DataSource =ArrangeValueLength(
                BUS.Advertisements.PopularCriterias.Firms.GetTop5(),
                "Desc",21);
            repeater.DataBind();
            Menu(accUser1_SendCv, "hlAllFirms", true, UrlHelper.PageUrl.AllFirms());

            //sektör listesi
            repeater = accUser1_Sectors.FindControl("rptSectors") as Repeater;
            repeater.DataSource = ArrangeValueLength(
                BUS.Advertisements.PopularCriterias.Sectors.GetTop5(),
                "Desc",21);
            repeater.DataBind(); 


            //şehirler / ülkeler
            repeater = accUser1_CityCountry.FindControl("rptCityCountry") as Repeater;
            repeater.DataSource = ArrangeValueLength(
                BUS.Advertisements.PopularCriterias.CityCountry.GetTop5(),
                "Desc",21);
            repeater.DataBind();

            //---------------------------------------------


            //ÖĞRENCİ MENU GRUBU 2

            //kariyerim
            Menu(accUser1_MyCareer, "hlUser2_UserCvList", true, UrlHelper.PageUrl.Student());
            Menu(accUser1_MyCareer, "hlUser2_Signup", true, UrlHelper.PageUrl.Signup());
            Menu(accUser1_MyCareer, "hlUser2_UserApplications", true, UrlHelper.PageUrl.UserApplications());
            Menu(accUser1_MyCareer, "hlUser2_UserMessages", true, UrlHelper.PageUrl.UserMessages());
            Menu(accUser1_MyCareer, "hlUser2_UserFronPosts", true, Go(PageName.UserFrontPosts));
                            

            //kariyer planlama
            Menu(accUser1_CareerPlaning, "hlUser2_Interview", true, UrlHelper.PageUrl.Contents(UrlHelper.ContentTypes.Roportajlar));            
            Menu(accUser1_CareerPlaning, "hlUser2_SuccessStories", true, UrlHelper.PageUrl.Contents(UrlHelper.ContentTypes.BasariHikayeleri));
            Menu(accUser1_CareerPlaning, "hlUser2_Articles", true, UrlHelper.PageUrl.Contents(UrlHelper.ContentTypes.Makaleler));


            //duyurular
            Menu(accUser1_Announcements, "hlUser2_Announcements", false, UrlHelper.PageUrl.Contents(UrlHelper.ContentTypes.Duyurular));



            //---------------------------------------------


            //FİRMA MENU GRUBU 1

            //ana sayfa
            Menu(accFirm1_Main, "hlFirm1_MainPage", false, UrlHelper.PageUrl.Default());


            //eleman ara

            repeater = accFirm1_Search.FindControl("rptFirmSearchUser") as Repeater;
            repeater.DataSource = ArrangeValueLength(
                SiteParams.GetAdvertisementTypes(),"Description",21);
            repeater.DataBind();

            Menu(accFirm1_Search, "hlFirm1_SearchDetail", true, Go(PageName.UserSearch));


            //bölümler
            repeater = accFirm1_Departments.FindControl("rptDepartments") as Repeater;
            repeater.DataSource = ArrangeValueLength(
                SiteParams.GetRandomTop5Deparments(), "Description", 21); 
            repeater.DataBind();
            //---------------------------------------------


            //FİRMA MENU GRUBU 2

            //ilanlarım            
            Menu(accFirm2_MyAdvertisements, "hlFirm2_FirmMainPage", true, UrlHelper.PageUrl.Firm());
            Menu(accFirm2_MyAdvertisements, "hlFirm2_AdvertisementForm", true, UrlHelper.PageUrl.AdvertisementForm());  //**
            Menu(accFirm2_MyAdvertisements, "hlFirm2_Advertisements", true, UrlHelper.PageUrl.FirmAdvertisements());  //**
            Menu(accFirm2_MyAdvertisements, "hlFirm2_FirmApplications", true, UrlHelper.PageUrl.FirmApplications());  //**


            //üyelik bilgilerim
            Menu(accFirm2_SignUp, "hlFirm2_SignUp", false, Go(PageName.FirmSignup));


            //kariyer planlama
            Menu(accFirm2_CareerPlaning, "hlFirm2_Interviews", true, UrlHelper.PageUrl.Contents(UrlHelper.ContentTypes.Roportajlar));            
            Menu(accFirm2_CareerPlaning, "hlFirm2_SuccessStories", true, UrlHelper.PageUrl.Contents(UrlHelper.ContentTypes.BasariHikayeleri));
            Menu(accFirm2_CareerPlaning, "hlFirm2_Articles", true, UrlHelper.PageUrl.Contents(UrlHelper.ContentTypes.Makaleler));


            //duyurular
            Menu(accFirm2_Announcements, "hlFirm2_Announcements", false, UrlHelper.PageUrl.Contents(UrlHelper.ContentTypes.Duyurular));
        }
        #endregion

        #region Others       
        protected string ArrangeSearchUrlByDepartment(string department)
        {
            return UrlHelper.PageUrl.Users(Users.SearchHelper.UsersPage.Mode.Fast,department, String.Empty,
                String.Empty, String.Empty);
        }
        protected string ArrangeSearchUrlByWorkingType(string workingType)
        {
            return UrlHelper.PageUrl.Users(Users.SearchHelper.UsersPage.Mode.Fast, String.Empty, String.Empty,
                String.Empty, workingType);
        }
        protected string ArrangeFirmUrl(string firmId,string firmName)
        {
            return UrlHelper.PageUrl.FirmDetail(firmId.ToInt(),firmName);
        }
        protected string ArrangeSectorUrl(string sectorId)
        {
            return UrlHelper.PageUrl.Advertisements(BUS.Advertisements.SearchHelper.AdvertisementsPage.Mode.Sectors,
                sectorId);
        }
        protected string ArrangeCityCountryUrl(string cityCountry)
        {
            return UrlHelper.PageUrl.Advertisements(BUS.Advertisements.SearchHelper.AdvertisementsPage.Mode.CityCountry,
                cityCountry);
        }

        
        protected HyperLink GetHyperLink(AccordionPane ac,string hlID,bool IsSubMenu)
        {
            AccordionContentPanel Cntrl;
            Cntrl = IsSubMenu ? ac.ContentContainer : ac.HeaderContainer;
            return (HyperLink)Cntrl.FindControl(hlID);
        }
        protected void Menu(AccordionPane ac, string hlID, bool IsSubMenu, string URL)
        {
            GetHyperLink(ac,hlID,IsSubMenu).NavigateUrl = URL;
        }
        #endregion

        protected DataTable ArrangeValueLength(DataTable dt,string columnName,int length)
        {
            foreach (DataRow dr in dt.Rows)
            {
                if (dr[columnName].ToString().Length > length)
                    dr[columnName] =String.Concat(dr[columnName].ToString().Substring(0,length-3),"...");
            }

            return dt;
        }

    }
}