using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class UserAdded4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Admins_Users_AdminId",
                table: "Admins");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Users_AdminId",
                table: "Students");

            migrationBuilder.RenameColumn(
                name: "AdminId",
                table: "Users",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "AdminId",
                table: "Students",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "AdminId",
                table: "Admins",
                newName: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Admins_Users_Id",
                table: "Admins",
                column: "Id",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Users_Id",
                table: "Students",
                column: "Id",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Admins_Users_Id",
                table: "Admins");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Users_Id",
                table: "Students");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Users",
                newName: "AdminId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Students",
                newName: "AdminId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Admins",
                newName: "AdminId");

            migrationBuilder.AddForeignKey(
                name: "FK_Admins_Users_AdminId",
                table: "Admins",
                column: "AdminId",
                principalTable: "Users",
                principalColumn: "AdminId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Users_AdminId",
                table: "Students",
                column: "AdminId",
                principalTable: "Users",
                principalColumn: "AdminId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
