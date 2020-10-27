using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EasyProfiler.MariaDb.Migrations
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
                    Duration = table.Column<long>(type: "bigint", nullable: false)
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
