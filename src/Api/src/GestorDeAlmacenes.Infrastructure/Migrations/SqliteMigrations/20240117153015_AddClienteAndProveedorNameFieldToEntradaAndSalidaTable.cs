using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestorDeAlmacenes.Infrastructure.Migrations.SqliteMigrations
{
    /// <inheritdoc />
    public partial class AddClienteAndProveedorNameFieldToEntradaAndSalidaTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Entradas_Users_ID_Usuario",
                table: "Entradas");

            migrationBuilder.DropForeignKey(
                name: "FK_Salidas_Users_ID_Usuario",
                table: "Salidas");

            migrationBuilder.AddColumn<string>(
                name: "Cliente_Name",
                table: "Salidas",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "UserID_User",
                table: "Salidas",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Proveedor_Name",
                table: "Entradas",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "UserID_User",
                table: "Entradas",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Salidas_UserID_User",
                table: "Salidas",
                column: "UserID_User");

            migrationBuilder.CreateIndex(
                name: "IX_Entradas_UserID_User",
                table: "Entradas",
                column: "UserID_User");

            migrationBuilder.AddForeignKey(
                name: "FK_Entradas_Proveedores_ID_Usuario",
                table: "Entradas",
                column: "ID_Usuario",
                principalTable: "Proveedores",
                principalColumn: "ID_Proveedor",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Entradas_Users_UserID_User",
                table: "Entradas",
                column: "UserID_User",
                principalTable: "Users",
                principalColumn: "ID_User");

            migrationBuilder.AddForeignKey(
                name: "FK_Salidas_Clientes_ID_Usuario",
                table: "Salidas",
                column: "ID_Usuario",
                principalTable: "Clientes",
                principalColumn: "ID_Cliente",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Salidas_Users_UserID_User",
                table: "Salidas",
                column: "UserID_User",
                principalTable: "Users",
                principalColumn: "ID_User");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Entradas_Proveedores_ID_Usuario",
                table: "Entradas");

            migrationBuilder.DropForeignKey(
                name: "FK_Entradas_Users_UserID_User",
                table: "Entradas");

            migrationBuilder.DropForeignKey(
                name: "FK_Salidas_Clientes_ID_Usuario",
                table: "Salidas");

            migrationBuilder.DropForeignKey(
                name: "FK_Salidas_Users_UserID_User",
                table: "Salidas");

            migrationBuilder.DropIndex(
                name: "IX_Salidas_UserID_User",
                table: "Salidas");

            migrationBuilder.DropIndex(
                name: "IX_Entradas_UserID_User",
                table: "Entradas");

            migrationBuilder.DropColumn(
                name: "Cliente_Name",
                table: "Salidas");

            migrationBuilder.DropColumn(
                name: "UserID_User",
                table: "Salidas");

            migrationBuilder.DropColumn(
                name: "Proveedor_Name",
                table: "Entradas");

            migrationBuilder.DropColumn(
                name: "UserID_User",
                table: "Entradas");

            migrationBuilder.AddForeignKey(
                name: "FK_Entradas_Users_ID_Usuario",
                table: "Entradas",
                column: "ID_Usuario",
                principalTable: "Users",
                principalColumn: "ID_User",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Salidas_Users_ID_Usuario",
                table: "Salidas",
                column: "ID_Usuario",
                principalTable: "Users",
                principalColumn: "ID_User",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
