namespace SaguiDB.Migrations
{
    using global::Sagui.Model;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SaguiDB.Sagui>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(SaguiDB.Sagui context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.


            if (!context.Procedimento.Any())
            {
                var procedimentos = new List<Procedimentos>
                {
                new Procedimentos{Codigo=1,NomeProcedimento="Alexander",Exigencias="2005-09-01", Anotacoes="AAAAAAAAAAAAA", ValorProcedimento= 1.0},
                new Procedimentos{Codigo=2,NomeProcedimento="Fabio",Exigencias="2005-09-01", Anotacoes="AAAAAAAAAAAAA", ValorProcedimento= 1.0},
                };

                procedimentos.ForEach(s => context.Procedimento.Add(s));
                context.SaveChanges();
            }

            if (!context.PlanoOperadora.Any())
            {
                var planoOperadora = new List<PlanoOperadora>
                {
                new PlanoOperadora{NomeFantasia="Plano 1", RazaoSocial="Plano numero 1", CNPJ="00000000000000", DataEnvioLote=DateTime.Parse("2019-09-01"),DataRecebimentoLote=DateTime.Parse("2019-09-01")},
                new PlanoOperadora{NomeFantasia="Plano 2", RazaoSocial="Plano numero 2", CNPJ="00000000000001", DataEnvioLote=DateTime.Parse("2019-09-01"),DataRecebimentoLote=DateTime.Parse("2019-09-01")},
                };

                planoOperadora.ForEach(s => context.PlanoOperadora.Add(s));
                context.SaveChanges();
            }



        }
    }
}
