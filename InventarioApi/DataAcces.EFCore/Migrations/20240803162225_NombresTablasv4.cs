using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAcces.EFCore.Migrations
{
    /// <inheritdoc />
    public partial class NombresTablasv4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductStateId",
                table: "Products",
                column: "ProductStateId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProducStates_ProductStateId",
                table: "Products",
                column: "ProductStateId",
                principalTable: "ProducStates",
                principalColumn: "ProductStateId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProducStates_ProductStateId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_ProductStateId",
                table: "Products");
        }
    }
}
