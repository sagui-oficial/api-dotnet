using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sagui.Model
{
    public class Procedimentos
    {[Key]
        public int IdProcedimento { get; set; }
        public int Codigo { get; set; }
        public string NomeProcedimento { get; set; }
        public double ValorProcedimento { get; set; }
    }
}
