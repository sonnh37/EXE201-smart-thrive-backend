using EXE201.SmartThrive.Data.Context;
using EXE201.SmartThrive.Domain.Contracts.Repositories;
using EXE201.SmartThrive.Domain.Entities;
using EXE201.SmartThrive.Domain.Models.Requests.Queries.Order;
using EXE201.SmartThrive.Domain.Models.Requests.Queries.Provider;
using EXE201.SmartThrive.Domain.Utilities.Sorts;
using EXE201.SmartThrive.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXE201.SmartThrive.Repositories
{
    public class OrderRepository: BaseRepository<Order>, IOrderRepository
    {
        public OrderRepository(STDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<(List<Order>, int)> GetAllFiltered(OrderGetAllQuery query)
        {
            var queryable = GetQueryable();

            // filter
            queryable = ApplyFilter.Order(queryable, query);

            var totalOrigin = queryable.Count();

            // sort & pagination
            var results = await ApplySortingAndPaging(queryable, query);

            return (results, totalOrigin);
        }
    }
}
