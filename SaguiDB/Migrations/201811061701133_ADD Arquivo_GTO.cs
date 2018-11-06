namespace SaguiDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ADDArquivo_GTO : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Arquivos", "GTO_Id", "dbo.GTO");
            DropIndex("dbo.Arquivos", new[] { "GTO_Id" });
            CreateTable(
                "dbo.Arquivo",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        NomeArquivo = c.String(),
                        DataArquivo = c.DateTime(nullable: false),
                        GTO_Id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.GTO", t => t.GTO_Id)
                .Index(t => t.GTO_Id);
            
            DropTable("dbo.Arquivos");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Arquivos",
                c => new
                    {
                        NomeArquivo = c.String(nullable: false, maxLength: 128),
                        DataArquivo = c.DateTime(nullable: false),
                        GTO_Id = c.Int(),
                    })
                .PrimaryKey(t => t.NomeArquivo);
            
            DropForeignKey("dbo.Arquivo", "GTO_Id", "dbo.GTO");
            DropIndex("dbo.Arquivo", new[] { "GTO_Id" });
            DropTable("dbo.Arquivo");
            CreateIndex("dbo.Arquivos", "GTO_Id");
            AddForeignKey("dbo.Arquivos", "GTO_Id", "dbo.GTO", "Id");
        }
    }
}
