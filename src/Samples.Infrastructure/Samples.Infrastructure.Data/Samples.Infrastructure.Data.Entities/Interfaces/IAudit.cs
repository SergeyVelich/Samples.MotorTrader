namespace Samples.Infrastructure.Data.Entities.Interfaces;

public interface IAudit
{
    public DateTimeOffset CreatedAt { get; set; }
    public Guid? CreatedBy { get; set; }
    public DateTimeOffset ModifiedAt { get; set; }
    public Guid? ModifiedBy { get; set; }
}