using System;
using System.Collections.Generic;
using System.Text;
using TasksManagement.Application.Email;
using System.Net;
using System.Net.Mail;

namespace TasksManagement.Implementation.Email
{
    public class SmtpEmailSender : IEmailSender
    {
        public void Send(SendEmailDto dto)
        {
            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential("aspsandraict@gmail.com", "Sandra123!")
            };

            var message = new MailMessage("aspsandraict@gmail.com", dto.SendTo);
            message.Subject = dto.Subject;
            message.Body = dto.Content;
            message.IsBodyHtml = true;
            smtp.Send(message);
        }
    }
}
