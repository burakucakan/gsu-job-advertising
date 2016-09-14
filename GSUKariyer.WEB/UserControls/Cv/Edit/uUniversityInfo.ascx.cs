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
    public partial class uUniversityInfo : BaseCvEditUserControl
    {
        #region Properties
        public override int ControlOrder
        {
            get
            {
                return CVs.Forms.ControlOrders.UniversityInfo;
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
        public int? EducationType
        {
            get { return uLicenseEducationType1.SelectedValue.ToNullableInt(); }
        }
        public int? GradeSystem
        {
            get
            {
                return uEducationGradeSystem1.SelectedValue.ToNullableInt();
            }
        }
        public decimal? GraduationGrade
        {
            get { return txtGraduationGrade.Text.ToNullableDecimal(); }
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
            uUniversities1.FreeItemValue = ((int)CVs.EducationInfo.UniversityInfo.Other).ToString();
            uUniversities1.FreeTextBoxWidth = 250;
            uUniversityInstitute1.ParentControl = uUniversities1;

            uUniversityDepartments1.ParentControl = uUniversityInstitute1;
            uUniversityDepartments1.FreeItemValue = CVs.EducationInfo.UniversityInstitute.Other.ToString();
            uUniversityDepartments1.FreeTextBoxWidth = 250;          
        }
        #endregion

        #region ButtonEvents
        protected void imgBtnSend_Click(object sender, ImageClickEventArgs e)
        {
            if (!IsNewCV)
                CVs.EducationInfo.LicenseInfo.Update(CVId.Value, StartDate.Value, EndDate, University.Value,
                    UniversityFree, Institute.Value, Department.Value, DepartmentFree, EducationType, GradeSystem,
                    GraduationGrade, DateTime.Now);

            Submit();
        }
        #endregion

        public void Bind(DataTable dt)
        {
            if (dt.Rows.Count>0)
            {
                DataRow dr=dt.Rows[0];

                uStartDate.SelectedValue = dr[CVs.ColumnNames.LicenseStartDate].ToNullableDateTime();
                uEndDate.SelectedValue = dr[CVs.ColumnNames.LicenseEndDate].ToNullableDateTime();
                uUniversities1.SelectedValue = dr[CVs.ColumnNames.LicenseUniversity].ToString();
                uUniversities1.FreeValue = dr[CVs.ColumnNames.LicenseUniversityFree].ToString();
                uUniversityInstitute1.SelectedValue = dr[CVs.ColumnNames.LicenseInstitute].ToString();
                uUniversityDepartments1.SelectedValue = dr[CVs.ColumnNames.LicenseDepartment].ToString();
                uUniversityDepartments1.FreeValue = dr[CVs.ColumnNames.LicenseDepartmentFree].ToString();
                uEducationGradeSystem1.SelectedValue = dr[CVs.ColumnNames.LicenseGradeSystem].ToString();
                txtGraduationGrade.Text = dr[CVs.ColumnNames.LicenseGraduationGrade].ToString();
                uLicenseEducationType1.SelectedValue = dr[CVs.ColumnNames.LicenseEducationType].ToString();

            }else
                ThrowNoDataException("Bind");
        }
    }
}