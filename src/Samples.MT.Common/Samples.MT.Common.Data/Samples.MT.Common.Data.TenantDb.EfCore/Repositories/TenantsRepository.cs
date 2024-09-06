using Samples.Infrastructure.Data.EfCore.Repositories;
using Samples.MT.Common.Data.TenantDb.Abstractions.Repositories;
using Samples.MT.Common.Data.TenantDb.Entities;

namespace Samples.MT.Common.Data.TenantDb.EfCore.Repositories;

public class TenantsRepository : BaseRepository<TenantEntity, int>, ITenantsRepository
{
    public TenantsRepository(TenantDbContext context) : base(context.Tenants)
    {
    }
}