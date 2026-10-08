using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace WebApplication1.Entity
{
    public class UniMContext : DbContext
    {
        public UniMContext(DbContextOptions<UniMContext> options) : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<User> Users { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().HasData(
                new Student
                {
                    Id = 1,
                    Name = "John Doe",
                    Email = "john.doe@example.com",
                    DateOfBirth = new DateTime(2000, 1, 1),
                    CourseId = 1

                },
                new Student
                {
                    Id = 2,
                    Name = "Jane Smith",
                    Email = "jane.smith@example.com",
                    DateOfBirth = new DateTime(2001, 2, 2),
                    CourseId = 2
                }
            );

            modelBuilder.Entity<Course>().HasData(
                new Course
                {
                    Id = 1,
                    Title = "Mathematics",
                    StartDate = new DateTime(2024, 9, 1)
                },
                new Course
                {
                    Id = 2,
                    Title = "Physics",
                    StartDate = new DateTime(2024, 9, 1)
                }
            );

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    Username = "admin",
                    PasswordHash = "admin123",
                    Role = "Admin"
                },
                new User
                {
                    Id = 2,
                    Username = "Staff",
                    PasswordHash = "user123",
                    Role = "Staff"
                }
            );
        }
    }
}
