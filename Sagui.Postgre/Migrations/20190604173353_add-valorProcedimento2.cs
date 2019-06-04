using Microsoft.EntityFrameworkCore.Migrations;

namespace Sagui.Postgres.Migrations
{
    public partial class addvalorProcedimento2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ValorProcedimento",
                table: "Procedimento");

            migrationBuilder.AddColumn<bool>(
                name: "Pago",
                table: "Procedimento_GTO",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<double>(
                name: "ValorProcedimento",
                table: "Procedimento_GTO",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Pago",
                table: "Procedimento_GTO");

            migrationBuilder.DropColumn(
                name: "ValorProcedimento",
                table: "Procedimento_GTO");

            migrationBuilder.AddColumn<double>(
                name: "ValorProcedimento",
                table: "Procedimento",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
