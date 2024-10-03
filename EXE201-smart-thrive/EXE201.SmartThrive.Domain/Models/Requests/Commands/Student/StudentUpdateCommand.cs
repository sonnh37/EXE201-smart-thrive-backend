using EXE201.SmartThrive.Domain.Enums;
using EXE201.SmartThrive.Domain.Models.Requests.Commands.Base;

namespace EXE201.SmartThrive.Domain.Models.Requests.Commands.Student;

public class StudentUpdateCommand : UpdateCommand
{
    public Guid? UserId { get; set; }

    public string? StudentName { get; set; }


    public string? FirstName { get; set; }
    public string? LastName { get; set; }

    public Gender? Gender { get; set; }

    public string? ImageAvatar { get; set; }

    public DateTime? Dob { get; set; }

    public UserStatus? Status { get; set; }
}