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
    public partial class uExamInfo : BaseCvEditUserControl
    {
        #region ConstValues
        protected struct RepeaterControls
        {
            public const string hfId = "hfId";
            public const string hfExamName = "hfExamName";
            public const string hfExamYear = "hfExamYear";
            public const string hfExamCorporation = "hfExamCorporation";
            public const string hfExamScore = "hfExamScore";
            public const string hfDescription = "hfDescription";
            public const string uItem1 = "uItem1";
        }
        #endregion

        #region Properties
        public override int ControlOrder
        {
            get
            {
                return CVs.Forms.ControlOrders.ExamInfo;
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
            uExamYear.MaxValue = DateTime.Now.Year;
            uExamYear.MinValue = DateTime.Now.AddYears(-40).Year;
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

            dr[CVs.ExamInfo.ColumnNames.Description] = txtDescription.Text.Trim();
            dr[CVs.ExamInfo.ColumnNames.ExamCorporation] =txtExamCorporation.Text.Trim();
            dr[CVs.ExamInfo.ColumnNames.ExamName] =DBNullHelper.ConvertValueToDBNull(
                uExams1.SelectedValue);
            dr[CVs.ExamInfo.ColumnNames.ExamScore] = DBNullHelper.ConvertValueToDBNull(
                txtExamScore.Text.ToNullableInt());
            dr[CVs.ExamInfo.ColumnNames.StartYear] = DBNullHelper.ConvertValueToDBNull(
                uExamYear.SelectedValue.ToNullableInt());

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
                CVs.ExamInfo.Update(CVId.Value,GetData());

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
            DataTable dt = CVs.ExamInfo.CreateTable();

            foreach (RepeaterItem rptItem in rptItems.Items)
            {
                DataRow dr = dt.NewRow();

                dr[CVs.ExamInfo.ColumnNames.ID] = DBNullHelper.ConvertValueToDBNull(
                    RepeaterHelper.GetControl<HiddenField>(
                    rptItem, RepeaterControls.hfId).Value.ToNullableInt());
                dr[CVs.ExamInfo.ColumnNames.Description] = DBNullHelper.ConvertValueToDBNull(
                    RepeaterHelper.GetControl<HiddenField>(
                    rptItem, RepeaterControls.hfDescription).Value);
                dr[CVs.ExamInfo.ColumnNames.ExamCorporation] = DBNullHelper.ConvertValueToDBNull(RepeaterHelper.GetControl<HiddenField>(
                    rptItem, RepeaterControls.hfExamCorporation).Value);
                dr[CVs.ExamInfo.ColumnNames.ExamName] = DBNullHelper.ConvertValueToDBNull(
                    RepeaterHelper.GetControl<HiddenField>(
                    rptItem, RepeaterControls.hfExamName).Value);
                dr[CVs.ExamInfo.ColumnNames.ExamScore] = DBNullHelper.ConvertValueToDBNull( 
                    RepeaterHelper.GetControl<HiddenField>(
                    rptItem, RepeaterControls.hfExamScore).Value.ToNullableInt());
                dr[CVs.ExamInfo.ColumnNames.StartYear] = DBNullHelper.ConvertValueToDBNull(
                    RepeaterHelper.GetControl<HiddenField>(
                    rptItem, RepeaterControls.hfExamYear).Value.ToNullableInt());

                dt.Rows.Add(dr);
            }

            return dt;
        }
        protected void ResetForm()
        {
            hfRepeaterIndex.Value = String.Empty;
            btnCancel.Visible = false;

            uExams1.SelectedValue = String.Empty;
            uExamYear.SelectedValue = String.Empty;
            txtDescription.Text = String.Empty;
            txtExamCorporation.Text = String.Empty;
            txtExamScore.Text = String.Empty;
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

            uExams1.SelectedValue = RepeaterHelper.GetControl<HiddenField>(
                    rptItem, RepeaterControls.hfExamName).Value;
            uExamYear.SelectedValue = RepeaterHelper.GetControl<HiddenField>(
                    rptItem, RepeaterControls.hfExamYear).Value;
            txtDescription.Text = RepeaterHelper.GetControl<HiddenField>(
                    rptItem, RepeaterControls.hfDescription).Value;
            txtExamCorporation.Text = RepeaterHelper.GetControl<HiddenField>(
                    rptItem, RepeaterControls.hfExamCorporation).Value;
            txtExamScore.Text = RepeaterHelper.GetControl<HiddenField>(
                    rptItem, RepeaterControls.hfExamScore).Value;

            btnCancel.Visible = true;
        }
        protected string ArrangeDesc(string examName, string examYear)
        {
            string retval = String.Empty;

            retval = SiteParams.GetExamDescription(examName.ToInt());
            if (!String.IsNullOrEmpty(examYear)) retval = String.Concat(retval, " - ",
                examYear);

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