using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Sagui.Postgres.Migrations
{
    public partial class start : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE EXTENSION IF NOT EXISTS ""uuid-ossp""");

            migrationBuilder.CreateTable(
                name: "PlanoOperadora",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    PublicID = table.Column<Guid>(nullable: false, defaultValueSql: "uuid_generate_v1()"),
                    Status = table.Column<int>(nullable: true, defaultValueSql: "1"),
                    NomeFantasia = table.Column<string>(nullable: true),
                    RazaoSocial = table.Column<string>(nullable: true),
                    CNPJ = table.Column<string>(nullable: true),
                    DataEnvioLote = table.Column<DateTime>(nullable: false),
                    DataRecebimentoLote = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanoOperadora", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Procedimento_GTO",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    IdGTO = table.Column<int>(nullable: false),
                    IdProcedimento = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Procedimento_GTO", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UsuarioBase",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    PublicID = table.Column<Guid>(nullable: false, defaultValueSql: "uuid_generate_v1()"),
                    Status = table.Column<int>(nullable: true, defaultValueSql: "1"),
                    Funcao = table.Column<string>(nullable: true),
                    Nome = table.Column<string>(nullable: true),
                    Anotacoes = table.Column<string>(nullable: true),
                    CPF = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Telefone = table.Column<string>(nullable: true),
                    TipoUsuario = table.Column<int>(nullable: false),
                    //Discriminator = table.Column<string>(nullable: false),
                    CRO = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioBase", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Lote",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    PublicID = table.Column<Guid>(nullable: false, defaultValueSql: "uuid_generate_v1()"),
                    Status = table.Column<int>(nullable: true, defaultValueSql: "1"),
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
                        name: "FK_Lote_UsuarioBase_FuncionarioId",
                        column: x => x.FuncionarioId,
                        principalTable: "UsuarioBase",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Lote_PlanoOperadora_PlanoOperadoraId",
                        column: x => x.PlanoOperadoraId,
                        principalTable: "PlanoOperadora",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PlanoOperadoraPaciente",
                columns: table => new
                {
                    PacienteId = table.Column<int>(nullable: false),
                    PlanoOperadoraId = table.Column<int>(nullable: false),
                    NumeroPlano = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanoOperadoraPaciente", x => new { x.PacienteId, x.PlanoOperadoraId });
                    table.ForeignKey(
                        name: "FK_PlanoOperadoraPaciente_UsuarioBase_PacienteId",
                        column: x => x.PacienteId,
                        principalTable: "UsuarioBase",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GTO",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    PublicID = table.Column<Guid>(nullable: false, defaultValueSql: "uuid_generate_v1()"),
                    Status = table.Column<int>(nullable: true, defaultValueSql: "1"),
                    Numero = table.Column<string>(nullable: true),
                    PlanoOperadoraId = table.Column<int>(nullable: true),
                    PacienteId = table.Column<int>(nullable: true),
                    Solicitacao = table.Column<DateTime>(nullable: false),
                    Vencimento = table.Column<DateTime>(nullable: false),
                    LoteId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GTO", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GTO_Lote_LoteId",
                        column: x => x.LoteId,
                        principalTable: "Lote",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GTO_UsuarioBase_PacienteId",
                        column: x => x.PacienteId,
                        principalTable: "UsuarioBase",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GTO_PlanoOperadora_PlanoOperadoraId",
                        column: x => x.PlanoOperadoraId,
                        principalTable: "PlanoOperadora",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Arquivo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    PublicID = table.Column<Guid>(nullable: false, defaultValueSql: "uuid_generate_v1()"),
                    Status = table.Column<int>(nullable: true, defaultValueSql: "1"),
                    Nome = table.Column<string>(nullable: true),
                    Stream = table.Column<byte[]>(nullable: true),
                    DataCriacao = table.Column<DateTime>(nullable: false),
                    PathArquivo = table.Column<string>(nullable: true),
                    //Discriminator = table.Column<string>(nullable: false),
                    //PlanoOperadoraId = table.Column<int>(nullable: true),
                    //idArquivo_GTO = table.Column<int>(nullable: true),
                    //idGTO = table.Column<int>(nullable: true),
                    //idArquivo = table.Column<int>(nullable: true),
                    //GTOId = table.Column<int>(nullable: true)
                }
                //constraints: table =>
                //{
                //    table.PrimaryKey("PK_Arquivo", x => x.Id);
                //    table.ForeignKey(
                //        name: "FK_Arquivo_GTO_GTOId",
                //        column: x => x.GTOId,
                //        principalTable: "GTO",
                //        principalColumn: "Id",
                //        onDelete: ReferentialAction.Restrict);
                //    table.ForeignKey(
                //        name: "FK_Arquivo_PlanoOperadora_PlanoOperadoraId",
                //        column: x => x.PlanoOperadoraId,
                //        principalTable: "PlanoOperadora",
                //        principalColumn: "Id",
                //        onDelete: ReferentialAction.Restrict);
                //}
                );

            migrationBuilder.CreateTable(
                name: "Procedimento",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    PublicID = table.Column<Guid>(nullable: false, defaultValueSql: "uuid_generate_v1()"),
                    Status = table.Column<int>(nullable: true, defaultValueSql: "1"),
                    Codigo = table.Column<string>(nullable: true),
                    NomeProcedimento = table.Column<string>(nullable: true),
                    ValorProcedimento = table.Column<double>(nullable: false),
                    Exigencias = table.Column<string>(nullable: true),
                    Anotacoes = table.Column<string>(nullable: true),
                    //GTOId = table.Column<int>(nullable: true),
                    //PlanoOperadoraId = table.Column<int>(nullable: true)
                }
                //constraints: table =>
                //{
                //    table.PrimaryKey("PK_Procedimento", x => x.Id);
                //    table.ForeignKey(
                //        name: "FK_Procedimento_GTO_GTOId",
                //        column: x => x.GTOId,
                //        principalTable: "GTO",
                //        principalColumn: "Id",
                //        onDelete: ReferentialAction.Restrict);
                //    table.ForeignKey(
                //        name: "FK_Procedimento_PlanoOperadora_PlanoOperadoraId",
                //        column: x => x.PlanoOperadoraId,
                //        principalTable: "PlanoOperadora",
                //        principalColumn: "Id",
                //        onDelete: ReferentialAction.Restrict);
                //}
                );

            //migrationBuilder.CreateIndex(
            //    name: "IX_Arquivo_GTOId",
            //    table: "Arquivo",
            //    column: "GTOId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Arquivo_PlanoOperadoraId",
            //    table: "Arquivo",
            //    column: "PlanoOperadoraId");

            migrationBuilder.CreateIndex(
                name: "IX_GTO_LoteId",
                table: "GTO",
                column: "LoteId");

            migrationBuilder.CreateIndex(
                name: "IX_GTO_PacienteId",
                table: "GTO",
                column: "PacienteId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_GTO_PlanoOperadoraId",
            //    table: "GTO",
            //    column: "PlanoOperadoraId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Lote_FuncionarioId",
            //    table: "Lote",
            //    column: "FuncionarioId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Lote_PlanoOperadoraId",
            //    table: "Lote",
            //    column: "PlanoOperadoraId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Procedimento_GTOId",
            //    table: "Procedimento",
            //    column: "GTOId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Procedimento_PlanoOperadoraId",
            //    table: "Procedimento",
            //    column: "PlanoOperadoraId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Arquivo");

            migrationBuilder.DropTable(
                name: "PlanoOperadoraPaciente");

            migrationBuilder.DropTable(
                name: "Procedimento");

            migrationBuilder.DropTable(
                name: "Procedimento_GTO");

            migrationBuilder.DropTable(
                name: "GTO");

            migrationBuilder.DropTable(
                name: "Lote");

            migrationBuilder.DropTable(
                name: "UsuarioBase");

            migrationBuilder.DropTable(
                name: "PlanoOperadora");
        }
    }
}
