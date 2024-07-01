using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TaskListDemo.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddForeignKeyForRoleUserRelation : Migration
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
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "JobLists",
                keyColumn: "JobId",
                keyValue: 1,
                column: "Created_at",
                value: new DateTime(2024, 7, 1, 11, 12, 11, 415, DateTimeKind.Local).AddTicks(8951));

            migrationBuilder.UpdateData(
                table: "JobLists",
                keyColumn: "JobId",
                keyValue: 2,
                column: "Created_at",
                value: new DateTime(2024, 7, 1, 11, 12, 11, 417, DateTimeKind.Local).AddTicks(2748));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "RoleName",
                value: "工程師");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "RoleName",
                value: "使用者");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Email", "Password", "RoleId", "UserName" },
                values: new object[,]
                {
                    { 1, "admin@tasklist.com", "kkk123456", 1, "Admin" },
                    { 2, "engineer@tasklist.com", "kkk123456", 2, "Engineer" },
                    { 3, "user@tasklist.com", "kkk123456", 3, "User" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");
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

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "RoleName",
                value: "使用者");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "RoleName",
                value: "工程師");
        }
    }
}
