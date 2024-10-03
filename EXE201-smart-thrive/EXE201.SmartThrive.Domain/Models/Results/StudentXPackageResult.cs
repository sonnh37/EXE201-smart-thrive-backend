using EXE201.SmartThrive.Domain.Enums;

namespace EXE201.SmartThrive.Domain.Models.Results;

public class StudentXPackageResult : BaseResult
{
    public Guid? StudentId { get; set; }

    public Guid? PackageId { get; set; }

    public StudentXPackageStatus Status { get; set; }


    public StudentResult? Student { get; set; }

    public PackageResult? Package { get; set; }
}