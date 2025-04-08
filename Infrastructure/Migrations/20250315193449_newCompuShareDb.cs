using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class newCompuShareDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Admins",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$t6xkQyJo3SBThu8BBj23meohinqiOGz2BDScOxGkXzYDcYE9Zir.G");

            migrationBuilder.UpdateData(
                table: "Admins",
                keyColumn: "Id",
                keyValue: 2,
                column: "Password",
                value: "$2a$11$t6xkQyJo3SBThu8BBj23meohinqiOGz2BDScOxGkXzYDcYE9Zir.G");

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$t6xkQyJo3SBThu8BBj23meohinqiOGz2BDScOxGkXzYDcYE9Zir.G");

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 2,
                column: "Password",
                value: "$2a$11$t6xkQyJo3SBThu8BBj23meohinqiOGz2BDScOxGkXzYDcYE9Zir.G");

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 3,
                column: "Password",
                value: "$2a$11$t6xkQyJo3SBThu8BBj23meohinqiOGz2BDScOxGkXzYDcYE9Zir.G");

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 4,
                column: "Password",
                value: "$2a$11$t6xkQyJo3SBThu8BBj23meohinqiOGz2BDScOxGkXzYDcYE9Zir.G");

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 5,
                column: "Password",
                value: "$2a$11$t6xkQyJo3SBThu8BBj23meohinqiOGz2BDScOxGkXzYDcYE9Zir.G");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Admins",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$U19QY4/h75mYXmG7pksqNOc1R/rp5TdkDoTAhvyyfpTEFheg/Dx56");

            migrationBuilder.UpdateData(
                table: "Admins",
                keyColumn: "Id",
                keyValue: 2,
                column: "Password",
                value: "$2a$11$U19QY4/h75mYXmG7pksqNOc1R/rp5TdkDoTAhvyyfpTEFheg/Dx56");

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$U19QY4/h75mYXmG7pksqNOc1R/rp5TdkDoTAhvyyfpTEFheg/Dx56");

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 2,
                column: "Password",
                value: "$2a$11$U19QY4/h75mYXmG7pksqNOc1R/rp5TdkDoTAhvyyfpTEFheg/Dx56");

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 3,
                column: "Password",
                value: "$2a$11$U19QY4/h75mYXmG7pksqNOc1R/rp5TdkDoTAhvyyfpTEFheg/Dx56");

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 4,
                column: "Password",
                value: "$2a$11$U19QY4/h75mYXmG7pksqNOc1R/rp5TdkDoTAhvyyfpTEFheg/Dx56");

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 5,
                column: "Password",
                value: "$2a$11$U19QY4/h75mYXmG7pksqNOc1R/rp5TdkDoTAhvyyfpTEFheg/Dx56");
        }
    }
}
