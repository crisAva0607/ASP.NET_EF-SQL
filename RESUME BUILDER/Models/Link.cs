using System;
using System.Collections.Generic;

namespace RESUME_BUILDER.Models;

public partial class Link
{
    public int Id { get; set; }

    public string? Github { get; set; }

    public string? Gmail { get; set; }

    public int? StudentId { get; set; }

    public virtual Student? Student { get; set; }
}
