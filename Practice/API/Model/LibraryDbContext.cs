using System.Text;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static Azure.Core.HttpHeader;

namespace API2.Model
{
    public class LibraryDbContext:DbContext
    {
        public LibraryDbContext(DbContextOptions<LibraryDbContext> options) : base(options) { }

        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().HasData(
                new Book
                {
                    BookId = 1,
                    Title = "Clean Code",
                    Author = "Robert C. Martin",
                    Price = 35.99m,
                    InternalNotes = "Bestseller, restock monthly"
                },
                new Book
                {
                    BookId = 2,
                    Title = "The Pragmatic Programmer",
                    Author = "Andrew Hunt",
                    Price = 42.50m,
                    InternalNotes = "Popular with senior devs"
                },
                new Book
                {
                    BookId = 3,
                    Title = "Design Patterns",
                    Author = "Erich Gamma",
                    Price = 55.00m,
                    InternalNotes = "Slow mover, consider discount"
                },
                new Book
                {
                    BookId = 4,
                    Title = "Refactoring",
                    Author = "Martin Fowler",
                    Price = 39.99m,
                    InternalNotes = "New edition available"
                },
                new Book
                {
                    BookId = 5,
                    Title = "You Don't Know JS",
                    Author = "Kyle Simpson",
                    Price = 24.99m,
                    InternalNotes = "Free PDF also circulates online"
                }
            );
        }

        }
}
