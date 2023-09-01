using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Raspored.Migrations
{
    public partial class Edited : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_ContractType_ContractTypeId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Position_PositionId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "ContractType");

            migrationBuilder.DropTable(
                name: "Position");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "04fc4544-ff32-451c-8fbe-c9c47a29adba");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2dc07fbe-32a3-4b66-84f2-e15a40eb325b");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "58a526d6-fd71-4af7-90d1-a7bb6d6cff41");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Teams",
                type: "nvarchar(40)",
                maxLength: 40,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "TeamMemberRoles",
                type: "nvarchar(3)",
                maxLength: 3,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "TeamMemberRoles",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "ShiftTypes",
                type: "nvarchar(3)",
                maxLength: 3,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "ShiftTypes",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "ContractTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContractTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Positions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Positions", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "ContractTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Određeno" },
                    { 2, "Neodređeno" },
                    { 3, "Zamena" },
                    { 4, "Stažiranje" },
                    { 5, "Zamrznuto" },
                    { 6, "Čeka prekid ugovora" },
                    { 7, "Prekinut radni odnos" }
                });

            migrationBuilder.InsertData(
                table: "Positions",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Organizaciona sestra - tehničar" },
                    { 2, "Edukator" },
                    { 3, "Medicinska sestra - tehničar" },
                    { 4, "Mikrobiološka sestra - tehničar" },
                    { 5, "Administrativna sestra - tehničar" },
                    { 6, "Sterilizacijska sestra - tehničar" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_ContractTypes_ContractTypeId",
                table: "AspNetUsers",
                column: "ContractTypeId",
                principalTable: "ContractTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Positions_PositionId",
                table: "AspNetUsers",
                column: "PositionId",
                principalTable: "Positions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_ContractTypes_ContractTypeId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Positions_PositionId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "ContractTypes");

            migrationBuilder.DropTable(
                name: "Positions");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Teams",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(40)",
                oldMaxLength: 40);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "TeamMemberRoles",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(3)",
                oldMaxLength: 3);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "TeamMemberRoles",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "ShiftTypes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(3)",
                oldMaxLength: 3,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "ShiftTypes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "ContractType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContractType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Position",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Position", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "ContractType",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Određeno" },
                    { 2, "Neodređeno" },
                    { 3, "Zamena" },
                    { 4, "Stažiranje" },
                    { 5, "Zamrznuto" },
                    { 6, "Čeka prekid ugovora" },
                    { 7, "Prekinut radni odnos" }
                });

            migrationBuilder.InsertData(
                table: "Position",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Organizaciona sestra - tehničar" },
                    { 2, "Edukator" },
                    { 3, "Medicinska sestra - tehničar" },
                    { 4, "Mikrobiološka sestra - tehničar" },
                    { 5, "Administrativna sestra - tehničar" },
                    { 6, "Sterilizacijska sestra - tehničar" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "ContractTypeId", "DateOfBirth", "Deleted", "Email", "EmailConfirmed", "FirstName", "LastName", "LicenseNumber", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "PositionId", "Rating", "SecurityStamp", "TwoFactorEnabled", "UserName", "YearOfEmployment" },
                values: new object[] { "2dc07fbe-32a3-4b66-84f2-e15a40eb325b", 0, "e45d6649-07ce-41f4-8379-904f2527db0e", 2, new DateTime(1985, 6, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "admin@example.com", true, "admin", "admin", "OVO2131312341", false, null, null, null, "AQAAAAEAACcQAAAAEKKe+SgAMHF4Qs/Pe70LnRDfkL5lm4nSRBtVV8xwASWIKfjHl3wolOCNvoSsZ6Jq1Q==", null, false, 1, 0.0, "2516f7dc-1138-4e2e-9f9c-361bb17906a9", false, "admin", 2022 });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "ContractTypeId", "DateOfBirth", "Deleted", "Email", "EmailConfirmed", "FirstName", "LastName", "LicenseNumber", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "PositionId", "Rating", "SecurityStamp", "TwoFactorEnabled", "UserName", "YearOfEmployment" },
                values: new object[] { "58a526d6-fd71-4af7-90d1-a7bb6d6cff41", 0, "40b670b8-74e4-474d-a754-4c1e56a8f829", 2, new DateTime(1995, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "korisnik1@test.com", false, "korisnik", "prvi", "OVO2156312341", false, null, null, null, "AQAAAAEAACcQAAAAELWgSYBJhkNPl7eGlPPVkm4LsYy4m2uO3q5l1cvWfHaIoJmtBXz3VamAvrDzx9vpcw==", null, false, 1, 0.0, "3db8406e-96ba-4056-82ff-20a5888a4ef0", false, "korisnik1", 2022 });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "ContractTypeId", "DateOfBirth", "Deleted", "Email", "EmailConfirmed", "FirstName", "LastName", "LicenseNumber", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "PositionId", "Rating", "SecurityStamp", "TwoFactorEnabled", "UserName", "YearOfEmployment" },
                values: new object[] { "04fc4544-ff32-451c-8fbe-c9c47a29adba", 0, "0414e394-ad4f-4021-aec9-52dab8c56ca0", 2, new DateTime(1985, 6, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "korisnik2@test.com", false, "korisnik", "drugi", "OVO2131356341", false, null, null, null, "AQAAAAEAACcQAAAAEE8bfLLdzLVRWTppQg2WLSYI2GfDwqoxjJYZhPr6MvIeFkkHvR7dCCAMo/s67Ip0qQ==", null, false, 1, 0.0, "fe1a008e-711b-4046-9bab-1bf706186660", false, "korisnik2", 2022 });

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_ContractType_ContractTypeId",
                table: "AspNetUsers",
                column: "ContractTypeId",
                principalTable: "ContractType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Position_PositionId",
                table: "AspNetUsers",
                column: "PositionId",
                principalTable: "Position",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
