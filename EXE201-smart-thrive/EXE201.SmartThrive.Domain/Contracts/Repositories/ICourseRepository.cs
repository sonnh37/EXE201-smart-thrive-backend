using EXE201.SmartThrive.Domain.Contracts.Bases;
using EXE201.SmartThrive.Domain.Entities;
using EXE201.SmartThrive.Domain.Models.Requests.Queries.Course;

namespace EXE201.SmartThrive.Domain.Contracts.Repositories;

public interface ICourseRepository : IBaseRepository
{
    Task<(List<Course>, int)> GetAllFiltered(CourseGetAllQuery query);
}