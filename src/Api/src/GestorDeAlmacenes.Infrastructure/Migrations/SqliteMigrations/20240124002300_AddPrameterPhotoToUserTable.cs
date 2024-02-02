using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestorDeAlmacenes.Infrastructure.Migrations.SqliteMigrations
{
    /// <inheritdoc />
    public partial class AddPrameterPhotoToUserTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Photos_Users_AuthID_User",
                table: "Photos");

            migrationBuilder.DropIndex(
                name: "IX_Photos_AuthID_User",
                table: "Photos");

            migrationBuilder.DropColumn(
                name: "AuthID_User",
                table: "Photos");

            migrationBuilder.AddColumn<string>(
                name: "Photo",
                table: "Users",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Photo",
                table: "Users");

            migrationBuilder.AddColumn<Guid>(
                name: "AuthID_User",
                table: "Photos",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Photos_AuthID_User",
                table: "Photos",
                column: "AuthID_User");

            migrationBuilder.AddForeignKey(
                name: "FK_Photos_Users_AuthID_User",
                table: "Photos",
                column: "AuthID_User",
                principalTable: "Users",
                principalColumn: "ID_User",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
