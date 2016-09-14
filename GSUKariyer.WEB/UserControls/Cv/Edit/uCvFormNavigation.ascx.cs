using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GSUKariyer.COMMON.Helpers.WEB;
using GSUKariyer.BUS;
using GSUKariyer.COMMON;

namespace GSUKariyer.WEB.UserControls.Cv.Edit
{
    public partial class uCvFormNavigation : BaseUserControl
    {
        #region ConstValues
        protected struct ViewStateKeys
        {
            public const string MaxControlOrder = "MCI";
        }
        protected struct ControlId
        {
            public const string lbtnWelcome = "lbtnWelcome";

            public const string lbtnPersonalInfo = "lbtnPersonalInfo";
            public const string lbtnContactInfo = "lbtnContactInfo";
            public const string lbtnCityCountryInfo = "lbtnCityCountryInfo";
            public const string lbtnCigaretteUsage = "lbtnCigaretteUsage";
            public const string lbtnSocialClubs = "lbtnSocialClubs";

            public const string lbtnEducationState = "lbtnEducationState";
            public const string lbtnMasterInfo = "lbtnMasterInfo";
            public const string lbtnUniversityInfo = "lbtnUniversityInfo";
            public const string lbtnHighSchoolInfo = "lbtnHighSchoolInfo";
            public const string lbtnLanguageInfo = "lbtnLanguageInfo";
            public const string lbtnComputerInfo = "lbtnComputerInfo";
            public const string lbtnCertificateInfo = "lbtnCertificateInfo";
            public const string lbtnExamInfo = "lbtnExamInfo";
            public const string lbtnCourseInfo = "lbtnCourseInfo";
            public const string lbtnDrivingLicense = "lbtnDrivingLicense";

            public const string lbtnInterestedJobPositions = "lbtnInterestedJobPositions";
            public const string lbtnWorkExperiences = "lbtnWorkExperiences";
            public const string lbtnReferances = "lbtnReferances";

            public const string lbtnCvState = "lbtnCvState";
            public const string lbtnPhoto = "lbtnPhoto";            
        }
        #endregion

        protected static readonly object MenuItemClickEvent = new object();
        public delegate void MenuItemClick_EventHandler(object sender,int controlOrder);

        #region Properties
        public event MenuItemClick_EventHandler MenuItemClick
        {
            add { this.Events.AddHandler(MenuItemClickEvent,value); }
            remove { this.Events.RemoveHandler(MenuItemClickEvent, value); }
        }
        protected bool IsNewCV
        {
            get
            {
                return String.IsNullOrEmpty(GetUrlParam(UrlHelper.PageUrl.UrlKey.Id));
            }
        }
        protected int? CVId
        {
            get
            {
                return GetUrlParam(UrlHelper.PageUrl.UrlKey.Id).ToNullableInt();
            }
        }
        protected int MaxControlOrder
        {
            get { return (ViewState[ViewStateKeys.MaxControlOrder] == null ? -1 : (int)ViewState[ViewStateKeys.MaxControlOrder]); }
            set { ViewState.Add(ViewStateKeys.MaxControlOrder, value); }
        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                ArrangeForm();
        }

        #region ArrangeForm
        protected void ArrangeForm()
        {
            accCV.SelectedIndex = -1;
            ArrangeControlsEnable(CVs.Forms.ControlOrders.WelcomeForm);
            hlCvDetail.Visible = ! IsNewCV;
            if (CVId.HasValue)
                hlCvDetail.NavigateUrl = UrlHelper.PageUrl.Cv(CVId.Value, SessionManager.Name,
                    SessionManager.Surname);

        }
        #endregion

        #region Public Functions
        public void OpenMenu(int controlOrder)
        {
            CVs.Forms.MenuGroup menuGroup = CVs.Forms.FindMenuGroup(controlOrder);
            accCV.SelectedIndex = (int)menuGroup;
            ArrangeControlsEnable(controlOrder);
        }
        public void SetValidationGroup(string validationGroup)
        {
            (accCV_Welcome.FindControl(ControlId.lbtnWelcome) as LinkButton).ValidationGroup = validationGroup;
            (accCV_PersonalInfo.FindControl(ControlId.lbtnPersonalInfo) as LinkButton).ValidationGroup = validationGroup;
            (accCV_PersonalInfo.FindControl(ControlId.lbtnContactInfo) as LinkButton).ValidationGroup = validationGroup;
            (accCV_PersonalInfo.FindControl(ControlId.lbtnCityCountryInfo) as LinkButton).ValidationGroup = validationGroup;
            (accCV_PersonalInfo.FindControl(ControlId.lbtnCigaretteUsage) as LinkButton).ValidationGroup = validationGroup;
            (accCV_PersonalInfo.FindControl(ControlId.lbtnSocialClubs) as LinkButton).ValidationGroup = validationGroup;

            (accCV_EducationInfo.FindControl(ControlId.lbtnEducationState) as LinkButton).ValidationGroup = validationGroup;                                       
             
            (accCV_EducationInfo.FindControl(ControlId.lbtnUniversityInfo ) as LinkButton).ValidationGroup = validationGroup;                                        
            (accCV_EducationInfo.FindControl(ControlId.lbtnLanguageInfo ) as LinkButton).ValidationGroup = validationGroup;                                        
            (accCV_EducationInfo.FindControl(ControlId.lbtnCertificateInfo) as LinkButton).ValidationGroup = validationGroup;                                       
            (accCV_EducationInfo.FindControl(ControlId.lbtnCourseInfo) as LinkButton).ValidationGroup = validationGroup;                                        
            (accCV_EducationInfo.FindControl(ControlId.lbtnMasterInfo) as LinkButton).ValidationGroup = validationGroup;
            (accCV_EducationInfo.FindControl(ControlId.lbtnDrivingLicense) as LinkButton).ValidationGroup = validationGroup;
            (accCV_EducationInfo.FindControl(ControlId.lbtnExamInfo) as LinkButton).ValidationGroup = validationGroup;
            (accCV_EducationInfo.FindControl(ControlId.lbtnComputerInfo) as LinkButton).ValidationGroup = validationGroup;
            (accCV_EducationInfo.FindControl(ControlId.lbtnHighSchoolInfo) as LinkButton).ValidationGroup = validationGroup;
            (accCV_WorkExperienceInfo.FindControl(ControlId.lbtnInterestedJobPositions) as LinkButton).ValidationGroup = validationGroup;
            (accCV_WorkExperienceInfo.FindControl(ControlId.lbtnWorkExperiences) as LinkButton).ValidationGroup = validationGroup;
            (accCV_WorkExperienceInfo.FindControl(ControlId.lbtnReferances) as LinkButton).ValidationGroup = validationGroup;

            (accCV_State.FindControl(ControlId.lbtnCvState) as LinkButton).ValidationGroup = validationGroup;
            (accCV_Photo.FindControl(ControlId.lbtnPhoto) as LinkButton).ValidationGroup = validationGroup;
        }
        protected void ArrangeControlsEnable(int controlOrder)
        {
            if (IsNewCV)
            {
                if (MaxControlOrder < controlOrder)
                    MaxControlOrder = controlOrder;

                controlOrder = MaxControlOrder;

                (accCV_Welcome.FindControl(ControlId.lbtnWelcome) as LinkButton).Enabled = 
                    (controlOrder>= CVs.Forms.ControlOrders.WelcomeForm);
                (accCV_PersonalInfo.FindControl(ControlId.lbtnPersonalInfo) as LinkButton).Enabled =
                    (controlOrder >= CVs.Forms.ControlOrders.PersonalInfoForm);
                (accCV_PersonalInfo.FindControl(ControlId.lbtnContactInfo) as LinkButton).Enabled =
                    (controlOrder >= CVs.Forms.ControlOrders.ContactInfoForm); 
                (accCV_PersonalInfo.FindControl(ControlId.lbtnCityCountryInfo) as LinkButton).Enabled=
                    (controlOrder >= CVs.Forms.ControlOrders.CityCountryInfoForm);
                (accCV_PersonalInfo.FindControl(ControlId.lbtnCigaretteUsage) as LinkButton).Enabled=
                    (controlOrder >= CVs.Forms.ControlOrders.CigaretteUsage);
                (accCV_PersonalInfo.FindControl(ControlId.lbtnSocialClubs) as LinkButton).Enabled =
                    (controlOrder >= CVs.Forms.ControlOrders.SocialClubs); ;

                (accCV_EducationInfo.FindControl(ControlId.lbtnEducationState) as LinkButton).Enabled=
                    (controlOrder >= CVs.Forms.ControlOrders.EducationState);
                (accCV_EducationInfo.FindControl(ControlId.lbtnUniversityInfo) as LinkButton).Enabled =
                    (controlOrder >= CVs.Forms.ControlOrders.UniversityInfo);
                (accCV_EducationInfo.FindControl(ControlId.lbtnLanguageInfo) as LinkButton).Enabled =
                    (controlOrder >= CVs.Forms.ControlOrders.LanguageInfo);
                (accCV_EducationInfo.FindControl(ControlId.lbtnCertificateInfo) as LinkButton).Enabled=
                    (controlOrder >= CVs.Forms.ControlOrders.CertificateInfo);
                (accCV_EducationInfo.FindControl(ControlId.lbtnCourseInfo) as LinkButton).Enabled =
                    (controlOrder >= CVs.Forms.ControlOrders.CourseInfo);
                (accCV_EducationInfo.FindControl(ControlId.lbtnMasterInfo) as LinkButton).Enabled =
                    (controlOrder >= CVs.Forms.ControlOrders.MasterInfo);
                (accCV_EducationInfo.FindControl(ControlId.lbtnDrivingLicense) as LinkButton).Enabled =
                    (controlOrder >= CVs.Forms.ControlOrders.DrivingLicense);
                (accCV_EducationInfo.FindControl(ControlId.lbtnExamInfo) as LinkButton).Enabled =
                    (controlOrder >= CVs.Forms.ControlOrders.ExamInfo);
                (accCV_EducationInfo.FindControl(ControlId.lbtnComputerInfo) as LinkButton).Enabled =
                    (controlOrder >= CVs.Forms.ControlOrders.ComputerInfo);
                (accCV_EducationInfo.FindControl(ControlId.lbtnHighSchoolInfo) as LinkButton).Enabled=
                    (controlOrder >= CVs.Forms.ControlOrders.HighSchoolInfo);
                (accCV_WorkExperienceInfo.FindControl(ControlId.lbtnInterestedJobPositions) as LinkButton).Enabled=
                    (controlOrder >= CVs.Forms.ControlOrders.InterestedJobPositions);
                (accCV_WorkExperienceInfo.FindControl(ControlId.lbtnWorkExperiences) as LinkButton).Enabled=
                    (controlOrder >= CVs.Forms.ControlOrders.WorkExperinces);
                (accCV_WorkExperienceInfo.FindControl(ControlId.lbtnReferances) as LinkButton).Enabled =
                    (controlOrder >= CVs.Forms.ControlOrders.Referances);

                (accCV_State.FindControl(ControlId.lbtnCvState) as LinkButton).Enabled =
                    (controlOrder >= CVs.Forms.ControlOrders.CVState);
                (accCV_Photo.FindControl(ControlId.lbtnPhoto) as LinkButton).Enabled = 
                    (controlOrder >= CVs.Forms.ControlOrders.Photo);           
            }
        }
        #endregion

        #region MenuItem_Click
        protected void MenuItem_Click(object sender, EventArgs e)
        {
            int controlOrder = ((LinkButton)sender).CommandArgument.ToInt();

            MenuItemClick_EventHandler eventHandler = (MenuItemClick_EventHandler)this.Events[MenuItemClickEvent];
            if (eventHandler != null)
                eventHandler(sender,controlOrder);

            ArrangeItems(controlOrder);
        }

        public void ArrangeItems(int controlOrder)
        {
            if (controlOrder == CVs.Forms.ControlOrders.WelcomeForm ||
                controlOrder == CVs.Forms.ControlOrders.CVState ||
                controlOrder == CVs.Forms.ControlOrders.Photo||
                controlOrder == CVs.Forms.ControlOrders.CVResult)
                accCV.SelectedIndex = -1;
        }
        #endregion

    }
}