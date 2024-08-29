﻿using EXE201.SmartThrive.Domain.Models.Requests.Commands.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXE201.SmartThrive.Domain.Models.Requests.Commands.Student
{
    public class StudentCreateCommand : CreateCommand
    {
        public Guid? UserId { get; set; }

        public string? StudentName { get; set; }

        public string? Gender { get; set; }

        public DateTime? DOB { get; set; }

        public string? Phone { get; set; }

        public string? Status { get; set; }
    }
}