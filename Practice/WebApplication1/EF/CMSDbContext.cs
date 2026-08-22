using Microsoft.EntityFrameworkCore;

namespace WebApplication1.EF
{
    public class CMSDbContext : DbContext
    {
        public CMSDbContext(DbContextOptions<CMSDbContext> options) : base(options)
        { }

        public DbSet<Student> Students { get; set; }

        public DbSet<Department> Departments { get; set; }

		public DbSet<Admin> Admins { get; set; }

		public DbSet<User> Users { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<User>().ToTable("Users");
			modelBuilder.Entity<Student>().ToTable("Students");
			modelBuilder.Entity<Admin>().ToTable("Admins");

			modelBuilder.Entity<Department>().HasData(
				new Department { Id = 1, Name = "Computer Science" },
				new Department { Id = 2, Name = "Mathematics" },
				new Department { Id = 3, Name = "Physics" }
			);

			modelBuilder.Entity<Student>().HasData(
				new Student { Id = 1, Name = "Alice", Age = 20, BloodGroup = "O-", Password = "password1", Role = "Student", DepartmentId = 1, SemesterNumber = 3 },
				new Student { Id = 2, Name = "Bob", Age = 22, BloodGroup = "A+", Password = "password2", Role = "Student", DepartmentId = 2, SemesterNumber = 5 },
				new Student { Id = 3, Name = "Charlie", Age = 21, BloodGroup = "O+", Password = "password3", Role = "Student", DepartmentId = 3, SemesterNumber = 1 }
			);

			modelBuilder.Entity<Admin>().HasData(
				new Admin { Id = 4, Name = "David", Age = 30, BloodGroup = "B-", Password = "adminpassword1", Role = "Admin", AdminLevel = 1 },
				new Admin { Id = 5, Name = "Eve", Age = 35, BloodGroup = "AB+", Password = "adminpassword2", Role = "Admin", AdminLevel = 2 }
			);
		}

	}
}
