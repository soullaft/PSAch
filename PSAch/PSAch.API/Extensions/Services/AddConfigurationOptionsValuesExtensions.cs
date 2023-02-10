using PSAch.API.Services.Cache;
using PSAch.Core;

namespace PSAch.API.Extensions.Services
{
    public static class AddConfigurationOptionsValuesExtensions
    {
        public static IServiceCollection AddConfigurationOptionsValues(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<MailSettings>(configuration.GetSection("MailSettings"));
            services.Configure<CacheSettings>(configuration.GetSection("CacheSettings"));

            return services;
        }
    }
}
