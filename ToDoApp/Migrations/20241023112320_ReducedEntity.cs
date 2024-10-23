using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToDoApp.Migrations
{
    /// <inheritdoc />
    public partial class ReducedEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateWhenAdded",
                table: "ToDoItems");

            migrationBuilder.DropColumn(
                name: "TimeWhenAdded",
                table: "ToDoItems");

            migrationBuilder.DropColumn(
                name: "WhenFinished",
                table: "ToDoItems");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateOnly>(
                name: "DateWhenAdded",
                table: "ToDoItems",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<TimeOnly>(
                name: "TimeWhenAdded",
                table: "ToDoItems",
                type: "time",
                nullable: false,
                defaultValue: new TimeOnly(0, 0, 0));

            migrationBuilder.AddColumn<DateTime>(
                name: "WhenFinished",
                table: "ToDoItems",
                type: "datetime2",
                nullable: true);
        }
    }
}
