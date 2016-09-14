using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GSUKariyer.COMMON.Helpers.WEB;
using GSUKariyer.COMMON;
using GSUKariyer.BUS;
using System.Data;

namespace GSUKariyer.WEB.UserControls.Cv.Edit
{
    public partial class uEducationState : BaseCvEditUserControl
    {
        #region Properties
        public override int ControlOrder
        {
            get
            {
                return CVs.Forms.ControlOrders.EducationState;
            }
        }
        public int State
        {
            get { return rblEducationState.SelectedValue.ToInt();}
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
            rblEducationState.DataSource = SiteParams.GetEducationStates();
            rblEducationState.DataTextField = SiteParams.ColumnNames.Description;
            rblEducationState.DataValueField = SiteParams.ColumnNames.Value;
            rblEducationState.DataBind();

            rblEducationState.SelectedIndex = 0;
        }
        #endregion

        #region ButtonEvents
        protected void imgBtnSend_Click(object sender, ImageClickEventArgs e)
        {
            if (!IsNewCV)
                CVs.EducationInfo.State.Update(CVId.Value,State,DateTime.Now);

            Submit();
        }
        #endregion

        public void Bind(DataTable dt)
        {
            if (dt.Rows.Count > 0)
                rblEducationState.SelectedValue = dt.Rows[0][CVs.ColumnNames.EducationState].ToString();
            else
                ThrowNoDataException("Bind");
        }
    }
}