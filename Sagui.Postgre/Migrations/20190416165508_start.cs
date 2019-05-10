using System;
using Microsoft.EntityFrameworkCore.Metadata;
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
                name: "Arquivo_GTO",
                columns: table => new
                {
                    idArquivo_GTO = table.Column<int>(nullable: false).Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    idGTO = table.Column<int>(nullable: false),
                    idArquivo = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Arquivo_GTO", x => x.idArquivo_GTO);
                });

            migrationBuilder.CreateTable(
                name: "Procedimento_GTO",
                columns: table => new
                {
                    idProcedimento_GTO = table.Column<int>(nullable: false).Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
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

                    Id = table.Column<int>(nullable: false).Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Funcao = table.Column<string>(nullable: true),
                    Nome = table.Column<string>(nullable: true),
                    Anotacoes = table.Column<string>(nullable: true),
                    CPF = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Telefone = table.Column<string>(nullable: true),
                    TipoUsuario = table.Column<int>(nullable: false),
                    Discriminator = table.Column<string>(nullable: true),
                    PublicID = table.Column<Guid>(nullable: false, defaultValueSql: "uuid_generate_v1()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioBase", x => new { x.Id, x.PublicID });
                });

            migrationBuilder.CreateTable(
                name: "PlanoOperadoraPaciente",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false).Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NumeroPlano = table.Column<string>(nullable: true),
                    PacienteId = table.Column<int>(nullable: true),
                    PublicID = table.Column<Guid>(nullable: false, defaultValueSql: "uuid_generate_v1()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanoOperadoraPaciente", x => x.id);
                    table.ForeignKey(
                        name: "FK_PlanoOperadoraPaciente_UsuarioBase_PacienteId_PacientePublicID",
                        columns: x => new { x.PacienteId, x.PublicID },
                        principalTable: "UsuarioBase",
                        principalColumns: new[] { "Id", "PublicID" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PlanoOperadora",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false).Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NomeFantasia = table.Column<string>(nullable: true),
                    RazaoSocial = table.Column<string>(nullable: true),
                    CNPJ = table.Column<string>(nullable: true),
                    DataEnvioLote = table.Column<DateTime>(nullable: false),
                    DataRecebimentoLote = table.Column<DateTime>(nullable: false),
                    PublicID = table.Column<Guid>(nullable: false, defaultValueSql: "uuid_generate_v1()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanoOperadora", x => new { x.Id, x.PublicID });

                });

            migrationBuilder.CreateTable(
                name: "GTO",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false).Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Numero = table.Column<string>(nullable: true),
                    PlanoOperadoraId = table.Column<int>(nullable: true),
                    PacienteId = table.Column<int>(nullable: true),
                    Solicitacao = table.Column<DateTime>(nullable: false),
                    Vencimento = table.Column<DateTime>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    PublicID = table.Column<Guid>(nullable: false, defaultValueSql: "uuid_generate_v1()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GTO", x => new { x.Id, x.PublicID });
                });

            migrationBuilder.CreateTable(
                name: "Arquivo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false).Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: true),
                    Stream = table.Column<byte[]>(nullable: true),
                    DataCriacao = table.Column<DateTime>(nullable: false),
                    PathArquivo = table.Column<string>(nullable: true),

                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Arquivo", x => x.Id);

                });

            migrationBuilder.CreateTable(
                name: "Procedimento",
                columns: table => new
                {
                    IdProcedimento = table.Column<int>(nullable: false).Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Codigo = table.Column<int>(nullable: false),
                    NomeProcedimento = table.Column<string>(nullable: true),
                    ValorProcedimento = table.Column<double>(nullable: false),
                    Exigencias = table.Column<string>(nullable: true),
                    Anotacoes = table.Column<string>(nullable: true),
                    PublicID = table.Column<Guid>(nullable: false, defaultValueSql: "uuid_generate_v1()")

                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Procedimento", x => new { x.IdProcedimento, x.PublicID });

                });




            migrationBuilder.CreateIndex(
                name: "IX_PlanoOperadora_Id",
                table: "PlanoOperadora",
                column: "Id",
                unique: true);




        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Arquivo");

            migrationBuilder.DropTable(
                name: "Arquivo_GTO");

            migrationBuilder.DropTable(
                name: "Procedimento");

            migrationBuilder.DropTable(
                name: "Procedimento_GTO");

            migrationBuilder.DropTable(
                name: "GTO");

            migrationBuilder.DropTable(
                name: "PlanoOperadora");

            migrationBuilder.DropTable(
                name: "PlanoOperadoraPaciente");

            migrationBuilder.DropTable(
                name: "UsuarioBase");
        }
    }
}
