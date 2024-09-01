using EXE201.SmartThrive.Domain.Models.Requests.Commands.Base;

namespace EXE201.SmartThrive.Domain.Models.Requests.Commands.Provider;

public class ProviderCreateCommand : CreateCommand
{
    public Guid? UserId { get; set; }

    public string? CompanyName { get; set; }

    public string? Website { get; set; }
}