using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using GSUKariyer.BUS;
using GSUKariyer.COMMON;
using GSUKariyer.COMMON.Helpers;
using GSUKariyer.COMMON.Helpers.WEB;

public partial class UC_Survey_uSurveyAddEdit : BaseUserControl
{
    #region Properties
    public int? SurveyID
    {
        get
        {
            return Request.QueryString["ID"].ToNullableInt();
        }
    }
    #endregion

    #region SurveyItemRepeaterControls
    public class SurveyItemRepeaterControls
    {
        protected RepeaterItem rptItem;

        public SurveyItemRepeaterControls(RepeaterItem surveyItemRepeater)
        {
            rptItem = surveyItemRepeater;
        }

        public TextBox txtOptionDescription
        {
            get { return RepeaterHelper.GetControl<TextBox>(rptItem, "txtOptionText"); }
        }

        public HiddenField hfSurveyItemId
        {
            get { return RepeaterHelper.GetControl<HiddenField>(rptItem, "hfSurveyItemID"); }
        }

        public TextBox txtOrder
        {
            get { return RepeaterHelper.GetControl<TextBox>(rptItem, "txtOrder"); }
        }
        
        public HiddenField hfVoteCount
        {
            get { return RepeaterHelper.GetControl<HiddenField>(rptItem, "hfVoteCount"); }
        }

        public TextBox txtVoteCount
        {
            get { return RepeaterHelper.GetControl<TextBox>(rptItem, "txtVoteCount"); }
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

    #region ArrangeForm/BindForm
    protected void ArrangeForm()
    {
        ddlState.DataSource=SiteParams.GetSurveyStates();
        ddlState.DataTextField=SiteParams.ColumnNames.Description; 
        ddlState.DataValueField=SiteParams.ColumnNames.Value;
        ddlState.DataBind();

        if (SurveyID.HasValue)
            BindForm();
    }
    protected void BindForm()
    {
        DataTable dt = Surveys.Generated.Get(SurveyID.Value);
        DataTable dtSurveysItems = SurveyItems.Generated.GetByFK(SurveyID.Value);

        if (dt.Rows.Count>0)
        {
            txtSurveyName.Text = dt.Rows[0][Surveys.ColumnNames.Name].ToString();
            txtDescription.Text = dt.Rows[0][Surveys.ColumnNames.Description].ToString();
            txtQuestion.Text = dt.Rows[0][Surveys.ColumnNames.Question].ToString();
            ddlState.SelectedValue = dt.Rows[0][Surveys.ColumnNames.State].ToString();
            ltrCreateDate.Text = dt.Rows[0][Surveys.ColumnNames.CreateDate].ToDateTime().ToShortDateString();

        }

        rptSurveyItems.DataSource=dtSurveysItems;
        rptSurveyItems.DataBind();
    }
    #endregion

    #region Button Events

    protected void btnAddSurvey_Click(object sender, EventArgs e)
    {
        DataTable dtItems = GetSurveyItems();

        DataRow dr = dtItems.NewRow();
        dr[SurveyItems.ColumnNames.ID] = -1;
        dr[SurveyItems.ColumnNames.Description] = txtOptionText.Text;
        dr[SurveyItems.ColumnNames.Order] = txtOrder.Text.ToNullableInt() ?? 1;
        dr[SurveyItems.ColumnNames.VoteCount] = txtVoteCount.Text.ToNullableInt()?? 0 ;

        dtItems.Rows.Add(dr);

        rptSurveyItems.DataSource = dtItems;
        rptSurveyItems.DataBind();
        ClearForm();
    }
    protected void btnCancelSurvey_Click(object sender, EventArgs e)
    {
        ClearForm();   
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        uError1.Visible = false;
        uSuccess1.Visible = false;

        try
        {
            Surveys.InsertSurvey(txtSurveyName.Text.Trim(), txtDescription.Text.Trim(),
                txtQuestion.Text.Trim(), (Surveys.State)int.Parse(ddlState.SelectedValue),
                GetSurveyItems());
            uSuccess1.Visible = true;
        }
        catch (Exception ex)
        {
            uError1.Visible = true;
        }
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        ((sender as Button).NamingContainer as RepeaterItem).Visible = false;

        rptSurveyItems.DataSource = GetSurveyItems();
        rptSurveyItems.DataBind();
    }
    #endregion

    #region Other Functions
    protected DataTable GetSurveyItems()
    {
        DataTable dtSurveyItems = SurveyItems.CreateTable();
        SurveyItemRepeaterControls rptControls;

        foreach (RepeaterItem rptItem in rptSurveyItems.Items)
        {
            if (!rptItem.Visible) continue;

            rptControls = new SurveyItemRepeaterControls(rptItem);
            DataRow dr = dtSurveyItems.NewRow();

            dr[SurveyItems.ColumnNames.ID] = rptControls.hfSurveyItemId.ToNullableInt() ?? -1;
            dr[SurveyItems.ColumnNames.Description] = rptControls.txtOptionDescription.Text.Trim();
            dr[SurveyItems.ColumnNames.Order] = rptControls.txtOrder.ToNullableInt() ?? 1; 
            dr[SurveyItems.ColumnNames.VoteCount] = 0; 

            dtSurveyItems.Rows.Add(dr);
        }

        return dtSurveyItems;
    }
    protected void ClearForm()
    {
        txtOptionText.Text = String.Empty;
        txtVoteCount.Text = String.Empty;
        txtOrder.Text = String.Empty;
    }
    #endregion
    
}