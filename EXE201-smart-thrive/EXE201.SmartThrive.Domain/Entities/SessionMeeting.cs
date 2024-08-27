﻿namespace EXE201.SmartThrive.Domain.Entities;

public class SessionMeeting : BaseEntity
{
    public string? Host { get; set; }

    public string? MeetingUrl { get; set; }

    public string? MeetingPlatform { get; set; }

    public string? AccessCode { get; set; }
    
    public virtual Session? Session { get; set; }
}