using Microsoft.AspNetCore.Builder;
using Samples.MT.Common.Api.Configuration;

namespace Samples.MT.Common.Api.Authentication.Swagger;

public static class WebApplicationExtensions
{
    public static void UseSwagger(this WebApplication app, Auth0IdentityConfiguration configuration)
    {
        app.UseSwagger();
        app.UseSwaggerUI(options =>
        {
            options.OAuthClientId(configuration.ClientId);
            options.OAuthClientSecret(configuration.ClientSecret);
            options.OAuthUsePkce();
            options.ConfigObject.AdditionalItems.Add("persistAuthorization", "true");

            options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
            options.RoutePrefix = string.Empty;
        });
    }
}