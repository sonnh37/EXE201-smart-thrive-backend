using EXE201.SmartThrive.Domain.Contracts.Bases;
using EXE201.SmartThrive.Domain.Contracts.Repositories;

namespace EXE201.SmartThrive.Domain.Contracts.UnitOfWorks;

public interface IUnitOfWork : IBaseUnitOfWork
{
    ISubjectRepository SubjectRepository { get; }
    IStudentRepository StudentRepository { get; }
    IBlogRepository BlogRepository { get; }
    IFeedbackRepository FeedbackRepository { get; }
    IVoucherRepository VoucherRepository { get; }
    IModuleRepository ModuleRepository { get; }

}