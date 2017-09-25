using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;

namespace Eating.Service
{
    public class MailService
    {
        private string mail_Account = "abc470708";
        private string mail_Password = "0910602142";
        private string mail_Address = "abc470708@gmail.com";

        /// <summary>
        /// Create new validate code
        /// </summary>
        /// <returns></returns>
        public string GetValidateCode()
        {
            string[] Code = {"A", "B", "C", "D", "E", "F", "G",
                "H", "I", "J", "K", "L", "M", "N", "P", "Q",
                "R", "S", "T", "U", "V", "W", "X", "Y", "Z",
                "0", "1", "2", "3", "4", "5", "6", "7", "8",
                "9", "a", "b", "c", "d", "e", "f", "g", "h",
                "i", "j", "k", "l", "m", "n", "p", "q", "r",
                "s", "t", "u", "v", "w", "x", "y", "z"};

            string ValidCode = string.Empty;
            Random rd = new Random();
            for(int i = 0; i < 10; i++)
            {
                ValidCode += Code[rd.Next(Code.Count())];
            }

            return ValidCode;
        }

        /// <summary>
        /// Write the user data to mail content body
        /// </summary>
        /// <param name="TempString"></param>
        /// <param name="UserName"></param>
        /// <param name="ValidateUrl"></param>
        /// <returns></returns>
        public string GetRegisterMailBody(string TempString, string UserName, string ValidateUrl)
        {
            TempString = TempString.Replace("{{UserName}}", UserName);
            TempString = TempString.Replace("{{ValidateUrl}}", ValidateUrl);

            return TempString;
        }

        /// <summary>
        /// Send E-mail
        /// </summary>
        /// <param name="MailBody"></param>
        /// <param name="ToEmail"></param>
        public void SendRegisterMail(string MailBody, string ToEmail)
        {
            SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
            SmtpServer.Port = 587;
            SmtpServer.Credentials = new System.Net.NetworkCredential(mail_Account, mail_Password);
            SmtpServer.EnableSsl = true;
            SmtpServer.DeliveryMethod = SmtpDeliveryMethod.Network;
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress(mail_Address);
            mail.To.Add(ToEmail);
            mail.Subject = "會員註冊驗證信"; //mail topic
            mail.Body = MailBody; // mail main content
            mail.IsBodyHtml = true;
            SmtpServer.Send(mail);
        }
    }
}