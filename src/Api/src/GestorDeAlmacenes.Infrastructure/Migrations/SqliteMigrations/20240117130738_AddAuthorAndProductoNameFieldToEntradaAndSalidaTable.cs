using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestorDeAlmacenes.Infrastructure.Migrations.SqliteMigrations
{
    /// <inheritdoc />
    public partial class AddAuthorAndProductoNameFieldToEntradaAndSalidaTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Autor",
                table: "Salidas",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Producto_Name",
                table: "Salidas",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Autor",
                table: "Entradas",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Producto_Name",
                table: "Entradas",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Autor",
                table: "Salidas");

            migrationBuilder.DropColumn(
                name: "Producto_Name",
                table: "Salidas");

            migrationBuilder.DropColumn(
                name: "Autor",
                table: "Entradas");

            migrationBuilder.DropColumn(
                name: "Producto_Name",
                table: "Entradas");
        }
    }
}
