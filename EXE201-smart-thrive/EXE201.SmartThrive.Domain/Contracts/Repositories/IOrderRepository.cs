﻿using EXE201.SmartThrive.Domain.Contracts.Bases;
using EXE201.SmartThrive.Domain.Entities;

namespace EXE201.SmartThrive.Domain.Contracts.Repositories;

public interface IOrderRepository : IBaseRepository<Order>
{
    Task<Order> GetItemsFromOrder(Guid id);
}