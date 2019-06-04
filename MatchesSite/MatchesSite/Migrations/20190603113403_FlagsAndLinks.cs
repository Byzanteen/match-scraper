using Microsoft.EntityFrameworkCore.Migrations;

namespace MatchesSite.Migrations
{
    public partial class FlagsAndLinks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Flag",
                table: "Countries",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageLink",
                table: "Bookies",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Link",
                table: "Bookies",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Flag",
                table: "Countries");

            migrationBuilder.DropColumn(
                name: "ImageLink",
                table: "Bookies");

            migrationBuilder.DropColumn(
                name: "Link",
                table: "Bookies");
        }
    }
}
