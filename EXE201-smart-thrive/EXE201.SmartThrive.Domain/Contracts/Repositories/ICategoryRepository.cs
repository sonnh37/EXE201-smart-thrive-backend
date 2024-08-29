using EXE201.SmartThrive.Domain.Contracts.Bases;
using EXE201.SmartThrive.Domain.Entities;
using EXE201.SmartThrive.Domain.Models.Requests.Queries.Category;

namespace EXE201.SmartThrive.Domain.Contracts.Repositories;

public interface ICategoryRepository : IBaseRepository<Category>
{
    Task<(List<Subject>, int)> GetAllFiltered(CategoryGetAllQuery query);
}