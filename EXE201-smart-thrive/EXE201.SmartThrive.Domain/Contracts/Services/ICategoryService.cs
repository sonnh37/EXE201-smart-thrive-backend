using EXE201.SmartThrive.Domain.Contracts.Bases;
using EXE201.SmartThrive.Domain.Models.Requests.Queries.Category;
using EXE201.SmartThrive.Domain.Models.Responses;
using EXE201.SmartThrive.Domain.Models.Results;

namespace EXE201.SmartThrive.Domain.Contracts.Services;

public interface ICategoryService : IBaseService
{
    Task<PagedResponse<CategoryResult>> GetAllFiltered(CategoryGetAllQuery query);
}