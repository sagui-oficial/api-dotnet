using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Sagui.Data;
using Sagui.Model;
using System;
using System.Collections.Generic;

namespace Sagui.Postgres
{
    public class Sagui : DbContext
    {
        public Sagui(DbContextOptions<Sagui> options) : base(options)
        {

        }

        public DbSet<Arquivo_GTO> Arquivo_GTO { get; set; }
        public DbSet<Arquivos> Arquivo { get; set; }
        public DbSet<GTO> GTO { get; set; }
        public DbSet<PlanoOperadora> PlanoOperadora { get; set; }
        public DbSet<Procedimento_GTO> Procedimento_GTO { get; set; }
        public DbSet<Procedimentos> Procedimento { get; set; }
        public DbSet<UsuarioBase> UsuarioBase { get; set; }
        public DbSet<PlanoOperadoraPaciente> PlanoOperadoraPaciente { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.Development.json")
                .Build();
                var connectionString = configuration.GetConnectionString("SaguiPostgres");
                optionsBuilder.UseNpgsql(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GTO>().HasKey(c => new { c.Id, c.PublicID });
            modelBuilder.Entity<GTO>(b => { b.Property(u => u.PublicID).HasDefaultValueSql("uuid_generate_v1()"); });

            modelBuilder.Entity<PlanoOperadora>().HasKey(c => new { c.Id, c.PublicID });
            modelBuilder.Entity<PlanoOperadora>(b => { b.Property(u => u.PublicID).HasDefaultValueSql("uuid_generate_v1()"); });

            modelBuilder.Entity<UsuarioBase>().HasKey(c => new { c.Id, c.PublicID });
            modelBuilder.Entity<UsuarioBase>(b => { b.Property(u => u.PublicID).HasDefaultValueSql("uuid_generate_v1()"); });

            modelBuilder.Entity<Procedimentos>().HasKey(c => new { c.IdProcedimento, c.PublicID });
            modelBuilder.Entity<Procedimentos>(b => { b.Property(u => u.PublicID).HasDefaultValueSql("uuid_generate_v1()"); });

            modelBuilder.Entity<Arquivos>().HasKey(c => new { c.Id, c.PublicID });
            modelBuilder.Entity<Arquivos>(b => { b.Property(u => u.PublicID).HasDefaultValueSql("newsequentialid()"); });




           // Seed(modelBuilder);



            // exemplo para remover os plurais das tabelas.
            //modelBuilder.Entity<Course>().ToTable("Course");

        }


        public void Seed(ModelBuilder modelBuilder) {


            var procedimentos = new List<Procedimentos>
                        {
                        new Procedimentos{Codigo=1,NomeProcedimento="Procedimento 1",Exigencias="AAAAAAAAAAAAA", Anotacoes="AAAAAAAAAAAAA", ValorProcedimento= 1.0, Status= 1, PublicID = new Guid() },
                        new Procedimentos{Codigo=2,NomeProcedimento="Procedimento 2",Exigencias="AAAAAAAAAAAAA", Anotacoes="AAAAAAAAAAAAA", ValorProcedimento= 1.0, Status= 1, PublicID = new Guid() },
                        };



            //modelBuilder.Entity<Procedimentos>().HasData(procedimentos);
        }
    }
}
