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

        public DbSet<Arquivos> Arquivos { get; set; }
        public DbSet<GTO> GTO { get; set; }
        public DbSet<Operadora> Operadora { get; set; }
        public DbSet<Paciente> Paciente { get; set; }
        public DbSet<Plano> Plano { get; set; }
        public DbSet<Procedimentos> Procedimentos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }

}