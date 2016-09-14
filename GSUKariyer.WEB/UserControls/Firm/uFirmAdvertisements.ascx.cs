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
using GSUKariyer.COMMON.Helpers.WEB;

namespace GSUKariyer.WEB.UserControls.Firm
{
    public partial class uFirmAdvertisements : BaseFirmUserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                Bind();
        }

        protected void Bind()
        {            
            DataTable dt = BUS.Advertisements.GetFirmAdvertisements(this.SessionManager.FirmId, GSUKariyer.BUS.Advertisements.State.Live);
            uFirmAdvertisementList1.Bind(dt);
        }

        protected void Search()
        {
            BUS.Advertisements.State AdvertisementsState = GSUKariyer.BUS.Advertisements.State.Archive;
            string Title = "";
            DateTime StartDate = DateTime.MinValue;
            DateTime EndDate = DateTime.MaxValue;

            DataTable dt = BUS.Advertisements.GetFirmAdvertisements(this.SessionManager.FirmId, AdvertisementsState, Title, StartDate, EndDate);
            uFirmAdvertisementList1.Bind(dt);
        }

        protected void lnkArchive_Click(object sender, EventArgs e)
        {
            Search();
            lnkArchive.Visible = false;
            lnkLive.Visible = true;
        }

        protected void lnkLive_Click(object sender, EventArgs e)
        {
            Bind();
            lnkArchive.Visible = true;
            lnkLive.Visible = false;
        }        
    }
}