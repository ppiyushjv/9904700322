using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrakME.DATA;
using System.Net.Mail;
using System.Web.Mvc;
using System.Web;

namespace TrakME.Common
{
    public static class Extension
    {
        public static string DomainName = "http://trackmymobile.online/";
        public static string EmailPassword = "M0ss@2018";
        public static string EmailUserName = "acverify_noreply@trackmymobile.online";
        public static string EmailSMTPServer = "mail.trackmymobile.online";
        public static int    EmailSMTPServerPort = 25;
      
        public static void SendEmailVerify(string email, string requestUrl)
        {
            string templatedata = System.IO.File.ReadAllText(HttpContext.Current.Server.MapPath(@"~/Assets/Templates/verifyemail.html")).ToString();
            StringBuilder stringBuilder = new StringBuilder(templatedata);
            stringBuilder.Replace("ppiyushjv@hotmail.com", email);
            stringBuilder.Replace("http://www.google.com", DomainName + requestUrl);
            SendEmail(email, "TrakMe - Verify Email", stringBuilder.ToString());
        }

        public static void SendEmailForgot(string email, string password)
        {
            StringBuilder mailHtml = new StringBuilder();
            mailHtml.Append("Hi!!<br/>");
            mailHtml.Append("We have received a request to reset your <b>TrakME</b> account.<br/>");
            mailHtml.Append($"Your password is : <b>\"{password}\"</b><br/><br/>");
            mailHtml.Append("Thanks");
            SendEmail(email, "TrakMe - forgot Password", mailHtml.ToString());
        }

        public static void SendEmail(string senderEmail,string subject,string body)
        {
            MailMessage mail = new MailMessage();
            mail.To.Add(senderEmail);
            mail.From = new MailAddress(EmailUserName);
            mail.Subject = subject;
            mail.Body = body.ToString();
            mail.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = EmailSMTPServer;
            smtp.Port = EmailSMTPServerPort;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new System.Net.NetworkCredential(EmailUserName, EmailPassword);
            smtp.EnableSsl = false;
            smtp.Send(mail);
        }
    }
}