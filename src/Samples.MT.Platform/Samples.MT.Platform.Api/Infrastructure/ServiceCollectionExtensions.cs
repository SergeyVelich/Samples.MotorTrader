using Microsoft.Extensions.DependencyInjection.Extensions;
using Samples.MT.Common;
using Samples.MT.Common.Services.Abstractions;
using Samples.MT.Common.Services.Multitenancy;
using Samples.MT.Common.Services.Multitenancy.Abstractions;
using Samples.MT.Platform.Services;
using Samples.MT.Platform.Services.Abstractions;

namespace Samples.MT.Platform.Api.Infrastructure;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddMultitenancyServices(this IServiceCollection services)
    {
        services.TryAddScoped<IRequestContext, RequestContext>();

        services.TryAddScoped<ITenantConnectionStringProvider, TenantConnectionStringProvider>();
        services.TryAddScoped<ITenantConfigurationProvider, TenantConfigurationProvider>();
        services.TryAddScoped<ITenantDbContextConfigurator, TenantDbContextConfigurator>();

        return services;
    }

    public static IServiceCollection AddLogicServices(this IServiceCollection services)
    {
        services.TryAddScoped<IUserManagementService, UserManagementService>();

        return services;
    }
}