using EXE201.SmartThrive.Domain.Contracts.Services;
using EXE201.SmartThrive.Services;

namespace EXE201.SmartThrive.API.Registrations;

public static class ServiceRegistration
{
    public static void AddCustomServices(this IServiceCollection services)
    {
        services.AddScoped<ISubjectService, SubjectService>();
        services.AddScoped<ICourseService, CourseService>();
        services.AddScoped<IStudentService, StudentService>();
        services.AddScoped<IBlogService, BlogService>();
        services.AddScoped<IFeedbackService, FeedbackService>();
        services.AddScoped<IVoucherService, VoucherService>();
        services.AddScoped<IModuleService, ModuleService>();
        services.AddScoped<ICategoryService, CategoryService>();
    }
}