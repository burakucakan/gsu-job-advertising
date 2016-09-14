using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GSUKariyer.COMMON.Helpers.WEB;
using GSUKariyer.BUS;
using System.Data;
using GSUKariyer.COMMON;
using System.IO;

namespace GSUKariyer.WEB.UserControls.Cv.Edit
{
    public partial class uMyPhoto : BaseCvEditUserControl
    {
        #region Properties
        public override int ControlOrder
        {
            get
            {
                return CVs.Forms.ControlOrders.Photo;
            }
        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            errUpload.Visible = false;
            succDel.Visible = false;
            errDel.Visible = false;
            pnlPhoto.Visible = false;

            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            ArrangeForm();
        }

        #region ArrangeForm
        protected void ArrangeForm()
        {
            imgPhoto.ImageUrl = UrlHelper.ImgUrl.ImgUrlUser(this.SessionManager.UserId.Value, GSUKariyer.COMMON.UrlHelper.ImgUrl.ImgSizes.Default);
            pnlPhoto.Visible = imgPhoto.ImageUrl.Length > 0;
        }
        #endregion

        #region ButtonEvents
        protected void imgBtnSend_Click(object sender, ImageClickEventArgs e)
        {
            if (!fuPhoto.HasFile)
                Submit();
            else {
                errUpload.Visible = !PhotoUpload();
                ArrangeForm();
            }
        }

        protected bool PhotoUpload()
        {
            if ((fuPhoto.HasFile) && (fuPhoto.PostedFile != null))
            {
                int MaxKBSize = int.Parse(ConfigurationHelper.GetAppSetting(ConfigurationHelper.AppSettingKeys.ImgUploadMaxKB));
                int FileSize = fuPhoto.PostedFile.ContentLength;

                if ((FileSize <= 0) || (FileSize > MaxKBSize)) return false;

                try
                {
                    string Ext = Util.GetExtension(fuPhoto.PostedFile.FileName);
                    string SavePath = ConfigurationHelper.GetAppSetting(ConfigurationHelper.AppSettingKeys.ImgPathRoot) + ConfigurationHelper.GetAppSetting(ConfigurationHelper.AppSettingKeys.ImgPathUsers);
                    string PhotoName = UrlHelper.ImgUrl.ImgNameKey + this.SessionManager.UserId.ToString();

                    string SaveFullName = SavePath + UrlHelper.ImgUrl.ImgSizes.Original + "/" + PhotoName + Ext;

                    fuPhoto.PostedFile.SaveAs(Request.MapPath(SaveFullName));

                    ImageHelper ImgHelper = new ImageHelper();

                    string PhotoSource = SaveFullName;
                    SaveFullName = SavePath + UrlHelper.ImgUrl.ImgSizes.Default + "/" + PhotoName + Ext;
                    ImgHelper.Resize(Request.MapPath(PhotoSource), Request.MapPath(SaveFullName), (int)UrlHelper.ImgUrl.ImgUserPhotoSizes.DefaultW);

                    PhotoSource = SaveFullName;
                    SaveFullName = SavePath + UrlHelper.ImgUrl.ImgSizes.Thumb  + "/" + PhotoName + Ext;
                    ImgHelper.Resize(Request.MapPath(PhotoSource), Request.MapPath(SaveFullName), (int)UrlHelper.ImgUrl.ImgUserPhotoSizes.Thumb);

                    PhotoSource = SaveFullName;
                    SaveFullName = SavePath + UrlHelper.ImgUrl.ImgSizes.Square + "/" + PhotoName + Ext;
                    ImgHelper.Crop(Request.MapPath(PhotoSource), Request.MapPath(SaveFullName), (int)UrlHelper.ImgUrl.ImgUserPhotoSizes.Square, (int)UrlHelper.ImgUrl.ImgUserPhotoSizes.Square);

                    return true;
                }
                catch (Exception)
                { return false; }
            }
            return false;
        }

        protected void lnkDelPhoto_Click(object sender, EventArgs e)
        {
            string imgUserPathRoot = ConfigurationHelper.GetAppSetting(ConfigurationHelper.AppSettingKeys.ImgPathRoot) + ConfigurationHelper.GetAppSetting(ConfigurationHelper.AppSettingKeys.ImgPathUsers);            
            string imgUserFileName = UrlHelper.ImgUrl.ImgNameKey + this.SessionManager.UserId.ToString() + ".jpg";

            string imgUserPath = imgUserPathRoot + UrlHelper.ImgUrl.ImgSizes.Default + "/" + imgUserFileName;

            try
            {                
                if (File.Exists(Request.MapPath(imgUserPath)))
                    File.Delete(Request.MapPath(imgUserPath));

                imgUserPath = imgUserPathRoot + UrlHelper.ImgUrl.ImgSizes.Thumb + "/" + imgUserFileName;

                if (File.Exists(Request.MapPath(imgUserPath)))
                    File.Delete(Request.MapPath(imgUserPath));

                imgUserPath = imgUserPathRoot + UrlHelper.ImgUrl.ImgSizes.Square + "/" + imgUserFileName;

                if (File.Exists(Request.MapPath(imgUserPath)))
                    File.Delete(Request.MapPath(imgUserPath));

                succDel.Visible = true;
            }
            catch (Exception)
            {
                errDel.Visible = true;
            }
        }

        #endregion
    }
}