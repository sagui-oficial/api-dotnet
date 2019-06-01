using Microsoft.EntityFrameworkCore.Migrations;

namespace Sagui.Postgres.Migrations
{
    public partial class removePlanoOperadroPaciente : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlanoOperadoraPaciente");

            migrationBuilder.AddColumn<string>(
                name: "NumeroPlano",
                table: "UsuarioBase",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PlanoOperadoraId",
                table: "UsuarioBase",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumeroPlano",
                table: "UsuarioBase");

            migrationBuilder.DropColumn(
                name: "PlanoOperadoraId",
                table: "UsuarioBase");

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
        }
    }
}
