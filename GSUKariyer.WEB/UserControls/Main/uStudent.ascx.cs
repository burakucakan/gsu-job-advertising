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
using GSUKariyer.COMMON;
using GSUKariyer.BUS;

namespace GSUKariyer.WEB.UserControls.Main
{
    public partial class uStudent : BaseStudentUserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Arrange();
            }
        }

        protected void Arrange()
        {
            hlMostSuitable.NavigateUrl = UrlHelper.PageUrl.Advertisements(BUS.Advertisements.SearchHelper.AdvertisementsPage.Mode.MostSuitable, true.ToString());
            hlUserApplications.NavigateUrl = UrlHelper.PageUrl.UserApplications();
            hlCvAdd.NavigateUrl=UrlHelper.PageUrl.CvAdd() ;

            BUS.Advertisements.SearchHelper searchHelper = new BUS.Advertisements.SearchHelper();
            searchHelper.UsersSuitableAdv.UserId = SessionManager.UserId.Value;
            uAdvertisementThumbList1.Bind(searchHelper.Search());

            DataTable dtCvs = Users.Cv.Get(SessionManager.UserId.Value);
            DataTable dtCvsLive = dtCvs.Clone();
            foreach (DataRow dr in dtCvs.Rows)
                if (dr[BUS.CVs.ColumnNames.CVState].ToInt() < (int)BUS.CVs.CVState.Deleted)
                    dtCvsLive.Rows.Add(dr.ItemArray);


            rptCvs.Visible = dtCvsLive.Rows.Count > 0;

            DataBindHelper.BindRepeater(ref rptCvs, dtCvsLive);

            hlCvAdd.Visible = (dtCvsLive.Rows.Count < 3);

            UserApplications();
        }

        protected void UserApplications()
        {            
            DataTable dtUserApplicationList = BUS.AdvertisementApplications.GetUserApplicationsTop(this.SessionManager.UserId.Value);            
            uUserApplicationList1.Bind(dtUserApplicationList);
            hlUserApplications.Visible = dtUserApplicationList.Rows.Count > 0;
            uUserApplicationList1.PagingShow = false;
        }

        #region RepeaterEvents
        protected string ArrangeViewUrl(string cvId)
        {
            return UrlHelper.PageUrl.Cv(cvId.ToInt(), this.SessionManager.Name, this.SessionManager.Surname); 
        }
        protected void uCv_ItemEdit(BaseUserControl sender, string value, string parentControlId)
        {            
            Response.Redirect(UrlHelper.PageUrl.CvEdit(value.ToInt()));
        }
        protected void uCv_ItemRemove(BaseUserControl sender, string value, string parentControlId)
        {
            //TODO : Not to delete now
            //CVs.Generated.Delete(value.ToInt());
        }
        #endregion

        protected void rptCvs_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
            {
                Literal ltlLanguage = (Literal)e.Item.FindControl("ltlLanguage");
                ltlLanguage.Text = CVs.Languages.Options.Get(ltlLanguage.Text);

                bool IsDefaultCv = bool.Parse(((HiddenField)e.Item.FindControl("hdDefaultCv")).Value);
                LinkButton lnkDefaultCv = (LinkButton)e.Item.FindControl("lnkDefaultCv");
                Image imgCheckedCv = (Image)e.Item.FindControl("imgCheckedCv");
                lnkDefaultCv.Visible = !IsDefaultCv;
                imgCheckedCv.Visible = !lnkDefaultCv.Visible;

                string eCvStateID = "";
                Literal ltlCvState = (Literal)e.Item.FindControl("ltlCvState");
                switch (ltlCvState.Text.ToInt())
                {
                    case BUS.CVs.CVState.Active:
                        eCvStateID = "lnkCvStateActive";
                        break;
                    case BUS.CVs.CVState.Passive:
                        eCvStateID = "lnkCvStatePassive";
                        break;
                }

                LinkButton lnkCvState = (LinkButton)e.Item.FindControl(eCvStateID);
                lnkCvState.Visible = true;
            }
        }

        protected void rptCvs_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
            {
                int CvId = e.CommandArgument.ToInt();
                switch (e.CommandName)
                {
                    case "DefaultCv":
                        BUS.CVs.CvDefault(this.SessionManager.UserId.Value, CvId);
                        break;
                    case "Del":
                        BUS.CVs.Delete(CvId);                        
                        break;
                    case "CvStateActive":
                        CVs.CVState.Update(CvId, CVs.CVState.Passive, DateTime.Now);
                        break;
                    case "CvStatePassive":
                        CVs.CVState.Update(CvId, CVs.CVState.Active, DateTime.Now);
                        break;
                }
                Response.Redirect(UrlHelper.PageUrl.Student());
            }
        }
    }
}