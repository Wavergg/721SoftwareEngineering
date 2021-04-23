using Microsoft.EntityFrameworkCore.Migrations;

namespace HomeSquareApp.Migrations
{
    public partial class modelsmanyToManyFixed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_Category_CategoryID",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Product_CategoryID",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "CategoryID",
                table: "Product");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryID",
                table: "Product",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Product_CategoryID",
                table: "Product",
                column: "CategoryID");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Category_CategoryID",
                table: "Product",
                column: "CategoryID",
                principalTable: "Category",
                principalColumn: "CategoryID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
