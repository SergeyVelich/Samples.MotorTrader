using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;

namespace Samples.Infrastructure.Api.ConfigValidation;

public static class OptionsBuilderExtensions
{
    public static OptionsBuilder<TOptions> ValidateMiniValidation<TOptions>(this OptionsBuilder<TOptions> optionsBuilder)
        where TOptions : class
    {
        // register the validator against the options
        optionsBuilder.Services.TryAddSingleton<IValidateOptions<TOptions>>(
            new MiniValidationValidateOptions<TOptions>(optionsBuilder.Name));
        return optionsBuilder;
    }
}