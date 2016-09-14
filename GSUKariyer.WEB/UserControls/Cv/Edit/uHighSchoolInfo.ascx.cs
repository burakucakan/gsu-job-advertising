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
    public partial class uHighSchoolInfo : BaseCvEditUserControl
    {
        #region Properties
        public override int ControlOrder
        {
            get
            {
                return CVs.Forms.ControlOrders.HighSchoolInfo;
            }
        }
        public string HighSchool
        {
            get {
                return txtHighSchool.Text.Trim();
            }
        }
        public DateTime? EndDate
        {
            get { return uEndDate.SelectedValue; }
        }
        public decimal? GraduationGrade
        {
            get { return txtGraduationGrade.Text.ToNullableDecimal(); }
        }
        public int? EducationGradeSystem
        {
            get { return uEducationGradeSystem1.SelectedValue.ToNullableInt(); }
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
        protected void imgBtnSend_Click(object sender, ImageClickEventArgs e)
        {
            Submit();
        }
        #endregion

        public void Bind(DataTable dt)
        {
            if (dt.Rows.Count>0)
            {
                DataRow dr=dt.Rows[0];

                txtHighSchool.Text = dr[CVs.EducationInfo.HighSchoolInfo.ColumnNames.HighSchool].ToString();
                uEndDate.SelectedValue=dr[CVs.EducationInfo.HighSchoolInfo.ColumnNames.HighSchoolEndDate].ToNullableDateTime();
                uEducationGradeSystem1.SelectedValue = dr[CVs.EducationInfo.HighSchoolInfo.ColumnNames.HighSchoolGradeSystem].ToString();
                txtGraduationGrade.Text = dr[CVs.EducationInfo.HighSchoolInfo.ColumnNames.HighSchoolGraduationGrade].ToString();

            }else
                ThrowNoDataException("Bind");
        }
    }
}