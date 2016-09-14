using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using GSUKariyer.COMMON;

public partial class _private_EncDec : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnEnc_Click(object sender, EventArgs e)
    {
        Label1.Text = Encryption.Encrypt(TextBox1.Text);
    }
    protected void btnDec_Click(object sender, EventArgs e)
    {
        Label1.Text = Encryption.Decrypt(TextBox1.Text);
    }
}
