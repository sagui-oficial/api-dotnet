using Microsoft.EntityFrameworkCore;
using Sagui.Model;
using System;

namespace Sagui.DBNN
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

            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB");//, b => b.MigrationsAssembly("Sagui.Application"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Course>().ToTable("Course");
            //modelBuilder.Entity<Enrollment>().ToTable("Enrollment");
            //modelBuilder.Entity<Student>().ToTable("Student");
        }
    }
    
}
