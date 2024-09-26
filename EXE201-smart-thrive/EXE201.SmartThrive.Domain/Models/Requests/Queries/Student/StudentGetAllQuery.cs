using EXE201.SmartThrive.Domain.Enums;
using EXE201.SmartThrive.Domain.Models.Requests.Queries.Base;

namespace EXE201.SmartThrive.Domain.Models.Requests.Queries.Student;

public class StudentGetAllQuery : GetAllQuery
{
    public Guid? UserId { get; set; }

    public string? StudentName { get; set; }

    public Gender? Gender { get; set; }

    public DateTime? Dob { get; set; }

    public UserStatus? Status { get; set; }
}