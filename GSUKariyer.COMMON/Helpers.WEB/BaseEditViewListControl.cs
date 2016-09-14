using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;

namespace GSUKariyer.COMMON.Helpers.WEB
{
    public delegate void SelectedValueChangedEventHandler(string value,bool isValueChanged);
    public abstract class BaseEditViewListControl:BaseUserControl
    {
        #region Enums
        public enum ModOptions
        {
            Edit = 0,
            View = 1
        }
        #endregion

        #region Const Values
        protected struct ViewStateKey
        {
            public const string PreviousParentValue = "PPV";
        }
        #endregion

        #region Events
        private static readonly object EventSelectedValueChanged = new object();
        public event SelectedValueChangedEventHandler SelectedValueChanged 
        {
            add 
            {
                base.Events.AddHandler(EventSelectedValueChanged, value);
            }
            remove 
            {
                base.Events.RemoveHandler(EventSelectedValueChanged, value);
            }
        }
        #endregion

        #region Properties
        public Unit FreeTextBoxWidth
        {
            set
            {
                ((TextBox)((this.FindControl("uEditViewControl1")).FindControl("txtFreeValue"))).Width = value;
            }
            get
            {
                return ((TextBox)((this.FindControl("uEditViewControl1")).FindControl("txtFreeValue"))).Width;
            }
        }
        public virtual bool ValidationRequired
        {
            get
            {
                return ((IEditViewControl)this.FindControl("uEditViewControl1")).ValidationRequired;
            }
            set
            {
                ((IEditViewControl)this.FindControl("uEditViewControl1")).ValidationRequired = value;
            }
        }
        public bool IsBound
        {
            get;
            set;
        }
        public ModOptions Mode
        {
            get
            {
                return (this.FindControl("uEditViewControl1") as IEditViewControl).Mode;
            }
            set
            {
                (this.FindControl("uEditViewControl1") as IEditViewControl).Mode = value;
            }
        }
        public bool AutoPostBack
        {
            get
            {
                return ((IEditViewControl)this.FindControl("uEditViewControl1")).IsAutoPostBack;
            }
            set
            {
                ((IEditViewControl)this.FindControl("uEditViewControl1")).IsAutoPostBack = value;
            }
        }
        public string SelectedValue
        {
            get
            {
                return (this.FindControl("uEditViewControl1") as IEditViewControl).SelectedValue;
            }
            set
            {
                (this.FindControl("uEditViewControl1") as IEditViewControl).SelectedValue = value.ToString();
            }
        }
        public bool DropDownViewStateEnabled
        {
            get
            {
                return (this.FindControl("uEditViewControl1") as IEditViewControl).EnableDropdownViewState;
            }
            set
            {
                (this.FindControl("uEditViewControl1") as IEditViewControl).EnableDropdownViewState = value;
            }
        }
        public BaseEditViewListControl ParentControl
        {
            get
            {
                return (ViewState["ParentControlID"] == null ? null : (BaseEditViewListControl)this.Parent.FindControl(ViewState["ParentControlID"].ToString()));
            }
            set
            {
                ViewState.Add("ParentControlID", value.ID);
                ((BaseEditViewListControl)value).AutoPostBack = true;
            }
        }
        public virtual string FreeValue
        {
            get
            {
                if (Mode == ModOptions.View)
                {
                    Label lblValue = ((Label)((this.FindControl("uEditViewControl1")).FindControl("lblValue")));
                    string[] valueAtoms = lblValue.Text.Split('-');

                    if (valueAtoms.Length < 2)
                        return String.Empty;

                    return valueAtoms[1];
                }
                else
                    return ((TextBox)((this.FindControl("uEditViewControl1")).FindControl("txtFreeValue"))).Text.Trim();
            }
            set
            {
                if (Mode == ModOptions.View)
                {
                    if (!String.IsNullOrEmpty(value.Trim()))
                    {
                        Label lblValue = ((Label)((this.FindControl("uEditViewControl1")).FindControl("lblValue")));
                        lblValue.Text = String.Format("{0}-{1}", lblValue.Text, value.Trim());
                    }
                }
                else
                    ((TextBox)((this.FindControl("uEditViewControl1")).FindControl("txtFreeValue"))).Text = value;
            }
        }
        public virtual bool Enabled
        {
            get
            {
                return ((IEditViewControl)this.FindControl("uEditViewControl1")).Enabled;
            }
            set
            {
                ((IEditViewControl)this.FindControl("uEditViewControl1")).Enabled = value;
            }
        }
        public virtual ListItem SelectedItem
        {
            get
            {
                return ((IEditViewControl)this.FindControl("uEditViewControl1")).SelectedItem;
            }

        }
        public virtual bool HasFreeValue
        {
            set
            {
                ((IEditViewControl)this.FindControl("uEditViewControl1")).HasFreeValue = value; 
            }
            get
            {
                return ((IEditViewControl)this.FindControl("uEditViewControl1")).HasFreeValue;
            }
        }
        public virtual string FreeItemValue
        {
            get {
                return ((IEditViewControl)this.FindControl("uEditViewControl1")).FreeValue;
            }
            set { 
                ((IEditViewControl)this.FindControl("uEditViewControl1")).FreeValue=value;
            }
        }
        public virtual string ValidationInitialValue
        {
            get
            {
                return (this.FindControl("uEditViewControl1") as IEditViewControl).ValidationInitialValue;
            }
            set
            {
                (this.FindControl("uEditViewControl1") as IEditViewControl).ValidationInitialValue = value;
            }

        }
        public virtual string ValidationErrorMessage
        {
            get
            {
                return ((IEditViewControl)this.FindControl("uEditViewControl1")).ValidationErrorMessage;
            }
            set
            {
                ((IEditViewControl)this.FindControl("uEditViewControl1")).ValidationErrorMessage = value;
            }
        }
        public virtual string ValidationGroup
        {
            get
            {
                return ((IEditViewControl)this.FindControl("uEditViewControl1")).ValidationGroup;
            }
            set
            {
                ((IEditViewControl)this.FindControl("uEditViewControl1")).ValidationGroup = value;
            }
        }
        protected bool isValueChanged = false;
        public bool IsValueChanged
        {
            get
            {
                return isValueChanged;
            }
        }
        //protected string PreviousParentValue
        //{
        //    get {return (ViewState[ViewStateKey.PreviousParentValue]==null?String.Empty:
        //        ViewState[ViewStateKey.PreviousParentValue].ToString());
        //    }
        //    set {
        //        ViewState[ViewStateKey.PreviousParentValue] = value;
        //    }
        //}
        #endregion

        #region Page Events
        protected void Page_Init(object sender, EventArgs e)
        {
            //this.Page.InitComplete += new EventHandler(BaseEditViewListControl_Load);
            this.Page.PreLoad += new EventHandler(BaseEditViewListControl_PreLoad);
            this.Page.LoadComplete += new EventHandler(BaseEditViewListControl_PreRender);
        }


        void BaseEditViewListControl_PreLoad(object sender, EventArgs e)
        {
            LoadControl();
        }
        void BaseEditViewListControl_PreRender(object sender, EventArgs e)
        {
            ArrangeControlBind();
        }
        #endregion

        protected void LoadControl()
        {
            CustomBeforePageLoad();

           
                if (ParentControl != null)
                {
                    ParentControl.SelectedValueChanged += new SelectedValueChangedEventHandler(ParentControl_SelectedValueChanged);
                }

                (this.FindControl("uEditViewControl1") as IEditViewControl).ReBind += new BaseEditViewControl.ReBindEventHandler(uEditViewControl1_ReBind);

                if (ParentControl != null)
                    ParentControl.AutoPostBack = true;
            

            CustomPageLoad();
        }
        protected void ArrangeControlBind()
        {
            if ((!DropDownViewStateEnabled))
            {
                BindControl();
            }
            else
            {
                if (!IsPostBack)
                {
                    BindControl();
                }
            }

        }

        #region Event Functions
        protected void ThrowSelectedValueChanged(string value,bool isValueChanged)
        {
            SelectedValueChangedEventHandler handler = base.Events[EventSelectedValueChanged] as SelectedValueChangedEventHandler;
            if (handler != null)
            {
                handler(value, isValueChanged);
            }
        } 
        protected void ParentControl_SelectedValueChanged(string value,bool isParentSelectedValueChanged)
        {
            if (isParentSelectedValueChanged)
                this.SelectedValue = String.Empty;
            
            if (DropDownViewStateEnabled)
            {
                BindControl();
            }

            ThrowSelectedValueChanged(SelectedValue, isParentSelectedValueChanged);
        }
        protected void uEditViewControl1_ReBind(string value, bool isValueChanged)
        {
            this.isValueChanged = isValueChanged;
            ThrowSelectedValueChanged(value, isValueChanged);
        }
        #endregion

        public Nullable<T> GetTextWithType<T>() where T : struct
        {
            if (string.IsNullOrEmpty(SelectedValue))
                return null;
            else
                return (T)Convert.ChangeType(SelectedValue, typeof(T));
        }
        public void Reset()
        {
            ((DropDownList)((this.FindControl("uEditViewControl1")).FindControl("ddlList"))).SelectedIndex = -1;
            ((TextBox)((this.FindControl("uEditViewControl1")).FindControl("txtFreeValue"))).Text = String.Empty;
        }
        protected void BindControl()
        {
            if (Mode == ModOptions.Edit)
            {
                if (ParentControl != null)
                {
                    BindData(ParentControl.SelectedValue);
                }
                else
                    BindData(String.Empty);

            }
            else if (Mode == ModOptions.View)
            {
                SetViewData(SelectedValue);
            }

            IsBound = true;
        }


        protected virtual void CustomPageLoad()
        {
        }
        protected virtual void CustomBeforePageLoad()
        {
        }
        protected abstract void BindData(string parentSelectedValue);
        protected abstract void SetViewData(string value);

        //protected void BaseDDLUserControl_SelectedValueChanged(string value, bool isValueChanged)
        //{
        //    if (HasFreeValue)
        //    {
        //        if (value == FreeItemValue)
        //        {
        //            ((this.FindControl("uEditViewControl1")).FindControl("trFreeValue")).Visible = true;
        //            ((RequiredFieldValidator)((this.FindControl("uEditViewControl1")).FindControl("rfvFreeValue"))).Enabled = true;

        //        }
        //        else
        //        {
        //            ((this.FindControl("uEditViewControl1")).FindControl("trFreeValue")).Visible = false;
        //            ((RequiredFieldValidator)((this.FindControl("uEditViewControl1")).FindControl("rfvFreeValue"))).Enabled = false;
        //            ((Label)((this.FindControl("uEditViewControl1")).FindControl("lblValue"))).Text = String.Empty;
        //        }
        //    }
        //}
    }
}
