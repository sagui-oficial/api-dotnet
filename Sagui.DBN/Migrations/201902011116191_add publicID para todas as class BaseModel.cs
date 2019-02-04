namespace SaguiDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addpublicIDparatodasasclassBaseModel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Arquivos", "GTO_Id", "dbo.GTO");
            DropForeignKey("dbo.GTO", "Paciente_Id", "dbo.UsuarioBase");
            DropForeignKey("dbo.GTO", "PlanoOperadora_Id", "dbo.PlanoOperadora");
            DropForeignKey("dbo.Procedimentos", "GTO_Id", "dbo.GTO");
            DropForeignKey("dbo.PlanoOperadoraPaciente", "Paciente_Id", "dbo.UsuarioBase");
            DropForeignKey("dbo.PlanoOperadoraPaciente", "PlanoOperadora_Id", "dbo.PlanoOperadora");
            DropForeignKey("dbo.Arquivos", "PlanoOperadora_Id", "dbo.PlanoOperadora");
            DropForeignKey("dbo.Procedimentos", "PlanoOperadora_Id", "dbo.PlanoOperadora");
            DropIndex("dbo.Arquivos", new[] { "GTO_Id" });
            DropIndex("dbo.Arquivos", new[] { "PlanoOperadora_Id" });
            DropIndex("dbo.GTO", new[] { "Paciente_Id" });
            DropIndex("dbo.GTO", new[] { "PlanoOperadora_Id" });
            DropIndex("dbo.PlanoOperadoraPaciente", new[] { "PlanoOperadora_Id" });
            DropIndex("dbo.PlanoOperadoraPaciente", new[] { "Paciente_Id" });
            DropIndex("dbo.Procedimentos", new[] { "PlanoOperadora_Id" });
            DropIndex("dbo.Procedimentos", new[] { "GTO_Id" });

            //Pagara chaves estranhas
            DropColumn("dbo.Procedimentos",  "PlanoOperadora_Id" );
            DropColumn("dbo.Procedimentos",  "GTO_Id" );
            DropColumn("dbo.Arquivos", "PlanoOperadora_Id");
            DropColumn("dbo.Arquivos", "GTO_Id");

            DropPrimaryKey("dbo.GTO");
            DropPrimaryKey("dbo.UsuarioBase");
            DropPrimaryKey("dbo.PlanoOperadora");
            //AddColumn("dbo.Arquivos", "GTO_PublicID", c => c.Guid());
            //AddColumn("dbo.Arquivos", "PlanoOperadora_PublicID", c => c.Guid());
            AddColumn("dbo.GTO", "PublicID", c => c.Guid(nullable: false, identity: true));
            //AddColumn("dbo.GTO", "Paciente_PublicID", c => c.Guid());
            //AddColumn("dbo.GTO", "PlanoOperadora_PublicID", c => c.Guid());
            AddColumn("dbo.UsuarioBase", "PublicID", c => c.Guid(nullable: false, identity: true));
            //AddColumn("dbo.PlanoOperadoraPaciente", "PlanoOperadora_PublicID", c => c.Guid());
            //AddColumn("dbo.PlanoOperadoraPaciente", "Paciente_PublicID", c => c.Guid());
            AddColumn("dbo.PlanoOperadora", "PublicID", c => c.Guid(nullable: false, identity: true));
            //AddColumn("dbo.Procedimentos", "PlanoOperadora_PublicID", c => c.Guid());
            //AddColumn("dbo.Procedimentos", "GTO_PublicID", c => c.Guid());
            AlterColumn("dbo.GTO", "Id", c => c.Int(nullable: false));
            AlterColumn("dbo.UsuarioBase", "Id", c => c.Int(nullable: false));
            AlterColumn("dbo.PlanoOperadora", "Id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.GTO", new[] { "Id", "PublicID" });
            AddPrimaryKey("dbo.UsuarioBase", new[] { "Id", "PublicID" });
            AddPrimaryKey("dbo.PlanoOperadora", new[] { "Id", "PublicID" });
            //CreateIndex("dbo.Arquivos", new[] { "GTO_Id", "GTO_PublicID" });
            //CreateIndex("dbo.Arquivos", new[] { "PlanoOperadora_Id", "PlanoOperadora_PublicID" });
            //CreateIndex("dbo.GTO", new[] { "Paciente_Id", "Paciente_PublicID" });
            //CreateIndex("dbo.GTO", new[] { "PlanoOperadora_Id", "PlanoOperadora_PublicID" });
            //CreateIndex("dbo.PlanoOperadoraPaciente", new[] { "PlanoOperadora_Id", "PlanoOperadora_PublicID" });
            //CreateIndex("dbo.PlanoOperadoraPaciente", new[] { "Paciente_Id", "Paciente_PublicID" });
            //CreateIndex("dbo.Procedimentos", new[] { "PlanoOperadora_Id", "PlanoOperadora_PublicID" });
            //CreateIndex("dbo.Procedimentos", new[] { "GTO_Id", "GTO_PublicID" });
            //AddForeignKey("dbo.Arquivos", new[] { "GTO_Id", "GTO_PublicID" }, "dbo.GTO", new[] { "Id", "PublicID" });
            //AddForeignKey("dbo.GTO", new[] { "Paciente_Id", "Paciente_PublicID" }, "dbo.UsuarioBase", new[] { "Id", "PublicID" });
            //AddForeignKey("dbo.GTO", new[] { "PlanoOperadora_Id", "PlanoOperadora_PublicID" }, "dbo.PlanoOperadora", new[] { "Id", "PublicID" });
            //AddForeignKey("dbo.Procedimentos", new[] { "GTO_Id", "GTO_PublicID" }, "dbo.GTO", new[] { "Id", "PublicID" });
            //AddForeignKey("dbo.PlanoOperadoraPaciente", new[] { "Paciente_Id", "Paciente_PublicID" }, "dbo.UsuarioBase", new[] { "Id", "PublicID" });
            //AddForeignKey("dbo.PlanoOperadoraPaciente", new[] { "PlanoOperadora_Id", "PlanoOperadora_PublicID" }, "dbo.PlanoOperadora", new[] { "Id", "PublicID" });
            //AddForeignKey("dbo.Arquivos", new[] { "PlanoOperadora_Id", "PlanoOperadora_PublicID" }, "dbo.PlanoOperadora", new[] { "Id", "PublicID" });
            //AddForeignKey("dbo.Procedimentos", new[] { "PlanoOperadora_Id", "PlanoOperadora_PublicID" }, "dbo.PlanoOperadora", new[] { "Id", "PublicID" });
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Procedimentos", new[] { "PlanoOperadora_Id", "PlanoOperadora_PublicID" }, "dbo.PlanoOperadora");
            DropForeignKey("dbo.Arquivos", new[] { "PlanoOperadora_Id", "PlanoOperadora_PublicID" }, "dbo.PlanoOperadora");
            DropForeignKey("dbo.PlanoOperadoraPaciente", new[] { "PlanoOperadora_Id", "PlanoOperadora_PublicID" }, "dbo.PlanoOperadora");
            DropForeignKey("dbo.PlanoOperadoraPaciente", new[] { "Paciente_Id", "Paciente_PublicID" }, "dbo.UsuarioBase");
            DropForeignKey("dbo.Procedimentos", new[] { "GTO_Id", "GTO_PublicID" }, "dbo.GTO");
            DropForeignKey("dbo.GTO", new[] { "PlanoOperadora_Id", "PlanoOperadora_PublicID" }, "dbo.PlanoOperadora");
            DropForeignKey("dbo.GTO", new[] { "Paciente_Id", "Paciente_PublicID" }, "dbo.UsuarioBase");
            DropForeignKey("dbo.Arquivos", new[] { "GTO_Id", "GTO_PublicID" }, "dbo.GTO");
            DropIndex("dbo.Procedimentos", new[] { "GTO_Id", "GTO_PublicID" });
            DropIndex("dbo.Procedimentos", new[] { "PlanoOperadora_Id", "PlanoOperadora_PublicID" });
            DropIndex("dbo.PlanoOperadoraPaciente", new[] { "Paciente_Id", "Paciente_PublicID" });
            DropIndex("dbo.PlanoOperadoraPaciente", new[] { "PlanoOperadora_Id", "PlanoOperadora_PublicID" });
            DropIndex("dbo.GTO", new[] { "PlanoOperadora_Id", "PlanoOperadora_PublicID" });
            DropIndex("dbo.GTO", new[] { "Paciente_Id", "Paciente_PublicID" });
            DropIndex("dbo.Arquivos", new[] { "PlanoOperadora_Id", "PlanoOperadora_PublicID" });
            DropIndex("dbo.Arquivos", new[] { "GTO_Id", "GTO_PublicID" });
            DropPrimaryKey("dbo.PlanoOperadora");
            DropPrimaryKey("dbo.UsuarioBase");
            DropPrimaryKey("dbo.GTO");
            AlterColumn("dbo.PlanoOperadora", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.UsuarioBase", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.GTO", "Id", c => c.Int(nullable: false, identity: true));
            DropColumn("dbo.Procedimentos", "GTO_PublicID");
            DropColumn("dbo.Procedimentos", "PlanoOperadora_PublicID");
            DropColumn("dbo.PlanoOperadora", "PublicID");
            DropColumn("dbo.PlanoOperadoraPaciente", "Paciente_PublicID");
            DropColumn("dbo.PlanoOperadoraPaciente", "PlanoOperadora_PublicID");
            DropColumn("dbo.UsuarioBase", "PublicID");
            DropColumn("dbo.GTO", "PlanoOperadora_PublicID");
            DropColumn("dbo.GTO", "Paciente_PublicID");
            DropColumn("dbo.GTO", "PublicID");
            DropColumn("dbo.Arquivos", "PlanoOperadora_PublicID");
            DropColumn("dbo.Arquivos", "GTO_PublicID");
            AddPrimaryKey("dbo.PlanoOperadora", "Id");
            AddPrimaryKey("dbo.UsuarioBase", "Id");
            AddPrimaryKey("dbo.GTO", "Id");
            CreateIndex("dbo.Procedimentos", "GTO_Id");
            CreateIndex("dbo.Procedimentos", "PlanoOperadora_Id");
            CreateIndex("dbo.PlanoOperadoraPaciente", "Paciente_Id");
            CreateIndex("dbo.PlanoOperadoraPaciente", "PlanoOperadora_Id");
            CreateIndex("dbo.GTO", "PlanoOperadora_Id");
            CreateIndex("dbo.GTO", "Paciente_Id");
            CreateIndex("dbo.Arquivos", "PlanoOperadora_Id");
            CreateIndex("dbo.Arquivos", "GTO_Id");
            AddForeignKey("dbo.Procedimentos", "PlanoOperadora_Id", "dbo.PlanoOperadora", "Id");
            AddForeignKey("dbo.Arquivos", "PlanoOperadora_Id", "dbo.PlanoOperadora", "Id");
            AddForeignKey("dbo.PlanoOperadoraPaciente", "PlanoOperadora_Id", "dbo.PlanoOperadora", "Id");
            AddForeignKey("dbo.PlanoOperadoraPaciente", "Paciente_Id", "dbo.UsuarioBase", "Id");
            AddForeignKey("dbo.Procedimentos", "GTO_Id", "dbo.GTO", "Id");
            AddForeignKey("dbo.GTO", "PlanoOperadora_Id", "dbo.PlanoOperadora", "Id");
            AddForeignKey("dbo.GTO", "Paciente_Id", "dbo.UsuarioBase", "Id");
            AddForeignKey("dbo.Arquivos", "GTO_Id", "dbo.GTO", "Id");
        }
    }
}
