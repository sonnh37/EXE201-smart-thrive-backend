using EXE201.SmartThrive.Data.Context;
using EXE201.SmartThrive.Domain.Contracts.Repositories;
using EXE201.SmartThrive.Domain.Entities;
using EXE201.SmartThrive.Domain.Enums;
using EXE201.SmartThrive.Domain.Models;
using EXE201.SmartThrive.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace EXE201.SmartThrive.Repositories;

public class SessionRepository : BaseRepository<Session>, ISessionRepository
{
    public SessionRepository(STDbContext context) : base(context)
    {
    }

    public async Task<IList<SessionSchedule>> GetSessionsByStudentId(Guid studentId)
    {
        var queryStudentXPackage = base.GetQueryable<StudentXPackage>();

        //Lay studentXpackage by studentId
        if (queryStudentXPackage.Any())
        {
            queryStudentXPackage = queryStudentXPackage.Where(e => e.StudentId == studentId);
        }

        //Lay packageIds
        var listStudentXPackage = queryStudentXPackage.ToList();
        var packageIds = queryStudentXPackage.Select(e => e.PackageId).ToList();

        //PackageXCourse by PackageIds
        var queryPackageXCourse = base.GetQueryable<PackageXCourse>();
        if (queryPackageXCourse.Any())
        {
            queryPackageXCourse = queryPackageXCourse.Where(e => packageIds.Contains(e.PackageId));
            var e = queryPackageXCourse.ToList();
        }

        //Lay courseIds
        var courseIds = queryPackageXCourse.Select(e => e.CourseId).ToList();

        //Get courses by courseIds
        var queryCourse = base.GetQueryable<Course>()
    .Where(e => courseIds.Contains(e.Id))
    .Include(e => e.Modules) // Bao gồm các Module
        .ThenInclude(m => m.Sessions) // Bao gồm các Session của Module
            .ThenInclude(s => s.SessionOffline) // Bao gồm SessionOffline trong Session
    .Include(e => e.Modules)
        .ThenInclude(m => m.Sessions)
            .ThenInclude(s => s.SessionMeeting) // Bao gồm SessionMeeting trong Session
    .Include(e => e.Modules)
        .ThenInclude(m => m.Sessions)
            .ThenInclude(s => s.SessionSelfLearn);

        var sessions = await queryCourse
                   .SelectMany(c => c.Modules.SelectMany(m => m.Sessions))
                   .Where(s => s.SessionType.HasValue)
                   .Select(s => new SessionSchedule
                   {
                       CourseName = s.Module.Course.Name,
                       SessionTitle = s.Title,
                       SessionType = s.SessionType,
                       //Location = s.Module.Course.A
                       StartDate = s.SessionType == SessionType.Offline
                    ? s.SessionOffline.Date
                    : s.SessionType == SessionType.Meeting
                    ? s.SessionMeeting.Date
                    : (DateTime?)null, // Chuyển null về kiểu DateTime?
                                       // Tính toán EndDate dựa trên StartDate và Duration (nếu có)
                       EndDate = s.SessionType == SessionType.Offline && s.SessionOffline.Date.HasValue
                  ? s.SessionOffline.Date.Value.AddMinutes(s.SessionOffline.Duration ?? 0)
                  : s.SessionType == SessionType.Meeting && s.SessionMeeting.Date.HasValue
                  ? s.SessionMeeting.Date.Value.AddMinutes(s.SessionMeeting.Duration ?? 0)
                  : (DateTime?)null,
                   })
                   .ToListAsync();

        return (IList<SessionSchedule>)sessions;
    }

    public async Task<IList<SessionComming>> Get4CommingSessionsByStudentId(Guid studentId)
    {
        var queryStudentXPackage = base.GetQueryable<StudentXPackage>();

        //Lay studentXpackage by studentId
        if (queryStudentXPackage.Any())
        {
            queryStudentXPackage = queryStudentXPackage.Where(e => e.StudentId == studentId);
        }

        //Lay packageIds
        var listStudentXPackage = queryStudentXPackage.ToList();
        var packageIds = queryStudentXPackage.Select(e => e.PackageId).ToList();

        //PackageXCourse by PackageIds
        var queryPackageXCourse = base.GetQueryable<PackageXCourse>();
        if (queryPackageXCourse.Any())
        {
            queryPackageXCourse = queryPackageXCourse.Where(e => packageIds.Contains(e.PackageId));
            var e = queryPackageXCourse.ToList();
        }

        //Lay courseIds
        var courseIds = queryPackageXCourse.Select(e => e.CourseId).ToList();

        //Get courses by courseIds
        var queryCourse = base.GetQueryable<Course>()
    .Where(e => courseIds.Contains(e.Id))
    .Include(e => e.Modules) // Bao gồm các Module
        .ThenInclude(m => m.Sessions) // Bao gồm các Session của Module
            .ThenInclude(s => s.SessionOffline) // Bao gồm SessionOffline trong Session
    .Include(e => e.Modules)
        .ThenInclude(m => m.Sessions)
            .ThenInclude(s => s.SessionMeeting) // Bao gồm SessionMeeting trong Session
    .Include(e => e.Modules)
        .ThenInclude(m => m.Sessions)
            .ThenInclude(s => s.SessionSelfLearn);

        var sessions = await queryCourse
                   .SelectMany(c => c.Modules.SelectMany(m => m.Sessions))
                   .Where(s => s.SessionType.HasValue)
                   .Select(s => new SessionComming
                   {
                       CourseName = s.Module.Course.Name,
                       TeacherName = s.Module.Course.TeacherName,
                       SessionTitle = s.Title,
                       SessionType = s.SessionType,
                       //Location = s.Module.Course.A
                       StartDate = s.SessionType == SessionType.Offline
                    ? s.SessionOffline.Date
                    : s.SessionType == SessionType.Meeting
                    ? s.SessionMeeting.Date
                    : (DateTime?)null, // Chuyển null về kiểu DateTime?
                                       // Tính toán EndDate dựa trên StartDate và Duration (nếu có)
                       EndDate = s.SessionType == SessionType.Offline && s.SessionOffline.Date.HasValue
                  ? s.SessionOffline.Date.Value.AddMinutes(s.SessionOffline.Duration ?? 0)
                  : s.SessionType == SessionType.Meeting && s.SessionMeeting.Date.HasValue
                  ? s.SessionMeeting.Date.Value.AddMinutes(s.SessionMeeting.Duration ?? 0)
                  : (DateTime?)null,
                   })
                   .Where(s => s.StartDate >= DateTime.Now) //loc
                   .OrderBy(s => s.StartDate) // sap xep 
                   .Take(4)// Lay 4 phan tu
                   .ToListAsync();

        return (IList<SessionComming>)sessions;
    }
}