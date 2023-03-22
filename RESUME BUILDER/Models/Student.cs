using System;
using System.Collections.Generic;

namespace RESUME_BUILDER.Models;

public partial class Student
{
    public int Id { get; set; }

    public string? FirstName { get; set; }

    public string? MiddleName { get; set; }

    public string? LastName { get; set; }

    public string? Role { get; set; }

    public string? Address { get; set; }

    public string? ContactNumber { get; set; }

    public string? Objective { get; set; }

    public virtual ICollection<CharacterReference> CharacterReferences { get; } = new List<CharacterReference>();

    public virtual ICollection<EducationBg> EducationBgs { get; } = new List<EducationBg>();

    public virtual ICollection<Experience> Experiences { get; } = new List<Experience>();

    public virtual ICollection<Link> Links { get; } = new List<Link>();

    public virtual ICollection<Skill> Skills { get; } = new List<Skill>();

    public virtual ICollection<Training> Training { get; } = new List<Training>();
}
