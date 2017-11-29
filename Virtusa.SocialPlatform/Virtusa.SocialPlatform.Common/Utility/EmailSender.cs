using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace Virtusa.SocialPlatform.Common.Utility

{
    public class EmailSender
    {
        public EmailSender(EmailSettings emailSettings)
        {
            _emailSettings = emailSettings;
        }

        public EmailSettings _emailSettings { get; }


        public Task SendEmailAsync(List<string> Recipients, string subject, string body)
        {
            Excecute(Recipients, subject, body).Wait();
            return Task.FromResult(0);
        }

        private async Task Excecute(List<string> Recipients, string subject, string body)
        {
            try
            {
                List<string> toMail = Recipients;

                MailMessage mail = new MailMessage()
                {
                    From = new MailAddress(_emailSettings.UsernameEmail, "Vindya Manamperi")

                };
                mail.Body = body;
                mail.Subject = subject;
                mail.IsBodyHtml = true;
                mail.Priority = MailPriority.High;
                foreach (var recipient in Recipients)
                    mail.To.Add(recipient);

                using (SmtpClient smtp = new SmtpClient(_emailSettings.Domain, _emailSettings.Port))
                {
                    smtp.Credentials = new NetworkCredential(_emailSettings.UsernameEmail, _emailSettings.UsernamePassword);
                    smtp.EnableSsl = true;
                    ServicePointManager.ServerCertificateValidationCallback = delegate (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) { return true; };
                    await smtp.SendMailAsync(mail);

                }


            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
