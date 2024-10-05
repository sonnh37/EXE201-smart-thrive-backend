using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXE201.SmartThrive.Domain.Models
{
    public class VerifyOtpRequest
    {
        public string? Email { get; set; }
        public string? Otp { get; set; }
    }
}
