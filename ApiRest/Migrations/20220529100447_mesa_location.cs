using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiRest.Migrations
{
    public partial class mesa_location : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "location",
                table: "mesa",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "location",
                table: "mesa");
        }
    }
}
