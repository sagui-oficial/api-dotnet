namespace Sagui.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _00criadasastabelasprincipais : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Arquivos",
                c => new
                    {
                        NomeArquivo = c.String(nullable: false, maxLength: 128),
                        DataArquivo = c.DateTime(nullable: false),
                        GTO_IdGTO = c.Int(),
                    })
                .PrimaryKey(t => t.NomeArquivo)
                .ForeignKey("dbo.GTOes", t => t.GTO_IdGTO)
                .Index(t => t.GTO_IdGTO);
            
            CreateTable(
                "dbo.GTOes",
                c => new
                    {
                        IdGTO = c.Int(nullable: false, identity: true),
                        NumeroGTO = c.Int(nullable: false),
                        Solicitacao = c.DateTime(nullable: false),
                        Vencimento = c.DateTime(nullable: false),
                        Status = c.Int(nullable: false),
                        Operadora_IdOperadora = c.Int(),
                        Paciente_IdPaciente = c.Int(),
                    })
                .PrimaryKey(t => t.IdGTO)
                .ForeignKey("dbo.Operadoras", t => t.Operadora_IdOperadora)
                .ForeignKey("dbo.Pacientes", t => t.Paciente_IdPaciente)
                .Index(t => t.Operadora_IdOperadora)
                .Index(t => t.Paciente_IdPaciente);
            
            CreateTable(
                "dbo.Operadoras",
                c => new
                    {
                        IdOperadora = c.Int(nullable: false, identity: true),
                        NomeOperadora = c.String(),
                    })
                .PrimaryKey(t => t.IdOperadora);
            
            CreateTable(
                "dbo.Pacientes",
                c => new
                    {
                        IdPaciente = c.Int(nullable: false, identity: true),
                        NomePaciente = c.String(),
                    })
                .PrimaryKey(t => t.IdPaciente);
            
            CreateTable(
                "dbo.Procedimentos",
                c => new
                    {
                        IdProcedimento = c.Int(nullable: false, identity: true),
                        Codigo = c.Int(nullable: false),
                        NomeProcedimento = c.String(),
                        ValorProcedimento = c.Double(nullable: false),
                        GTO_IdGTO = c.Int(),
                    })
                .PrimaryKey(t => t.IdProcedimento)
                .ForeignKey("dbo.GTOes", t => t.GTO_IdGTO)
                .Index(t => t.GTO_IdGTO);
            
            CreateTable(
                "dbo.Planoes",
                c => new
                    {
                        PlanoId = c.Int(nullable: false, identity: true),
                        NomeFantasia = c.String(),
                        RazaoSocial = c.String(),
                        CNPJ = c.String(),
                    })
                .PrimaryKey(t => t.PlanoId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Procedimentos", "GTO_IdGTO", "dbo.GTOes");
            DropForeignKey("dbo.GTOes", "Paciente_IdPaciente", "dbo.Pacientes");
            DropForeignKey("dbo.GTOes", "Operadora_IdOperadora", "dbo.Operadoras");
            DropForeignKey("dbo.Arquivos", "GTO_IdGTO", "dbo.GTOes");
            DropIndex("dbo.Procedimentos", new[] { "GTO_IdGTO" });
            DropIndex("dbo.GTOes", new[] { "Paciente_IdPaciente" });
            DropIndex("dbo.GTOes", new[] { "Operadora_IdOperadora" });
            DropIndex("dbo.Arquivos", new[] { "GTO_IdGTO" });
            DropTable("dbo.Planoes");
            DropTable("dbo.Procedimentos");
            DropTable("dbo.Pacientes");
            DropTable("dbo.Operadoras");
            DropTable("dbo.GTOes");
            DropTable("dbo.Arquivos");
        }
    }
}
