namespace client_app_backend.Configuration.Layers
{
    using client_app_backend.Core.Services;
    using client_app_backend.Core.Services.Interface;

    public static class ServiceConfiguration
    {
        public static IServiceCollection AddServiceConfiguration(this IServiceCollection services)
        {
            services.AddTransient<IPSGService, PSGService>();
            services.AddTransient<ISurveyService, SurveyService>();
            services.AddTransient<IUserService, UserService>();
            return services;
        }
    }
}
