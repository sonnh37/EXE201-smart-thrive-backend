using EXE201.SmartThrive.Domain.Models.Requests.Commands.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXE201.SmartThrive.Domain.Models.Requests.Commands.StudentXPackage
{
    public class StudentXPackageUpdateCommand: UpdateCommand
    {
        public Guid? StudentId { get; set; }

        public Guid? PackageId { get; set; }

        public bool? Status { get; set; }
    }
}
