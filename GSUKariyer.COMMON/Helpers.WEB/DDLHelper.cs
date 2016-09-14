using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace GSUKariyer.COMMON.Helpers.WEB
{
    public class DDLHelper
    {
        public static void BindDDL(System.Web.UI.WebControls.DropDownList ddlControl, DataTable dt, string DataTextField, string DataValueField, string SelectedValue, string InitialValueText, string InitialValue)
        {
            ddlControl.DataTextField = DataTextField;
            ddlControl.DataValueField = DataValueField;
            ddlControl.DataSource = dt;
            ddlControl.DataBind();

            if ((!string.IsNullOrEmpty(InitialValueText)))
            {
                ddlControl.Items.Insert(0, new System.Web.UI.WebControls.ListItem(InitialValueText, InitialValue));
            }

            if ((!string.IsNullOrEmpty(SelectedValue)))
            {
                ddlControl.SelectedValue = SelectedValue;
            }
        }
        public static void BindDDL(System.Web.UI.WebControls.DropDownList ddlControl, DataTable dt, string DataTextField, string DataValueField, string SelectedValue)
        {
            BindDDL(ddlControl, dt, DataTextField, DataValueField, SelectedValue, "", "");
        }
        public static void LoadNumberDDL(System.Web.UI.WebControls.DropDownList ddl, int Count, int UpStep, int StartNumber)
        {
            ddl.Items.Clear();
            for (int i = StartNumber; i <= Count; i += UpStep)
            {
                ddl.Items.Add(new System.Web.UI.WebControls.ListItem(i.ToString(), i.ToString()));
            }
        }
        public static void LoadNumberDDL(ref System.Web.UI.WebControls.DropDownList ddl, int count)
        {
            LoadNumberDDL(ddl, count, 1, 1);
        }
    }
}
