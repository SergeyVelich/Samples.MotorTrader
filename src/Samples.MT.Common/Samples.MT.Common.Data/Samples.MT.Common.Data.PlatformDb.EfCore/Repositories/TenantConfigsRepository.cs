using Samples.Infrastructure.Data.EfCore.Repositories;
using Samples.MT.Common.Data.PlatformDb.Abstractions.Repositories;
using Samples.MT.Common.Data.PlatformDb.Entities;

namespace Samples.MT.Common.Data.PlatformDb.EfCore.Repositories;

public class TenantConfigsRepository : BaseRepository<TenantConfigEntity, int>, ITenantConfigsRepository
{
    public TenantConfigsRepository(PlatformDbContext context) : base(context.Tenants)
    {
    }
}