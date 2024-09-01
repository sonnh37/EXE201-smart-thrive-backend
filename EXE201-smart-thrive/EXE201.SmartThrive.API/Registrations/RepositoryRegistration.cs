using EXE201.SmartThrive.Domain.Contracts.Repositories;
using EXE201.SmartThrive.Domain.Contracts.UnitOfWorks;
using EXE201.SmartThrive.Repositories;
using EXE201.SmartThrive.Repositories.UnitOfWorks;

namespace EXE201.SmartThrive.API.Registrations;

public static class RepositoryRegistration
{
    public static void AddCustomRepositories(this IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IBlogRepository, BlogRepository>();
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<ICourseRepository, CourseRepository>();
        services.AddScoped<IFeedbackRepository, FeedbackRepository>();
        services.AddScoped<IModuleRepository, ModuleRepository>();
        services.AddScoped<IOrderRepository, OrderRepository>();
        services.AddScoped<IProviderRepository, ProviderRepository>();
        services.AddScoped<ISessionRepository, SessionRepository>();
        services.AddScoped<IStudentRepository, StudentRepository>();
        services.AddScoped<ISubjectRepository, SubjectRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IVoucherRepository, VoucherRepository>();
    }
}