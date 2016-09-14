using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;

namespace GSUKariyer.COMMON.Helpers.WEB
{
    public class RepeaterHelper
    {
        public static T GetControl<T>(object webControl, string controlId)
        {
            return (T)((object)((RepeaterItem)((WebControl)webControl).NamingContainer).FindControl(controlId));
        }

        public static T GetControl<T>(WebControl webControl, string controlId)
        {
            return (T)((object)((RepeaterItem)webControl.NamingContainer).FindControl(controlId));
        }

        public static T GetControl<T>(RepeaterItem rptItem, string controlId)
        {
            return (T)((object)(rptItem.FindControl(controlId)));
        }

        public static RepeaterItem GetRepeaterItem(object webControl)
        {
            return (RepeaterItem)((WebControl)webControl).NamingContainer;
        }



        //public class CustomRepeaterHeader : ITemplate
        //{
        //    private string[] columnList = null;
        //    public CustomRepeaterHeader(string[] columnList)
        //    {
        //        this.columnList = columnList;
        //    }


        //    #region ITemplate Members

        //    public void InstantiateIn(Control container)
        //    {
        //        if (columnList != null)
        //        {
        //            for (int cntr = 0; cntr < columnList.Length; cntr++)
        //            {


        //            }

        //        }
        //    }

        //    #endregion
        //}

    }
}
