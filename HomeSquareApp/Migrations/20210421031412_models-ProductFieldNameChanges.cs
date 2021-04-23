using Microsoft.EntityFrameworkCore.Migrations;

namespace HomeSquareApp.Migrations
{
    public partial class modelsProductFieldNameChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Week5Purchase",
                table: "Product",
                newName: "Week5PurchaseCount");

            migrationBuilder.RenameColumn(
                name: "Week4Purchase",
                table: "Product",
                newName: "Week4PurchaseCount");

            migrationBuilder.RenameColumn(
                name: "Week3Purchase",
                table: "Product",
                newName: "Week3PurchaseCount");

            migrationBuilder.RenameColumn(
                name: "Week2Purchase",
                table: "Product",
                newName: "Week2PurchaseCount");

            migrationBuilder.RenameColumn(
                name: "Week1Purchase",
                table: "Product",
                newName: "Week1PurchaseCount");

            migrationBuilder.RenameColumn(
                name: "ReviewTwoStars",
                table: "Product",
                newName: "ReviewTwoStarsCount");

            migrationBuilder.RenameColumn(
                name: "ReviewThreeStars",
                table: "Product",
                newName: "ReviewThreeStarsCount");

            migrationBuilder.RenameColumn(
                name: "ReviewOneStars",
                table: "Product",
                newName: "ReviewOneStarsCount");

            migrationBuilder.RenameColumn(
                name: "ReviewFourStars",
                table: "Product",
                newName: "ReviewFourStarsCount");

            migrationBuilder.RenameColumn(
                name: "ReviewFiveStars",
                table: "Product",
                newName: "ReviewFiveStarsCount");

            migrationBuilder.RenameColumn(
                name: "CurrentWeekPurchase",
                table: "Product",
                newName: "CurrentWeekPurchaseCount");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Week5PurchaseCount",
                table: "Product",
                newName: "Week5Purchase");

            migrationBuilder.RenameColumn(
                name: "Week4PurchaseCount",
                table: "Product",
                newName: "Week4Purchase");

            migrationBuilder.RenameColumn(
                name: "Week3PurchaseCount",
                table: "Product",
                newName: "Week3Purchase");

            migrationBuilder.RenameColumn(
                name: "Week2PurchaseCount",
                table: "Product",
                newName: "Week2Purchase");

            migrationBuilder.RenameColumn(
                name: "Week1PurchaseCount",
                table: "Product",
                newName: "Week1Purchase");

            migrationBuilder.RenameColumn(
                name: "ReviewTwoStarsCount",
                table: "Product",
                newName: "ReviewTwoStars");

            migrationBuilder.RenameColumn(
                name: "ReviewThreeStarsCount",
                table: "Product",
                newName: "ReviewThreeStars");

            migrationBuilder.RenameColumn(
                name: "ReviewOneStarsCount",
                table: "Product",
                newName: "ReviewOneStars");

            migrationBuilder.RenameColumn(
                name: "ReviewFourStarsCount",
                table: "Product",
                newName: "ReviewFourStars");

            migrationBuilder.RenameColumn(
                name: "ReviewFiveStarsCount",
                table: "Product",
                newName: "ReviewFiveStars");

            migrationBuilder.RenameColumn(
                name: "CurrentWeekPurchaseCount",
                table: "Product",
                newName: "CurrentWeekPurchase");
        }
    }
}
