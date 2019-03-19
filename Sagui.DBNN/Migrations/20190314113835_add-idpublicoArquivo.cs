using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sagui.DB.Migrations
{
    public partial class addidpublicoArquivo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Arquivo",
                table: "Arquivo");

          
            migrationBuilder.DropColumn(
                name: "Id",
                table: "Arquivo"
                );
            
            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Arquivo"
                ).Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<Guid>(
                name: "PublicID",
                table: "Arquivo",
                nullable: false,
                defaultValueSql: "newsequentialid()");

            //migrationBuilder.AddPrimaryKey(
            //    name: "PK_Arquivo",
            //    table: "Arquivo",
            //    columns: new[] { "Id", "PublicID" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Arquivo",
                table: "Arquivo");

            migrationBuilder.DropColumn(
                name: "PublicID",
                table: "Arquivo");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Arquivo",
                nullable: false,
                oldClrType: typeof(int))
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Arquivo",
                table: "Arquivo",
                column: "Id");
        }
    }
}
