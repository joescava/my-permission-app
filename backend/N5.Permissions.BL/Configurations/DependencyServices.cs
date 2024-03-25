using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using N5.Permissions.BL.Interfaces;
using N5.Permissions.BL.Messaging;
using N5.Permissions.BL.Services;
using Nest;

namespace N5.Permissions.BL.Configurations;
public static class DependencyServices
{
    public static IServiceCollection AddBusinessServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddTransient<IPermissionBusiness, PermissionBusiness>();

        var elasticUri = configuration["Elasticsearch:Uri"];
        var settings = new ConnectionSettings(new Uri(elasticUri))
                           .DefaultIndex("permissions");

        services.AddSingleton<IElasticClient>(new ElasticClient(settings));
        services.AddScoped<IElasticsearchService, ElasticsearchService>();
        services.AddScoped<IKafkaProducerService, KafkaProducerService>();

        return services;
    }
}
