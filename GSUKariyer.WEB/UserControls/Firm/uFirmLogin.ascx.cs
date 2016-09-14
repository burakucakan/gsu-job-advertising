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
using GSUKariyer.COMMON.Helpers.WEB;

namespace GSUKariyer.WEB.UserControls.Firm
{
    public partial class uFirmLogin : BaseUserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if ((this.SessionManager.IsLoggedIn) || (this.SessionManager.IsFirmLoggedIn))
                    Go(UrlHelper.PageUrl.Default());

                hlFirmSignUp.NavigateUrl = Go(PageName.FirmSignup);
                hlForgotPassword.NavigateUrl = "javascript:Show('" + FirmForgotPass.ClientID + "')";
            }
        }

        protected void imgBtnLogin_Click(object sender, ImageClickEventArgs e)
        {
            if (this.SessionManager.IsLoggedIn)
                this.SessionManager.KillAllSessions();

            string Email = Util.r(txtEmail.Text.Trim());
            string Password = Encryption.Encrypt(Util.r(txtPassword.Text.Trim()));

            DataTable dtUser = BUS.Firms.Login(Email, Password);

            this.SessionManager.IsFirmLoggedIn = dtUser.Rows.Count > 0;
            if (this.SessionManager.IsFirmLoggedIn)
            {
                this.SessionManager.FirmId = dtUser.Rows[0]["FirmId"].ToInt();
                this.SessionManager.FirmEmail = dtUser.Rows[0]["Email"].ToString();
                this.SessionManager.FirmName = dtUser.Rows[0]["FirmName"].ToString();
                this.SessionManager.FirmApplicationCount = dtUser.Rows[0]["ApplicationCount"].ToInt();

                Response.Redirect(UrlHelper.PageUrl.Firm());
            }
            else
                errLogin.Visible = true;

        }

        protected void imgBtnForgotPassSend_Click(object sender, ImageClickEventArgs e)
        {
            string Email = Util.r(txtEmail.Text.Trim());
            DataTable dtFirmUser = BUS.FirmUsers.GetFirmByEmail(Email);

            errHasFirms.Visible = dtFirmUser.Rows.Count == 0;
            if (!errHasFirms.Visible)
            {
                string Password = Encryption.Decrypt(dtFirmUser.Rows[0]["Password"].ToString());
                Mail objMail = new Mail();
                succPassword.Visible = objMail.SendPassword(Email, Password);
                errPassword.Visible = !succPassword.Visible;
            }
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            //txtEmail.Text = "burak@burak.com";
            //txtPassword.Text = "burak";
            //imgBtnLogin_Click(null, null);
        }
        
    }
}