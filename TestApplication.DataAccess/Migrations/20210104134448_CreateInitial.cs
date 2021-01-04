using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TestApplication.DataAccess.Migrations
{
    public partial class CreateInitial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerName = table.Column<string>(name: "Customer Name", type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
                    CustomerPhone = table.Column<string>(name: "Customer Phone", type: "varchar(11)", unicode: false, maxLength: 11, nullable: false),
                    CustomerAddress = table.Column<string>(name: "Customer Address", type: "nvarchar(200)", maxLength: 200, nullable: false),
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
                    eMail = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Name = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
                    password = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
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
                    userTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userTypeName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    userTypeDescription = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserType", x => x.userTypeId);
                });

            migrationBuilder.CreateTable(
                name: "CustomerCard",
                columns: table => new
                {
                    CustomerCardId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerCardName = table.Column<string>(name: "CustomerCard Name", type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
                    ProductManagerName = table.Column<string>(name: "ProductManager Name", type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
                    CostOfCardTime = table.Column<double>(type: "float", nullable: false),
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
                    UserId = table.Column<int>(type: "int", nullable: false),
                    UserTypeId = table.Column<int>(type: "int", nullable: false),
                    UserUserTypeId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_userUserTypes", x => new { x.UserId, x.UserTypeId });
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
                        principalColumn: "userTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CustomerCardRow",
                columns: table => new
                {
                    CustomerCardRowId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerCardId = table.Column<int>(type: "int", nullable: false),
                    DeveloperName = table.Column<string>(name: "Developer Name", type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
                    Priorty = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
                    FinishedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProgressId = table.Column<int>(type: "int", nullable: false),
                    Explanation = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
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
                columns: new[] { "UserId", "CreatedDate", "eMail", "Name", "password" },
                values: new object[] { 1, new DateTime(2021, 1, 4, 16, 44, 46, 751, DateTimeKind.Local).AddTicks(4965), "ozanbatuhanozdal@hotmail.com", "Batuhan", "123" });

            migrationBuilder.InsertData(
                table: "UserType",
                columns: new[] { "userTypeId", "userTypeDescription", "userTypeName" },
                values: new object[] { 1, "admin", "admin" });

            migrationBuilder.InsertData(
                table: "userUserTypes",
                columns: new[] { "UserId", "UserTypeId", "CreatedDate", "UserUserTypeId" },
                values: new object[] { 1, 1, new DateTime(2021, 1, 4, 16, 44, 46, 758, DateTimeKind.Local).AddTicks(8796), 1 });

            migrationBuilder.CreateIndex(
                name: "IX_CustomerCard_CustomerId",
                table: "CustomerCard",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerCardRow_CustomerCardId",
                table: "CustomerCardRow",
                column: "CustomerCardId");

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
