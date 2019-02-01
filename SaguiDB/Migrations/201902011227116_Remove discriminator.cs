namespace SaguiDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Removediscriminator : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.UsuarioBase", "Discriminator", c => c.String(maxLength: 128));
        }
        
        public override void Down()
        {
            AddColumn("dbo.UsuarioBase", "TipoUsuario", c => c.String(nullable: false, maxLength: 128));
        }
    }
}
