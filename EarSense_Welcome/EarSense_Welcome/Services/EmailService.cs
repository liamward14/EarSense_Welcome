using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EarSense_Welcome.Interfaces;
using System.Net;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using MailKit.Net;
using MailKit.Security;
using MimeKit;
using MailKit.Net.Smtp;

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
            MimeMessage email = new MimeMessage();
            email.From.Add(new MailboxAddress(_config.GetValue<string>("EmailService:FromName"), _config.GetValue<string>("EmailService:FromAddress")));
            email.To.Add(new MailboxAddress(toAddress.Split('@').First(), toAddress));
            if (string.IsNullOrEmpty(subject))
            {
                email.Subject = "Earsense Communication";
            }
            else
            {
                email.Subject = subject;
            }
            var builder = new BodyBuilder();
            builder.HtmlBody = body;
            email.Body = builder.ToMessageBody();

            Console.WriteLine("Getting from settings:");
            Console.WriteLine(_config.GetValue<string>("EmailService:Credentials:Username"));
            Console.WriteLine(_config.GetValue<string>("EmailService:Credentials:Password"));
            /*
            client.Host = _config.GetValue<string>("EmailService:Host");
            client.UseDefaultCredentials = true;
            client.Port = _config.GetValue<int>("EmailService:Port");
            client.EnableSsl = true;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.Credentials = new NetworkCredential(
                _config.GetValue<string>("EmailService:Credentials:Username"),
                _config.GetValue<string>("EmailService:Credentials:Password"));
            */
            using (var client = new SmtpClient())
            {
                client.CheckCertificateRevocation = false;
                Console.WriteLine("Host: " + _config.GetValue<string>("EmailService:Host"));
                client.Connect(_config.GetValue<string>("EmailService:Host"), _config.GetValue<int>("EmailService:Port"), SecureSocketOptions.StartTlsWhenAvailable);
                client.Authenticate(_config.GetValue<string>("EmailService:Credentials:Username"), _config.GetValue<string>("EmailService:Credentials:Password"));
                try
                {
                    await client.SendAsync(email);
                    Console.WriteLine("Sent!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
                client.Disconnect(true);
            };
        }

       
    }
}
