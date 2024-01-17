using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestorDeAlmacenes.Infrastructure.Migrations.SqliteMigrations
{
    /// <inheritdoc />
    public partial class AddDimensionsFieldsToRackTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Columnas",
                table: "Racks",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Filas",
                table: "Racks",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Columnas",
                table: "Racks");

            migrationBuilder.DropColumn(
                name: "Filas",
                table: "Racks");
        }
    }
}
