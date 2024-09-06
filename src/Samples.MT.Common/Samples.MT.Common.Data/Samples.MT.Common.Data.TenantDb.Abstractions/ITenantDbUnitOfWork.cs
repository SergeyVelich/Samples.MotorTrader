using Samples.Infrastructure.Data.Abstractions;
using Samples.MT.Common.Data.TenantDb.Abstractions.Repositories;

namespace Samples.MT.Common.Data.TenantDb.Abstractions;

public interface ITenantDbUnitOfWork : IUnitOfWork
{
    IRolesRepository RolesRepository { get; }
    ITenantsRepository TenantsRepository { get; }
    IUsersRepository UsersRepository { get; }
}