using Microsoft.EntityFrameworkCore.Migrations;

namespace Sagui.Postgres.Migrations
{
    public partial class fixprocedimento_gtr_id : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "idProcedimento",
                table: "Procedimento_GTO",
                newName: "IdProcedimento");

            migrationBuilder.RenameColumn(
                name: "idGTO",
                table: "Procedimento_GTO",
                newName: "IdGTO");

            migrationBuilder.RenameColumn(
                name: "idProcedimento_GTO",
                table: "Procedimento_GTO",
                newName: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IdProcedimento",
                table: "Procedimento_GTO",
                newName: "idProcedimento");

            migrationBuilder.RenameColumn(
                name: "IdGTO",
                table: "Procedimento_GTO",
                newName: "idGTO");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Procedimento_GTO",
                newName: "idProcedimento_GTO");
        }
    }
}
