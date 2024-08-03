using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAcces.EFCore.Migrations
{
    /// <inheritdoc />
    public partial class NombresTablasv2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProducStates_ProductStateNameProductStateId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_ProductStateNameProductStateId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ProductStateNameProductStateId",
                table: "Products");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProductStateNameProductStateId",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductStateNameProductStateId",
                table: "Products",
                column: "ProductStateNameProductStateId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProducStates_ProductStateNameProductStateId",
                table: "Products",
                column: "ProductStateNameProductStateId",
                principalTable: "ProducStates",
                principalColumn: "ProductStateId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
