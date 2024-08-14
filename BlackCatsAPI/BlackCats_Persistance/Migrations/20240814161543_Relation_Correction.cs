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
                keyValue: new Guid("9d971057-4dfa-41b6-990b-d820ef228dbe"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "ContactNo", "CreatedAt", "CreatedBy", "Email", "IsDeleted", "Name", "PasswordHash", "PasswordSalt", "RefreshToken", "ResetCode", "TokenExpires", "UserName", "UserRole", "UserStatus" },
                values: new object[] { new Guid("ff987286-e262-4bb0-be5b-df942b1e9c8a"), "7006342430", new DateTime(2024, 8, 14, 21, 45, 43, 256, DateTimeKind.Local).AddTicks(9966), null, "admin@gmail.com", false, "admin", new byte[] { 184, 130, 156, 110, 49, 15, 106, 217, 164, 164, 176, 3, 217, 71, 226, 20, 55, 21, 193, 92, 132, 193, 92, 194, 171, 49, 225, 240, 67, 135, 73, 242 }, new byte[] { 153, 8, 12, 164, 8, 213, 22, 110, 125, 140, 222, 153, 151, 215, 227, 24, 149, 173, 214, 68, 25, 38, 146, 142, 148, 180, 166, 170, 207, 160, 18, 116, 166, 40, 222, 154, 80, 239, 30, 106, 113, 199, 168, 239, 8, 208, 6, 16, 45, 146, 2, 235, 145, 101, 34, 51, 147, 18, 223, 16, 171, 22, 65, 129 }, "", null, null, "admin", 1, 1 });

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
                keyValue: new Guid("ff987286-e262-4bb0-be5b-df942b1e9c8a"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "ContactNo", "CreatedAt", "CreatedBy", "Email", "IsDeleted", "Name", "PasswordHash", "PasswordSalt", "RefreshToken", "ResetCode", "TokenExpires", "UserName", "UserRole", "UserStatus" },
                values: new object[] { new Guid("9d971057-4dfa-41b6-990b-d820ef228dbe"), "7006342430", new DateTime(2024, 7, 28, 22, 29, 35, 568, DateTimeKind.Local).AddTicks(6043), null, "admin@gmail.com", false, "admin", new byte[] { 112, 161, 95, 48, 224, 58, 74, 117, 43, 145, 33, 18, 212, 78, 220, 184, 89, 179, 170, 94, 1, 200, 191, 226, 126, 53, 79, 207, 196, 188, 21, 48 }, new byte[] { 222, 178, 181, 253, 21, 249, 171, 208, 241, 88, 219, 181, 135, 255, 129, 254, 71, 227, 248, 9, 221, 91, 11, 232, 121, 145, 64, 243, 82, 115, 245, 212, 106, 227, 247, 78, 103, 59, 80, 236, 244, 113, 232, 203, 60, 107, 161, 123, 73, 189, 136, 62, 228, 5, 237, 135, 93, 241, 138, 113, 174, 31, 6, 114 }, "", null, null, "admin", 1, 1 });

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
