using MailKit.Net.Smtp;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities
{
    public static class MailUtil
    {
        public static void sendMail(string text,string mail)
        {
            var mailMessage = new MimeMessage();
            mailMessage.From.Add(new MailboxAddress("Ivana Bilić", "bilic.ivana11@gmail.com"));
            mailMessage.To.Add(new MailboxAddress("to name", $"{mail}"));
            mailMessage.Subject = "subject";
            mailMessage.Body = new TextPart("plain")
            {
                Text = $"{text}"
            };

            using (var smtpClient = new SmtpClient())
            {
                smtpClient.Connect("smtp.gmail.com", 587);
                smtpClient.Authenticate("bilic.ivana11@gmail.com", "0989346501");
                smtpClient.Send(mailMessage);
                smtpClient.Disconnect(true);
            }
        }

    }
}
