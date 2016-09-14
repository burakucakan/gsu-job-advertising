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
    public partial class uCourseInfo : BaseCvEditUserControl
    {
        #region ConstValues
        protected struct RepeaterControls
        {
            public const string hfId = "hfId";
            public const string hfName = "hfName";
            public const string hfInstitution = "hfInstitution";
            public const string hfStartDate = "hfStartDate";
            public const string hfEndDate = "hfEndDate";
            public const string hfDuration = "hfDuration";
            public const string hfDescription = "hfDescription";
            public const string uItem1 = "uItem1";
        }
        #endregion

        #region Properties
        public override int ControlOrder
        {
            get
            {
                return CVs.Forms.ControlOrders.CourseInfo;
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

            dr[CVs.CourseInfo.ColumnNames.Description] = txtDescription.Text.Trim();
            dr[CVs.CourseInfo.ColumnNames.DurationInHours] = DBNullHelper.ConvertValueToDBNull(
                txtDuration.Text.ToNullableInt());
            dr[CVs.CourseInfo.ColumnNames.EndDate] = DBNullHelper.ConvertValueToDBNull(
                uEndDate.SelectedValue);
            dr[CVs.CourseInfo.ColumnNames.Institution] = txtInstitution.Text;
            dr[CVs.CourseInfo.ColumnNames.StartDate] = DBNullHelper.ConvertValueToDBNull(
                uStartDate.SelectedValue);
            dr[CVs.CourseInfo.ColumnNames.Name] = txtCourseName.Text;
            

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
            btnCancel_Click(null,null);

            if (!IsNewCV)
                CVs.CourseInfo.Update(CVId.Value,GetData());

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
            DataTable dt = CVs.CourseInfo.CreateTable();

            foreach (RepeaterItem rptItem in rptItems.Items)
            {
                DataRow dr = dt.NewRow();

                dr[CVs.CourseInfo.ColumnNames.ID] = DBNullHelper.ConvertValueToDBNull(
                    RepeaterHelper.GetControl<HiddenField>(
                    rptItem, RepeaterControls.hfId).Value.ToNullableInt());
                dr[CVs.CourseInfo.ColumnNames.Description] = DBNullHelper.ConvertValueToDBNull(
                    RepeaterHelper.GetControl<HiddenField>(
                    rptItem, RepeaterControls.hfDescription).Value);
                dr[CVs.CourseInfo.ColumnNames.DurationInHours] = DBNullHelper.ConvertValueToDBNull(RepeaterHelper.GetControl<HiddenField>(
                    rptItem, RepeaterControls.hfDuration).Value.ToNullableInt());
                dr[CVs.CourseInfo.ColumnNames.EndDate] = DBNullHelper.ConvertValueToDBNull(
                    RepeaterHelper.GetControl<HiddenField>(
                    rptItem, RepeaterControls.hfEndDate).Value.ToNullableDateTime());
                dr[CVs.CourseInfo.ColumnNames.StartDate] = DBNullHelper.ConvertValueToDBNull(
                    RepeaterHelper.GetControl<HiddenField>(
                    rptItem, RepeaterControls.hfStartDate).Value.ToNullableDateTime());
                dr[CVs.CourseInfo.ColumnNames.Institution] = DBNullHelper.ConvertValueToDBNull( 
                    RepeaterHelper.GetControl<HiddenField>(
                    rptItem, RepeaterControls.hfInstitution).Value);
                dr[CVs.CourseInfo.ColumnNames.Name] = DBNullHelper.ConvertValueToDBNull(
                    RepeaterHelper.GetControl<HiddenField>(
                    rptItem, RepeaterControls.hfName).Value);

                dt.Rows.Add(dr);
            }

            return dt;
        }
        protected void ResetForm()
        {
            hfRepeaterIndex.Value = String.Empty;
            btnCancel.Visible = false;

            txtCourseName.Text = String.Empty;
            txtDuration.Text = String.Empty;
            txtInstitution.Text = String.Empty;
            uStartDate.SelectedValue = null;
            uEndDate.SelectedValue = null;
            txtDescription.Text = String.Empty;
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
                btnCancel_Click(null,null);

            RepeaterItem rptItem = (RepeaterItem)((uItem)sender).NamingContainer;
            hfRepeaterIndex.Value = rptItem.ItemIndex.ToString();
            ArrangeItemsEditVisibility(((uItem)sender),false);

            txtCourseName.Text = RepeaterHelper.GetControl<HiddenField>(
                    rptItem, RepeaterControls.hfName).Value;
            txtDuration.Text = RepeaterHelper.GetControl<HiddenField>(
                    rptItem, RepeaterControls.hfDuration).Value;
            txtInstitution.Text = RepeaterHelper.GetControl<HiddenField>(
                    rptItem, RepeaterControls.hfInstitution).Value;
            uStartDate.SelectedValue = RepeaterHelper.GetControl<HiddenField>(
                    rptItem, RepeaterControls.hfStartDate).Value.ToNullableDateTime();
            uEndDate.SelectedValue = RepeaterHelper.GetControl<HiddenField>(
                    rptItem, RepeaterControls.hfEndDate).Value.ToNullableDateTime();
            txtDescription.Text = RepeaterHelper.GetControl<HiddenField>(
                    rptItem, RepeaterControls.hfDescription).Value;
            

            btnCancel.Visible = true;
        }
        protected string ArrangeDesc(string name, string institution)
        {
            string retval = String.Empty;

            retval = name;
            if (!String.IsNullOrEmpty(institution)) retval = String.Concat(retval, " - ",
                institution);

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