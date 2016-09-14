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
using GSUKariyer.BUS;

namespace GSUKariyer.WEB.UserControls.Cv.Edit
{
    public partial class uWelcome : BaseCvEditUserControl
    {
        #region Properties
        public override int ControlOrder
        {
            get
            {
                return CVs.Forms.ControlOrders.WelcomeForm;
            }
        }
        public string CVName
        {
            get { return txtName.Text.Trim(); }
        }
        public int CVLanguage
        {
            get { return rblCvLanguages.SelectedValue.ToInt(); }
        }
        //public bool IsDefault
        //{
        //    get { return rblIsDefault.SelectedValue.ToBool(true); }
        //}
        public bool IsDefaultOldValue
        {
            get { return (ViewState["IDOV"]==null?false: (bool)ViewState["IDOV"]);}
            protected set {ViewState.Add("IDOV",value);}
        }
        #endregion

        bool isArranged = false;
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
            if (isArranged)
                return;

            rblCvLanguages.DataSource = CVs.Languages.Options.Get();
            rblCvLanguages.DataTextField = CVs.Languages.Options.ColumnNames.Desc;
            rblCvLanguages.DataValueField = CVs.Languages.Options.ColumnNames.Value;
            rblCvLanguages.DataBind();

            rblCvLanguages.SelectedValue = CVs.Languages.Options.Turkish;

            //rblIsDefault.DataSource = FormatHelper.BoolFunc.GetTrueFalse();
            //rblIsDefault.DataTextField = FormatHelper.BoolFunc.ColumnNames.Description;
            //rblIsDefault.DataValueField = FormatHelper.BoolFunc.ColumnNames.Value;
            //rblIsDefault.DataBind();

            DataTable dtCvs = Users.Cv.Get(SessionManager.UserId.Value);
            if (CVId.HasValue)
                dtCvs.DefaultView.RowFilter = String.Format("{0}<>{1}",CVs.ColumnNames.ID,
                    CVId.Value.ToString());

            //rblIsDefault.Enabled = (dtCvs.DefaultView.Count > 0);

            isArranged = true;
        }
        #endregion

        #region ButtonEvents
        protected void imgBtnSend_Click(object sender, ImageClickEventArgs e)
        {
            if (!IsNewCV)
                CVs.GeneralInfo.Update(CVId.Value,CVName,CVLanguage,DateTime.Now);

            Submit();
        }
        #endregion

        public void Bind(DataTable dt)
        {
            if (dt.Rows.Count > 0)
            {
                if (!isArranged)
                    ArrangeForm();
                    

                DataRow dr = dt.Rows[0];

                rblCvLanguages.SelectedValue = dr[CVs.ColumnNames.CvLanguage].ToString();
                txtName.Text = dr[CVs.ColumnNames.Name].ToString();
                //rblIsDefault.SelectedValue = dr[CVs.ColumnNames.IsDefault].ToNullableBool().ToString();
            }
            else
                ThrowNoDataException("Bind");
        }
    }
}