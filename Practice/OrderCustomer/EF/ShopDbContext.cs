using Microsoft.EntityFrameworkCore;

namespace OrderCustomer.EF
{
    public class ShopDbContext : DbContext
    {
        public ShopDbContext(DbContextOptions<ShopDbContext> options) : base(options)
        {
        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().HasData(
                new Customer
                {
                    CustomerId = 1,
                    Name = "John Doe",
                    Email = "john.doe@example.com",
                },
                new Customer
                {
                    CustomerId = 2,
                    Name = "Jane Smith",
                    Email = "jane.smith@example.com"
                }
            );

            modelBuilder.Entity<Order>().HasData(
                new Order
                {
                    OrderId = 1,
                    ProductName = "Product A",
                    Quantity = 2,
                    OrderDate = new DateTime(2026, 1, 1),
                    CustomerId = 1
                },
                new Order
                {
                    OrderId = 2,
                    ProductName = "Product B",
                    Quantity = 3,
                    OrderDate = new DateTime(2026, 2, 1),
                    CustomerId = 2
                }
                );
        }




    }
}
