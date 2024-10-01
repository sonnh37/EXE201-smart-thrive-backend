using EXE201.SmartThrive.Domain.Enums;
using EXE201.SmartThrive.Domain.Models.Requests.Commands.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXE201.SmartThrive.Domain.Models.Requests.Commands.StudentXPackage
{
    public class StudentXPackageCreateCommand: CreateCommand
    {
        public Guid? StudentId { get; set; }

        public Guid? PackageId { get; set; }

        public StudentXPackageStatus Status { get; set; }
    }
}
