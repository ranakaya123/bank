using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Threading;

namespace Bank.Core.Repositories;

public class AsyncRepository<TEntity, TId> : IAsyncRepository<TEntity, TId> where TEntity : Entity<TId>
{
    private readonly DbContext _context;
    private readonly DbSet<TEntity> _dbSet;

    public AsyncRepository(DbContext context)
    {
        _context = context;
        _dbSet = context.Set<TEntity>();
    }

    public async Task<TEntity?> GetAsync(
        Expression<Func<TEntity, bool>> predicate,
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default)
    {
        IQueryable<TEntity> queryable = _dbSet.AsQueryable();

        if (!enableTracking)
            queryable = queryable.AsNoTracking();

        if (include != null)
            queryable = include(queryable);

        // Soft delete kontrolü kaldırıldı - DeletedDate property'si yok
        // if (!withDeleted)
        //     queryable = queryable.Where(x => x.DeletedDate == null);

        return await queryable.FirstOrDefaultAsync(predicate, cancellationToken);
    }

    public async Task<Paginate<TEntity>> GetListAsync(
        Expression<Func<TEntity, bool>>? predicate = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default)
    {
        IQueryable<TEntity> queryable = _dbSet.AsQueryable();

        if (!enableTracking)
            queryable = queryable.AsNoTracking();

        if (include != null)
            queryable = include(queryable);

        // Soft delete kontrolü kaldırıldı - DeletedDate property'si yok
        // if (!withDeleted)
        //     queryable = queryable.Where(x => x.DeletedDate == null);

        if (predicate != null)
            queryable = queryable.Where(predicate);

        if (orderBy != null)
            queryable = orderBy(queryable);

        var totalCount = await queryable.CountAsync(cancellationToken);
        var items = await queryable.Skip(index * size).Take(size).ToListAsync(cancellationToken);

        return new Paginate<TEntity>(items, index, size, index * size);
    }

    public async Task<bool> AnyAsync(
        Expression<Func<TEntity, bool>>? predicate = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default)
    {
        IQueryable<TEntity> queryable = _dbSet.AsQueryable();

        if (!enableTracking)
            queryable = queryable.AsNoTracking();

        // Soft delete kontrolü kaldırıldı - DeletedDate property'si yok
        // if (!withDeleted)
        //     queryable = queryable.Where(x => x.DeletedDate == null);

        if (predicate != null)
            queryable = queryable.Where(predicate);

        return await queryable.AnyAsync(cancellationToken);
    }

    public async Task<TEntity> AddAsync(TEntity entity)
    {
        var addedEntity = await _dbSet.AddAsync(entity);
        await _context.SaveChangesAsync();
        return addedEntity.Entity;
    }

    public async Task<TEntity> UpdateAsync(TEntity entity)
    {
        var updatedEntity = _dbSet.Update(entity);
        await _context.SaveChangesAsync();
        return updatedEntity.Entity;
    }

    public async Task<TEntity> DeleteAsync(TId id)
    {
        var entity = await _dbSet.FindAsync(id);
        if (entity != null)
        {
            // Soft delete kaldırıldı - DeletedDate property'si yok
            // entity.DeletedDate = DateTime.UtcNow;
            // var deletedEntity = _dbSet.Update(entity);
            // await _context.SaveChangesAsync();
            // return deletedEntity.Entity;
            
            // Hard delete yapılıyor
            var deletedEntity = _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
            return deletedEntity.Entity;
        }
        throw new InvalidOperationException($"Entity with id {id} not found.");
    }

    protected IQueryable<TEntity> Query()
    {
        return _dbSet.AsQueryable();
    }
}
