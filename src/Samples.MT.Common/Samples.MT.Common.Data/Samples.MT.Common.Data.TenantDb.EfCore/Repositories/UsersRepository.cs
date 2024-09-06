using Samples.Infrastructure.Data.EfCore.Repositories;
using Samples.MT.Common.Data.TenantDb.Abstractions.Repositories;
using Samples.MT.Common.Data.TenantDb.Entities;

namespace Samples.MT.Common.Data.TenantDb.EfCore.Repositories;

public class UsersRepository : BaseRepository<UserEntity, Guid>, IUsersRepository
{
    public UsersRepository(TenantDbContext context) : base(context.Users)
    {
    }
}