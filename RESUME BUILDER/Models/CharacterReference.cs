using System;
using System.Collections.Generic;

namespace RESUME_BUILDER.Models;

public partial class CharacterReference
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Job { get; set; }

    public string? Company { get; set; }

    public string? ContactNumber { get; set; }

    public int? StudentId { get; set; }

    public virtual Student? Student { get; set; }
}
