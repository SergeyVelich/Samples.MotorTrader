using Samples.Infrastructure.Data.Entities;
using Samples.MT.Common.Data.TenantDb.Entities.Enums;

namespace Samples.MT.Common.Data.TenantDb.Entities;

public class TenantEntity : BaseEntity<int>
{
    public string ExternalId { get; set; } = null!;
    public string Name { get; set; } = null!;
    public string SubdomainName { get; set; } = null!;
    public string? Email { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Address { get; set; }
    public TenantStatus Status { get; set; }
    public string? LogoId { get; set; }
    public ColoringScheme ColoringScheme { get; set; }
    public bool IsMaster { get; set; }
    public virtual ICollection<UserEntity> Users { get; set; } = [];
    public virtual ICollection<RoleEntity> Roles { get; set; } = [];
}