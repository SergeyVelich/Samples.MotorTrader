using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Samples.Infrastructure.Resources.Cache.Abstractions;

namespace Samples.Infrastructure.Resources.Cache.LocalMemoryCache.Configuration;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddLocalMemoryCache(this IServiceCollection services)
    {
        services.AddMemoryCache();
        services.TryAddSingleton<ICacheService, MemoryCacheService>();

        return services;
    }
}