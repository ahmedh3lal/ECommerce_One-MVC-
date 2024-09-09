using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerce_One.Migrations
{
    /// <inheritdoc />
    public partial class installDb5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_products_CategoryID",
                table: "products",
                column: "CategoryID");

            migrationBuilder.AddForeignKey(
                name: "FK_products_categories_CategoryID",
                table: "products",
                column: "CategoryID",
                principalTable: "categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_products_categories_CategoryID",
                table: "products");

            migrationBuilder.DropIndex(
                name: "IX_products_CategoryID",
                table: "products");
        }
    }
}
