using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Samples.MT.Common.Data.TenantDb.Abstractions;

namespace Samples.MT.Common.Data.TenantDb.EfCore.Configuration;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddTenantDbContext(this IServiceCollection services, TenantDbConfiguration configuration)
    {
        services.AddDbContext<TenantDbContext>((serviceProvider, optionsBuilder) =>
        {
            optionsBuilder
                .UseSqlServer(configuration.ConnectionString);
        });

        services.TryAddScoped<ITenantDbUnitOfWork, TenantDbUnitOfWork>();

        return services;
    }
}