using Microsoft.EntityFrameworkCore.Migrations;

namespace Sagui.DB.Migrations
{
    public partial class cro : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CRO",
                table: "UsuarioBase",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CRO",
                table: "UsuarioBase");
        }
    }
}
