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

namespace GSUKariyer.WEB._Private
{
    public partial class Password : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnEnc_Click(object sender, EventArgs e)
        {
            Label1.Text = GSUKariyer.COMMON.Encryption.Encrypt(TextBox1.Text);
        }
        protected void btnDec_Click(object sender, EventArgs e)
        {
            Label1.Text = GSUKariyer.COMMON.Encryption.Decrypt(TextBox1.Text);
        }
    }
}
