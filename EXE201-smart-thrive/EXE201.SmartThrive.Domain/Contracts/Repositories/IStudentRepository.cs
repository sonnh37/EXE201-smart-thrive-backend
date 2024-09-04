using EXE201.SmartThrive.Domain.Contracts.Bases;
using EXE201.SmartThrive.Domain.Entities;
using EXE201.SmartThrive.Domain.Models.Requests.Queries.Student;

namespace EXE201.SmartThrive.Domain.Contracts.Repositories;

public interface IStudentRepository : IBaseRepository
{
    Task<(List<Student>, int)> GetAllFiltered(StudentGetAllQuery query);
}