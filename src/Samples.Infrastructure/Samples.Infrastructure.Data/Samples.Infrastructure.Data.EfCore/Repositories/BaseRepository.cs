using Microsoft.EntityFrameworkCore;
using Samples.Infrastructure.Data.Abstractions.Repositories;
using Samples.Infrastructure.Data.Entities.Interfaces;
using System.Linq.Expressions;

namespace Samples.Infrastructure.Data.EfCore.Repositories;

public abstract class BaseRepository<TEntity, TKey> : IRepository<TEntity, TKey>
    where TEntity : class, IEntityKey<TKey>
    where TKey : struct
{
    protected readonly DbSet<TEntity> _dbSet;

    protected BaseRepository(DbSet<TEntity> dbSet)
    {
        _dbSet = dbSet;
    }

    public Task<TEntity?> FindSingleAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
    {
        return _dbSet.FirstOrDefaultAsync(predicate, cancellationToken);
    }

    public Task<List<TEntity>> GetAllByAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
    {
        return _dbSet.Where(predicate).ToListAsync(cancellationToken);
    }

    public Task<int> CountAllByAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
    {
        return _dbSet.Where(predicate).CountAsync(cancellationToken);
    }

    public async Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        return (await _dbSet.AddAsync(entity, cancellationToken)).Entity;
    }

    public Task AddRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default)
    {
        return _dbSet.AddRangeAsync(entities, cancellationToken);
    }

    public void Update(TEntity entity)
    {
        _dbSet.Update(entity);
    }

    public void UpdateRange(IEnumerable<TEntity> entities)
    {
        _dbSet.UpdateRange(entities);
    }

    public Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken)
    {
        return _dbSet.AnyAsync(predicate, cancellationToken);
    }

    public void Delete(TEntity entity)
    {
        _dbSet.Remove(entity);
    }

    public void DeleteRange(IEnumerable<TEntity> entities)
    {
        _dbSet.RemoveRange(entities);
    }
}