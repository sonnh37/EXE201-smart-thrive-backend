using EXE201.SmartThrive.Data.Context;
using EXE201.SmartThrive.Domain.Contracts.Repositories;
using EXE201.SmartThrive.Domain.Entities;
using EXE201.SmartThrive.Domain.Models.Requests.Queries.Order;
using EXE201.SmartThrive.Domain.Utilities.Filters;
using EXE201.SmartThrive.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace EXE201.SmartThrive.Repositories;
public class OrderRepository : BaseRepository<Order>, IOrderRepository
{
    private STDbContext _context;
    public OrderRepository(STDbContext dbContext) : base(dbContext)
    {
        _context = dbContext;
    }

    public async Task<Order> GetItemsFromOrder(Guid id)
    {
        return await _context.Orders.Include(x => x.Package)
            .ThenInclude(y => y.PackageXCourses)
            .ThenInclude(z => z.Course)
            .FirstOrDefaultAsync(x => x.Id == id);
    }
}