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

namespace GSUKariyer.WEB.UserControls.Firm
{    
    public partial class uUserSearch : BaseFirmUserControl
    {
        protected struct LBtnCommadArguments
        {
            public const string lbtnGeneralCriteria = "divGeneral";
            public const string lbtnGsuInstuteAndDepartments = "divUniversityDepartments";
            public const string lbtnLanguages = "divLanguages";
            public const string lbtnClubs = "divGsClubs";
            public const string lbtnCertificates = "divCertificates";
            public const string lbtnWorkExperiences = "divWorkExperience";
            public const string lbtnInterestedPositions="divInterestedPositions";
        }
        public delegate void BannerShow_EventHandler(bool isVisible);
        protected BannerShow_EventHandler _bannerShow;
        public BannerShow_EventHandler BannerShow
        {
            get { return _bannerShow; }
            set { _bannerShow=value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                ArrangeForm();
        }

        #region ArrangeForms
        protected void ArrangeForm()
        {
            lbtnGeneralCriteria.CommandArgument = LBtnCommadArguments.lbtnGeneralCriteria;
            lbtnGsuInstuteAndDepartments.CommandArgument = LBtnCommadArguments.lbtnGsuInstuteAndDepartments;
            lbtnLanguages.CommandArgument = LBtnCommadArguments.lbtnLanguages; 
            lbtnCertificates.CommandArgument = LBtnCommadArguments.lbtnCertificates;
            lbtnClubs.CommandArgument = LBtnCommadArguments.lbtnClubs;
            lbtnInterestedPositions.CommandArgument = LBtnCommadArguments.lbtnInterestedPositions;

            ArrangeForm(LBtnCommadArguments.lbtnGeneralCriteria);
        }
        protected void ArrangeForm(string commandArgument)
        {
            switch (commandArgument)
            {
                case LBtnCommadArguments.lbtnGeneralCriteria:
                    if (ddlAges.Items.Count == 0)
                    {
                        ddlAges.DataSource = SiteParams.GetUserAge();
                        ddlAges.DataTextField = SiteParams.ColumnNames.Description;
                        ddlAges.DataValueField = SiteParams.ColumnNames.Value;
                        ddlAges.DataBind();
                    }
                    break;
                case LBtnCommadArguments.lbtnClubs:
                    if (lbGsClubs.Items.Count == 0)
                    {
                        lbGsClubs.DataSource = SiteParams.GetGSClubs();
                        lbGsClubs.DataTextField = SiteParams.ColumnNames.Description;
                        lbGsClubs.DataValueField = SiteParams.ColumnNames.Value;
                        lbGsClubs.DataBind();
                    }
                    break;
                case LBtnCommadArguments.lbtnGsuInstuteAndDepartments:
                    if (lbUniversityDepartments.Items.Count == 0)
                    {
                        lbUniversityDepartments.DataSource = SiteParams.GetUniversityDepartments();
                        lbUniversityDepartments.DataTextField = SiteParams.ColumnNames.Description;
                        lbUniversityDepartments.DataValueField = SiteParams.ColumnNames.Value;
                        lbUniversityDepartments.DataBind();
                    }
                    break;
                case LBtnCommadArguments.lbtnLanguages:
                    if (ddlLanguages1.Items.Count == 0)
                    {
                        DataTable dtlanguage = SiteParams.GetLanguages();

                        DataRow dr = dtlanguage.NewRow();
                        dr[SiteParams.ColumnNames.Description] = "...";
                        dr[SiteParams.ColumnNames.Value] =String.Empty;

                        dtlanguage.Rows.InsertAt(dr,0);

                        ddlLanguages1.DataSource = dtlanguage;
                        ddlLanguages1.DataTextField = SiteParams.ColumnNames.Description;
                        ddlLanguages1.DataValueField = SiteParams.ColumnNames.Value;
                        ddlLanguages1.DataBind();

                        ddlLanguages2.DataSource = dtlanguage;
                        ddlLanguages2.DataTextField = SiteParams.ColumnNames.Description;
                        ddlLanguages2.DataValueField = SiteParams.ColumnNames.Value;
                        ddlLanguages2.DataBind();

                        ddlLanguages3.DataSource = dtlanguage;
                        ddlLanguages3.DataTextField = SiteParams.ColumnNames.Description;
                        ddlLanguages3.DataValueField = SiteParams.ColumnNames.Value;
                        ddlLanguages3.DataBind();
                    }
                    break;
                case LBtnCommadArguments.lbtnCertificates:
                    if (lbCertificateCategories.Items.Count == 0)
                    {
                        lbCertificateCategories.DataSource = SiteParams.GetCertificateCategory();
                        lbCertificateCategories.DataTextField = SiteParams.ColumnNames.Description;
                        lbCertificateCategories.DataValueField = SiteParams.ColumnNames.Value;
                        lbCertificateCategories.DataBind(); 
                    }
                    break;
                case LBtnCommadArguments.lbtnInterestedPositions:
                    if (lbInterestedPositions.Items.Count == 0)
                    {
                        lbInterestedPositions.DataSource = SiteParams.GetPositions();
                        lbInterestedPositions.DataTextField = SiteParams.ColumnNames.Description;
                        lbInterestedPositions.DataValueField = SiteParams.ColumnNames.Value;
                        lbInterestedPositions.DataBind(); 
                    }
                    break;
            }
        }
        #endregion

        #region Button Events
        protected void lbtnSearchCriteria_Click(object sender, EventArgs e)
        {
            divGeneral.Visible = false;
            divCertificates.Visible = false;
            divGsClubs.Visible = false;
            divLanguages.Visible = false;
            divUniversityDepartments.Visible = false;
            divInterestedPositions.Visible = false;

            string commandArgument = ((LinkButton)sender).CommandArgument;
            ((HtmlControl)this.FindControl(commandArgument)).Visible = true;
            ArrangeForm(commandArgument);
        }
        protected void imgBtnSearch_Click(object sender, ImageClickEventArgs e)
        {
            Users.SearchHelper searchHelper = new Users.SearchHelper();

            searchHelper.Age = ddlAges.SelectedValue.ToNullableInt();
            searchHelper.EducationState = uEducationStates1.SelectedValue.ToNullableInt();
            searchHelper.WorkExperienceInMonth = uWorkingExperiences2.SelectedValue.ToNullableInt();
            searchHelper.WorkingStatus = uWorkingStatus2.SelectedValue.ToNullableInt();

            foreach (ListItem item in lbUniversityDepartments.Items)
            {
                if (item.Selected)
                    searchHelper.UnivDepartmentList.Add(item.Value.ToNullableInt());

                if (searchHelper.UnivDepartmentList.ListCount == searchHelper.UnivDepartmentList.MaxListCount)
                    break;
            }

            foreach (ListItem item in lbCertificateCategories.Items)
            {
                if (item.Selected)
                    searchHelper.CertificateList.Add(item.Value.ToNullableInt());

                if (searchHelper.CertificateList.ListCount == searchHelper.CertificateList.MaxListCount)
                    break;
            }

            foreach (ListItem item in lbGsClubs.Items)
            {
                if (item.Selected)
                    searchHelper.GsClubsList.Add(item.Value.ToNullableInt());

                if (searchHelper.GsClubsList.ListCount == searchHelper.GsClubsList.MaxListCount)
                    break;
            }

            foreach (ListItem item in lbInterestedPositions.Items)
            {
                if (item.Selected)
                    searchHelper.InterestedPositionsList.Add(item.Value);

                if (searchHelper.InterestedPositionsList.ListCount == searchHelper.InterestedPositionsList.MaxListCount)
                    break;
            }

            uUsers1.Bind(searchHelper.Search()); 

            divSearch.Visible = false;
            uUsers1.Visible = true;
            if (BannerShow != null)
                BannerShow(false);
        }
        #endregion

        #region ListBoxEvents
        protected void lb_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedItemCount = 0;
            foreach (ListItem listItem in (sender as ListBox).Items)
            {
                if (listItem.Selected)
                {
                    if (selectedItemCount == BUS.Users.SearchHelper.MaxSelectedItemCount)
                    {
                        listItem.Selected = false;
                        continue;
                    }

                    selectedItemCount++;
                }
            }
        }
        #endregion

        protected void uUsers1_BackClick(object sender, EventArgs e)
        {
            divSearch.Visible = true;
            uUsers1.Visible = false;
        }
        
    }
}