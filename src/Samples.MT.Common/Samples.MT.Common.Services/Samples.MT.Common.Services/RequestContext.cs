using Samples.MT.Common.Services.Abstractions;

namespace Samples.MT.Common;

public class RequestContext : IRequestContext
{
    public Guid? UserId { get; set; }
    public string? UserExternalId { get; set; }
    public int TenantId { get; set; }
    public string? TenantExternalId { get; set; }
    public int TargetTenantId { get; set; }
}