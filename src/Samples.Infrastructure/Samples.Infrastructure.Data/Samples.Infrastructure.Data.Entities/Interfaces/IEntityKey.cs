namespace Samples.Infrastructure.Data.Entities.Interfaces;

public interface IEntityKey<T> where T : struct
{
    public T Id { get; }
}