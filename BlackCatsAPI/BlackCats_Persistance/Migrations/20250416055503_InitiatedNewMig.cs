using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlackCats_Persistance.Migrations
{
    /// <inheritdoc />
    public partial class InitiatedNewMig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CLIENTS_APPFILES_AgreementDocumentId",
                table: "CLIENTS");

            migrationBuilder.DropIndex(
                name: "IX_CLIENTS_AgreementDocumentId",
                table: "CLIENTS");

            migrationBuilder.DeleteData(
                table: "USERS",
                keyColumn: "Id",
                keyValue: new Guid("9fb4e56e-a9c2-41f9-b68c-7ab698ac07e3"));

            migrationBuilder.DropColumn(
                name: "AgreementDocumentId",
                table: "CLIENTS");

            migrationBuilder.AddColumn<int>(
                name: "FileType",
                table: "APPFILES",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "USERS",
                columns: new[] { "Id", "ContactNo", "CreatedAt", "CreatedBy", "Email", "IsDeleted", "Name", "PasswordHash", "PasswordSalt", "ResetCode", "UserName", "UserRole", "UserStatus" },
                values: new object[] { new Guid("acb90693-15df-45a2-85e9-2c3b54194183"), "7006342430", new DateTime(2025, 4, 16, 11, 25, 2, 416, DateTimeKind.Local).AddTicks(8704), null, "admin@gmail.com", false, "admin", new byte[] { 36, 50, 97, 36, 49, 49, 36, 107, 111, 87, 50, 84, 67, 82, 111, 85, 103, 70, 122, 119, 90, 103, 110, 54, 51, 49, 98, 103, 117, 69, 121, 87, 73, 113, 99, 98, 117, 67, 70, 97, 87, 51, 81, 54, 106, 117, 54, 119, 87, 65, 67, 82, 87, 111, 81, 46, 53, 110, 55, 105 }, new byte[] { 36, 50, 97, 36, 49, 49, 36, 107, 111, 87, 50, 84, 67, 82, 111, 85, 103, 70, 122, 119, 90, 103, 110, 54, 51, 49, 98, 103, 117 }, null, "admin", 1, 1 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "USERS",
                keyColumn: "Id",
                keyValue: new Guid("acb90693-15df-45a2-85e9-2c3b54194183"));

            migrationBuilder.DropColumn(
                name: "FileType",
                table: "APPFILES");

            migrationBuilder.AddColumn<Guid>(
                name: "AgreementDocumentId",
                table: "CLIENTS",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci");

            migrationBuilder.InsertData(
                table: "USERS",
                columns: new[] { "Id", "ContactNo", "CreatedAt", "CreatedBy", "Email", "IsDeleted", "Name", "PasswordHash", "PasswordSalt", "ResetCode", "UserName", "UserRole", "UserStatus" },
                values: new object[] { new Guid("9fb4e56e-a9c2-41f9-b68c-7ab698ac07e3"), "7006342430", new DateTime(2024, 9, 14, 2, 42, 22, 695, DateTimeKind.Local).AddTicks(1331), null, "admin@gmail.com", false, "admin", new byte[] { 36, 50, 97, 36, 49, 49, 36, 57, 65, 77, 52, 101, 103, 70, 56, 111, 82, 90, 56, 73, 80, 100, 97, 57, 107, 49, 69, 66, 79, 117, 49, 77, 111, 86, 73, 121, 116, 56, 100, 82, 110, 120, 98, 118, 76, 65, 109, 46, 51, 85, 102, 118, 70, 100, 108, 70, 49, 68, 102, 117 }, new byte[] { 36, 50, 97, 36, 49, 49, 36, 57, 65, 77, 52, 101, 103, 70, 56, 111, 82, 90, 56, 73, 80, 100, 97, 57, 107, 49, 69, 66, 79 }, null, "admin", 1, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_CLIENTS_AgreementDocumentId",
                table: "CLIENTS",
                column: "AgreementDocumentId");

            migrationBuilder.AddForeignKey(
                name: "FK_CLIENTS_APPFILES_AgreementDocumentId",
                table: "CLIENTS",
                column: "AgreementDocumentId",
                principalTable: "APPFILES",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
