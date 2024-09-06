using Samples.Infrastructure.Data.Entities.Interfaces;
using System.Linq.Expressions;

namespace Samples.Infrastructure.Data.Abstractions.Repositories;

public interface IRepository<TEntity, TKey>
    where TEntity : class, IEntityKey<TKey>
    where TKey : struct
{
    Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken = default);
    Task AddRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default);
    Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken);
    Task<int> CountAllByAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default);
    void Delete(TEntity entity);
    void DeleteRange(IEnumerable<TEntity> entities);
    Task<TEntity?> FindSingleAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default);
    Task<List<TEntity>> GetAllByAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default);
    void Update(TEntity entity);
    void UpdateRange(IEnumerable<TEntity> entities);
}