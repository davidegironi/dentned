#region License
// Copyright (c) 2016 Davide Gironi
//
// Please refer to LICENSE file for licensing information.
#endregion

using System;
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
        private readonly bool smtpEnableSSL = false;
        private readonly string subjectPrefix = null;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="smtpHost"></param>
        /// <param name="smtpPort"></param>
        /// <param name="smtpFrom"></param>
        /// <param name="smtpUsername"></param>
        /// <param name="smtpPassword"></param>
        /// <param name="smtpEnableSSL"></param>
        /// <param name="subjectPrefix"></param>
        public Mailer(string smtpHost, int smtpPort, string smtpFrom, string smtpUsername, string smtpPassword, bool smtpEnableSSL, string subjectPrefix)
        {
            this.smtpHost = smtpHost;
            this.smtpPort = smtpPort;
            this.smtpFrom = smtpFrom;
            this.smtpUsername = smtpUsername;
            this.smtpPassword = smtpPassword;
            this.smtpEnableSSL = smtpEnableSSL;
            this.subjectPrefix = subjectPrefix;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="smtpHost"></param>
        /// <param name="smtpPort"></param>
        /// <param name="smtpFrom"></param>
        /// <param name="smtpUsername"></param>
        /// <param name="smtpPassword"></param>
        /// <param name="smtpEnableSSL"></param>
        public Mailer(string smtpHost, int smtpPort, string smtpFrom, string smtpUsername, string smtpPassword, bool smtpEnableSSL)
            : this(smtpHost, smtpPort, smtpFrom, smtpUsername, smtpPassword, smtpEnableSSL, null)
        { }

        /// <summary>
        /// Send an email
        /// </summary>
        /// <param name="subject"></param>
        /// <param name="subjectprefix"></param>
        /// <param name="body"></param>
        /// <param name="to"></param>
        /// <param name="attachments"></param>
        public void SendMail(string subject, string subjectprefix, string body, string[] to, string[] attachments)
        {
            //try to send mail
            MailMessage mail = new MailMessage();

            SmtpClient SmtpServer = new SmtpClient(smtpHost);
            SmtpServer.Port = smtpPort;
            mail.From = new MailAddress(smtpFrom);
            SmtpServer.Credentials = new System.Net.NetworkCredential(smtpUsername, smtpPassword);
            if (Convert.ToBoolean(smtpEnableSSL))
                SmtpServer.EnableSsl = true;
            mail.Body = "";
            foreach (string dest in to)
                mail.To.Add(dest);
            foreach (string attachment in attachments)
                mail.Attachments.Add(new Attachment(attachment));

            mail.Subject = (!String.IsNullOrEmpty(subjectprefix) ? subjectprefix : "") + subject;
            mail.Body += body;
            SmtpServer.Send(mail);
        }
    }
}