namespace Samples.MT.Common.Models;

public class TenantConfiguration
{
    public int Id { get; set; }
    public string ExternalId { get; set; } = null!;
    public string Name { get; set; } = null!;
    public string SubdomainName { get; set; } = null!;
    public string TenantConfigStoreKey { get; set; } = null!;
    public bool IsMaster { get; set; }
    public string? DbConnectionString { get; set; }
}