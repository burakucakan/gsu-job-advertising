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

namespace GSUKariyer.WEB.UserControls.Firm
{
    public partial class uUsers : BaseFirmUserControl
    {
        private static readonly object EventBackClick = new object();

        #region Properties
        public bool ShowBackButton
        {
            get { return lbtnOpenSearchCriteria.Visible; }
            set { lbtnOpenSearchCriteria.Visible = value; }
        }
        public event EventHandler BackClick
        {
            add { base.Events.AddHandler(EventBackClick, value); }
            remove { base.Events.RemoveHandler(EventBackClick, value); }
        }
        protected string Mode
        {
            get { return GetUrlParam(UrlHelper.PageUrl.UrlKey.Mode); }
        }
        protected string Department
        {
            get { return GetUrlParam(UrlHelper.PageUrl.UrlKey.Department); }
        }
        protected string Age
        {
            get { return GetUrlParam(UrlHelper.PageUrl.UrlKey.Age); }
        }
        protected string EducationState
        {
            get { return GetUrlParam(UrlHelper.PageUrl.UrlKey.EducationState); }
        }
        protected string WorkStatus
        {
            get { return GetUrlParam(UrlHelper.PageUrl.UrlKey.WorkStatus); }
        }
        protected string InterestedWorkingType
        {
            get { return GetUrlParam(UrlHelper.PageUrl.UrlKey.InterestedWorkType); }
        }
        
        #endregion

        Users.SearchHelper _searchHelper;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                ArrangeForm();
        }

        #region ArrangeForm/BindForm
        protected void ArrangeForm()
        {
            if (Mode == Users.SearchHelper.UsersPage.Mode.Fast)
            {
                _searchHelper = new Users.SearchHelper();
                _searchHelper.Age = Age.ToNullableInt();
                _searchHelper.EducationState = EducationState.ToNullableInt();

                int? univDepartment = Department.ToNullableInt();
                if (univDepartment.HasValue)
                    _searchHelper.UnivDepartmentList.Add(univDepartment);

                _searchHelper.InterestedWorkType = InterestedWorkingType.ToNullableInt();

                Bind(_searchHelper.Search());
            }
        }
        public void Bind(DataTable dt)
        {
            uUserList1.Bind(dt);
        }
        #endregion

        #region Button Events
        protected void lbtnOpenSearchCriteria_Click(object sender, EventArgs e)
        {
            EventHandler eventHandler = (EventHandler)base.Events[EventBackClick];
            if (eventHandler != null)
                eventHandler(this,null);
        }
        #endregion
    }
}