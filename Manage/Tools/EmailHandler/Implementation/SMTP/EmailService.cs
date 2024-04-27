using MailKit.Net.Smtp;
using Manage.Tools.EmailHandler.Abstract;
using Manage.Tools.EmailHandler.Configuration;
using MimeKit;
using System;
using System.Threading.Tasks;

namespace Manage.Tools.EmailHandler.Implementation.SMTP
{
    public class EmailService : IEmailService
    {
        private readonly SMTPConfiguration _smtpConfig;
        public EmailService(SMTPConfiguration smtpConfig)
        {
            _smtpConfig = smtpConfig;
        }
        public async Task<bool> SendEmail(Message message)
        {
            var emailMessage = CreateEmailMessage(message);
            return Send(emailMessage);
        }
        private MimeMessage CreateEmailMessage(Message message)
        {
            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress(_smtpConfig.From));
            emailMessage.To.AddRange(message.To);
            emailMessage.Subject = message.Subject;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html) { Text = message.Content };
            return emailMessage;
        }
        private bool Send(MimeMessage mailMessage)
        {
            using (var client = new SmtpClient())
            {
                try
                {
                    client.Connect(_smtpConfig.SmtpServer, _smtpConfig.Port, true);
                    client.AuthenticationMechanisms.Remove("XOAUTH2");
                    client.Authenticate(_smtpConfig.UserName, _smtpConfig.Password);
                    client.Send(mailMessage);
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
                finally
                {
                    client.Disconnect(true);
                    client.Dispose();
                }
            }
        }
    }
}
