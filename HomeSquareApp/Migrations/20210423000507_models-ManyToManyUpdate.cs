using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HomeSquareApp.Migrations
{
    public partial class modelsManyToManyUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_Category_CategoryID",
                table: "Product");

            migrationBuilder.AlterColumn<int>(
                name: "Week5PurchaseCount",
                table: "Product",
                nullable: false,
                oldClrType: typeof(int),
                oldDefaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "Week4PurchaseCount",
                table: "Product",
                nullable: false,
                oldClrType: typeof(int),
                oldDefaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "Week3PurchaseCount",
                table: "Product",
                nullable: false,
                oldClrType: typeof(int),
                oldDefaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "Week2PurchaseCount",
                table: "Product",
                nullable: false,
                oldClrType: typeof(int),
                oldDefaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "Week1PurchaseCount",
                table: "Product",
                nullable: false,
                oldClrType: typeof(int),
                oldDefaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "ReviewTwoStarsCount",
                table: "Product",
                nullable: false,
                oldClrType: typeof(int),
                oldDefaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "ReviewThreeStarsCount",
                table: "Product",
                nullable: false,
                oldClrType: typeof(int),
                oldDefaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "ReviewOneStarsCount",
                table: "Product",
                nullable: false,
                oldClrType: typeof(int),
                oldDefaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "ReviewFourStarsCount",
                table: "Product",
                nullable: false,
                oldClrType: typeof(int),
                oldDefaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "ReviewFiveStarsCount",
                table: "Product",
                nullable: false,
                oldClrType: typeof(int),
                oldDefaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "ProductStock",
                table: "Product",
                nullable: false,
                oldClrType: typeof(int),
                oldDefaultValue: 0);

            migrationBuilder.AlterColumn<float>(
                name: "ProductDiscount",
                table: "Product",
                nullable: false,
                oldClrType: typeof(float),
                oldDefaultValue: 0f);

            migrationBuilder.AlterColumn<int>(
                name: "CurrentWeekPurchaseCount",
                table: "Product",
                nullable: false,
                oldClrType: typeof(int),
                oldDefaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "CategoryID",
                table: "Product",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.CreateTable(
                name: "CategoriesProduct",
                columns: table => new
                {
                    CategoriesProductID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CategoryID = table.Column<int>(nullable: false),
                    ProductID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoriesProduct", x => x.CategoriesProductID);
                    table.ForeignKey(
                        name: "FK_CategoriesProduct_Category_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Category",
                        principalColumn: "CategoryID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoriesProduct_Product_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Product",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CategoriesProduct_CategoryID",
                table: "CategoriesProduct",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_CategoriesProduct_ProductID",
                table: "CategoriesProduct",
                column: "ProductID");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Category_CategoryID",
                table: "Product",
                column: "CategoryID",
                principalTable: "Category",
                principalColumn: "CategoryID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_Category_CategoryID",
                table: "Product");

            migrationBuilder.DropTable(
                name: "CategoriesProduct");

            migrationBuilder.AlterColumn<int>(
                name: "Week5PurchaseCount",
                table: "Product",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "Week4PurchaseCount",
                table: "Product",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "Week3PurchaseCount",
                table: "Product",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "Week2PurchaseCount",
                table: "Product",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "Week1PurchaseCount",
                table: "Product",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "ReviewTwoStarsCount",
                table: "Product",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "ReviewThreeStarsCount",
                table: "Product",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "ReviewOneStarsCount",
                table: "Product",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "ReviewFourStarsCount",
                table: "Product",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "ReviewFiveStarsCount",
                table: "Product",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "ProductStock",
                table: "Product",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<float>(
                name: "ProductDiscount",
                table: "Product",
                nullable: false,
                defaultValue: 0f,
                oldClrType: typeof(float));

            migrationBuilder.AlterColumn<int>(
                name: "CurrentWeekPurchaseCount",
                table: "Product",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "CategoryID",
                table: "Product",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Category_CategoryID",
                table: "Product",
                column: "CategoryID",
                principalTable: "Category",
                principalColumn: "CategoryID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
