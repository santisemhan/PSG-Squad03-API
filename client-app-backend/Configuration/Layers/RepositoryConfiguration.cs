namespace client_app_backend.Configuration.Layers
{
    using client_app_backend.Core.Repository;
    using client_app_backend.Core.Repository.Interfaces;
    using client_app_backend.Data;
    using client_app_backend.Data.Interface;
    using Microsoft.EntityFrameworkCore;
    using MongoDB.Driver;

    public static class RepositoryConfiguration
    {
        public static IServiceCollection AddDatabaseConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IConnection<IMongoDatabase>, MongoDataContext>();
            services.AddDbContext<DataContext>(options =>
            {
                options.UseSqlServer(configuration.GetValue<string>("Databases:SQLServer:ConnectionString"));
            });
            return services;
        }

        public static IServiceCollection AddRepositoryConfiguration(this IServiceCollection services)
        {
            services.AddTransient<IPublicDataRepository, PublicDataRepository>();
            services.AddTransient<ISurveyRepository, SurveyRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            return services;
        }
    }
}
