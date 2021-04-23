using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HomeSquareApp.Migrations
{
    public partial class modelsRemoveManyToMany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategoriesProduct");

            migrationBuilder.AddColumn<int>(
                name: "CategoryID",
                table: "Product",
                nullable: false,
                defaultValue: 0);

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
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}
