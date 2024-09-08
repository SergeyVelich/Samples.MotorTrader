using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Samples.Infrastructure.Common.Abstractions;
using Samples.Infrastructure.Data.Entities;

namespace Samples.Infrastructure.Data.EfCore.Interceptors;

public sealed class AuditInterceptor : SaveChangesInterceptor
{
    private readonly IDbOperationContext _dbOperationContext;

    public AuditInterceptor(IDbOperationContext dbOperationContext)
    {
        _dbOperationContext = dbOperationContext;
    }

    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(
        DbContextEventData eventData,
        InterceptionResult<int> result,
        CancellationToken cancellationToken = default)
    {
        if (eventData.Context is null)
        {
            return base.SavingChangesAsync(eventData, result, cancellationToken);
        }

        var entries = eventData.Context.ChangeTracker
            .Entries<AuditEntity>()
            .Where(e => e is { State: EntityState.Added or EntityState.Modified or EntityState.Deleted });

        var currentUserId = _dbOperationContext.UserId;

        foreach (var entry in entries)
        {
            var auditEntity = entry.Entity;
            if (entry.State == EntityState.Added)
            {
                auditEntity.CreatedAt = DateTimeOffset.Now;
                auditEntity.CreatedBy = currentUserId;
            }
            else
            {
                auditEntity.ModifiedAt = DateTimeOffset.Now;
                auditEntity.ModifiedBy = currentUserId;
            }
        }

        return base.SavingChangesAsync(eventData, result, cancellationToken);
    }
}