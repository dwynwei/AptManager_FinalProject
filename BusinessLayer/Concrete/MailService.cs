using BusinessLayer.Abstract;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Options;
using MimeKit;
using Models.EmailEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    /*
     * Mail Service Which related with HangFire
     */
    public class MailService : IMailService
    {
        private readonly MailSettings _settings;

        public MailService(IOptions<MailSettings> mailSettings)
        {
            _settings = mailSettings.Value;
        }

        public async Task SendEmailAsync(MailRequest mailRequest)
        {
            var email = new MimeMessage();

            email.Sender = MailboxAddress.Parse(_settings.Mail);
            email.To.Add(MailboxAddress.Parse(mailRequest.ToEmail));
            email.Subject = mailRequest.Subject;

            var builder = new BodyBuilder();

            if(mailRequest.Attachments != null)
            {
                byte[] fileInBytes;

                foreach(var attachment in mailRequest.Attachments)
                {
                    using(var stream = new MemoryStream())
                    {
                        attachment.CopyTo(stream);
                        fileInBytes = stream.ToArray();
                    }
                    builder.Attachments.Add(attachment.Name, fileInBytes,ContentType.Parse(attachment.ContentType));
                }
            }

            builder.HtmlBody = mailRequest.Body;
            email.Body = builder.ToMessageBody();
            using var smtp = new SmtpClient();

            smtp.Connect(_settings.Host, _settings.Port,MailKit.Security.SecureSocketOptions.StartTls);
            smtp.Authenticate(_settings.Mail, _settings.Password);
            await smtp.SendAsync(email);
            smtp.Disconnect(true);
        }
    }
}
