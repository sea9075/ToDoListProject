using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TaskListDemo.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addUserToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.UpdateData(
                table: "JobLists",
                keyColumn: "JobId",
                keyValue: 1,
                column: "Created_at",
                value: new DateTime(2024, 7, 2, 2, 11, 33, 782, DateTimeKind.Local).AddTicks(8110));

            migrationBuilder.UpdateData(
                table: "JobLists",
                keyColumn: "JobId",
                keyValue: 2,
                column: "Created_at",
                value: new DateTime(2024, 7, 2, 2, 11, 33, 784, DateTimeKind.Local).AddTicks(5730));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Email", "Password", "UserName" },
                values: new object[,]
                {
                    { 1, "John@tasklist.com", "kkk123456", "John" },
                    { 2, "ben@tasklist.com", "kkk123456", "Ben" },
                    { 3, "marry@tasklist.com", "kkk123456", "Marry" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.UpdateData(
                table: "JobLists",
                keyColumn: "JobId",
                keyValue: 1,
                column: "Created_at",
                value: new DateTime(2024, 6, 30, 15, 27, 34, 711, DateTimeKind.Local).AddTicks(9315));

            migrationBuilder.UpdateData(
                table: "JobLists",
                keyColumn: "JobId",
                keyValue: 2,
                column: "Created_at",
                value: new DateTime(2024, 6, 30, 15, 27, 34, 713, DateTimeKind.Local).AddTicks(5025));
        }
    }
}
