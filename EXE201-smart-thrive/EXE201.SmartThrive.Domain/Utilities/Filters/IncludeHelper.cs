using EXE201.SmartThrive.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EXE201.SmartThrive.Domain.Utilities.Filters;

public static class IncludeHelper
{
    public static IQueryable<TEntity> Apply<TEntity>(IQueryable<TEntity> queryable)
        where TEntity : BaseEntity
    {
        return (queryable switch
        {
            IQueryable<Blog> q => Blog(q) as IQueryable<TEntity>,
            IQueryable<Package> q => Package(q) as IQueryable<TEntity>,
            IQueryable<Category> q => Category(q) as IQueryable<TEntity>,
            IQueryable<Course> q => Course(q) as IQueryable<TEntity>,
            IQueryable<Feedback> q => Feedback(q) as IQueryable<TEntity>,
            IQueryable<Module> q => Module(q) as IQueryable<TEntity>,
            IQueryable<Order> q => Order(q) as IQueryable<TEntity>,
            IQueryable<Provider> q => Provider(q) as IQueryable<TEntity>,
            IQueryable<Student> q => Student(q) as IQueryable<TEntity>,
            IQueryable<Subject> q => Subject(q) as IQueryable<TEntity>,
            IQueryable<User> q => User(q) as IQueryable<TEntity>,
            IQueryable<Voucher> q => Voucher(q) as IQueryable<TEntity>,
            IQueryable<StudentXPackage> q => StudentXPackage(q) as IQueryable<TEntity>,
            IQueryable<PackageXCourse> q => PackageXCourse(q) as IQueryable<TEntity>,
            _ => queryable
        })!;
    }

    private static IQueryable<Subject> Subject(IQueryable<Subject> queryable)
    {
        queryable = queryable.Include(m => m.Category);
        return queryable;
    }

    private static IQueryable<Module> Module(IQueryable<Module> queryable)
    {

        return queryable;
    }


    private static IQueryable<Voucher> Voucher(IQueryable<Voucher> queryable)
    {
        queryable = queryable.Include(m => m.VoucherType);

        return queryable;
    }

    private static IQueryable<Blog> Blog(IQueryable<Blog> queryable)
    {
        queryable = queryable.Include(m => m.User);

        return queryable;
    }

    private static IQueryable<Feedback> Feedback(IQueryable<Feedback> queryable)
    {
        queryable = queryable.Include(m => m.Student);

        queryable = queryable.Include(m => m.Course);


        return queryable;
    }

    private static IQueryable<Student> Student(IQueryable<Student> queryable)
    {
        queryable = queryable.Include(m => m.User);


        return queryable;
    }

    private static IQueryable<Course> Course(IQueryable<Course> queryable)
    {
        if (queryable.Any())
        {
            queryable = queryable.Include(m => m.Subject);
        }

        if (queryable.Any())
        {
            queryable = queryable.Include(m => m.Provider);
        }

        if (queryable.Any())
        {
            queryable = queryable.Include(m => m.Modules);
        }

        if (queryable.Any())
        {
            queryable = queryable.Include(m => m.Feedbacks);
        }

        if (queryable.Any())
        {
            queryable = queryable.Include(m => m.PackageXCourses);
        }

        if (queryable.Any())
        {
            queryable = queryable.Include(m => m.DayInWeek);
        }

        return queryable;
    }

    private static IQueryable<Category> Category(IQueryable<Category> queryable)
    {
        queryable = queryable.Include(x => x.Subjects);
        return queryable;
    }

    private static IQueryable<User> User(IQueryable<User> queryable)
    {
        return queryable;
    }

    private static IQueryable<Provider> Provider(IQueryable<Provider> queryable)
    {
        queryable = queryable.Include(m => m.User);
        queryable = queryable.Include(m => m.Addresses);

        return queryable;
    }

    private static IQueryable<Order> Order(IQueryable<Order> queryable)
    {
        queryable = queryable.Include(m => m.Voucher);

        return queryable;
    }

    private static IQueryable<Package> Package(IQueryable<Package> queryable)
    {
        queryable = queryable.Include(m => m.PackageXCourses);

        return queryable;
    }

    private static IQueryable<StudentXPackage> StudentXPackage(IQueryable<StudentXPackage> queryable)
    {
        queryable = queryable.Include(m => m.Package).ThenInclude(y => y.PackageXCourses).ThenInclude(x => x.Course);

        queryable = queryable.Include(m => m.Student);


        return queryable;
    }

    private static IQueryable<PackageXCourse> PackageXCourse(IQueryable<PackageXCourse> queryable)
    {
        queryable = queryable.Include(m => m.Package);
        queryable = queryable.Include(m => m.Course);

        return queryable;
    }
}