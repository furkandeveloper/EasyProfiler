using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EasyProfiler.MariaDb.Migrations
{
    public partial class AddStartAndEndDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                schema: "easy-profiler",
                table: "Profilers",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDate",
                schema: "easy-profiler",
                table: "Profilers",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndDate",
                schema: "easy-profiler",
                table: "Profilers");

            migrationBuilder.DropColumn(
                name: "StartDate",
                schema: "easy-profiler",
                table: "Profilers");
        }
    }
}
