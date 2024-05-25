using System;
using System.Net;
using System.Net.Mail;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoadsOfRussia.ViewModel
{
    public class NotifyViewModel
    {
        public static async Task SendEmailAsync(string to, string subject, string body)
        {
            using(var client = new SmtpClient("smtp.mail.ru", 587))
            {
                client.EnableSsl = true;
                client.Credentials = new NetworkCredential("alexanderhomer239@mail.ru", "eFNbCBmsAzXgZz14RbdG");

                var mailMessage = new MailMessage()
                {
                    From = new MailAddress("alexanderhomer239@mail.ru"),
                    Subject = subject,
                    Body = body,
                    IsBodyHtml = true
                };
                mailMessage.To.Add(to);

                await client.SendMailAsync(mailMessage);
            }
        }
    }
}
