using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using System.Web.UI;
using System.Web.UI.HtmlControls;

namespace GSUKariyer.COMMON.Helpers.WEB
{
    public abstract class BaseEditViewControl:BaseUserControl
    {
        #region Constants
        public struct ViewStateKey
        {
            public const string ShowSelectValue = "SSV";
            public const string ShowSelectValueText = "SSVT";
            public const string Mode = "Md";
            public const string ValidationInitialValue = "VIV";
            public const string FreeValue = "FV";
            public const string HasFreeValue = "HFV";
            public const string SelectedValue = "SV";
        }
        private struct Constant
        {
            public const string ShowSelectValueText = "Seçiniz";
        }
        #endregion

        #region Events
        public delegate void ReBindEventHandler(string value, bool isValueChanged);
        private static readonly object EventReBind = new object();

        // Events   
        public event ReBindEventHandler ReBind
        {
            add
            {
                base.Events.AddHandler(EventReBind, value);
            }
            remove
            {
                base.Events.RemoveHandler(EventReBind, value);
            }
        }
        #endregion

        #region Properties
        public string FreeValue
        {
            get {
                return (ViewState[ViewStateKey.FreeValue] == null ? String.Empty :
                    ViewState[ViewStateKey.FreeValue].ToString());
            }
            set {
                ViewState.Add(ViewStateKey.FreeValue,value);
            }
        }

        public bool ShowSelectValue
        {
            get { return (ViewState[ViewStateKey.ShowSelectValue] == null ? true : (bool)ViewState[ViewStateKey.ShowSelectValue]); }
            set { ViewState.Add(ViewStateKey.ShowSelectValue,value); }
        }
        public string ShowSelectValueText
        {
            get { return (ViewState[ViewStateKey.ShowSelectValueText] == null ? Constant.ShowSelectValueText : ViewState[ViewStateKey.ShowSelectValueText].ToString()); }
            set { ViewState.Add(ViewStateKey.ShowSelectValueText, value); }
        }

        public string ValidationInitialValue
        {
            set {
                ViewState[ViewStateKey.ValidationInitialValue] = value;
            }
            get {
                return (ViewState[ViewStateKey.ValidationInitialValue]==null?String.Empty:
                    ViewState[ViewStateKey.ValidationInitialValue].ToString());
            }
        }

        public BaseEditViewListControl.ModOptions Mode
        {
            get { return (ViewState[ViewStateKey.Mode] == null ? BaseEditViewListControl.ModOptions.Edit :
                (BaseEditViewListControl.ModOptions)ViewState[ViewStateKey.Mode]);
            }
            set { ViewState.Add(ViewStateKey.Mode, value); }
        }
        #endregion

        #region Constructers
        public BaseEditViewControl()
        {
            this.Load += new EventHandler(Page_Init);
        }
        #endregion

        #region Page Events
        protected void Page_Init(object sender, EventArgs e)
        {
            this.Page.LoadComplete+=new EventHandler(Page_LoadComplete);
            Page_Load(sender,e);
        }
        protected virtual void Page_Load(object sender, EventArgs e)
        {
        }
        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            InitControl();
            AfterControlInit();
        }
        #endregion

        protected void ThrowReBindEvent(string value,bool isValueChanged)
        {
            ReBindEventHandler handler = (ReBindEventHandler)base.Events[EventReBind];
            if (handler != null)
            {
                handler(value, isValueChanged);
            }
        }

        protected abstract void InitControl();
        public abstract void BindControl(object dataSource, string dataTextField, string dataValueField);
        protected abstract void AfterControlInit();

        public void ParentControl_SelectedValueChanged(string value)
        {
            ThrowReBindEvent(value,false);
        }        
    }

    public interface IEditViewControl
    {
        // uEditViewControl Implements
        ListItem SelectedItem { get; }
        bool EnableDropdownViewState { get; set; }
        bool IsAutoPostBack { get; set; }
        string SelectedValue { get; set; }
        string SelectedValueRequestKey { get; }
        bool ValidationRequired { get; set; }
        bool Enabled { get; set; }
        string ValidationGroup { get; set; }
        string ValidationErrorMessage { get; set; }


        // Base Class Implements
        bool ShowSelectValue { get; set; }
        string ShowSelectValueText { get; set; }
        string ValidationInitialValue { get; set; }
        BaseEditViewListControl.ModOptions Mode { get; set; }
        event BaseEditViewControl.ReBindEventHandler ReBind;        
        string FreeValue { get; set; }
        bool HasFreeValue{get;set;} 
    }
}

