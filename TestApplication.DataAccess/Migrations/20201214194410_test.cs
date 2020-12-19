using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TestApplication.DataAccess.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomerPhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomerAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.CustomerId);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "UserType",
                columns: table => new
                {
                    UserTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserTypeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserTypeDescription = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserType", x => x.UserTypeId);
                });

            migrationBuilder.CreateTable(
                name: "CustomerCard",
                columns: table => new
                {
                    CustomerCardId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerCardName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductManagerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerCard", x => x.CustomerCardId);
                    table.ForeignKey(
                        name: "FK_CustomerCard_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "userUserTypes",
                columns: table => new
                {
                    UserUserTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    UserTypeId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_userUserTypes", x => x.UserUserTypeId);
                    table.ForeignKey(
                        name: "FK_userUserTypes_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_userUserTypes_UserType_UserTypeId",
                        column: x => x.UserTypeId,
                        principalTable: "UserType",
                        principalColumn: "UserTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CustomerCardRow",
                columns: table => new
                {
                    CustomerCardRowId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerCardId = table.Column<int>(type: "int", nullable: false),
                    DeveloperName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Priorty = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FinishedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Explanation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerCardRow", x => x.CustomerCardRowId);
                    table.ForeignKey(
                        name: "FK_CustomerCardRow_CustomerCard_CustomerCardId",
                        column: x => x.CustomerCardId,
                        principalTable: "CustomerCard",
                        principalColumn: "CustomerCardId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "UserId", "CreatedDate", "Email", "Name", "Password" },
                values: new object[] { 1, new DateTime(2020, 12, 14, 22, 44, 9, 709, DateTimeKind.Local).AddTicks(8057), "ozanbatuhanozdal@hotmail.com", "Batuhan", "123" });

            migrationBuilder.InsertData(
                table: "UserType",
                columns: new[] { "UserTypeId", "UserTypeDescription", "UserTypeName" },
                values: new object[] { 1, "admin", "admin" });

            migrationBuilder.InsertData(
                table: "userUserTypes",
                columns: new[] { "UserUserTypeId", "CreatedDate", "UserId", "UserTypeId" },
                values: new object[] { 1, new DateTime(2020, 12, 14, 22, 44, 9, 710, DateTimeKind.Local).AddTicks(7532), 1, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_CustomerCard_CustomerId",
                table: "CustomerCard",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerCardRow_CustomerCardId",
                table: "CustomerCardRow",
                column: "CustomerCardId");

            migrationBuilder.CreateIndex(
                name: "IX_userUserTypes_UserId",
                table: "userUserTypes",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_userUserTypes_UserTypeId",
                table: "userUserTypes",
                column: "UserTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomerCardRow");

            migrationBuilder.DropTable(
                name: "userUserTypes");

            migrationBuilder.DropTable(
                name: "CustomerCard");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "UserType");

            migrationBuilder.DropTable(
                name: "Customer");
        }
    }
}
