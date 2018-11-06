namespace SaguiDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ADDProcedimento_GTO : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Procedimentos", newName: "Procedimento");
            CreateTable(
                "dbo.Procedimento_GTO",
                c => new
                    {
                        idGTO = c.Int(nullable: false, identity: true),
                        idProcedimento = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.idGTO);
            
            AddColumn("dbo.GTO", "Procedimento_GTO_idGTO", c => c.Int());
            AddColumn("dbo.Procedimento", "Procedimento_GTO_idGTO", c => c.Int());
            CreateIndex("dbo.GTO", "Procedimento_GTO_idGTO");
            CreateIndex("dbo.Procedimento", "Procedimento_GTO_idGTO");
            AddForeignKey("dbo.GTO", "Procedimento_GTO_idGTO", "dbo.Procedimento_GTO", "idGTO");
            AddForeignKey("dbo.Procedimento", "Procedimento_GTO_idGTO", "dbo.Procedimento_GTO", "idGTO");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Procedimento", "Procedimento_GTO_idGTO", "dbo.Procedimento_GTO");
            DropForeignKey("dbo.GTO", "Procedimento_GTO_idGTO", "dbo.Procedimento_GTO");
            DropIndex("dbo.Procedimento", new[] { "Procedimento_GTO_idGTO" });
            DropIndex("dbo.GTO", new[] { "Procedimento_GTO_idGTO" });
            DropColumn("dbo.Procedimento", "Procedimento_GTO_idGTO");
            DropColumn("dbo.GTO", "Procedimento_GTO_idGTO");
            DropTable("dbo.Procedimento_GTO");
            RenameTable(name: "dbo.Procedimento", newName: "Procedimentos");
        }
    }
}
