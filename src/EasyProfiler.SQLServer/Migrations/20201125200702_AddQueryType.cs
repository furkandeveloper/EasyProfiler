using Microsoft.EntityFrameworkCore.Migrations;

namespace EasyProfiler.SQLServer.Migrations
{
    public partial class AddQueryType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "QueryType",
                table: "Profilers",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "QueryType",
                table: "Profilers");
        }
    }
}
