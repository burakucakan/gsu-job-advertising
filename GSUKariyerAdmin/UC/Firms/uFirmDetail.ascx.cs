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
using GSUKariyer.COMMON;
using GSUKariyer.BUS;

public partial class UC_Firms_uFirmDetail : BaseUserControl
{
    public int FirmId { get { return int.Parse(hdFirmId.Value); } set { hdFirmId.Value = value.ToString(); } }
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Util.IsNumeric(Request.QueryString["j"]))
                this.FirmId = int.Parse(Request.QueryString["j"]);
            else
                this.goDefault();

            BindData();
        }
    }

    protected void BindData() {
        DataTable dtFirmDetail = Firms.Generated.Get(this.FirmId);
        DataTable dtFirmUser = FirmUsers.GetFirmUser(this.FirmId);

        DataRow drFirmDetail = dtFirmDetail.Rows[0];
        DataRow drFirmUser = dtFirmUser.Rows[0];

        imgLogo.ImageUrl = UrlHelper.ImgUrl.ImgUrlCompany(this.FirmId, UrlHelper.ImgUrl.ImgSizes.Default);
        imgLogo.Visible = imgLogo.ImageUrl.Length > 0;
        ltlName.Text = drFirmDetail[Firms.ColumnNames.Name].ToString();
        ltlSector.Text = AdminSiteParams.GetSectorDescription(
            drFirmDetail[Firms.ColumnNames.Sector].ToString());

        int? workerCount = drFirmDetail[Firms.ColumnNames.WorkerCount].ToNullableInt();
        if (workerCount.HasValue)
            ltlWorkerCount.Text = AdminSiteParams.GetWorkerCountDescription(workerCount.Value);
        else
            ltlWorkerCount.Text = "-";

        ltlAddress.Text = Util.Nl2Br(drFirmDetail[Firms.ColumnNames.Address].ToString());
        ltlZipCode.Text = drFirmDetail[Firms.ColumnNames.Zipcode].ToString();
        ltlCountry.Text = AdminSiteParams.CityCountry.GetCountryDescription( drFirmDetail[Firms.ColumnNames.Country].ToInt());
        ltlCity.Text = AdminSiteParams.CityCountry.GetCityDescription( 
            drFirmDetail[Firms.ColumnNames.City].ToInt());
        ltlDescription.Text = drFirmDetail[Firms.ColumnNames.Description].ToString();
        hlWebPage.Text = drFirmDetail[Firms.ColumnNames.Webpage].ToString();
        hlWebPage.NavigateUrl = Util.FormatWebPage(hlWebPage.Text);
        ltlCreateDate.Text = drFirmDetail[Firms.ColumnNames.CreateDate].ToDateTime().ToShortDateString();

        ltlFirmUserName.Text = drFirmUser[FirmUsers.ColumnNames.Name].ToString();
        ltlFirmUserSurname.Text = drFirmUser[FirmUsers.ColumnNames.Surname].ToString();
        ltlFirmUserPosition.Text = drFirmUser[FirmUsers.ColumnNames.Position].ToString();
        ltlFirmUserPhone.Text = drFirmUser[FirmUsers.ColumnNames.Phone].ToString();
        ltlFirmUserFax.Text = drFirmUser[FirmUsers.ColumnNames.Fax].ToString();
        ltlFirmUserEmail.Text = drFirmUser[FirmUsers.ColumnNames.Email].ToString();
        ltlFirmUserPassword.Text = Encryption.Decrypt(drFirmUser[FirmUsers.ColumnNames.Password].ToString());

        btnApprove.Visible = !Convert.ToBoolean(drFirmDetail[Firms.ColumnNames.IsActive]);
    }

    protected void btnApprove_Click(object sender, EventArgs e)
    {
        if (Firms.Active(hdFirmId.Value.ToInt()))
        {
            string Email = ltlFirmUserEmail.Text;
            Mail objMail = new Mail();
            objMail.SendFirmActivated(Email);
            uSuccess1.Visible = true;
            btnApprove.Visible = false;
        }
        else
            uSuccess1.Visible = false;

        uError1.Visible = !uSuccess1.Visible;
    }
}
