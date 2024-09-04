using EXE201.SmartThrive.Data.Context;
using EXE201.SmartThrive.Domain.Contracts.Bases;
using EXE201.SmartThrive.Domain.Contracts.Repositories;
using EXE201.SmartThrive.Domain.Entities;
using EXE201.SmartThrive.Domain.Models.Requests.Queries.User;
using EXE201.SmartThrive.Domain.Utilities.Sorts;
using EXE201.SmartThrive.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXE201.SmartThrive.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(STDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<User> FindByEmailOrUsername(string keyword)
        {
            var queryable = base.GetQueryable();

            var user = await queryable.Where(e => e.Email.ToLower() == keyword.ToLower()
                                            || e.Username.ToLower() == keyword.ToLower())
                                            .Include(e => e.Students)
                                            .SingleOrDefaultAsync();

            return user;
        }

        public async Task<(List<User>, int)> GetAllFiltered(UserGetAllQuery query)
        {
            var queryable = base.GetQueryable();

            // filter
            queryable = ApplyFilter.User(queryable, query);

            var totalOrigin = queryable.Count();

            // sort & pagination
            var results = await base.ApplySortingAndPaging(queryable, query);

            return (results, totalOrigin);
        }

        
    }
}
