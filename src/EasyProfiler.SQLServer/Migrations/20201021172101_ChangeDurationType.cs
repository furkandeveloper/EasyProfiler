using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EasyProfiler.SQLServer.Migrations
{
    public partial class ChangeDurationType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<TimeSpan>(
                name: "Duration",
                table: "Profilers",
                type: "time",
                nullable: false,
                oldClrType: typeof(TimeSpan),
                oldType: "time(7)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<TimeSpan>(
                name: "Duration",
                table: "Profilers",
                type: "time(7)",
                nullable: false,
                oldClrType: typeof(TimeSpan),
                oldType: "time");
        }
    }
}
