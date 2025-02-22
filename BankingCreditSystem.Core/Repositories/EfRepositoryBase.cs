namespace BankingCreditSystem.Core.Repositories;

using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

public class EfRepositoryBase<TEntity, TId, TContext> : IAsyncRepository<TEntity, TId>
    where TEntity : Entity<TId>
    where TContext : DbContext
{
    protected readonly TContext Context;

    public EfRepositoryBase(TContext context)
    {
        Context = context;
    }

    public async Task<TEntity> GetAsync(TId id, bool tracking = true, bool withDeleted = false)
    {
        var query = Context.Set<TEntity>().AsQueryable();
        
        if (!tracking)
            query = query.AsNoTracking();
        
        if (!withDeleted)   
            query = query.Where(e => e.DeletedDate == null);

        return await query.FirstOrDefaultAsync(e => e.Id.Equals(id));
    }

    public async Task<TEntity> AddAsync(TEntity entity)
    {
        entity.CreatedDate = DateTime.UtcNow;
        await Context.AddAsync(entity);
        await Context.SaveChangesAsync();
        return entity;
    }

    public async Task<TEntity> UpdateAsync(TEntity entity)
    {
        entity.UpdatedDate = DateTime.UtcNow;
        Context.Update(entity);
        await Context.SaveChangesAsync();
        return entity;
    }

    public async Task<TEntity> DeleteAsync(TEntity entity)
    {
        entity.DeletedDate = DateTime.UtcNow;
        Context.Update(entity);
        await Context.SaveChangesAsync();
        return entity;
    }

    public async Task<IList<TEntity>> GetListAsync(bool tracking = true, bool withDeleted = false)
    {
        var query = Context.Set<TEntity>().AsQueryable();
        
        if (!tracking)
            query = query.AsNoTracking();
        
        if (!withDeleted)
            query = query.Where(e => e.DeletedDate == null);

        return await query.ToListAsync();
    }

    public async Task<IList<TEntity>> AddRangeAsync(IList<TEntity> entities)
    {
        foreach (var entity in entities)
            entity.CreatedDate = DateTime.UtcNow;
            
        await Context.AddRangeAsync(entities);
        await Context.SaveChangesAsync();
        return entities;
    }

    public async Task<IList<TEntity>> UpdateRangeAsync(IList<TEntity> entities)
    {
        foreach (var entity in entities)
            entity.UpdatedDate = DateTime.UtcNow;
            
        Context.UpdateRange(entities);
        await Context.SaveChangesAsync();
        return entities;
    }

    public async Task<IList<TEntity>> DeleteRangeAsync(IList<TEntity> entities)
    {
        foreach (var entity in entities)
            entity.DeletedDate = DateTime.UtcNow;
            
        Context.UpdateRange(entities);
        await Context.SaveChangesAsync();
        return entities;
    }

    public async Task<TEntity> GetAsync(
        Expression<Func<TEntity, bool>> predicate,
        bool tracking = true,
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
        bool withDeleted = false)
    {
        var query = Context.Set<TEntity>().AsQueryable();

        if (!tracking)
            query = query.AsNoTracking();

        if (include != null)
            query = include(query);

        if (!withDeleted)
            query = query.Where(e => e.DeletedDate == null);

        return await query.FirstOrDefaultAsync(predicate);
    }

    public async Task<IList<TEntity>> GetListAsync(
        Expression<Func<TEntity, bool>>? predicate = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
        bool tracking = true,
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
        bool withDeleted = false)
    {
        var query = Context.Set<TEntity>().AsQueryable();

        if (!tracking)
            query = query.AsNoTracking();

        if (include != null)
            query = include(query);

        if (!withDeleted)
            query = query.Where(e => e.DeletedDate == null);

        if (predicate != null)
            query = query.Where(predicate);

        if (orderBy != null)
            query = orderBy(query);

        return await query.ToListAsync();
    }

    public async Task<IPaginate<TEntity>> GetListAsyncPaginate(
        Expression<Func<TEntity, bool>>? predicate = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
        int index = 0,
        int size = 10,
        bool tracking = true,
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
        bool withDeleted = false)
    {
        var query = Context.Set<TEntity>().AsQueryable();

        if (!tracking)
            query = query.AsNoTracking();

        if (include != null)
            query = include(query);

        if (!withDeleted)
            query = query.Where(e => e.DeletedDate == null);

        if (predicate != null)
            query = query.Where(predicate);

        if (orderBy != null)
            query = orderBy(query);

        return new Paginate<TEntity>(query, index, size, 0);
    }

    public async Task<bool> AnyAsync(Expression<Func<TEntity, bool>>? predicate = null, bool withDeleted = false)
    {
        var query = Context.Set<TEntity>().AsQueryable();

        if (!withDeleted)
            query = query.Where(e => e.DeletedDate == null);

        if (predicate != null)
            query = query.Where(predicate);

        return await query.AnyAsync();
    }
} 