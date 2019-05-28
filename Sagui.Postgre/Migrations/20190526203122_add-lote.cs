using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Sagui.Postgres.Migrations
{
    public partial class addlote : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.AddColumn<int>(
            //    name: "LoteId",
            //    table: "GTO",
            //    nullable: true);

            migrationBuilder.CreateTable(
                name: "Lote",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    PublicID = table.Column<Guid>(nullable: false, defaultValueSql: "uuid_generate_v1()"),
                    Status = table.Column<int>(nullable: false, defaultValueSql: "1"),
                    PlanoOperadoraId = table.Column<int>(nullable: true),
                   
                    TotalGTOLote = table.Column<int>(nullable: false),
                    ValorTotalLote = table.Column<decimal>(nullable: false),
                    DataEnvioCorreio = table.Column<DateTime>(nullable: false),
                    DataPrevistaRecebimento = table.Column<DateTime>(nullable: false),
                    FuncionarioId = table.Column<int>(nullable: true)
                   
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lote", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lote_UsuarioBase_FuncionarioId_FuncionarioPublicID",
                        columns: x => new { x.FuncionarioId},
                        principalTable: "UsuarioBase",
                        principalColumns: new[] { "Id" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Lote_PlanoOperadora_PlanoOperadoraId_PlanoOperadoraPublicID",
                        columns: x => new { x.PlanoOperadoraId },
                        principalTable: "PlanoOperadora",
                        principalColumns: new[] { "Id" },
                        onDelete: ReferentialAction.Restrict);
                });

            //migrationBuilder.CreateIndex(
            //    name: "IX_GTO_LoteId",
            //    table: "GTO",
            //    column: "LoteId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Lote_FuncionarioId_FuncionarioPublicID",
            //    table: "Lote",
            //    columns: new[] { "FuncionarioId", "FuncionarioPublicID" });

            //migrationBuilder.CreateIndex(
            //    name: "IX_Lote_PlanoOperadoraId_PlanoOperadoraPublicID",
            //    table: "Lote",
            //    columns: new[] { "PlanoOperadoraId", "PlanoOperadoraPublicID" });

            //migrationBuilder.AddForeignKey(
            //    name: "FK_GTO_Lote_LoteId",
            //    table: "GTO",
            //    column: "LoteId",
            //    principalTable: "Lote",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GTO_Lote_LoteId",
                table: "GTO");

            migrationBuilder.DropTable(
                name: "Lote");

            migrationBuilder.DropIndex(
                name: "IX_GTO_LoteId",
                table: "GTO");

            migrationBuilder.DropColumn(
                name: "LoteId",
                table: "GTO");
        }
    }
}
