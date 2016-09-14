using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using GSUKariyer.COMMON.Helpers.WEB;

namespace GSUKariyer.WEB.UserControls.Common
{
    public partial class uPagingPostback1 : System.Web.UI.UserControl
    {
        private static object PageChangedEvent = new object();

        public enum ObjectTypes
        {
            Repeater = 0,
            DataList = 1
        }

        #region Properties
        public event EventHandler PageChanged
        {
            add
            {
                base.Events.AddHandler(PageChangedEvent, value);
            }
            remove
            {
                base.Events.RemoveHandler(PageChangedEvent, value);
            }
        }
        public string RecordCountTitle
        {
            set { ltlRecordCountTitle.Text = value; }
            get { return ltlRecordCountTitle.Text; }
        }
        public int PagerCurrentPage
        {
            get { return CurrentPage; }
        }
        public int PagerHeight
        {
            get { return 41; }
        }
        public int PageSize
        {
            get
            {
                return (ViewState["PageSize"] == null ? 10 : int.Parse(ViewState["PageSize"].ToString()));
            }
            set
            {
                ViewState["PageSize"] = value;
            }
        }

        private int AddedPageSize
        {
            get
            {
                return (ViewState["APageSize"] == null ? 10 : int.Parse(ViewState["APageSize"].ToString()));
            }
            set
            {
                ViewState["APageSize"] = value;
            }
        }
        private int CurrentPage
        {
            get
            {
                return (ViewState["CurrentPage"] == null ? 0 : int.Parse(ViewState["CurrentPage"].ToString()));
            }
            set
            {
                ViewState["CurrentPage"] = value;
            }
        }
        private int RecordCount
        {
            get
            {
                return (ViewState["RC"] == null ? 0 : int.Parse(ViewState["RC"].ToString()));
            }
            set
            {
                ViewState["RC"] = value;
            }
        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        #region Public
        public void SetPager(int PageSize, bool ShowPageSize, string RecordCountTitle)
        {
            this.AddedPageSize = PageSize;
            this.PageSize = PageSize;
            this.RecordCountTitle = RecordCountTitle;
        }
        public void GeneratePager(DataTable dt, object BindObject, ObjectTypes ObjectType)
        {
            PagedDataSource pds = new PagedDataSource();
            pds.DataSource = dt.DefaultView;
            pds.AllowPaging = true;
            pds.PageSize = this.PageSize;
            pds.CurrentPageIndex = this.CurrentPage;
            this.RecordCount = pds.DataSourceCount;

            switch (ObjectType)
            {
                case ObjectTypes.Repeater:
                    ((Repeater)BindObject).DataSource = pds;
                    ((Repeater)BindObject).DataBind();
                    break;
                case ObjectTypes.DataList:
                    ((DataList)BindObject).DataSource = pds;
                    ((DataList)BindObject).DataBind();
                    break;
            }

            GeneratePager();
        }
        public void ResetPager(bool ResetPageSize)
        {
            this.CurrentPage = 1;
            if (ResetPageSize)
            {
                PageSize = AddedPageSize;
                OnPagerChangedEvent();
            }
        }
        #endregion

        #region private
        private void GeneratePager()
        {
            int MaxPageSize = 30;
            int PageSizeUp = 5;

            if (RecordCount > PageSize)
            {
                this.Visible = true;

                int ConfigPageSize = this.PageSize;

                int MaxPageNumber = Convert.ToInt32(Math.Ceiling((decimal)RecordCount / (decimal)ConfigPageSize));

                lblRecordCount.Text = RecordCount.ToString();
                if (!IsPostBack)
                {
                    DDLHelper.LoadNumberDDL(ddlPageSize, MaxPageSize, PageSizeUp, PageSizeUp);
                    //ddlPageSize
                }

                if (AddedPageSize > MaxPageSize)
                {
                    ddlPageSize.Items.Add(new ListItem(AddedPageSize.ToString(), AddedPageSize.ToString()));
                }
                else
                {
                    int maxddlPageSize = ddlPageSize.Items.Count;
                    for (int i = 0; i < maxddlPageSize; i++)
                    {
                        if (int.Parse(ddlPageSize.Items[i].Value) == AddedPageSize)
                            break;

                        if (int.Parse(ddlPageSize.Items[i].Value) > AddedPageSize)
                        {
                            ddlPageSize.Items.Insert(i, new ListItem(AddedPageSize.ToString(), AddedPageSize.ToString()));
                            break;
                        }
                    }
                }

                ddlPageSize.SelectedValue = PageSize.ToString();
                MaxPageNumber = Convert.ToInt32(Math.Ceiling((decimal)RecordCount / (decimal)PageSize));

                DDLHelper.LoadNumberDDL(ddlPageNumber, MaxPageNumber, 1, 1);
                //ddlPageNumber

                ddlPageNumber.SelectedValue = ((int)(CurrentPage + 1)).ToString();

                if (int.Parse(ddlPageNumber.SelectedValue) > 1)
                {
                    hlPrevious.Enabled = true;
                    //hlPrevious
                }
                else { hlPrevious.Enabled = false; }

                if (int.Parse(ddlPageNumber.SelectedValue) + 1 <= MaxPageNumber)
                {
                    hlNext.Enabled = true;
                    //hlNext
                }
                else { hlNext.Enabled = false; }

                dvPagingPanel.Visible = true;
            }
            else
            {
                this.Visible = false;
                dvPagingPanel.Visible = false;
            }

        }

        protected virtual void OnPagerChangedEvent()
        {
            // Check if there are any subscribers before throwing the Event
            EventHandler eventHandler = (EventHandler)base.Events[PageChangedEvent];
            if (eventHandler != null)
            {
                eventHandler(this, null);
            }
        }
        protected void hlPrevious_Click(object sender, EventArgs e)
        {
            if (CurrentPage > 0)
            {
                CurrentPage = CurrentPage - 1;
                OnPagerChangedEvent();
            }
        }
        protected void hlNext_Click(object sender, EventArgs e)
        {
            CurrentPage = CurrentPage + 1;
            OnPagerChangedEvent();
        }
        protected void ddlPageNumber_SelectedIndexChanged(object sender, EventArgs e)
        {
            CurrentPage = (int.Parse(ddlPageNumber.SelectedValue)) - 1;
            //JScripts.GotoPageTop();
            OnPagerChangedEvent();
        }
        protected void ddlPageSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            CurrentPage = 0;
            PageSize = int.Parse(ddlPageSize.SelectedValue);
            OnPagerChangedEvent();
        }
        #endregion
    }
}