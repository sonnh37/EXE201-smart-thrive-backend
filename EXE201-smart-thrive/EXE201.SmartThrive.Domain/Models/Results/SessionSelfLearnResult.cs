﻿namespace EXE201.SmartThrive.Domain.Models.Results;

public class SessionSelfLearnResult : BaseResult
{
    public Guid? SessionId { get; set; }

    public int? SessionNumber { get; set; }

    public string? VideoUrl { get; set; }

    public bool IsComplete { get; set; }

    public SessionResult? Session { get; set; }
}