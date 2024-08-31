using EXE201.SmartThrive.Domain.Entities;
using EXE201.SmartThrive.Domain.Models.Requests.Queries.Base;
using EXE201.SmartThrive.Domain.Models.Requests.Queries.Category;
using EXE201.SmartThrive.Domain.Models.Requests.Queries.Course;
using EXE201.SmartThrive.Domain.Models.Requests.Queries.Student;
using EXE201.SmartThrive.Domain.Models.Requests.Queries.Order;
using EXE201.SmartThrive.Domain.Models.Requests.Queries.Provider;
using EXE201.SmartThrive.Domain.Models.Requests.Queries.Subject;
using EXE201.SmartThrive.Domain.Models.Requests.Queries.User;

namespace EXE201.SmartThrive.Domain.Utilities.Sorts;

public static class ApplyFilter
{
    public static IQueryable<Subject> Subject(IQueryable<Subject> queryable, SubjectGetAllQuery query)
    {
        if (!string.IsNullOrEmpty(query.Name))
        {
            queryable = queryable.Where(m => m.Name != null && m.Name.Contains(query.Name));
        }

        if (query.CategoryId != Guid.Empty && query.CategoryId != null)
        {
            queryable = queryable.Where(m => m.CategoryId == query.CategoryId);
        }

        queryable = Base(queryable, query);

        return queryable;
    }

    public static IQueryable<Student> Student(IQueryable<Student> queryable, StudentGetAllQuery query)
    {
        if (!string.IsNullOrEmpty(query.StudentName))
        {
            queryable = queryable.Where(m => m.StudentName != null && m.StudentName.Contains(query.StudentName));
        }

        if (query.UserId != Guid.Empty && query.UserId != null)
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

        if (query.SubjectId != null && query.SubjectId != Guid.Empty)
        {
            queryable = queryable.Where(m => m.SubjectId == query.SubjectId);
        }

        if (query.ProviderId != Guid.Empty && query.SubjectId != null)
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

    public static IQueryable<User> User(IQueryable<User> queryable, UserGetAllQuery query)
    {
        if (!string.IsNullOrEmpty(query.Username))
        {
            queryable = queryable.Where(e => e.Username.Contains(query.Username));
        }

        if (!string.IsNullOrEmpty(query.FirstName))
        {
            queryable = queryable.Where(e => e.FirstName.Contains(query.FirstName));
        }

        if (!string.IsNullOrEmpty(query.LastName))
        {
            queryable = queryable.Where(e => e.LastName.Contains(query.LastName));
        }

        if (!string.IsNullOrEmpty(query.Email))
        {
            queryable = queryable.Where(e => e.Email.Contains(query.Email));
        }

        if (query.Dob.HasValue)
        {
            queryable = queryable.Where(e => e.Dob == query.Dob);
        }

        if (!string.IsNullOrEmpty(query.Address))
        {
            queryable = queryable.Where(e => e.Address.Contains(query.Address));
        }

        if (!string.IsNullOrEmpty(query.Status.ToString()))
        {
            queryable = queryable.Where(e => e.Status == query.Status);
        }

        if (!string.IsNullOrEmpty(query.Gender.ToString()))
        {
            queryable = queryable.Where(e => e.Gender == query.Gender);
        }

        if (!string.IsNullOrEmpty(query.Role.ToString()))
        {
            queryable = queryable.Where(e => e.Role == query.Role);
        }

        if (!string.IsNullOrEmpty(query.Phone))
        {
            queryable = queryable.Where(e => e.Phone.Contains(query.Phone));
        }

        queryable = Base(queryable, query);

        return queryable;
    }

    public static IQueryable<Provider> Provider(IQueryable<Provider> queryable, ProviderGetAllQuery query)
    {
        if (query.UserId != Guid.Empty)
        {
            queryable = queryable.Where(m => m.UserId == query.UserId);
        }

        if (!string.IsNullOrEmpty(query.CompanyName))
        {
            queryable = queryable.Where(e => e.CompanyName != null && e.CompanyName.Contains(query.CompanyName));
        }

        if (!string.IsNullOrEmpty(query.Website))
        {
            queryable = queryable.Where(e => e.Website != null && e.Website.Contains(query.Website));
        }

        queryable = Base(queryable, query);

        return queryable;
    }

    public static IQueryable<Order> Order(IQueryable<Order> queryable, OrderGetAllQuery query)
    {
        if (query.PackageId != Guid.Empty)
        {
            queryable = queryable.Where(m => m.PackageId == query.PackageId);
        }

        if (query.VoucherId != Guid.Empty)
        {
            queryable = queryable.Where(m => m.VoucherId == query.VoucherId);
        }

        if (!string.IsNullOrEmpty(query.PaymentMethod.ToString()))
        {
            queryable = queryable.Where(e => e.PaymentMethod == query.PaymentMethod);
        }

        if (query.TotalPrice.HasValue)
        {
            queryable = queryable.Where(e => e.TotalPrice == query.TotalPrice);
        }

        if (!string.IsNullOrEmpty(query.Description))
        {
            queryable = queryable.Where(e => e.Description != null && e.Description.Contains(query.Description));
        }

        if (!string.IsNullOrEmpty(query.Status.ToString()))
        {
            queryable = queryable.Where(e => e.Status == query.Status);
        }

        queryable = Base(queryable, query);

        return queryable;
    }

    private static IQueryable<TEntity> Base<TEntity>(IQueryable<TEntity> queryable, BaseQuery query) where TEntity : BaseEntity
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