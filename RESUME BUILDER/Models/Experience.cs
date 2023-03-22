using System;
using System.Collections.Generic;

namespace RESUME_BUILDER.Models;

public partial class Experience
{
    public int Id { get; set; }

    public string? Role { get; set; }

    public string? Company { get; set; }

    public int? StudentId { get; set; }

    public virtual Student? Student { get; set; }
}
