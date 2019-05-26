using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sagui.Postgres.Migrations
{
    public partial class addstatusBaseModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           

            migrationBuilder.DropIndex(
                name: "IX_PlanoOperadora_Id",
                table: "PlanoOperadora");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "UsuarioBase",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PlanoOperadoraId",
                table: "PlanoOperadoraPaciente",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "PlanoOperadoraPublicID",
                table: "PlanoOperadoraPaciente",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "PlanoOperadora",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Arquivo",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddUniqueConstraint(
                name: "AK_UsuarioBase_Id",
                table: "UsuarioBase",
                column: "Id");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Procedimento_IdProcedimento",
                table: "Procedimento",
                column: "IdProcedimento");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_PlanoOperadora_Id",
                table: "PlanoOperadora",
                column: "Id");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_GTO_Id",
                table: "GTO",
                column: "Id");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Arquivo_Id",
                table: "Arquivo",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_PlanoOperadoraPaciente_PlanoOperadoraId_PlanoOperadoraPubli~",
                table: "PlanoOperadoraPaciente",
                columns: new[] { "PlanoOperadoraId", "PlanoOperadoraPublicID" });

            migrationBuilder.AddForeignKey(
                name: "FK_PlanoOperadoraPaciente_PlanoOperadora_PlanoOperadoraId_Plan~",
                table: "PlanoOperadoraPaciente",
                columns: new[] { "PlanoOperadoraId", "PlanoOperadoraPublicID" },
                principalTable: "PlanoOperadora",
                principalColumns: new[] { "Id", "PublicID" },
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlanoOperadoraPaciente_PlanoOperadora_PlanoOperadoraId_Plan~",
                table: "PlanoOperadoraPaciente");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_UsuarioBase_Id",
                table: "UsuarioBase");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Procedimento_IdProcedimento",
                table: "Procedimento");

            migrationBuilder.DropIndex(
                name: "IX_PlanoOperadoraPaciente_PlanoOperadoraId_PlanoOperadoraPubli~",
                table: "PlanoOperadoraPaciente");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_PlanoOperadora_Id",
                table: "PlanoOperadora");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_GTO_Id",
                table: "GTO");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Arquivo_Id",
                table: "Arquivo");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "UsuarioBase");

            migrationBuilder.DropColumn(
                name: "PlanoOperadoraId",
                table: "PlanoOperadoraPaciente");

            migrationBuilder.DropColumn(
                name: "PlanoOperadoraPublicID",
                table: "PlanoOperadoraPaciente");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "PlanoOperadora");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Arquivo");

            migrationBuilder.CreateIndex(
                name: "IX_PlanoOperadora_Id",
                table: "PlanoOperadora",
                column: "Id",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PlanoOperadora_PlanoOperadoraPaciente_Id",
                table: "PlanoOperadora",
                column: "Id",
                principalTable: "PlanoOperadoraPaciente",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
