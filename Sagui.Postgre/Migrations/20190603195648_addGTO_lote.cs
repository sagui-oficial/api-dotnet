using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Sagui.Postgres.Migrations
{
    public partial class addGTO_lote : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GTO_Lote",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    IdLote = table.Column<int>(nullable: false),
                    IdGTO = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GTO_Lote", x => x.Id);
                });


            //migrationBuilder.DropColumn(
            //   name: "GTO_Lote",
            //   table: "GTO"
            //   );

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GTO_Lote");
        }
    }
}
