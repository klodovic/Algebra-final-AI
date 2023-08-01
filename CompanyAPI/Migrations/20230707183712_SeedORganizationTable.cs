using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CompanyAPI.Migrations
{
    /// <inheritdoc />
    public partial class SeedORganizationTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Organizations",
                columns: new[] { "Id", "CellNumber", "City", "CompanyName", "Country", "CreatedTime", "Email", "Fax", "Iban", "Mbs", "Oib", "Phone", "PostNumber", "Street", "Website" },
                values: new object[,]
                {
                    { 1, "098/888555", "Zagreb", "AB Gradnja", "Hrvatska", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "info@ab.hr", "01/888555", "HR012345678998787121", "012345648", "123456", "01/888555", "1000", "Ilica 12", "www/ab.hr" },
                    { 2, "098/999252", "Zagreb", "CD Gradnja", "Hrvatska", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "info@cd.hr", "01/999252", "HR0123456789264581", "01234564897", "1234564587", "01/999252", "10000", "Ilica 152", "www/cd.hr" },
                    { 3, "098/2255663", "Zagreb", "Adria", "Hrvatska", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "info@2255663.hr", "01/2255663", "HR012345676543210", "9876543210", "9874563210", "01/2255663", "10000", "Selska ulica 15", "www/adria.hr" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
