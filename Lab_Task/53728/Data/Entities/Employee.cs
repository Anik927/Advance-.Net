using System;
using System.Collections.Generic;

namespace _53728.Data.Entities;

public partial class Employee
{
    public int EmployeeId { get; set; }

    public string EmployeeName { get; set; } = null!;

    public string Department { get; set; } = null!;

    public int Salary { get; set; }

    public int JoiningYear { get; set; }
}
