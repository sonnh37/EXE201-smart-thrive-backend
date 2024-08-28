using EXE201.SmartThrive.Domain.Entities;
using EXE201.SmartThrive.Domain.Models.Requests.Queries.Subject;

namespace EXE201.SmartThrive.Domain.Utilities.Sorts;

public static class ApplySort
{
    public static IQueryable<Subject> Subject(IQueryable<Subject> queryable, SubjectGetAllQuery query)
    {
        if (!string.IsNullOrEmpty(query.Name))
        {
            queryable = queryable.Where(m => m.Name != null && m.Name.Contains(query.Name));
        }
        
        if (query.CategoryId != Guid.Empty)
        {
            queryable = queryable.Where(m => m.CategoryId == query.CategoryId);
        }

        queryable = Base(queryable, query);
        
        return queryable;
    }

    private static IQueryable<TEntity> Base<TEntity>(IQueryable<TEntity> queryable, SubjectGetAllQuery query) where TEntity: BaseEntity
    {
        if (query.Id != Guid.Empty)
        {
            queryable = queryable.Where(m => m.Id == query.Id);
        }
        
        if (!string.IsNullOrEmpty(query.CreatedBy))
        {
            queryable = queryable.Where(m => m.CreatedBy != null && m.CreatedBy.Contains(query.CreatedBy));
        }

        if (query.CreatedDate.HasValue)
        {
            var date = query.CreatedDate.Value.Date;
            queryable = queryable.Where(m => m.CreatedDate.Date == date);
        }

        if (!string.IsNullOrEmpty(query.UpdatedBy))
        {
            queryable = queryable.Where(m => m.UpdatedBy != null && m.UpdatedBy.Contains(query.UpdatedBy));
        }

        if (query.UpdatedDate.HasValue)
        {
            queryable = queryable.Where(m => m.UpdatedDate <= query.UpdatedDate.Value);
        }

        if (query.IsDeleted.HasValue)
        {
            queryable = queryable.Where(m => m.IsDeleted == query.IsDeleted);
        }

        return queryable;
    }
}