using System;
using System.Collections.Generic;

namespace testing.EF.Tables;

public partial class Student
{
    public int StudentId { get; set; }

    public string? Name { get; set; }

    public DateOnly? DateOfBirth { get; set; }

    public string? Email { get; set; }

    public int? CourseId { get; set; }

    public virtual Course? Course { get; set; }
}
