﻿// <auto-generated />
using System;
using GestorDeAlmacenes.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace GestorDeAlmacenes.Infrastructure.Migrations.SqliteMigrations
{
    [DbContext(typeof(GestorDeAlmacenesDBContext))]
    [Migration("20240117130738_AddAuthorAndProductoNameFieldToEntradaAndSalidaTable")]
    partial class AddAuthorAndProductoNameFieldToEntradaAndSalidaTable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("GestorDeAlmacenes.Application.Entities.Casillero", b =>
                {
                    b.Property<Guid>("ID_Casillero")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<float>("Alto")
                        .HasColumnType("real");

                    b.Property<float>("Ancho")
                        .HasColumnType("real");

                    b.Property<float>("Area")
                        .HasColumnType("real");

                    b.Property<Guid>("ID_Rack")
                        .HasColumnType("uuid");

                    b.Property<long>("Index")
                        .HasColumnType("bigint");

                    b.Property<float>("Largo")
                        .HasColumnType("real");

                    b.Property<float>("Peso_Maximo")
                        .HasColumnType("real");

                    b.Property<string>("Unidad_Dimensiones")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("ID_Casillero");

                    b.HasIndex("ID_Rack");

                    b.ToTable("Casilleros");
                });

            modelBuilder.Entity("GestorDeAlmacenes.Application.Entities.Cliente", b =>
                {
                    b.Property<Guid>("ID_Cliente")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Apellidos")
                        .HasColumnType("text");

                    b.Property<string>("CI")
                        .HasColumnType("text");

                    b.Property<string>("Correo")
                        .HasColumnType("text");

                    b.Property<string>("Direccion")
                        .HasColumnType("text");

                    b.Property<string>("Nombres")
                        .HasColumnType("text");

                    b.Property<string>("Telefono")
                        .HasColumnType("text");

                    b.HasKey("ID_Cliente");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("GestorDeAlmacenes.Application.Entities.Entrada", b =>
                {
                    b.Property<Guid>("ID_Entrada")
                        .HasColumnType("uuid");

                    b.Property<Guid>("ID_Producto")
                        .HasColumnType("uuid");

                    b.Property<Guid>("ID_Usuario")
                        .HasColumnType("uuid");

                    b.Property<string>("Autor")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Cantidad")
                        .HasColumnType("integer");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Producto_Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("ID_Entrada", "ID_Producto", "ID_Usuario");

                    b.HasIndex("ID_Producto");

                    b.HasIndex("ID_Usuario");

                    b.ToTable("Entradas");
                });

            modelBuilder.Entity("GestorDeAlmacenes.Application.Entities.Merma", b =>
                {
                    b.Property<Guid>("ID_Merma")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("Cantidad")
                        .HasColumnType("integer");

                    b.Property<DateTime>("Fecha_Caducidad")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("ID_Producto")
                        .HasColumnType("uuid");

                    b.HasKey("ID_Merma");

                    b.HasIndex("ID_Producto");

                    b.ToTable("Mermas");
                });

            modelBuilder.Entity("GestorDeAlmacenes.Application.Entities.Photo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("AuthID_User")
                        .HasColumnType("uuid");

                    b.Property<byte[]>("Contenido")
                        .IsRequired()
                        .HasColumnType("bytea");

                    b.Property<string>("FileDescription")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("AuthID_User");

                    b.ToTable("Photos");
                });

            modelBuilder.Entity("GestorDeAlmacenes.Application.Entities.Producto", b =>
                {
                    b.Property<Guid>("ID_Producto")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<float>("Alto")
                        .HasColumnType("real");

                    b.Property<float>("Ancho")
                        .HasColumnType("real");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("EnAlmacen")
                        .HasColumnType("boolean");

                    b.Property<float>("Largo")
                        .HasColumnType("real");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<float>("Peso")
                        .HasColumnType("real");

                    b.Property<string>("Tipo")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Unidad_Dimensiones")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("ID_Producto");

                    b.ToTable("Productos");
                });

            modelBuilder.Entity("GestorDeAlmacenes.Application.Entities.Proveedor", b =>
                {
                    b.Property<Guid>("ID_Proveedor")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Apellidos")
                        .HasColumnType("text");

                    b.Property<string>("CI")
                        .HasColumnType("text");

                    b.Property<string>("Correo")
                        .HasColumnType("text");

                    b.Property<string>("Direccion")
                        .HasColumnType("text");

                    b.Property<string>("Nombres")
                        .HasColumnType("text");

                    b.Property<string>("Telefono")
                        .HasColumnType("text");

                    b.HasKey("ID_Proveedor");

                    b.ToTable("Proveedores");
                });

            modelBuilder.Entity("GestorDeAlmacenes.Application.Entities.Rack", b =>
                {
                    b.Property<Guid>("ID_Rack")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<float>("Alto")
                        .HasColumnType("real");

                    b.Property<float>("Ancho")
                        .HasColumnType("real");

                    b.Property<int>("Cantidad_Casillas")
                        .HasColumnType("integer");

                    b.Property<int>("Columnas")
                        .HasColumnType("integer");

                    b.Property<int>("Filas")
                        .HasColumnType("integer");

                    b.Property<float>("Largo")
                        .HasColumnType("real");

                    b.Property<string>("Pasillo")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<float>("Peso_Maximo")
                        .HasColumnType("real");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Unidad_Dimensiones")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("ID_Rack");

                    b.ToTable("Racks");
                });

            modelBuilder.Entity("GestorDeAlmacenes.Application.Entities.Salida", b =>
                {
                    b.Property<Guid>("ID_Salida")
                        .HasColumnType("uuid");

                    b.Property<Guid>("ID_Producto")
                        .HasColumnType("uuid");

                    b.Property<Guid>("ID_Usuario")
                        .HasColumnType("uuid");

                    b.Property<string>("Autor")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Cantidad")
                        .HasColumnType("integer");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Producto_Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("ID_Salida", "ID_Producto", "ID_Usuario");

                    b.HasIndex("ID_Producto");

                    b.HasIndex("ID_Usuario");

                    b.ToTable("Salidas");
                });

            modelBuilder.Entity("GestorDeAlmacenes.Application.Entities.Ubicacion", b =>
                {
                    b.Property<Guid>("ID_Producto")
                        .HasColumnType("uuid");

                    b.Property<Guid>("ID_Casillero")
                        .HasColumnType("uuid");

                    b.Property<int>("Cantidad")
                        .HasColumnType("integer");

                    b.Property<DateTime>("Fecha_Caducidad")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("Fecha_Llegada")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("ID_Producto", "ID_Casillero");

                    b.HasIndex("ID_Casillero");

                    b.ToTable("Ubicaciones");
                });

            modelBuilder.Entity("GestorDeAlmacenes.Application.Entities.User", b =>
                {
                    b.Property<Guid>("ID_User")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Apellidos")
                        .HasColumnType("text");

                    b.Property<string>("Correo")
                        .HasColumnType("text");

                    b.Property<string>("Nombres")
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .HasColumnType("text");

                    b.Property<string>("Rol")
                        .HasColumnType("text");

                    b.HasKey("ID_User");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("GestorDeAlmacenes.Application.Entities.Casillero", b =>
                {
                    b.HasOne("GestorDeAlmacenes.Application.Entities.Rack", "Rack")
                        .WithMany("Casilleros")
                        .HasForeignKey("ID_Rack")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Rack");
                });

            modelBuilder.Entity("GestorDeAlmacenes.Application.Entities.Entrada", b =>
                {
                    b.HasOne("GestorDeAlmacenes.Application.Entities.Producto", "Producto")
                        .WithMany("Entradas")
                        .HasForeignKey("ID_Producto")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GestorDeAlmacenes.Application.Entities.User", "Usuario")
                        .WithMany("Entradas")
                        .HasForeignKey("ID_Usuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Producto");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("GestorDeAlmacenes.Application.Entities.Merma", b =>
                {
                    b.HasOne("GestorDeAlmacenes.Application.Entities.Producto", "Producto")
                        .WithMany("Mermas")
                        .HasForeignKey("ID_Producto")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Producto");
                });

            modelBuilder.Entity("GestorDeAlmacenes.Application.Entities.Photo", b =>
                {
                    b.HasOne("GestorDeAlmacenes.Application.Entities.User", "Auth")
                        .WithMany()
                        .HasForeignKey("AuthID_User")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Auth");
                });

            modelBuilder.Entity("GestorDeAlmacenes.Application.Entities.Salida", b =>
                {
                    b.HasOne("GestorDeAlmacenes.Application.Entities.Producto", "Producto")
                        .WithMany("Salidas")
                        .HasForeignKey("ID_Producto")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GestorDeAlmacenes.Application.Entities.User", "Usuario")
                        .WithMany("Salidas")
                        .HasForeignKey("ID_Usuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Producto");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("GestorDeAlmacenes.Application.Entities.Ubicacion", b =>
                {
                    b.HasOne("GestorDeAlmacenes.Application.Entities.Casillero", "Casillero")
                        .WithMany("Ubicaciones")
                        .HasForeignKey("ID_Casillero")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GestorDeAlmacenes.Application.Entities.Producto", "Producto")
                        .WithMany("Ubicaciones")
                        .HasForeignKey("ID_Producto")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Casillero");

                    b.Navigation("Producto");
                });

            modelBuilder.Entity("GestorDeAlmacenes.Application.Entities.Casillero", b =>
                {
                    b.Navigation("Ubicaciones");
                });

            modelBuilder.Entity("GestorDeAlmacenes.Application.Entities.Producto", b =>
                {
                    b.Navigation("Entradas");

                    b.Navigation("Mermas");

                    b.Navigation("Salidas");

                    b.Navigation("Ubicaciones");
                });

            modelBuilder.Entity("GestorDeAlmacenes.Application.Entities.Rack", b =>
                {
                    b.Navigation("Casilleros");
                });

            modelBuilder.Entity("GestorDeAlmacenes.Application.Entities.User", b =>
                {
                    b.Navigation("Entradas");

                    b.Navigation("Salidas");
                });
#pragma warning restore 612, 618
        }
    }
}
