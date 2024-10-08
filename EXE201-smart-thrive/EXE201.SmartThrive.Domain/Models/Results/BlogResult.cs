﻿namespace EXE201.SmartThrive.Domain.Models.Results;

public class BlogResult : BaseResult
{
    public Guid? UserId { get; set; }

    public string? Title { get; set; }

    public string? Description { get; set; }

    public bool IsActive { get; set; }

    public string? BackgroundImage { get; set; }

    public UserResult? User { get; set; }
}