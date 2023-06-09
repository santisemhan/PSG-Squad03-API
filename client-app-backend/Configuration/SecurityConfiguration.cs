namespace client_app_backend.Configuration
{
    public static class SecurityConfiguration
    {
        public static IServiceCollection AddWebSecurityConfiguration(this IServiceCollection services)
        {
            // TODO: Validar URLs que tienen permitido obtener informacion de nuestra API
            services.AddCors(options =>
            {
                options.AddPolicy("_AllowOriginDev", builder =>
                {
                    builder.AllowAnyOrigin()
                            .AllowAnyHeader()
                            .AllowAnyMethod()
                            .WithExposedHeaders("Content-Disposition");
                });
                options.AddPolicy("_AllowOriginProd", builder =>
                {
                    builder.AllowAnyOrigin()
                            .AllowAnyHeader()
                            .AllowAnyMethod()
                            .WithExposedHeaders("Content-Disposition");
                });
            });

            return services;
        }
    }
}
