using Samples.Infrastructure.Data.Entities;

namespace Samples.MT.Common.Data.PlatformDb.Entities;

public class TenantConfigEntity : BaseEntity<int>
{
    public string ExternalId { get; set; } = null!;
    public string Name { get; set; } = null!;
    public string SubdomainName { get; set; } = null!;
    public string TenantConfigStoreKey { get; set; } = null!;
    public bool IsMaster { get; set; }
}