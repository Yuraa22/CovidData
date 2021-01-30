using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CovidData.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CasesDaily",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Date = table.Column<DateTime>(nullable: false),
                    Confirmed = table.Column<int>(nullable: false),
                    Recovered = table.Column<int>(nullable: false),
                    Deaths = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CasesDaily", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CasesTotal",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Date = table.Column<DateTime>(nullable: false),
                    Confirmed = table.Column<int>(nullable: false),
                    Recovered = table.Column<int>(nullable: false),
                    Deaths = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CasesTotal", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CasesDaily");

            migrationBuilder.DropTable(
                name: "CasesTotal");
        }
    }
}
