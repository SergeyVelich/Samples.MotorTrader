namespace Samples.MT.Common.Services.Multitenancy.Abstractions;

public interface ITenantConnectionStringProvider
{
    string? GetDbConnection(string tenantConfigStoreKey);
}