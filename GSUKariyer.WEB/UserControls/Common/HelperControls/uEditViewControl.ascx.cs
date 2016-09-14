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
using System.ComponentModel;
using System.Text;

namespace GSUKariyer.WEB.UserControls.Common.HelperControls
{
    public partial class uEditViewControl : BaseEditViewControl,IEditViewControl
    {
        protected bool selectedValueChanged = false;
        protected string oldSelectedValue;
        protected bool isReset=false;

        #region Properties
        protected string ListRequestID
        {
            get
            {
                return ddlList.ClientID.Replace("_", "$");
            }
        }
        public virtual ListItem SelectedItem
        {
            get
            {
                int selectedIndex = ddlList.SelectedIndex;
                if (selectedIndex >= 0)
                {
                    return ddlList.Items[selectedIndex];
                }
                return null;
            }
        }
        public bool EnableDropdownViewState
        {
            get
            {
                return ddlList.EnableViewState;
            }
            set
            {                
                ddlList.EnableViewState = value;
            }
        }
        public bool IsAutoPostBack
        {
            get { return ddlList.AutoPostBack; }
            set { ddlList.AutoPostBack = value; }
        }
        public string SelectedValueRequestKey
        {
            get
            {
                return ddlList.ClientID.Replace("_", "$");
            }
        }
        public bool ValidationRequired
        {
            get
            {
                return cvDDLList.Enabled;
            }
            set
            {
                if (Mode == BaseEditViewListControl.ModOptions.View) return;
                cvDDLList.Enabled = value;
            }
        }
        public string SelectedValue
        {
            get
            {
                if (Mode == BaseEditViewListControl.ModOptions.Edit)
                {
                    if (isReset)
                        return String.Empty;
                    
                    if (EnableDropdownViewState)
                    {
                        if (!String.IsNullOrEmpty(ddlList.SelectedValue))
                            return ddlList.SelectedValue;
                    }
                    else
                    {
                        if (!IsPostBack)
                        {
                            if (ViewState[ViewStateKey.SelectedValue] != null)
                                return ViewState[ViewStateKey.SelectedValue].ToString();
                            else
                                return String.Empty;
                        }
                        else
                        {
                            if (!String.IsNullOrEmpty(Request.Form[ListRequestID]))
                            { 
                                return Request.Form[ListRequestID].ToString();
                            }
                            else
                            {
                                if (EnableDropdownViewState == false)
                                    if (ViewState[ViewStateKey.SelectedValue] != null)
                                        return ViewState[ViewStateKey.SelectedValue].ToString();
                                    else
                                        return String.Empty;
                            }
                        }
                    }
                    
                    return String.Empty;
                }

                return lblValue.Text;
            }
            set
            {
                if (String.IsNullOrEmpty(value)) isReset = true;

                if (Mode == BaseEditViewListControl.ModOptions.Edit)
                {
                    ViewState.Add(ViewStateKey.SelectedValue,value);

                    if (ddlList.Items.Count > 0)
                    {
                        ddlList.SelectedIndex = -1;
                        ListItem listItemSelected = ddlList.Items.FindByValue(value);
                        if (listItemSelected != null) listItemSelected.Selected = true;

                        //if (!IsPostBack)
                        //{
                        //    BaseEditViewUserControl parentControl = ((BaseEditViewUserControl)this.Parent);
                        //    parentControl.ThrowSelectedValueChanged(value);
                        //}
                    }
                }
                else if (Mode == BaseEditViewListControl.ModOptions.View)
                    lblValue.Text = value;
            }
        }
        public bool Enabled {
            get {
                return ddlList.Enabled;
            }
            set {
                ddlList.Enabled = value;
                txtFreeValue.Enabled = value;
            }
        }
        public string ValidationGroup
        {
            get
            {
                return cvDDLList.ValidationGroup;
            }
            set
            {
                cvDDLList.ValidationGroup = value;
                rfvFreeValue.ValidationGroup= value;
            }
        }
        public string ValidationErrorMessage
        {
            get
            {
                return cvDDLList.ErrorMessage;
            }
            set
            {
                cvDDLList.ErrorMessage = value;
                rfvFreeValue.ErrorMessage = value;
            }
        }
        public bool HasFreeValue
        {
            get
            {
                return (ViewState[ViewStateKey.HasFreeValue] == null ? false :
                    (bool)ViewState[ViewStateKey.HasFreeValue]);
            }
            set
            {
                ViewState.Add(ViewStateKey.HasFreeValue, value);
                if (value)
                    IsAutoPostBack = true;
            }
        }
        #endregion

        #region Other Events
        protected override void Page_Load(object sender, EventArgs e)
        {
            if (EnableDropdownViewState)
            {
                ddlList.SelectedIndexChanged += new EventHandler(ddlList_SelectedIndexChanged);
            }

            
            if (Request.Form[ListRequestID] != null)
            {
                oldSelectedValue=ViewState[ViewStateKey.SelectedValue] as string;
                ViewState.Add(ViewStateKey.SelectedValue, Request.Form[ListRequestID].ToString());
            }
        }
        protected void ddlList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (EnableDropdownViewState)
                ViewState.Add(ViewStateKey.SelectedValue, ddlList.SelectedValue);

            if (EnableDropdownViewState)
                ThrowReBindEvent(SelectedValue,true);

            selectedValueChanged = true;
        }
        #endregion

        #region BindData
        public override void BindControl(object dataSource, string dataTextField, string dataValueField)
        {
            if (dataSource != null)
            {
                try
                {
                    ddlList.DataTextField = dataTextField;
                    ddlList.DataValueField = dataValueField;
                    ddlList.DataSource = dataSource;
                    ddlList.DataBind();
                }
                catch
                {
                    ddlList.SelectedIndex=-1;

                    ddlList.DataTextField = dataTextField;
                    ddlList.DataValueField = dataValueField;
                    ddlList.DataSource = dataSource;
                    ddlList.DataBind();
                }
            }

            if (ddlList.DataSource == null &&
                ddlList.Items.Count > 0)
            {
                ddlList.Items.Clear();
            }

            if (ShowSelectValue)
            {
                ListItem item = new ListItem(ShowSelectValueText, String.Empty);

                if (!ddlList.Items.Contains(item))
                {
                    ddlList.Items.Insert(0, item);
                }
            }

            if (String.IsNullOrEmpty(SelectedValue) || isReset )
                ddlList.SelectedIndex = -1;
            else
                SelectedValue = SelectedValue;

            ThrowReBindEvent(SelectedValue, selectedValueChanged);
        }
        #endregion

        #region Validation Functions
        protected void Server_Validate(object sender, ServerValidateEventArgs e)
        {
            if (String.IsNullOrEmpty(SelectedValue) || SelectedValue == ValidationInitialValue)
                e.IsValid = false;
            else
                e.IsValid = true;

        }
        #endregion

        #region Control Initialize
        protected override void InitControl()
        {
            if (IsPostBack)
            {
                if (Request.Form[ListRequestID] != null)
                {
                    if (Request.Form[ListRequestID].ToString() != oldSelectedValue)
                        ddlList_SelectedIndexChanged(ddlList,null);
                }
            }

            if (Mode == BaseEditViewListControl.ModOptions.Edit)
            {
                trDropDown.Visible = true;
                trLabel.Visible = false;
                trFreeValue.Visible = false;

                if (HasFreeValue && SelectedValue == FreeValue)
                {
                    trFreeValue.Visible = true;

                    if (ValidationRequired) 
                        rfvFreeValue.Enabled = true;
                    else
                        rfvFreeValue.Enabled = false;
                }
            }
            else if (Mode == BaseEditViewListControl.ModOptions.View)
            {
                trDropDown.Visible = false;
                trLabel.Visible = true;

                cvDDLList.Enabled = false;
                rfvFreeValue.Enabled = false;
            }
        }
        protected override void AfterControlInit()
        {
            if (!IsPostBack)
            {
                StringBuilder scriptBuilder=new StringBuilder();
                scriptBuilder.AppendLine(ArrangeValidationScript());
                //scriptBuilder.AppendLine(ArrangeFreeValueScript());
                //scriptBuilder.AppendLine(ArrangeDropdownChangeScript());

                ValidationScriptLiteral.Text = scriptBuilder.ToString();
                cvDDLList.ClientValidationFunction = String.Concat("Client_Validate_", this.ClientID);

                //string onChangeScript = String.Empty;
                //onChangeScript = String.Concat("SelectedChange_", this.ClientID, "();");

                //if (HasFreeValue)
                //    onChangeScript = String.Concat(onChangeScript, "FreeValue_", this.ClientID, "();");

                //if (!ddlList.AutoPostBack)
                //    ddlList.Attributes.Add("onchange", onChangeScript);
                //else
                //{ 
                    
                //}
            }
        }
        #endregion

        #region ArrangeScriptFunctions
        protected string ArrangeValidationScript()
        {
            StringBuilder builder = new StringBuilder();

            builder.AppendLine("<script type=\"text/javascript\">");
            builder.AppendLine(String.Concat("function Client_Validate_", this.ClientID, "(sender, args) {"));
            builder.AppendLine(String.Concat("var listDropdown = document.getElementById('", ddlList.ClientID, "');"));
            builder.AppendLine(String.Concat("if (listDropdown.value.length == 0 || listDropdown.value == '",
                ValidationInitialValue, "')"));
            builder.AppendLine("args.IsValid = false;");
            builder.AppendLine("else");
            builder.AppendLine("args.IsValid = true;");
            builder.AppendLine("}");

            builder.AppendLine("</script>");

            return builder.ToString();
        }
        protected string ArrangeFreeValueScript()
        {
            StringBuilder builder = new StringBuilder();

            builder.AppendLine("<script type=\"text/javascript\">");
            builder.AppendLine(String.Concat("function FreeValue_", this.ClientID, "() {"));
            builder.AppendLine(String.Concat("var listDropdown = document.getElementById('", ddlList.ClientID, "');"));

            builder.AppendLine(String.Concat("var divFreeValue = document.getElementById('", trFreeValue.ClientID, "');"));
            builder.AppendLine(String.Concat("var freeValueValidator = document.getElementById('", rfvFreeValue.ClientID, "');"));
            builder.AppendLine(String.Concat("var freeValueInput = document.getElementById('", txtFreeValue.ClientID, "');"));


            builder.AppendLine(String.Concat("if (listDropdown.value == '",
                FreeValue, "')"));
            builder.AppendLine("{");

            builder.AppendLine("divFreeValue.style.visibility = 'visible';");
            if (ValidationRequired)
                builder.AppendLine("ValidatorEnable(freeValueValidator,true)");
            else
                builder.AppendLine("ValidatorEnable(freeValueValidator,false)");

            builder.AppendLine("}");
            builder.AppendLine("else");
            builder.AppendLine("{");

            builder.AppendLine("divFreeValue.style.visibility = 'hidden';");
            builder.AppendLine("ValidatorEnable(freeValueValidator,false)");
            builder.AppendLine("freeValueInput.value='';");

            builder.AppendLine("}");

            builder.AppendLine("}");

            builder.AppendLine("</script>");

            return builder.ToString();
        }
        protected string ArrangeDropdownChangeScript()
        {
            StringBuilder builder = new StringBuilder();

            builder.AppendLine("<script type=\"text/javascript\">");
            builder.AppendLine(String.Concat("function SelectedChange_", this.ClientID, "() {"));
            builder.AppendLine(String.Concat("var listDropdown = document.getElementById('", ddlList.ClientID, "');"));
            //builder.AppendLine(String.Concat("var selectedHiddenField = document.getElementById('", SelectedValueHiddenField.ClientID, "');"));

            builder.AppendLine("selectedHiddenField.value=listDropdown.value;");
            builder.AppendLine("}");

            builder.AppendLine("</script>");

            return builder.ToString();
        }
        #endregion
    }
}