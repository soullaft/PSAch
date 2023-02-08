using Microsoft.Extensions.Options;
using PSAch.API.Models;

namespace PSAch.API.Services
{
    public class MailService : IMailService
    {
        private readonly MailSettings _mailSettings;

        public MailService(IOptions<MailSettings> mailSettings)
        {
            _mailSettings = mailSettings.Value;
        }

        public Task SendEmailAsync(MailRequest mailRequest)
        {
            throw new NotImplementedException();
        }
    }
}
