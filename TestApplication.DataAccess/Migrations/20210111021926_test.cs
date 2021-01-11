using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TestApplication.DataAccess.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2021, 1, 11, 5, 19, 25, 882, DateTimeKind.Local).AddTicks(6657));

            migrationBuilder.UpdateData(
                table: "userUserTypes",
                keyColumns: new[] { "UserId", "UserTypeId" },
                keyValues: new object[] { 1, 1 },
                column: "CreatedDate",
                value: new DateTime(2021, 1, 11, 5, 19, 25, 883, DateTimeKind.Local).AddTicks(5522));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2021, 1, 11, 3, 40, 36, 166, DateTimeKind.Local).AddTicks(5539));

            migrationBuilder.UpdateData(
                table: "userUserTypes",
                keyColumns: new[] { "UserId", "UserTypeId" },
                keyValues: new object[] { 1, 1 },
                column: "CreatedDate",
                value: new DateTime(2021, 1, 11, 3, 40, 36, 167, DateTimeKind.Local).AddTicks(4739));
        }
    }
}
