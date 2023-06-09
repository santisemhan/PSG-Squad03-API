namespace client_app_backend.Configuration
{
    using Microsoft.AspNetCore.Localization;
    using System.Globalization;

    public static class GlobalConfiguration
    {
        public static IServiceCollection AddGlobalConfiguration(this IServiceCollection services)
        {
            services.AddLogging(loggingBuilder =>
            {
                loggingBuilder.AddDebug();
            });

            services.AddLocalization(options => { options.ResourcesPath = "Resources"; });

            services.Configure<RequestLocalizationOptions>(opts => {
                var supportedCultures = new List<CultureInfo> { new CultureInfo("es") };

                opts.DefaultRequestCulture = new RequestCulture("es");
                // Formatting numbers, dates, etc.
                opts.SupportedCultures = supportedCultures;
                // UI strings that we have localized.
                opts.SupportedUICultures = supportedCultures;
            });

            return services;
        }
    }
}
