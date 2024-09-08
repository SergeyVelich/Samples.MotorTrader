namespace Samples.Infrastructure.Common.Abstractions;

public interface IDbOperationContext
{
    Guid? UserId { get; set; }
}