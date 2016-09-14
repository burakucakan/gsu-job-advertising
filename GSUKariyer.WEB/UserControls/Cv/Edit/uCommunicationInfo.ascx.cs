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

namespace GSUKariyer.WEB.UserControls.Cv.Edit
{
    public partial class uCommunicationInfo : BaseCvEditUserControl
    {
        #region Properties
        public override int ControlOrder
        {
            get
            {
                return CVs.Forms.ControlOrders.ContactInfoForm;
            }
        }
        public string HomePhoneNumber
        {
            get { return uHomePhoneNumber.Value; }
        }
        public string MobileNumber1
        {
            get { return uMobileNumber1.Value; }
        }
        public string MobileNumber2
        {
            get { return uMobileNumber2.Value; }
        }
        public string Webpage
        {
            get { return txtWebpage.Text; }
        }
        public string Email
        {
            get { return txtEmail.Text; }
        }
        public int? ContactType
        {
            get { return uContactTypes1.SelectedValue.ToNullableInt(); }
        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ArrangeForm();
            }
        }

        #region ArrangeForm
        protected void ArrangeForm()
        {
                    
        }
        #endregion

        #region ButtonEvents
        protected void imgBtnSend_Click(object sender, ImageClickEventArgs e)
        {
            if (!IsNewCV)
                CVs.CommunicationInfo.Update(CVId.Value,HomePhoneNumber,MobileNumber1,MobileNumber2,Email,Webpage,ContactType.Value,DateTime.Now);

            Submit();
        }
        #endregion

        public void Bind(DataTable dt)
        {
            if (dt.Rows.Count>0)
            {
                DataRow dr=dt.Rows[0];

                uHomePhoneNumber.Value = dr[CVs.ColumnNames.HomePhone].ToString();
                uMobileNumber1.Value = dr[CVs.ColumnNames.MobilePhone1].ToString();
                uMobileNumber2.Value = dr[CVs.ColumnNames.MobilePhone2].ToString();
                txtWebpage.Text = dr[CVs.ColumnNames.Webpage].ToString();
                txtEmail.Text = dr[CVs.ColumnNames.Email].ToString();
                uContactTypes1.SelectedValue = dr[CVs.ColumnNames.ContactType].ToString();              
            }else
                ThrowNoDataException("Bind");
        }
    }
}