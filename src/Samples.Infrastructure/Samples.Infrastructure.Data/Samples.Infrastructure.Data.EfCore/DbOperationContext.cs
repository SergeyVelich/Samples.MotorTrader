using Samples.Infrastructure.Common.Abstractions;

namespace Samples.Infrastructure.Common;

public class DbOperationContext : IDbOperationContext
{
    public Guid? UserId { get; set; }
}