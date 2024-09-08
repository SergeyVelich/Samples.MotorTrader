using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Samples.Infrastructure.Data.EfCore.Interceptors;
using Samples.MT.Common.Data.TenantDb.Abstractions;

namespace Samples.MT.Common.Data.TenantDb.EfCore.Configuration;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddTenantDbContext(this IServiceCollection services, Func<IServiceProvider, TenantDbConfiguration> configureOptions)
    {
        services.TryAddScoped<SoftDeleteInterceptor>();

        services.AddDbContext<TenantDbContext>((serviceProvider, optionsBuilder) =>
        {
            var configuration = configureOptions(serviceProvider);

            optionsBuilder
                .UseSqlServer(configuration.ConnectionString)
                .AddInterceptors(
                    serviceProvider.GetRequiredService<SoftDeleteInterceptor>());
        });

        services.TryAddScoped<ITenantDbUnitOfWork, TenantDbUnitOfWork>();

        return services;
    }
}