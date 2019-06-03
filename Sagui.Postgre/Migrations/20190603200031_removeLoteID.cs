using Microsoft.EntityFrameworkCore.Migrations;

namespace Sagui.Postgres.Migrations
{
    public partial class removeLoteID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
               name: "LoteId",
               table: "GTO"
               );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
