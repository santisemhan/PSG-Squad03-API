namespace client_app_backend.Configuration
{
    using Ardalis.GuardClauses;
    using client_app_backend.Core.Integrations;
    using client_app_backend.Core.Integrations.Interfaces;
    using System.Net;

    public static class IntegrationConfiguration
    {
        public const string FootballConnectionName = "Football";

        public static IServiceCollection AddIntegrationConfiguration(this IServiceCollection services)
        {
            services.AddHttpContextAccessor();

            services.AddTransient<IFootballDataAPI, FootballDataAPI>();

            return services;
        }

        public static IServiceCollection AddHttpIntegrationLayer(this IServiceCollection services, IConfiguration configuration)
        {
            var footballService = configuration?.GetSection($"ServicesHosts:{FootballConnectionName}").Get<ServiceConfiguration>();
            Guard.Against.Null(footballService, nameof(footballService));

            services.AddTransient<ServiceHandler>();

            services.AddHttpClient(FootballConnectionName, options =>
            {
                options.BaseAddress = footballService.Url;
                options.DefaultRequestHeaders.Add("X-Auth-Token", "ADD-SECRET");
            }).AddHttpMessageHandler(provider =>
            {
                var handler = provider.GetRequiredService<ServiceHandler>();
                handler.IsActive = footballService.Active;
                return handler;
            });

            return services;
        }

        protected class ServiceHandler : DelegatingHandler
        {
            public bool IsActive { get; set; }

            protected async override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
            {
                if (IsActive)
                    return await base.SendAsync(request, cancellationToken);

                return new HttpResponseMessage(HttpStatusCode.ServiceUnavailable);
            }
        }

        protected class ServiceConfiguration
        {
            public Uri Url { get; set; }

            public bool Active { get; set; }
        }
    }
}
