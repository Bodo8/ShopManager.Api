using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZarzadzanieCenami.Api.Migrations
{
    /// <inheritdoc />
    public partial class AddListDiscount : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_discounts_products_product_id",
                table: "discounts");

            migrationBuilder.DropForeignKey(
                name: "FK_discounts_shops_shop_id",
                table: "discounts");

            migrationBuilder.DropIndex(
                name: "IX_discounts_product_id",
                table: "discounts");

            migrationBuilder.DropIndex(
                name: "IX_discounts_shop_id",
                table: "discounts");

            migrationBuilder.DropColumn(
                name: "product_id",
                table: "discounts");

            migrationBuilder.DropColumn(
                name: "shop_id",
                table: "discounts");

            migrationBuilder.CreateTable(
                name: "discount_product",
                columns: table => new
                {
                    discounts_id = table.Column<int>(type: "integer", nullable: false),
                    products_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_discount_product", x => new { x.discounts_id, x.products_id });
                    table.ForeignKey(
                        name: "FK_discount_product_discounts_discounts_id",
                        column: x => x.discounts_id,
                        principalTable: "discounts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_discount_product_products_products_id",
                        column: x => x.products_id,
                        principalTable: "products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "discount_shop",
                columns: table => new
                {
                    discounts_id = table.Column<int>(type: "integer", nullable: false),
                    shops_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_discount_shop", x => new { x.discounts_id, x.shops_id });
                    table.ForeignKey(
                        name: "FK_discount_shop_discounts_discounts_id",
                        column: x => x.discounts_id,
                        principalTable: "discounts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_discount_shop_shops_shops_id",
                        column: x => x.shops_id,
                        principalTable: "shops",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_discount_product_products_id",
                table: "discount_product",
                column: "products_id");

            migrationBuilder.CreateIndex(
                name: "IX_discount_shop_shops_id",
                table: "discount_shop",
                column: "shops_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "discount_product");

            migrationBuilder.DropTable(
                name: "discount_shop");

            migrationBuilder.AddColumn<int>(
                name: "product_id",
                table: "discounts",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "shop_id",
                table: "discounts",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_discounts_product_id",
                table: "discounts",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "IX_discounts_shop_id",
                table: "discounts",
                column: "shop_id");

            migrationBuilder.AddForeignKey(
                name: "FK_discounts_products_product_id",
                table: "discounts",
                column: "product_id",
                principalTable: "products",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_discounts_shops_shop_id",
                table: "discounts",
                column: "shop_id",
                principalTable: "shops",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
