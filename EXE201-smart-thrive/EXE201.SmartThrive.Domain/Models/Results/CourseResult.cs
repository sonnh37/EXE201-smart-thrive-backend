﻿using EXE201.SmartThrive.Domain.Entities;

namespace EXE201.SmartThrive.Domain.Models.Results;

public class CourseResult : BaseResult
{
    public Guid? SubjectId { get; set; }

    public Guid? ProviderId { get; set; }

    public string? TeacherName { get; set; }

    public string? Type { get; set; }

    public string? Name { get; set; }

    public string? Code { get; set; }

    public string? CourseName { get; set; }

    public string? Description { get; set; }

    public string? BackgroundImage { get; set; }

    public decimal? Price { get; set; }

    public int? SoldCourses { get; set; }

    public int? TotalSlots { get; set; }

    public int? TotalSessions { get; set; }

    public TimeSpan StartTime { get; set; }

    public TimeSpan EndTime { get; set; }

    public string? Status { get; set; }

    public bool IsActive { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public virtual DayInWeek? DayInWeek { get; set; }

    public virtual Subject? Subject { get; set; }

    public virtual Provider? Provider { get; set; }

    public List<ModuleResult>? Modules { get; set; }

    public List<FeedbackResult>? Feedbacks { get; set; }

    public List<PackageXCourseResult>? PackageXCourses { get; set; }
}