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


namespace GSUKariyer.WEB.UserControls.Firm
{
    public partial class uFirm : BaseFirmUserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Arrange();
                Bind();
            }
        }

        #region ArrangeForm/BindForm
        protected void Arrange()
        {
            hlUserDetailSearch.NavigateUrl = UrlHelper.PageUrl.UserSearch();
            
            ddlAge.DataSource = SiteParams.GetUserAge();
            ddlAge.DataTextField = SiteParams.ColumnNames.Description;
            ddlAge.DataValueField = SiteParams.ColumnNames.Value;
            ddlAge.DataBind();

            DataTable dtUnivDepartments = SiteParams.GetUniversityDepartments().Copy(); 
            DataRow dr=dtUnivDepartments.NewRow();
            dr[SiteParams.ColumnNames.Description] = "Seçiniz";
            dr[SiteParams.ColumnNames.Value] = String.Empty;
            dtUnivDepartments.Rows.InsertAt(dr, 0);

            ddlUnivDepartments.DataSource = dtUnivDepartments;
            ddlUnivDepartments.DataTextField = SiteParams.ColumnNames.Description;
            ddlUnivDepartments.DataValueField = SiteParams.ColumnNames.Value;
            ddlUnivDepartments.DataBind();

            DataTable dtWorkTypes = SiteParams.GetAdvertisementTypes().Copy();
            dr = dtWorkTypes.NewRow();
            dr[SiteParams.ColumnNames.Description] = "Seçiniz";
            dr[SiteParams.ColumnNames.Value] = String.Empty;
            dtWorkTypes.Rows.InsertAt(dr, 0);

            ddlWorkTypes.DataSource = dtWorkTypes;
            ddlWorkTypes.DataTextField = SiteParams.ColumnNames.Description;
            ddlWorkTypes.DataValueField = SiteParams.ColumnNames.Value;
            ddlWorkTypes.DataBind();

            DataTable dtEducationStates = SiteParams.GetEducationStates().Copy();
            dr = dtEducationStates.NewRow();
            dr[SiteParams.ColumnNames.Description] = "Hepsi";
            dr[SiteParams.ColumnNames.Value] = String.Empty;
            dtEducationStates.Rows.Add(dr);

            rblEducationState.DataSource = dtEducationStates;
            rblEducationState.DataTextField = SiteParams.ColumnNames.Description;
            rblEducationState.DataValueField = SiteParams.ColumnNames.Value;
            rblEducationState.DataBind();

            rblEducationState.SelectedIndex = 2;
        }

        protected void Bind()
        {
            FirmAdvertisements();
            FirmApplications();
        }

        private void FirmAdvertisements()
        {
            hlAllFirmAdvertisements.NavigateUrl = UrlHelper.PageUrl.FirmAdvertisements();
            DataTable dtLastAdvertisements = BUS.Advertisements.GetLastFirmAdvertisements(this.SessionManager.FirmId);

            uFirmAdvertisementListLast.Bind(dtLastAdvertisements);
            hlAllFirmAdvertisements.Visible = (dtLastAdvertisements.Rows.Count > 0);

            uFirmAdvertisementListLast.PagingShow = false;
        }

        protected void FirmApplications()
        {
            hlFirmApplications.NavigateUrl = UrlHelper.PageUrl.FirmApplications();
            DataTable dt = BUS.AdvertisementApplications.GetApplicationsTop(this.SessionManager.FirmId);
            uFirmApplicationList1.Bind(dt);
            uFirmApplicationList1.PagingShow = false;
            hlFirmApplications.Visible = dt.Rows.Count > 0;
        }
        #endregion

        #region Button Events
        protected void btnSearch_Click(object sender, ImageClickEventArgs e)
        {
            if (ddlUnivDepartments.SelectedIndex == 0 && ddlAge.SelectedIndex == 0 &&
                ddlWorkTypes.SelectedIndex == 0 && rblEducationState.SelectedValue == String.Empty)
                return;

            Response.Redirect(UrlHelper.PageUrl.Users(Users.SearchHelper.UsersPage.Mode.Fast,
                ddlUnivDepartments.SelectedValue,ddlAge.SelectedValue,rblEducationState.SelectedValue,
                ddlWorkTypes.SelectedValue));
        }
        #endregion
    }
}
