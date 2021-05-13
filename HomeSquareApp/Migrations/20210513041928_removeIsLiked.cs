using Microsoft.EntityFrameworkCore.Migrations;

namespace HomeSquareApp.Migrations
{
    public partial class removeIsLiked : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isRecipeLiked",
                table: "RecipeUserLike");

            migrationBuilder.AlterColumn<string>(
                name: "UserID",
                table: "RecipeUserLike",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserID",
                table: "RecipeUserLike",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<bool>(
                name: "isRecipeLiked",
                table: "RecipeUserLike",
                nullable: false,
                defaultValue: false);
        }
    }
}
