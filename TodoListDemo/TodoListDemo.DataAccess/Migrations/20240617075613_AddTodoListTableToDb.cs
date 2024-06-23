using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TodoListDemo.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddTodoListTableToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "todoLists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_todoLists", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "todoLists",
                columns: new[] { "Id", "CreateTime", "Description", "EndTime", "StartTime", "Status", "Title" },
                values: new object[] { 1, new DateTime(2024, 6, 17, 15, 56, 13, 491, DateTimeKind.Local).AddTicks(7718), "去桃園牙醫診所看牙醫", new DateTime(2024, 6, 15, 20, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 15, 14, 0, 0, 0, DateTimeKind.Unspecified), true, "看牙醫" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "todoLists");
        }
    }
}
