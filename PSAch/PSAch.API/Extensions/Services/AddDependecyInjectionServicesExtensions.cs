using PSAch.API.Data;
using PSAch.API.Services.Mail;

namespace PSAch.API.Extensions.Services
{
    public static class AddDependecyInjectionServicesExtensions
    {
        public static IServiceCollection AddDependecyInjectionServices(this IServiceCollection services)
        {
            services.AddScoped<IGamesRepository, GamesRepository>();
            services.AddTransient<IMailService, MailService>();

            return services;
        }
    }
}
