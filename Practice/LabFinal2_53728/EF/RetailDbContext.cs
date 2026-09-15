using Microsoft.EntityFrameworkCore;

namespace LabFinal2_53728.EF
{
    public class RetailDbContext : DbContext
    {
        public RetailDbContext(DbContextOptions<RetailDbContext> options) : base(options) { }

        public DbSet<Products> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Products>().HasData(
                new Products { Id = 1, Name = "Product A", Category = "Category 1", Price = 10.99m, Quantity = 100 },
                new Products { Id = 2, Name = "Product B", Category = "Category 2", Price = 19.99m, Quantity = 50 },
                new Products { Id = 3, Name = "Product C", Category = "Category 1", Price = 5.99m, Quantity = 200 }
            );
        }
    }
}
