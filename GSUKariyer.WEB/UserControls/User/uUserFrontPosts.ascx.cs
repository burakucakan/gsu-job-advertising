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

namespace GSUKariyer.WEB.UserControls.User
{
    public partial class uUserFrontPosts : BaseStudentUserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                Bind();
        }

        protected void Bind()
        {
            DataTable dt = BUS.UserFrontPosts.GetByUserId(this.SessionManager.UserId.Value);
            DataBindHelper.BindRepeater(ref rptList, dt);
        }

        protected void imgBtnNew_Click(object sender, ImageClickEventArgs e)
        {
            string Title = Util.r(txtFrontPostTitle.Text);
            string Content = Util.r(txtFrontPostContent.Text);            

            if (Title != "")
            {
                succSave.Visible = Save(0, Title, Content);
                errSave.Visible = !succSave.Visible;
                if (succSave.Visible) {
                    txtFrontPostTitle.Text = "";
                    txtFrontPostContent.Text = "";
                    CP1.Collapsed = true;
                }
            }
        }

        protected void rptList_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
            {
                int UserFrontPostId = ((ImageButton)(e.Item.FindControl("imgBtnUpdate"))).CommandArgument.ToInt();

                PlaceHolder phEdit = (PlaceHolder)(e.Item.FindControl("phEdit"));
                PlaceHolder phView = (PlaceHolder)(e.Item.FindControl("phView"));

                string Title = ((TextBox)e.Item.FindControl("txtFrontPostTitle")).Text;
                string Content = ((TextBox)e.Item.FindControl("txtFrontPostContent")).Text;

                switch (e.CommandName)
                {
                    case "Del":
                        succDel.Visible = Del(UserFrontPostId);
                        break;
                    case "Edit":
                        phEdit.Visible = true;
                        phView.Visible = false;
                        break;
                    case "Update":
                        succUpdate.Visible = Save(UserFrontPostId, Title, Content);
                        phEdit.Visible = false;
                        phView.Visible = true;
                        break;
                }
            }
        }

        protected void rptList_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
            {
                Literal ltlContent = ((Literal)e.Item.FindControl("ltlContent"));
                ltlContent.Text = Util.Nl2Br(ltlContent.Text);
            }
        }

        private bool Del(int UserFrontPostId)
        {
            bool IsDel = BUS.UserFrontPosts.Generated.Delete(UserFrontPostId) > 0;
            Bind();
            return IsDel;
        }

        protected bool Save(int UserFrontPostId, string Title, string Content)
        {
            bool IsSucc = false;
            if (UserFrontPostId == 0)
                IsSucc = BUS.UserFrontPosts.Generated.Add(this.SessionManager.UserId.Value, Title, Content) > 0;
            else
                IsSucc = BUS.UserFrontPosts.Generated.Update(UserFrontPostId, this.SessionManager.UserId.Value, Title, Content) > 0;

            Bind();

            return IsSucc;
        }
    }
}