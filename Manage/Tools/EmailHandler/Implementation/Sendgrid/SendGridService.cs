using Manage.Tools.EmailHandler.Abstract;
using Manage.Tools.EmailHandler.Configuration;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Linq;
using System.Threading.Tasks;

namespace Manage.Tools.EmailHandler.Implementation.Sendgrid
{
    public class SendGridService : IEmailService
    {
        private readonly SendGridConfiguration _sendgridConfig;
        public SendGridService(SendGridConfiguration sendgridConfig)
        {
            _sendgridConfig = sendgridConfig;
        }
        public async Task<bool> SendEmail(Message message)
        {
            var client = new SendGridClient(_sendgridConfig.API_KEY);
            var from = new EmailAddress(_sendgridConfig.From, _sendgridConfig.Sender);
            var subject = message.Subject;
            var tos = message.To.Select(e => new EmailAddress(e.Address)).ToList();
            var content = message.Content;
            var msg = MailHelper.CreateSingleEmailToMultipleRecipients(from, tos, subject, "", content);
            var response = await client.SendEmailAsync(msg);

            return response.IsSuccessStatusCode;
        }
    }
}
