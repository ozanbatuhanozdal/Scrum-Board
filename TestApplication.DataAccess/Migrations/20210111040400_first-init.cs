using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TestApplication.DataAccess.Migrations
{
    public partial class firstinit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerName = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
                    CustomerPhone = table.Column<string>(type: "varchar(11)", unicode: false, maxLength: 11, nullable: false),
                    CustomerAddress = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
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
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Guid = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    CustomerCardName = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
                    ProductManagerName = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
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
                    DeveloperName = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
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
                columns: new[] { "UserId", "CreatedDate", "eMail", "Guid", "Name", "PasswordHash", "PasswordSalt" },
                values: new object[] { 1, new DateTime(2021, 1, 11, 7, 4, 0, 164, DateTimeKind.Local).AddTicks(9455), "ozanbatuhanozdal@hotmail.com", "e15bddf8-c087-4ca9-b7ea-5b6bfa6408e8", "Batuhan", new byte[] { 156, 8, 27, 62, 92, 139, 243, 29, 169, 69, 253, 195, 115, 179, 188, 122, 100, 161, 64, 55, 204, 157, 113, 24, 38, 50, 46, 245, 255, 166, 15, 161, 50, 125, 201, 94, 154, 109, 70, 20, 160, 31, 180, 136, 37, 83, 43, 228, 48, 78, 40, 76, 131, 195, 243, 141, 201, 112, 243, 151, 166, 39, 83, 9 }, new byte[] { 164, 11, 55, 81, 215, 216, 114, 249, 112, 44, 201, 7, 204, 93, 213, 216, 67, 155, 107, 42, 105, 243, 67, 193, 235, 120, 230, 226, 36, 154, 10, 193, 57, 42, 162, 73, 62, 86, 202, 221, 118, 214, 145, 78, 153, 91, 222, 93, 193, 254, 21, 225, 244, 30, 122, 56, 23, 109, 80, 246, 213, 71, 74, 98, 55, 183, 228, 162, 48, 155, 25, 90, 154, 233, 135, 243, 124, 86, 162, 198, 191, 78, 75, 179, 68, 199, 138, 242, 136, 83, 120, 136, 241, 116, 137, 224, 45, 227, 142, 48, 70, 94, 208, 253, 235, 110, 235, 63, 10, 57, 48, 27, 42, 34, 243, 208, 254, 73, 61, 44, 40, 56, 118, 150, 223, 103, 149, 152 } });

            migrationBuilder.InsertData(
                table: "UserType",
                columns: new[] { "userTypeId", "userTypeDescription", "userTypeName" },
                values: new object[] { 1, "admin", "admin" });

            migrationBuilder.InsertData(
                table: "userUserTypes",
                columns: new[] { "UserUserTypeId", "CreatedDate", "UserId", "UserTypeId" },
                values: new object[] { 1, new DateTime(2021, 1, 11, 7, 4, 0, 166, DateTimeKind.Local).AddTicks(3204), 1, 1 });

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
