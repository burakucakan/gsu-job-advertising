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
    public partial class uFirmApplicationList : BaseUserControl
    {
        public bool PagingShow
        {
            get { return uPaging.Visible; }
            set { uPaging.Visible = value; }
        }

        private DataTable dt;

        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public void Bind(DataTable dt)
        {
            if (dt.Rows.Count > 0)
            {
                this.dt = dt;

                DataTable dtAdvs = DataTableHelper.Distinct(this.dt, "AdvertisementId");
                uPaging.GeneratePager(ref dtAdvs, rptAdvs);

                PHList.Visible = true;
                ltlNoData.Visible = false;
            }
            else
            {
                PHList.Visible = false;
                ltlNoData.Visible = true;
            }
        }

        protected void rptAdvs_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
            {
                HyperLink hlAdvertisement = (HyperLink)e.Item.FindControl("hlAdvertisement");
                int AdvertisementId = Convert.ToInt32(hlAdvertisement.NavigateUrl);
                hlAdvertisement.NavigateUrl = UrlHelper.PageUrl.AdvertisementDetail(AdvertisementId, this.SessionManager.FirmName, hlAdvertisement.Text);

                Repeater rptList = ((Repeater)e.Item.FindControl("rptList"));
                DataTable dtList = DataTableHelper.Filter(this.dt, "AdvertisementId", AdvertisementId.ToString());
                DataBindHelper.BindRepeater(ref rptList, dtList);
            }
        }

        protected void rptList_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
            {
                HyperLink hlImgUser = (HyperLink)e.Item.FindControl("hlImgUser");
                HyperLink hlUser = (HyperLink)e.Item.FindControl("hlUser");
                Literal ltlEducationState = (Literal)e.Item.FindControl("ltlEducationState");
                Literal ltlCity = (Literal)e.Item.FindControl("ltlCity");
                Literal ltlCountry = (Literal)e.Item.FindControl("ltlCountry");
                Literal ltlGender = (Literal)e.Item.FindControl("ltlGender");
                Literal ltlBirthDate = (Literal)e.Item.FindControl("ltlBirthDate");
                Literal ltlUnvDepartment = (Literal)e.Item.FindControl("ltlUnvDepartment");
                
                int UserId = int.Parse(hlImgUser.ImageUrl);
                int CvId = int.Parse(hlImgUser.NavigateUrl);                
                string Name = ((Literal)e.Item.FindControl("ltlName")).Text;
                string Surname = ((Literal)e.Item.FindControl("ltlSurname")).Text;
                BUS.AdvertisementApplications.State State = (BUS.AdvertisementApplications.State)int.Parse(((Literal)e.Item.FindControl("ltlState")).Text);

                
                string MasterDepartment = ((HiddenField)e.Item.FindControl("hdMasterDepartment")).Value;
                string MasterDepartmentFree = ((HiddenField)e.Item.FindControl("hdMasterDepartmentFree")).Value;
                string LicenseDepartment = ((HiddenField)e.Item.FindControl("hdLicenseDepartment")).Value;
                string LicenseDepartmentFree = ((HiddenField)e.Item.FindControl("hdLicenseDepartmentFree")).Value;
                int applicationId = ((HiddenField)e.Item.FindControl("hdApplicationId")).Value.ToInt();

                hlImgUser.ImageUrl = UrlHelper.ImgUrl.ImgUrlUser(int.Parse(hlImgUser.ImageUrl), UrlHelper.ImgUrl.ImgSizes.Square);
                hlImgUser.NavigateUrl = UrlHelper.PageUrl.Cv(CvId, Name, Surname, applicationId);
                hlUser.NavigateUrl = hlImgUser.NavigateUrl;

                ltlEducationState.Text = SiteParams.GetEducatonStateDescription(int.Parse(ltlEducationState.Text));
                ltlCity.Text = SiteParams.CityCountry.GetCityDescription(int.Parse(ltlCity.Text));
                ltlCountry.Text = SiteParams.CityCountry.GetCountryDescription(int.Parse(ltlCountry.Text));
                ltlGender.Text = SiteParams.GetGenderDescription(int.Parse(ltlGender.Text));
                ltlBirthDate.Text = (DateTime.Now.Year - Convert.ToDateTime(ltlBirthDate.Text).Year).ToString();

                string imgID = "";
                switch (State)
                {
                    case AdvertisementApplications.State.Viewed:
                        imgID = "imgViewed";
                        break;
                    case AdvertisementApplications.State.NotViewed:
                        imgID = "imgNotViewed";
                        break;
                    case AdvertisementApplications.State.Answered:
                        imgID = "imgAnswered";
                        break;
                }

                ((Image)e.Item.FindControl(imgID)).Visible = true;

                if (MasterDepartment != "")
                {
                    if (int.Parse(MasterDepartment) != CVs.EducationInfo.UniversityDepartment.Other)
                        ltlUnvDepartment.Text = SiteParams.GetUniversityDepartmentDescription(int.Parse(MasterDepartment));
                    else if (!String.IsNullOrEmpty(MasterDepartmentFree))
                        ltlUnvDepartment.Text = MasterDepartmentFree;

                }
                else
                {
                    if (int.Parse(LicenseDepartment) != CVs.EducationInfo.UniversityDepartment.Other)
                        ltlUnvDepartment.Text = SiteParams.GetUniversityDepartmentDescription(int.Parse(LicenseDepartment));
                    else if (!String.IsNullOrEmpty(LicenseDepartmentFree))
                        ltlUnvDepartment.Text = LicenseDepartmentFree;
                }
            }
        }
    }
}