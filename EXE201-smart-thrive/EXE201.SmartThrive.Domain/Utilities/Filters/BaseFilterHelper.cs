﻿using EXE201.SmartThrive.Domain.Entities;
using EXE201.SmartThrive.Domain.Models.Requests.Queries.Base;

namespace EXE201.SmartThrive.Domain.Utilities.Filters;

public static class BaseFilterHelper
{
    public static IQueryable<TEntity> Base<TEntity>(IQueryable<TEntity> queryable, GetQueryableQuery query)
        where TEntity : BaseEntity
    {
        if (query.Id != Guid.Empty) queryable = queryable.Where(m => m.Id == query.Id);

        if (!string.IsNullOrEmpty(query.CreatedBy))
            queryable = queryable.Where(m => m.CreatedBy != null && m.CreatedBy.Contains(query.CreatedBy));

        if (!string.IsNullOrEmpty(query.UpdatedBy))
            queryable = queryable.Where(m => m.UpdatedBy != null && m.UpdatedBy.Contains(query.UpdatedBy));

        if (query.IsDeleted.HasValue) queryable = queryable.Where(m => m.IsDeleted == query.IsDeleted);

        queryable = FromDateToDate(queryable, query);

        return queryable;
    }

    private static IQueryable<TEntity> FromDateToDate<TEntity>(IQueryable<TEntity> queryable, GetQueryableQuery query)
        where TEntity : BaseEntity
    {
        if (query.FromDate.HasValue)
            queryable = queryable.Where(entity => entity.CreatedDate >= query.FromDate.Value);

        if (query.ToDate.HasValue)
            queryable = queryable.Where(entity => entity.CreatedDate <= query.ToDate.Value);

        return queryable;
    }
}