using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HomeSquareApp.Migrations
{
    public partial class recipeChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recipe_RecipeApprovalStatus_RecipeApprovalStatusID",
                table: "Recipe");

            migrationBuilder.DropTable(
                name: "RecipeApprovalStatus");

            migrationBuilder.DropIndex(
                name: "IX_Recipe_RecipeApprovalStatusID",
                table: "Recipe");

            migrationBuilder.DropColumn(
                name: "RecipeApprovalStatusID",
                table: "Recipe");

            migrationBuilder.AddColumn<DateTime>(
                name: "AddedDate",
                table: "Recipe",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Recipe",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RecipeApprovalStatus",
                table: "Recipe",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AddedDate",
                table: "Recipe");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Recipe");

            migrationBuilder.DropColumn(
                name: "RecipeApprovalStatus",
                table: "Recipe");

            migrationBuilder.AddColumn<int>(
                name: "RecipeApprovalStatusID",
                table: "Recipe",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "RecipeApprovalStatus",
                columns: table => new
                {
                    RecipeApprovalStatusID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ApprovalStatus = table.Column<string>(maxLength: 12, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeApprovalStatus", x => x.RecipeApprovalStatusID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Recipe_RecipeApprovalStatusID",
                table: "Recipe",
                column: "RecipeApprovalStatusID");

            migrationBuilder.AddForeignKey(
                name: "FK_Recipe_RecipeApprovalStatus_RecipeApprovalStatusID",
                table: "Recipe",
                column: "RecipeApprovalStatusID",
                principalTable: "RecipeApprovalStatus",
                principalColumn: "RecipeApprovalStatusID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
