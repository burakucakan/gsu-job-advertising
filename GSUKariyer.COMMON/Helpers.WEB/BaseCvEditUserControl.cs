using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;

namespace GSUKariyer.COMMON.Helpers.WEB
{
    public class BaseCvEditUserControl : BaseUserControl
    {
        #region ConstValues
        protected static readonly object SubmitEvent = new object();
        protected struct ViewStateKeys
        {
            public const string CvLanguage = "CvLanguage";
        }
        protected struct ControlId
        {
            public const string imgBtnSend = "imgBtnSend";
        }
        #endregion

        #region Properties
        public event EventHandler SubmitForm
        {
            add { this.Events.AddHandler(SubmitEvent, value); }
            remove { this.Events.RemoveHandler(SubmitEvent, value); }
        }
        public virtual int ControlOrder
        {
            get { return 0; }
        }
        public virtual string ValidationGroup
        {
            get { 
                return ((ImageButton)this.FindControl(ControlId.imgBtnSend)).ValidationGroup; 
            }
        }
        protected bool IsNewCV
        {
            get
            {
                return String.IsNullOrEmpty(GetUrlParam(UrlHelper.PageUrl.UrlKey.Id));
            }
        }
        protected int? CVId
        {
            get
            {
                return GetUrlParam<int>(UrlHelper.PageUrl.UrlKey.Id);
            }
        }
        protected int? UserId
        {
            get
            {
                return SessionManager.UserId;
            }
        }
        #endregion

        protected void Submit()
        {
            EventHandler eventHandler = (EventHandler)this.Events[SubmitEvent];

            if (eventHandler != null)
                eventHandler(this, null);
        }
    }
}
