using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sagui.Model
{
   public class Procedimento_GTO
    {
        [Key]
        public int idProcedimento_GTO { get; set; }
        public int idGTO { get; set; }
        public int idProcedimento { get; set; }

        //public ICollection<GTO> GTO { get; set; }
        //public ICollection<Procedimentos> Procedimento { get; set; }
    }
}
