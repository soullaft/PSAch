using PSAch.API.Extensions.Services;
using NLog;
using NLog.Web;
using PSAch.API.Data;
using Microsoft.EntityFrameworkCore;
using PSAch.API.Middlewares;
using PSAch.API.Generator;

var logger = LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();

try
{
    var builder = WebApplication.CreateBuilder(args);

    builder.Services.AddAplicationServices(builder.Configuration);

    // NLog setup
    builder.Logging.ClearProviders();
    builder.Host.UseNLog();

    var app = builder.Build();

    // migrate any database changes on startup (includes initial db creation)
    using (var scope = app.Services.CreateScope())
    {
        var dataContext = scope.ServiceProvider.GetRequiredService<DataContext>();
        dataContext.Database.Migrate();

        if(builder.Configuration.GetValue<bool>("LocalVariables:generateUsers"))
        {
            await Generator.GenerateUsersAsync(dataContext, builder.Configuration);
        }
    }

    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI(c => { c.DisplayRequestDuration(); });
    }

    app.UseCors(policy =>
    {
        policy.AllowAnyHeader().AllowAnyMethod().WithOrigins(builder.Configuration.GetValue<string>("ClientUrl"));
    });

    // global error handler
    app.UseMiddleware<ErrorHandlerMiddleware>();

    app.UseHttpsRedirection();

    app.UseAuthorization();

    app.MapControllers();

    await app.RunAsync();

}
catch(Exception ex) { logger.Error(ex); }
finally { LogManager.Shutdown(); }