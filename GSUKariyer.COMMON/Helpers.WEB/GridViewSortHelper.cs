using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GSUKariyer.COMMON.Helpers.WEB
{
    public class GridViewSortHelper : Control
    {
        protected const string AscendingStr = "ASC";
        protected const string DescendingStr = "DESC";
        protected const string AscendingImageUrl = @"~/ServicingSitePages/Images/Design/sort.gif";
        protected const string DescendingImageUrl = @"~/ServicingSitePages/Images/Design/rsort.gif";

        public delegate void BindForm_EventHandler();
        protected GridView _gridView;
        protected BindForm_EventHandler _bindFormFunction = null;
        protected StateBag _parentControlViewState;

        #region Properties
        public string SortString
        {
            get
            {
                if (String.IsNullOrEmpty(SortExpression))
                    return String.Empty;

                string previousSortString = String.Empty;

                if (!String.IsNullOrEmpty(PreviousSortExpression))
                {
                    previousSortString = String.Format(",{0} {1}", PreviousSortExpression,
                        ConvertSortDirectionToStr(PreviousControlSortDirection));
                }

                return String.Format("{0} {1}{2}", SortExpression, ConvertSortDirectionToStr(
                    ControlSortDirection), previousSortString);
            }
        }
        protected string SortExpression
        {
            get { return (_parentControlViewState["GVSE"] == null ? String.Empty : _parentControlViewState["GVSE"].ToString()); }
            set { _parentControlViewState.Add("GVSE", value); }
        }
        protected SortDirection ControlSortDirection
        {
            get
            {
                return (_parentControlViewState["GVSD"] == null ? System.Web.UI.WebControls.SortDirection.Ascending :
                    (System.Web.UI.WebControls.SortDirection)_parentControlViewState["GVSD"]);
            }
            set { _parentControlViewState.Add("GVSD", value); }
        }

        protected string PreviousSortExpression
        {
            get { return (_parentControlViewState["GVPSE"] == null ? String.Empty : _parentControlViewState["GVPSE"].ToString()); }
            set { _parentControlViewState.Add("GVPSE", value); }
        }
        protected SortDirection PreviousControlSortDirection
        {
            get
            {
                return (_parentControlViewState["GVPSD"] == null ? System.Web.UI.WebControls.SortDirection.Ascending :
                    (System.Web.UI.WebControls.SortDirection)_parentControlViewState["GVPSD"]);
            }
            set { _parentControlViewState.Add("GVPSD", value); }
        }
        #endregion

        #region Constructers
        public GridViewSortHelper(GridView gridView, BindForm_EventHandler bindFormFunction, StateBag parentControlViewState)
            : base()
        {
            gridView.Sorting += new GridViewSortEventHandler(gridView_Sorting);
            gridView.RowCreated += new GridViewRowEventHandler(gridView_RowCreated);
            _gridView = gridView;
            _bindFormFunction = bindFormFunction;
            _parentControlViewState = parentControlViewState;
        }
        #endregion

        #region Public Functions
        public void ResetSort()
        {
            SortExpression = String.Empty;
            ControlSortDirection = SortDirection.Ascending;
        }
        #endregion

        #region Gridview Events
        protected void gridView_Sorting(object sender, GridViewSortEventArgs e)
        {
            if (SortExpression != e.SortExpression)
            {
                PreviousSortExpression = SortExpression;
                PreviousControlSortDirection = ControlSortDirection;
            }

            if (SortExpression == e.SortExpression)
            {
                ControlSortDirection =
                    (ControlSortDirection == SortDirection.Ascending) ? SortDirection.Descending : SortDirection.Ascending;
            }
            else
            {
                ControlSortDirection = SortDirection.Ascending;
            }

            SortExpression = e.SortExpression;
            if (_bindFormFunction != null)
                _bindFormFunction();
        }
        protected void gridView_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (String.IsNullOrEmpty(SortExpression))
                return;

            if (e.Row.RowType == DataControlRowType.Header)
            {
                int cellIndex = -1;
                bool cellFound = false;

                for (int i = 0; i < _gridView.Columns.Count; i++)
                {
                    if (_gridView.Columns[i].Visible)
                        cellIndex++;

                    if (SortExpression == _gridView.Columns[i].SortExpression)
                    {
                        cellFound = true;
                        break;
                    }
                }

                if (cellFound)
                {
                    Image sortImage = new Image();
                    Label space = new Label();

                    sortImage.ImageUrl = (
                        ControlSortDirection ==
                        SortDirection.Ascending ? AscendingImageUrl : DescendingImageUrl);
                    sortImage.Visible = true;
                    space.Text = " ";


                    e.Row.Cells[cellIndex].Controls.Add(space);
                    e.Row.Cells[cellIndex].Controls.Add(sortImage);
                }
            }
        }
        #endregion

        #region Others
        protected string ConvertSortDirectionToStr(SortDirection sortDirection)
        {
            return (sortDirection == System.Web.UI.WebControls.SortDirection.Ascending ? AscendingStr : DescendingStr);
        }
        #endregion
    }
}
