using System.Linq.Expressions;
using AutoMapper;
using EXE201.SmartThrive.Domain.Contracts.Bases;
using EXE201.SmartThrive.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EXE201.SmartThrive.Repositories.Base;

public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
{
    private readonly DbContext _dbContext;
    protected readonly IMapper Mapper;

    public BaseRepository(DbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public BaseRepository(DbContext dbContext, IMapper mapper) : this(dbContext)
    {
        Mapper = mapper;
    }

    protected DbSet<TEntity> DbSet
    {
        get
        {
            var dbSet = GetDbSet<TEntity>();
            return dbSet;
        }
    }

    #region GetAll(CancellationToken)

    public async Task<IList<TEntity>> GetAll(CancellationToken cancellationToken = default)
    {
        var queryable = GetQueryable(cancellationToken);
        var result = await queryable.Where(entity => !entity.IsDeleted).ToListAsync(cancellationToken);
        return result;
    }

    #endregion

    #region Check(Guid) + CheckCancellationToken(CancellationToken)

    public async Task<bool> Check(Guid id)
    {
        return await DbSet.AnyAsync(t => t.Id.Equals(id));
    }

    public virtual void CheckCancellationToken(CancellationToken cancellationToken = default)
    {
        if (cancellationToken.IsCancellationRequested)
            throw new OperationCanceledException("Request was cancelled");
    }

    #endregion

    #region Add(TEntity) + AddRange(IEnumerable<TEntity>)

    public void Add(TEntity entity)
    {
        DbSet.Add(entity);
    }

    public void AddRange(IEnumerable<TEntity> entities)
    {
        if (entities.Any()) DbSet.AddRange(entities);
    }

    #endregion

    #region Update(TEntity) + UpdateRange(IEnumerable<TEntity>)

    public void Update(TEntity entity)
    {
        DbSet.Update(entity);
    }

    public void UpdateRange(IEnumerable<TEntity> entities)
    {
        if (entities.Any()) DbSet.UpdateRange(entities);
    }

    #endregion

    #region Delete(TEntity) + DeleteRange(IEnumerable<TEntity>)

    public void Delete(TEntity entity)
    {
        entity.IsDeleted = true;
        DbSet.Update(entity);
    }

    public void DeleteRange(IEnumerable<TEntity> entities)
    {
        entities.Where(e => e.IsDeleted == false ? e.IsDeleted = true : e.IsDeleted = false);
        DbSet.UpdateRange(entities);
    }

    #endregion

    #region GetById(Guid) + GetByIds(IList<Guid>)

    public virtual async Task<TEntity?> GetById(Guid id)
    {
        var queryable = GetQueryable(x => x.Id == id);
        var entity = await queryable.FirstOrDefaultAsync();

        return entity;
    }

    public virtual async Task<IList<TEntity>> GetByIds(IList<Guid> ids)
    {
        var queryable = GetQueryable(x => ids.Contains(x.Id));
        var entity = await queryable.ToListAsync();

        return entity;
    }

    #endregion

    #region GetQueryable(CancellationToken) + GetQueryable() + GetQueryable(Expression<Func<TEntity, bool>>)

    public IQueryable<TEntity> GetQueryable(CancellationToken cancellationToken = default)
    {
        CheckCancellationToken(cancellationToken);
        var queryable = GetQueryable<TEntity>();
        return queryable;
    }

    public IQueryable<T> GetQueryable<T>()
        where T : BaseEntity
    {
        IQueryable<T> queryable = GetDbSet<T>(); // like DbSet in this
        return queryable;
    }

    public IQueryable<TEntity> GetQueryable(Expression<Func<TEntity, bool>> predicate)
    {
        var queryable = GetQueryable<TEntity>();
        queryable = queryable.Where(predicate);
        return queryable;
    }

    #endregion


    #region Other

    public async Task<long> GetTotalCount()
    {
        var result = await GetQueryable().LongCountAsync();
        return result;
    }

    protected DbSet<T> GetDbSet<T>() where T : BaseEntity
    {
        var dbSet = _dbContext.Set<T>();
        return dbSet;
    }

    #endregion
}