using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Samples.MT.Common.Data.TenantDb.Abstractions;
using Samples.MT.Common.Data.TenantDb.Abstractions.Repositories;
using Samples.MT.Common.Data.TenantDb.EfCore.Repositories;
using System.Data;

namespace Samples.MT.Common.Data.TenantDb.EfCore;

public class TenantDbUnitOfWork : ITenantDbUnitOfWork
{
    private readonly TenantDbContext _context;

    private ITenantsRepository? _tenantsRepository;
    private IUsersRepository? _usersRepository;
    private IRolesRepository? _rolesRepository;

    public TenantDbUnitOfWork(TenantDbContext context)
    {
        _context = context;
    }

    public ITenantsRepository TenantsRepository => _tenantsRepository ??= new TenantsRepository(_context);
    public IUsersRepository UsersRepository => _usersRepository ??= new UsersRepository(_context);
    public IRolesRepository RolesRepository => _rolesRepository ??= new RolesRepository(_context);

    public Task<IDbContextTransaction> BeginTransactionAsync(IsolationLevel level, CancellationToken cancellationToken)
    {
        return _context.Database.BeginTransactionAsync(level, cancellationToken);
    }

    public Task CommitAsync(CancellationToken cancellationToken = default)
    {
        return _context.SaveChangesAsync(cancellationToken);
    }

    public async Task CommitAsync(IDbContextTransaction transaction, CancellationToken cancellationToken)
    {
        await _context.SaveChangesAsync(cancellationToken);
        await transaction.CommitAsync(cancellationToken);
    }
}