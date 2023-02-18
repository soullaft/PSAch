using PSAch.Telegram.Data;

namespace PSAch.Telegram.Extensions.Services
{
    public static class AddConfigurationOptionsValuesExtensions
    {
        public static IServiceCollection AddConfigurationOptionsValues(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<TelegramSettings>(configuration.GetSection("TelegramSettings"));

            return services;
        }
    }
}
