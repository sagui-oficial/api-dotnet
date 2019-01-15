namespace SaguiDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Arquivos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Stream = c.Binary(),
                        DataCriacao = c.DateTime(nullable: false),
                        PathArquivo = c.String(),
                        GTO_Id = c.Int(),
                        PlanoOperadora_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.GTO", t => t.GTO_Id)
                .ForeignKey("dbo.PlanoOperadora", t => t.PlanoOperadora_Id)
                .Index(t => t.GTO_Id)
                .Index(t => t.PlanoOperadora_Id);
            
            CreateTable(
                "dbo.Arquivo_GTO",
                c => new
                    {
                        idArquivo_GTO = c.Int(nullable: false, identity: true),
                        idGTO = c.Int(nullable: false),
                        idArquivo = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.idArquivo_GTO);
            
            CreateTable(
                "dbo.GTO",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Numero = c.Int(nullable: false),
                        Solicitacao = c.DateTime(nullable: false),
                        Vencimento = c.DateTime(nullable: false),
                        Status = c.Int(nullable: false),
                        Paciente_Id = c.Int(),
                        PlanoOperadora_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UsuarioBase", t => t.Paciente_Id)
                .ForeignKey("dbo.PlanoOperadora", t => t.PlanoOperadora_Id)
                .Index(t => t.Paciente_Id)
                .Index(t => t.PlanoOperadora_Id);
            
            CreateTable(
                "dbo.UsuarioBase",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Funcao = c.String(),
                        Nome = c.String(),
                        Anotacoes = c.String(),
                        CPF = c.String(),
                        Email = c.String(),
                        Telefone = c.String(),
                        CRO = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PlanoOperadoraPaciente",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        NumeroPlano = c.String(),
                        PlanoOperadora_Id = c.Int(),
                        Paciente_Id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.PlanoOperadora", t => t.PlanoOperadora_Id)
                .ForeignKey("dbo.UsuarioBase", t => t.Paciente_Id)
                .Index(t => t.PlanoOperadora_Id)
                .Index(t => t.Paciente_Id);
            
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
            
            CreateTable(
                "dbo.Procedimentos",
                c => new
                    {
                        IdProcedimento = c.Int(nullable: false, identity: true),
                        Codigo = c.Int(nullable: false),
                        NomeProcedimento = c.String(),
                        ValorProcedimento = c.Double(nullable: false),
                        Exigencias = c.String(),
                        Anotacoes = c.String(),
                        PlanoOperadora_Id = c.Int(),
                        GTO_Id = c.Int(),
                    })
                .PrimaryKey(t => t.IdProcedimento)
                .ForeignKey("dbo.PlanoOperadora", t => t.PlanoOperadora_Id)
                .ForeignKey("dbo.GTO", t => t.GTO_Id)
                .Index(t => t.PlanoOperadora_Id)
                .Index(t => t.GTO_Id);
            
            CreateTable(
                "dbo.Procedimento_GTO",
                c => new
                    {
                        idProcedimento_GTO = c.Int(nullable: false, identity: true),
                        idGTO = c.Int(nullable: false),
                        idProcedimento = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.idProcedimento_GTO);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Procedimentos", "GTO_Id", "dbo.GTO");
            DropForeignKey("dbo.GTO", "PlanoOperadora_Id", "dbo.PlanoOperadora");
            DropForeignKey("dbo.GTO", "Paciente_Id", "dbo.UsuarioBase");
            DropForeignKey("dbo.PlanoOperadoraPaciente", "Paciente_Id", "dbo.UsuarioBase");
            DropForeignKey("dbo.PlanoOperadoraPaciente", "PlanoOperadora_Id", "dbo.PlanoOperadora");
            DropForeignKey("dbo.Procedimentos", "PlanoOperadora_Id", "dbo.PlanoOperadora");
            DropForeignKey("dbo.Arquivos", "PlanoOperadora_Id", "dbo.PlanoOperadora");
            DropForeignKey("dbo.Arquivos", "GTO_Id", "dbo.GTO");
            DropIndex("dbo.Procedimentos", new[] { "GTO_Id" });
            DropIndex("dbo.Procedimentos", new[] { "PlanoOperadora_Id" });
            DropIndex("dbo.PlanoOperadoraPaciente", new[] { "Paciente_Id" });
            DropIndex("dbo.PlanoOperadoraPaciente", new[] { "PlanoOperadora_Id" });
            DropIndex("dbo.GTO", new[] { "PlanoOperadora_Id" });
            DropIndex("dbo.GTO", new[] { "Paciente_Id" });
            DropIndex("dbo.Arquivos", new[] { "PlanoOperadora_Id" });
            DropIndex("dbo.Arquivos", new[] { "GTO_Id" });
            DropTable("dbo.Procedimento_GTO");
            DropTable("dbo.Procedimentos");
            DropTable("dbo.PlanoOperadora");
            DropTable("dbo.PlanoOperadoraPaciente");
            DropTable("dbo.UsuarioBase");
            DropTable("dbo.GTO");
            DropTable("dbo.Arquivo_GTO");
            DropTable("dbo.Arquivos");
        }
    }
}
