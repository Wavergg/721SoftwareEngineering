using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HomeSquareApp.Migrations
{
    public partial class changeRewardField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "RewardStatus",
                table: "Reward",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(8)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProductID",
                table: "Reward",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "RewardAddedDateTime",
                table: "Reward",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_Reward_ProductID",
                table: "Reward",
                column: "ProductID");

            migrationBuilder.AddForeignKey(
                name: "FK_Reward_Product_ProductID",
                table: "Reward",
                column: "ProductID",
                principalTable: "Product",
                principalColumn: "ProductID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reward_Product_ProductID",
                table: "Reward");

            migrationBuilder.DropIndex(
                name: "IX_Reward_ProductID",
                table: "Reward");

            migrationBuilder.DropColumn(
                name: "ProductID",
                table: "Reward");

            migrationBuilder.DropColumn(
                name: "RewardAddedDateTime",
                table: "Reward");

            migrationBuilder.AlterColumn<string>(
                name: "RewardStatus",
                table: "Reward",
                type: "varchar(8)",
                nullable: true,
                oldClrType: typeof(int));
        }
    }
}
