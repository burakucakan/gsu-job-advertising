using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GSUKariyer.COMMON;

namespace GSUKariyer.WEB.UserControls.Common.HelperControls
{
    public partial class uDateDropDown : System.Web.UI.UserControl
    {
        #region Const Values
        protected struct ViewStateKeys
        {
            public const string StartYear = "SY";
            public const string EndYear = "EY";
        }
        #endregion

        #region Properties
        public string ValidationGroup
        {
            get { return rfvDate.ValidationGroup; }
            set { rfvDate.ValidationGroup = value; }
        }
        public bool ValidationRequired
        {
            get { return rfvDate.Enabled; }
            set { rfvDate.Enabled = value; }
        }
        public string ValidationError
        {
            get { return rfvDate.ErrorMessage; }
            set { rfvDate.ErrorMessage = value; }
        }
        public DateTime? SelectedValue
        {
            get {
                return txtDate.Text.ToNullableDateTime();
            }
            set {
                if (value.HasValue)
                    txtDate.Text = value.Value.ToShortDateString();
                else
                    txtDate.Text = String.Empty;
            }
        }
        public bool Enabled
        {
            get {
                return ibtnSelect.Enabled;
            }
            set {
                txtDate.Enabled = value;
                ibtnSelect.Enabled = value;
            }
        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}