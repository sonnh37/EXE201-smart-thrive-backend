using EXE201.SmartThrive.Data.Context;
using EXE201.SmartThrive.Domain.Contracts.Repositories;
using EXE201.SmartThrive.Domain.Entities;
using EXE201.SmartThrive.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace EXE201.SmartThrive.Repositories;

public class UserRepository : BaseRepository<User>, IUserRepository
{
    public UserRepository(STDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<User?> FindByEmailOrUsername(string keyword)
    {
        var queryable = GetQueryable();

        var user = await queryable.Where(e => e.Email!.ToLower().Trim() == keyword.ToLower().Trim()
                                              || e.Username!.ToLower().Trim() == keyword.ToLower().Trim())
            .Include(e => e.Students)
            .SingleOrDefaultAsync();

        return user;
    }

    public async Task<User?> GetByEmail(string keyword)
    {
        var queryable = GetQueryable();

        var user = await queryable.Where(e => e.Email!.ToLower() == keyword.ToLower())
            .Include(e => e.Students)
            .SingleOrDefaultAsync();

        return user;
    }

    public async Task<User?> GetByUsername(string username)
    {
        var queryable = GetQueryable();

        var user = await queryable.Where(e => e.Username!.ToLower() == username.ToLower())
                                    .Include(e => e.Students)
                                    .SingleOrDefaultAsync();

        return user;
    }
}