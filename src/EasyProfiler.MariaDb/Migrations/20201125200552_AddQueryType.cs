using Microsoft.EntityFrameworkCore.Migrations;

namespace EasyProfiler.MariaDb.Migrations
{
    public partial class AddQueryType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "QueryType",
                table: "Profilers",
                nullable: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "QueryType",
                table: "Profilers");
        }
    }
}
