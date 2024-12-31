using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace BlackCats_Application.Abstraction.IEmailService
{
    public class MailSettings
    {
        public List<string> To { get; set; } = null!;

        public List<string> CC { get; set; } = null!;

        public List<string> BCC { get; set; } = null!;

        public string Subject { get; set; } = string.Empty;

        public string Body { get; set; } = string.Empty;

        public bool IsBodyHtml { get; set; } = true;

        public List<Attachment> Attachments { get; set; } = null!;
    }
}
