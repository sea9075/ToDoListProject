using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TaskListDemo.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addJobListToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "JobLists",
                columns: table => new
                {
                    JobId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Completed_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Confirmed_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobLists", x => x.JobId);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DisplayNum = table.Column<int>(type: "int", nullable: false),
                    RoleName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "JobLists",
                columns: new[] { "JobId", "Completed_at", "Confirmed_at", "Created_at", "Description", "Status", "Title" },
                values: new object[,]
                {
                    { 1, null, null, new DateTime(2024, 6, 30, 15, 27, 34, 711, DateTimeKind.Local).AddTicks(9315), "剛才突然不能上網", 0, "無法上網" },
                    { 2, null, null, new DateTime(2024, 6, 30, 15, 27, 34, 713, DateTimeKind.Local).AddTicks(5025), "剛剛突然關機，無法重開", 0, "無法開機" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "DisplayNum", "RoleName" },
                values: new object[,]
                {
                    { 1, 1, "管理員" },
                    { 2, 2, "使用者" },
                    { 3, 3, "工程師" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JobLists");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
