using Microsoft.Extensions.Configuration;
using Samples.MT.Common.Services.Multitenancy.Abstractions;

namespace Samples.MT.Common.Services.Multitenancy;

public class TenantConnectionStringProvider : ITenantConnectionStringProvider
{
    private readonly IConfiguration _configuration;

    public TenantConnectionStringProvider(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    /// <inheritdoc/>
    public string? GetDbConnection(string tenantConfigStoreKey)
    {
        return _configuration[tenantConfigStoreKey];
    }
}