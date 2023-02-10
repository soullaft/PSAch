using PSAch.Core;

namespace PSAch.API.Services.Mail
{
    public interface IMailService
    {
        Task SendEmailAsync(MailRequest<IFormFile> mailRequest);
    }
}
