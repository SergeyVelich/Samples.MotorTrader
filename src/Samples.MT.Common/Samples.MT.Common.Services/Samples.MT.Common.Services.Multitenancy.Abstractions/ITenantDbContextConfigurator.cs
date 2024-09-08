using Samples.MT.Common.Data.TenantDb.EfCore.Configuration;

namespace Samples.MT.Common.Services.Multitenancy.Abstractions;

public interface ITenantDbContextConfigurator
{
    Task<TenantDbConfiguration> GetConfigurationAsync(CancellationToken cancellationToken);//TODO Unbind TenantDbConfiguration from EFCore to avoid unwanted dependency
}