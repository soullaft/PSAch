using Microsoft.EntityFrameworkCore;
using PSAch.API.Data;
using System.Net;
using MediatR;
using PSAch.API.Models;

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

            services.AddScoped<IBaseRepository<Game>, GamesRepository>();

            //make all http request to redirect to https protocol
            services.AddHttpsRedirection(options =>
            {
                options.RedirectStatusCode = (int)HttpStatusCode.PermanentRedirect;
                options.HttpsPort = 443;
            });

            services.AddMediatR(typeof(Program));
            services.AddControllers();
            services.AddCors();

            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            return services;
        }
    }
}
