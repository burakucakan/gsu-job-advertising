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
    public partial class uCVState : BaseCvEditUserControl
    {
        #region Properties
        public override int ControlOrder
        {
            get
            {
                return CVs.Forms.ControlOrders.CVState;
            }
        }
        public int State
        {
            get { return rblCvState.SelectedValue.ToInt(); }
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
            rblCvState.DataSource = SiteParams.GetCVStates();
            rblCvState.DataTextField = SiteParams.ColumnNames.Description;
            rblCvState.DataValueField = SiteParams.ColumnNames.Value;
            rblCvState.DataBind();

            rblCvState.SelectedIndex = 0;
        }
        #endregion

        #region ButtonEvents
        protected void imgBtnSend_Click(object sender, ImageClickEventArgs e)
        {
            if (!IsNewCV)
                CVs.CVState.Update(CVId.Value, rblCvState.SelectedValue.ToInt(),DateTime.Now);

            Submit();
        }
        #endregion

        public void Bind(DataTable dt)
        {
            if (dt.Rows.Count > 0)
                rblCvState.SelectedValue = dt.Rows[0][CVs.ColumnNames.CVState].ToString();
            else
                ThrowNoDataException("Bind");
        }
    }
}