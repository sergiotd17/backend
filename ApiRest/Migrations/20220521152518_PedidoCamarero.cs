using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiRest.Migrations
{
    public partial class PedidoCamarero : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "id_camarero",
                table: "Pedido",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pedido_id_camarero",
                table: "Pedido",
                column: "id_camarero");

            migrationBuilder.AddForeignKey(
                name: "FK_Pedido_Camarero_id_camarero",
                table: "Pedido",
                column: "id_camarero",
                principalTable: "Camarero",
                principalColumn: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pedido_Camarero_id_camarero",
                table: "Pedido");

            migrationBuilder.DropIndex(
                name: "IX_Pedido_id_camarero",
                table: "Pedido");

            migrationBuilder.DropColumn(
                name: "id_camarero",
                table: "Pedido");
        }
    }
}
