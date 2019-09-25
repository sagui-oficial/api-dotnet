using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Sagui.Postgres.Migrations
{
    public partial class addArquivo_GTO : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropColumn(
            //    name: "idArquivo",
            //    table: "Arquivo");

            //migrationBuilder.DropColumn(
            //    name: "idArquivo_GTO",
            //    table: "Arquivo");

            //migrationBuilder.DropColumn(
            //    name: "idGTO",
            //    table: "Arquivo");

            //migrationBuilder.DropColumn(
            //    name: "Discriminator",
            //    table: "Arquivo");

            migrationBuilder.CreateTable(
                name: "Arquivo_GTO",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    idGTO = table.Column<int>(nullable: false),
                    idArquivo = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Arquivo_GTO", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Arquivo_GTO");

            migrationBuilder.AddColumn<int>(
                name: "idArquivo",
                table: "Arquivo",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "idArquivo_GTO",
                table: "Arquivo",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "idGTO",
                table: "Arquivo",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Arquivo",
                nullable: false,
                defaultValue: "");
        }
    }
}
