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

namespace GSUKariyer.WEB.UserControls.Master
{
    public partial class uLoginArea : BaseUserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ArrangeForm();                
            }
            BindForm();
        }

        #region ArrangeForm & BindForm

        protected void BindForm()
        {
            pnlLoginOn.Visible = this.SessionManager.IsLoggedIn || this.SessionManager.IsFirmLoggedIn;
            pnlLoginOff.Visible = !pnlLoginOn.Visible;

            if (pnlLoginOn.Visible) {

                string Name = "";
                string LoginTime = this.SessionManager.LoginTime.ToShortTimeString();

                if (this.SessionManager.IsLoggedIn) {                    
                    Name = this.SessionManager.Name + " " + this.SessionManager.Surname;

                    ltlInfo.Text = this.SessionManager.StudentNumber;
                    ltlApplicationCount.Text = this.SessionManager.ApplicationCount.ToString();
                    ltlUnreadAnswerCount.Text = this.SessionManager.UnreadAnswerCount.ToString();

                    img.ImageUrl = UrlHelper.ImgUrl.ImgUrlUser(this.SessionManager.UserId.Value, UrlHelper.ImgUrl.ImgSizes.Square);
                    img.Visible = img.ImageUrl != "";
                }
                else if (this.SessionManager.IsFirmLoggedIn) {
                    ltlInfo.Visible = false;                    
                    hlApplications.Visible = false;
                    hlFirmApplications.Visible = true;

                    Name = this.SessionManager.FirmName;
                    ltlFirmApplicationCount.Text = this.SessionManager.FirmApplicationCount.ToString();

                    hlFirmApplications.NavigateUrl = UrlHelper.PageUrl.FirmApplications();
                    img.ImageUrl = UrlHelper.ImgUrl.ImgUrlCompany(this.SessionManager.FirmId, UrlHelper.ImgUrl.ImgSizes.Thumb);
                    img.Visible = img.ImageUrl.Length > 0;
                }

                ltlName.Text = Name;
                ltlLoginTime.Text = LoginTime;
            }
        }
        protected void ArrangeForm()
        {
            hlNewUser.NavigateUrl = UrlHelper.PageUrl.Signup();
            hlFirmLogin.NavigateUrl = UrlHelper.PageUrl.FirmLogin();
            hlApplications.NavigateUrl = UrlHelper.PageUrl.UserMessages();
        }

        #endregion

        protected void lnkLogOut_Click(object sender, EventArgs e)
        {
            this.SessionManager.KillAllSessions();
            Response.Redirect(UrlHelper.PageUrl.Default());
        }
    }
}