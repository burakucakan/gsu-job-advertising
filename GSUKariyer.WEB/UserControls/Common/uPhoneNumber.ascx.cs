using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GSUKariyer.WEB.UserControls.Common
{
    public partial class uPhoneNumber : System.Web.UI.UserControl
    {
        protected const string splitter = "-";

        public string ValidationGroup
        {
            get { return rfvPhoneNo.ValidationGroup; }
            set { 
                rfvPhoneNo.ValidationGroup = value;
                rfvCountryCode.ValidationGroup = value;
            }
        }
        public bool ValidationRequired
        {
            get { return rfvPhoneNo.Enabled; }
            set { 
                rfvPhoneNo.Enabled = value;
                rfvCountryCode.Enabled = value;
            }
        }
        public string ValidationError
        {
            get { return rfvPhoneNo.ErrorMessage; }
            set { rfvPhoneNo.ErrorMessage = value; }
        }
        public string Value
        {
            get { return String.Concat(txtCountryCode.Text.Trim(),splitter,txtPhoneNo.Text.Trim()); }
            set {
                if (value.IndexOf(splitter) != -1)
                {
                    string[] phoneAtoms=value.Split(new string[] { splitter }, 
                        StringSplitOptions.RemoveEmptyEntries);
                    if (phoneAtoms.Length == 2)
                    {
                        txtCountryCode.Text = phoneAtoms[0];
                        txtPhoneNo.Text = phoneAtoms[1];
                    }
                }
                else
                {
                    txtCountryCode.Text = String.Empty;
                    txtPhoneNo.Text = String.Empty;
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}