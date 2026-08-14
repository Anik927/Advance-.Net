using System;
using System.Collections.Generic;

namespace testing.EF.Tables;

public partial class Course
{
    public int CourseId { get; set; }

    public string? CourseName { get; set; }

    public int? Credits { get; set; }

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();
}
