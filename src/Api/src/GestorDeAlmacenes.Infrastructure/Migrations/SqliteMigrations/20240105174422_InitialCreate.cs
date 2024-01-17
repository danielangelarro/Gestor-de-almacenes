using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestorDeAlmacenes.Infrastructure.Migrations.SqliteMigrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    ID_Cliente = table.Column<Guid>(type: "uuid", nullable: false),
                    Nombres = table.Column<string>(type: "text", nullable: true),
                    Apellidos = table.Column<string>(type: "text", nullable: true),
                    CI = table.Column<string>(type: "text", nullable: true),
                    Telefono = table.Column<string>(type: "text", nullable: true),
                    Correo = table.Column<string>(type: "text", nullable: true),
                    Direccion = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.ID_Cliente);
                });

            migrationBuilder.CreateTable(
                name: "Productos",
                columns: table => new
                {
                    ID_Producto = table.Column<Guid>(type: "uuid", nullable: false),
                    Nombre = table.Column<string>(type: "text", nullable: false),
                    Descripcion = table.Column<string>(type: "text", nullable: false),
                    Tipo = table.Column<string>(type: "text", nullable: false),
                    Alto = table.Column<float>(type: "real", nullable: false),
                    Ancho = table.Column<float>(type: "real", nullable: false),
                    Largo = table.Column<float>(type: "real", nullable: false),
                    Unidad_Dimensiones = table.Column<string>(type: "text", nullable: false),
                    Peso = table.Column<float>(type: "real", nullable: false),
                    EnAlmacen = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productos", x => x.ID_Producto);
                });

            migrationBuilder.CreateTable(
                name: "Proveedores",
                columns: table => new
                {
                    ID_Proveedor = table.Column<Guid>(type: "uuid", nullable: false),
                    Nombres = table.Column<string>(type: "text", nullable: true),
                    Apellidos = table.Column<string>(type: "text", nullable: true),
                    CI = table.Column<string>(type: "text", nullable: true),
                    Telefono = table.Column<string>(type: "text", nullable: true),
                    Correo = table.Column<string>(type: "text", nullable: true),
                    Direccion = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proveedores", x => x.ID_Proveedor);
                });

            migrationBuilder.CreateTable(
                name: "Racks",
                columns: table => new
                {
                    ID_Rack = table.Column<Guid>(type: "uuid", nullable: false),
                    Pasillo = table.Column<string>(type: "text", nullable: false),
                    Cantidad_Casillas = table.Column<int>(type: "integer", nullable: false),
                    Peso_Maximo = table.Column<float>(type: "real", nullable: false),
                    Alto = table.Column<float>(type: "real", nullable: false),
                    Ancho = table.Column<float>(type: "real", nullable: false),
                    Largo = table.Column<float>(type: "real", nullable: false),
                    Unidad_Dimensiones = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Racks", x => x.ID_Rack);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    ID_User = table.Column<Guid>(type: "uuid", nullable: false),
                    Nombres = table.Column<string>(type: "text", nullable: true),
                    Apellidos = table.Column<string>(type: "text", nullable: true),
                    Correo = table.Column<string>(type: "text", nullable: true),
                    Password = table.Column<string>(type: "text", nullable: true),
                    Rol = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.ID_User);
                });

            migrationBuilder.CreateTable(
                name: "Mermas",
                columns: table => new
                {
                    ID_Merma = table.Column<Guid>(type: "uuid", nullable: false),
                    ID_Producto = table.Column<Guid>(type: "uuid", nullable: false),
                    Cantidad = table.Column<int>(type: "integer", nullable: false),
                    Fecha_Caducidad = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mermas", x => x.ID_Merma);
                    table.ForeignKey(
                        name: "FK_Mermas_Productos_ID_Producto",
                        column: x => x.ID_Producto,
                        principalTable: "Productos",
                        principalColumn: "ID_Producto",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Casilleros",
                columns: table => new
                {
                    ID_Casillero = table.Column<Guid>(type: "uuid", nullable: false),
                    ID_Rack = table.Column<Guid>(type: "uuid", nullable: false),
                    Area = table.Column<float>(type: "real", nullable: false),
                    Peso_Maximo = table.Column<float>(type: "real", nullable: false),
                    Alto = table.Column<float>(type: "real", nullable: false),
                    Ancho = table.Column<float>(type: "real", nullable: false),
                    Largo = table.Column<float>(type: "real", nullable: false),
                    Unidad_Dimensiones = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Casilleros", x => x.ID_Casillero);
                    table.ForeignKey(
                        name: "FK_Casilleros_Racks_ID_Rack",
                        column: x => x.ID_Rack,
                        principalTable: "Racks",
                        principalColumn: "ID_Rack",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Entradas",
                columns: table => new
                {
                    ID_Entrada = table.Column<Guid>(type: "uuid", nullable: false),
                    ID_Producto = table.Column<Guid>(type: "uuid", nullable: false),
                    ID_Usuario = table.Column<Guid>(type: "uuid", nullable: false),
                    Cantidad = table.Column<int>(type: "integer", nullable: false),
                    Fecha = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entradas", x => new { x.ID_Entrada, x.ID_Producto, x.ID_Usuario });
                    table.ForeignKey(
                        name: "FK_Entradas_Productos_ID_Producto",
                        column: x => x.ID_Producto,
                        principalTable: "Productos",
                        principalColumn: "ID_Producto",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Entradas_Users_ID_Usuario",
                        column: x => x.ID_Usuario,
                        principalTable: "Users",
                        principalColumn: "ID_User",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Photos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FileDescription = table.Column<string>(type: "text", nullable: false),
                    FileName = table.Column<string>(type: "text", nullable: false),
                    Contenido = table.Column<byte[]>(type: "bytea", nullable: false),
                    AuthID_User = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Photos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Photos_Users_AuthID_User",
                        column: x => x.AuthID_User,
                        principalTable: "Users",
                        principalColumn: "ID_User",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Salidas",
                columns: table => new
                {
                    ID_Salida = table.Column<Guid>(type: "uuid", nullable: false),
                    ID_Producto = table.Column<Guid>(type: "uuid", nullable: false),
                    ID_Usuario = table.Column<Guid>(type: "uuid", nullable: false),
                    Cantidad = table.Column<int>(type: "integer", nullable: false),
                    Fecha = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Salidas", x => new { x.ID_Salida, x.ID_Producto, x.ID_Usuario });
                    table.ForeignKey(
                        name: "FK_Salidas_Productos_ID_Producto",
                        column: x => x.ID_Producto,
                        principalTable: "Productos",
                        principalColumn: "ID_Producto",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Salidas_Users_ID_Usuario",
                        column: x => x.ID_Usuario,
                        principalTable: "Users",
                        principalColumn: "ID_User",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ubicaciones",
                columns: table => new
                {
                    ID_Producto = table.Column<Guid>(type: "uuid", nullable: false),
                    ID_Casillero = table.Column<Guid>(type: "uuid", nullable: false),
                    Cantidad = table.Column<int>(type: "integer", nullable: false),
                    Fecha_Llegada = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Fecha_Caducidad = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ubicaciones", x => new { x.ID_Producto, x.ID_Casillero });
                    table.ForeignKey(
                        name: "FK_Ubicaciones_Casilleros_ID_Casillero",
                        column: x => x.ID_Casillero,
                        principalTable: "Casilleros",
                        principalColumn: "ID_Casillero",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ubicaciones_Productos_ID_Producto",
                        column: x => x.ID_Producto,
                        principalTable: "Productos",
                        principalColumn: "ID_Producto",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Casilleros_ID_Rack",
                table: "Casilleros",
                column: "ID_Rack");

            migrationBuilder.CreateIndex(
                name: "IX_Entradas_ID_Producto",
                table: "Entradas",
                column: "ID_Producto");

            migrationBuilder.CreateIndex(
                name: "IX_Entradas_ID_Usuario",
                table: "Entradas",
                column: "ID_Usuario");

            migrationBuilder.CreateIndex(
                name: "IX_Mermas_ID_Producto",
                table: "Mermas",
                column: "ID_Producto");

            migrationBuilder.CreateIndex(
                name: "IX_Photos_AuthID_User",
                table: "Photos",
                column: "AuthID_User");

            migrationBuilder.CreateIndex(
                name: "IX_Salidas_ID_Producto",
                table: "Salidas",
                column: "ID_Producto");

            migrationBuilder.CreateIndex(
                name: "IX_Salidas_ID_Usuario",
                table: "Salidas",
                column: "ID_Usuario");

            migrationBuilder.CreateIndex(
                name: "IX_Ubicaciones_ID_Casillero",
                table: "Ubicaciones",
                column: "ID_Casillero");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Entradas");

            migrationBuilder.DropTable(
                name: "Mermas");

            migrationBuilder.DropTable(
                name: "Photos");

            migrationBuilder.DropTable(
                name: "Proveedores");

            migrationBuilder.DropTable(
                name: "Salidas");

            migrationBuilder.DropTable(
                name: "Ubicaciones");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Casilleros");

            migrationBuilder.DropTable(
                name: "Productos");

            migrationBuilder.DropTable(
                name: "Racks");
        }
    }
}
