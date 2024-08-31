using EXE201.SmartThrive.Domain.Entities;
using EXE201.SmartThrive.Domain.Models.Requests.Queries.Base;
using EXE201.SmartThrive.Domain.Models.Requests.Queries.Category;
using EXE201.SmartThrive.Domain.Models.Requests.Queries.Course;
using EXE201.SmartThrive.Domain.Models.Requests.Queries.Student;
using EXE201.SmartThrive.Domain.Models.Requests.Queries.Subject;

namespace EXE201.SmartThrive.Domain.Utilities;

public static class ApplyFilter
{
    public static IQueryable<Subject> Subject(IQueryable<Subject> queryable, SubjectGetAllQuery query)
    {
        if (!string.IsNullOrEmpty(query.Name))
            queryable = queryable.Where(m => m.Name != null && m.Name.Contains(query.Name));

        if (query.CategoryId != Guid.Empty && query.CategoryId != null)
            queryable = queryable.Where(m => m.CategoryId == query.CategoryId);

        queryable = Base(queryable, query);

        return queryable;
    }

    public static IQueryable<Student> Student(IQueryable<Student> queryable, StudentGetAllQuery query)
    {
        if (!string.IsNullOrEmpty(query.StudentName))
            queryable = queryable.Where(m => m.StudentName != null && m.StudentName.Contains(query.StudentName));

        if (query.UserId != Guid.Empty && query.UserId != null)
            queryable = queryable.Where(m => m.UserId == query.UserId);

        queryable = Base(queryable, query);

        return queryable;
    }

    public static IQueryable<Course> Course(IQueryable<Course> queryable, CourseGetAllQuery query)
    {
        if (!string.IsNullOrEmpty(query.CourseName))
            queryable = queryable.Where(m => m.CourseName != null && m.CourseName.Contains(query.CourseName));

        if (query.SubjectId != null && query.SubjectId != Guid.Empty)
            queryable = queryable.Where(m => m.SubjectId == query.SubjectId);

        if (query.ProviderId != Guid.Empty && query.SubjectId != null)
            queryable = queryable.Where(m => m.ProviderId == query.ProviderId);

        queryable = Base(queryable, query);

        return queryable;
    }


    public static IQueryable<Category> Category(IQueryable<Category> queryable, CategoryGetAllQuery query)
    {
        if (!string.IsNullOrEmpty(query.Name))
            queryable = queryable.Where(m => m.Name != null && m.Name.Contains(query.Name));

        queryable = Base(queryable, query);

        return queryable;
    }

    private static IQueryable<TEntity> Base<TEntity>(IQueryable<TEntity> queryable, BaseQuery query)
        where TEntity : BaseEntity
    {
        if (query.Id != Guid.Empty) queryable = queryable.Where(m => m.Id == query.Id);

        if (!string.IsNullOrEmpty(query.CreatedBy))
            queryable = queryable.Where(m => m.CreatedBy != null && m.CreatedBy.Contains(query.CreatedBy));

        if (query.CreatedDate.HasValue)
        {
            var date = query.CreatedDate.Value.Date;
            queryable = queryable.Where(m => m.CreatedDate.Date == date);
        }

        if (!string.IsNullOrEmpty(query.UpdatedBy))
            queryable = queryable.Where(m => m.UpdatedBy != null && m.UpdatedBy.Contains(query.UpdatedBy));

        if (query.UpdatedDate.HasValue) queryable = queryable.Where(m => m.UpdatedDate <= query.UpdatedDate.Value);

        if (query.IsDeleted.HasValue) queryable = queryable.Where(m => m.IsDeleted == query.IsDeleted);

        return queryable;
    }
}