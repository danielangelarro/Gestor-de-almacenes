using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestorDeAlmacenes.Infrastructure.Migrations.SqliteMigrations
{
    /// <inheritdoc />
    public partial class AddParametersUbicacionSalidaTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ubicacion_Salidas",
                columns: table => new
                {
                    ID_Ubicacion_Salida = table.Column<Guid>(type: "uuid", nullable: false),
                    ID_Ubicacion = table.Column<Guid>(type: "uuid", nullable: false),
                    ID_Salida = table.Column<Guid>(type: "uuid", nullable: false),
                    Pasillo = table.Column<string>(type: "text", nullable: false),
                    Indice_Casillero = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ubicacion_Salidas", x => x.ID_Ubicacion_Salida);
                    table.ForeignKey(
                        name: "FK_Ubicacion_Salidas_Movimientos_ID_Salida",
                        column: x => x.ID_Salida,
                        principalTable: "Movimientos",
                        principalColumn: "ID_Movimiento",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ubicacion_Salidas_Ubicaciones_ID_Ubicacion",
                        column: x => x.ID_Ubicacion,
                        principalTable: "Ubicaciones",
                        principalColumn: "ID_Ubicacion",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ubicacion_Salidas_ID_Salida",
                table: "Ubicacion_Salidas",
                column: "ID_Salida");

            migrationBuilder.CreateIndex(
                name: "IX_Ubicacion_Salidas_ID_Ubicacion",
                table: "Ubicacion_Salidas",
                column: "ID_Ubicacion");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ubicacion_Salidas");
        }
    }
}
