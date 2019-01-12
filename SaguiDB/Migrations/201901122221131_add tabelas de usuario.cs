namespace SaguiDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addtabelasdeusuario : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Paciente", newName: "UsuarioBase");
            DropForeignKey("dbo.GTO", "Operadora_IdOperadora", "dbo.Operadora");
            DropForeignKey("dbo.GTO", "Paciente_IdPaciente", "dbo.Paciente");
            DropIndex("dbo.GTO", new[] { "Operadora_IdOperadora" });
            RenameColumn(table: "dbo.GTO", name: "Paciente_IdPaciente", newName: "Paciente_Id");
            RenameIndex(table: "dbo.GTO", name: "IX_Paciente_IdPaciente", newName: "IX_Paciente_Id");
            DropPrimaryKey("dbo.UsuarioBase");
            CreateTable(
                "dbo.PlanoOperadora",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NomeFantasia = c.String(),
                        RazaoSocial = c.String(),
                        CNPJ = c.String(),
                        DataEnvioLote = c.DateTime(nullable: false),
                        DataRecebimentoLote = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Arquivos", "PlanoOperadora_Id", c => c.Int());
            AddColumn("dbo.GTO", "PlanoOperadora_Id", c => c.Int());

            //DropColumn("dbo.UsuarioBase", "IdPaciente");
            //DropColumn("dbo.UsuarioBase", "NomePaciente");

            AddColumn("dbo.UsuarioBase", "Id", c => c.Int(nullable: false));
            AlterColumn("dbo.UsuarioBase", "Id", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.UsuarioBase", "Funcao", c => c.String());
            AddColumn("dbo.UsuarioBase", "Nome", c => c.String());
            AddColumn("dbo.UsuarioBase", "Anotacoes", c => c.String());
            AddColumn("dbo.UsuarioBase", "CPF", c => c.String());
            AddColumn("dbo.UsuarioBase", "Email", c => c.String());
            AddColumn("dbo.UsuarioBase", "Telefone", c => c.String());
            AddColumn("dbo.UsuarioBase", "CRO", c => c.String());
            AddColumn("dbo.UsuarioBase", "NumeroPlano", c => c.String());
            AddColumn("dbo.UsuarioBase", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.UsuarioBase", "PlanoOperadora_Id", c => c.Int());
            AddColumn("dbo.Procedimentos", "PlanoOperadora_Id", c => c.Int());
            AddPrimaryKey("dbo.UsuarioBase", "Id");
            CreateIndex("dbo.Arquivos", "PlanoOperadora_Id");
            CreateIndex("dbo.UsuarioBase", "PlanoOperadora_Id");
            CreateIndex("dbo.GTO", "PlanoOperadora_Id");
            CreateIndex("dbo.Procedimentos", "PlanoOperadora_Id");
            AddForeignKey("dbo.Arquivos", "PlanoOperadora_Id", "dbo.PlanoOperadora", "Id");
            AddForeignKey("dbo.Procedimentos", "PlanoOperadora_Id", "dbo.PlanoOperadora", "Id");
            AddForeignKey("dbo.UsuarioBase", "PlanoOperadora_Id", "dbo.PlanoOperadora", "Id");
            AddForeignKey("dbo.GTO", "PlanoOperadora_Id", "dbo.PlanoOperadora", "Id");
            AddForeignKey("dbo.GTO", "Paciente_Id", "dbo.UsuarioBase", "Id");
            DropColumn("dbo.GTO", "Operadora_IdOperadora");
            DropColumn("dbo.UsuarioBase", "IdPaciente");
            DropColumn("dbo.UsuarioBase", "NomePaciente");
            DropTable("dbo.Operadora");
            DropTable("dbo.Plano");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Plano",
                c => new
                    {
                        PlanoId = c.Int(nullable: false, identity: true),
                        NomeFantasia = c.String(),
                        RazaoSocial = c.String(),
                        CNPJ = c.String(),
                    })
                .PrimaryKey(t => t.PlanoId);
            
            CreateTable(
                "dbo.Operadora",
                c => new
                    {
                        IdOperadora = c.Int(nullable: false, identity: true),
                        NomeOperadora = c.String(),
                    })
                .PrimaryKey(t => t.IdOperadora);
            
            AddColumn("dbo.UsuarioBase", "NomePaciente", c => c.String());
            AddColumn("dbo.UsuarioBase", "IdPaciente", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.GTO", "Operadora_IdOperadora", c => c.Int());
            DropForeignKey("dbo.GTO", "Paciente_Id", "dbo.UsuarioBase");
            DropForeignKey("dbo.GTO", "PlanoOperadora_Id", "dbo.PlanoOperadora");
            DropForeignKey("dbo.UsuarioBase", "PlanoOperadora_Id", "dbo.PlanoOperadora");
            DropForeignKey("dbo.Procedimentos", "PlanoOperadora_Id", "dbo.PlanoOperadora");
            DropForeignKey("dbo.Arquivos", "PlanoOperadora_Id", "dbo.PlanoOperadora");
            DropIndex("dbo.Procedimentos", new[] { "PlanoOperadora_Id" });
            DropIndex("dbo.GTO", new[] { "PlanoOperadora_Id" });
            DropIndex("dbo.UsuarioBase", new[] { "PlanoOperadora_Id" });
            DropIndex("dbo.Arquivos", new[] { "PlanoOperadora_Id" });
            DropPrimaryKey("dbo.UsuarioBase");
            DropColumn("dbo.Procedimentos", "PlanoOperadora_Id");
            DropColumn("dbo.UsuarioBase", "PlanoOperadora_Id");
            DropColumn("dbo.UsuarioBase", "Discriminator");
            DropColumn("dbo.UsuarioBase", "NumeroPlano");
            DropColumn("dbo.UsuarioBase", "CRO");
            DropColumn("dbo.UsuarioBase", "Telefone");
            DropColumn("dbo.UsuarioBase", "Email");
            DropColumn("dbo.UsuarioBase", "CPF");
            DropColumn("dbo.UsuarioBase", "Anotacoes");
            DropColumn("dbo.UsuarioBase", "Nome");
            DropColumn("dbo.UsuarioBase", "Funcao");
            DropColumn("dbo.UsuarioBase", "Id");
            DropColumn("dbo.GTO", "PlanoOperadora_Id");
            DropColumn("dbo.Arquivos", "PlanoOperadora_Id");
            DropTable("dbo.PlanoOperadora");
            AddPrimaryKey("dbo.UsuarioBase", "IdPaciente");
            RenameIndex(table: "dbo.GTO", name: "IX_Paciente_Id", newName: "IX_Paciente_IdPaciente");
            RenameColumn(table: "dbo.GTO", name: "Paciente_Id", newName: "Paciente_IdPaciente");
            CreateIndex("dbo.GTO", "Operadora_IdOperadora");
            AddForeignKey("dbo.GTO", "Paciente_IdPaciente", "dbo.Paciente", "IdPaciente");
            AddForeignKey("dbo.GTO", "Operadora_IdOperadora", "dbo.Operadora", "IdOperadora");
            RenameTable(name: "dbo.UsuarioBase", newName: "Paciente");
        }
    }
}
