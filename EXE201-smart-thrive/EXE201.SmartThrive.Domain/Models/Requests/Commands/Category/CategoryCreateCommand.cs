using EXE201.SmartThrive.Domain.Models.Requests.Commands.Base;

namespace EXE201.SmartThrive.Domain.Models.Requests.Commands.Category;

public class CategoryCreateCommand : CreateCommand
{
    public string? Name { get; set; }
}