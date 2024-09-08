using Microsoft.Extensions.Options;
using Samples.Infrastructure.Common.Exceptions;
using Samples.MT.Common.Data.TenantDb.EfCore.Configuration;
using Samples.MT.Common.Services.Abstractions;
using Samples.MT.Common.Services.Multitenancy.Abstractions;

namespace Samples.MT.Common.Services.Multitenancy;

public class TenantDbContextConfigurator : ITenantDbContextConfigurator
{
    private readonly TenantDbConfiguration _tenantDbConfiguration;//TODO: move to separate class, like TenantDbConfigurationUpdater
    private readonly IRequestContext _requestContext;
    private readonly ITenantConfigurationProvider _tenantConfigurationProvider;

    public TenantDbContextConfigurator(IOptions<TenantDbConfiguration> tenantDbOptions, IRequestContext requestContext, ITenantConfigurationProvider tenantConfigurationProvider)
    {
        _tenantDbConfiguration = tenantDbOptions.Value;
        _requestContext = requestContext;
        _tenantConfigurationProvider = tenantConfigurationProvider;
    }

    /// <inheritdoc/>
    public async Task<TenantDbConfiguration> GetConfigurationAsync(CancellationToken cancellationToken)
    {
        var tenantConfiguration = await _tenantConfigurationProvider.GetTenantConfigurationAsync(_requestContext.TargetTenantId, CancellationToken.None).ConfigureAwait(false);
        if (tenantConfiguration == null)
        {
            throw new ItemNotFoundException($"Configuration for tenant with organization id {_requestContext.TenantExternalId} is missing");//TODO
        }

        if (tenantConfiguration.DbConnectionString == null)
        {
            throw new ItemNotFoundException($"Db connection string for tenant with id {tenantConfiguration.Id} is missing");//TODO: duplicated in TenantDatabaseMigrator
        }

        _tenantDbConfiguration.ConnectionString = tenantConfiguration.DbConnectionString;
        _tenantDbConfiguration.TenantId = tenantConfiguration.Id;

        return _tenantDbConfiguration;
    }
}
