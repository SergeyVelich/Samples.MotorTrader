using Samples.Infrastructure.Data.EfCore.Repositories;
using Samples.MT.Common.Data.TenantDb.Abstractions.Repositories;
using Samples.MT.Common.Data.TenantDb.Entities;

namespace Samples.MT.Common.Data.TenantDb.EfCore.Repositories;

public class RolesRepository : BaseRepository<RoleEntity, Guid>, IRolesRepository
{
    public RolesRepository(TenantDbContext context) : base(context.Roles)
    {
    }
}