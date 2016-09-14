using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace GSUKariyer.WEB.UserControls.Common.HelperControls
{
    public partial class uNumericDropdown : System.Web.UI.UserControl
    {
        protected struct BindColumns
        {
            public const string Description = "Desc";
            public const string Value = "Value";
        }
        protected bool _isBind = false;
        protected int _maxValue = 10;
        protected int _minValue = 1;
        protected bool _orderAsc = true;

        #region Properties
        public int MaxValue
        {
            get { return _maxValue; }
            set { 
                _maxValue = value;
                Bind();
            }
        }
        public int MinValue
        {
            get { return _minValue; }
            set
            {
                _minValue = value;
                Bind();
            }
        }
        public bool OrderAsc 
        {
            get { return _orderAsc; }
            set
            {
                _orderAsc = value;
            }
        }
        public string ValidationGroup
        {
            get { return rfvNumbers.ValidationGroup; }
            set { rfvNumbers.ValidationGroup = value; }
        }
        public string ValidationMessage
        {
            get { return rfvNumbers.ErrorMessage; }
            set { rfvNumbers.ErrorMessage = value; }
        }
        public bool ValidationRequired
        {
            get { return rfvNumbers.Enabled; }
            set { rfvNumbers.Enabled = value; }
        }
        public bool ClientValidationEnabled
        {
            get { return rfvNumbers.EnableClientScript; }
            set { rfvNumbers.EnableClientScript = value; }
        }
        public string SelectedValue
        {
            get { return ddlNumbers.SelectedValue; }
            set { ddlNumbers.SelectedValue = value; }
        }

        public string ClientID
        {
            get { return ddlNumbers.ClientID; }
        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if ((!IsPostBack) && _isBind == false)
                Bind();
        }
        public void Bind()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(BindColumns.Value, System.Type.GetType("System.Int32"));
            dt.Columns.Add(BindColumns.Description);

            for (int i = MinValue; i <= MaxValue; i++)
            {
                DataRow dr = dt.NewRow();
                dr[BindColumns.Description] = i.ToString();
                dr[BindColumns.Value] = i;
                dt.Rows.Add(dr);
            }

            if (!OrderAsc)
            {
                dt.DefaultView.Sort = String.Format("{0} DESC",BindColumns.Value);
                dt=dt.DefaultView.ToTable();
            }

            DataRow drSelect = dt.NewRow();
            drSelect[BindColumns.Description] = "...";
            drSelect[BindColumns.Value] = DBNull.Value;
            dt.Rows.InsertAt(drSelect,0);

            ddlNumbers.DataSource = dt;
            ddlNumbers.DataValueField = BindColumns.Value;
            ddlNumbers.DataTextField = BindColumns.Description;
            ddlNumbers.DataBind();
        }
    }
}