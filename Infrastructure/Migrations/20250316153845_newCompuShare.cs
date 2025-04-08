using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class newCompuShare : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Admins",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$8xmXJBmVFrbqhrPrMeFQh.FmYyaeqHyZ4ImtWUYGP0c8g8wq8tKlG");

            migrationBuilder.UpdateData(
                table: "Admins",
                keyColumn: "Id",
                keyValue: 2,
                column: "Password",
                value: "$2a$11$8xmXJBmVFrbqhrPrMeFQh.FmYyaeqHyZ4ImtWUYGP0c8g8wq8tKlG");

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$8xmXJBmVFrbqhrPrMeFQh.FmYyaeqHyZ4ImtWUYGP0c8g8wq8tKlG");

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 2,
                column: "Password",
                value: "$2a$11$8xmXJBmVFrbqhrPrMeFQh.FmYyaeqHyZ4ImtWUYGP0c8g8wq8tKlG");

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 3,
                column: "Password",
                value: "$2a$11$8xmXJBmVFrbqhrPrMeFQh.FmYyaeqHyZ4ImtWUYGP0c8g8wq8tKlG");

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 4,
                column: "Password",
                value: "$2a$11$8xmXJBmVFrbqhrPrMeFQh.FmYyaeqHyZ4ImtWUYGP0c8g8wq8tKlG");

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 5,
                column: "Password",
                value: "$2a$11$8xmXJBmVFrbqhrPrMeFQh.FmYyaeqHyZ4ImtWUYGP0c8g8wq8tKlG");

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "StudentId", "ComputerId", "Email", "IsFunded", "IsRegistered", "Name", "Password", "StudentNumber", "Surname" },
                values: new object[] { 6, 0, "kamomohapi17@gmail.com", false, true, "Kagiso", "$2a$11$8xmXJBmVFrbqhrPrMeFQh.FmYyaeqHyZ4ImtWUYGP0c8g8wq8tKlG", 21851234, "Mohapi" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 6);

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
    }
}
