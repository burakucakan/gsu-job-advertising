using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GSUKariyer.COMMON.Helpers.WEB;
using GSUKariyer.BUS;
using GSUKariyer.COMMON;
using System.Data;
using GSUKariyer.WEB.UserControls.Common.HelperControls;

namespace GSUKariyer.WEB.UserControls.Cv.Edit
{
    public partial class uCertificateInfo : BaseCvEditUserControl
    {
        #region ConstValues
        protected struct RepeaterControls
        {
            public const string uCertificateItem = "uCertificateItem";
            public const string hfId = "hfId";
            public const string hfCerticateDate = "hfCerticateDate";
            public const string hfCertificateCategory = "hfCertificateCategory";
            public const string hfCertificateName = "hfCertificateName";
            public const string hfCertificateFirm = "hfCertificateFirm";
            public const string hfCertificateDescription = "hfCertificateDescription";
        }
        #endregion

        #region Properties
        public override int ControlOrder
        {
            get
            {
                return CVs.Forms.ControlOrders.CertificateInfo;
            }
        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack )
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
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            btnCancel.Visible = false;
            if (!String.IsNullOrEmpty(hfRepeaterIndex.Value))
            {
                ArrangeItemsEditVisibility(((uItem)rptCertificates.Items[hfRepeaterIndex.Value.ToInt()].FindControl(
                        RepeaterControls.uCertificateItem)),true);
            }
            hfRepeaterIndex.Value = String.Empty;
            ResetForm();
        }
        protected void imgBtnAdd_Click(object sender, ImageClickEventArgs e)
        {
            DataTable dt = GetData();
            DataRow dr;

            bool isEdit = false;
            if (String.IsNullOrEmpty(hfRepeaterIndex.Value))
                dr = dt.NewRow();
            else
            {
                dr = dt.Rows[hfRepeaterIndex.Value.ToInt()];
                isEdit = true;
            }

            dr[CVs.CertificateInfo.ColumnNames.CertificateDate] = DBNullHelper.ConvertValueToDBNull(uCertificateDate.SelectedValue);
            dr[CVs.CertificateInfo.ColumnNames.Category] = DBNullHelper.ConvertValueToDBNull(uCertificateTypes1.SelectedValue.ToNullableInt());
            dr[CVs.CertificateInfo.ColumnNames.Description] = txtDescription.Text.Trim();
            dr[CVs.CertificateInfo.ColumnNames.Name] = txtCertificateName.Text.Trim();
            dr[CVs.CertificateInfo.ColumnNames.TakenInstitution] = txtCertificateFirm.Text.Trim();

            if (isEdit == false) dt.Rows.Add(dr);
            Bind(dt);

            if (isEdit)
            {
                ArrangeItemsEditVisibility(
                    ((uItem)rptCertificates.Items[hfRepeaterIndex.Value.ToInt()].FindControl(
                    RepeaterControls.uCertificateItem)), true);
            }

            ResetForm();
        }
        protected void imgBtnSend_Click(object sender, ImageClickEventArgs e)
        {
            btnCancel_Click(null, null);

            if (!IsNewCV)
            {
                CVs.CertificateInfo.Update(CVId.Value,GetData());
            }

            Submit();
        }
        #endregion

        #region Others 
        public void ArrangeItemsEditVisibility(uItem control, bool isVisible)
        {
            control.IsRemove = isVisible;
            control.IsEdit = isVisible;
        }
        public DataTable GetData()
        {
            DataTable dt = CVs.CertificateInfo.CreateTable();            

            foreach (RepeaterItem rptItem in rptCertificates.Items)
            {
                DataRow dr = dt.NewRow();

                dr[CVs.CertificateInfo.ColumnNames.ID] = DBNullHelper.ConvertValueToDBNull( 
                    RepeaterHelper.GetControl<HiddenField>(
                    rptItem, RepeaterControls.hfId).Value.ToNullableInt());
                dr[CVs.CertificateInfo.ColumnNames.CertificateDate]=DBNullHelper.ConvertValueToDBNull( 
                    RepeaterHelper.GetControl<HiddenField>(
                    rptItem, RepeaterControls.hfCerticateDate).Value.ToNullableDateTime());
                dr[CVs.CertificateInfo.ColumnNames.Category] = DBNullHelper.ConvertValueToDBNull(RepeaterHelper.GetControl<HiddenField>(
                    rptItem, RepeaterControls.hfCertificateCategory).Value.ToNullableInt());
                dr[CVs.CertificateInfo.ColumnNames.Description] = DBNullHelper.ConvertValueToDBNull(
                    RepeaterHelper.GetControl<HiddenField>(
                    rptItem, RepeaterControls.hfCertificateDescription).Value);
                dr[CVs.CertificateInfo.ColumnNames.Name] = DBNullHelper.ConvertValueToDBNull( 
                    RepeaterHelper.GetControl<HiddenField>(
                    rptItem, RepeaterControls.hfCertificateName).Value);
                dr[CVs.CertificateInfo.ColumnNames.TakenInstitution] = DBNullHelper.ConvertValueToDBNull(
                    RepeaterHelper.GetControl<HiddenField>(
                    rptItem, RepeaterControls.hfCertificateFirm).Value);

                dt.Rows.Add(dr);
            }

            return dt;
        }
        protected void ResetForm()
        {
            hfRepeaterIndex.Value = String.Empty;
            btnCancel.Visible = false;

            uCertificateDate.SelectedValue = null;
            uCertificateTypes1.SelectedValue = String.Empty;
            txtDescription.Text = String.Empty;
            txtCertificateFirm.Text = String.Empty;
            txtCertificateName.Text = String.Empty;
        }
        #endregion

        public void Bind(DataTable dt)
        {
            rptCertificates.DataSource = dt;
            rptCertificates.DataBind();
        }

        #region RepeaterEvents
        protected void uCertificateItem_ItemRemove(object sender, string value, string parentControlId)
        {
            DataTable dt = GetData();
            int deletedItemIndex = ((RepeaterItem)((uItem)sender).NamingContainer).ItemIndex;

            if (!String.IsNullOrEmpty(hfRepeaterIndex.Value))
                if (deletedItemIndex < hfRepeaterIndex.Value.ToInt())
                    hfRepeaterIndex.Value = (hfRepeaterIndex.Value.ToInt() - 1).ToString();

            dt.Rows[deletedItemIndex].Delete();
            Bind(dt);
        }
        protected void uCertificateItem_ItemEdit(object sender, string value, string parentControlId)
        {
            if (!String.IsNullOrEmpty(hfRepeaterIndex.Value))
                btnCancel_Click(null, null);

            RepeaterItem rptItem =(RepeaterItem) ((uItem)sender).NamingContainer;
            hfRepeaterIndex.Value = rptItem.ItemIndex.ToString();
            ((uItem)sender).IsEdit = false;
            ((uItem)sender).IsRemove = false;

            uCertificateDate.SelectedValue=RepeaterHelper.GetControl<HiddenField>(
                    rptItem, RepeaterControls.hfCerticateDate).Value.ToNullableDateTime();
            uCertificateTypes1.SelectedValue=RepeaterHelper.GetControl<HiddenField>(
                    rptItem, RepeaterControls.hfCertificateCategory).Value;
            txtDescription.Text= RepeaterHelper.GetControl<HiddenField>(
                    rptItem, RepeaterControls.hfCertificateDescription).Value;
            txtCertificateName.Text = RepeaterHelper.GetControl<HiddenField>(
                    rptItem, RepeaterControls.hfCertificateName).Value;
            txtCertificateFirm.Text = RepeaterHelper.GetControl<HiddenField>(
                    rptItem, RepeaterControls.hfCertificateFirm).Value;

            btnCancel.Visible = true;
        }
        protected string ArrangeCertificateDesc(string certificateName, string certificateInstitude, string certificateDate)
        {
            string retval = String.Empty;

            retval = certificateName;

            if (!String.IsNullOrEmpty(certificateDate)) retval = String.Concat(retval, " - ",
                certificateDate.ToDateTime().ToShortDateString());

            return retval;
        }
        protected bool ArrangeIsEdit(RepeaterItem rptItem)
        {
            if (!String.IsNullOrEmpty(hfRepeaterIndex.Value))
                if (hfRepeaterIndex.Value.ToInt()==rptItem.ItemIndex) return false ;
            
            return true;
        }
        #endregion
    }
}