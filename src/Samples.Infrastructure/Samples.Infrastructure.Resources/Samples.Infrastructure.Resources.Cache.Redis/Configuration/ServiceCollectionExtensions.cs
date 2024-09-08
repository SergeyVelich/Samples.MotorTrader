using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Samples.Infrastructure.Resources.Cache.Abstractions;

namespace Samples.Infrastructure.Resources.Cache.Redis.Configuration;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddRedisCache(this IServiceCollection services, RedisCacheConfiguration configuration)
    {
        services.AddStackExchangeRedisCache(options =>
        {
            options.Configuration = configuration.ConnectionString;
        });

        services.TryAddSingleton<ICacheService, RedisCacheService>();

        return services;
    }
}