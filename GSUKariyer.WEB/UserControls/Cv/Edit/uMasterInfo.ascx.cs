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
using GSUKariyer.BUS;
using GSUKariyer.COMMON;

namespace GSUKariyer.WEB.UserControls.Cv.Edit
{
    public partial class uMasterInfo : BaseCvEditUserControl
    {
        #region Properties
        public override int ControlOrder
        {
            get
            {
                return CVs.Forms.ControlOrders.MasterInfo;
            }
        }
        public DateTime? StartDate
        {
            get { return uStartDate.SelectedValue; }
        }
        public DateTime? EndDate
        {
            get { return uEndDate.SelectedValue; }
        }
        public int? University
        {
            get { return uUniversities1.SelectedValue.ToNullableInt(); }
        }
        public string UniversityFree
        {
            get { return uUniversities1.FreeValue; }
        }
        public int? Institute
        {
            get { return uUniversityInstitute1.SelectedValue.ToNullableInt(); }
        }
        public int? Department
        {
            get { return uUniversityDepartments1.SelectedValue.ToNullableInt(); }
        }
        public string DepartmentFree
        {
            get { return uUniversityDepartments1.FreeValue; }
        }
        public int? GradeSystem
        {
            get {
                return uEducationGradeSystem1.SelectedValue.ToNullableInt();
            }
        }
        public decimal? GraduationGrade
        {
            get { return txtGraduationGrade.Text.ToNullableDecimal(); }
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
            uUniversities1.FreeItemValue = ((int)CVs.EducationInfo.UniversityInfo.Other).ToString();
            uUniversities1.FreeTextBoxWidth = 250;
            uUniversityInstitute1.ParentControl = uUniversities1;

            uUniversityDepartments1.ParentControl = uUniversityInstitute1;
            uUniversityDepartments1.FreeItemValue = CVs.EducationInfo.UniversityInstitute.Other.ToString();
            uUniversityDepartments1.FreeTextBoxWidth = 250;

            isArranged = true;
        }
        #endregion

        #region ButtonEvents
        protected void imgBtnSend_Click(object sender, ImageClickEventArgs e)
        {
            if (uStartDate.SelectedValue.HasValue ||
                (!String.IsNullOrEmpty(uUniversities1.SelectedValue)) ||
                (!String.IsNullOrEmpty(uUniversityInstitute1.SelectedValue)) ||
                (!String.IsNullOrEmpty(uUniversityDepartments1.SelectedValue)))
            {
                lblErrorStartDate.Visible = (!uStartDate.SelectedValue.HasValue);
                lblErrorUniversity.Visible = String.IsNullOrEmpty(uUniversities1.SelectedValue);
                lblErrorInstitute.Visible = String.IsNullOrEmpty(uUniversityInstitute1.SelectedValue);
                lblErrorDepartments.Visible = String.IsNullOrEmpty(uUniversityDepartments1.SelectedValue);

                if (lblErrorStartDate.Visible ||
                    lblErrorUniversity.Visible ||
                    lblErrorInstitute.Visible ||
                    lblErrorDepartments.Visible)
                    return;
            }

            if (!IsNewCV)
                CVs.EducationInfo.MasterInfo.Update(CVId.Value,StartDate,EndDate,University,UniversityFree,
                    Institute,Department,DepartmentFree,GradeSystem,GraduationGrade,DateTime.Now);

            Submit();
        }
        #endregion

        public void Bind(DataTable dt)
        {
            if (!isArranged) ArrangeForm();

            if (dt.Rows.Count>0)
            {
                DataRow dr=dt.Rows[0];

                uStartDate.SelectedValue = dr[CVs.ColumnNames.MasterStartDate].ToNullableDateTime();
                uEndDate.SelectedValue = dr[CVs.ColumnNames.MasterEndDate].ToNullableDateTime();
                uUniversities1.SelectedValue = dr[CVs.ColumnNames.MasterUniversity].ToString();
                uUniversities1.FreeValue = dr[CVs.ColumnNames.MasterUniversityFree].ToString();
                uUniversityInstitute1.SelectedValue = dr[CVs.ColumnNames.MasterInstitute].ToString();
                uUniversityDepartments1.SelectedValue = dr[CVs.ColumnNames.MasterDepartment].ToString();
                uUniversityDepartments1.FreeValue = dr[CVs.ColumnNames.MasterDepartmentFree].ToString();
                uEducationGradeSystem1.SelectedValue = dr[CVs.ColumnNames.MasterGradeSystem].ToString();
                txtGraduationGrade.Text = dr[CVs.ColumnNames.MasterGraduationGrade].ToString();

            }else
                ThrowNoDataException("Bind");
        }

        #region Others
        protected void ArrangeValidation(bool isVisible)
        {
            lblErrorDepartments.Visible = isVisible;
            lblErrorInstitute.Visible = isVisible;
            lblErrorStartDate.Visible = isVisible;
            lblErrorUniversity.Visible = isVisible;
        }
        #endregion
    }
}