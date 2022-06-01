﻿// <auto-generated />
using System;
using ApiRest.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ApiRest.Migrations
{
    [DbContext(typeof(MyDbContext))]
    [Migration("20220529100447_mesa_location")]
    partial class mesa_location
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseCollation("utf8mb4_general_ci")
                .HasAnnotation("MySql:CharSet", "utf8mb4")
                .HasAnnotation("ProductVersion", "6.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ApiRest.Entities.Categoria", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("nombre");

                    b.HasKey("Id");

                    b.ToTable("Categoria", (string)null);
                });

            modelBuilder.Entity("ApiRest.Entities.Comanda", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<string>("Descripcion")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("descripcion");

                    b.Property<int>("Estado")
                        .HasColumnType("int")
                        .HasColumnName("estado");

                    b.Property<long>("IdCamarero")
                        .HasColumnType("bigint")
                        .HasColumnName("id_camarero");

                    b.Property<long?>("IdCocinero")
                        .HasColumnType("bigint")
                        .HasColumnName("id_cocinero");

                    b.Property<long>("IdPedido")
                        .HasColumnType("bigint")
                        .HasColumnName("id_pedido");

                    b.Property<long>("IdProducto")
                        .HasColumnType("bigint")
                        .HasColumnName("id_producto");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "IdCamarero" }, "fk_camarerocomanda");

                    b.HasIndex(new[] { "IdCocinero" }, "fk_cocinerocomanda");

                    b.HasIndex(new[] { "IdPedido" }, "fk_pedidocomanda");

                    b.HasIndex(new[] { "IdProducto" }, "fk_productocomanda");

                    b.ToTable("Comanda", (string)null);
                });

            modelBuilder.Entity("ApiRest.Entities.Mesa", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<int>("Estado")
                        .HasColumnType("int")
                        .HasColumnName("estado");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("location");

                    b.HasKey("Id");

                    b.ToTable("mesa");
                });

            modelBuilder.Entity("ApiRest.Entities.Pedido", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<int>("Estado")
                        .HasColumnType("int")
                        .HasColumnName("estado");

                    b.Property<DateTime?>("Fecha")
                        .HasColumnType("datetime")
                        .HasColumnName("fecha");

                    b.Property<long?>("IdCamarero")
                        .HasColumnType("bigint")
                        .HasColumnName("id_camarero");

                    b.Property<long>("IdMesa")
                        .HasColumnType("bigint")
                        .HasColumnName("id_mesa");

                    b.Property<decimal>("PrecioTotal")
                        .HasPrecision(5, 2)
                        .HasColumnType("decimal(5,2)")
                        .HasColumnName("precio_total");

                    b.HasKey("Id");

                    b.HasIndex("IdCamarero");

                    b.HasIndex(new[] { "IdMesa" }, "fk_idmesa");

                    b.ToTable("Pedido", (string)null);
                });

            modelBuilder.Entity("ApiRest.Entities.Producto", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<long>("IdCat")
                        .HasColumnType("bigint")
                        .HasColumnName("id_cat");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("nombre");

                    b.Property<decimal>("Precio")
                        .HasPrecision(4, 2)
                        .HasColumnType("decimal(4,2)")
                        .HasColumnName("precio");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "IdCat" }, "fk_catProd");

                    b.ToTable("Producto", (string)null);
                });

            modelBuilder.Entity("ApiRest.Entities.Reserva", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<int>("CantidadPersonas")
                        .HasColumnType("int")
                        .HasColumnName("cantidad_personas");

                    b.Property<DateTime>("HoraFecha")
                        .HasColumnType("datetime")
                        .HasColumnName("hora_fecha");

                    b.Property<string>("NombreCliente")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("nombre_Cliente");

                    b.Property<int>("Telefono")
                        .HasColumnType("int")
                        .HasColumnName("telefono");

                    b.HasKey("Id");

                    b.ToTable("Reserva", (string)null);
                });

            modelBuilder.Entity("ApiRest.Entities.Usuario", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<string>("Apellidos")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("apellidos");

                    b.Property<string>("Nombre")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("nombre");

                    b.Property<string>("Nss")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("NSS");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasColumnName("password");

                    b.Property<string>("Rol")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasColumnName("rol");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("username");

                    b.HasKey("Id");

                    b.HasAlternateKey("Username");

                    b.HasIndex(new[] { "Username" }, "username")
                        .IsUnique();

                    b.ToTable("Usuario", (string)null);
                });

            modelBuilder.Entity("MesaReserva", b =>
                {
                    b.Property<long>("IdMesa")
                        .HasColumnType("bigint");

                    b.Property<long>("IdReserva")
                        .HasColumnType("bigint");

                    b.HasKey("IdMesa", "IdReserva");

                    b.HasIndex("IdReserva");

                    b.ToTable("MesaReserva");
                });

            modelBuilder.Entity("ApiRest.Entities.Camarero", b =>
                {
                    b.HasBaseType("ApiRest.Entities.Usuario");

                    b.ToTable("Camarero", (string)null);
                });

            modelBuilder.Entity("ApiRest.Entities.Cocinero", b =>
                {
                    b.HasBaseType("ApiRest.Entities.Usuario");

                    b.ToTable("Cocinero", (string)null);
                });

            modelBuilder.Entity("ApiRest.Entities.Gerente", b =>
                {
                    b.HasBaseType("ApiRest.Entities.Usuario");

                    b.ToTable("Gerente", (string)null);
                });

            modelBuilder.Entity("ApiRest.Entities.Comanda", b =>
                {
                    b.HasOne("ApiRest.Entities.Camarero", "IdCamareroNavigation")
                        .WithMany("Comanda")
                        .HasForeignKey("IdCamarero")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ApiRest.Entities.Cocinero", "IdCocineroNavigation")
                        .WithMany("Comanda")
                        .HasForeignKey("IdCocinero");

                    b.HasOne("ApiRest.Entities.Pedido", "IdPedidoNavigation")
                        .WithMany("Comanda")
                        .HasForeignKey("IdPedido")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ApiRest.Entities.Producto", "IdProductoNavigation")
                        .WithMany("Comanda")
                        .HasForeignKey("IdProducto")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("IdCamareroNavigation");

                    b.Navigation("IdCocineroNavigation");

                    b.Navigation("IdPedidoNavigation");

                    b.Navigation("IdProductoNavigation");
                });

            modelBuilder.Entity("ApiRest.Entities.Pedido", b =>
                {
                    b.HasOne("ApiRest.Entities.Camarero", "IdCamareroNavigation")
                        .WithMany("Pedidos")
                        .HasForeignKey("IdCamarero");

                    b.HasOne("ApiRest.Entities.Mesa", "IdMesaNavigation")
                        .WithMany("Pedidos")
                        .HasForeignKey("IdMesa")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("IdCamareroNavigation");

                    b.Navigation("IdMesaNavigation");
                });

            modelBuilder.Entity("ApiRest.Entities.Producto", b =>
                {
                    b.HasOne("ApiRest.Entities.Categoria", "IdCatNavigation")
                        .WithMany("Productos")
                        .HasForeignKey("IdCat")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("IdCatNavigation");
                });

            modelBuilder.Entity("MesaReserva", b =>
                {
                    b.HasOne("ApiRest.Entities.Mesa", null)
                        .WithMany()
                        .HasForeignKey("IdMesa")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ApiRest.Entities.Reserva", null)
                        .WithMany()
                        .HasForeignKey("IdReserva")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ApiRest.Entities.Camarero", b =>
                {
                    b.HasOne("ApiRest.Entities.Usuario", null)
                        .WithOne()
                        .HasForeignKey("ApiRest.Entities.Camarero", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ApiRest.Entities.Cocinero", b =>
                {
                    b.HasOne("ApiRest.Entities.Usuario", null)
                        .WithOne()
                        .HasForeignKey("ApiRest.Entities.Cocinero", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ApiRest.Entities.Gerente", b =>
                {
                    b.HasOne("ApiRest.Entities.Usuario", null)
                        .WithOne()
                        .HasForeignKey("ApiRest.Entities.Gerente", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ApiRest.Entities.Categoria", b =>
                {
                    b.Navigation("Productos");
                });

            modelBuilder.Entity("ApiRest.Entities.Mesa", b =>
                {
                    b.Navigation("Pedidos");
                });

            modelBuilder.Entity("ApiRest.Entities.Pedido", b =>
                {
                    b.Navigation("Comanda");
                });

            modelBuilder.Entity("ApiRest.Entities.Producto", b =>
                {
                    b.Navigation("Comanda");
                });

            modelBuilder.Entity("ApiRest.Entities.Camarero", b =>
                {
                    b.Navigation("Comanda");

                    b.Navigation("Pedidos");
                });

            modelBuilder.Entity("ApiRest.Entities.Cocinero", b =>
                {
                    b.Navigation("Comanda");
                });
#pragma warning restore 612, 618
        }
    }
}
