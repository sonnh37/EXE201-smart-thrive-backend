using EXE201.SmartThrive.Data.Context;
using EXE201.SmartThrive.Domain.Contracts.Repositories;
using EXE201.SmartThrive.Domain.Entities;
using EXE201.SmartThrive.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXE201.SmartThrive.Repositories
{
    public class PackageXCourseRepository: BaseRepository<PackageXCourse>, IPackageXCourseRepository
    {
        public PackageXCourseRepository(STDbContext dbContext) : base(dbContext)
        {
        }
    }
}
