using EXE201.SmartThrive.Domain.Contracts.Bases;
using EXE201.SmartThrive.Domain.Entities;
using EXE201.SmartThrive.Domain.Models.Requests.Queries.Category;
using EXE201.SmartThrive.Domain.Models.Requests.Queries.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXE201.SmartThrive.Domain.Contracts.Repositories
{
    public interface IUserRepository: IBaseRepository<User>
    {
        Task<(List<User>, int)> GetAllFiltered(UserGetAllQuery query);
        Task<User> FindByEmailOrUsername(string keyword);
    }
}
