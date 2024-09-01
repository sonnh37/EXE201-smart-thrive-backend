using EXE201.SmartThrive.Domain.Models.Requests.Commands.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXE201.SmartThrive.Domain.Models.Requests.Commands.Provider
{
    public class ProviderUpdateCommand: UpdateCommand
    {
        public Guid? UserId { get; set; }

        public string? CompanyName { get; set; }

        public string? Website { get; set; }
    }
}
