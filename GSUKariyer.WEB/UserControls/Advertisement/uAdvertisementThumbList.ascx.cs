using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GSUKariyer.COMMON.Helpers.WEB;
using System.Data;

namespace GSUKariyer.WEB.UserControls.Advertisement
{
    public partial class uAdvertisementThumbList : BaseUserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void Bind(DataTable dt)
        {
            rptJob.DataSource = dt;
            rptJob.DataBind();
        }
    }
}