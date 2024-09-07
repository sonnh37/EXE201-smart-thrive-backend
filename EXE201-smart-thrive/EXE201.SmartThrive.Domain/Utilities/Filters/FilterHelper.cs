using EXE201.SmartThrive.Domain.Entities;
using EXE201.SmartThrive.Domain.Models.Requests.Queries.Blog;
using EXE201.SmartThrive.Domain.Models.Requests.Queries.Category;
using EXE201.SmartThrive.Domain.Models.Requests.Queries.Course;
using EXE201.SmartThrive.Domain.Models.Requests.Queries.Feedback;
using EXE201.SmartThrive.Domain.Models.Requests.Queries.Module;
using EXE201.SmartThrive.Domain.Models.Requests.Queries.Order;
using EXE201.SmartThrive.Domain.Models.Requests.Queries.Provider;
using EXE201.SmartThrive.Domain.Models.Requests.Queries.Student;
using EXE201.SmartThrive.Domain.Models.Requests.Queries.Subject;
using EXE201.SmartThrive.Domain.Models.Requests.Queries.User;
using EXE201.SmartThrive.Domain.Models.Requests.Queries.Voucher;

namespace EXE201.SmartThrive.Domain.Utilities.Filters;

public static class FilterHelper
{
    public static IQueryable<Subject> Subject(IQueryable<Subject> queryable, SubjectGetAllQuery query)
    {
        if (!string.IsNullOrEmpty(query.Name))
            queryable = queryable.Where(m => m.Name != null && m.Name.Contains(query.Name));

        if (query.CategoryId != Guid.Empty && query.CategoryId != null)
            queryable = queryable.Where(m => m.CategoryId == query.CategoryId);

        queryable = BaseFilterHelper.Base(queryable, query);

        return queryable;
    }

    public static IQueryable<Module> Module(IQueryable<Module> queryable, ModuleGetAllQuery query)
    {
        if (query.CourseId != Guid.Empty && query.CourseId != null)
            queryable = queryable.Where(m => m.CourseId == query.CourseId);
        if (!string.IsNullOrEmpty(query.Name))
            queryable = queryable.Where(m => m.Name != null && m.Name.Contains(query.Name));
        queryable = BaseFilterHelper.Base(queryable, query);

        return queryable;
    }


    public static IQueryable<Voucher> Voucher(IQueryable<Voucher> queryable, VoucherGetAllQuery query)
    {
        if (!string.IsNullOrEmpty(query.Code))
            queryable = queryable.Where(m => m.Code != null && m.Code.Contains(query.Code));
        if (!string.IsNullOrEmpty(query.Name))
            queryable = queryable.Where(m => m.Name != null && m.Name.Contains(query.Name));
        queryable = BaseFilterHelper.Base(queryable, query);

        return queryable;
    }

    public static IQueryable<Blog> Blog(IQueryable<Blog> queryable, BlogGetAllQuery query)
    {
        if (!string.IsNullOrEmpty(query.Title))
            queryable = queryable.Where(m => m.Title != null && m.Title.Contains(query.Title));
        if (query.UserId != Guid.Empty && query.UserId != null)
            queryable = queryable.Where(m => m.UserId == query.UserId);
        queryable = BaseFilterHelper.Base(queryable, query);

        return queryable;
    }

    public static IQueryable<Feedback> Feedback(IQueryable<Feedback> queryable, FeedbackGetAllQuery query)
    {
        if (query.StudentId != Guid.Empty && query.StudentId != null)
            queryable = queryable.Where(m => m.StudentId == query.StudentId);
        if (query.CourseId != Guid.Empty && query.CourseId != null)
            queryable = queryable.Where(m => m.CourseId == query.CourseId);
        if (query.Rating.HasValue) // Assuming Title is nullable int (int?)
            queryable = queryable.Where(m => m.Rating == query.Rating.Value);

        queryable = BaseFilterHelper.Base(queryable, query);

        return queryable;
    }

    public static IQueryable<Student> Student(IQueryable<Student> queryable, StudentGetAllQuery query)
    {
        if (!string.IsNullOrEmpty(query.StudentName))
            queryable = queryable.Where(m => m.StudentName != null && m.StudentName.Contains(query.StudentName));

        if (query.UserId != Guid.Empty && query.UserId != null)
            queryable = queryable.Where(m => m.UserId == query.UserId);

        queryable = BaseFilterHelper.Base(queryable, query);

        return queryable;
    }

    public static IQueryable<Course> Course(IQueryable<Course> queryable, CourseGetAllQuery query)
    {
        if (!string.IsNullOrEmpty(query.CourseName))
            queryable = queryable.Where(m => m.CourseName != null && m.CourseName.Contains(query.CourseName));

        if (query.SubjectId != null && query.SubjectId != Guid.Empty)
            queryable = queryable.Where(m => m.SubjectId == query.SubjectId);

        // query.SubjectId != null => query.ProviderId != null
        if (query.ProviderId != Guid.Empty && query.ProviderId != null)
            queryable = queryable.Where(m => m.ProviderId == query.ProviderId);

        queryable = BaseFilterHelper.Base(queryable, query);

        return queryable;
    }

    public static IQueryable<Category> Category(IQueryable<Category> queryable, CategoryGetAllQuery query)
    {
        if (!string.IsNullOrEmpty(query.Name))
            queryable = queryable.Where(m => m.Name != null && m.Name.Contains(query.Name));

        queryable = BaseFilterHelper.Base(queryable, query);

        return queryable;
    }

    public static IQueryable<User> User(IQueryable<User> queryable, UserGetAllQuery query)
    {
        if (!string.IsNullOrEmpty(query.Username))
            queryable = queryable.Where(e => e.Username.Contains(query.Username));

        if (!string.IsNullOrEmpty(query.FirstName))
            queryable = queryable.Where(e => e.FirstName.Contains(query.FirstName));

        if (!string.IsNullOrEmpty(query.LastName))
            queryable = queryable.Where(e => e.LastName.Contains(query.LastName));

        if (!string.IsNullOrEmpty(query.Email)) queryable = queryable.Where(e => e.Email.Contains(query.Email));

        if (query.Dob.HasValue) queryable = queryable.Where(e => e.Dob == query.Dob);

        if (!string.IsNullOrEmpty(query.Address)) queryable = queryable.Where(e => e.Address.Contains(query.Address));

        if (!string.IsNullOrEmpty(query.Status.ToString())) queryable = queryable.Where(e => e.Status == query.Status);

        if (!string.IsNullOrEmpty(query.Gender.ToString())) queryable = queryable.Where(e => e.Gender == query.Gender);

        if (!string.IsNullOrEmpty(query.Role.ToString())) queryable = queryable.Where(e => e.Role == query.Role);

        if (!string.IsNullOrEmpty(query.Phone)) queryable = queryable.Where(e => e.Phone.Contains(query.Phone));

        queryable = BaseFilterHelper.Base(queryable, query);

        return queryable;
    }

    public static IQueryable<Provider> Provider(IQueryable<Provider> queryable, ProviderGetAllQuery query)
    {
        if (query.UserId != Guid.Empty) queryable = queryable.Where(m => m.UserId == query.UserId);

        if (!string.IsNullOrEmpty(query.CompanyName))
            queryable = queryable.Where(e => e.CompanyName != null && e.CompanyName.Contains(query.CompanyName));

        if (!string.IsNullOrEmpty(query.Website))
            queryable = queryable.Where(e => e.Website != null && e.Website.Contains(query.Website));

        queryable = BaseFilterHelper.Base(queryable, query);

        return queryable;
    }

    public static IQueryable<Order> Order(IQueryable<Order> queryable, OrderGetAllQuery query)
    {
        if (query.PackageId != Guid.Empty && query.PackageId != null)
            queryable = queryable.Where(m => m.PackageId == query.PackageId);
        if (query.VoucherId != Guid.Empty && query.VoucherId != null)
            queryable = queryable.Where(m => m.VoucherId == query.VoucherId);

        if (!string.IsNullOrEmpty(query.PaymentMethod.ToString()))
            queryable = queryable.Where(e => e.PaymentMethod == query.PaymentMethod);

        if (query.TotalPrice.HasValue) queryable = queryable.Where(e => e.TotalPrice == query.TotalPrice);

        if (!string.IsNullOrEmpty(query.Description))
            queryable = queryable.Where(e => e.Description != null && e.Description.Contains(query.Description));

        if (!string.IsNullOrEmpty(query.Status.ToString())) queryable = queryable.Where(e => e.Status == query.Status);

        queryable = BaseFilterHelper.Base(queryable, query);

        return queryable;
    }
}