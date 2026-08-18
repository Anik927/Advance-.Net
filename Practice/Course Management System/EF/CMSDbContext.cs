using Microsoft.EntityFrameworkCore;

namespace Course_Management_System.EF
{
    public class CMSDbContext : DbContext
    {

        public CMSDbContext(DbContextOptions<CMSDbContext> options) : base(options)
        {
            
        }

        public DbSet<Student> Students { get; set; }    
        public DbSet<Course> Courses { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			// Seed Courses
			modelBuilder.Entity<Course>().HasData(
				new Course { CourseId = 1, Title = "Web Development", Duration = 6 },
				new Course { CourseId = 2, Title = "Data Science", Duration = 8 }
			);

			// Seed Students (Link using CourseId only, remove the navigation property)
			modelBuilder.Entity<Student>().HasData(
				new Student
				{
					StudentId = 1,
					Name = "Anik",
					Password = "1234",
					Age = 25,
					DateOfBirth = new DateTime(1999, 1, 1), // Use a fixed date for seeding
					Email = "hh@gmail.com",
					CourseId = 1 // Foreign key pointing to 'Web Development'
				}
			);
		}

	}
}
