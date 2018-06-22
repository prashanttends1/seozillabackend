using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace seozillabackend.Extensions
{
    public class emailmanager
    {
        public static void Appsettings(out string UserID, out string Password, out string SMTPPort, out string Host)
        {
            UserID = ConfigurationManager.AppSettings.Get("UserID");
            Password = ConfigurationManager.AppSettings.Get("Password");
            SMTPPort = ConfigurationManager.AppSettings.Get("SMTPPort");
            Host = ConfigurationManager.AppSettings.Get("Host"); 
        }

        public static void SendEmail(string From, string Subject, string Body, string To, string UserID, string Password, string SMTPPort, string Host)
        {
            System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
            mail.IsBodyHtml = true;
            mail.To.Add(To);
            mail.From = new System.Net.Mail.MailAddress("support@seozilla.co.uk", "SEOZILLA SUPPORT");
            mail.Subject = Subject;
            mail.Body = Body;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = Host;
            smtp.Port = Convert.ToInt16(SMTPPort);
            smtp.Credentials = new NetworkCredential(UserID, Password);
            smtp.EnableSsl = true;
            smtp.Send(mail);  
        }
    }
}