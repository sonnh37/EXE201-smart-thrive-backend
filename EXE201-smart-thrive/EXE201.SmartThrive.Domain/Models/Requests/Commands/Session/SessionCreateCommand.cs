using EXE201.SmartThrive.Domain.Enums;
using EXE201.SmartThrive.Domain.Models.Requests.Commands.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXE201.SmartThrive.Domain.Models.Requests.Commands.Session
{
    public class SessionCreateCommand : CreateCommand
    {
        public Guid? ModuleId { get; set; }

        public string? Title { get; set; }

        public string? Document { get; set; }

        public SessionType SessionType { get; set; }
        public int SessionNumber { get; set; }

        public string? Description { get; set; }

        public object? Detail { get; set; }
    }
}
