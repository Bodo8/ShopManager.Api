using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZarzadzanieCenami.Api.Migrations
{
    /// <inheritdoc />
    public partial class AddShopToProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "product_shop",
                columns: table => new
                {
                    shop_products_id = table.Column<int>(type: "integer", nullable: false),
                    shop_products_id1 = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_product_shop", x => new { x.shop_products_id, x.shop_products_id1 });
                    table.ForeignKey(
                        name: "FK_product_shop_products_shop_products_id",
                        column: x => x.shop_products_id,
                        principalTable: "products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_product_shop_shops_shop_products_id1",
                        column: x => x.shop_products_id1,
                        principalTable: "shops",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_product_shop_shop_products_id1",
                table: "product_shop",
                column: "shop_products_id1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "product_shop");
        }
    }
}
