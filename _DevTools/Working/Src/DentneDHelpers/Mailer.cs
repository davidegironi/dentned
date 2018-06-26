#region License
// Copyright (c) 2016 Davide Gironi
//
// Please refer to LICENSE file for licensing information.
#endregion

using System.Net;
using System.Net.Mail;

namespace DG.DentneD.Helpers
{
    public class Mailer
    {
        private readonly string smtpHost = "";
        private readonly int smtpPort = 25;
        private readonly string smtpFrom = "";
        private readonly string smtpUsername = "";
        private readonly string smtpPassword = "";
        private readonly bool smtpEnableSsl = false;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="smtpHost"></param>
        /// <param name="smtpPort"></param>
        /// <param name="smtpFrom"></param>
        /// <param name="smtpUsername"></param>
        /// <param name="smtpPassword"></param>
        /// <param name="smtpEnableSsl"></param>
        public Mailer(string smtpHost, int smtpPort, string smtpFrom, string smtpUsername, string smtpPassword, bool smtpEnableSsl)
        {
            this.smtpHost = smtpHost;
            this.smtpPort = smtpPort;
            this.smtpFrom = smtpFrom;
            this.smtpUsername = smtpUsername;
            this.smtpPassword = smtpPassword;
            this.smtpEnableSsl = smtpEnableSsl;
        }

        /// <summary>
        /// Send an email
        /// </summary>
        /// <param name="subject"></param>
        /// <param name="body"></param>
        /// <param name="to"></param>
        /// <param name="attachments"></param>
        public void SendMail(string subject, string body, string[] to, string[] attachments)
        {
            //try to send mail
            MailMessage mail = new MailMessage();

            SmtpClient smtpClient = new SmtpClient(smtpHost);
            smtpClient.Port = smtpPort;
            mail.From = new MailAddress(smtpFrom);
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = new NetworkCredential(smtpUsername, smtpPassword);
            smtpClient.EnableSsl = smtpEnableSsl;
            mail.Body = "";
            foreach (string dest in to)
                mail.To.Add(dest);
            foreach (string attachment in attachments)
                mail.Attachments.Add(new Attachment(attachment));

            mail.Subject = subject;
            mail.Body += body;
            mail.IsBodyHtml = true;
            smtpClient.Send(mail);
        }
    }
}