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
    public partial class uReferanceInfo : BaseCvEditUserControl
    {
        #region ConstValues
        protected struct RepeaterControls
        {
            public const string hfId = "hfId";
            public const string hfName = "hfName";
            public const string hfSurname = "hfSurname";
            public const string hfEmail = "hfEmail";
            public const string hfPhone = "hfPhone";
            public const string hfFirmName = "hfFirmName";
            public const string hfFirmSector = "hfFirmSector";
            public const string hfPosition = "hfPosition";
            public const string uItem1 = "uItem1";
        }
        #endregion

        #region Properties
        public override int ControlOrder
        {
            get
            {
                return CVs.Forms.ControlOrders.Referances;
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
        }
        #endregion

        #region ButtonEvents
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            btnCancel.Visible = false;
            if (!String.IsNullOrEmpty(hfRepeaterIndex.Value))
            {
                ArrangeItemsEditVisibility(((uItem)rptItems.Items[hfRepeaterIndex.Value.ToInt()].FindControl(
                        RepeaterControls.uItem1)),true);
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

            dr[CVs.Referances.ColumnNames.Email] = txtEmail.Text.Trim();
            dr[CVs.Referances.ColumnNames.FirmSector] =uSectors1.SelectedValue;
            dr[CVs.Referances.ColumnNames.Name] = txtReferanceName.Text.Trim();
            dr[CVs.Referances.ColumnNames.Phone] = uPhoneNumber1.Value;
            dr[CVs.Referances.ColumnNames.Surname] = txtSurname.Text.Trim();
            dr[CVs.Referances.ColumnNames.WorkingFirm] = txtFirmName.Text.Trim();
            dr[CVs.Referances.ColumnNames.WorkingPosition] = uPositions1.SelectedValue;

            if (isEdit == false) dt.Rows.Add(dr);
            Bind(dt);
            
            if(isEdit)
            {
                ArrangeItemsEditVisibility(((uItem)rptItems.Items[hfRepeaterIndex.Value.ToInt()].FindControl(
                    RepeaterControls.uItem1)),true);
            }
            
            ResetForm();
        }
        protected void imgBtnSend_Click(object sender, ImageClickEventArgs e)
        {
            if (!IsNewCV)
                CVs.Referances.Update(CVId.Value,GetData());

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
            DataTable dt = CVs.Referances.CreateTable();

            foreach (RepeaterItem rptItem in rptItems.Items)
            {
                DataRow dr = dt.NewRow();

                dr[CVs.Referances.ColumnNames.ID] = DBNullHelper.ConvertValueToDBNull(
                    RepeaterHelper.GetControl<HiddenField>(
                    rptItem, RepeaterControls.hfId).Value.ToNullableInt());
                dr[CVs.Referances.ColumnNames.Email] = DBNullHelper.ConvertValueToDBNull(
                    RepeaterHelper.GetControl<HiddenField>(
                    rptItem, RepeaterControls.hfEmail).Value);
                dr[CVs.Referances.ColumnNames.FirmSector] = DBNullHelper.ConvertValueToDBNull(RepeaterHelper.GetControl<HiddenField>(
                    rptItem, RepeaterControls.hfFirmSector).Value);
                dr[CVs.Referances.ColumnNames.Name] = DBNullHelper.ConvertValueToDBNull(
                    RepeaterHelper.GetControl<HiddenField>(
                    rptItem, RepeaterControls.hfName).Value);
                dr[CVs.Referances.ColumnNames.Phone] = DBNullHelper.ConvertValueToDBNull(
                    RepeaterHelper.GetControl<HiddenField>(
                    rptItem, RepeaterControls.hfPhone).Value);
                dr[CVs.Referances.ColumnNames.Phone] = DBNullHelper.ConvertValueToDBNull( 
                    RepeaterHelper.GetControl<HiddenField>(
                    rptItem, RepeaterControls.hfPhone).Value);
                dr[CVs.Referances.ColumnNames.Surname] = DBNullHelper.ConvertValueToDBNull(
                    RepeaterHelper.GetControl<HiddenField>(
                    rptItem, RepeaterControls.hfSurname).Value);
                dr[CVs.Referances.ColumnNames.WorkingFirm] = DBNullHelper.ConvertValueToDBNull(
                    RepeaterHelper.GetControl<HiddenField>(
                    rptItem, RepeaterControls.hfFirmName).Value);
                dr[CVs.Referances.ColumnNames.FirmSector] = DBNullHelper.ConvertValueToDBNull(
                    RepeaterHelper.GetControl<HiddenField>(
                    rptItem, RepeaterControls.hfFirmSector).Value);
                dr[CVs.Referances.ColumnNames.WorkingPosition] = DBNullHelper.ConvertValueToDBNull(
                    RepeaterHelper.GetControl<HiddenField>(
                    rptItem, RepeaterControls.hfPosition).Value);

                dt.Rows.Add(dr);
            }

            return dt;
        }
        protected void ResetForm()
        {
            hfRepeaterIndex.Value = String.Empty;
            hfId.Value = String.Empty;
            btnCancel.Visible = false;

            txtEmail.Text = String.Empty;
            txtFirmName.Text = String.Empty;
            txtReferanceName.Text = String.Empty;
            txtSurname.Text = String.Empty;
            uPhoneNumber1.Value = String.Empty;
            uSectors1.SelectedValue = String.Empty;
            uPositions1.SelectedValue = String.Empty;
        }
        #endregion

        public void Bind(DataTable dt)
        {
            rptItems.DataSource = dt;
            rptItems.DataBind();
        }

        #region RepeaterEvents
        protected void uItem_ItemRemove(object sender, string value, string parentControlId)
        {
            DataTable dt = GetData();
            int deletedItemIndex = ((RepeaterItem)((uItem)sender).NamingContainer).ItemIndex;

            if (!String.IsNullOrEmpty(hfRepeaterIndex.Value))
                if (deletedItemIndex < hfRepeaterIndex.Value.ToInt())
                    hfRepeaterIndex.Value = (hfRepeaterIndex.Value.ToInt() - 1).ToString();

            dt.Rows[deletedItemIndex].Delete();
            Bind(dt);
        }
        protected void uItem_ItemEdit(object sender, string value, string parentControlId)
        {
            if (!String.IsNullOrEmpty(hfRepeaterIndex.Value))
                btnCancel_Click(null, null);

            RepeaterItem rptItem = (RepeaterItem)((uItem)sender).NamingContainer;
            hfRepeaterIndex.Value = rptItem.ItemIndex.ToString();
            ArrangeItemsEditVisibility(((uItem)sender),false);

            txtEmail.Text = RepeaterHelper.GetControl<HiddenField>(
                    rptItem, RepeaterControls.hfEmail).Value;
            txtFirmName.Text = RepeaterHelper.GetControl<HiddenField>(
                    rptItem, RepeaterControls.hfFirmName).Value;
            txtReferanceName.Text = RepeaterHelper.GetControl<HiddenField>(
                    rptItem, RepeaterControls.hfName).Value;
            txtSurname.Text = RepeaterHelper.GetControl<HiddenField>(
                    rptItem, RepeaterControls.hfSurname).Value;
            uPositions1.SelectedValue = RepeaterHelper.GetControl<HiddenField>(
                    rptItem, RepeaterControls.hfPosition).Value;
            uSectors1.SelectedValue = RepeaterHelper.GetControl<HiddenField>(
                    rptItem, RepeaterControls.hfFirmSector).Value;
            uPhoneNumber1.Value = RepeaterHelper.GetControl<HiddenField>(
                    rptItem, RepeaterControls.hfPhone).Value;

            btnCancel.Visible = true;
        }
        protected string ArrangeDesc(string name, string surname,string workingFirm )
        {
            string retval = String.Empty;

            retval = String.Concat(name," ",surname);
            if (!String.IsNullOrEmpty(workingFirm)) retval = String.Concat(retval, " - ",
                workingFirm);

            return retval;
        }
        protected bool ArrangeIsEdit(RepeaterItem rptItem)
        {
            if (!String.IsNullOrEmpty(hfRepeaterIndex.Value))
                if (hfRepeaterIndex.Value.ToInt() == rptItem.ItemIndex) return false;

            return true;
        }
        #endregion
    }
}