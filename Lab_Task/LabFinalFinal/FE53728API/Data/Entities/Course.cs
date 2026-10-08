using System;
using System.Collections.Generic;

namespace FE53728API.Data.Entities;

public partial class Course
{
    public int Id { get; set; }

    public string Code { get; set; } = null!;

    public string Title { get; set; } = null!;

    public int TotalHrs { get; set; }

    public virtual ICollection<Batch> Batches { get; set; } = new List<Batch>();
}
