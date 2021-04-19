using Microsoft.EntityFrameworkCore.Migrations;

namespace HomeSquareApp.Migrations
{
    public partial class extendIdentitybillingInfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Suburb",
                table: "AspNetUsers",
                maxLength: 16,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Unit",
                table: "AspNetUsers",
                maxLength: 8,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ZipCode",
                table: "AspNetUsers",
                maxLength: 8,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Suburb",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Unit",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ZipCode",
                table: "AspNetUsers");
        }
    }
}
