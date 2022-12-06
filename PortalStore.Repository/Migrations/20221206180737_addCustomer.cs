using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PortalStore.Repository.Migrations
{
    public partial class addCustomer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Birthdate", "CreationDate", "Email", "FirstName", "Gsm", "LastName", "Status", "TCID" },
                values: new object[] { 1, new DateTime(2022, 12, 6, 21, 7, 37, 202, DateTimeKind.Local).AddTicks(344), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "deneme@gmail.com", "Test", "123456789", "Test", false, 11111111111L });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
