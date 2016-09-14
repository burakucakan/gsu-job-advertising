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
    public partial class uSendCv : BaseUserControl
    {        
        public int FirmId
        {
            get { return (ViewState["FirmId"] == null ? -1 : int.Parse(ViewState["FirmId"].ToString())); }
            set { ViewState["FirmId"] = value; }
        }

        public string FirmMail
        {
            get { return (ViewState["FirmMail"] == null ? "" : ViewState["FirmMail"].ToString()); }
            set { ViewState["FirmMail"] = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void imgBtnSendCv_Click(object sender, ImageClickEventArgs e)
        {
            imgBtnSendCv.Visible = false;
            SendCv();
        }

        protected void SendCv()
        {
            int UserId = (int)this.SessionManager.UserId;
            int CvId = 0;
            string cvURL = "";

            DataTable dtDefaultCv = BUS.CVs.GetDefaultCv(UserId);
            if (dtDefaultCv.Rows.Count < 1)
                errNoCv.Visible = true;
            else
            {
                CvId = Convert.ToInt32(dtDefaultCv.Rows[0][BUS.CVs.ColumnNames.ID]);

                if (this.FirmMail == "")
                    this.FirmMail = BUS.FirmUsers.GetFirmUser(this.FirmId).Rows[0][BUS.FirmUsers.ColumnNames.Email].ToString();

                cvURL = UrlHelper.PageUrl.SendCv(CvId, this.SessionManager.Name, this.SessionManager.Surname);

                Mail objMail = new Mail();
                succSendCv.Visible = objMail.SendCv(this.FirmMail, this.SessionManager.Name, this.SessionManager.Surname, cvURL);

                errSendCv.Visible = !succSendCv.Visible;

                if (succSendCv.Visible)
                    try
                    { BUS.SentCvs.Generated.Add(UserId, CvId, FirmId, DateTime.Now); }
                    catch (Exception)
                    { }
            }
        }
    }
}