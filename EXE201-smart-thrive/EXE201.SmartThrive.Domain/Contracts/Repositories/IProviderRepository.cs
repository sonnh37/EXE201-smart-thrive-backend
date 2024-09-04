using EXE201.SmartThrive.Domain.Contracts.Bases;
using EXE201.SmartThrive.Domain.Entities;
using EXE201.SmartThrive.Domain.Models.Requests.Queries.Provider;

namespace EXE201.SmartThrive.Domain.Contracts.Repositories;

public interface IProviderRepository : IBaseRepository<Provider>
{
    Task<(List<Provider>, int)> GetAllFiltered(ProviderGetAllQuery query);
}