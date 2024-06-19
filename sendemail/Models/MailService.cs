using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Mailgun;
using Mailgun.Messages;
using System.Configuration;

namespace sendemail.Models
{
    public class MailService
    {
        private readonly string _apiKey = ConfigurationManager.AppSettings["Mailgun:ApiKey"];
        private readonly string _domain = ConfigurationManager.AppSettings["Mailgun:Domain"];
        private readonly string _fromAddress = ConfigurationManager.AppSettings["Mailgun:FromAddress"];
        public void SendEmail(string to, string subject, string body)
        {
            var message = new MessageBuilder()
                .SetFromAddress(_fromAddress)
                .AddRecipient(new Recipient { Email = to }) // Ensure to create Recipient object with email address
                .SetSubject(subject)
                .SetTextBody(body)
                .Build();

            var client = new Mailgun.MailgunClient(_apiKey, _domain);
            client.SendMessage(message);
        }
    }
}