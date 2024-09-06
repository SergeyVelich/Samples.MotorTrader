using Samples.Infrastructure.Data.Entities.Interfaces;

namespace Samples.Infrastructure.Data.Entities;

public class BaseEntity<T> : IEntityKey<T>
    where T : struct
{
    public T Id { get; }
}