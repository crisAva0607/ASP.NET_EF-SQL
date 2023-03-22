using System;
using System.Collections.Generic;

namespace RESUME_BUILDER.Models;

public partial class EducationBg
{
    public int Id { get; set; }

    public string? School { get; set; }

    public string? Course { get; set; }

    public string? YearAttended { get; set; }

    public int? StudentId { get; set; }

    public virtual Student? Student { get; set; }
}
