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
    public IStudentRepository StudentRepository => GetRepository<IStudentRepository>();
    public ICategoryRepository CategoryRepository => GetRepository<ICategoryRepository>();
    public ICourseRepository CourseRepository => GetRepository<ICourseRepository>();
    public IUserRepository UserRepository => GetRepository<IUserRepository>();
    public IProviderRepository ProviderRepository => GetRepository<IProviderRepository>();
    public IOrderRepository OrderRepository => GetRepository<IOrderRepository>();
}