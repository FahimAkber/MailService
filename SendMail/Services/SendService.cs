using System.Threading.Tasks;
using MailService.Models;
using Microsoft.Extensions.Configuration;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace SendMail.Services
{
    public class SendService : ISendService
    {
        private IConfiguration configuration;
        public SendService(IConfiguration configuration){
            this.configuration = configuration;
        }
        public async Task SendMail(MailData mail)
        {
            var apikey = configuration["SendgridAPIKey"];
            var client = new SendGridClient(apikey);
            var from = new EmailAddress("aversoftbd@gmail.com", "Fahim Akber");
            var recipient = new EmailAddress(mail.RecipientAddress, mail.RecipientName);
            var subject = mail.Subject;
            var content = mail.Content;
            var msg = new SendGridMessage{
                From = from,
                Subject = subject
            };
            msg.AddContent(MimeType.Text, content);
            msg.AddTo(recipient);
            await client.SendEmailAsync(msg).ConfigureAwait(false);
        }
    }
}