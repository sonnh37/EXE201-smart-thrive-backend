using System.Linq.Expressions;
using System.Reflection;
using AutoMapper;
using EXE201.SmartThrive.Domain.Contracts.Bases;
using EXE201.SmartThrive.Domain.Entities;
using EXE201.SmartThrive.Domain.Enums;
using EXE201.SmartThrive.Domain.Models.Requests.Queries.Base;
using EXE201.SmartThrive.Domain.Utilities.Filters;
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

    private DbSet<TEntity> DbSet
    {
        get
        {
            var dbSet = GetDbSet<TEntity>();
            return dbSet;
        }
    }

    public async Task<List<TEntity>> ApplySortingAndPaging(IQueryable<TEntity> queryable, GetQueryableQuery pagedQuery)
    {
        queryable = Sort(queryable, pagedQuery);

        if (queryable.Any()) queryable = GetQueryablePagination(queryable, pagedQuery);

        return await queryable.ToListAsync();
    }

    public async Task<bool> IsExistById(Guid id)
    {
        return await DbSet.AnyAsync(t => t.Id.Equals(id));
    }

    public virtual void CheckCancellationToken(CancellationToken cancellationToken = default)
    {
        if (cancellationToken.IsCancellationRequested)
            throw new OperationCanceledException("Request was cancelled");
    }

    private static IQueryable<TEntity> Sort(IQueryable<TEntity> queryable, GetQueryableQuery pagedQuery)
    {
        if (!queryable.Any()) return queryable;

        var parameter = Expression.Parameter(typeof(TEntity), "o");
        var property = typeof(TEntity).GetProperty(pagedQuery.SortField ?? "",
            BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);

        if (property == null)
            // If the property doesn't exist, default to sorting by Id
            property = typeof(TEntity).GetProperty("CreatedDate");

        var propertyAccess = Expression.MakeMemberAccess(parameter, property);
        var orderByExp = Expression.Lambda(propertyAccess, parameter);

        var methodName = pagedQuery.SortOrder == (SortOrder?)1 ? "OrderBy" : "OrderByDescending";
        var resultExp = Expression.Call(typeof(Queryable), methodName,
            new[] { typeof(TEntity), property.PropertyType },
            queryable.Expression, Expression.Quote(orderByExp));

        queryable = queryable.Provider.CreateQuery<TEntity>(resultExp);

        return queryable;
    }

    #region Commands

    public void Add(TEntity entity)
    {
        DbSet.Add(entity);
    }

    public void AddRange(IEnumerable<TEntity> entities)
    {
        DbSet.AddRange(entities);
    }

    public void Update(TEntity entity)
    {
        DbSet.Update(entity);
    }

    public void UpdateRange(IEnumerable<TEntity> entities)
    {
        DbSet.UpdateRange(entities);
    }

    public void Delete(TEntity entity)
    {
        entity.IsDeleted = true;
        DbSet.Update(entity);
    }

    public void DeleteRange(IEnumerable<TEntity> entities)
    {
        var baseEntities = entities.ToList();
        var enumerable = baseEntities.Where(e => e.IsDeleted == false ? e.IsDeleted = true : e.IsDeleted = false);
        DbSet.UpdateRange(baseEntities);
    }

    #endregion

    #region Queries

    public async Task<IList<TEntity>> GetAll(CancellationToken cancellationToken = default)
    {
        var queryable = GetQueryable(cancellationToken);
        queryable = IncludeHelper.Apply(queryable);
        var result = await queryable.ToListAsync(cancellationToken);
        return result;
    }

    public async Task<(List<TEntity>, int)> GetAll(GetQueryableQuery query)
    {
        var queryable = GetQueryable();
        queryable = FilterHelper.Apply(queryable, query);
        queryable = IncludeHelper.Apply(queryable);
        var totalOrigin = queryable.Count();
        var results = await ApplySortingAndPaging(queryable, query);

        return (results, totalOrigin);
    }

    public virtual async Task<TEntity?> GetById(Guid id)
    {
        var queryable = GetQueryable(x => x.Id == id);
        queryable = IncludeHelper.Apply(queryable);
        var entity = await queryable.FirstOrDefaultAsync();

        return entity;
    }

    public virtual async Task<IList<TEntity>> GetByIds(IList<Guid> ids)
    {
        var queryable = GetQueryable(x => ids.Contains(x.Id));
        queryable = IncludeHelper.Apply(queryable);
        var entity = await queryable.ToListAsync();

        return entity;
    }

    public IQueryable<TEntity> GetQueryable(CancellationToken cancellationToken = default)
    {
        CheckCancellationToken(cancellationToken);
        var queryable = GetQueryable<TEntity>();
        return queryable;
    }

    public IQueryable<T> GetQueryable<T>()
        where T : BaseEntity
    {
        IQueryable<T> queryable = GetDbSet<T>();
        return queryable;
    }

    public IQueryable<TEntity> GetQueryable(Expression<Func<TEntity, bool>> predicate)
    {
        var queryable = GetQueryable<TEntity>();
        queryable = queryable.Where(predicate);
        return queryable;
    }

    private DbSet<T> GetDbSet<T>() where T : BaseEntity
    {
        var dbSet = _dbContext.Set<T>();
        return dbSet;
    }

    private IQueryable<TEntity> GetQueryablePagination(IQueryable<TEntity> queryable, GetQueryableQuery pagedQuery)
    {
        queryable = queryable.Skip((pagedQuery.PageNumber - 1) * pagedQuery.PageSize).Take(pagedQuery.PageSize);

        return queryable;
    }

    public async Task<long> GetTotalCount()
    {
        var result = await GetQueryable().LongCountAsync();

        return result;
    }

    #endregion
}