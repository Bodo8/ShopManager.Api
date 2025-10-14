
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZarzadzanieCenami.Api.Migrations
{
    /// <inheritdoc />
    public partial class AddExpirationDateDiscount : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "expiration_date",
                table: "discounts",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2025, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "expiration_date",
                table: "discounts");
        }
    }
}
