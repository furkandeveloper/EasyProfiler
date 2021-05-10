using Microsoft.EntityFrameworkCore.Migrations;

namespace EasyProfiler.PostgreSQL.Migrations
{
    public partial class ChangeDatabaseSchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "easy-profiler");

            migrationBuilder.RenameTable(
                name: "Profilers",
                newName: "Profilers",
                newSchema: "easy-profiler");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "Profilers",
                schema: "easy-profiler",
                newName: "Profilers");
        }
    }
}
