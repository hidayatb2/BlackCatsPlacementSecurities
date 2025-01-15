using BlackCats_Application.Abstraction.IEmailService;
using Mailjet.Client;
using Mailjet.Client.TransactionalEmails;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackCats_Infrastructure.Email_Services
{
    public class MailJetService : IEmailService
    {
        private readonly MailJetOptions options;

        public MailJetService(IOptions<MailJetOptions> options)
        {
            this.options = options.Value;
        }
        public async Task<string> SendEmailAsync(MailSettings settings)
        {
            MailjetClient client = new MailjetClient(options?.ApiKey, options?.ApiSecret);

            var email= new TransactionalEmailBuilder()
                       .WithFrom(new SendContact(options?.FromEmail))
                       .WithTo(new SendContact(settings.To.FirstOrDefault()))
                       .WithSubject(settings.Subject)
                       .WithHtmlPart(settings.Body)
                       .Build();
            var emailResult=await client.SendTransactionalEmailAsync(email);
            return emailResult?.Messages?.FirstOrDefault()?.Status!;
        }
    }
}
