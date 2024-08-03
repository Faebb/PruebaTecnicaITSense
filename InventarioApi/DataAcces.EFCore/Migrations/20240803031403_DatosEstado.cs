using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAcces.EFCore.Migrations
{
    /// <inheritdoc />
    public partial class DatosEstado : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO EstadoProductos (Nombre) VALUES ('Disponible'), ('Defectuoso'), ('Salido');");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
