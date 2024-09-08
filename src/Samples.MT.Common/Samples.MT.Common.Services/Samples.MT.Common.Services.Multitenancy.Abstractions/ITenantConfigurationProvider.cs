using Samples.MT.Common.Models;

namespace Samples.MT.Common.Services.Multitenancy.Abstractions;

public interface ITenantConfigurationProvider
{
    Task<TenantConfiguration?> GetTenantConfigurationAsync(int tenantId, CancellationToken cancellationToken);
    Task<IEnumerable<TenantConfiguration>> GetTenantConfigurationsAsync(CancellationToken cancellationToken);
}