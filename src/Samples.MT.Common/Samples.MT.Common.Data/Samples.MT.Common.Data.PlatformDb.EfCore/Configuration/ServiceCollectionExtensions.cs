using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Samples.MT.Common.Data.PlatformDb.Abstractions;

namespace Samples.MT.Common.Data.PlatformDb.EfCore.Configuration;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddPlatformDbContext(this IServiceCollection services, PlatformDbConfiguration configuration)
    {
        services.AddDbContext<PlatformDbContext>((serviceProvider, optionsBuilder) => 
        {
            optionsBuilder
                .UseSqlServer(configuration.ConnectionString);
        });

        services.TryAddScoped<IPlatformDbUnitOfWork, PlatformDbUnitOfWork>();

        return services;
    }
}