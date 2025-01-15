using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackCats_Application.Abstraction.IEmailService
{
    public interface IEmailService
    {
        Task<string> SendEmailAsync(MailSettings settings);
    }
}
