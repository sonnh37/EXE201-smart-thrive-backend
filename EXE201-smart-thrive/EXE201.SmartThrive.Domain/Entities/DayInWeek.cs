﻿namespace EXE201.SmartThrive.Domain.Entities;

public class DayInWeek : BaseEntity
{
    public Guid? CourseId { get; set; }

    public bool Monday { get; set; }

    public bool Thursday { get; set; }

    public bool Tuesday { get; set; }

    public bool Wednesday { get; set; }

    public bool Friday { get; set; }

    public bool Saturday { get; set; }

    public bool Sunday { get; set; }

    public virtual Course? Course { get; set; }
}