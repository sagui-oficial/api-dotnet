namespace SaguiDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addpublicID : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Procedimentos");
            AddColumn("dbo.Procedimentos", "PublicID", c => c.Guid(nullable: false, identity: true));
            AlterColumn("dbo.Procedimentos", "IdProcedimento", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Procedimentos", new[] { "IdProcedimento", "PublicID" });
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Procedimentos");
            AlterColumn("dbo.Procedimentos", "IdProcedimento", c => c.Int(nullable: false, identity: true));
            DropColumn("dbo.Procedimentos", "PublicID");
            AddPrimaryKey("dbo.Procedimentos", "IdProcedimento");
        }
    }
}
