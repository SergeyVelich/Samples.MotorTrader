using Microsoft.Extensions.DependencyInjection.Extensions;
using Samples.MT.Platform.Services;
using Samples.MT.Platform.Services.Abstractions;

namespace Samples.MT.Platform.Api.Infrastructure;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddLogicServices(this IServiceCollection services)
    {
        services.TryAddScoped<IUserManagementService, UserManagementService>();

        return services;
    }
}