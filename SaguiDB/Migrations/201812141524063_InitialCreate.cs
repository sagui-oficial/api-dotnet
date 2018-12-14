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
                    // GTO_Id = c.Int(),
                })
                .PrimaryKey(t => t.Id);
                //.ForeignKey("dbo.GTO", t => t.GTO_Id)
                //.Index(t => t.GTO_Id);
            
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
                        Operadora_IdOperadora = c.Int(),
                        Paciente_IdPaciente = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Operadora", t => t.Operadora_IdOperadora)
                .ForeignKey("dbo.Paciente", t => t.Paciente_IdPaciente)
                .Index(t => t.Operadora_IdOperadora)
                .Index(t => t.Paciente_IdPaciente);
            
            CreateTable(
                "dbo.Operadora",
                c => new
                    {
                        IdOperadora = c.Int(nullable: false, identity: true),
                        NomeOperadora = c.String(),
                    })
                .PrimaryKey(t => t.IdOperadora);
            
            CreateTable(
                "dbo.Paciente",
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
                    Exigencias = c.String(),
                    Anotacoes = c.String(),
                    //GTO_Id = c.Int(),
                })
                .PrimaryKey(t => t.IdProcedimento);
                //.ForeignKey("dbo.GTO", t => t.GTO_Id)
                //.Index(t => t.GTO_Id);
            
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
            DropForeignKey("dbo.GTO", "Paciente_IdPaciente", "dbo.Paciente");
            DropForeignKey("dbo.GTO", "Operadora_IdOperadora", "dbo.Operadora");
            DropForeignKey("dbo.Arquivos", "GTO_Id", "dbo.GTO");
            DropIndex("dbo.Procedimentos", new[] { "GTO_Id" });
            DropIndex("dbo.GTO", new[] { "Paciente_IdPaciente" });
            DropIndex("dbo.GTO", new[] { "Operadora_IdOperadora" });
            DropIndex("dbo.Arquivos", new[] { "GTO_Id" });
            DropTable("dbo.Procedimento_GTO");
            DropTable("dbo.Plano");
            DropTable("dbo.Procedimentos");
            DropTable("dbo.Paciente");
            DropTable("dbo.Operadora");
            DropTable("dbo.GTO");
            DropTable("dbo.Arquivo_GTO");
            DropTable("dbo.Arquivos");
        }
    }
}
