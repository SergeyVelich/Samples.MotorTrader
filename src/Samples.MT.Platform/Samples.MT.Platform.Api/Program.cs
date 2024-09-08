using Samples.Infrastructure.Api;
using Samples.Infrastructure.Api.ConfigValidation;
using Samples.MT.Common.Api.Ardalis;
using Samples.MT.Common.Api.Authentication;
using Samples.MT.Common.Api.Authentication.Swagger;
using Samples.MT.Common.Api.Configuration;
using Samples.MT.Common.Api.Middlewares;
using Samples.MT.Common.Data.PlatformDb.EfCore.Configuration;
using Samples.MT.Common.Data.TenantDb.EfCore.Configuration;
using Samples.MT.Common.Services.Multitenancy.Abstractions;
using Samples.MT.Platform.Api.Infrastructure;
using Samples.MT.Platform.Api.Mapping;
using static Samples.MT.Common.Api.Constants;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
var configuration = builder.Configuration;

var isLocalDeployment = EnvironmentHelpers.IsLocalDevelopment();

// Add configurations to the container.
var auth0IdentityConfiguration = services.AddConfigWithValidation<Auth0IdentityConfiguration>(configuration, ConfigurationSectionNames.Auth0Identity);
var platformDbConfiguration = services.AddConfigWithValidation<PlatformDbConfiguration>(configuration, ConfigurationSectionNames.PlatformDb);
var tenantDbConfiguration = services.AddConfigWithValidation<TenantDbConfiguration>(configuration, ConfigurationSectionNames.TenantDb);

// Add services to the container.

builder.Services.AddControllers(mvcOptions => mvcOptions
        .ConfigureArdalis());

services.AddAuthentication(auth0IdentityConfiguration);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
services.AddSwagger(auth0IdentityConfiguration);

services.AddAutoMapper(typeof(AppMappingProfile));

//Add db contexts
services.AddPlatformDbContext(platformDbConfiguration);
services.AddTenantDbContext(provider =>
{
    var tenantDbContextConfigurator = provider.GetRequiredService<ITenantDbContextConfigurator>();
    var tenantDbConfiguration = tenantDbContextConfigurator.GetConfigurationAsync(CancellationToken.None).Result;

    return tenantDbConfiguration;
});

services.AddMultitenancyServices();
services.AddLogicServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger(auth0IdentityConfiguration);
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.UseMiddleware<TenantMiddleware>();

app.Run();