namespace BankingCreditSystem.Core.Repositories;

using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Query;

public interface IAsyncRepository<T, TId> where T : Entity<TId>
{
    // Tekil kayıt işlemleri
    Task<T> GetAsync(TId id, bool tracking = true, bool withDeleted = false);
    Task<T> AddAsync(T entity);
    Task<T> UpdateAsync(T entity);
    Task<T> DeleteAsync(T entity);

    // Çoklu kayıt işlemleri
    Task<IList<T>> GetListAsync(bool tracking = true, bool withDeleted = false);
    Task<IList<T>> AddRangeAsync(IList<T> entities);
    Task<IList<T>> UpdateRangeAsync(IList<T> entities);
    Task<IList<T>> DeleteRangeAsync(IList<T> entities);

    // Sorgu işlemleri
    Task<T> GetAsync(
        Expression<Func<T, bool>> predicate,
        bool tracking = true,
        Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
        bool withDeleted = false);

    Task<IList<T>> GetListAsync(
        Expression<Func<T, bool>>? predicate = null,
        Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
        bool tracking = true,
        Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
        bool withDeleted = false);

    // Sayfalama işlemleri
    Task<IPaginate<T>> GetListAsyncPaginate(
        Expression<Func<T, bool>>? predicate = null,
        Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
        int index = 0,
        int size = 10,
        bool tracking = true,
        Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
        bool withDeleted = false);

    // Varlık kontrolü
    Task<bool> AnyAsync(Expression<Func<T, bool>>? predicate = null, bool withDeleted = false);
} 