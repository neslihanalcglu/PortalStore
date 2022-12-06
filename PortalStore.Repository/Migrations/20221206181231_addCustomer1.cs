using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PortalStore.Repository.Migrations
{
    public partial class addCustomer1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1,
                column: "Birthdate",
                value: new DateTime(2022, 12, 6, 21, 12, 31, 471, DateTimeKind.Local).AddTicks(2489));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1,
                column: "Birthdate",
                value: new DateTime(2022, 12, 6, 21, 7, 37, 202, DateTimeKind.Local).AddTicks(344));
        }
    }
}
