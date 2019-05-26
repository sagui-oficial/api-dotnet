using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Sagui.Postgres.Migrations
{
    public partial class fixidparabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_GTO_Lote_LoteId",
            //    table: "GTO");

            //migrationBuilder.DropTable(
            //    name: "Lote");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Procedimento_IdProcedimento",
                table: "Procedimento");

            //migrationBuilder.DropIndex(
            //    name: "IX_GTO_LoteId",
            //    table: "GTO");

            //migrationBuilder.DropColumn(
            //    name: "LoteId",
            //    table: "GTO");

            migrationBuilder.RenameColumn(
                name: "IdProcedimento",
                table: "Procedimento",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "PlanoOperadoraPaciente",
                newName: "Id");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Procedimento_Id",
                table: "Procedimento",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_Procedimento_Id",
                table: "Procedimento");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Procedimento",
                newName: "IdProcedimento");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "PlanoOperadoraPaciente",
                newName: "id");

            migrationBuilder.AddColumn<int>(
                name: "LoteId",
                table: "GTO",
                nullable: true);

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Procedimento_IdProcedimento",
                table: "Procedimento",
                column: "IdProcedimento");

            migrationBuilder.CreateTable(
                name: "Lote",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    DataEnvioCorreio = table.Column<DateTime>(nullable: false),
                    DataPrevistaRecebimento = table.Column<DateTime>(nullable: false),
                    FuncionarioId = table.Column<int>(nullable: true),
                    FuncionarioPublicID = table.Column<Guid>(nullable: true),
                    PlanoOperadoraId = table.Column<int>(nullable: true),
                    PlanoOperadoraPublicID = table.Column<Guid>(nullable: true),
                    PublicID = table.Column<Guid>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    StatusLote = table.Column<int>(nullable: false),
                    TotalGTOLote = table.Column<int>(nullable: false),
                    ValorTotalLote = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lote", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lote_UsuarioBase_FuncionarioId_FuncionarioPublicID",
                        columns: x => new { x.FuncionarioId, x.FuncionarioPublicID },
                        principalTable: "UsuarioBase",
                        principalColumns: new[] { "Id", "PublicID" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Lote_PlanoOperadora_PlanoOperadoraId_PlanoOperadoraPublicID",
                        columns: x => new { x.PlanoOperadoraId, x.PlanoOperadoraPublicID },
                        principalTable: "PlanoOperadora",
                        principalColumns: new[] { "Id", "PublicID" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GTO_LoteId",
                table: "GTO",
                column: "LoteId");

            migrationBuilder.CreateIndex(
                name: "IX_Lote_FuncionarioId_FuncionarioPublicID",
                table: "Lote",
                columns: new[] { "FuncionarioId", "FuncionarioPublicID" });

            migrationBuilder.CreateIndex(
                name: "IX_Lote_PlanoOperadoraId_PlanoOperadoraPublicID",
                table: "Lote",
                columns: new[] { "PlanoOperadoraId", "PlanoOperadoraPublicID" });

            migrationBuilder.AddForeignKey(
                name: "FK_GTO_Lote_LoteId",
                table: "GTO",
                column: "LoteId",
                principalTable: "Lote",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
