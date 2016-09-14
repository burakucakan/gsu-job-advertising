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

namespace GSUKariyer.WEB
{
    public partial class _DefMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Prep();
            }
        }

        protected void Prep()
        {
            try
            {

                //SetBaseTarget();
                //this.Head1.Controls.AddAt(0, new BaseTag(Request));

                //www olmadan girişi engellemek
                if ((Request != null) && (Request.Url != null) && (Request.Url.AbsoluteUri.IndexOf("http://gsukariyer") != -1))
                    Response.Redirect("http://www.gsukariyer.com");
            }
            catch (Exception) {}

            hlLogo.NavigateUrl = "~/Kariyer.aspx";
        }

    }


    public class BaseTag : HtmlControl
    {
        public BaseTag(HttpRequest Request)
            : base("base")
        {
            string value = Request.Url.Scheme + "://" + Request.Url.Authority + Request.ApplicationPath ;
            if (Request.Url.Authority.IndexOf("localhost") > -1)
                value = String.Concat(value, "/");

            base.Attributes.Add("href", value);
        }
    }
}
