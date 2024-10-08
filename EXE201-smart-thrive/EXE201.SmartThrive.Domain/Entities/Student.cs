﻿using EXE201.SmartThrive.Domain.Enums;

namespace EXE201.SmartThrive.Domain.Entities;

public class Student : BaseEntity
{
    public Guid? UserId { get; set; }

    public string? StudentName { get; set; }

    public string? FirstName { get; set; }
    public string? LastName { get; set; }

    public Gender? Gender { get; set; }

    public DateTime? Dob { get; set; }

    public string? ImageAvatar { get; set; }

    public UserStatus? Status { get; set; }

    public virtual User? User { get; set; }

    public virtual Feedback? Feedback { get; set; }

    public virtual ICollection<StudentXPackage>? StudentXPackages { get; set; }
}