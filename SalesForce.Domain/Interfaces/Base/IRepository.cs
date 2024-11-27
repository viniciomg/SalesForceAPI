using System.Linq.Expressions;

namespace SalesForce.Domain.Interfaces.Base;

public interface IRepository<TEntity> where TEntity : class 
{
    Task<TEntity> InsertAsync(TEntity entity);
    Task<List<TEntity>> GetAllList();
    Task<IQueryable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate);
    Task<IQueryable<TEntity>> GetAllIncludeAsync(Expression<Func<TEntity, bool>> predicate = null, bool? asNoTracking = false, params Expression<Func<TEntity, object>>[] includes);
    Task<IQueryable<TEntity>> GetIncludeAsync(params Expression<Func<TEntity, object>>[] includes);
    Task<TEntity> UpdateAsync(TEntity entity);
    Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> predicate);
    void Delete(TEntity entity);
    Task DeleteAsync(TEntity entity);
    void Delete(int id);
    Task DeleteAsync(int id);
    void Delete(Expression<Func<TEntity, bool>> predicate);
}
