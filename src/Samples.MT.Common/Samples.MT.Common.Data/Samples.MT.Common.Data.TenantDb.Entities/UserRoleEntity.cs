using Samples.Infrastructure.Data.Entities;

namespace Samples.MT.Common.Data.TenantDb.Entities;

public class UserRoleEntity : BaseEntity<Guid>
{
    public int TenantId { get; set; }
    public Guid UserId { get; set; }
    public Guid RoleId { get; set; }
    public virtual TenantEntity Tenant { get; set; } = null!;
    public virtual UserEntity User { get; set; } = null!;
    public virtual RoleEntity Role { get; set; } = null!;
}