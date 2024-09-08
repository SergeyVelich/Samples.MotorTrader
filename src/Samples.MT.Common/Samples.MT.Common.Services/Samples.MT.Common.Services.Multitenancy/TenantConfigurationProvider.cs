using AutoMapper;
using Samples.MT.Common.Data.PlatformDb.Abstractions;
using Samples.MT.Common.Models;
using Samples.MT.Common.Services.Multitenancy.Abstractions;

namespace Samples.MT.Common.Services.Multitenancy;

public class TenantConfigurationProvider : ITenantConfigurationProvider
{
    private readonly IPlatformDbUnitOfWork _platformDbUnitOfWork;
    private readonly ITenantConnectionStringProvider _tenantConnectionStringProvider;
    private readonly IMapper _mapper;

    public TenantConfigurationProvider(IPlatformDbUnitOfWork platformDbUnitOfWork, ITenantConnectionStringProvider tenantConnectionStringProvider, IMapper mapper)
    {
        _platformDbUnitOfWork = platformDbUnitOfWork;
        _tenantConnectionStringProvider = tenantConnectionStringProvider;
        _mapper = mapper;
    }

    /// <inheritdoc/>
    public async Task<IEnumerable<TenantConfiguration>> GetTenantConfigurationsAsync(CancellationToken cancellationToken)
    {
        var tenantConfigurationEntities = await _platformDbUnitOfWork.TenantConfigsRepository.GetAllByAsync(e => true, cancellationToken);
        var tenantConfigurations = _mapper.Map<List<TenantConfiguration>>(tenantConfigurationEntities);
        SetResourceConnections(tenantConfigurations);

        return tenantConfigurations;
    }

    /// <inheritdoc/>
    public async Task<TenantConfiguration?> GetTenantConfigurationAsync(int tenantId, CancellationToken cancellationToken)
    {
        var tenantsConfigurations = await GetTenantConfigurationsAsync(cancellationToken);

        return tenantsConfigurations.FirstOrDefault(c => c.Id == tenantId);
    }

    private void SetResourceConnections(IReadOnlyCollection<TenantConfiguration> tenantConfigurations)
    {
        foreach (var tenantConfiguration in tenantConfigurations)
        {
            tenantConfiguration.DbConnectionString = _tenantConnectionStringProvider.GetDbConnection(tenantConfiguration.TenantConfigStoreKey);
        }
    }
}