using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestorDeAlmacenes.Infrastructure.Migrations.SqliteMigrations
{
    /// <inheritdoc />
    public partial class AddNotificacionTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Notificaciones",
                columns: table => new
                {
                    ID_Notificacion = table.Column<Guid>(type: "uuid", nullable: false),
                    ID_Usuario = table.Column<Guid>(type: "uuid", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Tipo = table.Column<string>(type: "text", nullable: false),
                    Cantidad = table.Column<int>(type: "integer", nullable: false),
                    Fecha = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notificaciones", x => x.ID_Notificacion);
                    table.ForeignKey(
                        name: "FK_Notificaciones_Users_ID_Usuario",
                        column: x => x.ID_Usuario,
                        principalTable: "Users",
                        principalColumn: "ID_User",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Notificaciones_ID_Usuario",
                table: "Notificaciones",
                column: "ID_Usuario");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Notificaciones");
        }
    }
}
