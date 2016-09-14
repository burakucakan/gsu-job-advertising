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
using System.IO;
using GSUKariyer.BUS;

namespace GSUKariyer.WEB.UserControls.Firm
{
    public partial class uFirmSignup : BaseUserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {
	            ArrangeForm();

                if (this.SessionManager.IsFirmLoggedIn) {
                    BindData();
                }
            }
        }

        protected void BindData()
        {
            DataTable dtFirmDetail = BUS.Firms.Generated.Get(this.SessionManager.FirmId);
            DataTable dtFirmUser = BUS.FirmUsers.GetFirmUser(this.SessionManager.FirmId);

            if ((dtFirmDetail.Rows.Count > 0) && (dtFirmUser.Rows.Count > 0))
            {
                DataRow drFirm = dtFirmDetail.Rows[0];
                DataRow drUser = dtFirmUser.Rows[0];

                txtName.Text = drFirm[BUS.Firms.ColumnNames.Name].ToString();
                USectors1.SelectedValue = drFirm[BUS.Firms.ColumnNames.Sector].ToString();
                ddlWorkerCount.SelectedValue = drFirm[BUS.Firms.ColumnNames.WorkerCount].ToString();
                txtAddress.Text= drFirm[BUS.Firms.ColumnNames.Address].ToString();
                txtZipcode.Text= drFirm[BUS.Firms.ColumnNames.Zipcode].ToString();
                uCountries1.SelectedValue= drFirm[BUS.Firms.ColumnNames.Country].ToString();
                uCities1.SelectedValue= drFirm[BUS.Firms.ColumnNames.City].ToString();
                txtWebPage.Text = drFirm[BUS.Firms.ColumnNames.Webpage].ToString();
                txtDescription.Text = drFirm[BUS.Firms.ColumnNames.Description].ToString().Replace("&#39;", "'");

                txtFirmUserName.Text = drUser[BUS.FirmUsers.ColumnNames.Name].ToString();
                txtFirmUserSurname.Text = drUser[BUS.FirmUsers.ColumnNames.Surname].ToString();
                txtPosition.Text = drUser[BUS.FirmUsers.ColumnNames.Position].ToString();
                txtPhone.Text = drUser[BUS.FirmUsers.ColumnNames.Phone].ToString();
                txtFax.Text = drUser[BUS.FirmUsers.ColumnNames.Fax].ToString();
                txtEmail.Text = drUser[BUS.FirmUsers.ColumnNames.Email].ToString();

                //Logo İşlemleri
                SetLogo();

                hdFirmUserId.Value = drUser[BUS.FirmUsers.ColumnNames.ID].ToString();

                txtEmail.Enabled = false;
                hdPassword.Value = drUser[BUS.FirmUsers.ColumnNames.Password].ToString();
                reqPassword.Visible = false;
                reqPassword2.Visible = false;
            }
            else
                UrlHelper.PageUrl.Default();
        }

        protected void SetLogo()
        {
            string companyLogoUrl = UrlHelper.ImgUrl.ImgUrlCompany(this.SessionManager.FirmId, UrlHelper.ImgUrl.ImgSizes.Thumb);

            if (File.Exists(Request.MapPath(companyLogoUrl)))
            {
                pnlLogo.Visible = true;
                imgLogo.ImageUrl = companyLogoUrl;
            }
            else
                pnlLogo.Visible = false;
        }

        protected void ArrangeForm() {
            FillWorkerCount();
            SetLocationSettings();
        }

        protected void SetLocationSettings()
        {
            uCities1.FreeItemValue = SiteParams.CityCountry.otherCityValue;
            uCities1.ParentControl = uCountries1;
        }
        
        protected void FillWorkerCount() {
            ddlWorkerCount.DataSource = SiteParams.GetWorkerCounts();
            ddlWorkerCount.DataTextField = SiteParams.ColumnNames.Description;
            ddlWorkerCount.DataValueField = SiteParams.ColumnNames.Value;
            ddlWorkerCount.DataBind();

            ddlWorkerCount.Items.Add(new ListItem("Lütfen Seçiniz","-1"));
        }

        protected void lnkDelLogo_Click(object sender, EventArgs e)
        {
            string companyLogoUrl = UrlHelper.ImgUrl.ImgUrlCompany(this.SessionManager.FirmId, UrlHelper.ImgUrl.ImgSizes.Default);

            try
            {
                if (File.Exists(Request.MapPath(companyLogoUrl)))
                {
                    File.Delete(Request.MapPath(companyLogoUrl));

                    companyLogoUrl = UrlHelper.ImgUrl.ImgUrlCompany(this.SessionManager.FirmId, UrlHelper.ImgUrl.ImgSizes.Thumb);
                    if (File.Exists(Request.MapPath(companyLogoUrl)))
                        File.Delete(Request.MapPath(companyLogoUrl));
                        
                    pnlLogo.Visible = false;
                }
            }
            catch (Exception)
            { }
            errDelLogo.Visible = pnlLogo.Visible;
            succDelLogo.Visible = !errDelLogo.Visible;
        }

        protected void imgBtnSend_Click(object sender, ImageClickEventArgs e)
        {
            if (Page.IsValid)
            {
                string Name = Util.r(txtName.Text);
                string SectorValue = USectors1.SelectedValue;
                int WorkerCount = int.Parse(ddlWorkerCount.SelectedValue);
                string Address = Util.r(txtAddress.Text);
                string ZipCode = Util.r(txtZipcode.Text);
                int Country = int.Parse(uCountries1.SelectedValue);
                int City = int.Parse(uCities1.SelectedValue);
                string WebPage = Util.r(txtWebPage.Text);
                string Description = Util.r(txtDescription.Text);

                int FirmUserId = hdFirmUserId.Value == "" ? 0 : hdFirmUserId.Value.ToInt();

                string FirmUserName = Util.r(txtFirmUserName.Text);
                string FirmUserSurname = Util.r(txtFirmUserSurname.Text);
                string Position = Util.r(txtPosition.Text);
                string Phone = Util.r(txtPhone.Text);
                string Fax = Util.r(txtFax.Text);
                string Email = Util.r(txtEmail.Text.Trim());
                string Password = Util.r(txtPassword.Text);

                Password = Encryption.Encrypt(Util.r(Password.Trim()));

                bool HasUser = false;

                if (!this.SessionManager.IsFirmLoggedIn)
                    HasUser = BUS.FirmUsers.HasUser(Email);
                else
                    if (txtPassword.Text.Trim() == String.Empty) Password = hdPassword.Value;

                if (!HasUser)
                {
                    int SavedFirmId = BUS.Firms.Save(this.SessionManager.FirmId, Name, SectorValue, WorkerCount, Address, ZipCode, Country, City, WebPage, Description,
                        FirmUserId, FirmUserName, FirmUserSurname, Position, Phone, Fax, Email, Password);

                    if (SavedFirmId > 0)
                    {
                        succUpdate.Visible = this.SessionManager.IsFirmLoggedIn;
                        succSave.Visible = !this.SessionManager.IsFirmLoggedIn;

                        errDelLogo.Visible = errHasUser.Visible = errLogo.Visible = false;

                        Mail objMail = new Mail();
                        objMail.SendNewFirm(ConfigurationHelper.GetAppSetting(ConfigurationHelper.AppSettingKeys.ToAdmin), Name, FirmUserName, FirmUserSurname);
                    }

                    errSave.Visible = !(SavedFirmId > 0);
                    pnlForm.Visible = !errSave.Visible;

                    if (fuLogo.FileName != "")
                    {
                        errLogo.Visible = !(LogoUpload(SavedFirmId));
                        if (!errDelLogo.Visible) SetLogo();
                    }
                }
                else
                    errHasUser.Visible = HasUser;
            }
        }

        protected bool LogoUpload(int FirmId) {
            if ((fuLogo.HasFile) && (fuLogo.PostedFile != null))
            {                
                int MaxKBSize = int.Parse(ConfigurationHelper.GetAppSetting(ConfigurationHelper.AppSettingKeys.ImgUploadMaxKB));
                int FileSize = fuLogo.PostedFile.ContentLength;

                if ((FileSize <= 0) || (FileSize > MaxKBSize)) return false;

                try
                {
                    string SavePath = ConfigurationHelper.GetAppSetting(ConfigurationHelper.AppSettingKeys.ImgPathRoot) + ConfigurationHelper.GetAppSetting(ConfigurationHelper.AppSettingKeys.ImgPathCompany);
                    string LogoName = UrlHelper.ImgUrl.ImgNameKey + FirmId.ToString();

                    string SaveFullName = SavePath + UrlHelper.ImgUrl.ImgSizes.Original + "/" + LogoName + ".jpg";

                    fuLogo.PostedFile.SaveAs(Request.MapPath(SaveFullName));

                    ImageHelper ImgHelper = new ImageHelper();

                    string PhotoSource = SaveFullName;
                    SaveFullName = SavePath + UrlHelper.ImgUrl.ImgSizes.Default + "/" + LogoName + ".jpg";
                    ImgHelper.Resize(Request.MapPath(PhotoSource), Request.MapPath(SaveFullName), (int)UrlHelper.ImgUrl.ImgFirmLogoSizes.DefaultW);

                    PhotoSource = SaveFullName;
                    SaveFullName = SavePath + UrlHelper.ImgUrl.ImgSizes.Thumb + "/" + LogoName + ".jpg";
                    ImgHelper.Resize(Request.MapPath(PhotoSource), Request.MapPath(SaveFullName), (int)UrlHelper.ImgUrl.ImgFirmLogoSizes.ThumbW);

                    return true;
                }
                catch (Exception)
                { return false; }
            }
            return false;
        }
    }
}