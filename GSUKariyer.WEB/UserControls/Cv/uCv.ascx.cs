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

namespace GSUKariyer.WEB.UserControls.Cv
{
    public partial class uCv : BaseUserControl
    {
        #region Constant Values
        protected struct ExperienceControlId
        {
            public const string ltrDataExperinceDate = "ltrDataExperinceDate";
            public const string ltrDataFirmName = "ltrDataFirmName";
            public const string ltrDataPosition = "ltrDataPosition";
            public const string ltrDataFirmCity = "ltrDataFirmCity";
            public const string ltrDataDesc = "ltrDataDesc";
            public const string ltrFirmSector = "ltrFirmSector";
            public const string ltrDataFirmSector = "ltrDataFirmSector";
            public const string ltrFirmWorkerCount = "ltrFirmWorkerCount";
            public const string ltrDataFirmWorkerCount = "ltrDataFirmWorkerCount";
            public const string ltrWorkType = "ltrWorkType";
            public const string ltrDataWorkType = "ltrDataWorkType";
            public const string ltrPersonelCount = "ltrPersonelCount";
            public const string ltrDataPersonelCount = "ltrDataPersonelCount";
            public const string ltrRelatedPerson = "ltrRelatedPerson";
            public const string ltrDataRelatedPerson = "ltrDataRelatedPerson";
        }
        protected struct LanguageControlId
        {
            public const string ltrDataLanguage = "ltrDataLanguage";
            public const string ltrDataLanguageDetail = "ltrDataLanguageDetail";
            public const string ltrDataLearnPlace = "ltrDataLearnPlace";
        }
        protected struct CourseConrolId
        {
            public const string ltrDataCourseName = "ltrDataCourseName";
            public const string ltrDataCourseDesc = "ltrDataCourseDesc";
        }
        protected struct CertificateConrolId
        {
            public const string ltrDataName = "ltrDataName";
            public const string ltrDataDesc = "ltrDataDesc";
            public const string ltrDataNote = "ltrDataNote";

        }
        protected struct ReferanceConrolId
        {
            public const string ltrDataName = "ltrDataName";
            public const string ltrDataDesc = "ltrDataDesc";
        }
        #endregion

        #region Properties
        protected int? CVId
        {
            get { return GetUrlParam<int>(UrlHelper.PageUrl.UrlKey.Id); }
        }
        protected int? AdvertisementApplicationId
        {
            get { return GetUrlParam<int>(UrlHelper.PageUrl.UrlKey.AdvertisementApplicationId); }
        }
        #endregion

        string language;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!CVId.HasValue) Response.Redirect(UrlHelper.PageUrl.Default());
                    BindForm();


                Print();
            }
        }

        #region ArrangeForm & BindForm
        protected void ArrangeForm()
        {
            ltrMaritalStatus.Text = CVs.Viewer.MaritalStatus.GetTitle(language);
            ltrAddress.Text = CVs.Viewer.Address.GetTitle(language);
            ltrBirthPlace.Text = CVs.Viewer.BirthPlace.GetTitle(language);
            ltrDateOfBirth.Text = CVs.Viewer.DateOfBirth.GetTitle(language);
            ltrDrivingLicense.Text = CVs.Viewer.DrivingLicense.GetTitle(language);
            ltrEducationInfo.Text=CVs.Viewer.EducationInfo.GetTitle(language);
            ltrEducationState.Text = CVs.Viewer.EducationState.GetTitle(language);
            ltrExperience.Text = CVs.Viewer.Experiences.GetTitle(language);
            ltrHomePhone.Text = CVs.Viewer.HomePhone.GetTitle(language);
            ltrMobileNo.Text = CVs.Viewer.MobileNo.GetTitle(language);
            ltrNationality.Text = CVs.Viewer.Nationality.GetTitle(language);
            ltrPersonalInfo.Text = CVs.Viewer.PersonalInfo.GetTitle(language);
            ltrStudentNumber.Text = CVs.Viewer.StudentNumber.GetTitle(language);
            ltrWorkStatus.Text = CVs.Viewer.WorkStatus.GetTitle(language);
            ltrMasterInfo.Text = CVs.Viewer.MasterInfo.GetTitle(language);
            ltrHighSchoolInfo.Text = CVs.Viewer.HighSchoolInfo.GetTitle(language);
            ltrLicenseInfo.Text = CVs.Viewer.LicenseInfo.GetTitle(language);
            ltrExperienceInfo.Text = CVs.Viewer.ExperienceInfo.GetTitle(language);
            ltrLanguage.Text = CVs.Viewer.LanguageInfo.GetTitle(language);
            ltrComputerInfo.Text = CVs.Viewer.ComputerInfo.GetTitle(language);
            ltrCourseInfo.Text = CVs.Viewer.CourseInfo.GetTitle(language);
            ltrCertificateInfo.Text = CVs.Viewer.CertificateInfo.GetTitle(language);
            ltrReferances.Text = CVs.Viewer.Referances.GetTitle(language);
            ltrCigaretteUsage.Text = CVs.Viewer.CigaretteUsage.GetTitle(language);
            ltrClubs.Text = CVs.Viewer.GSClubs.GetTitle(language);

            if (IsPostBack)
            {
                if ((HttpContext.Current.Request.UrlReferrer != null) && (HttpContext.Current.Request.UrlReferrer.ToString().IndexOf("Firm") == -1 || !SessionManager.IsFirmLoggedIn))
                    pnlSendMessage.Visible = false;
                else
                    pnlSendMessage.Visible = true;
            }

        }
        protected void BindForm()
        {
            DataSet dsCv = CVs.GetAllData(CVId.Value);
            DataTable dtCvs = dsCv.Tables[0];
            DataTable dtCertificates = dsCv.Tables[1];
            DataTable dtCourseInfo = dsCv.Tables[2];
            DataTable dtExamInfo = dsCv.Tables[3];
            DataTable dtInterestedPositions = dsCv.Tables[4];
            DataTable dtLanguageInfo = dsCv.Tables[5];
            DataTable dtReferances = dsCv.Tables[6];
            DataTable dtUserClubs = dsCv.Tables[7];
            DataTable dtExperience = dsCv.Tables[8];
            DataTable dtWorkPlaces = dsCv.Tables[9];

            if (dtCvs.Rows.Count > 0)
            {
                DataRow dr = dtCvs.Rows[0];

                language = CVs.Languages.Options.ArrangeCvLanguageDBValue( 
                    dr[CVs.ColumnNames.CvLanguage].ToString());
                ArrangeForm();

                #region General & ... Info
                imgUser.ImageUrl = UrlHelper.ImgUrl.ImgUrlUser(Convert.ToInt32(dr[CVs.ColumnNames.UserId]), GSUKariyer.COMMON.UrlHelper.ImgUrl.ImgSizes.Default);

                ltrDataCvName.Text = dr[CVs.ColumnNames.Name].ToString().ToLower();
                ltrDataName.Text = String.Concat(dr[CVs.CustomColumnNames.UserName].ToString(), " ",
                    dr[CVs.CustomColumnNames.Surname].ToString());
                hlDataMail.Text = dr[CVs.ColumnNames.Email].ToString();
                hlDataMail.NavigateUrl = String.Concat("mailto:", dr[CVs.ColumnNames.Email].ToString());
                ltrDataAddress.Text = dr[CVs.CustomColumnNames.Address].ToString();

                ltrDataBirthPlace.Text = CVs.Viewer.BirthPlace.GetDescription(
                    dr[CVs.ColumnNames.BirthPlaceCountry].ToNullableInt(),
                    dr[CVs.ColumnNames.BirthPlaceCity].ToNullableInt(),
                    dr[CVs.ColumnNames.BirthPlaceCityFree].ToString());

                ltrDataDateOfBirth.Text = dr[CVs.CustomColumnNames.Birthdate].ToDateTime().ToShortDateString();

                ltrDataDrivingLicense.Text = CVs.Viewer.DrivingLicense.GetDescription( 
                    dr[CVs.ColumnNames.HasDrivingLicense].ToBool(false));
                ltrDataEducationState.Text=CVs.Viewer.EducationState.GetDescription(
                    language,dr[CVs.ColumnNames.EducationState].ToNullableInt());
                ltrDataExperience.Text = CVs.Viewer.Experiences.GetDescription(
                    dr[CVs.ColumnNames.TotalWorkExperienceInMonth].ToNullableInt());
                ltrDataHomePhone.Text = CVs.Viewer.HomePhone.GetDescription(
                    dr[CVs.ColumnNames.HomePhone].ToString());
                ltrDataMaritalStatus.Text = CVs.Viewer.MaritalStatus.GetDescription(
                    language,dr[CVs.ColumnNames.MaritalStatus].ToNullableInt());
                ltrDataMobileNo.Text = CVs.Viewer.MobileNo.GetDescription(
                    dr[CVs.ColumnNames.MobilePhone1].ToString(),
                    dr[CVs.ColumnNames.MobilePhone2].ToString());
                ltrDataNationality.Text=CVs.Viewer.Nationality.GetDescription(
                    dr[CVs.ColumnNames.Nationality].ToNullableInt());
                ltrDataStudentNumber.Text=CVs.Viewer.StudentNumber.GetDescription(
                    dr[CVs.CustomColumnNames.StudentNumber].ToString());

                ltrDataWorkStatus.Text = CVs.Viewer.WorkStatus.GetDescription(
                    dr[CVs.ColumnNames.WorkingStatus].ToNullableInt());
                #endregion

                #region EducationInfo
                if (CVs.Viewer.MasterInfo.ArrangeVisibility(
                    dr[CVs.ColumnNames.MasterUniversity].ToNullableInt()))
                {
                    trMaster.Visible = true;
                    ltrDataMasterDates.Text = CVs.Viewer.MasterInfo.ArrangeDates(
                        dr[CVs.ColumnNames.MasterStartDate].ToDateTime(),
                        dr[CVs.ColumnNames.MasterEndDate].ToNullableDateTime());
                    ltrDataMasterDesc.Text = CVs.Viewer.MasterInfo.ArrageDesc(
                        language,
                        dr[CVs.ColumnNames.MasterInstitute].ToNullableInt(),
                        dr[CVs.ColumnNames.MasterDepartment].ToNullableInt(),
                        dr[CVs.ColumnNames.MasterDepartmentFree].ToString());
                    ltrDataMasterScore.Text = CVs.Viewer.MasterInfo.ArrangeScore(
                        dr[CVs.ColumnNames.MasterGraduationGrade].ToNullableDecimal(),
                        dr[CVs.ColumnNames.MasterGradeSystem].ToNullableInt());
                    ltrDataMasterUniversity.Text = CVs.Viewer.MasterInfo.ArrangeUniversity(
                        dr[CVs.ColumnNames.MasterUniversity].ToNullableInt(),
                        dr[CVs.ColumnNames.MasterUniversityFree].ToString());
                }
                else
                    trMaster.Visible = false;

                ltrDataLicenseDates.Text = CVs.Viewer.LicenseInfo.ArrangeDates(
                    dr[CVs.ColumnNames.LicenseStartDate].ToDateTime(),
                    dr[CVs.ColumnNames.LicenseEndDate].ToNullableDateTime());
                ltrDataLicenseDesc.Text = CVs.Viewer.LicenseInfo.ArrageDesc(
                    language,
                    dr[CVs.ColumnNames.LicenseInstitute].ToInt(),
                    dr[CVs.ColumnNames.LicenseDepartment].ToNullableInt(),
                    dr[CVs.ColumnNames.LicenseDepartmentFree].ToString()); ;
                ltrDataLicenseScore.Text = CVs.Viewer.LicenseInfo.ArrangeScore(
                    dr[CVs.ColumnNames.LicenseGraduationGrade].ToNullableDecimal(),
                    dr[CVs.ColumnNames.LicenseGradeSystem].ToNullableInt());
                ltrDataLicenseUniversity.Text = CVs.Viewer.LicenseInfo.ArrangeUniversity(
                    dr[CVs.ColumnNames.LicenseUniversity].ToInt(),
                    dr[CVs.ColumnNames.LicenseUniversityFree].ToString());

                ltrDataHighSchool.Text = CVs.Viewer.HighSchoolInfo.ArrangeHighSchool(
                    dr[CVs.ColumnNames.HighSchool].ToString());
                ltrDataHighSchoolDates.Text = CVs.Viewer.HighSchoolInfo.ArrangeDates(
                    dr[CVs.ColumnNames.HighSchoolEndDate].ToDateTime()); 
                ltrDataHighSchoolDesc.Text = "";
                ltrDataHighSchoolScore.Text = CVs.Viewer.HighSchoolInfo.ArrangeScore(
                    dr[CVs.ColumnNames.HighSchoolGraduationGrade].ToNullableDecimal(),
                    dr[CVs.ColumnNames.HighSchoolGradeSystem].ToNullableInt()); 
                #endregion

                #region ExperienceInfo
                rptWorkExperience.DataSource = dtExperience;
                rptWorkExperience.DataBind();
                #endregion

                #region LanguageInfo
                rptLanguages.DataSource = dtLanguageInfo;
                rptLanguages.DataBind(); 
                #endregion

                #region ComputerInfo
                ltrDataComputerInfo.Text =CVs.Viewer.ComputerInfo.GetDescription(
                    dr[CVs.ColumnNames.ComputerInfo].ToString());
                #endregion

                #region CourseInfo
                rptCourseInfo.DataSource = dtCourseInfo;
                rptCourseInfo.DataBind();
                #endregion

                #region CertificateInfo
                rptCertificateInfo.DataSource = dtCertificates;
                rptCertificateInfo.DataBind();
                #endregion

                #region Referances
                rptReferances.DataSource = dtReferances;
                rptReferances.DataBind();
                #endregion

                #region Others
                ltrDataCigaretteUsage.Text = CVs.Viewer.CigaretteUsage.GetDetail(language,
                    dr[CVs.ColumnNames.CigaretteUseType].ToNullableInt());

                ltrDataClubs.Text = CVs.Viewer.GSClubs.GetDetail(language,dtUserClubs);
                #endregion

            }
        }
        #endregion

        #region Repeater Events
        protected void rptWorkExperience_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item ||
                e.Item.ItemType == ListItemType.AlternatingItem)
            {
                DataRowView dr = (DataRowView)e.Item.DataItem;

                RepeaterHelper.GetControl<Literal>(e.Item,ExperienceControlId.ltrFirmSector).Text=
                    CVs.Viewer.ExperienceInfo.FirmSector.GetTitle(language);
                RepeaterHelper.GetControl<Literal>(e.Item,ExperienceControlId.ltrFirmWorkerCount).Text =
                    CVs.Viewer.ExperienceInfo.FirmWorkerCount.GetTitle(language);
                RepeaterHelper.GetControl<Literal>(e.Item, ExperienceControlId.ltrPersonelCount).Text =
                    CVs.Viewer.ExperienceInfo.PersonelCount.GetTitle(language);
                RepeaterHelper.GetControl<Literal>(e.Item, ExperienceControlId.ltrRelatedPerson).Text =
                    CVs.Viewer.ExperienceInfo.RelatedPerson.GetTitle(language);
                RepeaterHelper.GetControl<Literal>(e.Item, ExperienceControlId.ltrWorkType).Text =
                    CVs.Viewer.ExperienceInfo.WorkType.GetTitle(language);

                RepeaterHelper.GetControl<Literal>(e.Item, ExperienceControlId.ltrDataDesc).Text =
                    CVs.Viewer.ExperienceInfo.GetDescription(
                    dr[CVs.WorkExperiences.ColumnNames.JobDescription].ToString());
                RepeaterHelper.GetControl<Literal>(e.Item, ExperienceControlId.ltrDataExperinceDate).Text =
                    CVs.Viewer.ExperienceInfo.ArrangeDates(
                    dr[CVs.WorkExperiences.ColumnNames.WorkStartDate].ToDateTime(),
                    dr[CVs.WorkExperiences.ColumnNames.WorkEndDate].ToNullableDateTime());
                RepeaterHelper.GetControl<Literal>(e.Item, ExperienceControlId.ltrDataFirmCity).Text =
                    CVs.Viewer.ExperienceInfo.ArrangeWorkCityCountry(
                    dr[CVs.WorkExperiences.ColumnNames.WorkCity].ToString());
                RepeaterHelper.GetControl<Literal>(e.Item, ExperienceControlId.ltrDataFirmName).Text =
                    CVs.Viewer.ExperienceInfo.ArrangeFirmName(
                    dr[CVs.WorkExperiences.ColumnNames.FirmName].ToString());
                RepeaterHelper.GetControl<Literal>(e.Item,ExperienceControlId.ltrDataFirmSector).Text =
                    CVs.Viewer.ExperienceInfo.FirmSector.GetDescription(
                    dr[CVs.WorkExperiences.ColumnNames.FirmSector].ToString());
                RepeaterHelper.GetControl<Literal>(e.Item, ExperienceControlId.ltrDataFirmWorkerCount).Text =
                    CVs.Viewer.ExperienceInfo.FirmWorkerCount.GetDescription(
                    dr[CVs.WorkExperiences.ColumnNames.FirmWorkerCount].ToNullableInt());
                RepeaterHelper.GetControl<Literal>(e.Item, ExperienceControlId.ltrDataPersonelCount).Text =
                    CVs.Viewer.ExperienceInfo.PersonelCount.GetDescription(
                    dr[CVs.WorkExperiences.ColumnNames.NumberOfPeopleOnResponsibility].ToNullableInt());
                RepeaterHelper.GetControl<Literal>(e.Item, ExperienceControlId.ltrDataPosition).Text =
                    CVs.Viewer.ExperienceInfo.ArrangePosition(
                    dr[CVs.WorkExperiences.ColumnNames.WorkingPosition].ToString());
                RepeaterHelper.GetControl<Literal>(e.Item, ExperienceControlId.ltrDataRelatedPerson).Text =
                    CVs.Viewer.ExperienceInfo.RelatedPerson.GetDescription(
                    dr[CVs.WorkExperiences.ColumnNames.ResponsibleName].ToString(),
                    dr[CVs.WorkExperiences.ColumnNames.ResponsiblePhone].ToString());
                RepeaterHelper.GetControl<Literal>(e.Item, ExperienceControlId.ltrDataWorkType).Text =
                    CVs.Viewer.ExperienceInfo.WorkType.GetDescription(
                    dr[CVs.WorkExperiences.ColumnNames.WorkingType].ToNullableInt());                

            }
        }
        protected void rptLanguages_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item ||
                e.Item.ItemType == ListItemType.AlternatingItem)
            {
                DataRowView dr = (DataRowView)e.Item.DataItem;

                RepeaterHelper.GetControl<Literal>(e.Item, LanguageControlId.ltrDataLanguage).Text =
                    CVs.Viewer.LanguageInfo.GetDescription(
                    dr[CVs.LanguageInfo.ColumnNames.LanguageId].ToNullableInt());
                RepeaterHelper.GetControl<Literal>(e.Item, LanguageControlId.ltrDataLanguageDetail).Text =
                    CVs.Viewer.LanguageInfo.GetDetail(language,
                    dr[CVs.LanguageInfo.ColumnNames.ReadGrade].ToInt(),
                    dr[CVs.LanguageInfo.ColumnNames.WriteGrade].ToInt(),
                    dr[CVs.LanguageInfo.ColumnNames.TalkGrade].ToInt());
                RepeaterHelper.GetControl<Literal>(e.Item, LanguageControlId.ltrDataLearnPlace).Text =
                    CVs.Viewer.LanguageInfo.GetHowLearned(
                    dr[CVs.LanguageInfo.ColumnNames.HowLearned].ToString());

            }
        }
        protected void rptCourseInfo_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item ||
                e.Item.ItemType == ListItemType.AlternatingItem)
            {
                DataRowView dr = (DataRowView)e.Item.DataItem;

                RepeaterHelper.GetControl<Literal>(e.Item, CourseConrolId.ltrDataCourseName).Text =
                    CVs.Viewer.CourseInfo.GetDescription(
                    dr[CVs.CourseInfo.ColumnNames.Name].ToString());
                RepeaterHelper.GetControl<Literal>(e.Item, CourseConrolId.ltrDataCourseDesc).Text =
                    CVs.Viewer.CourseInfo.GetDetail(language,
                    dr[CVs.CourseInfo.ColumnNames.Institution].ToString(),
                    dr[CVs.CourseInfo.ColumnNames.StartDate].ToNullableDateTime(),
                    dr[CVs.CourseInfo.ColumnNames.EndDate].ToNullableDateTime(),
                    dr[CVs.CourseInfo.ColumnNames.DurationInHours].ToNullableInt());
            }
        }
        protected void rptCertificateInfo_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item ||
                e.Item.ItemType == ListItemType.AlternatingItem)
            {
                DataRowView dr = (DataRowView)e.Item.DataItem;

                RepeaterHelper.GetControl<Literal>(e.Item, CertificateConrolId.ltrDataName).Text =
                    CVs.Viewer.CertificateInfo.GetDescription(
                    dr[CVs.CertificateInfo.ColumnNames.Name].ToString());
                RepeaterHelper.GetControl<Literal>(e.Item, CertificateConrolId.ltrDataDesc).Text =
                    CVs.Viewer.CertificateInfo.GetDetail(
                    dr[CVs.CertificateInfo.ColumnNames.TakenInstitution].ToString(),
                    dr[CVs.CertificateInfo.ColumnNames.CertificateDate].ToNullableDateTime());

                RepeaterHelper.GetControl<Literal>(e.Item, CertificateConrolId.ltrDataNote).Text =
                    dr[CVs.CertificateInfo.ColumnNames.Description].ToString();
            }
        }
        protected void rptReferances_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item ||
                e.Item.ItemType == ListItemType.AlternatingItem)
            {
                DataRowView dr = (DataRowView)e.Item.DataItem;

                RepeaterHelper.GetControl<Literal>(e.Item, ReferanceConrolId.ltrDataName).Text =
                    CVs.Viewer.Referances.GetDescription(
                    dr[CVs.Referances.ColumnNames.Name].ToString(),
                    dr[CVs.Referances.ColumnNames.Surname].ToString());
                RepeaterHelper.GetControl<Literal>(e.Item, ReferanceConrolId.ltrDataDesc).Text =
                    CVs.Viewer.Referances.GetDetail(
                    language,
                    dr[CVs.Referances.ColumnNames.WorkingFirm].ToString(),
                    dr[CVs.Referances.ColumnNames.WorkingPosition].ToString(),
                    dr[CVs.Referances.ColumnNames.Email].ToString(),
                    dr[CVs.Referances.ColumnNames.Phone].ToString());

            }
        } 
        #endregion

        protected void btnImgSendMessage_Click(object sender, ImageClickEventArgs e)
        {
            if (AdvertisementApplicationId.HasValue)
                AdvertisementApplications.Update(AdvertisementApplicationId.Value,
                    txtMessage.Text.Trim(),(int)AdvertisementApplications.State.Answered,
                    DateTime.Now);
        }

        void Print()
        {            
            if (Request.QueryString["IsPrint"] != null)
            {
                /*
                //Print Css i import et
                HtmlLink hm = new HtmlLink();
                hm.Attributes.Add("rel", "stylesheet");
                hm.Attributes.Add("type", "text/css");
                hm.Attributes.Add("media", "print");
                hm.Href = "Styles/Print.css";
                Page.Header.Controls.Add(hm);
                */

                //Print js yi import et
                HtmlGenericControl js = new HtmlGenericControl("script");
                js.Attributes["type"] = "text/javascript";
                js.Attributes["src"] = "Scripts/Print.js";
                Page.Header.Controls.Add(js);
            }
            else
                hlPrint.NavigateUrl = Request.Url + "&IsPrint=1";
        }
    }
}
