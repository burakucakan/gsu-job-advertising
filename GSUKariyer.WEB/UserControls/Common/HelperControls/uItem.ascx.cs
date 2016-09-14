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

namespace GSUKariyer.WEB.UserControls.Common.HelperControls
{
    public partial class uItem : BaseUserControl
    {
        private static readonly object EventItemEdit = new object();
        private static readonly object EventItemRemove = new object();

        public delegate void ItemOnEdit_EventHandler(BaseUserControl sender,string value, string parentControlId);
        public delegate void ItemOnRemove_EventHandler(BaseUserControl sender,string value, string parentControlId);

        #region Properties
        public string Text { set { lblText.Text = value; } }
        public string ParentUserControlId
        {
            get { return (ViewState["IPUCID"] == null ? String.Empty : ViewState["IPUCID"].ToString()); }
            set { ViewState["IPUCID"] = value; }
        }
        public bool IsRemove { set { lbtnRemove.Visible = value; } }
        public bool IsView { set { hlView.Visible = value; } }
        public bool IsEdit { set { lbtnEdit.Visible = value; } }
        public bool CanEdit {
            set { 
                lbtnEdit.Enabled = value;
                lbtnRemove.Enabled = value;
            }
            get {
                return (lbtnEdit.Visible ? lbtnEdit.Enabled : lbtnRemove.Enabled);
            }
        }

        public string ViewURL { set { hlView.NavigateUrl = value; } }

        public event ItemOnEdit_EventHandler ItemEdit
        {
            add { base.Events.AddHandler(EventItemEdit, value); }
            remove { base.Events.RemoveHandler(EventItemEdit, value); }
        }
        public event ItemOnRemove_EventHandler ItemRemove
        {
            add { base.Events.AddHandler(EventItemRemove, value); }
            remove { base.Events.RemoveHandler(EventItemRemove, value); }
        }
        public string ItemViewUrl
        {
            get { return hlView.NavigateUrl; }
            set { hlView.NavigateUrl = value; }
        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        #region LinkButtonEvents
        protected void lbtnEdit_OnClick(object sender, EventArgs e)
        {
            ItemOnEdit_EventHandler handler = (ItemOnEdit_EventHandler)base.Events[EventItemEdit];
            if (handler != null)
                handler(this, this.SpecialValue, this.ParentUserControlId);
            
        }
        protected void lbtnRemove_OnClick(object sender, EventArgs e)
        {
            ItemOnRemove_EventHandler handler = (ItemOnRemove_EventHandler)base.Events[EventItemRemove];
            if (handler != null)
                handler(this, this.SpecialValue, this.ParentUserControlId);
        }
        #endregion
    }
}