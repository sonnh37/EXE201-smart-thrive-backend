using EXE201.SmartThrive.Domain.Contracts.Bases;
using EXE201.SmartThrive.Domain.Contracts.Repositories;
using EXE201.SmartThrive.Domain.Contracts.UnitOfWorks;
using EXE201.SmartThrive.Repositories;
using EXE201.SmartThrive.Repositories.Base;
using EXE201.SmartThrive.Repositories.UnitOfWorks;

namespace EXE201.SmartThrive.API.Registrations;

public static class RepositoryRegistration
{
    public static void AddCustomRepositories(this IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
        services.AddScoped<ISubjectRepository, SubjectRepository>();
        services.AddScoped<IFeedbackRepository, FeedbackRepository>();
        services.AddScoped<IModuleRepository, ModuleRepository>();
        services.AddScoped<IVoucherRepository, VoucherRepository>();
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<ICourseRepository, CourseRepository>();
        services.AddScoped<IStudentRepository, StudentRepository>();
        services.AddScoped<IBlogRepository, BlogRepository>();
    }
}