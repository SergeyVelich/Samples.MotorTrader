using AutoMapper;
using Samples.Infrastructure.Resources.Cache.Abstractions;
using Samples.MT.Common.Data.PlatformDb.Abstractions;
using Samples.MT.Common.Models;
using Samples.MT.Common.Services.Multitenancy.Abstractions;
using static Samples.MT.Common.Services.Constants;

namespace Samples.MT.Common.Services.Multitenancy;

public class TenantConfigurationProvider : ITenantConfigurationProvider
{
    private readonly ICacheService _cache;
    private readonly IPlatformDbUnitOfWork _platformDbUnitOfWork;
    private readonly ITenantConnectionStringProvider _tenantConnectionStringProvider;
    private readonly IMapper _mapper;

    public TenantConfigurationProvider(ICacheService cache, IPlatformDbUnitOfWork platformDbUnitOfWork, ITenantConnectionStringProvider tenantConnectionStringProvider, IMapper mapper)
    {
        _cache = cache;
        _platformDbUnitOfWork = platformDbUnitOfWork;
        _tenantConnectionStringProvider = tenantConnectionStringProvider;
        _mapper = mapper;
    }

    /// <inheritdoc/>
    public async Task<IEnumerable<TenantConfiguration>> GetTenantConfigurationsAsync(CancellationToken cancellationToken)
    {
        var tenantConfigurations = await _cache.GetAsync<List<TenantConfiguration>>(Cache.TenantConfigurationsKey, cancellationToken);
        if (tenantConfigurations is not null && tenantConfigurations.Count != 0)//TODO
        {
            return tenantConfigurations;
        }

        var tenantConfigurationEntities = await _platformDbUnitOfWork.TenantConfigsRepository.GetAllByAsync(e => true, cancellationToken);
        tenantConfigurations = _mapper.Map<List<TenantConfiguration>>(tenantConfigurationEntities);
        SetResourceConnections(tenantConfigurations);
        await _cache.SetAsync(Cache.TenantConfigurationsKey, tenantConfigurations, cancellationToken);

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