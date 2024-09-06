using Samples.Infrastructure.Data.Entities;

namespace Samples.MT.Common.Data.TenantDb.Entities;

public class RoleEntity : BaseEntity<Guid>
{
    public string ExternalId { get; set; } = null!;
    public int TenantId { get; set; }
    public string Name { get; set; } = null!;
    public bool IsSystem { get; set; }
}