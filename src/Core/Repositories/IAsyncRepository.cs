using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Query;
using System.Threading;

namespace Bank.Core.Repositories;

public interface IAsyncRepository<TEntity, TId> where TEntity : Entity<TId>
{
    // Get
    Task<TEntity?> GetAsync(
        Expression<Func<TEntity, bool>> predicate,
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default);

    // Get List
    Task<Paginate<TEntity>> GetListAsync(
        Expression<Func<TEntity, bool>>? predicate = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default);

    // Any
    Task<bool> AnyAsync(
        Expression<Func<TEntity, bool>>? predicate = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default);

    // Command Operations
    Task<TEntity> AddAsync(TEntity entity);
    Task<TEntity> UpdateAsync(TEntity entity);
    Task<TEntity> DeleteAsync(TId id);
}
