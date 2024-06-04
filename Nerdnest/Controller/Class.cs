using System.Net;
using System.Net.Mail;

namespace Nerdnest.Controller
{
    public class EmailSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string message)
        {
            var mail = "BeykozUniversity@outlook.com";
            var pw = "85500800195ok";

            var client = new SmtpClient("smtp-mail.outlook.com", 587)
            {
                EnableSsl = true,
                Credentials = new NetworkCredential(mail, pw)
            };
            return client.SendMailAsync(new MailMessage(from: mail, to: email, subject, message));
        }
    }
}
