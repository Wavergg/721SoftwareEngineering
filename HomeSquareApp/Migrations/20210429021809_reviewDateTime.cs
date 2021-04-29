using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HomeSquareApp.Migrations
{
    public partial class reviewDateTime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "ReviewDateTime",
                table: "Review",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReviewDateTime",
                table: "Review");
        }
    }
}
