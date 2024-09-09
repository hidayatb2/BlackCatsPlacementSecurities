using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlackCats_Persistance.Migrations
{
    /// <inheritdoc />
    public partial class RefershTokenRemoved : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("9d971057-4dfa-41b6-990b-d820ef228dbe"));

            migrationBuilder.DropColumn(
                name: "RefreshToken",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "TokenExpires",
                table: "Users");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "ContactNo", "CreatedAt", "CreatedBy", "Email", "IsDeleted", "Name", "PasswordHash", "PasswordSalt", "ResetCode", "UserName", "UserRole", "UserStatus" },
                values: new object[] { new Guid("ee2966ed-d6f6-4af0-8d20-d13b6f5d18a2"), "7006342430", new DateTime(2024, 8, 14, 21, 44, 47, 817, DateTimeKind.Local).AddTicks(4258), null, "admin@gmail.com", false, "admin", new byte[] { 181, 83, 127, 154, 158, 117, 250, 197, 48, 47, 193, 6, 92, 163, 86, 53, 192, 66, 216, 135, 129, 167, 197, 104, 157, 194, 57, 253, 154, 10, 119, 69 }, new byte[] { 4, 180, 201, 249, 166, 238, 154, 95, 21, 26, 248, 157, 172, 54, 19, 50, 3, 203, 128, 50, 248, 99, 70, 34, 111, 74, 89, 252, 192, 243, 163, 6, 174, 6, 239, 48, 170, 43, 183, 231, 162, 209, 202, 152, 147, 249, 250, 252, 220, 47, 74, 47, 77, 207, 87, 172, 1, 150, 224, 103, 228, 97, 12, 138 }, null, "admin", 1, 1 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("ee2966ed-d6f6-4af0-8d20-d13b6f5d18a2"));

            migrationBuilder.AddColumn<string>(
                name: "RefreshToken",
                table: "Users",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<DateTime>(
                name: "TokenExpires",
                table: "Users",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "ContactNo", "CreatedAt", "CreatedBy", "Email", "IsDeleted", "Name", "PasswordHash", "PasswordSalt", "RefreshToken", "ResetCode", "TokenExpires", "UserName", "UserRole", "UserStatus" },
                values: new object[] { new Guid("9d971057-4dfa-41b6-990b-d820ef228dbe"), "7006342430", new DateTime(2024, 7, 28, 22, 29, 35, 568, DateTimeKind.Local).AddTicks(6043), null, "admin@gmail.com", false, "admin", new byte[] { 112, 161, 95, 48, 224, 58, 74, 117, 43, 145, 33, 18, 212, 78, 220, 184, 89, 179, 170, 94, 1, 200, 191, 226, 126, 53, 79, 207, 196, 188, 21, 48 }, new byte[] { 222, 178, 181, 253, 21, 249, 171, 208, 241, 88, 219, 181, 135, 255, 129, 254, 71, 227, 248, 9, 221, 91, 11, 232, 121, 145, 64, 243, 82, 115, 245, 212, 106, 227, 247, 78, 103, 59, 80, 236, 244, 113, 232, 203, 60, 107, 161, 123, 73, 189, 136, 62, 228, 5, 237, 135, 93, 241, 138, 113, 174, 31, 6, 114 }, "", null, null, "admin", 1, 1 });
        }
    }
}
