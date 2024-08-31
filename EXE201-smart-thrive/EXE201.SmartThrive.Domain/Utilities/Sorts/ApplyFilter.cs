using EXE201.SmartThrive.Domain.Entities;
using EXE201.SmartThrive.Domain.Models.Requests.Queries.Base;
using EXE201.SmartThrive.Domain.Models.Requests.Queries.Category;
using EXE201.SmartThrive.Domain.Models.Requests.Queries.Course;
using EXE201.SmartThrive.Domain.Models.Requests.Queries.Student;
using EXE201.SmartThrive.Domain.Models.Requests.Queries.Subject;

namespace EXE201.SmartThrive.Domain.Utilities.Sorts;

public static class ApplyFilter
{
    public static IQueryable<Feedback> Feedback(IQueryable<Feedback> queryable, FeedbackGetAllQuery query)
    {
        if (query.StudentId != Guid.Empty)
        {
            queryable = queryable.Where(m => m.StudentId == query.StudentId);
        }
        
        if (query.CategoryId != Guid.Empty)
        {
            queryable = queryable.Where(m => m.CourseId == query.CourseId);
        }

        if(query.Rating != null)
        {
            queryable = queryable.Where(m => m.Rating == query.Rating);
        }

        queryable = Base(queryable, query);

        return queryable;
    }
<<<<<<<<< Temporary merge branch 1
    public static IQueryable<Feedback> Feedback(IQueryable<Feedback> queryable, FeedbackGetAllQuery query)
    {
        if(query.StudentId != Guid.Empty)
        {
            queryable = queryable.Where(x => x.StudentId  == query.StudentId);
        }
        if(query.CourseId != Guid.Empty)
        {
            queryable = queryable.Where(x => x.CourseId == query.CourseId);
        }
        if(query.Rating != null)
        {
            queryable = queryable.Where(x => x.Rating == query.Rating);
        }
        queryable = Base(queryable, query);
        return queryable;
    }
=========
    
    public static IQueryable<Student> Student(IQueryable<Student> queryable, StudentGetAllQuery query)
    {
        if (!string.IsNullOrEmpty(query.StudentName))
        {
            queryable = queryable.Where(m => m.StudentName != null && m.StudentName.Contains(query.StudentName));
        }

        if (query.UserId != Guid.Empty)
        {
            queryable = queryable.Where(m => m.UserId == query.UserId);
        }

        queryable = Base(queryable, query);

        return queryable;
    }

    public static IQueryable<Course> Course(IQueryable<Course> queryable, CourseGetAllQuery query)
    {
        if (!string.IsNullOrEmpty(query.CourseName))
        {
            queryable = queryable.Where(m => m.CourseName != null && m.CourseName.Contains(query.CourseName));
        }

        if (query.SubjectId != Guid.Empty)
        {
            queryable = queryable.Where(m => m.SubjectId == query.SubjectId);
        }

        if (query.ProviderId != Guid.Empty)
        {
            queryable = queryable.Where(m => m.ProviderId == query.ProviderId);
        }

        queryable = Base(queryable, query);

        return queryable;
    }


    public static IQueryable<Category> Category(IQueryable<Category> queryable, CategoryGetAllQuery query)
    {
        if (!string.IsNullOrEmpty(query.Name))
        {
            queryable = queryable.Where(m => m.Name != null && m.Name.Contains(query.Name));
        }

        queryable = Base(queryable, query);

        return queryable;
    }

    private static IQueryable<TEntity> Base<TEntity>(IQueryable<TEntity> queryable, BaseQuery query) where TEntity: BaseEntity
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