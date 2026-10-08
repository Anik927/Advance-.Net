using System;
using System.Collections.Generic;

namespace FE53728API.Data.Entities;

public partial class Batch
{
    public int Id { get; set; }

    public string Code { get; set; } = null!;

    public string Title { get; set; } = null!;

    public DateOnly StartDate { get; set; }

    public double TutionFee { get; set; }

    public string EnrollmentStatus { get; set; } = null!;

    public int CourseId { get; set; }

    public virtual Course Course { get; set; } = null!;
}
