using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EasyProfiler.PostgreSQL.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Profilers",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Query = table.Column<string>(nullable: false),
                    Duration = table.Column<TimeSpan>(type: "time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profilers", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Profilers_Duration",
                table: "Profilers",
                column: "Duration");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Profilers");
        }
    }
}
