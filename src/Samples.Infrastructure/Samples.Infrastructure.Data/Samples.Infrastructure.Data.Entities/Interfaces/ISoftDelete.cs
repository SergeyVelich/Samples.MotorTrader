namespace Samples.Infrastructure.Data.Entities.Interfaces;

public interface ISoftDelete
{
    public bool IsDeleted { get; set; }
}