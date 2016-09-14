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
using GSUKariyer.WEB.UserControls.Common.HelperControls;

namespace GSUKariyer.WEB.UserControls.Cv.Edit
{
    public partial class uLanguagelInfo : BaseCvEditUserControl
    {
        #region ConstValues

        public ArrayList vwArrLngelements
        {
            get { return (ViewState["vwArrLngelements"] == null ? new ArrayList() : (ArrayList)ViewState["vwArrLngelements"]); }
            set { ViewState["vwArrLngelements"] = value; }
        }

        public struct RepeaterControls
        {
            public const string ddlLanguages = "ddlLanguages";
            public const string uReadGrade = "uReadGrade";
            public const string uWriteGrade = "uWriteGrade";
            public const string uTalkGrade = "uTalkGrade";
            public const string txtLearnPlace = "txtLearnPlace";
            public const string rfvLearnPlace = "rfvLearnPlace";
        }
        #endregion

        #region Properties
        public override int ControlOrder
        {
            get
            {
                return CVs.Forms.ControlOrders.LanguageInfo;
            }
        }
        #endregion

        DataTable dtLanguages = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack)
            {
                //hdValScr.Value = "";
                ArrangeForm();
            }
        }

        #region ArrangeForm
        protected void ArrangeForm()
        {
            if(!CVId.HasValue)
                Bind();
        }
        #endregion

        #region ButtonEvents
        protected void imgBtnSend_Click(object sender, ImageClickEventArgs e)
        {
            foreach (RepeaterItem rptItem in rptLanguageInfo.Items)
            {
                //bool validationEnabled = false;

                if (String.IsNullOrEmpty(RepeaterHelper.GetControl<DropDownList>(rptItem, RepeaterControls.ddlLanguages).SelectedValue))
                {
                    RepeaterHelper.GetControl<TextBox>(rptItem, RepeaterControls.txtLearnPlace).Text = String.Empty;
                    RepeaterHelper.GetControl<uNumericDropdown>(rptItem, RepeaterControls.uReadGrade).SelectedValue = String.Empty;
                    RepeaterHelper.GetControl<uNumericDropdown>(rptItem, RepeaterControls.uWriteGrade).SelectedValue = String.Empty;
                    RepeaterHelper.GetControl<uNumericDropdown>(rptItem, RepeaterControls.uTalkGrade).SelectedValue = String.Empty;

                }
                /* Custom Validation Kullanılmalı. Aşağıdaki kodlara gerek kalmadı
                else
                    validationEnabled = true;

                
                RepeaterHelper.GetControl<RequiredFieldValidator>(rptItem, RepeaterControls.rfvLearnPlace).Enabled = validationEnabled;
                RepeaterHelper.GetControl<uNumericDropdown>(rptItem, RepeaterControls.uReadGrade).ValidationRequired = validationEnabled;
                RepeaterHelper.GetControl<uNumericDropdown>(rptItem, RepeaterControls.uWriteGrade).ValidationRequired = validationEnabled;
                RepeaterHelper.GetControl<uNumericDropdown>(rptItem, RepeaterControls.uTalkGrade).ValidationRequired = validationEnabled;
                */ 
            }

            //Page.Validate(ValidationGroup);

            if (Page.IsValid)
            {
                if (!IsNewCV)
                    CVs.LanguageInfo.Update(CVId.Value,GetData());

                Submit();
            }
        }
        #endregion

        protected void Bind()
        {
            DataTable dt = CVs.LanguageInfo.CreateTable();

            for (int i = 0; i < 3; i++)
            {
                DataRow dr = dt.NewRow();
                dt.Rows.Add(dr);
            }

            Bind(dt);
        }
        public void Bind(DataTable dt)
        {
            if (dt.Rows.Count > 0)
            {
                for (int i = dt.Rows.Count; i < 3; i++)
                {
                    DataRow dr = dt.NewRow();
                    dt.Rows.Add(dr);
                }

                rptLanguageInfo.DataSource = dt;
                rptLanguageInfo.DataBind();

            }
            else
                Bind();
        }

        #region RepeaterEvents
        protected void rptLanguageInfo_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item ||
                e.Item.ItemType == ListItemType.AlternatingItem)
            {
                DataRowView drv= (DataRowView)e.Item.DataItem;

                DropDownList ddlLanguages= RepeaterHelper.GetControl<DropDownList>(e.Item,RepeaterControls.ddlLanguages);
                if (dtLanguages == null)
                {
                    dtLanguages = SiteParams.GetLanguages().Copy();
                    DataRow drLanguage = dtLanguages.NewRow();
                    drLanguage[SiteParams.ColumnNames.Description] = "Seçiniz";
                    dtLanguages.Rows.InsertAt(drLanguage, 0);
                }

                ddlLanguages.DataSource=dtLanguages;
                ddlLanguages.DataTextField=SiteParams.ColumnNames.Description;
                ddlLanguages.DataValueField=SiteParams.ColumnNames.Value;
                ddlLanguages.DataBind();
                ddlLanguages.SelectedValue=drv[CVs.LanguageInfo.ColumnNames.LanguageId].ToString();

                uNumericDropdown uReadGrade = RepeaterHelper.GetControl<uNumericDropdown>(e.Item,RepeaterControls.uReadGrade);
                uNumericDropdown uWriteGrade = RepeaterHelper.GetControl<uNumericDropdown>(e.Item,RepeaterControls.uWriteGrade);
                uNumericDropdown uTalkGrade = RepeaterHelper.GetControl<uNumericDropdown>(e.Item,RepeaterControls.uTalkGrade);

                uReadGrade.SelectedValue = drv[CVs.LanguageInfo.ColumnNames.ReadGrade].ToString();
                uWriteGrade.SelectedValue = drv[CVs.LanguageInfo.ColumnNames.WriteGrade].ToString();
                uTalkGrade.SelectedValue = drv[CVs.LanguageInfo.ColumnNames.TalkGrade].ToString();

                TextBox txtLearnPlace = RepeaterHelper.GetControl<TextBox>(e.Item, RepeaterControls.txtLearnPlace);
                txtLearnPlace.Text = drv[CVs.LanguageInfo.ColumnNames.HowLearned].ToString();

                hdValScr.Value += ddlLanguages.ClientID + "," + uReadGrade.ClientID + "," + uWriteGrade.ClientID + "," + uTalkGrade.ClientID + "," + txtLearnPlace.ClientID + "~";
            }
        }
        #endregion

        #region Others
        public DataTable GetData()
        {
            DataTable dt = CVs.LanguageInfo.CreateTable();

            foreach (RepeaterItem rptItem in rptLanguageInfo.Items)
            {
                string language = RepeaterHelper.GetControl<DropDownList>(rptItem, RepeaterControls.ddlLanguages).SelectedValue;

                if (!String.IsNullOrEmpty(language))
                {
                    DataRow dr = dt.NewRow();

                    dr[CVs.LanguageInfo.ColumnNames.LanguageId] = language.ToInt();
                    dr[CVs.LanguageInfo.ColumnNames.ReadGrade]=RepeaterHelper.GetControl<uNumericDropdown>(rptItem, RepeaterControls.uReadGrade).SelectedValue.ToInt();
                    dr[CVs.LanguageInfo.ColumnNames.TalkGrade]=RepeaterHelper.GetControl<uNumericDropdown>(rptItem, RepeaterControls.uTalkGrade).SelectedValue.ToInt();
                    dr[CVs.LanguageInfo.ColumnNames.WriteGrade]=RepeaterHelper.GetControl<uNumericDropdown>(rptItem, RepeaterControls.uWriteGrade).SelectedValue.ToInt();
                    dr[CVs.LanguageInfo.ColumnNames.HowLearned] = RepeaterHelper.GetControl<TextBox>(rptItem, RepeaterControls.txtLearnPlace).Text;

                    dt.Rows.Add(dr);
                }
            }

            return dt;
        }
        #endregion
    }
}