using Microsoft.Extensions.Options;
using NationsApi.Application.Dto.Email;
using NationsApi.Application.Email;
using NationsApi.Application.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace NationsApi.Implementation.Email
{
    public class SMTPEmailSender : IEmailSender
    {
        private readonly MailSettings mailSettings;

        public SMTPEmailSender(IOptions<MailSettings> options)
        {
            this.mailSettings = options.Value;
        }

        public void SendEmail(SendEmailDto dto)
        {
            var smtp = new SmtpClient
            {
                Host = mailSettings.Host,
                Port = mailSettings.Port,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(mailSettings.Mail, mailSettings.Password)
            };

            var message = new MailMessage(mailSettings.Mail, dto.SendTo);
            message.Subject = dto.Subject;
            message.Body = dto.Content;
            message.IsBodyHtml = true;
            // Less Secure Sign-In must be enabled for this line of code to work
            // Line commented since it is casting exception
            //smtp.Send(message);
        }
    }
}

