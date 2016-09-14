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
using GSUKariyer.BUS;

namespace GSUKariyer.WEB.UserControls.Advertisement
{
    public partial class uAdvertisementDetail : BaseUserControl
    {
        #region Properties
        public int? AdvertisementId
        {
            get { return GetUrlParam<int>(UrlHelper.PageUrl.UrlKey.Id); }
        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ArrangeForm();
                BindForm();
            }
        }

        #region BindForm
        protected void ArrangeForm()
        {
            if (!this.SessionManager.IsLoggedIn)
            {
                hlApply.NavigateUrl = "javascript:Login()";
                uSendCv1.Visible = false;
                hlApply.Visible = (!this.SessionManager.IsFirmLoggedIn);
            }
            else
            {
                DataTable dtAdvApp = BUS.AdvertisementApplications.GetAdvertisementApplication(this.AdvertisementId.Value, this.SessionManager.UserId.Value);

                if (dtAdvApp.Rows.Count > 0)
                {
                    pnlJobHasApply.Visible = true;
                    hlApply.NavigateUrl = "javascript:ShowHideChng('" + pnlJobHasApply.ClientID + "', 'dvJobDetail')";
                    ltlName.Text = this.SessionManager.Name;
                    ltlSurname.Text = this.SessionManager.Surname;
                    ltlApplyDate.Text = Convert.ToDateTime(dtAdvApp.Rows[0][BUS.AdvertisementApplications.ColumnNames.CreateDate]).ToShortDateString();
                    ltlCvName.Text = BUS.CVs.Generated.Get(Convert.ToInt32(dtAdvApp.Rows[0][BUS.AdvertisementApplications.ColumnNames.CvId])).Rows[0][BUS.CVs.ColumnNames.Name].ToString();
                }

                hlUserApplications.NavigateUrl = UrlHelper.PageUrl.UserApplications();
                hlUserApplication2.NavigateUrl = UrlHelper.PageUrl.UserApplications();

                DataBindHelper.BindDDL(ref ddlFrontPosts, BUS.UserFrontPosts.GetByUserId(this.SessionManager.UserId.Value), BUS.UserFrontPosts.ColumnNames.Title, BUS.UserFrontPosts.ColumnNames.ID, "", "Önyazılarınız", "0");

                DataTable dtCvs = Users.Cv.Get(this.SessionManager.UserId.Value);
                int DefaultCvId = 0;
                DataTable dtUserCvs = dtCvs.Clone();
                foreach (DataRow dr in dtCvs.Rows)
                    if (dr[BUS.CVs.ColumnNames.CVState].ToInt() == (int)BUS.CVs.CVState.Active)
                    {
                        dtUserCvs.Rows.Add(dr.ItemArray);
                        if (Convert.ToBoolean(dr[BUS.CVs.ColumnNames.IsDefault]))
                            DefaultCvId = dr[BUS.CVs.ColumnNames.ID].ToInt();
                    }

                if (dtUserCvs.Rows.Count > 0)
                    DataBindHelper.BindDDL(ref ddlCvs, dtUserCvs, BUS.CVs.ColumnNames.Name, BUS.CVs.ColumnNames.ID, DefaultCvId.ToString());
                else
                {
                    imgBtnApply1.Visible = false;
                    phCvSelect.Visible = false;
                    pnlNoCv.Visible = true;
                    hlCvCreate.Visible = true;
                    hlCvCreate.NavigateUrl = UrlHelper.PageUrl.CvAdd();
                }
            }

            CheckUrlParamRedirect(UrlHelper.PageUrl.Default(), UrlHelper.PageUrl.UrlKey.Id);
        }
        protected void BindForm()
        {
            DataTable dtAdvertisements = BUS.Advertisements.GetDetail(AdvertisementId.Value);

            if (dtAdvertisements.Rows.Count > 0)
            {
                DataRow dr = dtAdvertisements.Rows[0];

                hlFirmDetail.NavigateUrl = UrlHelper.PageUrl.FirmDetail(dr[BUS.Advertisements.CustomColumnNames.FirmId].ToInt(), dr[BUS.Advertisements.CustomColumnNames.FirmName].ToString());
                uSendCv1.FirmId = dr[BUS.Advertisements.ColumnNames.FirmId].ToInt();
                uSendCv1.FirmMail = dr[BUS.FirmUsers.ColumnNames.Email].ToString();

                ltrAdvertisementDate.Text = FormatHelper.ConvertDBDateTimeStringToShortString(
                    dr[BUS.Advertisements.ColumnNames.StartDate].ToString());
                ltlDetail.Text = Util.Nl2Br(Util.rt(dr[BUS.Advertisements.ColumnNames.Detail].ToString()));
                ltlDescription.Text = Util.Nl2Br(Util.rt(dr[BUS.Advertisements.ColumnNames.Description].ToString()));
                ltrCityCountry.Text = SiteParams.CityCountry.Get(
                    DBNullHelper.GetNullableValue<int>(dr[BUS.Advertisements.ColumnNames.City]),
                    DBNullHelper.GetNullableValue<int>(dr[BUS.Advertisements.ColumnNames.Country]));

                if (String.IsNullOrEmpty(dr[BUS.Advertisements.ColumnNames.EmployeesCount].ToString()))
                    ltrEmployeesCount.Text = "-";
                else
                    ltrEmployeesCount.Text = dr[BUS.Advertisements.ColumnNames.EmployeesCount].ToString();
                
                ltrFirmName.Text = dr[BUS.Advertisements.CustomColumnNames.FirmName].ToString();
                ltrPosition.Text = SiteParams.GetPositionDescription( 
                    dr[BUS.Advertisements.ColumnNames.WorkPosition].ToString());
                ltrTitle.Text = Util.ToLower(dr[BUS.Advertisements.ColumnNames.Title].ToString());

                //Arranging Company Logo
                string companyLogoUrl = UrlHelper.ImgUrl.ImgUrlCompany(
                    dr[BUS.Advertisements.CustomColumnNames.FirmId].ToInt(),
                    UrlHelper.ImgUrl.ImgSizes.Default);

                hlCompany.ImageUrl = UrlHelper.ImgUrl.ImgUrlCompany(dr[BUS.Advertisements.CustomColumnNames.FirmId].ToInt(), UrlHelper.ImgUrl.ImgSizes.Default);
                hlCompany.Visible = hlCompany.ImageUrl.Length > 0;
                hlCompany.ToolTip = dr[BUS.Advertisements.CustomColumnNames.FirmName].ToString();
                hlCompany.NavigateUrl = UrlHelper.PageUrl.FirmDetail(
                    dr[BUS.Advertisements.CustomColumnNames.FirmId].ToInt(),
                    dr[BUS.Advertisements.CustomColumnNames.FirmName].ToString());

            }
            else
                ThrowNoDataException("BindForm");
        }
        #endregion


        #region Button Events


        #endregion

        protected void ddlFrontPosts_SelectedIndexChanged(object sender, EventArgs e) {
            int UserFrontPostId = ddlFrontPosts.SelectedValue.ToInt();
            if (UserFrontPostId < 1)
            {
                txtFrontPostTitle.Text = "";
                txtFrontPost.Text = "";
            }
            else
            {
                DataTable dtUserFrontPost = BUS.UserFrontPosts.Generated.Get(UserFrontPostId);
                txtFrontPostTitle.Text = dtUserFrontPost.Rows[0][BUS.UserFrontPosts.ColumnNames.Title].ToString();
                txtFrontPost.Text = dtUserFrontPost.Rows[0][BUS.UserFrontPosts.ColumnNames.Content].ToString();
            }
        }

        protected void imgBtnApply_Click(object sender, ImageClickEventArgs e)
        {
            PHJobApplyFinish.Visible = true;
            PHJobApplyForm.Visible = false;

            if (IsApplied())
                Response.Redirect(UrlHelper.PageUrl.Default());
            else {
                succApply.Visible = Apply();
                errApply.Visible = !succApply.Visible;
            }
        }

        private bool IsApplied()
        {
            return BUS.AdvertisementApplications.IsApplied(this.AdvertisementId.Value, this.SessionManager.UserId.Value);
        }

        private bool Apply()
        {
            string FrontPostTitle = Util.r(txtFrontPostTitle.Text);
            string FrontPost = Util.r(txtFrontPost.Text);
            return BUS.AdvertisementApplications.Generated.Add(this.AdvertisementId.Value, this.SessionManager.UserId.Value, int.Parse(ddlCvs.SelectedValue), FrontPostTitle, FrontPost, "", false, (int)BUS.AdvertisementApplications.State.NotViewed, DateTime.Now, DateTime.Now) > 0;
        }
    }
}