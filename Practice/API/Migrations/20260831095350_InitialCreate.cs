using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    BookId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    InternalNotes = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.BookId);
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "BookId", "Author", "InternalNotes", "Price", "Title" },
                values: new object[,]
                {
                    { 1, "Robert C. Martin", "Bestseller, restock monthly", 35.99m, "Clean Code" },
                    { 2, "Andrew Hunt", "Popular with senior devs", 42.50m, "The Pragmatic Programmer" },
                    { 3, "Erich Gamma", "Slow mover, consider discount", 55.00m, "Design Patterns" },
                    { 4, "Martin Fowler", "New edition available", 39.99m, "Refactoring" },
                    { 5, "Kyle Simpson", "Free PDF also circulates online", 24.99m, "You Don't Know JS" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");
        }
    }
}
