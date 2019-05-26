using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Sagui.Model;

namespace Sagui.Postgres
{
    public class Sagui : DbContext
    {
        public Sagui(DbContextOptions<Sagui> options) : base(options)
        {

        }
        // required when local database deleted
       
        public DbSet<Arquivo_GTO> Arquivo_GTO { get; set; }
        public DbSet<Arquivos> Arquivo { get; set; }
        public DbSet<GTO> GTO { get; set; }
        public DbSet<PlanoOperadora> PlanoOperadora { get; set; }
        public DbSet<Procedimento_GTO> Procedimento_GTO { get; set; }
        public DbSet<Procedimentos> Procedimento { get; set; }
        public DbSet<UsuarioBase> UsuarioBase { get; set; }
        public DbSet<Dentinsta> Dentinsta { get; set; }
        public DbSet<Funcionario> Funcionario { get; set; }
        public DbSet<Paciente> Paciente { get; set; }
        public DbSet<PlanoOperadoraPaciente> PlanoOperadoraPaciente { get; set; }
        public DbSet<Lote> Lote { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
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

            modelBuilder.Entity<Procedimentos>().HasKey(c => new { c.Id, c.PublicID });
            modelBuilder.Entity<Procedimentos>(b => { b.Property(u => u.PublicID).HasDefaultValueSql("uuid_generate_v1()"); });

            modelBuilder.Entity<Arquivos>().HasKey(c => new { c.Id, c.PublicID });
            modelBuilder.Entity<Arquivos>(b => { b.Property(u => u.PublicID).HasDefaultValueSql("uuid_generate_v1()"); });

        }
       
    }
}
