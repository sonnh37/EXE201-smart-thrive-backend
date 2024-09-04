using EXE201.SmartThrive.Domain.Contracts.Bases;
using EXE201.SmartThrive.Domain.Contracts.Repositories;

namespace EXE201.SmartThrive.Domain.Contracts.UnitOfWorks;

public interface IUnitOfWork : IBaseUnitOfWork
{
    ISubjectRepository SubjectRepository { get; }

    IOrderRepository OrderRepository { get; }

    ISessionRepository SessionRepository { get; }

    ISessionMeetingRepository SessionMeetingRepository { get; }

    ISessionOfflineRepository SessionOfflineRepository { get; }

    ISessionSelfLearnRepository SessionSelfLearnRepository { get; }
    IStudentRepository StudentRepository { get; }
    ICategoryRepository CategoryRepository { get; }
    ICourseRepository CourseRepository { get; }

    IBlogRepository BlogRepository { get; }
    IVoucherRepository VoucherRepository { get; }
    IModuleRepository ModuleRepository { get; }
    IUserRepository UserRepository { get; }
    IProviderRepository ProviderRepository { get; }
    IFeedbackRepository FeedbackRepository { get; }
}