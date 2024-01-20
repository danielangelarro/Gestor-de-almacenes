using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestorDeAlmacenes.Infrastructure.Migrations.SqliteMigrations
{
    /// <inheritdoc />
    public partial class AddMovimientosTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Movimientos",
                columns: table => new
                {
                    ID_Movimiento = table.Column<Guid>(type: "uuid", nullable: false),
                    ID_Producto = table.Column<Guid>(type: "uuid", nullable: false),
                    ID_Usuario = table.Column<Guid>(type: "uuid", nullable: false),
                    ID_Cliente = table.Column<Guid>(type: "uuid", nullable: true),
                    ID_Proveedor = table.Column<Guid>(type: "uuid", nullable: true),
                    Cantidad = table.Column<int>(type: "integer", nullable: false),
                    Fecha = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Tipo = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movimientos", x => x.ID_Movimiento);
                    table.ForeignKey(
                        name: "FK_Movimientos_Clientes_ID_Cliente",
                        column: x => x.ID_Cliente,
                        principalTable: "Clientes",
                        principalColumn: "ID_Cliente");
                    table.ForeignKey(
                        name: "FK_Movimientos_Productos_ID_Producto",
                        column: x => x.ID_Producto,
                        principalTable: "Productos",
                        principalColumn: "ID_Producto",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Movimientos_Proveedores_ID_Proveedor",
                        column: x => x.ID_Proveedor,
                        principalTable: "Proveedores",
                        principalColumn: "ID_Proveedor");
                    table.ForeignKey(
                        name: "FK_Movimientos_Users_ID_Usuario",
                        column: x => x.ID_Usuario,
                        principalTable: "Users",
                        principalColumn: "ID_User",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Movimientos_ID_Cliente",
                table: "Movimientos",
                column: "ID_Cliente");

            migrationBuilder.CreateIndex(
                name: "IX_Movimientos_ID_Producto",
                table: "Movimientos",
                column: "ID_Producto");

            migrationBuilder.CreateIndex(
                name: "IX_Movimientos_ID_Proveedor",
                table: "Movimientos",
                column: "ID_Proveedor");

            migrationBuilder.CreateIndex(
                name: "IX_Movimientos_ID_Usuario",
                table: "Movimientos",
                column: "ID_Usuario");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Movimientos");
        }
    }
}
