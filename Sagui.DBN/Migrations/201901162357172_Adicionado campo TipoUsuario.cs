namespace SaguiDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdicionadocampoTipoUsuario : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UsuarioBase", "TipoUsuario", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.UsuarioBase", "TipoUsuario");
        }
    }
}
