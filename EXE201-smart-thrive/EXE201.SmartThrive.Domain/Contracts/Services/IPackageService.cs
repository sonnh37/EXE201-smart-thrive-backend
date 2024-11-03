using EXE201.SmartThrive.Domain.Contracts.Bases;
using EXE201.SmartThrive.Domain.Models.Requests.Commands.Package;
using EXE201.SmartThrive.Domain.Models.Responses;


namespace EXE201.SmartThrive.Domain.Contracts.Services
{
    public interface IPackageService : IBaseService
    {
        Task<BusinessResult> CreateWithStudentId(PackageCreateWithStudentCommand request);
        //Task<BusinessResult> Update(PackageUpdateCommand tRequest);
    }
}
