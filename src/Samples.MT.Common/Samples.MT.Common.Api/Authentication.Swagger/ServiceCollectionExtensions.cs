using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Samples.MT.Common.Api.Configuration;

namespace Samples.MT.Common.Api.Authentication.Swagger;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddSwagger(this IServiceCollection serviceCollection, Auth0IdentityConfiguration configuration)//TODO don't use config directly, use DI
    {
        serviceCollection.AddSwaggerGen(options =>
        {
            options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
            {
                Type = SecuritySchemeType.OAuth2,
                BearerFormat = "JWT",
                Flows = new OpenApiOAuthFlows
                {
                    Implicit = new OpenApiOAuthFlow
                    {
                        TokenUrl = new Uri($"https://{configuration.Authority}/oauth/token"),
                        AuthorizationUrl = new Uri($"https://{configuration.Authority}/authorize?audience={configuration.Audience}")
                    }
                }
            });
            options.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "oauth2" }
                    },
                    new[] { "openid email" }
                }
            });
        });

        return serviceCollection;
    }
}