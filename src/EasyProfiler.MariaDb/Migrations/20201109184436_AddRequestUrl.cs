using Microsoft.EntityFrameworkCore.Migrations;

namespace EasyProfiler.MariaDb.Migrations
{
    public partial class AddRequestUrl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RequestUrl",
                table: "Profilers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RequestUrl",
                table: "Profilers");
        }
    }
}
