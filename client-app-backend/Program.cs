using client_app_backend.Configuration;
using client_app_backend.Configuration.Layers;
using client_app_backend.Core.Support.Middleware;
using client_app_backend.Core.Support.Workers;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;
var services = builder.Services;

services.AddLogging(loggingBuilder =>
{
    loggingBuilder.AddConsole().AddFilter(DbLoggerCategory.Database.Command.Name, LogLevel.Information);
    loggingBuilder.AddDebug();
});

services.AddDatabaseConfiguration(configuration);

services.AddControllerConfiguration();

services.AddGlobalConfiguration();

services.AddHttpIntegrationLayer(configuration);

services.AddServiceConfiguration();
services.AddRepositoryConfiguration();
services.AddIntegrationConfiguration();

services.AddWebSecurityConfiguration();

services.AddHostedService<PSGCoreListener>();
services.AddHostedService<MockMessage>();

var app = builder.Build();

var environment = app.Environment;

app.UseMiddleware<ExceptionHandler>();

if (environment.IsDevelopment() || environment.IsEnvironment("Local"))
{
    app.UseSwagger();
    app.UseSwaggerUI(c => {
        c.RoutePrefix = "api/v1/docs";
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "PSG | Clients");
    });
    app.UseCors("_AllowOriginDev");
}
else if (environment.IsProduction())
{
    app.UseCors("_AllowOriginProd");
}
else
{
    throw new Exception("Invalid environment");
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
