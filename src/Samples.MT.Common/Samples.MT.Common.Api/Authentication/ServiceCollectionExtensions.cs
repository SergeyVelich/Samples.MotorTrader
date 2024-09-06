using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Samples.MT.Common.Api.Configuration;
using System.Security.Claims;

namespace Samples.MT.Common.Api.Authentication;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddAuthentication(this IServiceCollection services, Auth0IdentityConfiguration configuration)
    {
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.Authority = $"https://{configuration.Authority}/";
                options.Audience = configuration.Audience;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    NameClaimType = ClaimTypes.NameIdentifier,
                };
            });

        return services;
    }
}