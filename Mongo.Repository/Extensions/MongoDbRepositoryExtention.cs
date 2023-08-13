
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Mongo.Repository.Abstraction;
using Repository.Abstraction;

namespace Mongo.Repository.Extensions
{
    public static class MongoDbRepositoryExtention
    {
        public static void AddMongoDbRepository(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IMongoDbClient, MongoDbClient>();
            services.AddTransient<IMongoContext, MongoContext>();
            services.Configure<MongoDbSettings>(configuration.GetSection("MongoDbSettings"));
            services.AddSingleton<IMongoDbSettings>(serviceProvider =>
                serviceProvider.GetRequiredService<IOptions<MongoDbSettings>>().Value);
          
        }
    }
}
