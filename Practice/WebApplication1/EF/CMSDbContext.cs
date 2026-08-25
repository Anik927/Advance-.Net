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
			base.OnModelCreating(modelBuilder);
		
			// Configure the one-to-one relationship between User and Student
			modelBuilder.Entity<Student>()
				.HasOne(s => s.User)
				.WithOne()
				.HasForeignKey<Student>(s => s.Id)
				.OnDelete(DeleteBehavior.Cascade);
			// Configure the one-to-one relationship between User and Admin
			modelBuilder.Entity<Admin>()
				.HasOne(a => a.User)
				.WithOne()
				.HasForeignKey<Admin>(a => a.Id)
				.OnDelete(DeleteBehavior.Cascade);

			modelBuilder.Entity<Department>().HasData(
				new Department { Id = 1, Name = "Computer Science" },
				new Department { Id = 2, Name = "Electrical Engineering" },
				new Department { Id = 3, Name = "Mechanical Engineering" }
			);

			modelBuilder.Entity<User>().HasData(
				new User { Id = 1, Name = "John Doe", Password = "password123", Role = "Student", Age = 20, BloodGroup="A+" },
				new User { Id = 2, Name = "Jane Smith", Password = "password456", Role = "Admin", Age = 30, BloodGroup="B+" }
			);

			modelBuilder.Entity<Admin>().HasData(
				new Admin { Id = 2, AdminLevel = 1 }
			);

			modelBuilder.Entity<Student>().HasData(
				new Student { Id = 1, DepartmentId = 1, SemesterNumber=3 }
			);		

		}



	}
}
