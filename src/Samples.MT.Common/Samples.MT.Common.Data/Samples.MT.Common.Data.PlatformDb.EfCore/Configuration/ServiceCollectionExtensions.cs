using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Samples.Infrastructure.Data.EfCore.Interceptors;
using Samples.MT.Common.Data.PlatformDb.Abstractions;

namespace Samples.MT.Common.Data.PlatformDb.EfCore.Configuration;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddPlatformDbContext(this IServiceCollection services, PlatformDbConfiguration configuration)
    {
        services.TryAddScoped<SoftDeleteInterceptor>();

        services.AddDbContext<PlatformDbContext>((serviceProvider, optionsBuilder) => 
        {
            optionsBuilder
                .UseSqlServer(configuration.ConnectionString)
                .AddInterceptors(
                    serviceProvider.GetRequiredService<SoftDeleteInterceptor>());
        });

        services.TryAddScoped<IPlatformDbUnitOfWork, PlatformDbUnitOfWork>();

        return services;
    }
}