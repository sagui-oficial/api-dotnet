namespace SaguiDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Removediscriminator : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.UsuarioBase", "Discriminator");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UsuarioBase", "TipoUsuario", c => c.String(maxLength: 128));
        }
    }
}
