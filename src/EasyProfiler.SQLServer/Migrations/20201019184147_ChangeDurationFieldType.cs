using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EasyProfiler.SQLServer.Migrations
{
    public partial class ChangeDurationFieldType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<TimeSpan>(
                name: "Duration",
                table: "Profilers",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Duration",
                table: "Profilers",
                type: "int",
                nullable: false,
                oldClrType: typeof(TimeSpan));
        }
    }
}
