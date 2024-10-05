﻿using EXE201.SmartThrive.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXE201.SmartThrive.Domain.Models
{
    public class SessionSchedule
    {
        public string? CourseName { get; set; }
        public string? SessionTitle { get; set; }
        public string? Location { get; set; }
        public SessionType? SessionType { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}