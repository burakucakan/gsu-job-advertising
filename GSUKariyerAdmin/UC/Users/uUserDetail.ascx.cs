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
using GSUKariyer.BUS;
using GSUKariyer.COMMON;

public partial class UC_Firms_uUserDetail : BaseUserControl
{

    #region Properties
    public int? UserId { 
        get {
            int userId;
            if (int.TryParse(Request.QueryString["j"].ToString(), out userId))
                return userId;
            return null; 
        }
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

    #region ArrangeForm/BindForm Functions
    protected void ArrangeForm()
    {
        if (!UserId.HasValue)
            RedirectToList();

        ddlIsActive.Items.Add(new ListItem("Aktif",true.ToString()));
        ddlIsActive.Items.Add(new ListItem("Pasif", false.ToString()));
    }
    protected void BindForm()
    {
        DataTable dtUser = Users.Generated.Get(UserId.Value);

        if (dtUser.Rows.Count > 0)
        {
            DataRow dr = dtUser.Rows[0];

            string imageUrl=UrlHelper.ImgUrl.ImgUrlUser(UserId.Value, UrlHelper.ImgUrl.ImgSizes.Square,false);

            if (UrlHelper.ImgUrl.CheckImgExist(imageUrl))
            {
                imgUser.Visible = true;
                imgUser.ImageUrl = UrlHelper.ImgUrl.ArrangeImgUrlFromAdmin(imageUrl);                
            }
            else
            {
                imgUser.Visible = false;
            }

            bool isActive = DBNullHelper.GetNullableValue<bool>(dr[Users.ColumnNames.IsActive]) ?? false;
            ddlIsActive.SelectedValue = isActive.ToString();
            btnSendActivation.Visible = !isActive;

            txtEmail.Text = dr[Users.ColumnNames.Email].ToString();
            ltlActivationDate.Text = FormatHelper.ReplaceNoDataWithDash(
                dr[Users.ColumnNames.ActivationDate].ToString());
            ltlAddress.Text = FormatHelper.ReplaceNoDataWithDash(
                dr[Users.ColumnNames.Address].ToString());
            ltlBirthDate.Text = DBNullHelper.GetNullableValue<DateTime>(dr[Users.ColumnNames.Birthdate]).Value.ToShortDateString();
            ltlCity.Text = SiteParams.GetParamValueFromDB(SiteParams.ParamGroup.TurkeyCities, dr[Users.ColumnNames.City].ToString());
            ltlCountry.Text = SiteParams.GetParamValueFromDB(SiteParams.ParamGroup.Countries, dr[Users.ColumnNames.Country].ToString());
            ltlCreateDate.Text = DBNullHelper.GetNullableValue<DateTime>(dr[Users.ColumnNames.CreateDate]).Value.ToShortDateString();
            ltlGender.Text = SiteParams.GetParamValueFromDB(SiteParams.ParamGroup.Gender, dr[Users.ColumnNames.Gender].ToString());
            ltlName.Text = dr[Users.ColumnNames.Name].ToString();
            ltlNationality.Text = SiteParams.GetParamValueFromDB(SiteParams.ParamGroup.Countries, dr[Users.ColumnNames.Country].ToString());
            ltlStudentNumber.Text = dr[Users.ColumnNames.StudentNumber].ToString();
            ltlSurName.Text = dr[Users.ColumnNames.Surname].ToString();

        }
        else
            RedirectToList();
    }
    #endregion

    #region Button Events
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (Users.Update(UserId.Value, txtEmail.Text.ToString(), bool.Parse(ddlIsActive.SelectedValue)))
        {
            Success1.Desc = "Kullanıcı bilgileri güncellendi.";
            Success1.Visible = true;
            BindForm();
        }
        else
        {
            Error1.Desc = "Kullanıcı bilgileri güncellenirken hata oluştu!";
            Error1.Visible = true;
        }
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        if (Users.CustomDelete(UserId.Value) > 0)
        {
            Success1.Desc = "Kullanıcı bilgileri başarıyla silindi.";
            Success1.Visible = true;
            RedirectToList();
        }
        else
        {
            Error1.Desc = "Kullanıcı bilgileri silinirken hata oluştu.";
            Error1.Visible = true;
        }
    }
    protected void btnSendActivation_Click(object sender, EventArgs e)
    {
        string ActivationCode = AppUtil.genActivatonCode();

        if (Users.Update(UserId.Value ,ActivationCode,DateTime.Now))
        {
            Mail objMail = new Mail(Config(EnumUtil.Config.MailTempletePath), Config(EnumUtil.Config.MailMain),
                Config(EnumUtil.Config.ApplicationUrl));
            if (objMail.SendActivate(txtEmail.Text.Trim(), ActivationCode))
            {
                Success1.Desc = "Aktivasyon maili başarıyla yollandı. ";
                Success1.Visible = true;
                BindForm();
            }
            else
            {
                Error1.Desc = "Aktivasyon maili yollanırken hata oluştu.";
                Error1.Visible = true;
            }
        }
    }
    #endregion

    protected void RedirectToList()
    {
        Response.Redirect("UserManagement.aspx");
    }


}
