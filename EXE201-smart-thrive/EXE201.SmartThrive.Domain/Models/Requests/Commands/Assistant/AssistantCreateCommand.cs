using EXE201.SmartThrive.Domain.Models.Requests.Commands.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXE201.SmartThrive.Domain.Models.Requests.Commands.Assistant
{
    public class AssistantCreateCommand : CreateCommand
    {
        public string? FullName { get; set; }

        public string? Phone { get; set; }

        public string? Email { get; set; }
    }
}
