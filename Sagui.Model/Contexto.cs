using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sagui.Model
{
    public class Contexto : DbContext
    {
        public DbSet<Arquivos> Arquivos { get; set; }
        public DbSet<GTO> GTO { get; set; }
        public DbSet<Operadora> Operadora { get; set; }
        public DbSet<Paciente> Paciente { get; set; }
        public DbSet<Plano> Plano { get; set; }
        public DbSet<Procedimentos> Procedimentos { get; set; }
    }
}
