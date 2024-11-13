using EXE201.SmartThrive.Data.Context;
using EXE201.SmartThrive.Domain.Contracts.Repositories;
using EXE201.SmartThrive.Domain.Entities;
using EXE201.SmartThrive.Repositories.Base;

namespace EXE201.SmartThrive.Repositories
{
    public class PackageXCourseRepository : BaseRepository<PackageXCourse>, IPackageXCourseRepository
    {
        private STDbContext _context;
        public PackageXCourseRepository(STDbContext dbContext) : base(dbContext)
        {
            _context = dbContext;
        }

        public int AddToUpdatePackagePrice(PackageXCourse packageXCourse)
        {
            //Add packagexcourse
            packageXCourse.Id = Guid.NewGuid();
            packageXCourse.CreatedDate = DateTime.Now;
            _context.PackageXCourses.Add(packageXCourse);
            _context.SaveChanges();

            //get order ids by package id
            var listIds = _context.PackageXCourses.Where(e => e.PackageId == packageXCourse.PackageId).Select(e => e.CourseId).ToList();

            //get orders
            var listPrice = _context.Courses.Where(e => listIds.Contains(e.Id)).Select(e => e.Price).ToList();

            //total price of package
            decimal totalPrice = 0;
            foreach (decimal item in listPrice)
            {
                totalPrice += item;
            }

            //get package by id
            var p = _context.Packages.Where(e => e.Id == packageXCourse.PackageId).FirstOrDefault();

            //update package
            p.TotalPrice = totalPrice;
            p.QuantityCourse = listIds.Count();
            _context.Packages.Update(p);
            var rs = _context.SaveChanges();

            return rs;
        }

        public int DeleteToUpdatePackagePrice(Guid id)
        {
            //Delete packagexcourse
            var pxc = _context.PackageXCourses.Where(e => e.Id == id).FirstOrDefault();
            _context.PackageXCourses.Remove(pxc);
            _context.SaveChanges();

            //get package by id
            var p = _context.Packages.Where(e => e.Id == pxc.PackageId).FirstOrDefault();

            //total price of package
            decimal totalPrice = 0;

            //get order ids by package id
            var listIds = _context.PackageXCourses.Where(e => e.PackageId == pxc.PackageId).Select(e => e.CourseId).ToList();

            if (listIds.Count > 0)
            {
                //get orders
                var listPrice = _context.Courses.Where(e => listIds.Contains(e.Id)).Select(e => e.Price).ToList();

                foreach (decimal item in listPrice)
                {
                    totalPrice += item;
                }
            }

            //update package
            p.TotalPrice = totalPrice;
            p.QuantityCourse = listIds.Count();

            _context.Packages.Update(p);
            var rs = _context.SaveChanges();

            return rs;
        }
    }
}
