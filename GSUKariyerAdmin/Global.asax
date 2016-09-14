<%@ Application Language="C#" %>

<script runat="server">

    void Application_Start(object sender, EventArgs e) 
    {
        // Code that runs on application startup

    }
    
    void Application_End(object sender, EventArgs e) 
    {
        //  Code that runs on application shutdown

    }

    void Application_Error(object sender, EventArgs e)
    {
        if (!GSUKariyer.COMMON.Util.IsLocal())
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
                string Subject = "GsuKariyer.com Admin | Hata";
                string msgBody = errMsg;

                GSUKariyer.COMMON.Mailing Mail = new GSUKariyer.COMMON.Mailing();
                Mail.Send("burak@bgapartners.net", Subject, msgBody, "", "ufukaslan@gmail.com", System.Net.Mail.MailPriority.High, true);
            }
            catch (Exception) { }

            Server.ClearError();
        }
    }

    void Session_Start(object sender, EventArgs e) 
    {
        // Code that runs when a new session is started

    }

    void Session_End(object sender, EventArgs e) 
    {
        // Code that runs when a session ends. 
        // Note: The Session_End event is raised only when the sessionstate mode
        // is set to InProc in the Web.config file. If session mode is set to StateServer 
        // or SQLServer, the event is not raised.

    }
       
</script>
