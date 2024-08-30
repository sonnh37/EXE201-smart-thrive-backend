using EXE201.SmartThrive.Domain.Contracts.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EXE201.SmartThrive.Domain.Models.Requests.Queries.Student;
using EXE201.SmartThrive.Domain.Models.Requests.Queries.Subject;
using EXE201.SmartThrive.Domain.Models.Responses;
using EXE201.SmartThrive.Domain.Models.Results;

namespace EXE201.SmartThrive.Domain.Contracts.Services
{
    public interface IStudentService : IBaseService
    {
        Task<PaginatedResponse<StudentResult>> GetAllFiltered(StudentGetAllQuery query);
    }
}
