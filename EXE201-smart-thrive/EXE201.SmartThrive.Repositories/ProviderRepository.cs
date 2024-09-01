using EXE201.SmartThrive.Data.Context;
using EXE201.SmartThrive.Domain.Contracts.Repositories;
using EXE201.SmartThrive.Domain.Entities;
using EXE201.SmartThrive.Domain.Models.Requests.Queries.Provider;
using EXE201.SmartThrive.Domain.Utilities;
using EXE201.SmartThrive.Repositories.Base;

namespace EXE201.SmartThrive.Repositories;

public class ProviderRepository : BaseRepository<Provider>, IProviderRepository
{
    public ProviderRepository(STDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<(List<Provider>, int)> GetAllFiltered(ProviderGetAllQuery query)
    {
        var queryable = GetQueryable();

        // filter
        queryable = ApplyFilter.Provider(queryable, query);

        var totalOrigin = queryable.Count();

        // sort & pagination
        var results = await ApplySortingAndPaging(queryable, query);

        return (results, totalOrigin);
    }
}