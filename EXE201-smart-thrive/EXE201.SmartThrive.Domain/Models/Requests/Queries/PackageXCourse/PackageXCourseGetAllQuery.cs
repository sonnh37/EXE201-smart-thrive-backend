using EXE201.SmartThrive.Domain.Models.Requests.Queries.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXE201.SmartThrive.Domain.Models.Requests.Queries.PackageXCourse
{
    public class PackageXCourseGetAllQuery: GetAllQuery
    {
        public Guid? CourseId { get; set; }

        public Guid? PackageId { get; set; }
    }
}
