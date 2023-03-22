using System;
using System.Collections.Generic;

namespace RESUME_BUILDER.Models;

public partial class Training
{
    public int Id { get; set; }

    public string? TrainingName { get; set; }

    public string? YearAttended { get; set; }

    public int? StudentId { get; set; }

    public virtual Student? Student { get; set; }
}
