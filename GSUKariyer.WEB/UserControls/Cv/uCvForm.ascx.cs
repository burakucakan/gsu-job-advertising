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
using System.Collections.Generic;
using GSUKariyer.BUS;
using GSUKariyer.COMMON;

namespace GSUKariyer.WEB.UserControls.Cv
{
    public partial class uCvForm : BaseCvEditUserControl
    {
        #region Properties
        public string Language
        {
            get { return ViewState[ViewStateKeys.CvLanguage].ToString(); }
            set { ViewState.Add(ViewStateKeys.CvLanguage, value); }
        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ArrangeForm();
                if (CVId.HasValue) BindForm();
            }
        }

        #region ArrangeForm / BindForm
        protected void ArrangeForm()
        {
            uCVResult1.Bind(!CVId.HasValue);
            ArrangeControlVisibility(uWelcome1.ControlOrder);//uWelcome1.ControlOrder);
        }
        protected void BindForm()
        {
            DataSet dsCv=CVs.GetAllData(CVId.Value);
            
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

            if (dtCvs.Rows.Count == 0)
                Response.Redirect(UrlHelper.PageUrl.Default());

            if ((int)dtCvs.Rows[0][CVs.ColumnNames.UserId]!=SessionManager.UserId.Value)
                Response.Redirect(UrlHelper.PageUrl.Default());

            uCigaretteUsage1.Bind(dtCvs);
            uCommunicationInfo1.Bind(dtCvs);
            uComputerInfo1.Bind(dtCvs);
            uCVState1.Bind(dtCvs);
            uDrivingLicense1.Bind(dtCvs);
            uHighSchoolInfo1.Bind(dtCvs);
            uMasterInfo1.Bind(dtCvs);
            uUniversityInfo1.Bind(dtCvs);
            uPersonalInfo1.Bind(dtCvs);
            uUniversityInfo1.Bind(dtCvs);
            uWelcome1.Bind(dtCvs);

            uCertificateInfo1.Bind(dtCertificates);
            uCityCountryInfo1.Bind(dtWorkPlaces);
            uCourseInfo1.Bind(dtCourseInfo);
            uExamInfo1.Bind(dtExamInfo);
            uExperienceInfo1.Bind(dtCvs.Rows[0][CVs.ColumnNames.WorkingStatus].ToNullableInt(),
                dtCvs.Rows[0][CVs.ColumnNames.TotalWorkExperienceInMonth].ToNullableInt(),dtExperience);
            uLanguagelInfo1.Bind(dtLanguageInfo);
            uPositions1.Bind(dtCvs.Rows[0][CVs.ColumnNames.InterestedAdvertisementType].ToInt(),
                dtInterestedPositions);
            uReferanceInfo1.Bind(dtReferances);
            uUserClubs1.Bind(dtCvs.Rows[0][CVs.ColumnNames.OtherUniversityClubs].ToString(),
                dtCvs.Rows[0][CVs.ColumnNames.OtherClubs].ToString(), dtUserClubs);
            
        }
        #endregion

        #region Control Events
        protected void uCvFormNavigation1_OnMenuItemClick(object sender, int controlOrder)
        {
            ArrangeControlVisibility(controlOrder);
        }
        protected void Control_SubmitForm(object sender, EventArgs e)
        {
            BaseCvEditUserControl control = (BaseCvEditUserControl)sender;
            control.Visible= false;
            ArrangeControlVisibility(control.ControlOrder+1);
            uCvFormNavigation1.ArrangeItems(control.ControlOrder + 1);
        }
        protected void ArrangeControlVisibility(int controlOrder)
        {
            List<BaseCvEditUserControl> cvForms=new List<BaseCvEditUserControl>() ;
            

            cvForms.Add(uWelcome1);
            cvForms.Add(uPersonalInfo1);
            cvForms.Add(uCommunicationInfo1);
            cvForms.Add(uCityCountryInfo1);
            cvForms.Add(uCigaretteUsage1);
            cvForms.Add(uUserClubs1);
            cvForms.Add(uEducationState1);
            cvForms.Add(uMasterInfo1);
            cvForms.Add(uUniversityInfo1);
            cvForms.Add(uHighSchoolInfo1);
            cvForms.Add(uLanguagelInfo1);
            cvForms.Add(uComputerInfo1);
            cvForms.Add(uCertificateInfo1);
            cvForms.Add(uExamInfo1);
            cvForms.Add(uCourseInfo1);
            cvForms.Add(uDrivingLicense1);
            cvForms.Add(uPositions1);
            cvForms.Add(uExperienceInfo1);
            cvForms.Add(uReferanceInfo1);
            cvForms.Add(uCVState1);
            cvForms.Add(uMyPhoto1);
            cvForms.Add(uCVResult1);

            if (controlOrder == uCVResult1.ControlOrder && IsNewCV)
                uCVResult1.CVAddErrors.SetResult(Save());

            BaseCvEditUserControl activeControl = null;
            foreach (BaseCvEditUserControl control in cvForms)
            {
                control.Visible = (control.ControlOrder == controlOrder);
                if (activeControl == null)
                    activeControl = (control.ControlOrder == controlOrder?control:null);
            }

            uCvFormNavigation1.OpenMenu(controlOrder);
            if (activeControl != null)
                uCvFormNavigation1.SetValidationGroup(activeControl.ValidationGroup); 
        }
        #endregion

        #region Save CV
        protected int Save()
        {
            DataTable dtCvs = CVs.CreateTable();
            DataTable dtCertificates;
            DataTable dtWorkPlaces;
            DataTable dtCourseInfo;
            DataTable dtExamInfo;
            DataTable dtExperience;
            DataTable dtLanguageInfo;
            DataTable dtInterestedPositions;
            DataTable dtReferances;
            DataTable dtUserClubs;

            DataRow dr = dtCvs.NewRow();

            //uCigaretteUsage1
            dr[CVs.ColumnNames.CigaretteUseType] = uCigaretteUsage1.CigaretteUseType;

            //uCommunicationInfo1
            dr[CVs.ColumnNames.Email] = DBNullHelper.ConvertValueToDBNull(uCommunicationInfo1.Email);
            dr[CVs.ColumnNames.HomePhone] = DBNullHelper.ConvertValueToDBNull(uCommunicationInfo1.HomePhoneNumber);
            dr[CVs.ColumnNames.MobilePhone1] = DBNullHelper.ConvertValueToDBNull(uCommunicationInfo1.MobileNumber1);
            dr[CVs.ColumnNames.MobilePhone2] = DBNullHelper.ConvertValueToDBNull(uCommunicationInfo1.MobileNumber2);
            dr[CVs.ColumnNames.Webpage] = DBNullHelper.ConvertValueToDBNull(uCommunicationInfo1.Webpage);
            dr[CVs.ColumnNames.ContactType] = DBNullHelper.ConvertValueToDBNull(uCommunicationInfo1.ContactType);

            //uComputerInfo1
            dr[CVs.ColumnNames.ComputerInfo] = DBNullHelper.ConvertValueToDBNull(uComputerInfo1.ComputerInfo);

            //uCVState1
            dr[CVs.ColumnNames.CVState] = uCVState1.State;

            //uDrivingLicense1
            dr[CVs.ColumnNames.HasDrivingLicense] = uDrivingLicense1.HasDrivingLicense;

            //uHighSchoolInfo1 
            dr[CVs.ColumnNames.HighSchool] = DBNullHelper.ConvertValueToDBNull(uHighSchoolInfo1.HighSchool);
            dr[CVs.ColumnNames.HighSchoolEndDate] = DBNullHelper.ConvertValueToDBNull(uHighSchoolInfo1.EndDate);
            dr[CVs.ColumnNames.HighSchoolGradeSystem] = DBNullHelper.ConvertValueToDBNull(uHighSchoolInfo1.EducationGradeSystem);
            dr[CVs.ColumnNames.HighSchoolGraduationGrade] = DBNullHelper.ConvertValueToDBNull(uHighSchoolInfo1.GraduationGrade);

            //uMasterInfo1
            dr[CVs.ColumnNames.MasterDepartment] = DBNullHelper.ConvertValueToDBNull(uMasterInfo1.Department);
            dr[CVs.ColumnNames.MasterDepartmentFree] = DBNullHelper.ConvertValueToDBNull(uMasterInfo1.DepartmentFree);
            dr[CVs.ColumnNames.MasterEndDate] = DBNullHelper.ConvertValueToDBNull(uMasterInfo1.EndDate);
            dr[CVs.ColumnNames.MasterGradeSystem] = DBNullHelper.ConvertValueToDBNull(uMasterInfo1.GradeSystem);
            dr[CVs.ColumnNames.MasterGraduationGrade] = DBNullHelper.ConvertValueToDBNull(uMasterInfo1.GraduationGrade);
            dr[CVs.ColumnNames.MasterInstitute] = DBNullHelper.ConvertValueToDBNull(uMasterInfo1.Institute);
            dr[CVs.ColumnNames.MasterStartDate] = DBNullHelper.ConvertValueToDBNull(uMasterInfo1.StartDate);
            dr[CVs.ColumnNames.MasterUniversity] = DBNullHelper.ConvertValueToDBNull(uMasterInfo1.University);
            dr[CVs.ColumnNames.MasterUniversityFree] = DBNullHelper.ConvertValueToDBNull(uMasterInfo1.UniversityFree);

            //uPersonalInfo1
            dr[CVs.ColumnNames.BirthPlaceCity] = DBNullHelper.ConvertValueToDBNull(uPersonalInfo1.BirthCity);
            dr[CVs.ColumnNames.BirthPlaceCityFree] = DBNullHelper.ConvertValueToDBNull(uPersonalInfo1.BirthCityFree);
            dr[CVs.ColumnNames.BirthPlaceCountry] = DBNullHelper.ConvertValueToDBNull(uPersonalInfo1.BirthCountry);
            dr[CVs.ColumnNames.MaritalStatus] = DBNullHelper.ConvertValueToDBNull(uPersonalInfo1.MaritalStatus);
            dr[CVs.ColumnNames.Nationality] = DBNullHelper.ConvertValueToDBNull(uPersonalInfo1.Nationality);

            //uPositions1
            dr[CVs.ColumnNames.InterestedAdvertisementType] = DBNullHelper.ConvertValueToDBNull(uPositions1.InterestedAdversementType);

            //uUniversityInfo1
            dr[CVs.ColumnNames.LicenseDepartment] = DBNullHelper.ConvertValueToDBNull(uUniversityInfo1.Department);
            dr[CVs.ColumnNames.LicenseDepartmentFree] = DBNullHelper.ConvertValueToDBNull(uUniversityInfo1.DepartmentFree);
            dr[CVs.ColumnNames.LicenseEducationType] = DBNullHelper.ConvertValueToDBNull(uUniversityInfo1.EducationType);
            dr[CVs.ColumnNames.LicenseEndDate] = DBNullHelper.ConvertValueToDBNull(uUniversityInfo1.EndDate);
            dr[CVs.ColumnNames.LicenseGradeSystem] = DBNullHelper.ConvertValueToDBNull(uUniversityInfo1.GradeSystem);
            dr[CVs.ColumnNames.LicenseGraduationGrade] = DBNullHelper.ConvertValueToDBNull(uUniversityInfo1.GraduationGrade);
            dr[CVs.ColumnNames.LicenseInstitute] = DBNullHelper.ConvertValueToDBNull(uUniversityInfo1.Institute);
            dr[CVs.ColumnNames.LicenseStartDate] = DBNullHelper.ConvertValueToDBNull(uUniversityInfo1.StartDate);
            dr[CVs.ColumnNames.LicenseUniversity] = DBNullHelper.ConvertValueToDBNull(uUniversityInfo1.University);
            dr[CVs.ColumnNames.LicenseUniversityFree] = DBNullHelper.ConvertValueToDBNull(uUniversityInfo1.UniversityFree);

            //uUserClubs1
            dr[CVs.ColumnNames.OtherClubs] = DBNullHelper.ConvertValueToDBNull(uUserClubs1.OtherClubs);
            dr[CVs.ColumnNames.OtherUniversityClubs] = DBNullHelper.ConvertValueToDBNull(uUserClubs1.OtherUniversityClubs);

            //uEducationState1
            dr[CVs.ColumnNames.EducationState] = DBNullHelper.ConvertValueToDBNull(uEducationState1.State);

            //uWelcome1
            dr[CVs.ColumnNames.Name] = uWelcome1.CVName;
            dr[CVs.ColumnNames.CvLanguage] = uWelcome1.CVLanguage;

            dr[CVs.ColumnNames.UserId] = DBNullHelper.ConvertValueToDBNull(UserId);
            dr[CVs.ColumnNames.ModifyDate] = DateTime.Now;
            dr[CVs.ColumnNames.CreateDate] = DateTime.Now;

            //uExperienceInfo1
            dr[CVs.ColumnNames.TotalWorkExperienceInMonth] = DBNullHelper.ConvertValueToDBNull(uExperienceInfo1.WorkingExperience);
            dr[CVs.ColumnNames.WorkingStatus]=DBNullHelper.ConvertValueToDBNull(uExperienceInfo1.WorkingStatus);

            dtCertificates = uCertificateInfo1.GetData();
            dtWorkPlaces = uCityCountryInfo1.GetData();
            dtCourseInfo = uCourseInfo1.GetData();
            dtExamInfo = uExamInfo1.GetData();
            dtExperience = uExperienceInfo1.GetData();
            dtLanguageInfo = uLanguagelInfo1.GetData();
            dtInterestedPositions = uPositions1.GetData();
            dtReferances = uReferanceInfo1.GetData();
            dtUserClubs = uUserClubs1.GetData();

            return CVs.Add(dr,dtCertificates,dtWorkPlaces,dtCourseInfo,dtExamInfo,dtExperience,dtLanguageInfo,
                dtInterestedPositions,dtReferances,dtUserClubs);
        }
        #endregion
    }
}