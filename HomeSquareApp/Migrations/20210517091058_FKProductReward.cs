using Microsoft.EntityFrameworkCore.Migrations;

namespace HomeSquareApp.Migrations
{
    public partial class FKProductReward : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Product_RewardPoolID",
                table: "Product");

            migrationBuilder.CreateIndex(
                name: "IX_RewardPool_ProductID",
                table: "RewardPool",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_Product_RewardPoolID",
                table: "Product",
                column: "RewardPoolID");

            migrationBuilder.AddForeignKey(
                name: "FK_RewardPool_Product_ProductID",
                table: "RewardPool",
                column: "ProductID",
                principalTable: "Product",
                principalColumn: "ProductID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RewardPool_Product_ProductID",
                table: "RewardPool");

            migrationBuilder.DropIndex(
                name: "IX_RewardPool_ProductID",
                table: "RewardPool");

            migrationBuilder.DropIndex(
                name: "IX_Product_RewardPoolID",
                table: "Product");

            migrationBuilder.CreateIndex(
                name: "IX_Product_RewardPoolID",
                table: "Product",
                column: "RewardPoolID",
                unique: true,
                filter: "[RewardPoolID] IS NOT NULL");
        }
    }
}
