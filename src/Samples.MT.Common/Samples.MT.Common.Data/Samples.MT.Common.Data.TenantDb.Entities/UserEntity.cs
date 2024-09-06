using Samples.Infrastructure.Data.Entities;
using Samples.MT.Common.Data.TenantDb.Entities.Enums;

namespace Samples.MT.Common.Data.TenantDb.Entities;

public class UserEntity : BaseEntity<Guid>
{
    public string ExternalId { get; set; } = null!;
    public int TenantId { get; set; }
    public string Email { get; set; } = null!;
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string? Title { get; set; }
    public string? PhoneNumber { get; set; }
    public UserStatus Status { get; set; }
    public string? AvatarId { get; set; }
    public bool IsConsentAccepted { get; set; }
    public DateTimeOffset? ConsentAcceptedAt { get; set; }
    public virtual TenantEntity Tenant { get; set; } = null!;
    public virtual ICollection<RoleEntity> Roles { get; set; } = [];
}