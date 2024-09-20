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
        return queryable;
    }

    private static IQueryable<Blog> Blog(IQueryable<Blog> queryable)
    {
        return queryable;
    }

    private static IQueryable<Feedback> Feedback(IQueryable<Feedback> queryable)
    {
        return queryable;
    }

    private static IQueryable<Student> Student(IQueryable<Student> queryable)
    {
        return queryable;
    }

    private static IQueryable<Course> Course(IQueryable<Course> queryable)
    {
        return queryable;
    }

    private static IQueryable<Category> Category(IQueryable<Category> queryable)
    {
        return queryable;
    }

    private static IQueryable<User> User(IQueryable<User> queryable)
    {
        return queryable;
    }

    private static IQueryable<Provider> Provider(IQueryable<Provider> queryable)
    {
        return queryable;
    }

    private static IQueryable<Order> Order(IQueryable<Order> queryable)
    {
        return queryable;
    }
}