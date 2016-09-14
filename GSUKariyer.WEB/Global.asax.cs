using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Xml.Linq;
using GSUKariyer.COMMON.Helpers.WEB;
using GSUKariyer.COMMON;

namespace GSUKariyer.WEB
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {

        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        //protected void Application_Error(object sender, EventArgs e)
        //{
            
        //    //Gets Last Exception
        //    Exception appException = Server.GetLastError();
        //    Server.ClearError();

        //    //((HttpApplication)sender).Context.Request
        //    //Logs Error
        //    Logger.LogErrors(appException.Message);
        //    Application.Add(SessionHelper.Keys.CurrentError, appException.Message);

        //    //if (PageHelper.GetPageName() != 
        //    //    UrlHelper.PageUrl.PageName.Error)
        //    //{
        //    //    Response.Redirect(UrlHelper.PageUrl.PageName.Error);
        //    //}             
        //}


        void Application_Error(object sender, EventArgs e)
        {
            if (!Util.IsLocal())
            {
                Exception ex = Server.GetLastError().GetBaseException();

                string errMsg = "";
                errMsg = "<br><b>Hata Tarihi :</b>" + DateTime.Now;
                errMsg += "<br><br><br>b>Hata Mesajı : </b>" + ex.Message;
                errMsg += "<br><br><b>Hata Sayfa ve Konumu :</b>" + ex.StackTrace;

                errMsg += "<br><br><br><b><u>QueryString Bilgileri</u></b>";
                for (int x = 0; x < Request.QueryString.Count; x++)
                    errMsg += "<li>" + Request.QueryString.Keys[x] + " : " + Request.QueryString[x];

                errMsg += "<br><br><br><b><u>Form Bilgileri</u></b>";
                for (int x = 0; x < Request.Form.Count; x++)
                    errMsg += "</li><li>" + Request.Form.Keys[x] + " : " +
                        Request.Form[x] + "";

                errMsg += "<br><br><br><b><u>Sunucu Değişken Bilgileri</u></b>";
                for (int x = 0; x < Request.ServerVariables.Count; x++)
                    errMsg += "</li><li>" + Request.ServerVariables.Keys[x] + " : " +
                        Request.ServerVariables[x] + "";

                try
                {
                    string Subject = "GsuKariyer.com | Hata";
                    string msgBody = errMsg;

                    Mailing Mail = new Mailing();
                    Mail.Send("burak@bgapartners.net", Subject, msgBody, "", "ufukaslan@gmail.com", System.Net.Mail.MailPriority.High, true);
                }
                catch (Exception) { }

                Server.ClearError();
            }
        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}