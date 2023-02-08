using Microsoft.EntityFrameworkCore;
using PSAch.API.Data;
using System.Net;
using MediatR;
using PSAch.API.Mapper;
using System.Text.Json.Serialization;
using PSAch.API.Models;
using PSAch.API.Services.Mail;
using PSAch.API.Services.Cache;
using System.Reflection;

namespace PSAch.API.Extensions.Services
{
    public static class AddAplicationServicesExtensions
    {
        public static IServiceCollection AddAplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DataContext>(options =>
            {
                options.UseSqlite(configuration.GetConnectionString("DefaultConnection"));
            });

            services.AddDistributedMemoryCache();
            services.AddScoped<IGamesRepository, GamesRepository>();
            services.AddTransient<IMailService, MailService>();
            services.Configure<MailSettings>(configuration.GetSection("MailSettings"));
            services.Configure<CacheSettings>(configuration.GetSection("CacheSettings"));

            //make all http request to redirect to https protocol
            services.AddHttpsRedirection(options =>
            {
                options.RedirectStatusCode = (int)HttpStatusCode.PermanentRedirect;
                options.HttpsPort = 443;
            });

            services.AddAutoMapper(typeof(AutoMapperProfiles).Assembly);
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(CachingBehavior<,>));
            services.AddControllers()
                .AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
            services.AddCors();

            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            return services;
        }
    }
}
