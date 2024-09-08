namespace Samples.Infrastructure.Data.Entities.Interfaces;

public interface IOptimisticConcurrency
{
    public byte[] Version { get; }
}