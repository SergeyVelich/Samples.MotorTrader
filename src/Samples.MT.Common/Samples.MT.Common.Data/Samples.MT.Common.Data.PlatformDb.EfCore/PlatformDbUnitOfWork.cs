using Samples.MT.Common.Data.PlatformDb.Abstractions;
using Samples.MT.Common.Data.PlatformDb.Abstractions.Repositories;
using Samples.MT.Common.Data.PlatformDb.EfCore.Repositories;

namespace Samples.MT.Common.Data.PlatformDb.EfCore;

public class PlatformDbUnitOfWork : IPlatformDbUnitOfWork
{
    private readonly PlatformDbContext _context;

    private ITenantConfigsRepository? _tenantConfigsRepository;

    public PlatformDbUnitOfWork(PlatformDbContext context)
    {
        _context = context;
    }

    public ITenantConfigsRepository TenantConfigsRepository => _tenantConfigsRepository ??= new TenantConfigsRepository(_context);

    public Task CommitAsync(CancellationToken cancellationToken = default)
    {
        return _context.SaveChangesAsync(cancellationToken);
    }
}