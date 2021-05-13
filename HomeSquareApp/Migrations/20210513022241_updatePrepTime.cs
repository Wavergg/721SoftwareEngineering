using Microsoft.EntityFrameworkCore.Migrations;

namespace HomeSquareApp.Migrations
{
    public partial class updatePrepTime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PrepareTimeDuration",
                table: "Recipe",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PrepareTimeMeasurement",
                table: "Recipe",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PrepareTimeDuration",
                table: "Recipe");

            migrationBuilder.DropColumn(
                name: "PrepareTimeMeasurement",
                table: "Recipe");
        }
    }
}
