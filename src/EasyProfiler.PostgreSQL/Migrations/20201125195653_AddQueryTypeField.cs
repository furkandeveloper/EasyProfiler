using Microsoft.EntityFrameworkCore.Migrations;

namespace EasyProfiler.PostgreSQL.Migrations
{
    public partial class AddQueryTypeField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Query",
                table: "Profilers",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<int>(
                name: "QueryType",
                table: "Profilers",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "QueryType",
                table: "Profilers");

            migrationBuilder.AlterColumn<string>(
                name: "Query",
                table: "Profilers",
                type: "text",
                nullable: false,
                oldClrType: typeof(int));
        }
    }
}
