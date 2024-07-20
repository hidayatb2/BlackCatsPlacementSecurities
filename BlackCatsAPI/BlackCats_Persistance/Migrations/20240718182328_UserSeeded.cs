using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlackCats_Persistance.Migrations
{
    /// <inheritdoc />
    public partial class UserSeeded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserStatus",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "ContactNo", "CreatedAt", "CreatedBy", "Email", "Name", "PasswordHash", "PasswordSalt", "RefreshToken", "ResetCode", "TokenExpires", "UserName", "UserRole", "UserStatus" },
                values: new object[] { new Guid("a233a5ed-8fcc-4a90-88e2-e5d6d7d39f2d"), "7006342430", new DateTime(2024, 7, 18, 23, 53, 27, 50, DateTimeKind.Local).AddTicks(3131), null, "admin@gmail.com", "admin", new byte[] { 75, 140, 20, 182, 34, 202, 63, 225, 126, 89, 2, 253, 27, 100, 25, 86, 98, 87, 42, 97, 228, 37, 76, 76, 144, 109, 169, 208, 127, 5, 220, 226 }, new byte[] { 46, 215, 238, 168, 129, 32, 169, 151, 112, 113, 93, 75, 111, 47, 52, 55, 136, 209, 238, 67, 217, 0, 48, 35, 158, 228, 204, 227, 225, 128, 233, 139, 201, 240, 250, 201, 174, 193, 176, 242, 200, 102, 234, 188, 162, 215, 120, 148, 255, 157, 70, 115, 26, 192, 60, 38, 96, 90, 64, 12, 24, 191, 7, 162 }, "", null, null, "admin", 1, 1 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("a233a5ed-8fcc-4a90-88e2-e5d6d7d39f2d"));

            migrationBuilder.DropColumn(
                name: "UserStatus",
                table: "Users");
        }
    }
}
