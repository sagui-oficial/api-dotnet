using Microsoft.EntityFrameworkCore.Migrations;

namespace Sagui.Postgres.Migrations
{
    public partial class addvalorProcedimento : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "TotalProcedimentos",
                table: "GTO",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "ValorTotalProcedimentos",
                table: "GTO",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "Extensao",
                table: "Arquivo",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioBase_PlanoOperadoraId",
                table: "UsuarioBase",
                column: "PlanoOperadoraId");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_UsuarioBase_PlanoOperadora_PlanoOperadoraId",
            //    table: "UsuarioBase",
            //    column: "PlanoOperadoraId",
            //    principalTable: "PlanoOperadora",
            //    principalColumn: "Id"
            //    //onDelete: ReferentialAction.Cascade
            //    );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UsuarioBase_PlanoOperadora_PlanoOperadoraId",
                table: "UsuarioBase");

            migrationBuilder.DropIndex(
                name: "IX_UsuarioBase_PlanoOperadoraId",
                table: "UsuarioBase");

            migrationBuilder.DropColumn(
                name: "TotalProcedimentos",
                table: "GTO");

            migrationBuilder.DropColumn(
                name: "ValorTotalProcedimentos",
                table: "GTO");

            migrationBuilder.DropColumn(
                name: "Extensao",
                table: "Arquivo");
        }
    }
}
