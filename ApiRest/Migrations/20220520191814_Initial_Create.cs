using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiRest.Migrations
{
    public partial class Initial_Create : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categoria",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categoria", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "mesa",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    estado = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mesa", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Reserva",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre_Cliente = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    telefono = table.Column<int>(type: "int", nullable: false),
                    cantidad_personas = table.Column<int>(type: "int", nullable: false),
                    hora_fecha = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reserva", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    apellidos = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    NSS = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    username = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    password = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    rol = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.id);
                    table.UniqueConstraint("AK_Usuario_username", x => x.username);
                });

            migrationBuilder.CreateTable(
                name: "Producto",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    precio = table.Column<decimal>(type: "decimal(4,2)", precision: 4, scale: 2, nullable: false),
                    id_cat = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Producto", x => x.id);
                    table.ForeignKey(
                        name: "FK_Producto_Categoria_id_cat",
                        column: x => x.id_cat,
                        principalTable: "Categoria",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pedido",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fecha = table.Column<DateTime>(type: "datetime", nullable: true),
                    precio_total = table.Column<decimal>(type: "decimal(5,2)", precision: 5, scale: 2, nullable: false),
                    estado = table.Column<int>(type: "int", nullable: false),
                    id_mesa = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedido", x => x.id);
                    table.ForeignKey(
                        name: "FK_Pedido_mesa_id_mesa",
                        column: x => x.id_mesa,
                        principalTable: "mesa",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MesaReserva",
                columns: table => new
                {
                    IdMesa = table.Column<long>(type: "bigint", nullable: false),
                    IdReserva = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MesaReserva", x => new { x.IdMesa, x.IdReserva });
                    table.ForeignKey(
                        name: "FK_MesaReserva_mesa_IdMesa",
                        column: x => x.IdMesa,
                        principalTable: "mesa",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MesaReserva_Reserva_IdReserva",
                        column: x => x.IdReserva,
                        principalTable: "Reserva",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Camarero",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Camarero", x => x.id);
                    table.ForeignKey(
                        name: "FK_Camarero_Usuario_id",
                        column: x => x.id,
                        principalTable: "Usuario",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Cocinero",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cocinero", x => x.id);
                    table.ForeignKey(
                        name: "FK_Cocinero_Usuario_id",
                        column: x => x.id,
                        principalTable: "Usuario",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Gerente",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gerente", x => x.id);
                    table.ForeignKey(
                        name: "FK_Gerente_Usuario_id",
                        column: x => x.id,
                        principalTable: "Usuario",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Comanda",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_camarero = table.Column<long>(type: "bigint", nullable: false),
                    id_cocinero = table.Column<long>(type: "bigint", nullable: true),
                    id_producto = table.Column<long>(type: "bigint", nullable: false),
                    id_pedido = table.Column<long>(type: "bigint", nullable: false),
                    descripcion = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    estado = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comanda", x => x.id);
                    table.ForeignKey(
                        name: "FK_Comanda_Camarero_id_camarero",
                        column: x => x.id_camarero,
                        principalTable: "Camarero",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comanda_Cocinero_id_cocinero",
                        column: x => x.id_cocinero,
                        principalTable: "Cocinero",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Comanda_Pedido_id_pedido",
                        column: x => x.id_pedido,
                        principalTable: "Pedido",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comanda_Producto_id_producto",
                        column: x => x.id_producto,
                        principalTable: "Producto",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "fk_camarerocomanda",
                table: "Comanda",
                column: "id_camarero");

            migrationBuilder.CreateIndex(
                name: "fk_cocinerocomanda",
                table: "Comanda",
                column: "id_cocinero");

            migrationBuilder.CreateIndex(
                name: "fk_pedidocomanda",
                table: "Comanda",
                column: "id_pedido");

            migrationBuilder.CreateIndex(
                name: "fk_productocomanda",
                table: "Comanda",
                column: "id_producto");

            migrationBuilder.CreateIndex(
                name: "IX_MesaReserva_IdReserva",
                table: "MesaReserva",
                column: "IdReserva");

            migrationBuilder.CreateIndex(
                name: "fk_idmesa",
                table: "Pedido",
                column: "id_mesa");

            migrationBuilder.CreateIndex(
                name: "fk_catProd",
                table: "Producto",
                column: "id_cat");

            migrationBuilder.CreateIndex(
                name: "username",
                table: "Usuario",
                column: "username",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comanda");

            migrationBuilder.DropTable(
                name: "Gerente");

            migrationBuilder.DropTable(
                name: "MesaReserva");

            migrationBuilder.DropTable(
                name: "Camarero");

            migrationBuilder.DropTable(
                name: "Cocinero");

            migrationBuilder.DropTable(
                name: "Pedido");

            migrationBuilder.DropTable(
                name: "Producto");

            migrationBuilder.DropTable(
                name: "Reserva");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "mesa");

            migrationBuilder.DropTable(
                name: "Categoria");
        }
    }
}
