namespace SaguiDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ADDArquivo_GTO2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Arquivo_GTO",
                c => new
                    {
                        idGTO = c.Int(nullable: false, identity: true),
                        idArquivo = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.idGTO);
            
            AddColumn("dbo.Arquivo", "Arquivo_GTO_idGTO", c => c.Int());
            AddColumn("dbo.GTO", "Arquivo_GTO_idGTO", c => c.Int());
            CreateIndex("dbo.Arquivo", "Arquivo_GTO_idGTO");
            CreateIndex("dbo.GTO", "Arquivo_GTO_idGTO");
            AddForeignKey("dbo.Arquivo", "Arquivo_GTO_idGTO", "dbo.Arquivo_GTO", "idGTO");
            AddForeignKey("dbo.GTO", "Arquivo_GTO_idGTO", "dbo.Arquivo_GTO", "idGTO");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.GTO", "Arquivo_GTO_idGTO", "dbo.Arquivo_GTO");
            DropForeignKey("dbo.Arquivo", "Arquivo_GTO_idGTO", "dbo.Arquivo_GTO");
            DropIndex("dbo.GTO", new[] { "Arquivo_GTO_idGTO" });
            DropIndex("dbo.Arquivo", new[] { "Arquivo_GTO_idGTO" });
            DropColumn("dbo.GTO", "Arquivo_GTO_idGTO");
            DropColumn("dbo.Arquivo", "Arquivo_GTO_idGTO");
            DropTable("dbo.Arquivo_GTO");
        }
    }
}
