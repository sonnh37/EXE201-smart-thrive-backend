using EXE201.SmartThrive.Domain.Models.Requests.Commands.Base;

namespace EXE201.SmartThrive.Domain.Models.Requests.Commands.Module;

public class ModuleUpdateCommand : UpdateCommand
{
    public Guid? CourseId { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }
}