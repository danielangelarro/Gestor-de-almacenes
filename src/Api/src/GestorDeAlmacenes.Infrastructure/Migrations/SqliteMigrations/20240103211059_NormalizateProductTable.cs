using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestorDeAlmacenes.Infrastructure.Migrations.SqliteMigrations
{
    /// <inheritdoc />
    public partial class NormalizateProductTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cantidad",
                table: "Productos");

            migrationBuilder.DropColumn(
                name: "Fecha_Caducidad",
                table: "Productos");

            migrationBuilder.DropColumn(
                name: "Fecha_Llegada",
                table: "Productos");

            migrationBuilder.AddColumn<DateTime>(
                name: "Fecha_Caducidad",
                table: "Ubicaciones",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Fecha_Llegada",
                table: "Ubicaciones",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Fecha_Caducidad",
                table: "Ubicaciones");

            migrationBuilder.DropColumn(
                name: "Fecha_Llegada",
                table: "Ubicaciones");

            migrationBuilder.AddColumn<int>(
                name: "Cantidad",
                table: "Productos",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "Fecha_Caducidad",
                table: "Productos",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Fecha_Llegada",
                table: "Productos",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
