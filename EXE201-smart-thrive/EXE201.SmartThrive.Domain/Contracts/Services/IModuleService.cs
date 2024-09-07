using EXE201.SmartThrive.Domain.Contracts.Bases;
using EXE201.SmartThrive.Domain.Models.Requests.Queries.Module;
using EXE201.SmartThrive.Domain.Models.Responses;
using EXE201.SmartThrive.Domain.Models.Results;

namespace EXE201.SmartThrive.Domain.Contracts.Services;

public interface IModuleService : IBaseService
{
    Task<PagedResponse<ModuleResult>> GetAllFiltered(ModuleGetAllQuery query);
}