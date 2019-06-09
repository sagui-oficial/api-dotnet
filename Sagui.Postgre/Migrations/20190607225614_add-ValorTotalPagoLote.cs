using Microsoft.EntityFrameworkCore.Migrations;

namespace Sagui.Postgres.Migrations
{
    public partial class addValorTotalPagoLote : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "ValorTotalPagoLote",
                table: "Lote",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ValorTotalPagoLote",
                table: "Lote");
        }
    }
}
