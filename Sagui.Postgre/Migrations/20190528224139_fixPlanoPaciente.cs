using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Sagui.Postgres.Migrations
{
    public partial class fixPlanoPaciente : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_PlanoOperadoraPaciente_UsuarioBase_PacienteId_PacientePubli~",
            //    table: "PlanoOperadoraPaciente");

            //migrationBuilder.DropForeignKey(
            //    name: "FK_PlanoOperadoraPaciente_PlanoOperadora_PlanoOperadoraId1_Pla~",
            //    table: "PlanoOperadoraPaciente");

            //migrationBuilder.DropPrimaryKey(
            //    name: "PK_PlanoOperadoraPaciente",
            //    table: "PlanoOperadoraPaciente");

            //migrationBuilder.DropIndex(
            //    name: "IX_PlanoOperadoraPaciente_PacienteId_PacientePublicID",
            //    table: "PlanoOperadoraPaciente");

            //migrationBuilder.DropIndex(
            //    name: "IX_PlanoOperadoraPaciente_PlanoOperadoraId1_PlanoOperadoraPubl~",
            //    table: "PlanoOperadoraPaciente");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "PlanoOperadoraPaciente");

            //migrationBuilder.DropColumn(
            //    name: "PlanoOperadoraPublicID",
            //    table: "PlanoOperadoraPaciente");

            //migrationBuilder.RenameColumn(
            //    name: "PlanoOperadoraId1",
            //    table: "PlanoOperadoraPaciente",
            //    newName: "PacienteId1");

            migrationBuilder.AlterColumn<int>(
                name: "PacienteId",
                table: "PlanoOperadoraPaciente",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PlanoOperadoraPaciente",
                table: "PlanoOperadoraPaciente",
                columns: new[] { "PacienteId", "PlanoOperadoraId" });

            //migrationBuilder.CreateIndex(
            //    name: "IX_PlanoOperadoraPaciente_PacienteId1_PacientePublicID",
            //    table: "PlanoOperadoraPaciente",
            //    columns: new[] { "PacienteId1", "PacientePublicID" });

            //migrationBuilder.AddForeignKey(
            //    name: "FK_PlanoOperadoraPaciente_UsuarioBase_PacienteId1_PacientePubl~",
            //    table: "PlanoOperadoraPaciente",
            //    columns: new[] { "PacienteId1", "PacientePublicID" },
            //    principalTable: "UsuarioBase",
            //    principalColumns: new[] { "Id", "PublicID" },
            //    onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlanoOperadoraPaciente_UsuarioBase_PacienteId1_PacientePubl~",
                table: "PlanoOperadoraPaciente");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PlanoOperadoraPaciente",
                table: "PlanoOperadoraPaciente");

            migrationBuilder.DropIndex(
                name: "IX_PlanoOperadoraPaciente_PacienteId1_PacientePublicID",
                table: "PlanoOperadoraPaciente");

            migrationBuilder.RenameColumn(
                name: "PacienteId1",
                table: "PlanoOperadoraPaciente",
                newName: "PlanoOperadoraId1");

            migrationBuilder.AlterColumn<int>(
                name: "PacienteId",
                table: "PlanoOperadoraPaciente",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "PlanoOperadoraPaciente",
                nullable: false,
                defaultValue: 0)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

            migrationBuilder.AddColumn<Guid>(
                name: "PlanoOperadoraPublicID",
                table: "PlanoOperadoraPaciente",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PlanoOperadoraPaciente",
                table: "PlanoOperadoraPaciente",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_PlanoOperadoraPaciente_PacienteId_PacientePublicID",
                table: "PlanoOperadoraPaciente",
                columns: new[] { "PacienteId", "PacientePublicID" });

            migrationBuilder.CreateIndex(
                name: "IX_PlanoOperadoraPaciente_PlanoOperadoraId1_PlanoOperadoraPubl~",
                table: "PlanoOperadoraPaciente",
                columns: new[] { "PlanoOperadoraId1", "PlanoOperadoraPublicID" });

            migrationBuilder.AddForeignKey(
                name: "FK_PlanoOperadoraPaciente_UsuarioBase_PacienteId_PacientePubli~",
                table: "PlanoOperadoraPaciente",
                columns: new[] { "PacienteId", "PacientePublicID" },
                principalTable: "UsuarioBase",
                principalColumns: new[] { "Id", "PublicID" },
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PlanoOperadoraPaciente_PlanoOperadora_PlanoOperadoraId1_Pla~",
                table: "PlanoOperadoraPaciente",
                columns: new[] { "PlanoOperadoraId1", "PlanoOperadoraPublicID" },
                principalTable: "PlanoOperadora",
                principalColumns: new[] { "Id", "PublicID" },
                onDelete: ReferentialAction.Restrict);
        }
    }
}
