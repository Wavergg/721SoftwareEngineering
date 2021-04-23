using Microsoft.EntityFrameworkCore.Migrations;

namespace HomeSquareApp.Migrations
{
    public partial class changeProductAddDateToUpdateDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProductAddedDate",
                table: "Product",
                newName: "ProductUpdateDate");

            migrationBuilder.AlterColumn<int>(
                name: "ProductStock",
                table: "Product",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<float>(
                name: "ProductDiscount",
                table: "Product",
                nullable: true,
                oldClrType: typeof(float));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProductUpdateDate",
                table: "Product",
                newName: "ProductAddedDate");

            migrationBuilder.AlterColumn<int>(
                name: "ProductStock",
                table: "Product",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<float>(
                name: "ProductDiscount",
                table: "Product",
                nullable: false,
                oldClrType: typeof(float),
                oldNullable: true);
        }
    }
}
