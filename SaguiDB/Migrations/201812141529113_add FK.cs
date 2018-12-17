namespace SaguiDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addFK : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Arquivos", "Arquivo_GTO_idArquivo_GTO", c => c.Int());
            AddColumn("dbo.GTO", "Arquivo_GTO_idArquivo_GTO", c => c.Int());
            AddColumn("dbo.GTO", "Procedimento_GTO_idProcedimento_GTO", c => c.Int());
            AddColumn("dbo.Procedimentos", "Procedimento_GTO_idProcedimento_GTO", c => c.Int());
            CreateIndex("dbo.Arquivos", "Arquivo_GTO_idArquivo_GTO");
            CreateIndex("dbo.GTO", "Arquivo_GTO_idArquivo_GTO");
            CreateIndex("dbo.GTO", "Procedimento_GTO_idProcedimento_GTO");
            CreateIndex("dbo.Procedimentos", "Procedimento_GTO_idProcedimento_GTO");
            AddForeignKey("dbo.Arquivos", "Arquivo_GTO_idArquivo_GTO", "dbo.Arquivo_GTO", "idArquivo_GTO");
            AddForeignKey("dbo.GTO", "Arquivo_GTO_idArquivo_GTO", "dbo.Arquivo_GTO", "idArquivo_GTO");
            AddForeignKey("dbo.GTO", "Procedimento_GTO_idProcedimento_GTO", "dbo.Procedimento_GTO", "idProcedimento_GTO");
            AddForeignKey("dbo.Procedimentos", "Procedimento_GTO_idProcedimento_GTO", "dbo.Procedimento_GTO", "idProcedimento_GTO");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Procedimentos", "Procedimento_GTO_idProcedimento_GTO", "dbo.Procedimento_GTO");
            DropForeignKey("dbo.GTO", "Procedimento_GTO_idProcedimento_GTO", "dbo.Procedimento_GTO");
            DropForeignKey("dbo.GTO", "Arquivo_GTO_idArquivo_GTO", "dbo.Arquivo_GTO");
            DropForeignKey("dbo.Arquivos", "Arquivo_GTO_idArquivo_GTO", "dbo.Arquivo_GTO");
            DropIndex("dbo.Procedimentos", new[] { "Procedimento_GTO_idProcedimento_GTO" });
            DropIndex("dbo.GTO", new[] { "Procedimento_GTO_idProcedimento_GTO" });
            DropIndex("dbo.GTO", new[] { "Arquivo_GTO_idArquivo_GTO" });
            DropIndex("dbo.Arquivos", new[] { "Arquivo_GTO_idArquivo_GTO" });
            DropColumn("dbo.Procedimentos", "Procedimento_GTO_idProcedimento_GTO");
            DropColumn("dbo.GTO", "Procedimento_GTO_idProcedimento_GTO");
            DropColumn("dbo.GTO", "Arquivo_GTO_idArquivo_GTO");
            DropColumn("dbo.Arquivos", "Arquivo_GTO_idArquivo_GTO");
        }
    }
}
