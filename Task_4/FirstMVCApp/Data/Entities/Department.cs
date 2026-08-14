using System;
using System.Collections.Generic;

namespace FirstMVCApp.Data.Entities;

public partial class Department
{
    public int DepartmentId { get; set; }

    public string DepartmentName { get; set; } = null!;

    public string Location { get; set; } = null!;
}
