using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlackCats_Persistance.Migrations
{
    /// <inheritdoc />
    public partial class SeededUserPasswordCorrection : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("af056936-524e-43d2-95ed-f746ca6ccb46"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "ContactNo", "CreatedAt", "CreatedBy", "Email", "IsDeleted", "Name", "PasswordHash", "PasswordSalt", "ResetCode", "UserName", "UserRole", "UserStatus" },
                values: new object[] { new Guid("5dadbeda-18ed-4c39-acd8-90cf7206962b"), "7006342430", new DateTime(2024, 8, 15, 0, 46, 8, 577, DateTimeKind.Local).AddTicks(8483), null, "admin@gmail.com", false, "admin", new byte[] { 36, 50, 97, 36, 49, 49, 36, 111, 47, 85, 46, 98, 113, 115, 83, 46, 109, 76, 46, 68, 80, 78, 98, 88, 77, 103, 52, 86, 101, 80, 82, 115, 84, 47, 86, 47, 114, 71, 103, 112, 46, 52, 81, 98, 66, 56, 49, 51, 118, 118, 103, 70, 100, 54, 119, 109, 73, 117, 116, 75 }, new byte[] { 36, 50, 97, 36, 49, 49, 36, 111, 47, 85, 46, 98, 113, 115, 83, 46, 109, 76, 46, 68, 80, 78, 98, 88, 77, 103, 52, 86, 101 }, null, "admin", 1, 1 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("5dadbeda-18ed-4c39-acd8-90cf7206962b"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "ContactNo", "CreatedAt", "CreatedBy", "Email", "IsDeleted", "Name", "PasswordHash", "PasswordSalt", "ResetCode", "UserName", "UserRole", "UserStatus" },
                values: new object[] { new Guid("af056936-524e-43d2-95ed-f746ca6ccb46"), "7006342430", new DateTime(2024, 8, 15, 0, 11, 1, 713, DateTimeKind.Local).AddTicks(1018), null, "admin@gmail.com", false, "admin", new byte[] { 32, 28, 25, 64, 28, 65, 50, 32, 240, 111, 44, 102, 168, 149, 201, 158, 134, 3, 100, 37, 228, 27, 44, 87, 231, 110, 234, 125, 18, 94, 111, 32 }, new byte[] { 56, 189, 33, 185, 143, 23, 168, 6, 84, 73, 206, 75, 143, 135, 179, 3, 249, 50, 115, 117, 166, 69, 229, 252, 9, 111, 204, 107, 10, 222, 204, 50, 70, 7, 81, 201, 103, 132, 45, 201, 207, 18, 146, 180, 93, 159, 108, 188, 27, 84, 150, 3, 60, 89, 48, 71, 214, 8, 156, 12, 20, 107, 48, 159 }, null, "admin", 1, 1 });
        }
    }
}
