using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EarSense_Welcome.Interfaces;
using System.Net;
using System.Net.Mail;
using Microsoft.Extensions.Configuration;

namespace EarSense_Welcome.Services
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _config;

        public EmailService(IConfiguration config)
        {
            _config = config;
        }

        public async Task sendMessageGmail(string toAddress, string subject, string body)
        {
            MailMessage email = new MailMessage();
            MailAddress from = new MailAddress(_config.GetValue<string>("EmailService:FromAddress"));
            MailAddress to = new MailAddress(toAddress);
            email.From = from;
            email.To.Add(to);
            email.Subject = subject;
            email.Body = body;

            Console.WriteLine("Getting from settings:");
            Console.WriteLine(_config.GetValue<string>("EmailService:Credentials:Username"));
            Console.WriteLine(_config.GetValue<string>("EmailService:Credentials:Password"));
            using (var client = new SmtpClient())
            {
                client.Host = _config.GetValue<string>("EmailService:Host");
                client.UseDefaultCredentials = true;
                client.Port = _config.GetValue<int>("EmailService:Port");
                client.EnableSsl = true;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.Credentials = new NetworkCredential(
                    _config.GetValue<string>("EmailService:Credentials:Username"),
                    _config.GetValue<string>("EmailService:Credentials:Password"));

                try
                {
                    await client.SendMailAsync(email);
                    Console.WriteLine("Sent!");
                }
                catch(Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
        }

       
    }
}
