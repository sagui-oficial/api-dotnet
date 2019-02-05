using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sagui.DB.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Arquivo_GTO",
                columns: table => new
                {
                    idArquivo_GTO = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    idGTO = table.Column<int>(nullable: false),
                    idArquivo = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Arquivo_GTO", x => x.idArquivo_GTO);
                });

            migrationBuilder.CreateTable(
                name: "PlanoOperadora",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
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
                    idProcedimento_GTO = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    idGTO = table.Column<int>(nullable: false),
                    idProcedimento = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Procedimento_GTO", x => x.idProcedimento_GTO);
                });

            migrationBuilder.CreateTable(
                name: "UsuarioBase",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Funcao = table.Column<string>(nullable: true),
                    Nome = table.Column<string>(nullable: true),
                    Anotacoes = table.Column<string>(nullable: true),
                    CPF = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Telefone = table.Column<string>(nullable: true),
                    TipoUsuario = table.Column<int>(nullable: false),
                    Discriminator = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioBase", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GTO",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Numero = table.Column<string>(nullable: true),
                    PlanoOperadoraId = table.Column<int>(nullable: true),
                    PacienteId = table.Column<int>(nullable: true),
                    Solicitacao = table.Column<DateTime>(nullable: false),
                    Vencimento = table.Column<DateTime>(nullable: false),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GTO", x => x.Id);
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
                name: "PlanoOperadoraPaciente",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PlanoOperadoraId = table.Column<int>(nullable: true),
                    NumeroPlano = table.Column<string>(nullable: true),
                    PacienteId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanoOperadoraPaciente", x => x.id);
                    table.ForeignKey(
                        name: "FK_PlanoOperadoraPaciente_UsuarioBase_PacienteId",
                        column: x => x.PacienteId,
                        principalTable: "UsuarioBase",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PlanoOperadoraPaciente_PlanoOperadora_PlanoOperadoraId",
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
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: true),
                    Stream = table.Column<byte[]>(nullable: true),
                    DataCriacao = table.Column<DateTime>(nullable: false),
                    PathArquivo = table.Column<string>(nullable: true),
                    //GTOId = table.Column<int>(nullable: true),
                    //PlanoOperadoraId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Arquivo", x => x.Id);
                    //table.ForeignKey(
                    //    name: "FK_Arquivo_GTO_GTOId",
                    //    column: x => x.GTOId,
                    //    principalTable: "GTO",
                    //    principalColumn: "Id",
                    //    onDelete: ReferentialAction.Restrict);
                    //table.ForeignKey(
                    //    name: "FK_Arquivo_PlanoOperadora_PlanoOperadoraId",
                    //    column: x => x.PlanoOperadoraId,
                    //    principalTable: "PlanoOperadora",
                    //    principalColumn: "Id",
                    //    onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Procedimento",
                columns: table => new
                {
                    IdProcedimento = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Codigo = table.Column<int>(nullable: false),
                    NomeProcedimento = table.Column<string>(nullable: true),
                    ValorProcedimento = table.Column<double>(nullable: false),
                    Exigencias = table.Column<string>(nullable: true),
                    Anotacoes = table.Column<string>(nullable: true),
                   // GTOId = table.Column<int>(nullable: true),
                    //PlanoOperadoraId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Procedimento", x => x.IdProcedimento);
                    //table.ForeignKey(
                    //    name: "FK_Procedimento_GTO_GTOId",
                    //    column: x => x.GTOId,
                    //    principalTable: "GTO",
                    //    principalColumn: "Id",
                    //    onDelete: ReferentialAction.Restrict);
                    //table.ForeignKey(
                    //    name: "FK_Procedimento_PlanoOperadora_PlanoOperadoraId",
                    //    column: x => x.PlanoOperadoraId,
                    //    principalTable: "PlanoOperadora",
                    //    principalColumn: "Id",
                    //    onDelete: ReferentialAction.Restrict);
                });

            //migrationBuilder.CreateIndex(
            //    name: "IX_Arquivo_GTOId",
            //    table: "Arquivo",
            //    column: "GTOId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Arquivo_PlanoOperadoraId",
            //    table: "Arquivo",
            //    column: "PlanoOperadoraId");

            migrationBuilder.CreateIndex(
                name: "IX_GTO_PacienteId",
                table: "GTO",
                column: "PacienteId");

            migrationBuilder.CreateIndex(
                name: "IX_GTO_PlanoOperadoraId",
                table: "GTO",
                column: "PlanoOperadoraId");

            migrationBuilder.CreateIndex(
                name: "IX_PlanoOperadoraPaciente_PacienteId",
                table: "PlanoOperadoraPaciente",
                column: "PacienteId");

            migrationBuilder.CreateIndex(
                name: "IX_PlanoOperadoraPaciente_PlanoOperadoraId",
                table: "PlanoOperadoraPaciente",
                column: "PlanoOperadoraId");

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
                name: "Arquivo_GTO");

            migrationBuilder.DropTable(
                name: "PlanoOperadoraPaciente");

            migrationBuilder.DropTable(
                name: "Procedimento");

            migrationBuilder.DropTable(
                name: "Procedimento_GTO");

            migrationBuilder.DropTable(
                name: "GTO");

            migrationBuilder.DropTable(
                name: "UsuarioBase");

            migrationBuilder.DropTable(
                name: "PlanoOperadora");
        }
    }
}
