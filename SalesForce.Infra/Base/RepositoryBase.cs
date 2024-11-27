using SalesForce.Domain.Interfaces.Base;
using System.Linq.Expressions;

namespace SalesForce.Infra.Base;
public abstract class RepositoryBase<TEntity> : IRepository<TEntity> where TEntity : class
{
    public abstract IQueryable<TEntity> GetAll();
    public virtual Task<IQueryable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate)
    {
        return Task.FromResult(GetAll().Where(predicate));
    }
    public virtual Task<List<TEntity>> GetAllList()
    {
        return Task.FromResult(GetAll().ToList());
    }
    public abstract TEntity Find(Expression<Func<TEntity, bool>> predicate);

    public virtual Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> predicate)
    {
        return Task.FromResult(Find(predicate));
    }

    public abstract Task<IQueryable<TEntity>> GetAllIncludeAsync(Expression<Func<TEntity, bool>> predicate = null, bool? asNoTracking = false, params Expression<Func<TEntity, object>>[] includes);

    public abstract Task<IQueryable<TEntity>> GetIncludeAsync(params Expression<Func<TEntity, object>>[] includes);

    #region Insert
    public abstract TEntity Insert(TEntity entity);
    public virtual Task<TEntity> InsertAsync(TEntity entity)
    {
        return Task.FromResult(Insert(entity));
    }
    #endregion


    #region Update
    public abstract TEntity Update(TEntity entity);

    public virtual Task<TEntity> UpdateAsync(TEntity entity)
    {
        return Task.FromResult(Update(entity));
    }
    #endregion

    #region Delete
    public abstract void Delete(TEntity entity);

    public virtual Task DeleteAsync(TEntity entity)
    {
        Delete(entity);

        return Task.CompletedTask;
    }


    public virtual void Delete(Expression<Func<TEntity, bool>> predicate)
    {
        var list = GetAllList();
        foreach (var entity in list.Result)
        {
            Delete(entity);
        }
    }

    public void Delete(int id)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    #endregion


}
