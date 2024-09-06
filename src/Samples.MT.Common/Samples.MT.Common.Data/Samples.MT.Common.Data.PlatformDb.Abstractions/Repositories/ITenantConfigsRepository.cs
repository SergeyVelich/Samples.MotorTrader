using Samples.Infrastructure.Data.Abstractions.Repositories;
using Samples.MT.Common.Data.PlatformDb.Entities;

namespace Samples.MT.Common.Data.PlatformDb.Abstractions.Repositories;

public interface ITenantConfigsRepository : IRepository<TenantConfigEntity, int>
{
}