using Microsoft.EntityFrameworkCore;

namespace APIFinalTest.EF
{
    public class APITestDbContext : DbContext
    {
        public APITestDbContext(DbContextOptions<APITestDbContext> options) : base(options)
        {
        }

        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Patient> Patients { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Configure the one-to-many relationship between Doctor and Patient
            
            modelBuilder.Entity<Doctor>().HasData(
                new Doctor { Id = 1, Name = "Dr. Smith", Specialty = "Cardiology", Salary = 150000 },
                new Doctor { Id = 2, Name = "Dr. Johnson", Specialty = "Neurology", Salary = 160000 }
            );

            modelBuilder.Entity<Patient>().HasData(
                new Patient { Id = 1, Name = "John Doe", Age = 30, DoctorId = 1, Address = "123 Main St" },
                new Patient { Id = 2, Name = "Jane Smith", Age = 25, DoctorId = 1, Address = "456 Oak Ave" },
                new Patient { Id = 3, Name = "Alice Johnson", Age = 40, DoctorId = 2, Address = "789 Pine Rd" }
            );

        }

    }
}
