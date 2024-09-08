using Samples.Infrastructure.Data.Entities.Interfaces;

namespace Samples.Infrastructure.Data.Entities;

public class BaseEntity<T> : IEntityKey<T>, ISoftDelete
    where T : struct
{
    public T Id { get; }
    public bool IsDeleted { get; set; }
}