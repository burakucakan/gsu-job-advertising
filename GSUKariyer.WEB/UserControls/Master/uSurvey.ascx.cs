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
using GSUKariyer.BUS;
using GSUKariyer.COMMON.Helpers.WEB;
using GSUKariyer.COMMON;

namespace GSUKariyer.WEB.UserControls.Master
{
    public partial class uSurvey : BaseUserControl
    {
        protected const string rdItem = "rdItem";
        protected const string hfItemId = "hfItemId";

        private int TotalVote = 0;
        private int SurveyId = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)                   
                Arrange();
        }

        protected void Arrange()
        {
            if (this.SessionManager.IsLoggedIn)
            {
                pnlSurveyResults.Visible = BUS.Surveys.HasVoted(this.SessionManager.UserId.Value);
                pnlSurveyItems.Visible = !pnlSurveyResults.Visible;

                if (pnlSurveyResults.Visible)
                    ShowResults();
                else
                    BindForm();
            }
            else
            {
                pnlSurveyItems.Visible = true;
                BindForm();
            }
        }

        protected void ShowResults() {            
            DataTable dtSurveyResults = BUS.SurveyResults.GetSurveyResults();
            ltrSurveyQuestion.Text = dtSurveyResults.Rows[0][BUS.Surveys.ColumnNames.Question].ToString();
                        
            foreach (DataRow dr in dtSurveyResults.Rows)
                this.TotalVote += dr["Vote"].ToInt();
            
            DataBindHelper.BindRepeater(ref rptSurveyResult, dtSurveyResults);
        }

        protected void rptSurveyResult_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            float Percent = 0;
            if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
            {
                Percent = int.Parse(((Literal)e.Item.FindControl("ltlVote")).Text);
                Percent = this.TotalVote / Percent;
                Percent = 100 / Percent;
                ((Literal)e.Item.FindControl("ltlPercent")).Text = Convert.ToInt32(Percent).ToString();
                ((Image)e.Item.FindControl("imgBar")).Width = Unit.Pixel(Convert.ToInt32(Percent));
            }
        }
        
        #region BindForm
        protected void BindForm()
        {
            DataSet ds = Surveys.GetActive();

            DataTable dtSurvey = ds.Tables[0];
            DataTable dtSurveyItems = ds.Tables[1];

            if (dtSurvey.Rows.Count > 0)
            {
                ltrSurveyQuestion.Text = dtSurvey.Rows[0][Surveys.ColumnNames.Question].ToString();
                this.SurveyId = dtSurvey.Rows[0][Surveys.ColumnNames.ID].ToInt();

                DataBindHelper.BindRadioButtonList(ref rblSurveyItems, dtSurveyItems, BUS.SurveyItems.ColumnNames.Description, BUS.SurveyItems.ColumnNames.ID, "");
                rblSurveyItems.SelectedIndex = 0;
            }
        }
        #endregion

        #region Button Events
        protected void btnSurveySend_Click(object sender, EventArgs e)
        {
            if (SessionManager.IsLoggedIn)
            {
                int? selectedItemId = rblSurveyItems.SelectedValue.ToInt();

                if (selectedItemId.HasValue)
                {
                    SurveyResults.Generated.Add(selectedItemId.Value, this.SessionManager.UserId.Value, DateTime.Now);
                    pnlSurveyResults.Visible = true;
                    pnlSurveyItems.Visible = false;
                    ShowResults();
                }
            }
            else
                Response.Redirect(UrlHelper.PageUrl.Signup());
        }
        #endregion
    }
}