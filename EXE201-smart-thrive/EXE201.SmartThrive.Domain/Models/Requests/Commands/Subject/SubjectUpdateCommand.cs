using EXE201.SmartThrive.Domain.Models.Requests.Commands.Base;

namespace EXE201.SmartThrive.Domain.Models.Requests.Commands.Subject;

public class SubjectUpdateCommand : UpdateCommand
{
    public string? Name { get; set; }

    public Guid? CategoryId { get; set; }
}