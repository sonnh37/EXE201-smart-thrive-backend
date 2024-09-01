using EXE201.SmartThrive.Data.Context;
using EXE201.SmartThrive.Domain.Contracts.Repositories;
using EXE201.SmartThrive.Domain.Contracts.UnitOfWorks;

namespace EXE201.SmartThrive.Repositories.UnitOfWorks;

public class UnitOfWork : BaseUnitOfWork<STDbContext>, IUnitOfWork
{
    public UnitOfWork(STDbContext context, IServiceProvider serviceProvider) : base(context, serviceProvider)
    {
    }

    public ISubjectRepository SubjectRepository => GetRepository<ISubjectRepository>();

    public ISessionSelfLearnRepository SessionSelfLearnRepository => GetRepository<ISessionSelfLearnRepository>();
    
    public IFeedbackRepository FeedbackRepository => GetRepository<IFeedbackRepository>();

    public IStudentRepository StudentRepository => GetRepository<IStudentRepository>();

    public IBlogRepository BlogRepository => GetRepository<IBlogRepository>();

    public IVoucherRepository VoucherRepository => GetRepository<IVoucherRepository>();

    public IModuleRepository ModuleRepository => GetRepository<IModuleRepository>();

    public ICategoryRepository CategoryRepository => GetRepository<ICategoryRepository>();

    public ICourseRepository CourseRepository => GetRepository<ICourseRepository>();
    
    public IUserRepository UserRepository => GetRepository<IUserRepository>();
    
    public IProviderRepository ProviderRepository => GetRepository<IProviderRepository>();
    
    public IOrderRepository OrderRepository => GetRepository<IOrderRepository>();
    
    public ISessionRepository SessionRepository => GetRepository<ISessionRepository>();
    
    public ISessionMeetingRepository SessionMeetingRepository => GetRepository<ISessionMeetingRepository>();
    
    public ISessionOfflineRepository SessionOfflineRepository => GetRepository<ISessionOfflineRepository>();
}