using PSAch.API.Models;

namespace PSAch.API.Services
{
    public interface IMailService
    {
        Task SendEmailAsync(MailRequest mailRequest);
    }
}
