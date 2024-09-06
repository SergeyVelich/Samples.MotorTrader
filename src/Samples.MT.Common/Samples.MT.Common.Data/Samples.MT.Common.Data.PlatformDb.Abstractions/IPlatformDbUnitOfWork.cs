using Samples.Infrastructure.Data.Abstractions;
using Samples.MT.Common.Data.PlatformDb.Abstractions.Repositories;

namespace Samples.MT.Common.Data.PlatformDb.Abstractions;

public interface IPlatformDbUnitOfWork : IUnitOfWork
{
    ITenantConfigsRepository TenantConfigsRepository { get; }
}