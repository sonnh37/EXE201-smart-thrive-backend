using EXE201.SmartThrive.Domain.Models.Requests.Commands.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXE201.SmartThrive.Domain.Models.Requests.Commands.Blog
{
    public class BlogUpdateCommand : UpdateCommand
    {
        public Guid? UserId { get; set; }

        public string? Title { get; set; }

        public string? Description { get; set; }

        public bool IsActive { get; set; }

        public string? Status { get; set; }

        public string? BackgroundImage { get; set; }
    }
}
