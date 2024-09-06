using Microsoft.EntityFrameworkCore;
using Samples.Infrastructure.Data.Abstractions;

namespace Samples.Infrastructure.Data.EfCore;

public class BaseUnitOfWork : IUnitOfWork
{
    private readonly DbContext _context;

    public BaseUnitOfWork(DbContext context)
    {
        _context = context;
    }

    public Task CommitAsync(CancellationToken cancellationToken = default)
    {
        return _context.SaveChangesAsync(cancellationToken);
    }
}