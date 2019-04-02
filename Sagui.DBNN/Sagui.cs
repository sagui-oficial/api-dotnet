using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Sagui.Model;
using System;
using System.IO;

namespace Sagui.DB
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
        public DbSet<Lote> Lote { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.Development.json")
                .Build();
                var connectionString = configuration.GetConnectionString("DefaultConnection");
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GTO>().HasKey(c => new { c.Id, c.PublicID });
            modelBuilder.Entity<GTO>(b => { b.Property(u => u.PublicID).HasDefaultValueSql("newsequentialid()"); });

            modelBuilder.Entity<PlanoOperadora>().HasKey(c => new { c.Id, c.PublicID });
            modelBuilder.Entity<PlanoOperadora>(b => { b.Property(u => u.PublicID).HasDefaultValueSql("newsequentialid()"); });

            modelBuilder.Entity<UsuarioBase>().HasKey(c => new { c.Id, c.PublicID });
            modelBuilder.Entity<UsuarioBase>(b => { b.Property(u => u.PublicID).HasDefaultValueSql("newsequentialid()"); });

            modelBuilder.Entity<Procedimentos>().HasKey(c => new { c.IdProcedimento, c.PublicID });
            modelBuilder.Entity<Procedimentos>(b =>{b.Property(u => u.PublicID).HasDefaultValueSql("newsequentialid()");});

            modelBuilder.Entity<Arquivos>().HasKey(c => new { c.Id, c.PublicID });
            modelBuilder.Entity<Arquivos>(b => { b.Property(u => u.PublicID).HasDefaultValueSql("newsequentialid()"); });

            modelBuilder.Entity<Lote>().HasKey(c => new { c.IdLote, c.PublicID });
            modelBuilder.Entity<Lote>(b => { b.Property(u => u.PublicID).HasDefaultValueSql("newsequentialid()"); });


            // exemplo para remover os plurais das tabelas.
            //modelBuilder.Entity<Course>().ToTable("Course");
            //modelBuilder.Entity<Enrollment>().ToTable("Enrollment");
            //modelBuilder.Entity<Student>().ToTable("Student");
        }
    }
    
}
