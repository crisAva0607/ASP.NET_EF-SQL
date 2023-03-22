using System;
using System.Collections.Generic;

namespace RESUME_BUILDER.Models;

public partial class Skill
{
    public int Id { get; set; }

    public string? SkillName { get; set; }

    public int? StudentId { get; set; }

    public virtual Student? Student { get; set; }
}
