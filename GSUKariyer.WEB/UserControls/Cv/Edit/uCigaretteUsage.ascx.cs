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

namespace GSUKariyer.WEB.UserControls.Cv.Edit
{
    public partial class uCigaretteUsage : BaseCvEditUserControl
    {
        #region Properties
        public override int ControlOrder
        {
            get
            {
                return CVs.Forms.ControlOrders.CigaretteUsage;
            }
        }
        public int CigaretteUseType
        {
            get
            {
                return rblCigaretteUsage.SelectedValue.ToInt();
            }
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
            rblCigaretteUsage.DataSource = SiteParams.GetCigaretteUseTypes();
            rblCigaretteUsage.DataTextField = SiteParams.ColumnNames.Description;
            rblCigaretteUsage.DataValueField = SiteParams.ColumnNames.Value;
            rblCigaretteUsage.DataBind();

            rblCigaretteUsage.SelectedIndex=0;
        }
        #endregion

        #region ButtonEvents
        protected void imgBtnSend_Click(object sender, ImageClickEventArgs e)
        {
            if (!IsNewCV)
                CVs.CigaretteUsageInfo.Update(CVId.Value,CigaretteUseType,DateTime.Now);
            Submit();
        }
        #endregion

        public void Bind(DataTable dt)
        {
            if (dt.Rows.Count > 0)
                rblCigaretteUsage.SelectedValue = dt.Rows[0][CVs.ColumnNames.CigaretteUseType].ToString();
            else
                ThrowNoDataException("Bind");
        }
    }
}