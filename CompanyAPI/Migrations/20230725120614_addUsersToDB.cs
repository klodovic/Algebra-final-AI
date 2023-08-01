﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CompanyAPI.Migrations
{
    /// <inheritdoc />
    public partial class addUsersToDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedTime",
                value: new DateTime(2023, 7, 25, 14, 6, 14, 891, DateTimeKind.Local).AddTicks(2195));

            migrationBuilder.UpdateData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedTime",
                value: new DateTime(2023, 7, 25, 14, 6, 14, 891, DateTimeKind.Local).AddTicks(2254));

            migrationBuilder.UpdateData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedTime",
                value: new DateTime(2023, 7, 25, 14, 6, 14, 891, DateTimeKind.Local).AddTicks(2257));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedTime",
                value: new DateTime(2023, 7, 7, 20, 39, 30, 167, DateTimeKind.Local).AddTicks(8213));

            migrationBuilder.UpdateData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedTime",
                value: new DateTime(2023, 7, 7, 20, 39, 30, 167, DateTimeKind.Local).AddTicks(8272));

            migrationBuilder.UpdateData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedTime",
                value: new DateTime(2023, 7, 7, 20, 39, 30, 167, DateTimeKind.Local).AddTicks(8278));
        }
    }
}
