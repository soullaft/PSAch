using PSAch.API.Models;

namespace PSAch.API.Services.Mail
{
    public interface IMailService
    {
        Task SendEmailAsync(MailRequest mailRequest);
    }
}
