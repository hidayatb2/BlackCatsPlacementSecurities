using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlackCats_Persistance.Migrations
{
    /// <inheritdoc />
    public partial class Relation_Correction : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clients_Users_Id",
                table: "Clients");

            migrationBuilder.DropForeignKey(
                name: "FK_Contracts_Clients_Id",
                table: "Contracts");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Clients_Id",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Wages_Employees_Id",
                table: "Wages");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("ee2966ed-d6f6-4af0-8d20-d13b6f5d18a2"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "ContactNo", "CreatedAt", "CreatedBy", "Email", "IsDeleted", "Name", "PasswordHash", "PasswordSalt", "ResetCode", "UserName", "UserRole", "UserStatus" },
                values: new object[] { new Guid("af056936-524e-43d2-95ed-f746ca6ccb46"), "7006342430", new DateTime(2024, 8, 15, 0, 11, 1, 713, DateTimeKind.Local).AddTicks(1018), null, "admin@gmail.com", false, "admin", new byte[] { 32, 28, 25, 64, 28, 65, 50, 32, 240, 111, 44, 102, 168, 149, 201, 158, 134, 3, 100, 37, 228, 27, 44, 87, 231, 110, 234, 125, 18, 94, 111, 32 }, new byte[] { 56, 189, 33, 185, 143, 23, 168, 6, 84, 73, 206, 75, 143, 135, 179, 3, 249, 50, 115, 117, 166, 69, 229, 252, 9, 111, 204, 107, 10, 222, 204, 50, 70, 7, 81, 201, 103, 132, 45, 201, 207, 18, 146, 180, 93, 159, 108, 188, 27, 84, 150, 3, 60, 89, 48, 71, 214, 8, 156, 12, 20, 107, 48, 159 }, null, "admin", 1, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Wages_EmployeeId",
                table: "Wages",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_ClientId",
                table: "Employees",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_ClientId",
                table: "Contracts",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_UserId",
                table: "Clients",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_Users_UserId",
                table: "Clients",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Contracts_Clients_ClientId",
                table: "Contracts",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Clients_ClientId",
                table: "Employees",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Wages_Employees_EmployeeId",
                table: "Wages",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clients_Users_UserId",
                table: "Clients");

            migrationBuilder.DropForeignKey(
                name: "FK_Contracts_Clients_ClientId",
                table: "Contracts");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Clients_ClientId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Wages_Employees_EmployeeId",
                table: "Wages");

            migrationBuilder.DropIndex(
                name: "IX_Wages_EmployeeId",
                table: "Wages");

            migrationBuilder.DropIndex(
                name: "IX_Employees_ClientId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Contracts_ClientId",
                table: "Contracts");

            migrationBuilder.DropIndex(
                name: "IX_Clients_UserId",
                table: "Clients");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("af056936-524e-43d2-95ed-f746ca6ccb46"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "ContactNo", "CreatedAt", "CreatedBy", "Email", "IsDeleted", "Name", "PasswordHash", "PasswordSalt", "ResetCode", "UserName", "UserRole", "UserStatus" },
                values: new object[] { new Guid("ee2966ed-d6f6-4af0-8d20-d13b6f5d18a2"), "7006342430", new DateTime(2024, 8, 14, 21, 44, 47, 817, DateTimeKind.Local).AddTicks(4258), null, "admin@gmail.com", false, "admin", new byte[] { 181, 83, 127, 154, 158, 117, 250, 197, 48, 47, 193, 6, 92, 163, 86, 53, 192, 66, 216, 135, 129, 167, 197, 104, 157, 194, 57, 253, 154, 10, 119, 69 }, new byte[] { 4, 180, 201, 249, 166, 238, 154, 95, 21, 26, 248, 157, 172, 54, 19, 50, 3, 203, 128, 50, 248, 99, 70, 34, 111, 74, 89, 252, 192, 243, 163, 6, 174, 6, 239, 48, 170, 43, 183, 231, 162, 209, 202, 152, 147, 249, 250, 252, 220, 47, 74, 47, 77, 207, 87, 172, 1, 150, 224, 103, 228, 97, 12, 138 }, null, "admin", 1, 1 });

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_Users_Id",
                table: "Clients",
                column: "Id",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Contracts_Clients_Id",
                table: "Contracts",
                column: "Id",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Clients_Id",
                table: "Employees",
                column: "Id",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Wages_Employees_Id",
                table: "Wages",
                column: "Id",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
