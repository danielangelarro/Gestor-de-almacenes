using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestorDeAlmacenes.Infrastructure.Migrations.SqliteMigrations
{
    /// <inheritdoc />
    public partial class AddPArametersInMovimientosTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Autorization",
                table: "Movimientos",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Producto_Name",
                table: "Movimientos",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Proveedor_Name",
                table: "Movimientos",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Autorization",
                table: "Movimientos");

            migrationBuilder.DropColumn(
                name: "Producto_Name",
                table: "Movimientos");

            migrationBuilder.DropColumn(
                name: "Proveedor_Name",
                table: "Movimientos");
        }
    }
}
