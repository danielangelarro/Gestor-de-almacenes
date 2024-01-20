using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestorDeAlmacenes.Infrastructure.Migrations.SqliteMigrations
{
    /// <inheritdoc />
    public partial class ConvertNullableParametersInMovimientosTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movimientos_Clientes_ID_Cliente",
                table: "Movimientos");

            migrationBuilder.DropForeignKey(
                name: "FK_Movimientos_Proveedores_ID_Proveedor",
                table: "Movimientos");

            migrationBuilder.AlterColumn<Guid>(
                name: "ID_Proveedor",
                table: "Movimientos",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<Guid>(
                name: "ID_Cliente",
                table: "Movimientos",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddForeignKey(
                name: "FK_Movimientos_Clientes_ID_Cliente",
                table: "Movimientos",
                column: "ID_Cliente",
                principalTable: "Clientes",
                principalColumn: "ID_Cliente");

            migrationBuilder.AddForeignKey(
                name: "FK_Movimientos_Proveedores_ID_Proveedor",
                table: "Movimientos",
                column: "ID_Proveedor",
                principalTable: "Proveedores",
                principalColumn: "ID_Proveedor");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movimientos_Clientes_ID_Cliente",
                table: "Movimientos");

            migrationBuilder.DropForeignKey(
                name: "FK_Movimientos_Proveedores_ID_Proveedor",
                table: "Movimientos");

            migrationBuilder.AlterColumn<Guid>(
                name: "ID_Proveedor",
                table: "Movimientos",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "ID_Cliente",
                table: "Movimientos",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Movimientos_Clientes_ID_Cliente",
                table: "Movimientos",
                column: "ID_Cliente",
                principalTable: "Clientes",
                principalColumn: "ID_Cliente",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Movimientos_Proveedores_ID_Proveedor",
                table: "Movimientos",
                column: "ID_Proveedor",
                principalTable: "Proveedores",
                principalColumn: "ID_Proveedor",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
