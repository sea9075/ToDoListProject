using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TodoListDemo.Migrations
{
    /// <inheritdoc />
    public partial class SeedTodoListTableToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "todoLists",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateTime",
                value: new DateTime(2024, 6, 17, 15, 56, 26, 541, DateTimeKind.Local).AddTicks(3325));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "todoLists",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateTime",
                value: new DateTime(2024, 6, 17, 15, 56, 13, 491, DateTimeKind.Local).AddTicks(7718));
        }
    }
}
