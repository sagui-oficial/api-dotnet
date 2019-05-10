using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sagui.DB.Migrations
{
    public partial class Lote : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LoteIdLote",
                table: "GTO",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "LotePublicID",
                table: "GTO",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Lote",
                columns: table => new
                {
                    PublicID = table.Column<Guid>(nullable: false, defaultValueSql: "newsequentialid()"),
                    IdLote = table.Column<int>(nullable: false).Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PlanoOperadoraId = table.Column<int>(nullable: true),
                    PlanoOperadoraPublicID = table.Column<Guid>(nullable: true),
                    TotalGTOLote = table.Column<int>(nullable: false),
                    ValorTotalLote = table.Column<decimal>(nullable: false),
                    DataEnvioCorreio = table.Column<DateTime>(nullable: false),
                    DataPrevistaRecebimento = table.Column<DateTime>(nullable: false),
                    StatusLote = table.Column<int>(nullable: false),
                    FuncionarioId = table.Column<int>(nullable: true),
                    FuncionarioPublicID = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lote", x => new { x.IdLote, x.PublicID });
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
                name: "IX_GTO_LoteIdLote_LotePublicID",
                table: "GTO",
                columns: new[] { "LoteIdLote", "LotePublicID" });

            migrationBuilder.CreateIndex(
                name: "IX_Lote_FuncionarioId_FuncionarioPublicID",
                table: "Lote",
                columns: new[] { "FuncionarioId", "FuncionarioPublicID" });

            migrationBuilder.CreateIndex(
                name: "IX_Lote_PlanoOperadoraId_PlanoOperadoraPublicID",
                table: "Lote",
                columns: new[] { "PlanoOperadoraId", "PlanoOperadoraPublicID" });

            migrationBuilder.AddForeignKey(
                name: "FK_GTO_Lote_LoteIdLote_LotePublicID",
                table: "GTO",
                columns: new[] { "LoteIdLote", "LotePublicID" },
                principalTable: "Lote",
                principalColumns: new[] { "IdLote", "PublicID" },
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GTO_Lote_LoteIdLote_LotePublicID",
                table: "GTO");

            migrationBuilder.DropTable(
                name: "Lote");

            migrationBuilder.DropIndex(
                name: "IX_GTO_LoteIdLote_LotePublicID",
                table: "GTO");

            migrationBuilder.DropColumn(
                name: "LoteIdLote",
                table: "GTO");

            migrationBuilder.DropColumn(
                name: "LotePublicID",
                table: "GTO");
        }
    }
}
