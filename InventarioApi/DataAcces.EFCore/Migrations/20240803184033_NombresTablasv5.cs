using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAcces.EFCore.Migrations
{
    /// <inheritdoc />
    public partial class NombresTablasv5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProducStates_ProductStateId",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProducStates",
                table: "ProducStates");

            migrationBuilder.RenameTable(
                name: "ProducStates",
                newName: "ProductStates");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductStates",
                table: "ProductStates",
                column: "ProductStateId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProductStates_ProductStateId",
                table: "Products",
                column: "ProductStateId",
                principalTable: "ProductStates",
                principalColumn: "ProductStateId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductStates_ProductStateId",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductStates",
                table: "ProductStates");

            migrationBuilder.RenameTable(
                name: "ProductStates",
                newName: "ProducStates");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProducStates",
                table: "ProducStates",
                column: "ProductStateId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProducStates_ProductStateId",
                table: "Products",
                column: "ProductStateId",
                principalTable: "ProducStates",
                principalColumn: "ProductStateId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
