using EXE201.SmartThrive.Domain.Models.Requests.Queries.Base;

namespace EXE201.SmartThrive.Domain.Models.Requests.Queries.Provider;

public class ProviderGetAllQuery : GetAllQuery
{
    public Guid? UserId { get; set; }

    public string? CompanyName { get; set; }

    public string? Address { get; set; }

    public string? Website { get; set; }
}