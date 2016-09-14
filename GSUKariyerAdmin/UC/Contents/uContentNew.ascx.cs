using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using GSUKariyer.BUS;
using GSUKariyer.COMMON;

public partial class UC_News_uNewsNew : BaseUserControl
{
    public int _ID
    {
        get { return (ViewState["_ID"] == null ? 0 : int.Parse(ViewState["_ID"].ToString())); }
        set { ViewState["_ID"] = value; }
    }

    public GSUKariyer.BUS.SiteContents.Type _Type
    {
        get { return (ViewState["_Type"] == null ? GSUKariyer.BUS.SiteContents.Type.Announcements : (GSUKariyer.BUS.SiteContents.Type)(Convert.ToInt32(ViewState["_Type"]))); }
        set { ViewState["_Type"] = (int)value; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            SetType();

            if (GSUKariyer.COMMON.Util.IsNumeric(Request.QueryString["j"]))
            {
                this._ID = Convert.ToInt32(Request.QueryString["j"]);
                FillData();
            }
        }
    }

    private void SetType()
    {
        switch (this._Type)
        {
            case SiteContents.Type.Announcements:
                ltlTitleAnnouncement.Visible = true;
                break;

            case SiteContents.Type.Interview:
                ltlTitleInterview.Visible = true;
                break;

            case SiteContents.Type.SuccessStories:
                ltlTitleSuccessStory.Visible = true;
                break;

            case SiteContents.Type.Articles:
                ltlTitleArticle.Visible = true;
                break;
        }
    }

    protected void FillData()
    {
        DataTable dt = GSUKariyer.BUS.SiteContents.Generated.Get(this._ID);
        if (dt.Rows.Count > 0)
        {
            txtTitle.Text = dt.Rows[0]["Title"].ToString();
            txtShortContent.Text = dt.Rows[0]["ShortContent"].ToString();
            txtContentDetail.Content = dt.Rows[0]["Content"].ToString();
            txtAuthor.Text = dt.Rows[0]["Author"].ToString();

            rqPhoto.Visible = false;
        }
    }

    protected bool PhotoUpload(int ID)
    {
        if ((fuPhoto.HasFile) && (fuPhoto.PostedFile != null))
        {
            int MaxKBSize = int.Parse(ConfigurationHelper.GetAppSetting(ConfigurationHelper.AppSettingKeysAdmin.MaxKB));
            int FileSize = fuPhoto.PostedFile.ContentLength;

            if ((FileSize <= 0) || (FileSize > MaxKBSize)) return false;

            try
            {                
                string SavePath = ConfigurationHelper.GetAppSetting(ConfigurationHelper.AppSettingKeysAdmin.PhysicalLivePath) + ConfigurationHelper.GetAppSetting(ConfigurationHelper.AppSettingKeysAdmin.PhysicalImgPathRoot);
                SavePath += ConfigurationHelper.GetAppSetting(ConfigurationHelper.AppSettingKeysAdmin.ImgFolderCarrerPlaning + "\\");
                SavePath += this._Type.ToString() + "\\";

                string PhotoName = UrlHelper.ImgUrl.ImgNameKey + ID.ToString();

                string SaveFullName = SavePath + UrlHelper.ImgUrl.ImgSizes.Original + "\\" + PhotoName + ".jpg";

                fuPhoto.PostedFile.SaveAs(SaveFullName);

                ImageHelper ImgHelper = new ImageHelper();

                string PhotoSource = SaveFullName;
                SaveFullName = SavePath + UrlHelper.ImgUrl.ImgSizes.Default + "\\" + PhotoName + ".jpg";
                ImgHelper.Resize(PhotoSource, SaveFullName, (int)UrlHelper.ImgUrl.ImgCareerPlaningSizes.DefaultW);

                PhotoSource = SaveFullName;
                SaveFullName = SavePath + UrlHelper.ImgUrl.ImgSizes.Thumb + "\\" + PhotoName + ".jpg";
                ImgHelper.Resize(PhotoSource, SaveFullName, (int)UrlHelper.ImgUrl.ImgCareerPlaningSizes.ThumbW);

                return true;
            }
            catch (Exception)
            { return false; }
        }
        return false;
    }

    protected void btnSend_Click(object sender, EventArgs e)
    {
        if (this._ID < 1)
        {
            int returnID = GSUKariyer.BUS.SiteContents.Generated.Add((int)this._Type, txtTitle.Text, txtShortContent.Text, txtContentDetail.Content, "", txtAuthor.Text, DateTime.Now, DateTime.Now);

            if (returnID > 0)
            {
                if (fuPhoto.FileName != "")
                    PhotoUpload(returnID);

                uSuccess1.Visible = true;
            }
        }
        else {

            if (fuPhoto.FileName != "")
                PhotoUpload(this._ID);

            GSUKariyer.BUS.SiteContents.Generated.Update(this._ID, (int)this._Type, txtTitle.Text, txtShortContent.Text, txtContentDetail.Content, "", txtAuthor.Text, DateTime.Now);

            uSuccess1.Visible = true;

        }

        uError1.Visible = !uSuccess1.Visible;
        pnlForm.Visible = !uSuccess1.Visible;
    }
}
