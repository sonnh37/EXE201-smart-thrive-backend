﻿namespace EXE201.SmartThrive.Domain.Models.Results;

public class UserResult : BaseResult
{
    public string? Username { get; set; }

    public string? Password { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? ImageUrl { get; set; }

    public string? Email { get; set; }

    public DateTime? Dob { get; set; }

    public string? Address { get; set; }

    public string? Gender { get; set; }

    public string? Phone { get; set; }

    public string? Status { get; set; }

    public string? RoleName { get; set; }

    public List<BlogResult>? Blogs { get; set; }

    public ProviderResult? Provider { get; set; }

    public List<StudentResult>? Students { get; set; }
}