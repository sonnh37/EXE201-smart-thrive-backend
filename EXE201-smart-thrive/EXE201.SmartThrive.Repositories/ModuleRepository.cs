using EXE201.SmartThrive.Data.Context;
using EXE201.SmartThrive.Domain.Contracts.Repositories;
using EXE201.SmartThrive.Domain.Entities;
using EXE201.SmartThrive.Domain.Models.Requests.Queries.Module;
using EXE201.SmartThrive.Domain.Utilities.Filters;
using EXE201.SmartThrive.Repositories.Base;

namespace EXE201.SmartThrive.Repositories;

public class ModuleRepository : BaseRepository<Module>, IModuleRepository
{
    public ModuleRepository(STDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<(List<Module>, int)> GetAllFiltered(ModuleGetAllQuery query)
    {
        var queryable = GetQueryable();

        // filter
        queryable = FilterHelper.Module(queryable, query);

        var totalOrigin = queryable.Count();

        // sort & pagination
        var results = await ApplySortingAndPaging(queryable, query);

        return (results, totalOrigin);
    }
}