using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Samples.Infrastructure.Common;
using Samples.Infrastructure.Common.Abstractions;
using Samples.Infrastructure.Data.EfCore.Interceptors;
using Samples.MT.Common.Data.PlatformDb.Abstractions;

namespace Samples.MT.Common.Data.PlatformDb.EfCore.Configuration;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddPlatformDbContext(this IServiceCollection services, PlatformDbConfiguration configuration)
    {
        services.TryAddScoped<IDbOperationContext, DbOperationContext>();

        services.TryAddScoped<SoftDeleteInterceptor>();
        services.TryAddScoped<AuditInterceptor>();

        services.AddDbContext<PlatformDbContext>((serviceProvider, optionsBuilder) => 
        {
            optionsBuilder
                .UseSqlServer(configuration.ConnectionString)
                .AddInterceptors(
                    serviceProvider.GetRequiredService<SoftDeleteInterceptor>(),
                    serviceProvider.GetRequiredService<AuditInterceptor>());
        });

        services.TryAddScoped<IPlatformDbUnitOfWork, PlatformDbUnitOfWork>();

        return services;
    }
}