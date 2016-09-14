using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Configuration;
using System.Web;
using System.Net.Mail;

namespace GSUKariyer.COMMON
{
    public class Mail
    {
        private static string MailTemplateFileDefault = ConfigurationManager.AppSettings["MailTempletePath"].ToString();
        private static string MailMainDefault = ConfigurationManager.AppSettings["MailMain"].ToString();
        private static string AppURLDefault = Util.ApplicationRootPath();

        private Mailing objMail;
        private string appURL = Util.ApplicationRootPath();
        private string _MailTemplateFile = "MailTemplates/Default.htm";
        private string _MailTemplate = String.Empty;
        private string _MailMain = ConfigurationManager.AppSettings["MailMain"].ToString();

        private string _Subject = String.Empty;
        private string _Title = String.Empty;
        private StringBuilder _Content = new StringBuilder();
        public Mail()
            : this(MailTemplateFileDefault, MailMainDefault,AppURLDefault)
        {

        }

        public Mail(string MailTemplateFile, string MailMain,string appUrl)
        {
            objMail = new Mailing();

            _MailMain = MailMain;
            _MailTemplateFile = MailTemplateFile;
            this.appURL = appUrl;

            try
            {
                StreamReader sr = new StreamReader(this._MailTemplateFile, Encoding.GetEncoding("iso-8859-9"));
                this._MailTemplate = sr.ReadToEnd();
                sr.Close();
            }
            catch (Exception)
            {
                this._MailTemplate = "||TITLE|| <br><br> ||CONTENT||";
            }
        }

        public bool SendPassword(string To, string Password)
        {
            this._Subject = "GsuKariyer.com Şifre Hatırlatma";
            this._Title = "ŞİFRE HATIRLATMA";
            this._Content.Append("GsuKariyer.com’a giriş yapmanız için gerekli şifreniz aşağıda belirtilmiştir");
            this._Content.Append("<br><br>");
            this._Content.Append("Şifreniz: <b>");
            this._Content.Append(Password);
            this._Content.Append("</b>");
            return Send(To);
        }

        public bool SendActivate(string To, string ActivationCode)
        {
            string URL = this.appURL + "UserActivation.aspx?AC=" + ActivationCode;
            this._Subject = "GsuKariyer.com Üyelik aktivasyonu";
            this._Title = "ÜYELİK AKTİVASYONU";
            this._Content.Append("Üye girişi yapabilmeniz için lütfen aşağıdaki linke tıklayın, aktivasyon sürecini tamamlayın.");
            this._Content.Append("<br /><br />");
            this._Content.Append("<a href=\"");
            this._Content.Append(URL);
            this._Content.Append("\" >");
            this._Content.Append(URL);
            this._Content.Append("</a>");
            return Send(To);
        }

        public bool SendCv(string To, string Firstname, string Surname, string CvURL)
        {
            this._Subject = "GsuKariyer.com Cv Gönderimi";
            this._Title = "GsuKariyer.com üyesi size Cv'sini gönderdi";
            this._Content.Append(Firstname);
            this._Content.Append(" ");
            this._Content.Append(Surname);
            this._Content.Append(" Cv'sini incelemek için aşağıdaki linke tıklayınız");
            this._Content.Append("<br><br>");
            this._Content.Append("<a href=\"");
            this._Content.Append(CvURL);
            this._Content.Append("\" >");
            this._Content.Append(Firstname + " " + Surname);
            this._Content.Append("</a>");
            return Send(To);
        }

        public bool SendFirmActivated(string To)
        {
            this._Subject = "GsuKariyer.com Üyelik aktivasyonu";
            this._Title = "ÜYELİK AKTİVASYONU";
            this._Content.Append("Sitemize yaptığınız üyelik başvurusu onaylanmıştır.");
            this._Content.Append("<br /><br />");
            this._Content.Append("Kullanıcı adı ve şifrenizle sisteme giriş yapabilirsiniz.");
            this._Content.Append("<br /><br />");
            this._Content.Append("Sorunlarınız için GSÜ Öğrenci Konseyi ile irtibata geçebilirsiniz.");
            this._Content.Append("<br /><br />");
            return Send(To);
        }

        public bool SendNewFirm(string To, string FirmName, string FirmUserName, string FirmUserSurname)
        {
            this._Subject = "GsuKariyer.com Yeni Firma Üyelik Başvurusu";
            this._Title = "FİRMA ÜYELİK BAŞVURUSU";
            this._Content.Append("Yeni firma üyelik başvurusu yapılmıştır. Admin panelinden firma bilgilerini inceleyip, onaylabilirsiniz.");
            this._Content.Append("<br /><br />");
            this._Content.Append("Firma Ünvanı: ");
            this._Content.Append(FirmName);
            this._Content.Append("<br /><br />");
            this._Content.Append("Yetkili kişi: ");
            this._Content.Append(FirmUserName + " " + FirmUserSurname);
            this._Content.Append("<br /><br />");
            return Send(To);
        }

        public bool Send(string To)
        {
            this._MailTemplate = this._MailTemplate.Replace("||TITLE||", this._Title).Replace("||CONTENT||", this._Content.ToString());
            return objMail.Send(To, this._Subject, this._MailTemplate, String.Empty, String.Empty, MailPriority.Normal, true);
        }

    }
}
