using Microsoft.EntityFrameworkCore;

namespace LabFinal01_53728.EF
{
    public class DeptDbContext : DbContext
    {
        public DeptDbContext(DbContextOptions<DeptDbContext> options): base(options) { }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasData(
                    new Employee { Name="Anik", Age=33, EmployeeId=1, DepartmentId=1 },
                    new Employee { Name="Tasnim", Age=33, EmployeeId=2, DepartmentId=1 }
                );

            modelBuilder.Entity<Department>().HasData(
                    new Department { DepartmentId=1, Title="CSE" },
                    new Department { DepartmentId=2, Title="EEE" }                    
                );


        }

    }
}
