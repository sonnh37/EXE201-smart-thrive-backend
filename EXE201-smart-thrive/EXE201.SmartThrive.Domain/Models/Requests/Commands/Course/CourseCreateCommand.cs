﻿using EXE201.SmartThrive.Domain.Enums;
using EXE201.SmartThrive.Domain.Models.Requests.Commands.Base;

namespace EXE201.SmartThrive.Domain.Models.Requests.Commands.Course;

public class CourseCreateCommand : CreateCommand
{
    public Guid? SubjectId { get; set; }

    public Guid? ProviderId { get; set; }

    public string? TeacherName { get; set; }

    public CourseType? Type { get; set; }

    public string? Name { get; set; }

    public string? Code { get; set; }

    public string? Description { get; set; }

    public string? BackgroundImage { get; set; }

    public decimal? Price { get; set; }

    public int? SoldCourses { get; set; }

    public int? TotalSlots { get; set; }

    public int? TotalSessions { get; set; }

    public TimeSpan? StartTime { get; set; }

    public TimeSpan? EndTime { get; set; }

    public CourseStatus? Status { get; set; }

    public bool IsActive { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime? EndDate { get; set; }
}