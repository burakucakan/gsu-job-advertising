using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GSUKariyer.COMMON.Helpers.WEB;
using GSUKariyer.BUS;
using System.Data;

namespace GSUKariyer.WEB.UserControls.Cv.Edit
{
    public partial class uUserClubs : BaseCvEditUserControl
    {
        #region Properties
        public override int ControlOrder
        {
            get
            {
                return CVs.Forms.ControlOrders.SocialClubs;
            }
        }
        public string OtherClubs
        {
            get { return txtOtherClubs.Text.Trim(); }
        }
        public string OtherUniversityClubs
        {
            get { return txtOtherUniversityClubs.Text.Trim(); }
        }
        #endregion

        bool _isArranged = false;

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
            if (!_isArranged)
            {
                DataTable dtClubs = SiteParams.GetGSClubs();

                dtClubs.DefaultView.RowFilter = String.Format("{0}='{1}'",
                    SiteParams.ColumnNames.ParamName, SiteParams.ParamName.SporClubs);

                cblSporClubs.DataSource = dtClubs.DefaultView.ToTable();
                cblSporClubs.DataTextField = SiteParams.ColumnNames.Description;
                cblSporClubs.DataValueField = SiteParams.ColumnNames.Value;
                cblSporClubs.DataBind();

                dtClubs.DefaultView.RowFilter = String.Empty;
                dtClubs.DefaultView.RowFilter = String.Format("{0}='{1}'",
                    SiteParams.ColumnNames.ParamName, SiteParams.ParamName.CulturalClubs);

                cblCulturelClubs.DataSource = dtClubs.DefaultView.ToTable();
                cblCulturelClubs.DataTextField = SiteParams.ColumnNames.Description;
                cblCulturelClubs.DataValueField = SiteParams.ColumnNames.Value;
                cblCulturelClubs.DataBind();

                dtClubs.DefaultView.RowFilter = String.Empty;
                dtClubs.DefaultView.RowFilter = String.Format("{0}='{1}'",
                    SiteParams.ColumnNames.ParamName, SiteParams.ParamName.AkademicClubs);

                cblAcademicClubs.DataSource = dtClubs.DefaultView.ToTable();
                cblAcademicClubs.DataTextField = SiteParams.ColumnNames.Description;
                cblAcademicClubs.DataValueField = SiteParams.ColumnNames.Value;
                cblAcademicClubs.DataBind();

                _isArranged = true;
            }
        }
        #endregion

        #region ButtonEvents
        protected void imgBtnSend_Click(object sender, ImageClickEventArgs e)
        {
            if (!IsNewCV)
                CVs.UnivercityClubs.Update(CVId.Value, GetData(), OtherClubs, OtherUniversityClubs);

            Submit();
        }
        #endregion

        public void Bind(string otherUniversityClubs,string otherClubs,DataTable dtClubs)
        {
            ArrangeForm();

            txtOtherClubs.Text=otherClubs;
            txtOtherUniversityClubs.Text = otherUniversityClubs;

            foreach (DataRow dr in dtClubs.Rows)
            {
                ListItem item= cblSporClubs.Items.FindByValue(dr[CVs.UnivercityClubs.ColumnNames.UniversityClub].ToString());
                if (item != null)
                    item.Selected = true;

                item = cblAcademicClubs.Items.FindByValue(dr[CVs.UnivercityClubs.ColumnNames.UniversityClub].ToString());
                if (item != null)
                    item.Selected = true;

                item = cblCulturelClubs.Items.FindByValue(dr[CVs.UnivercityClubs.ColumnNames.UniversityClub].ToString());
                if (item != null)
                    item.Selected = true;
            }
        }

        #region Others
        public DataTable GetData()
        {
            DataTable dt = CVs.UnivercityClubs.CreateTable();

            foreach (ListItem item in cblCulturelClubs.Items)
            {
                if (item.Selected)
                {
                    DataRow dr = dt.NewRow();
                    dr[CVs.UnivercityClubs.ColumnNames.UniversityClub] = item.Value;
                    dt.Rows.Add(dr);
                }
            }

            foreach (ListItem item in cblAcademicClubs.Items)
            {
                if (item.Selected)
                {
                    DataRow dr = dt.NewRow();
                    dr[CVs.UnivercityClubs.ColumnNames.UniversityClub] = item.Value;
                    dt.Rows.Add(dr);
                }
            }

            foreach (ListItem item in cblSporClubs.Items)
            {
                if (item.Selected)
                {
                    DataRow dr = dt.NewRow();
                    dr[CVs.UnivercityClubs.ColumnNames.UniversityClub] = item.Value;
                    dt.Rows.Add(dr);
                }
            }

            return dt;
        }
        #endregion
    }
}