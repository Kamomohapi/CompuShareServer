using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Computers",
                columns: table => new
                {
                    ComputerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ComputerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ComputerVersion = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    SerialNumber = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Computers", x => x.ComputerId);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    StudentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentNumber = table.Column<int>(type: "int", nullable: false),
                    StudentEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.StudentId);
                });

            migrationBuilder.CreateTable(
                name: "Refubishments",
                columns: table => new
                {
                    RebubishmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ComputerId = table.Column<int>(type: "int", nullable: false),
                    DateRefubished = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateReleased = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Refubishments", x => x.RebubishmentId);
                    table.ForeignKey(
                        name: "FK_Refubishments_Computers_ComputerId",
                        column: x => x.ComputerId,
                        principalTable: "Computers",
                        principalColumn: "ComputerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Admins",
                columns: new[] { "Id", "Email", "Name", "Password", "Surname" },
                values: new object[,]
                {
                    { 1, "thabo@gmail.com", "Thabo", "$2a$11$wHAUIVeA7xXFWo.dcLldDO2hmF4LIBAD49VG0/cxDpJYf6UXynF8u", "Khoza" },
                    { 2, "thato@gmail.com", "Thato", "$2a$11$wHAUIVeA7xXFWo.dcLldDO2hmF4LIBAD49VG0/cxDpJYf6UXynF8u", "Mamatela" }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "StudentId", "Name", "Password", "StudentEmail", "StudentNumber", "Surname" },
                values: new object[,]
                {
                    { 1, "Kamohelo", "$2a$11$wHAUIVeA7xXFWo.dcLldDO2hmF4LIBAD49VG0/cxDpJYf6UXynF8u", "102412345@tut4life.ac.za", 102412345, "Mohapi" },
                    { 2, "Thabo", "$2a$11$wHAUIVeA7xXFWo.dcLldDO2hmF4LIBAD49VG0/cxDpJYf6UXynF8u", "102423456@tut4life.ac.za", 102423456, "Mohale" },
                    { 3, "Busisiwe", "$2a$11$wHAUIVeA7xXFWo.dcLldDO2hmF4LIBAD49VG0/cxDpJYf6UXynF8u", "102434567@tut4life.ac.za", 102434567, "Mkhize" },
                    { 4, "Jabulile", "$2a$11$wHAUIVeA7xXFWo.dcLldDO2hmF4LIBAD49VG0/cxDpJYf6UXynF8u", "102445678@tut4life.ac.za", 102445678, "Mkhwanazi" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Refubishments_ComputerId",
                table: "Refubishments",
                column: "ComputerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admins");

            migrationBuilder.DropTable(
                name: "Refubishments");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Computers");
        }
    }
}
