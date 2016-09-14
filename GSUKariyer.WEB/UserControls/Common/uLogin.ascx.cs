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

namespace GSUKariyer.WEB.UserControls.Common
{
    public partial class uLogin : BaseUserControl
    {
        public string TargetControlID
        {
            set { MPE.TargetControlID = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            PostReset();
        }

        protected void PostReset()
        {
            succPassword.Visible = false;
            errPassword.Visible = false;
            errHasUser.Visible = false;
            Error.Visible = false;
        }

        protected void imgBtnSend_Click(object sender, ImageClickEventArgs e)
        {
            if (this.SessionManager.IsFirmLoggedIn)
                this.SessionManager.KillAllSessions();

            string StudentNumber = Util.r(txtStudentNumber.Text.Trim());
            string Password = Encryption.Encrypt(Util.r(txtPassword.Text.Trim()));
            DataTable dtUser = BUS.Users.UserLogin(StudentNumber, Password);

            this.SessionManager.IsLoggedIn = dtUser.Rows.Count > 0;
            if (this.SessionManager.IsLoggedIn)
            {
                this.SessionManager.UserId = Convert.ToInt32(dtUser.Rows[0]["ID"]);
                this.SessionManager.NationalId = dtUser.Rows[0]["NationalId"].ToString();
                this.SessionManager.Email = dtUser.Rows[0]["Email"].ToString();
                this.SessionManager.Name = dtUser.Rows[0]["Name"].ToString();
                this.SessionManager.Surname = dtUser.Rows[0]["Surname"].ToString();
                this.SessionManager.StudentNumber = dtUser.Rows[0]["StudentNumber"].ToString();
                this.SessionManager.ApplicationCount = Convert.ToInt32(dtUser.Rows[0]["ApplicationCount"]);
                this.SessionManager.UnreadAnswerCount = Convert.ToInt32(dtUser.Rows[0]["UnreadAnswerCount"]);

                string qoRedirectURL = "";
                if (Request.Url.ToString().IndexOf(UrlHelper.PageUrl.PageName.AdvertisementDetail) != -1)
                    qoRedirectURL = Request.Url.ToString();
                else
                    qoRedirectURL = UrlHelper.PageUrl.Student();
                
                Response.Redirect(qoRedirectURL);
            }
            else
                Error.Visible = true;
        }

        protected void imgBtnSendPassword_Click(object sender, ImageClickEventArgs e)
        {
            string StudentNumber = Util.r(txtForgotPassStudentNumber.Text.Trim());
            DataTable dtUser = BUS.Users.GetUserByStudentNumber(StudentNumber);

            errHasUser.Visible = dtUser.Rows.Count == 0;
            if (!errHasUser.Visible)
            {
                string Email = dtUser.Rows[0]["Email"].ToString();
                string Password = Encryption.Decrypt(dtUser.Rows[0]["Password"].ToString());
                Mail objMail = new Mail();
                succPassword.Visible = objMail.SendPassword(Email, Password);
                errPassword.Visible = !succPassword.Visible;
            }
        }

        protected void LoginInit(object sender, EventArgs e)
        {
            PostReset();
            pnlLogin.Visible = true;
            pnlForgotPass.Visible = false;
        }

        protected void PanelChange(object sender, EventArgs e)
        {
            PostReset();
            pnlLogin.Visible = !pnlLogin.Visible;
            pnlForgotPass.Visible = !pnlLogin.Visible;
        }

    }
}