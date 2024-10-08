﻿using EXE201.SmartThrive.Domain.Contracts.Bases;
using EXE201.SmartThrive.Domain.Entities;

namespace EXE201.SmartThrive.Domain.Contracts.Repositories;

public interface IUserRepository : IBaseRepository<User>
{
    Task<User?> FindByEmailOrUsername(string keyword);
    Task<User?> GetByEmail(string keyword);
    Task<User?> GetByUsername(string username);
}