namespace client_app_backend.Configuration.Layers
{
    using client_app_backend.Core.Repository;
    using client_app_backend.Core.Repository.Interfaces;
    using client_app_backend.Data;
    using client_app_backend.Data.Interface;
    using MongoDB.Driver;

    public static class RepositoryConfiguration
    {
        public static IServiceCollection AddDatabaseConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IConnection<IMongoDatabase>, MongoDataContext>();
            return services;
        }

        public static IServiceCollection AddRepositoryConfiguration(this IServiceCollection services)
        {
            services.AddTransient<IPublicDataRepository, PublicDataRepository>();
            return services;
        }
    }
}
