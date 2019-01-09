using Sagui.Model;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace SaguiDB
{
    public class Sagui : DbContext
    {

        public Sagui() : base("sagui")
        {
            
        }

        public DbSet<Arquivos> Arquivo { get; set; }
        public DbSet<GTO> GTO { get; set; }
        public DbSet<PlanoOperadora> PlanoOperadora { get; set; }
        public DbSet<Paciente> Paciente { get; set; }
        public DbSet<Procedimentos> Procedimento { get; set; }
        public DbSet<Procedimento_GTO> Procedimento_GTO { get; set; }
        public DbSet<Arquivo_GTO> Arquivo_GTO { get; set; }
        

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {            
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }

}