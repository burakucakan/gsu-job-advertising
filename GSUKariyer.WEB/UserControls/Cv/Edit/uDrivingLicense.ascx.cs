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
    public partial class uDrivingLicense : BaseCvEditUserControl
    {
        #region Properties
        public override int ControlOrder
        {
            get
            {
                return CVs.Forms.ControlOrders.DrivingLicense;
            }
        }
        public bool HasDrivingLicense
        {
            get { 
                return rblDrivingLicense.SelectedValue.ToBool(false);
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
            rblDrivingLicense.DataSource = CVs.DrivingLicenseInfo.GetData();
            rblDrivingLicense.DataTextField = SiteParams.ColumnNames.Description;
            rblDrivingLicense.DataValueField = SiteParams.ColumnNames.Value;
            rblDrivingLicense.DataBind();

            rblDrivingLicense.SelectedIndex = 0;
        }
        #endregion

        #region ButtonEvents
        protected void imgBtnSend_Click(object sender, ImageClickEventArgs e)
        {
            if (!IsNewCV)
                CVs.DrivingLicenseInfo.Update(CVId.Value,HasDrivingLicense,DateTime.Now);

            Submit();
        }
        #endregion

        public void Bind(DataTable dt)
        {
            if (dt.Rows.Count > 0)
                rblDrivingLicense.SelectedValue = DBNullHelper.GetNullableValue<bool>(dt.Rows[0][CVs.ColumnNames.HasDrivingLicense]).ToString();
            else
                ThrowNoDataException("Bind");
        }
    }
}