using Microsoft.EntityFrameworkCore;
using SalesForce.Domain.Interfaces.Base;
using System.Linq.Expressions;

namespace SalesForce.Infra.Base;
public abstract class EFCoreRepositoryBase<TdbContext, TEntity> : RepositoryBase<TEntity>, IRepository<TEntity> where TEntity : class where TdbContext : DbContext
{
    private readonly TdbContext _dbContextProvider;
    public EFCoreRepositoryBase(TdbContext dbContextProvider)
    {
        _dbContextProvider = dbContextProvider;

    }
    public override IQueryable<TEntity> GetAll()
    {
        throw new NotImplementedException();
    }

    public virtual async Task<DbSet<TEntity>> GetTableAsync()
    {
        var context = _dbContextProvider;
        return context.Set<TEntity>();
    }
    public virtual async Task<DbContext> GetDbContext()
    {
        var context = _dbContextProvider;
        return context;
    }
    public virtual DbSet<TEntity> Table => _dbContextProvider.Set<TEntity>();
    public virtual DbContext context => _dbContextProvider;

    public override async Task<TEntity> InsertAsync(TEntity entity)
    {
        try
        {
            var table = await GetTableAsync();
            var retorno = (await table.AddAsync(entity)).Entity;
            _dbContextProvider.SaveChanges();

            return retorno;
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }
    public override TEntity Insert(TEntity entity)
    {
        var retorno = Table.Add(entity).Entity;
        _dbContextProvider.SaveChanges();
        return retorno;
    }

    public override async Task<List<TEntity>> GetAllList()
    {
        var table = await GetTableAsync();
        return await table.ToListAsync();
    }

    public override async Task<IQueryable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate)
    {
        var table = await GetTableAsync();
        return table.AsQueryable().AsNoTracking().Where(predicate);
    }

    protected virtual void AttachIfNot(TEntity entity)
    {
        if (!Table.Local.Contains(entity))
        {
            Table.Attach(entity);
        }
    }
    public override TEntity Update(TEntity entity)
    {
        _dbContextProvider.Entry(entity).State = EntityState.Modified;
        _dbContextProvider.SaveChanges();
        return entity;
    }

    public override Task<TEntity> UpdateAsync(TEntity entity)
    {
        AttachIfNot(entity);
        _dbContextProvider.Entry(entity).State = EntityState.Modified;
        _dbContextProvider.SaveChanges();
        return Task.FromResult(entity);
    }

    public override void Delete(TEntity entity)
    {
        AttachIfNot(entity);
        Table.Remove(entity);
        _dbContextProvider.SaveChanges();
    }

    public override TEntity Find(Expression<Func<TEntity, bool>> predicate)
    {

        var context = _dbContextProvider;
        return context.Set<TEntity>().Find(predicate);

    }

    public override async Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> predicate)
    {
        var table = await GetTableAsync();
        return await table.FirstOrDefaultAsync(predicate);
    }

    public override Task<IQueryable<TEntity>> GetAllIncludeAsync(Expression<Func<TEntity, bool>> predicate = null, bool? asNoTracking = false, params Expression<Func<TEntity, object>>[] includes)
    {

        var query = Table.AsQueryable();

        if (asNoTracking == true)
        {
            query = query.AsNoTracking();
        }

        if (includes != null)
        {
            query = includes.Aggregate(query, (current, include) => current.Include(include));
        }

        if (predicate != null)
        {
            query = query.Where(predicate);
        }

        return Task.FromResult(query);
    }

    public override Task<IQueryable<TEntity>> GetIncludeAsync(params Expression<Func<TEntity, object>>[] includes)
    {
        var query = Table.AsQueryable();

        if (includes != null)
        {
            query = includes.Aggregate(query, (current, include) => current.Include(include));
        }

        return Task.FromResult(query);
    }
}