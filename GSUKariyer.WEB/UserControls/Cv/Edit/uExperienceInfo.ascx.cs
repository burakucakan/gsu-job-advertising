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
    public partial class uExperienceInfo : BaseCvEditUserControl
    {
        #region ConstValues
        protected struct RepeaterControls
        {
            public const string uItem = "uItem";
            public const string hfId = "hfId";
            public const string hfFirmName = "hfFirmName";
            public const string hfStartDate = "hfStartDate";
            public const string hfEndDate = "hfEndDate";
            public const string hfCity = "hfCity";
            public const string hfSector = "hfSector";
            public const string hfWorkerCount = "hfWorkerCount";
            public const string hfPersonelCount = "hfPersonelCount";
            public const string hfExperience = "hfExperience";
            public const string hfLeaveReason = "hfLeaveReason";
            public const string hfDescription = "hfDescription";
            public const string hfResponsibleName = "hfResponsibleName";
            public const string hfResponsibleTitle = "hfResponsibleTitle";
            public const string hfResponsiblePhone = "hfResponsiblePhone";
            public const string hfWorkingType = "hfWorkingType";
            public const string hfPosition = "hfPosition";
        }
        #endregion

        #region Properties
        public override int ControlOrder
        {
            get
            {
                return CVs.Forms.ControlOrders.WorkExperinces;
            }
        }
        public int? WorkingStatus
        {
            get {
                return uWorkingStatus1.SelectedValue.ToNullableInt();
            }
        }
        public int? WorkingExperience
        {
            get
            {
                return uWorkingExperiences1.SelectedValue.ToNullableInt();
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
                        RepeaterControls.uItem)),true);
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

            dr[CVs.WorkExperiences.ColumnNames.ID] = DBNullHelper.ConvertValueToDBNull(
                hfItemId.Value.ToNullableInt());
            dr[CVs.WorkExperiences.ColumnNames.FirmName] =txtFirm.Text.Trim();
            dr[CVs.WorkExperiences.ColumnNames.FirmSector] = uSectors1.SelectedValue;
            dr[CVs.WorkExperiences.ColumnNames.FirmWorkerCount] = DBNullHelper.ConvertValueToDBNull(
                uWorkerCounts1.SelectedValue.ToNullableInt());
            dr[CVs.WorkExperiences.ColumnNames.JobDescription] = txtDescription.Text.Trim();
            dr[CVs.WorkExperiences.ColumnNames.JobLeavingReason] = txtJobLeaveReason.Text.Trim();
            dr[CVs.WorkExperiences.ColumnNames.NumberOfPeopleOnResponsibility] = DBNullHelper.ConvertValueToDBNull( 
                uPersonalCount1.SelectedValue.ToNullableInt());
            dr[CVs.WorkExperiences.ColumnNames.ResponsibleName] = txtResponsibleName.Text.Trim();
            dr[CVs.WorkExperiences.ColumnNames.ResponsiblePhone] = uResponsiblePhoneNumber.Value;
            dr[CVs.WorkExperiences.ColumnNames.ResponsibleTitle] = txtResponsibleTitle.Text.Trim();
            dr[CVs.WorkExperiences.ColumnNames.WorkCity] = DBNullHelper.ConvertValueToDBNull(
                uCityCountry1.SelectedValue);
            dr[CVs.WorkExperiences.ColumnNames.WorkEndDate] = DBNullHelper.ConvertValueToDBNull(
                uEndDate.SelectedValue.ToNullableDateTime()) ;
            dr[CVs.WorkExperiences.ColumnNames.WorkingExperience] = DBNullHelper.ConvertValueToDBNull(
                uExperienceCount1.SelectedValue.ToNullableInt());
            dr[CVs.WorkExperiences.ColumnNames.WorkingPosition] = uPositions1.SelectedValue;
            dr[CVs.WorkExperiences.ColumnNames.WorkingType] = DBNullHelper.ConvertValueToDBNull(
                uWorkingType1.SelectedValue.ToNullableInt());
            dr[CVs.WorkExperiences.ColumnNames.WorkStartDate] = DBNullHelper.ConvertValueToDBNull(
                uStartDate.SelectedValue.ToNullableDateTime());


            if (isEdit == false) dt.Rows.Add(dr);
            Bind(uWorkingStatus1.SelectedValue.ToNullableInt(),
                uWorkingExperiences1.SelectedValue.ToNullableInt(),dt);
            
            if(isEdit)
            {
                ArrangeItemsEditVisibility(
                    ((uItem)rptItems.Items[hfRepeaterIndex.Value.ToInt()].FindControl(
                    RepeaterControls.uItem)), true);
            }

            ResetForm();
        }
        protected void imgBtnSend_Click(object sender, ImageClickEventArgs e)
        {
            btnCancel_Click(null,null);

            if (!IsNewCV)
                CVs.WorkExperiences.Update(CVId.Value,uWorkingStatus1.SelectedValue.ToNullableInt(),
                    uWorkingExperiences1.SelectedValue.ToNullableInt(),GetData());

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
            DataTable dt = CVs.WorkExperiences.CreateTable();            

            foreach (RepeaterItem rptItem in rptItems.Items)
            {
                DataRow dr = dt.NewRow();


                dr[CVs.WorkExperiences.ColumnNames.ID] = DBNullHelper.ConvertValueToDBNull(
                    RepeaterHelper.GetControl<HiddenField>(
                       rptItem, RepeaterControls.hfId).Value.ToNullableInt());
                dr[CVs.WorkExperiences.ColumnNames.FirmName] =DBNullHelper.ConvertValueToDBNull(
                    RepeaterHelper.GetControl<HiddenField>(
                       rptItem, RepeaterControls.hfFirmName).Value);
                dr[CVs.WorkExperiences.ColumnNames.FirmSector] = DBNullHelper.ConvertValueToDBNull(
                    RepeaterHelper.GetControl<HiddenField>(
                    rptItem, RepeaterControls.hfSector).Value);
                dr[CVs.WorkExperiences.ColumnNames.FirmWorkerCount]=DBNullHelper.ConvertValueToDBNull(
                    RepeaterHelper.GetControl<HiddenField>(
                       rptItem, RepeaterControls.hfWorkerCount).Value.ToNullableInt());
                dr[CVs.WorkExperiences.ColumnNames.JobDescription] = DBNullHelper.ConvertValueToDBNull(
                    RepeaterHelper.GetControl<HiddenField>(
                    rptItem, RepeaterControls.hfDescription).Value);
                dr[CVs.WorkExperiences.ColumnNames.JobLeavingReason] =DBNullHelper.ConvertValueToDBNull(
                    RepeaterHelper.GetControl<HiddenField>(
                    rptItem, RepeaterControls.hfLeaveReason).Value);
                dr[CVs.WorkExperiences.ColumnNames.NumberOfPeopleOnResponsibility]= DBNullHelper.ConvertValueToDBNull(
                    RepeaterHelper.GetControl<HiddenField>(
                       rptItem, RepeaterControls.hfPersonelCount).Value.ToNullableInt());
                dr[CVs.WorkExperiences.ColumnNames.ResponsibleName] = DBNullHelper.ConvertValueToDBNull(
                    RepeaterHelper.GetControl<HiddenField>(
                    rptItem, RepeaterControls.hfResponsibleName).Value);
                dr[CVs.WorkExperiences.ColumnNames.ResponsiblePhone] = DBNullHelper.ConvertValueToDBNull(
                    RepeaterHelper.GetControl<HiddenField>(
                    rptItem, RepeaterControls.hfResponsiblePhone).Value);
                dr[CVs.WorkExperiences.ColumnNames.ResponsibleTitle] =DBNullHelper.ConvertValueToDBNull(
                    RepeaterHelper.GetControl<HiddenField>(
                    rptItem, RepeaterControls.hfResponsibleTitle).Value);
                dr[CVs.WorkExperiences.ColumnNames.WorkCity] = DBNullHelper.ConvertValueToDBNull(
                    RepeaterHelper.GetControl<HiddenField>(
                       rptItem, RepeaterControls.hfCity).Value);
                dr[CVs.WorkExperiences.ColumnNames.WorkEndDate] =DBNullHelper.ConvertValueToDBNull(
                    RepeaterHelper.GetControl<HiddenField>(
                       rptItem, RepeaterControls.hfEndDate).Value.ToNullableDateTime());
                dr[CVs.WorkExperiences.ColumnNames.WorkingExperience]= DBNullHelper.ConvertValueToDBNull(
                    RepeaterHelper.GetControl<HiddenField>(
                       rptItem, RepeaterControls.hfExperience).Value.ToNullableInt());
                dr[CVs.WorkExperiences.ColumnNames.WorkingPosition] = DBNullHelper.ConvertValueToDBNull(
                    RepeaterHelper.GetControl<HiddenField>(
                       rptItem, RepeaterControls.hfPosition).Value.ToNullableInt());
                dr[CVs.WorkExperiences.ColumnNames.WorkingType] = DBNullHelper.ConvertValueToDBNull(
                    RepeaterHelper.GetControl<HiddenField>(
                       rptItem, RepeaterControls.hfWorkingType).Value.ToNullableInt());
                dr[CVs.WorkExperiences.ColumnNames.WorkStartDate] = DBNullHelper.ConvertValueToDBNull(
                    RepeaterHelper.GetControl<HiddenField>(
                       rptItem, RepeaterControls.hfStartDate).Value.ToNullableDateTime());
                        

                dt.Rows.Add(dr);
            }

            return dt;
        }
        protected void ResetForm()
        {
            hfRepeaterIndex.Value = String.Empty;
            hfItemId.Value = String.Empty;
            btnCancel.Visible = false;

            txtDescription.Text = String.Empty;
            txtFirm.Text = String.Empty;
            txtJobLeaveReason.Text = String.Empty;
            txtResponsibleName.Text = String.Empty;
            uResponsiblePhoneNumber.Value = String.Empty;
            txtResponsibleTitle.Text = String.Empty;
            uStartDate.SelectedValue = null;
            uWorkerCounts1.SelectedValue = String.Empty;
            uWorkingType1.SelectedValue = String.Empty;
            uCityCountry1.SelectedValue = String.Empty;
            uSectors1.SelectedValue = String.Empty;
            uPositions1.SelectedValue = String.Empty;
            uPersonalCount1.SelectedValue = String.Empty;
            uExperienceCount1.SelectedValue = String.Empty;
        }
        #endregion

        public void Bind(int? workingStatus,int? totalWorkExperienceInMonth,DataTable dt)
        {
            uWorkingStatus1.SelectedValue=workingStatus.ToString();
            uWorkingExperiences1.SelectedValue = totalWorkExperienceInMonth.ToString();

            rptItems.DataSource = dt;
            rptItems.DataBind();
        }

        #region RepeaterEvents
        protected void uItem_ItemRemove(object sender, string value, string parentControlId)
        {
            if (!String.IsNullOrEmpty(hfRepeaterIndex.Value))
                btnCancel_Click(null, null);

            DataTable dt = GetData();
            int deletedItemIndex = ((RepeaterItem)((uItem)sender).NamingContainer).ItemIndex;

            if (!String.IsNullOrEmpty(hfRepeaterIndex.Value))
                if (deletedItemIndex < hfRepeaterIndex.Value.ToInt())
                    hfRepeaterIndex.Value = (hfRepeaterIndex.Value.ToInt() - 1).ToString();

            dt.Rows[deletedItemIndex].Delete();
            Bind(uWorkingStatus1.SelectedValue.ToNullableInt(),
                uWorkingExperiences1.SelectedValue.ToNullableInt(),dt);
        }
        protected void uItem_ItemEdit(object sender, string value, string parentControlId)
        {
            RepeaterItem rptItem =(RepeaterItem) ((uItem)sender).NamingContainer;
            hfRepeaterIndex.Value = rptItem.ItemIndex.ToString();
            ((uItem)sender).IsEdit = false;
            ((uItem)sender).IsRemove = false;

            hfItemId.Value=RepeaterHelper.GetControl<HiddenField>(
                rptItem, RepeaterControls.hfId).Value;
            txtFirm.Text=RepeaterHelper.GetControl<HiddenField>(
                rptItem, RepeaterControls.hfFirmName).Value;
            uSectors1.SelectedValue = RepeaterHelper.GetControl<HiddenField>(
                rptItem, RepeaterControls.hfSector).Value;
            uWorkerCounts1.SelectedValue = RepeaterHelper.GetControl<HiddenField>(
                rptItem, RepeaterControls.hfWorkerCount).Value;
            txtDescription.Text = RepeaterHelper.GetControl<HiddenField>(
                rptItem, RepeaterControls.hfDescription).Value;
            txtJobLeaveReason.Text = RepeaterHelper.GetControl<HiddenField>(
                rptItem, RepeaterControls.hfLeaveReason).Value;
            uPersonalCount1.SelectedValue = RepeaterHelper.GetControl<HiddenField>(
                rptItem, RepeaterControls.hfPersonelCount).Value;
            txtResponsibleName.Text = RepeaterHelper.GetControl<HiddenField>(
                rptItem, RepeaterControls.hfResponsibleName).Value;
            uResponsiblePhoneNumber.Value = RepeaterHelper.GetControl<HiddenField>(
                rptItem, RepeaterControls.hfResponsiblePhone).Value;
            txtResponsibleTitle.Text = RepeaterHelper.GetControl<HiddenField>(
                rptItem, RepeaterControls.hfResponsibleTitle).Value;
            uCityCountry1.SelectedValue = RepeaterHelper.GetControl<HiddenField>(
                rptItem, RepeaterControls.hfCity).Value;
            uEndDate.SelectedValue = RepeaterHelper.GetControl<HiddenField>(
                rptItem, RepeaterControls.hfEndDate).Value.ToNullableDateTime();
            uExperienceCount1.SelectedValue = RepeaterHelper.GetControl<HiddenField>(
                rptItem, RepeaterControls.hfExperience).Value;
            uPositions1.SelectedValue = RepeaterHelper.GetControl<HiddenField>(
                rptItem, RepeaterControls.hfPosition).Value;
            uWorkingType1.SelectedValue = RepeaterHelper.GetControl<HiddenField>(
                rptItem, RepeaterControls.hfWorkingType).Value;
            uStartDate.SelectedValue = RepeaterHelper.GetControl<HiddenField>(
                rptItem, RepeaterControls.hfStartDate).Value.ToNullableDateTime();

            btnCancel.Visible = true;
        }
        protected string ArrangeDesc(string firmName, string startDate)
        {
            string retval = String.Empty;

            retval = firmName;
            if (!String.IsNullOrEmpty(startDate)) retval = String.Concat(retval, " - ",
                startDate.ToDateTime().ToShortDateString());

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