using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Samples.Infrastructure.Api.ConfigValidation;

public static class ServiceCollectionExtensions
{
    public static TConfig AddConfigWithValidation<TConfig>(this IServiceCollection services, Action<TConfig> configureOptions)
        where TConfig : class, new()
    {
        services.AddOptions<TConfig>()
            .Configure(configureOptions)
            .ValidateMiniValidation()
            .ValidateOnStart();

        var config = new TConfig();
        configureOptions(config);

        return config;
    }

    public static TConfig AddConfigWithValidation<TConfig>(this IServiceCollection services, IConfiguration configuration, string sectionName)
        where TConfig : class, new()
    {
        services.AddOptions<TConfig>()
            .Bind(configuration.GetSection(sectionName))
            .ValidateMiniValidation()
            .ValidateOnStart();

        var config = configuration.GetSection(sectionName).Get<TConfig>() ?? new TConfig();

        return config;
    }

    public static TConfig AddConfigWithValidation<TConfig>(this IServiceCollection services, IConfiguration configuration, string sectionName, Action<TConfig> configureOptions)
        where TConfig : class, new()
    {
        services.AddOptions<TConfig>()
            .Bind(configuration.GetSection(sectionName))
            .Configure(configureOptions)
            .ValidateMiniValidation()
            .ValidateOnStart();

        var config = configuration.GetSection(sectionName).Get<TConfig>() ?? new TConfig();
        configureOptions(config);

        return config;
    }
}