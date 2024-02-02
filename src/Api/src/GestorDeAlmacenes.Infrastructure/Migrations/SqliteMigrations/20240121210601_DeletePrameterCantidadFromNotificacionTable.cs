using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestorDeAlmacenes.Infrastructure.Migrations.SqliteMigrations
{
    /// <inheritdoc />
    public partial class DeletePrameterCantidadFromNotificacionTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cantidad",
                table: "Notificaciones");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Cantidad",
                table: "Notificaciones",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
