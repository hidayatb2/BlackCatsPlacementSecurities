using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlackCats_Persistance.Migrations
{
    /// <inheritdoc />
    public partial class NewEntityAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("a233a5ed-8fcc-4a90-88e2-e5d6d7d39f2d"));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Users",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "AppFiles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    FilePath = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ModuleType = table.Column<int>(type: "int", nullable: false),
                    ModuleId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    CreatedBy = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppFiles", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Address = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ContactNo = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AgreementDate = table.Column<DateOnly>(type: "date", nullable: false),
                    TotalEmployees = table.Column<int>(type: "int", nullable: false),
                    SecurityDeposit = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    AgreementDocumentId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    UserId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    CreatedBy = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Clients_AppFiles_AgreementDocumentId",
                        column: x => x.AgreementDocumentId,
                        principalTable: "AppFiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Clients_Users_Id",
                        column: x => x.Id,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Contracts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    From = table.Column<DateOnly>(type: "date", nullable: false),
                    To = table.Column<DateOnly>(type: "date", nullable: false),
                    ClientId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    CreatedBy = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contracts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contracts_Clients_Id",
                        column: x => x.Id,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Address = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ContactNo = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DateOfJoining = table.Column<DateOnly>(type: "date", nullable: false),
                    DateOfLeaving = table.Column<DateOnly>(type: "date", nullable: true),
                    AadhaarNumber = table.Column<long>(type: "bigint", nullable: false),
                    BankAccountNo = table.Column<long>(type: "bigint", nullable: false),
                    IsUniformFeePaid = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    ClientId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    CreatedBy = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_Clients_Id",
                        column: x => x.Id,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Wages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    DailyWages = table.Column<int>(type: "int", nullable: false),
                    NoOfWorkingDays = table.Column<int>(type: "int", nullable: false),
                    WageMonth = table.Column<DateOnly>(type: "date", nullable: false),
                    PFDeduction = table.Column<int>(type: "int", nullable: false),
                    ESICDeduction = table.Column<int>(type: "int", nullable: false),
                    EmployeeId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    CreatedBy = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Wages_Employees_Id",
                        column: x => x.Id,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "ContactNo", "CreatedAt", "CreatedBy", "Email", "IsDeleted", "Name", "PasswordHash", "PasswordSalt", "RefreshToken", "ResetCode", "TokenExpires", "UserName", "UserRole", "UserStatus" },
                values: new object[] { new Guid("9d971057-4dfa-41b6-990b-d820ef228dbe"), "7006342430", new DateTime(2024, 7, 28, 22, 29, 35, 568, DateTimeKind.Local).AddTicks(6043), null, "admin@gmail.com", false, "admin", new byte[] { 112, 161, 95, 48, 224, 58, 74, 117, 43, 145, 33, 18, 212, 78, 220, 184, 89, 179, 170, 94, 1, 200, 191, 226, 126, 53, 79, 207, 196, 188, 21, 48 }, new byte[] { 222, 178, 181, 253, 21, 249, 171, 208, 241, 88, 219, 181, 135, 255, 129, 254, 71, 227, 248, 9, 221, 91, 11, 232, 121, 145, 64, 243, 82, 115, 245, 212, 106, 227, 247, 78, 103, 59, 80, 236, 244, 113, 232, 203, 60, 107, 161, 123, 73, 189, 136, 62, 228, 5, 237, 135, 93, 241, 138, 113, 174, 31, 6, 114 }, "", null, null, "admin", 1, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Clients_AgreementDocumentId",
                table: "Clients",
                column: "AgreementDocumentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contracts");

            migrationBuilder.DropTable(
                name: "Wages");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "AppFiles");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("9d971057-4dfa-41b6-990b-d820ef228dbe"));

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Users");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "ContactNo", "CreatedAt", "CreatedBy", "Email", "Name", "PasswordHash", "PasswordSalt", "RefreshToken", "ResetCode", "TokenExpires", "UserName", "UserRole", "UserStatus" },
                values: new object[] { new Guid("a233a5ed-8fcc-4a90-88e2-e5d6d7d39f2d"), "7006342430", new DateTime(2024, 7, 18, 23, 53, 27, 50, DateTimeKind.Local).AddTicks(3131), null, "admin@gmail.com", "admin", new byte[] { 75, 140, 20, 182, 34, 202, 63, 225, 126, 89, 2, 253, 27, 100, 25, 86, 98, 87, 42, 97, 228, 37, 76, 76, 144, 109, 169, 208, 127, 5, 220, 226 }, new byte[] { 46, 215, 238, 168, 129, 32, 169, 151, 112, 113, 93, 75, 111, 47, 52, 55, 136, 209, 238, 67, 217, 0, 48, 35, 158, 228, 204, 227, 225, 128, 233, 139, 201, 240, 250, 201, 174, 193, 176, 242, 200, 102, 234, 188, 162, 215, 120, 148, 255, 157, 70, 115, 26, 192, 60, 38, 96, 90, 64, 12, 24, 191, 7, 162 }, "", null, null, "admin", 1, 1 });
        }
    }
}
