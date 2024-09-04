using EXE201.SmartThrive.Domain.Enums;
using EXE201.SmartThrive.Domain.Models.Requests.Commands.Base;

namespace EXE201.SmartThrive.Domain.Models.Requests.Commands.Student;

public class StudentCreateCommand : CreateCommand
{
    public Guid? UserId { get; set; }

    public string? StudentName { get; set; }

    public Gender? Gender { get; set; }

    public DateTime? Dob { get; set; }

    public UserStatus? Status { get; set; }
}