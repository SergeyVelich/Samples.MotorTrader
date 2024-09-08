namespace Samples.MT.Common.Services.Abstractions;

public interface IRequestContext
{
    Guid? UserId { get; set; }
    string? UserExternalId { get; set; }
    int TenantId { get; set; }
    string? TenantExternalId { get; set; }
    int TargetTenantId { get; set; }
}