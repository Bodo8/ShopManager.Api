using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZarzadzanieCenami.Api.Migrations
{
    /// <inheritdoc />
    public partial class AddShopToProductNames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_product_shop_products_shop_products_id",
                table: "product_shop");

            migrationBuilder.DropForeignKey(
                name: "FK_product_shop_shops_shop_products_id1",
                table: "product_shop");

            migrationBuilder.RenameColumn(
                name: "shop_products_id1",
                table: "product_shop",
                newName: "shops_id");

            migrationBuilder.RenameColumn(
                name: "shop_products_id",
                table: "product_shop",
                newName: "products_id");

            migrationBuilder.RenameIndex(
                name: "IX_product_shop_shop_products_id1",
                table: "product_shop",
                newName: "IX_product_shop_shops_id");

            migrationBuilder.AddForeignKey(
                name: "FK_product_shop_products_products_id",
                table: "product_shop",
                column: "products_id",
                principalTable: "products",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_product_shop_shops_shops_id",
                table: "product_shop",
                column: "shops_id",
                principalTable: "shops",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_product_shop_products_products_id",
                table: "product_shop");

            migrationBuilder.DropForeignKey(
                name: "FK_product_shop_shops_shops_id",
                table: "product_shop");

            migrationBuilder.RenameColumn(
                name: "shops_id",
                table: "product_shop",
                newName: "shop_products_id1");

            migrationBuilder.RenameColumn(
                name: "products_id",
                table: "product_shop",
                newName: "shop_products_id");

            migrationBuilder.RenameIndex(
                name: "IX_product_shop_shops_id",
                table: "product_shop",
                newName: "IX_product_shop_shop_products_id1");

            migrationBuilder.AddForeignKey(
                name: "FK_product_shop_products_shop_products_id",
                table: "product_shop",
                column: "shop_products_id",
                principalTable: "products",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_product_shop_shops_shop_products_id1",
                table: "product_shop",
                column: "shop_products_id1",
                principalTable: "shops",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
