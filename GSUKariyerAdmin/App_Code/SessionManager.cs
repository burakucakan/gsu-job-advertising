using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections;

public class SM : System.Web.UI.UserControl
{
    private void SET(EnumUtil.Sess SessionName, object Value) { System.Web.HttpContext.Current.Session[SessionName.ToString()] = Value; }
    private object GET(EnumUtil.Sess SessionName) { return System.Web.HttpContext.Current.Session[SessionName.ToString()]; }

    public bool smIsLogin
    {
        get { return (GET(EnumUtil.Sess.IsLogin) == null ? false : Convert.ToBoolean(GET(EnumUtil.Sess.IsLogin).ToString())); }
        set { SET(EnumUtil.Sess.IsLogin, value); }
    }


    public int smAdminID
    {
        get { return (GET(EnumUtil.Sess.AdminID) == null ? 0 : (int)GET(EnumUtil.Sess.AdminID)); }
        set { SET(EnumUtil.Sess.AdminID, value); }
    }

    public DataTable smPermissions
    {
        get { return (GET(EnumUtil.Sess.Permissions) == null ? null : (DataTable)GET(EnumUtil.Sess.Permissions)); }
        set { SET(EnumUtil.Sess.Permissions, value); }
    }

    public string smPhoto
    {
        get { return (GET(EnumUtil.Sess.Photo) == null ? String.Empty : GET(EnumUtil.Sess.Photo).ToString()); }
        set { SET(EnumUtil.Sess.Photo, value); }
    }

}