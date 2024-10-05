using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXE201.SmartThrive.Domain.Models
{
    public class RegisterByGoogleRequest
    {
        public string? Token { get; set; }
        public string? Password { get; set; }
    }
}
