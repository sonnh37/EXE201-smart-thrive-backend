using EXE201.SmartThrive.Data.Context;
using EXE201.SmartThrive.Domain.Contracts.Repositories;
using EXE201.SmartThrive.Domain.Entities;
using EXE201.SmartThrive.Domain.Models.Requests.Queries.User;
using EXE201.SmartThrive.Domain.Utilities.Filters;
using EXE201.SmartThrive.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace EXE201.SmartThrive.Repositories;

public class UserRepository : BaseRepository<User>, IUserRepository
{
    public UserRepository(STDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<User> FindByEmailOrUsername(string keyword)
    {
        var queryable = GetQueryable();

        var user = await queryable.Where(e => e.Email.ToLower() == keyword.ToLower()
                                              || e.Username.ToLower() == keyword.ToLower())
            .Include(e => e.Students)
            .SingleOrDefaultAsync();

        return user;
    }

    public async Task<(List<User>, int)> GetAllFiltered(UserGetAllQuery query)
    {
        var queryable = GetQueryable();

        // filter
        queryable = FilterHelper.User(queryable, query);

        var totalOrigin = queryable.Count();

        // sort & pagination
        var results = await ApplySortingAndPaging(queryable, query);

        return (results, totalOrigin);
    }
}