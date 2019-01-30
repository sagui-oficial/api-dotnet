namespace SaguiDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Alteradonumerodagtiparastring : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.GTO", "Numero", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.GTO", "Numero", c => c.Int(nullable: false));
        }
    }
}
